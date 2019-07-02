using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookShop.Models;
using Microsoft.AspNetCore.Authorization;

namespace BookShop.Controllers
{
    [Authorize]
    public class OrderListsController : Controller
    {
        private readonly BookShopContext _context;
        private static int flag = 0;
        private static int orderid = -1;

        public void init()
        {
            if (flag == 0)
            {
                flag = 1;
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var order = _context.Order
                    .FirstOrDefaultAsync(m => m.OwnerId == userId);
                if (order.Result == null)
                {
                    Order tempOrder = new Order();
                    tempOrder.OwnerId = userId;
                    _context.Add(tempOrder);
                    _context.SaveChanges();

                    order = _context.Order
                        .FirstOrDefaultAsync(m => m.OwnerId == userId);
                    orderid = order.Result.Orderid;

                //    OrderList tempList=new OrderList();
                //    tempList.Orderid = orderid;
                //    tempList.Bookid = _context.Book.First().id;
                 //   _context.Add(tempList);
                 //   _context.SaveChanges();
                    return;
                }
                order = _context.Order
                    .FirstOrDefaultAsync(m => m.OwnerId == userId);
                orderid = order.Result.Orderid;
            }

        }
        public OrderListsController(BookShopContext context)
        {
            _context = context;
           
        }

        // GET: OrderLists
        public async Task<IActionResult> Index()
        {
         //   var orderlist= await _context.OrderList.FindAsync(m => m.Orderid == orderid);
       //     _context.OrderList.All()

            init();
            ViewData["orderid"] = orderid.ToString();
        //    return View(await  as IEnumerable<OrderList>);
            return View(await _context.OrderList.ToListAsync());
        }

        // GET: OrderLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderList = await _context.OrderList
                .FirstOrDefaultAsync(m => m.id == id);
            if (orderList == null)
            {
                return NotFound();
            }

            return View(orderList);
        }

        // GET: OrderLists/Create
        public IActionResult Create()
        {
            ViewData["orderid"] = orderid;
            
            return View();
        }

        // POST: OrderLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Orderid,Bookid")] OrderList orderList)
        {
            if (ModelState.IsValid)
            {
                if (orderList.Orderid != orderid)
                {
                    return NoContent();
                } 
                _context.Add(orderList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderList);
        }

        // GET: OrderLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["orderid"] = orderid;
            if (id == null)
            {
                return NotFound();
            }

            var orderList = await _context.OrderList.FindAsync(id);
            if (orderList == null)
            {
                return NotFound();
            }
            return View(orderList);
        }

        // POST: OrderLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Orderid,Bookid")] OrderList orderList)
        {
            ViewData["orderid"] = orderid;
            if (id != orderList.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderListExists(orderList.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(orderList);
        }

        // GET: OrderLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderList = await _context.OrderList
                .FirstOrDefaultAsync(m => m.id == id);
            if (orderList == null)
            {
                return NotFound();
            }

            return View(orderList);
        }

        // POST: OrderLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderList = await _context.OrderList.FindAsync(id);
            _context.OrderList.Remove(orderList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderListExists(int id)
        {
            return _context.OrderList.Any(e => e.id == id);
        }
    }
}

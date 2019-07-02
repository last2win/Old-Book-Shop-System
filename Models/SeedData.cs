using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookShopContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BookShopContext>>()))
            {
                if (context.Book.Any())
                {
                    ;   // DB has been seeded
                }
                else
                {
                    context.Book.AddRange(
                        new Book
                        {
                            id = 1,
                            OwnerId = "1076e8bd-6f74-4032-92b7-fe349d4acfc0",
                            Name = "埃及四千年",
                            Content =
                                "埃及——世界上最伟大的文明体，其古代故事跨越了四千多年的历史时段，而这一历史时段又塑造了日后整个世界的形态。英国古埃及研究权威、BBC古埃及历史纪录片首席讲解乔安·弗莱彻教授将古埃及的往事连缀成书，完整地讲述出来，记录王朝的兴衰沉浮，并将古埃及人的整个世界呈现于我们每个人都可以理解的一个历史情境之中。",
                            Price = 118,
                            SoldPrice = 50,
                            Author = "乔安·弗莱彻"

                        },
                        new Book
                        {
                            id = 2,
                            OwnerId = "1076e8bd-6f74-4032-92b7-fe349d4acfc0",
                            Name = "活着",
                            Content = "余华是我国当代著名作家，也是享誉世界的小说家，曾荣获众多国内外奖项。",
                            Price = 28,
                            SoldPrice = 18,
                            Author = "余华"

                        },
                        new Book
                        {
                            id = 3,
                            OwnerId = "nobody",
                            Name = "三体",
                            Content = "三体人在利用科技锁死了地球人的科学之后，出动庞大的宇宙舰队直扑太阳系，面对地球文明前所未有的危局",
                            Price = 46,
                            SoldPrice = 20,
                            Author = "刘慈欣"

                        }

                    );
                }

                if (context.Want.Any())
                {
                    ;
                }
                else
                {
                    context.Want.AddRange(
                        new Want
                        {
                            id = 1,
                            OwnerId = "1076e8bd-6f74-4032-92b7-fe349d4acfc0",
                            Name = "Java从入门到精通",
                            Price = 30
                        },
                        new Want
                        {
                            id = 2,
                            OwnerId = "nobody",
                            Name = "MySQL从入门到精通",
                            Price = 20
                        }


                        );
                }

                context.SaveChanges();
            }
        }
    }
 
}


代码在GitHub仓库：[zhang0peter/Old-Book-Shop-System: Old Book Shop System ASP .Net Core MVC MySQL e-commerce](https://github.com/zhang0peter/Old-Book-Shop-System)

我使用的是VS 2019， .NET Core的版本是2.2，数据库是mariadb，MySQL也可以。

使用前先修改appsettings.json文件中的数据库连接字符串：
```c
"DeafultConnection2": "server=localhost;port=3306;database=bookshop;user=root;Password=test;CharSet=utf8;"
```
然后对数据库进行迁移：
```js
dotnet ef migrations add InitialCreate -Context ApplicationDbContext
dotnet ef database update -Context ApplicationDbContext

dotnet ef migrations add InitialCreate2 -Context BookShopContext
dotnet ef database update -Context BookShopContext
```

然后使用数据库，手动增加用户，因为我的默认用户的Id需要统一：
```sql
use bookshop;

INSERT INTO `aspnetusers` (Id, UserName, NormalizedUserName, Email, NormalizedEmail,EmailConfirmed,
										PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumberConfirmed,TwoFactorEnabled,
										LockoutEnabled,AccessFailedCount) VALUES 
( 
    '1076e8bd-6f74-4032-92b7-fe349d4acfc0', 
    '123@123.com', 
    '123@123.COM',
    '123@123.com',
    '123@123.COM',0,
    'AQAAAAEAACcQAAAAECQn2NyyTkEYYoeco16V/mKuZG3KPgFtcNeB2tnI2b1RBI7/0y0qxp+kP5zGPyGTLg==',
    'C5ZYQOCBBZUUZTBL4C6JC2LGQ7RDNXD5',
    '8f035b62-b164-4c81-b95e-1cf025756323',
    0,0,1,0);
```
新增的用户名是  `123@123.com` ，密码是 `J7S:z!bZLW4KhnM`

然后程序中写好的初始化函数会对其他部分的数据库进行自动的初始化。

运行命令:  
```
dotnet run
```
程序就会运行了。
效果如下：

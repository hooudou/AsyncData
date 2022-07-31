

// new MySql.Data.MySqlClient.MySqlConnection("server=localhost;Database=TF;Uid=root;Pwd=cetc2018").Open(); 

System.Console.WriteLine("-->CodeFirst项目启动......");
SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
{
    // ConnectionString = "Server=localhost; port=5236; User id=SYSDBA; PWD=SYSDBA;DATABASE=MyTestDB",//连接符字串
    // ConnectionString = "Server=192.168.137.2; port=5246; User id=TF; PWD=daohang123;DATABASE=TF",//连接符字串
    ConnectionString = "server=127.0.0.1;Database=world;Port=3306;Uid=hodor;Pwd=cetc2018;Persist Security Info=True;SslMode=None;charset=utf8;",
    DbType = DbType.MySql, //数据库类型
    IsAutoCloseConnection = true //不设成true要手动close
});

// LogExecuting(db);

System.Console.WriteLine($"-->数据库连接成功！\n"
                         + $"\t数据库类型：{db.CurrentConnectionConfig.DbType}\n"
                         + $"\t连接字符串：{db.CurrentConnectionConfig.ConnectionString}");
var preTbsInfo = ConsoleTablesInfo(db);

//如果不存在创建数据库存在不会重复创建 
db.DbMaintenance.CreateDatabase(); // 注意 ：Oracle和个别国产库（DM）需不支持该方法，需要手动建库 
  
//创建表根据实体类Student   
CreateTables<Student>(db);//这样一个表就能成功创建了


System.Console.WriteLine("-->执行创建数据表命令结束.");
SeedingData(db);
LookOverData(db);//查看数据

// DropTable(db, "SITETYPE");
// paging(db);
System.Console.WriteLine("程序执行结束。");




/// <summary>
/// 打印数据表信息
/// </summary>
/// <param name="db"></param>
static List<DbTableInfo> ConsoleTablesInfo(SqlSugarClient db)
{
    System.Console.WriteLine("-->当前数据表信息：");
    var tables = db.DbMaintenance.GetTableInfoList(false);//true 走缓存 false不走缓存
    foreach (var table in tables)
    {
        Console.WriteLine($"\t{table.Name}");//输出表信息
    }
    return tables;
}

/// <summary>
/// <summary>
/// 打印数据库中所有表的数据
/// </summary>
/// <param name="db"></param>
/// <param name="tablesInfo"></param>
static void ConsoleAllTablesData(SqlSugarClient db, List<DbTableInfo> tablesInfo)
{
    foreach (var tb in tablesInfo)
    {
        ConsoleOneTableData(db, tb);
    }
}

static void ConsoleOneTableData(SqlSugarClient db, DbTableInfo tableInfo)
{
    // db.Queryable<Student>().ToList();//查询所有
    // db.Queryable<Student>().Where(it => it.Id == 1).ToList();//根据条件查询
    var list = db.Queryable(tableInfo.Name, "Name").ToList();
    if (list.Count == 0)
    {
      System.Console.WriteLine($"数据表{tableInfo.Name}为空。");
      return;
    }
    System.Console.WriteLine($"数据表{tableInfo.Name}数据：");
    foreach (var et in list)
    {
        System.Console.WriteLine($"{JsonConvert.SerializeObject(et)}");
    }
}

static void LookOverData(SqlSugarClient db)
{
    while (true)
    {
        System.Console.WriteLine("-->输入数据表名称，查看数据：(不区分大小写；输入all 查看所有；‘q’退出)");
        var afeTbsInfo = ConsoleTablesInfo(db);

        string InputStr = Console.ReadLine();
        string UserInputStr = InputStr.ToLower();
        if (UserInputStr != null)
        {
            if (UserInputStr == ("q"))
            {
                break;
            }
            if (UserInputStr == ("all"))
            {
                ConsoleAllTablesData(db, afeTbsInfo);
            }
            else
            {
                bool isDo = false;
                foreach (var tb in afeTbsInfo)
                {
                    if (UserInputStr == (tb.Name.ToLower()))
                    {
                        ConsoleOneTableData(db, tb);
                        isDo = true;
                        break;
                    }
                }
                if (!isDo)
                { System.Console.WriteLine("名字输错了吧。。。"); }
            }
        }
    }
}

static void CreateTables<T>(SqlSugarClient db)
{
    // /***创建单个表***/
    // db.CodeFirst.InitTables<Student>();

    /***批量创建表***/
    Type[] types = typeof(T).Assembly.GetTypes()
        .Where(it => it.FullName.Contains("AsyncData.Models."))//命名空间过滤，当然你也可以写其他条件过滤
        .ToArray();
    db.CodeFirst.SetStringDefaultLength(200).InitTables(types);//根据types创建表
}

static void SeedingData(SqlSugarClient db)
{
    //插入数据
    if (db.Queryable<Student>().Count() <= 0)
    {
        //插入返回实体
        var st1 = db.Insertable(new StudentSeedData().DataList).ExecuteReturnEntityAsync(); //都是参数化实现 
        System.Console.WriteLine($"插入数据-->\n{JsonConvert.SerializeObject(st1)}");
    }
    if (db.Queryable<Site>().Count() <= 0)
    {
        //插入返回实体
        var st1 = db.Insertable(new SiteSeedData().DataList).ExecuteReturnEntityAsync(); //都是参数化实现 
        System.Console.WriteLine($"插入数据-->\n{JsonConvert.SerializeObject(st1)}");
    }
    // if (db.Queryable<SiteType>().Count() <= 0)
    // {
    //     //插入返回实体
    //     var st1 = db.Insertable(new SiteTypeSeedData().DataList).ExecuteReturnEntityAsync(); //都是参数化实现 
    //     System.Console.WriteLine($"插入数据-->\n{JsonConvert.SerializeObject(st1)}");
    // }
}

/// <summary>
/// 根据数据表名删除数据表
/// </summary>
/// <param name="db"></param>
/// <param name="tableName"></param>
/// <returns></returns>
static bool DropTable(SqlSugarClient db, string tableName)
{
    if (db.DbMaintenance.IsAnyTable(tableName.ToUpper()))
    {
        return db.DbMaintenance.DropTable(tableName.ToUpper());
    }
    return false;
}
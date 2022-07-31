namespace AsyncData.SeedData;

public class SiteType2DB
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class SiteTypeSeedData 
{
    public List<SiteType2DB> DataList => new List<SiteType2DB>{
        new SiteType2DB{Id = 1, Name = "一级节点"},
        new SiteType2DB{Id = 2, Name = "二级节点"},
        new SiteType2DB{Id = 3, Name = "三级节点"},
        new SiteType2DB{Id = 4, Name = "四级节点"},
    };
}

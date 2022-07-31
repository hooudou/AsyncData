namespace AsyncData.SeedData;

public class SiteType2DB
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class SiteTypeSeedData 
{
    public List<SiteType2DB> DataList => new List<SiteType2DB>{
        new SiteType2DB{Id = 1, Name = "һ���ڵ�"},
        new SiteType2DB{Id = 2, Name = "�����ڵ�"},
        new SiteType2DB{Id = 3, Name = "�����ڵ�"},
        new SiteType2DB{Id = 4, Name = "�ļ��ڵ�"},
    };
}

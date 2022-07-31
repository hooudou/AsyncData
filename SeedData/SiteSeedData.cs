namespace AsyncData.SeedData;

public class SiteSeedData : SeedData<Site>
{
    public override List<Site> DataList => new List<Site>{
        new Site{
            Id = 1,
            Name = "���ļ�ʱƵ����(����)",
            RootSiteId = null,
            Longitude = 116.402464, 
            Latitude = 39.914245, 
            Altitude = 0
        },
        new Site{
            Id = 2,
            Name = "����ʱƵ����(�Ͼ�)",
            RootSiteId = 1,
            Longitude = 118.805871, 
            Latitude = 32.065876, 
            Altitude = 0
        },
    };
}

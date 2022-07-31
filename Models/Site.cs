namespace AsyncData.Models;

//实体与数据库结构一样
[SugarTable("Site")]
public class Site
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
    public int Id { get; set; }
    public string? Name { get; set; } // eg:一级节点
    public double Longitude { get; set; } //节点位置坐标--经度
    public double Latitude { get; set; } //节点位置坐标--纬度
    public double Altitude { get; set; }//节点位置坐标--高度

    //public int Status => AlarmDeviceCount > 0 ? 1 : 0 ; //节点状态，0:无告警、 1:有告警

    public int? RootSiteId { get; set; } //根节点的ID，最顶null

    //public List<Site> SubSites { get; set; }

    public int DeviceCount { get; set; } //节点包含的硬件数量
    public int AlarmDeviceCount { get; set; } //节点包含的告警硬件数量
    //public int SiteTypeId { get; set; } //节点等级id：1,2,3,4 。节点等级类型SiteType


    ////[Navigate(NavigateType.OneToMany, nameof(Device.SiteId))]//BookA表中的studenId
    //public List<Device> Devices { get; set; }

    ////[Navigate(NavigateType.OneToOne, nameof(SiteTypeId))]//一对一 SchoolId是StudentA类里面的
    public int SiteTypeId { get; set; } //外键关联相关


}


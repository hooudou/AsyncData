namespace AsyncData.Models;

//ʵ�������ݿ�ṹһ��
[SugarTable("Site")]
public class Site
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
    public int Id { get; set; }
    public string? Name { get; set; } // eg:һ���ڵ�
    public double Longitude { get; set; } //�ڵ�λ������--����
    public double Latitude { get; set; } //�ڵ�λ������--γ��
    public double Altitude { get; set; }//�ڵ�λ������--�߶�

    //public int Status => AlarmDeviceCount > 0 ? 1 : 0 ; //�ڵ�״̬��0:�޸澯�� 1:�и澯

    public int? RootSiteId { get; set; } //���ڵ��ID���null

    //public List<Site> SubSites { get; set; }

    public int DeviceCount { get; set; } //�ڵ������Ӳ������
    public int AlarmDeviceCount { get; set; } //�ڵ�����ĸ澯Ӳ������
    //public int SiteTypeId { get; set; } //�ڵ�ȼ�id��1,2,3,4 ���ڵ�ȼ�����SiteType


    ////[Navigate(NavigateType.OneToMany, nameof(Device.SiteId))]//BookA���е�studenId
    //public List<Device> Devices { get; set; }

    ////[Navigate(NavigateType.OneToOne, nameof(SiteTypeId))]//һ��һ SchoolId��StudentA�������
    public int SiteTypeId { get; set; } //����������


}


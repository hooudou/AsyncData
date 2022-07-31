namespace AsyncData.ModelsNoTable
{
    public class SiteType : Enumeration
    {
        public static SiteType 一级节点 = new SiteType(1, nameof(一级节点));
        public static SiteType 二级节点 = new SiteType(2, nameof(二级节点));
        public static SiteType 三级节点 = new SiteType(3, nameof(三级节点));
        public static SiteType 四级节点 = new SiteType(4, nameof(四级节点));
        public SiteType(int id, string name) : base(id, name)
        {

        }

    }
}
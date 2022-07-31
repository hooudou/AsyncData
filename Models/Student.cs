

namespace AsyncData.Models;

//实体与数据库结构一样
[SugarTable("Student")]
public class Student
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
    public int Id { get; set; }
    public int? SchoolId { get; set; }
    public string Name { get; set; }
    public DateTime? CreateTime { get; set; }
    [SugarColumn(IsIgnore = true, NoSerialize = true)]
    public int TestId { get; set; }
}


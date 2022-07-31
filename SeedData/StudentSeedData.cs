namespace AsyncData.SeedData;

public class StudentSeedData : SeedData<Student>
{
    public override List<Student> DataList => new List<Student>{
        new Student{Name = "stu1", SchoolId = 1, CreateTime = DateTime.Now },
        new Student{Name = "stu2", SchoolId = 1, CreateTime = DateTime.Now }
    };
    
}

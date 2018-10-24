namespace EFCoreDemo.Data.Models
{
    public class Person
    {
        public int DepartmentIdentifier { get; set; }
        public int DepartmentEmployeeIdentifier { get; set; }

        public PersonData PersonData { get; set; }
    }
}

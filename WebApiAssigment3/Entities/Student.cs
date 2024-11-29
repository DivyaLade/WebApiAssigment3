namespace WebApiAssigment3.Entities
{
    public class Student
    {
        public int StudentID {  get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth {  get; set; }
        public int ClassId { get; set; }
    }
}

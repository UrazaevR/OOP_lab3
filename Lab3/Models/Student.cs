namespace Lab3.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int? GroupId { get; set; }
        public Group? Group { get; set; }

        //public List<Hobby>? Hobbies { get; set; } = new List<Hobby>();
    }
}

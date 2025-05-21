namespace Lab3.Models
{
    public class StudentHobby
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public Student? Student { get; set; }
        public int? HobbyId { get; set; }
        public Hobby? Hobby { get; set; }
    }
}

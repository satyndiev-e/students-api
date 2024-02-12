using System;

namespace Students.Domain
{
    public class Gender
    {
        public int Id { get; set; }
        public GenderEnum GenderDescription { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}

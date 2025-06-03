namespace student2.Models.Entities
{
    public class Student
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }  
        public bool Subscribed { get; set; }

        public ICollection<Parent> Parents { get; set; }
    }
}

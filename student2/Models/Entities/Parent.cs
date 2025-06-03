using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace student2.Models.Entities
{
    public class Parent
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public Guid StudentID { get; set; }
        [ForeignKey("StudentID")]

        public virtual Student? Student { get; set; }

    }
}

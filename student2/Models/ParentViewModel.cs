using student2.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace student2.Models
{
    public class ParentViewModel
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        [ForeignKey("StudentID")]
        public virtual Student Students { get; set; }
        public Guid StudentID { get;  set; }

    }
}

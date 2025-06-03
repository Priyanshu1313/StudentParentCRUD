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

        public int ParentID { get; set; }
        [ForeignKey("ParentID")]

        public virtual Student Students { get; set; }

    }
}

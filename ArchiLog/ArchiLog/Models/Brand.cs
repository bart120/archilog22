using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArchiLog.Models
{
    //[Table("nomDeTable")]
    public class Brand
    {
        //[Key]
        public int ID { get; set; }

        public DateTime CreatedAt { get; set; }

        [StringLength(50)]
        [Required()]
        public string? Name { get; set; }

        //[Column(Name="nomdeColonne")]
        public string? Slogan { get; set; }

    }
}

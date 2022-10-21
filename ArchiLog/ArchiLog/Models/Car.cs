using ArchiLibrary.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArchiLog.Models
{
    public class Car : BaseModel
    {
       
        [StringLength(50)]
        [Required()]
        public string? Name { get; set; }
        public int BrandID { get; set; }
        [ForeignKey("BrandID")]
        public Brand? Brand { get; set; }

    }
}

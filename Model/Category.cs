using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_ComMIniProj.Model
{
    [Table("category")]
    public class Category
    {
        [Key]

        public int Category_id { get; set; }
        public string? Category_name { get; set; }
    }
}

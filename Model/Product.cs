// Importing necessary namespaces for data annotations and schema definition
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Defining the namespace for the model
namespace E_ComMIniProj.Model
{
    // Defining the class named 'Product' within the 'E_ComMIniProj.Model' namespace
    [Table("product")]  // Specifies that instances of this class should be stored in a table named 'product'
    public class Product
    {
        [Key]  // Specifies that the 'P_Id' property is the primary key for the database table
        public int P_Id { get; set; }  // Declares a property representing the primary key of the product

        public string? P_name { get; set; } 

        public decimal Price { get; set; } 

        public string image { get; set; }  

        [ForeignKey("Category_id")] 
        public int Category_id { get; set; }  

        [NotMapped]  
        public string? Category_name { get; internal set; } 
    }
}

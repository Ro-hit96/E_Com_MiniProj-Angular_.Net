// Importing necessary namespaces for data annotations and schema definition
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Defining the namespace for the model
namespace E_ComMIniProj.Model
{
    // Defining the class named 'Register' within the 'E_ComMIniProj.Model' namespace
    [Table("Userss")]  // Specifies that instances of this class should be stored in a table named 'Userss'
    public class Register
    {
        [Key]  // Specifies that the 'userid' property is the primary key for the database table
        public int userid { get; set; } 

        public string? username { get; set; }  

        public string? password { get; set; } 

        public string? email { get; set; } 

        // [ForeignKey("roleid")]  // Note: The foreign key attribute is commented out
        public int roleid { get; set; }  // Declares a property representing the user role ID
    }
}

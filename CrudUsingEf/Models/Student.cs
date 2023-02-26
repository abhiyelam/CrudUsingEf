
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CrudUsingEf.Models
{
    [Table("tblstudent")]
    public class Student
    {
        [Key]
        
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Mobileno { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public int Percentage { get; set; }
    }
}

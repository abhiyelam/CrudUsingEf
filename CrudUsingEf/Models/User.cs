

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudUsingEf.Models
{
    [Table("tbluser")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Username")]
        public string? Name { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        public string? ConfirmedPassword { get; set; }
        
       

    }
}

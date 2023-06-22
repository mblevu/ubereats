using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace UberEats.Models
{
    public class Partner
    {
        // EcF will instruct the database to automatically generate this value
        public int PartnerID { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        public int CategoryID { get; set; }  // foreign key property
        
        [Required(ErrorMessage = "Please enter a Phone number.")]
        public int Phone { get; set; }
        //public string Name { get; set; }
        //public string Email { get; set; }
        
        [Required(ErrorMessage = "Please enter a Partner name.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a Partner Email.")]
        public string Email { get; set; } = string.Empty;

       // [Required(ErrorMessage = "Please enter a Address.")] 

        public string? Address { get; set; } 
      // public int BusinessTypeId { get; set; }
    
        //public bool Status { get; set; }

        [ValidateNever]
        public Category Category { get; set; } = null!;  

    }
}
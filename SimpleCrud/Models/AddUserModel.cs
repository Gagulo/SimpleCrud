using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleCrud.Models
{
    public class AddUserModel
    {
        public AddUserModel()
        {
            DateOfBirth = DateTime.Now;
        }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [MinLength(3)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
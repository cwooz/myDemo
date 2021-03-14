using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace myData.Entities
{
    public class PersonToBeUpdated
    {
        [Required(ErrorMessage = "Please provide a name value.")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide an email value.")]
        [MaxLength(50)]
        public string Email { get; set; }
    }
}

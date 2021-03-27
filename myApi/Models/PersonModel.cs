using System.ComponentModel.DataAnnotations;
using myData.Services;

namespace myApi.Models
{
    public class PersonModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a name value.")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide an email value.")]
        [MaxLength(50)]
        public string Email { get; set; }
    }
}

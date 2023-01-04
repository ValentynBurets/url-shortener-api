using System.ComponentModel.DataAnnotations;


namespace Business.Contract.Models.UserManagement
{
    public class PersonDTO
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        //[StringLength(25, ErrorMessage = "Password is limited to {2} to {1} characters", MinimumLength = 10)]
        public string Password { get; set; }
    }
}

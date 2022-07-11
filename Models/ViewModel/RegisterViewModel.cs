namespace BoltaShop.Models.ViewModel;

public class RegisterViewModel
{
    [Display(Name = "Ime")]
    [Required(ErrorMessage = "Ime name is required")]
    public string Ime { get; set; }

    [Display(Name = "Prezime")]
    [Required(ErrorMessage = "Prezime name is required")]
    public string Prezime { get; set; }

    [Display(Name = "Email address")]
    [Required(ErrorMessage = "Email address is required")]
    public string EmailAddress { get; set; }


    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Display(Name = "Confirm password")]
    [Required(ErrorMessage = "Confirm password is required")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; }
}
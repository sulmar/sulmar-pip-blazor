using System.ComponentModel.DataAnnotations;

namespace BlazorServerApp.Models;

public class User : BaseEntity
{
    [Required(ErrorMessage = "Pole {0} jest wymagane"), MinLength(3, ErrorMessage = "Minimalna długość pola {0} wynosi {1} znaki"), MaxLength(50)]
    public string FirstName { get; set; }
    [Required, MinLength(3), MaxLength(50)]
    public string LastName { get; set; }
    [Range(18, 100)]
    public int Age { get; set; }

    [Required, Length(10, 20)]
    public string Password { get; set; }

    [Required, Length(10, 20)]
    [Compare(nameof(Password), ErrorMessage = "Hasła są inne")]
    public string ConfirmPassword { get; set; }
}

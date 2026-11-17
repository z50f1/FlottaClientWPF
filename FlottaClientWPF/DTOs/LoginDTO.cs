using System.ComponentModel.DataAnnotations;

namespace FlottaClientWPF.DTOs;

public class LoginDTO
{
    [Required]
    public string LoginName { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}

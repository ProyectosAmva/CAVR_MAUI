namespace MauiCAVR.Models;

public class ChangePasswordRequest
{

    /// <summary>
    /// Correo electrónico
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Contraseña actual
    /// </summary>
    public string CurrentPassword { get; set; } = string.Empty;


    /// <summary>
    /// Nueva contraseña
    /// </summary>
    public string NewPassword { get; set; } = string.Empty;
}

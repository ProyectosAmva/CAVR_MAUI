namespace MauiCAVR.Models;

public class Response
{
    /// <summary>
    /// Establce si el servicio respondió de manera satisfactoria o no
    /// </summary>
    public bool IsSuccess { get; set; }

    /// <summary>
    /// Mensaje de respuesta entregado por el servicio
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// Objecto devuelto por el servicio
    /// </summary>
    public object Result { get; set; } = null!;
}

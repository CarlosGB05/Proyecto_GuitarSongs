using System;

namespace Proyecto_GuitarSongs.Models;

public class Album
{
    public string titulo { get; set; } = String.Empty;
    public string creador { get; set; } = String.Empty;
    public DateTime fechaSalida { get; set; } = DateTime.Now;
    public int cantidad { get; set; } = 0;
    public string formato { get; set; } = "";
    
    public override string ToString()
    {
        return "Titulo: "+titulo+", Creador: "+creador+", Cantidad: "+cantidad+", Fecha Salida: "+fechaSalida+", Formato: "+formato;;
    }
}
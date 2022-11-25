using System.Text.Json.Serialization;

namespace factnet_back.Models;

public class Cliente
{
    public string dni {get;set;}
    public string nombres {get;set;}
    public string apellidos {get;set;}
    public DateTime fechaNacimiento {get;set;}
    public string direccion {get;set;}

    [JsonIgnore]
    public virtual ICollection<Factura> Facturas {get;set;}

}
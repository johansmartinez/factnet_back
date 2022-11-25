using System.Text.Json.Serialization;

namespace factnet_back.Models;

public class Factura
{
    public Guid id {get;set;}
    public DateTime facturacion {get;set;}
    public string clienteDni {get;set;}
    [JsonIgnore]
    public virtual Cliente Cliente {get;set;}

    [JsonIgnore]
    public virtual ICollection<Ventas> Ventas {get;set;}

}
using System.Text.Json.Serialization;

namespace factnet_back.Models;

public class Ventas
{
    public Guid id {get;set;}
    public Guid facturaId {get;set;}
    

    public int unidades {get;set;}
    public Guid productoId {get;set;}
    
    [JsonIgnore]
    public virtual Producto? Producto {get;set;}

    [JsonIgnore]
    public virtual Factura? Factura {get;set;}

}
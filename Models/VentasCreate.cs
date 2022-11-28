using System.Text.Json.Serialization;

namespace factnet_back.Models;

public class VentasCreate
{
    public Guid facturaId {get;set;}
    public int unidades {get;set;}
    public Guid productoId {get;set;}

}
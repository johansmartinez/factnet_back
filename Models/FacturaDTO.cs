using System.Text.Json.Serialization;

namespace factnet_back.Models;

public class FacturaDTO
{
    public Guid id {get;set;}
    public DateTime facturacion {get;set;}
    public string clienteDni {get;set;}
    
    public string clienteNombre {get;set;}
    public string clienteApellido {get;set;}
    public double total {get;set;}
    [JsonIgnore]
    public virtual ICollection<Ventas> Ventas {get;set;}

}
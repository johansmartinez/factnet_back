using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace factnet_back.Models;

public class ProductoDTO
{
    public Guid id {get;set;}
    public string nombre {get;set;}
    public int precioUnitario {get;set;}

    public Guid? proveedorId {get;set;}
    public string? proveedorNombre {get;set;}
    

}
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace factnet_back.Models;

public class Producto
{
    public Guid id {get;set;}
    public string nombre {get;set;}
    public int precioUnitario {get;set;}

    [ForeignKey("Proveedor")]
    public Guid? proveedorId {get;set;}
    public virtual Proveedor? Proveedor {get;set;}

    [JsonIgnore]
    public virtual ICollection<Ventas>? Ventas {get;set;}

}
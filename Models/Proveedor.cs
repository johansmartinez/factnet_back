using System.Text.Json.Serialization;

namespace factnet_back.Models;

public class Proveedor
{
    public Guid proveedorId {get;set;}
    public string nombre {get;set;}

    [JsonIgnore]
    public virtual ICollection<Producto> Productos {get;set;}

}
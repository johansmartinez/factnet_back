namespace factnet_back.Models;

public class VentasDTO
{
    public Guid id {get;set;}
    public Guid facturaId {get;set;}

    public DateTime facturacion {get;set;}
    public int unidades {get;set;}
    public Guid productoId {get;set;}
    public string productoNombre {get;set;}

}
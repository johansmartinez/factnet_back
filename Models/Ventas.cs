namespace factnet_back.Models;

public class Ventas
{
    public Guid id {get;set;}
    public Guid facturaId {get;set;}
    public virtual Factura? Factura {get;set;}

    public int unidades {get;set;}
    public Guid productoId {get;set;}
    public virtual Producto Producto {get;set;}

}
using factnet_back.Models;

namespace factnet_back.Services;

public class FacturaService: IFacturaService
{
    FacturationContext context;

    public FacturaService(FacturationContext dbContext)
    {
        context=dbContext;
    }

    public async Task Delete(Guid id)
    {
        var facturaActual = context.Facturas.Find(id);
        if (facturaActual != null)
        {
            context.Facturas.Remove(facturaActual);
            context.SaveChanges();
        }
    }

    public IEnumerable<Object> GetSales()
    {
        using (var ctx= context)
        {
            var query=  from v in ctx.Ventas
                        join f in ctx.Facturas on v.facturaId equals f.id
                        join c in ctx.Clientes on f.clienteDni equals c.dni
                        join p in ctx.Productos on v.productoId equals p.id
                        select new {
                            facturacion= f.facturacion,
                            facturaId= f.id,
                            clienteDni= f.clienteDni,
                            clienteNombre=c.nombres,
                            clienteApellido=c.apellidos,
                            ventasId=v.id,
                            producto=p.id,
                            productoNombre=p.nombre,
                            unidades=v.unidades,
                            precioUnitario=p.precioUnitario,
                            totalProducto= v.unidades * p.precioUnitario
                        } into x
                        group x by x.facturaId into g select new { 
                            facturacion= g.Select(p=>p.facturacion).First(),
                            facturaId= g.Select(p=>p.facturaId).First(),
                            clienteDni= g.Select(p=>p.clienteDni).First(),
                            clienteNombre=g.Select(p=>p.clienteNombre).First(),
                            clienteApellido=g.Select(p=>p.clienteApellido).First(),
                            productos=g.Select(p=> new {
                                productoNombre=p.productoNombre,
                                productoPrecio=p.precioUnitario,
                                productoUnidades=p.unidades
                            }),
                            total=g.Sum(p=>p.unidades*p.unidades)
                        };
                        
            return query.ToList();
        }
    }

    public IEnumerable<Object> GetSalesMonth(int month, int year)
    {
        using (var ctx= context)
        {
            var query=  from v in ctx.Ventas
                        join f in ctx.Facturas on v.facturaId equals f.id
                        join c in ctx.Clientes on f.clienteDni equals c.dni
                        join p in ctx.Productos on v.productoId equals p.id
                        where f.facturacion.Month==month && f.facturacion.Year==year
                        select new {
                            facturacion= f.facturacion,
                            facturaId= f.id,
                            clienteDni= f.clienteDni,
                            clienteNombre=c.nombres,
                            clienteApellido=c.apellidos,
                            ventasId=v.id,
                            producto=p.id,
                            productoNombre=p.nombre,
                            unidades=v.unidades,
                            precioUnitario=p.precioUnitario,
                            totalProducto= v.unidades * p.precioUnitario
                        } into x
                        group x by x.facturaId into g select new { 
                            facturacion= g.Select(p=>p.facturacion).First(),
                            facturaId= g.Select(p=>p.facturaId).First(),
                            clienteDni= g.Select(p=>p.clienteDni).First(),
                            clienteNombre=g.Select(p=>p.clienteNombre).First(),
                            clienteApellido=g.Select(p=>p.clienteApellido).First(),
                            productos=g.Select(p=> new {
                                productoNombre=p.productoNombre,
                                productoPrecio=p.precioUnitario,
                                productoUnidades=p.unidades
                            }),
                            total=g.Sum(p=>p.totalProducto)
                        };
                        
            return query.ToList();
        }
    }
    public IEnumerable<Object> GetSale(Guid id)
    {
        using (var ctx= context)
        {
            var query=  from v in ctx.Ventas
                        join f in ctx.Facturas on v.facturaId equals f.id
                        join c in ctx.Clientes on f.clienteDni equals c.dni
                        join p in ctx.Productos on v.productoId equals p.id
                        where f.id ==id
                        select new {
                            facturacion= f.facturacion,
                            facturaId= f.id,
                            clienteDni= f.clienteDni,
                            clienteNombre=c.nombres,
                            clienteApellido=c.apellidos,
                            ventasId=v.id,
                            producto=p.id,
                            productoNombre=p.nombre,
                            unidades=v.unidades,
                            precioUnitario=p.precioUnitario,
                            totalProducto= v.unidades * p.precioUnitario
                        } into x
                        group x by x.facturaId into g select new { 
                            facturacion= g.Select(p=>p.facturacion).First(),
                            facturaId= g.Select(p=>p.facturaId).First(),
                            clienteDni= g.Select(p=>p.clienteDni).First(),
                            clienteNombre=g.Select(p=>p.clienteNombre).First(),
                            clienteApellido=g.Select(p=>p.clienteApellido).First(),
                            productos=g.Select(p=> new {
                                productoNombre=p.productoNombre,
                                productoPrecio=p.precioUnitario,
                                productoUnidades=p.unidades
                            }),
                            total=g.Sum(p=>p.totalProducto)
                        };
                        
            return query.ToList();
        }
    }

    public IEnumerable<Object> Get()
    {
        using (var ctx= context)
        {
            var query=  from v in ctx.Ventas
                        join f in ctx.Facturas on v.facturaId equals f.id
                        join c in ctx.Clientes on f.clienteDni equals c.dni
                        join p in ctx.Productos on v.productoId equals p.id
                        select new {
                            facturacion= f.facturacion,
                            facturaId= f.id,
                            clienteDni= f.clienteDni,
                            clienteNombre=c.nombres,
                            clienteApellido=c.apellidos,
                            ventasId=v.id,
                            producto=p.id,
                            totalProducto= v.unidades * p.precioUnitario
                        } into x
                        group x by x.facturaId into g select new { 
                            facturacion= g.Select(p=>p.facturacion).First(),
                            facturaId= g.Select(p=>p.facturaId).First(),
                            clienteDni= g.Select(p=>p.clienteDni).First(),
                            clienteNombre=g.Select(p=>p.clienteNombre).First(),
                            clienteApellido=g.Select(p=>p.clienteApellido).First(),
                            total=g.Select(p=>p.totalProducto).Sum()
                        };
                        
            return query.ToList();
        }
    }

    public Guid Save(FacturaCreate factura)
    {
        var id=Guid.NewGuid();
        var fact=new Factura{
            id=id,
            clienteDni=factura.clienteDni,
            facturacion=DateTime.Now
        };
        context.Facturas.Add(fact);
        context.SaveChanges();
        return id;
    }

    public async Task Update(Guid id, Factura factura)
    {
        var facturaActual = context.Facturas.Find(id);
        if (facturaActual != null)
        {
            facturaActual.facturacion = factura.facturacion;
            await context.SaveChangesAsync();
        }
        context.SaveChanges();
    }
}

public interface IFacturaService{
    IEnumerable<Object> Get();
    IEnumerable<Object> GetSales();
    IEnumerable<Object> GetSale(Guid id);
    IEnumerable<Object> GetSalesMonth(int month, int year);
    Guid Save(FacturaCreate factura);
    Task Update(Guid id,Factura factura);
    Task Delete(Guid id);
}
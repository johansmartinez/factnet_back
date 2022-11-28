using factnet_back.Models;

namespace factnet_back.Services;

public class VentaService: IVentaService
{
    FacturationContext context;

    public VentaService(FacturationContext dbContext)
    {
        context=dbContext;
    }

    public async Task Delete(Guid id)
    {
        var ventaActual = context.Ventas.Find(id);
        if (ventaActual != null)
        {
            context.Remove(ventaActual);
            await context.SaveChangesAsync();
        }
    }

    public IEnumerable<Object> Get()
    {
        using (var ctx= context)
        {
            var query= from v in ctx.Ventas
                        join f in ctx.Facturas on v.facturaId equals f.id
                        join p in ctx.Productos on v.productoId equals p.id
                        select new VentasDTO{
                            id=v.id,
                            facturacion=f.facturacion,
                            facturaId=f.id,
                            productoId=p.id,
                            productoNombre=p.nombre,
                            unidades=v.unidades
                        };
            return query.ToList();
        }
    }

    public async Task Save(VentasCreate[] ventas)
    {
        foreach (var v in ventas)
        {
            var temp=new Ventas{
                id=Guid.NewGuid(),
                unidades=v.unidades,
                productoId=v.productoId,
                facturaId=v.facturaId
            };
            context.Ventas.Add(temp);
            await context.SaveChangesAsync();
        }
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id,Ventas ventas)
    {
        var ventaActual = context.Ventas.Find(id);
        if (ventaActual != null)
        {
            ventaActual.unidades = ventas.unidades;
            await context.SaveChangesAsync();
        }
        context.SaveChanges();
    }
}

public interface IVentaService{
    IEnumerable<Object> Get();
    Task Save(VentasCreate[] ventas);
    Task Update(Guid id,Ventas ventas);
    Task Delete(Guid id);
}
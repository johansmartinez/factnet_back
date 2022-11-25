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
        var facturaActual = context.Productos.Find(id);
        if (facturaActual != null)
        {
            context.Remove(facturaActual);
            await context.SaveChangesAsync();
        }
    }

    public IEnumerable<Object> Get()
    {
        using (var ctx= context)
        {
            var query= from f in ctx.Facturas
                        join c in ctx.Clientes on f.clienteDni equals c.dni
                        select new FacturaDTO{
                            facturacion= f.facturacion,
                            id= f.id,
                            clienteDni= f.clienteDni,
                            clienteNombre=c.nombres,
                            clienteApellido=c.apellidos
                        };
            return query.ToList();
        }
    }

    public async Task Save(Factura factura)
    {
        context.Facturas.Add(factura);
        await context.SaveChangesAsync();
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
    Task Save(Factura factura);
    Task Update(Guid id,Factura factura);
    Task Delete(Guid id);
}
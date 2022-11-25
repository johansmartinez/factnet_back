using factnet_back.Models;

namespace factnet_back.Services;

public class ProveedorService: IProveedorService
{
    FacturationContext context;

    public ProveedorService(FacturationContext dbContext)
    {
        context=dbContext;
    }

    public async Task Delete(Guid id)
    {
        var proveedorActual = context.Proveedores.Find(id);
        if (proveedorActual != null)
        {
            context.Remove(proveedorActual);
            await context.SaveChangesAsync();
        }
    }

    public IEnumerable<Proveedor> Get()
    {
        return context.Proveedores;
    }

    public async Task Save(Proveedor proveedor)
    {
        context.Proveedores.Add(proveedor);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Proveedor proveedor)
    {
        var proveedorActual = context.Proveedores.Find(id);
        if (proveedorActual != null)
        {
            proveedorActual.nombre = proveedor.nombre;
            await context.SaveChangesAsync();
        }
        context.SaveChanges();
    }
}

public interface IProveedorService{
    IEnumerable<Proveedor> Get();
    Task Save(Proveedor proveedor);
    Task Update(Guid id,Proveedor proveedor);
    Task Delete(Guid id);
}
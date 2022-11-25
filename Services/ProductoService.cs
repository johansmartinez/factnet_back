using factnet_back.Models;

namespace factnet_back.Services;

public class ProductoService: IProductoService
{
    FacturationContext context;

    public ProductoService(FacturationContext dbContext)
    {
        context=dbContext;
    }

    public async Task Delete(Guid id)
    {
        var productoActual = context.Productos.Find(id);
        if (productoActual != null)
        {
            context.Remove(productoActual);
            await context.SaveChangesAsync();
        }
    }

    public IEnumerable<Object> Get()
    {
        using (var ctx= context)
        {
            var query= from pd in ctx.Productos
                        join pv in ctx.Proveedores on pd.proveedorId equals pv.proveedorId
                        select new ProductoDTO{
                            id= pd.id,
                            nombre= pd.nombre,
                            precioUnitario= pd.precioUnitario,
                            proveedorId=pd.proveedorId,
                            proveedorNombre=pv.nombre
                        };
            return query.ToList();
        }
    }

    public async Task Save(Producto producto)
    {
        context.Productos.Add(producto);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Producto producto)
    {
        var productoActual = context.Productos.Find(id);
        if (productoActual != null)
        {
            productoActual.nombre = producto.nombre;
            productoActual.precioUnitario = producto.precioUnitario;
            productoActual.proveedorId = producto.proveedorId;
            await context.SaveChangesAsync();
        }
        context.SaveChanges();
    }
}

public interface IProductoService{
    IEnumerable<Object> Get();
    Task Save(Producto producto);
    Task Update(Guid id,Producto producto);
    Task Delete(Guid id);
}
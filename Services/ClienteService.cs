using factnet_back.Models;

namespace factnet_back.Services;

public class ClienteService: IClienteService
{
    FacturationContext context;

    public ClienteService(FacturationContext dbContext)
    {
        context=dbContext;
    }

    public async Task Delete(string dni)
    {
        var clienteActual = context.Clientes.Find(dni);
        if (clienteActual != null)
        {
            context.Remove(clienteActual);
            await context.SaveChangesAsync();
        }
    }

    public IEnumerable<Cliente> Get()
    {
        return context.Clientes;
    }

    public async Task Save(Cliente cliente)
    {
        context.Clientes.Add(cliente);
        await context.SaveChangesAsync();
    }

    public async Task Update(string dni,Cliente cliente)
    {
        var clienteActual = context.Clientes.Find(dni);
        if (clienteActual != null)
        {
            clienteActual.nombres = cliente.nombres;
            clienteActual.apellidos = cliente.apellidos;
            clienteActual.fechaNacimiento = cliente.fechaNacimiento;
            clienteActual.direccion = cliente.direccion;
            context.SaveChanges();
        }
        context.SaveChanges();
    }
}

public interface IClienteService{
    IEnumerable<Cliente> Get();
    Task Save(Cliente cliente);
    Task Update(string dni,Cliente cliente);
    Task Delete(string dni);
}
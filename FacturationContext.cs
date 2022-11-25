using Microsoft.EntityFrameworkCore;
using factnet_back.Models;

namespace factnet_back;

public class FacturationContext: DbContext
{
    public DbSet<Cliente> Clientes {get;set;}
    public DbSet<Proveedor> Proveedores {get;set;}

    public FacturationContext(DbContextOptions<FacturationContext> options): base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Cliente> clientesInit= new List<Cliente>();
        clientesInit.Add(new Cliente(){dni="00000", nombres="USUARIO", apellidos="PRUEBA",fechaNacimiento=new DateTime(2000,6,12), direccion="DIRECCIÓN DE PRUEBA"});

        modelBuilder.Entity<Cliente>(clientes=>
        {
            clientes.ToTable("CLIENTES");
            clientes.HasKey(p=>p.dni);

            clientes.Property(p=> p.nombres).IsRequired().HasMaxLength(150);
            clientes.Property(p=> p.apellidos).IsRequired().HasMaxLength(150);
            clientes.Property(p=> p.direccion).IsRequired().HasMaxLength(200);
            clientes.Property(p=> p.fechaNacimiento).IsRequired();
            clientes.HasData(clientesInit);
        });

        List<Proveedor> proveedorInit= new List<Proveedor>();
        proveedorInit.Add(new Proveedor(){id=Guid.Parse("40b4111a-defd-4539-942c-0adc8225e413"), nombre="PROVEEDOR DE PRUEBA"});

        modelBuilder.Entity<Proveedor>(Proveedor=>
        {
            Proveedor.ToTable("PROVEEDORES");
            Proveedor.HasKey(p=>p.id);
            Proveedor.Property(p=> p.nombre).IsRequired().HasMaxLength(200);
            Proveedor.HasData(proveedorInit);
        });

        base.OnModelCreating(modelBuilder);
    }
}

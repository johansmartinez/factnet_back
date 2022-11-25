using Microsoft.EntityFrameworkCore;
using factnet_back.Models;

namespace factnet_back;

public class FacturationContext: DbContext
{
    public DbSet<Cliente> Clientes {get;set;}
    public DbSet<Proveedor> Proveedores {get;set;}
    public DbSet<Producto> Productos {get;set;}
    public DbSet<Factura> Facturas {get;set;}
    public DbSet<Ventas> Ventas {get;set;}

    public FacturationContext(DbContextOptions<FacturationContext> options): base(options)
    {}

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
        proveedorInit.Add(new Proveedor(){proveedorId=Guid.Parse("40b4111a-defd-4539-942c-0adc8225e413"), nombre="PROVEEDOR DE PRUEBA"});

        modelBuilder.Entity<Proveedor>(Proveedor=>
        {
            Proveedor.ToTable("PROVEEDORES");
            Proveedor.HasKey(p=>p.proveedorId);
            Proveedor.Property(p=> p.nombre).IsRequired().HasMaxLength(200);
            Proveedor.HasData(proveedorInit);
        });


        List<Producto> productoInit= new List<Producto>();
        productoInit.Add(new Producto(){id=Guid.Parse("96b4bd45-9c9e-4e1f-85ee-9c5ea0e5c715"), nombre="PRODUCTO DE PRUEBA", precioUnitario=1200, proveedorId=Guid.Parse("40b4111a-defd-4539-942c-0adc8225e413")});

        modelBuilder.Entity<Producto>(Productos=>
        {
            Productos.ToTable("PRODUCTOS");
            Productos.HasKey(p=>p.id);
            Productos.Property(p=> p.nombre).IsRequired().HasMaxLength(200);
            Productos.Property(p=>p.precioUnitario).IsRequired();
            Productos.HasData(productoInit);
            Productos.HasOne(p=>p.Proveedor).WithMany(p=>p.Productos).HasForeignKey(p=>p.proveedorId).HasPrincipalKey(p=>p.proveedorId);
        });

        List<Factura> facturasInit= new List<Factura>();
        facturasInit.Add(new Factura(){id=Guid.Parse("62881386-8eee-4ca2-b946-5abc0d8c73e7"), facturacion=new DateTime(2020,07,12), clienteDni="00000" });

        modelBuilder.Entity<Factura>(Factura=>
        {
            Factura.ToTable("FACTURAS");
            Factura.HasKey(p=>p.id);
            Factura.Property(p=> p.facturacion).IsRequired();
            Factura.HasOne(p=> p.Cliente).WithMany(p=>p.Facturas).HasForeignKey(p=>p.clienteDni).HasPrincipalKey(p=>p.dni);
            Factura.HasData(facturasInit);
        });

        List<Ventas> ventasInit= new List<Ventas>();
        ventasInit.Add(new Ventas(){id=Guid.Parse("09d15e2c-e1cc-4d55-ac4b-5f01c098b899"),facturaId=Guid.Parse("62881386-8eee-4ca2-b946-5abc0d8c73e7"), unidades=2, productoId= Guid.Parse("96b4bd45-9c9e-4e1f-85ee-9c5ea0e5c715")});

        modelBuilder.Entity<Ventas>(Ventas=>
        {
            Ventas.ToTable("VENTAS");
            Ventas.HasKey(p=>p.id);
            Ventas.Property(p=> p.facturaId).IsRequired();
            Ventas.Property(p=> p.productoId).IsRequired();
            Ventas.Property(p=> p.unidades).IsRequired();
            Ventas.HasOne(p=> p.Factura).WithMany(p=>p.Ventas).HasForeignKey(p=>p.facturaId).HasPrincipalKey(p=>p.id);
            Ventas.HasOne(p=> p.Producto).WithMany(p=>p.Ventas).HasForeignKey(p=>p.productoId).HasPrincipalKey(p=>p.id);
            Ventas.HasData(ventasInit);
        });

        base.OnModelCreating(modelBuilder);
    }
}

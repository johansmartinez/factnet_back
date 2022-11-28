using Microsoft.AspNetCore.Mvc;
using factnet_back.Services;
using factnet_back.Models;
using Microsoft.AspNetCore.Cors;

namespace factnet_back.Controllers;

[EnableCors()]
[ApiController]
[Route("producto")]
public class ProductoController: ControllerBase
{
    IProductoService productoService;

    public ProductoController( IProductoService productoServ)
    {
        productoService=productoServ;
    }

    [HttpGet]
    public IActionResult Get(){
        return Ok(productoService.Get());
    }

    [HttpGet("{id}")]
    public IActionResult GetId(Guid id){
        return Ok(productoService.GetContext().Where(p=>p.id==id));
    }

    [HttpPost]
    public IActionResult Post([FromBody] Producto producto)
    {
        try
        {
            productoService.Save(producto);
            return Ok();
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id,[FromBody] Producto producto)
    {
        productoService.Update(id,producto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        productoService.Delete(id);
        return Ok();
    }

}
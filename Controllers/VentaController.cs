using Microsoft.AspNetCore.Mvc;
using factnet_back.Services;
using factnet_back.Models;
using Microsoft.AspNetCore.Cors;

namespace factnet_back.Controllers;

[EnableCors()]
[ApiController]
[Route("venta")]
public class VentaController: ControllerBase
{
    IVentaService ventaService;

    public VentaController(IVentaService ventaServ)
    {
        ventaService=ventaServ;
    }

    [HttpGet]
    public IActionResult Get(){
        return Ok(ventaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] VentasCreate[] ventas)
    {
        try
        {
            ventaService.Save(ventas);
            return Ok();
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id,[FromBody] Ventas ventas)
    {
        ventaService.Update(id,ventas);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        ventaService.Delete(id);
        return Ok();
    }

}
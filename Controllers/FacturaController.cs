using Microsoft.AspNetCore.Mvc;
using factnet_back.Services;
using factnet_back.Models;

namespace factnet_back.Controllers;

[ApiController]
[Route("factura")]
public class FacturaController: ControllerBase
{
    IFacturaService facturaService;

    public FacturaController(IFacturaService facturaServ)
    {
        facturaService=facturaServ;
    }

    [HttpGet]
    public IActionResult Get(){
        return Ok(facturaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Factura factura)
    {
        try
        {
            facturaService.Save(factura);
            return Ok();
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id,[FromBody] Factura factura)
    {
        facturaService.Update(id,factura);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        facturaService.Delete(id);
        return Ok();
    }

}
using Microsoft.AspNetCore.Mvc;
using factnet_back.Services;
using factnet_back.Models;

namespace factnet_back.Controllers;

[ApiController]
[Route("proveedor")]
public class ProveedorController: ControllerBase
{
    IProveedorService proveedorService;

    public ProveedorController(IProveedorService proveedorServ)
    {
        proveedorService=proveedorServ;
    }

    [HttpGet]
    public IActionResult Get(){
        return Ok(proveedorService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Proveedor proveedor)
    {
        try
        {
            proveedorService.Save(proveedor);
            return Ok();
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id,[FromBody] Proveedor proveedor)
    {
        proveedorService.Update(id,proveedor);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        proveedorService.Delete(id);
        return Ok();
    }

}
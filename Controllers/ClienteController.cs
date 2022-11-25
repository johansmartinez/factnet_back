using Microsoft.AspNetCore.Mvc;
using factnet_back.Services;
using factnet_back.Models;

namespace factnet_back.Controllers;

[ApiController]
[Route("cliente")]
public class ClienteController: ControllerBase
{
    IClienteService clienteService;

    public ClienteController(IClienteService clienteServ)
    {
        clienteService=clienteServ;
    }

    [HttpGet]
    public IActionResult Get(){
        return Ok(clienteService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Cliente cliente)
    {
        try
        {
            clienteService.Save(cliente);
            return Ok();
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
    }

    [HttpPut("{dni}")]
    public IActionResult Put(string dni,[FromBody] Cliente cliente)
    {
        clienteService.Update(dni,cliente);
        return Ok();
    }

    [HttpDelete("{dni}")]
    public IActionResult Delete(string dni)
    {
        clienteService.Delete(dni);
        return Ok();
    }

}
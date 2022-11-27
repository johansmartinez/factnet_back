using Microsoft.AspNetCore.Mvc;
using factnet_back.Services;
using factnet_back.Models;
using Microsoft.AspNetCore.Cors;

namespace factnet_back.Controllers;

[EnableCors()]
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

    [HttpGet("{dni}")]
    public IActionResult GetUser(string dni){
        return Ok(clienteService.Get().Where(c=>c.dni==dni));
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
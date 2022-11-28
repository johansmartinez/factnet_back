using Microsoft.AspNetCore.Mvc;
using factnet_back.Services;
using factnet_back.Models;
using Microsoft.AspNetCore.Cors;

namespace factnet_back.Controllers;

[EnableCors()]
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

    [HttpGet("ventas")]
    public IActionResult GetSales(){
        return Ok(facturaService.GetSales());
    }

    [HttpGet("ventas/{id}")]
    public IActionResult GetSale(Guid id){
        return Ok(facturaService.GetSale(id));
    }

    [HttpGet("ventas/filtro/{month}/{year}")]
    public IActionResult GetSaleMonth(int month, int year){
        return Ok(facturaService.GetSalesMonth(month,year));
    }

    [HttpPost]
    public IActionResult Post([FromBody] FacturaCreate factura)
    {
        try
        {
            return Ok(facturaService.Save(factura));
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
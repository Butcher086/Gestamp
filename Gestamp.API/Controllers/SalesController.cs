using Gestamp.API.Models;
using Gestamp.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Gestamp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly SalesService _salesService;
        private readonly ILogger<SalesController> _logger;

        public SalesController(SalesService salesService, ILogger<SalesController> logger)
        {
            _salesService = salesService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Sale>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSales()
        {
            var sales = await _salesService.GetSales();
            return Ok(sales);
        }

        [Route("GetSaleById")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Sale), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Sale>> GetSaleById(string id)
        {
            var sale = await _salesService.GetSale(id);
            if (sale == null)
            {
                _logger.LogError($"Sale with id: {id}, not found.");
                return NotFound();
            }

            return Ok(sale);
        }

        [Route("GetSaleByOrderDate")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Sale>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSaleByOrderDate(string orderDate)
        {
            var sales = await _salesService.GetSaleByOrderDate(orderDate);
            return Ok(sales);
        }

        [Route("CreateSale")]
        [HttpPost]
        [ProducesResponseType(typeof(Sale), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Sale>> CreateSale([FromBody] Sale sale)
        {
            await _salesService.CreateSale(sale);

            return CreatedAtRoute("GetSale", new { id = sale.Id }, sale);
        }

        [Route("UpdateProduct")]
        [HttpPut]
        [ProducesResponseType(typeof(Sale), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] Sale sale)
        {
            return Ok(await _salesService.UpdateSale(sale));
        }

        [Route("DeleteSale")]
        [HttpDelete]
        [ProducesResponseType(typeof(Sale), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteSale(string id)
        {
            return Ok(await _salesService.DeleteSale(id));
        }
    }
}

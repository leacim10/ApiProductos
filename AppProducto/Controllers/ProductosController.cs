using App.Entity.Model;
using App.Entity.Request;
using App.Entity.Response;
using AppProducto.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppProducto.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IServiceProducto _service;
        public ProductosController(IServiceProducto service)
        {
            _service = service;
        }

        [HttpPost("AnadirProducto")]
        [ProducesResponseType(typeof(Response<string>), 200)]
        public IActionResult addProducto([FromBody] anadirProductoRequest request)
        {
            try
            {
                var response = _service.addProducto(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("ActualizarProducto")]
        [ProducesResponseType(typeof(Response<string>), 200)]
        public IActionResult updateProducto([FromBody] actualizarProductoRequest request)
        {
            try
            {
                var response = _service.updateProducto(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("ListarProductos")]
        [ProducesResponseType(typeof(Response<List<Producto>>), 200)]
        public IActionResult listProductos()
        {
            try
            {
                var response = _service.listProductos();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

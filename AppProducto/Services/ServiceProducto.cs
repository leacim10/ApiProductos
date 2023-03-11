using App.Businness.Manager;
using App.Entity.Model;
using App.Entity.Request;
using App.Entity.Response;

namespace AppProducto.Services
{
    public interface IServiceProducto
    {
        Response<string> addProducto(anadirProductoRequest request);
        Response<string> updateProducto(actualizarProductoRequest request);
        Response<List<Producto>> listProductos();
    }
    public class ServiceProducto : IServiceProducto
    {
        private readonly IManagerProductos _manager;
        public ServiceProducto(IManagerProductos manager)
        {
            _manager = manager;
        }

        public Response<string> addProducto(anadirProductoRequest request)
        {
            try
            {
                var response = _manager.addProducto(request);
                return Response<string>.Completed(response);
            }
            catch(Exception ex)
            {
                return Response<string>.Error(ex.Message);
            }
        }

        public Response<List<Producto>> listProductos()
        {
            try
            {
                var response = _manager.listProductos();
                return Response<List<Producto>>.Completed(response);
            }
            catch (Exception ex)
            {
                return Response<List<Producto>>.Error(ex.Message);
            }
        }

        public Response<string> updateProducto(actualizarProductoRequest request)
        {
            try
            {
                var response = _manager.updateProducto(request);
                return Response<string>.Completed(response);
            }
            catch (Exception ex)
            {
                return Response<string>.Error(ex.Message);
            }
        }
    }
}

using App.Businness.Repository;
using App.Entity.Model;
using App.Entity.Request;
using App.Entity.Settings;
using App.Logger;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Businness.Manager
{
    public interface IManagerProductos
    {
        string addProducto(anadirProductoRequest request);
        string updateProducto(actualizarProductoRequest request);
        List<Producto> listProductos();
    }
    public class ManagerProductos : IManagerProductos
    {
        private IProductosRepository _repository;

        private readonly dataBaseEntity _dataBase;
        private static readonly string _sectionDataBase = "DataBase";

        private readonly ILogger _logger;

        public ManagerProductos(IConfiguration configuration, ILogger logger)
        {
            _logger = logger;

            _dataBase = new dataBaseEntity();
            configuration.GetSection(_sectionDataBase).Bind(_dataBase);

            _repository = new ProductosRepository(_dataBase);
        }

        public string addProducto(anadirProductoRequest request)
        {
            try
            {
                //Clase en la que se maneja la logica de negocio como operaciones y algoritmos complejos
                return _repository.addProducto(request.codProducto_VC, request.descripcion_VC) ? "El producto fue guardado correctamente." : "Se produjo un error al guardar el producto.";
            }
            catch (Exception ex)
            {
                _logger.Error($"[addProducto] Error: {ex.Message}");
                throw ex;
            }
        }

        public string updateProducto(actualizarProductoRequest request)
        {
            try
            {
                //Clase en la que se maneja la logica de negocio como operaciones y algoritmos complejos
                return _repository.updateProducto(request.idProducto_IN, request.codProducto_VC, request.stock_IN, request.usuario_VC) ? $"Se actualizo correctamente el producto con codigo: {request.codProducto_VC}." : $"Se produjo un error al guardar el producto con código: {request.codProducto_VC}.";
            }
            catch (Exception ex)
            {
                _logger.Error($"[updateProducto] Error: {ex.Message}");
                throw ex;
            }
        }

        public List<Producto> listProductos()
        {
            try
            {
                //Clase en la que se maneja la logica de negocio como operaciones y algoritmos complejos
                return _repository.listProductos();
            }
            catch (Exception ex)
            {
                _logger.Error($"[listProductos] Error: {ex.Message}");
                throw ex;
            }
        }
    }
}

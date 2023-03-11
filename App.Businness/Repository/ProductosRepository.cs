using App.DataAccess;
using App.Entity.Model;
using App.Entity.Settings;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Businness.Repository
{
    public interface IProductosRepository
    {
        bool addProducto(string codProducto, string descripcion);
        bool updateProducto(int idProducto, string codProducto, int stock, string usuario);
        List<Producto> listProductos();
    }
    public class ProductosRepository : IProductosRepository
    {
        private IDataAccess _dataAccess;
        private dataBaseEntity _dataBase;

        public ProductosRepository(dataBaseEntity dataBase)
        {
            _dataBase = dataBase; ;
            _dataAccess = new App.DataAccess.DataAccess(_dataBase);
        }

        public bool addProducto(string codProducto, string descripcion)
        {
            try
            {
                List<MySqlParameter> listParameters = new List<MySqlParameter>();
                listParameters.Add(new MySqlParameter("@_codProducto_VC", codProducto));
                listParameters.Add(new MySqlParameter("@_descripcion_VC", descripcion));

                return _dataAccess.ExecuteStoredProcedure("dbPrueba", "addProducto", listParameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"[addProducto] Error: {ex.Message}");
            }
        }

        public List<Producto> listProductos()
        {
            try
            {
                List<Producto> listProductos = new List<Producto>();
                List<MySqlParameter> listParameters = new List<MySqlParameter>();
                DataTable result = _dataAccess.SelectStoredProcedure("dbPrueba", "listProductos", listParameters);
                if (result.Rows.Count > 0)
                {
                    foreach (DataRow row in result.Rows)
                    {
                        Producto productos = new Producto();
                        productos.idProducto_IN = int.Parse(row["idProducto_IN"].ToString());
                        productos.codProducto_VC = row["codProducto_VC"].ToString();
                        productos.descripcion_VC = row["descripcion_VC"].ToString();
                        productos.fechaCreacion_DT = DateTime.Parse( row["fechaCreacion_DT"].ToString());
                        productos.fechaModificacion_DT = DateTime.Parse( row["fechaModificacion_DT"].ToString());
                        productos.stock_IN = int .Parse(row["stock_IN"].ToString());
                        listProductos.Add(productos);
                    }
                }
                return listProductos;
            }
            catch (Exception ex)
            {
                throw new Exception($"[listProductos] Error: {ex.Message}");
            }
        }

        public bool updateProducto(int idProducto, string codProducto, int stock, string usuario)
        {
            try
            {
                List<MySqlParameter> listParameters = new List<MySqlParameter>();
                listParameters.Add(new MySqlParameter("@_idProducto_IN", idProducto));
                listParameters.Add(new MySqlParameter("@_codProducto_VC", codProducto));
                listParameters.Add(new MySqlParameter("@_stock_IN", stock));
                listParameters.Add(new MySqlParameter("@_usuario_VC", usuario));

                return _dataAccess.ExecuteStoredProcedure("dbPrueba", "updateProducto", listParameters);
            }
            catch (Exception ex)
            {
                throw new Exception($"[updateProducto] Error: {ex.Message}");
            }
        }
    }
}

using Infraestructura;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio1
{
  public class ServicioProducto
    {
        Datos.AgenciaSegurosFalabellaEntities context = new Datos.AgenciaSegurosFalabellaEntities();
        public bool RegistrarProducto(InfraestructuraProductos producto)
        {
            try
            {
                context.PRODUCTOS.Add(new Datos.PRODUCTOS()
                {
                    
                    COM_CONT = producto.COM_CONT,
                    PRO_PRIMA = producto.PRO_PRIMA,
                    PRO_COBERTURA= producto.PRO_COBERTURA,
                    PRO_ASISTENCIA = producto.PRO_ASISTENCIA,
                    PRO_NOMBRE= producto.PRO_NOMBRE
                });
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<InfraestructuraProductos> TraerTodosProductos()
        {
            try
            {
                InfraestructuraProductos producto;
                List<InfraestructuraProductos> lista = new List<InfraestructuraProductos>();
                var listax = context.PRODUCTOS.ToList();
                foreach (var item in listax)
                {
                    producto = new InfraestructuraProductos
                    {
                        PRO_CONT = item.PRO_CONT,
                        COM_CONT =Convert.ToInt32(item.COM_CONT),
                        PRO_PRIMA = item.PRO_PRIMA,
                        PRO_COBERTURA = item.PRO_COBERTURA,
                        PRO_ASISTENCIA = item.PRO_ASISTENCIA,
                        PRO_NOMBRE = item.PRO_NOMBRE
                    };

                    lista.Add(producto);

                }



                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public InfraestructuraProductos TraerProducto(int id)
        {

            var producto = context.PRODUCTOS.Where(x => x.PRO_CONT == id).SingleOrDefault();
            InfraestructuraProductos objeto = new InfraestructuraProductos
            {
                PRO_CONT = producto.PRO_CONT,
                COM_CONT = Convert.ToInt32(producto.COM_CONT),
                PRO_PRIMA = producto.PRO_PRIMA,
                PRO_COBERTURA = producto.PRO_COBERTURA,
                PRO_ASISTENCIA = producto.PRO_ASISTENCIA,
                PRO_NOMBRE = producto.PRO_NOMBRE
            };
            return objeto;
        }
        public bool ElimarProducto(int id)
        {
            try
            {
                Datos.PRODUCTOS objeto = context.PRODUCTOS.Where(x => x.PRO_CONT == id).Single();
                context.PRODUCTOS.Remove(objeto);
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool ModificarProducto(int Id, InfraestructuraProductos producto)
        {
            try
            {
                var Producto = context.PRODUCTOS.Where(x => x.PRO_CONT == Id).FirstOrDefault();
                Producto.PRO_NOMBRE = producto.PRO_NOMBRE;
                context.Entry(Producto).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }



        }
    }
}

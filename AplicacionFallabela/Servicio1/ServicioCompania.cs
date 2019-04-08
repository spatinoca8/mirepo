using Infraestructura;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio1
{
   public class ServicioCompania
    {
        Datos.AgenciaSegurosFalabellaEntities context = new Datos.AgenciaSegurosFalabellaEntities();
        public bool RegistrarCompania(InfraestructuraCompania compania)
        {
            try
            {
                context.COMPANIA.Add(new Datos.COMPANIA()
                {                    
                    COM_NOMBRE = compania.COM_NOMBRE,
                    COM_NIT = compania.COM_NIT
                });
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<InfraestructuraCompania> TraerTodasCompanias()
        {
            try
            {
                InfraestructuraCompania compania;
                List<InfraestructuraCompania> lista = new List<InfraestructuraCompania>();
                 var listax = context.COMPANIA.ToList();
                foreach (var item in listax)
                {
                    compania = new InfraestructuraCompania
                    {
                        COM_CONT = item.COM_CONT,
                        COM_NIT =Convert.ToInt32( item.COM_NIT),
                        COM_NOMBRE= item.COM_NOMBRE
                    };

                    lista.Add(compania);                        

                }
                
               

                return lista;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool ModificarCompania(int Id, InfraestructuraCompania compania)
        {
            try
            {
                var Compania = context.COMPANIA.Where(x => x.COM_CONT == Id).FirstOrDefault();
                Compania.COM_NOMBRE = compania.COM_NOMBRE;
                Compania.COM_NIT = compania.COM_NIT;
                context.Entry(Compania).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }



        }
        public InfraestructuraCompania Traercompania(int id)
        {

            var compania = context.COMPANIA.Where(x => x.COM_CONT == id).SingleOrDefault();
            InfraestructuraCompania objeto = new InfraestructuraCompania
            {
                COM_CONT = compania.COM_CONT,
                COM_NOMBRE = compania.COM_NOMBRE,
                COM_NIT =Convert.ToInt32( compania.COM_NIT)
            };
            return objeto;
        }
        public bool ElimarCompania(int id)
        {
            try
            {
                Datos.COMPANIA objeto = context.COMPANIA.Where(x => x.COM_CONT == id).Single();
                context.COMPANIA.Remove(objeto);
                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}

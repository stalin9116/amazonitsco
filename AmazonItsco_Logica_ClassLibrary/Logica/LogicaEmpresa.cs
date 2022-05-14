using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazonItsco_Data_ClassLibrary;
using System.Data.Linq;

namespace AmazonItsco_Logica_ClassLibrary.Logica
{
    public class LogicaEmpresa
    {
        public dcAmazonItscoDataContext dc = new dcAmazonItscoDataContext();

        public List<Empresa> getAllEmpresa()
        {
            try
            {
                var listEmpresa = dc.Empresa.Where(data => data.emp_status.Equals("A"));

                return listEmpresa.ToList();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al obtener datos");
            }
        }

        public List<Empresa> getAllEmpresaById(int idEmpresa)
        {
            try
            {
                var listEmpresa = dc.Empresa.Where(data => data.emp_status.Equals("A")
                                                   && data.emp_id.Equals(idEmpresa));

                return listEmpresa.ToList();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al obtener datos");
            }
        }


        public bool save(Empresa empresa)
        {
            try
            {
                empresa.emp_status = 'A';

                dc.Empresa.InsertOnSubmit(empresa);

                dc.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al obtener datos" + ex.Message);
            }
        }

    }
}

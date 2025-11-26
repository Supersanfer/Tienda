using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Tienda
{
    public class ClienteService
    {
        public Dictionary<string, Cliente> Clientes { get; set; } = new Dictionary<string, Cliente>();
        public ClienteService()
        {
            CargarClientesFichero();
        }

        private void CargarClientesFichero()
        {
            string fullPath = Path.Combine(AppContext.BaseDirectory, "Resources", "Datos", "datosClientes.txt");
            if (File.Exists(fullPath))
            {
                var lineas = File.ReadAllLines(fullPath);
                foreach (var linea in lineas)
                {
                    var datos = linea.Split('#');
                    if (datos.Length == 6) // porque si tiene mas de 6 elementos no se cuenta (cada linea tiene 6 elementos)
                    {
                        var cliente = new Cliente(
                            datos[0],
                            datos[1],
                            datos[2],
                            datos[3],
                            datos[4],
                            bool.Parse(datos[5])
                        );
                        Clientes[cliente.Correo] = cliente;
                    }
                }
            }
        }
        public List<Cliente> ObtenerClientes()
        {
            return Clientes.Values.ToList();
        }
    }
}

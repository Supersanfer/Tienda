using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda
{
    public class Cliente
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Ciudad {  get; set; }
        public string Correo { get; set; }
        public string Comentarios { get; set; }
        public bool Vip {  get; set; }

        public Cliente()
        {
        }

        public Cliente(string nombre, string apellidos, string ciudad, string correo, string comentarios, bool vip)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            Ciudad = ciudad;
            Correo = correo;
            Comentarios = comentarios;
            Vip = vip;
        }

        public override bool Equals(object? obj)
        {
            return obj is Cliente cliente &&
                   Correo == cliente.Correo;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Correo);
        }
    }
}

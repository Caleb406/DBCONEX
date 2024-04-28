using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionUsuarios
{
    internal class UsuarioDto
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }

        }

        private string apellido;

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string pais;

        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usersapp.Logica
{
    class lusuarios
    {
        private int idusuario;
        private string usuario;
        private string clave;
        private byte[] icono;
        private string estado;

        public int Idusuario

        { 
        get { return idusuario; } 
        set { idusuario = value; } 
        }
        public string Usuario
        { 
        get { return usuario; } 
        set { usuario = value; } 
        }
        public string Clave
        { 
        get { return clave; } 
        set { clave = value; } 
        }
        public byte[] Icono
        { 
        get { return icono; } 
        set { icono = value; } 
        }
        public string Estado 
        { 
        get { return estado; } 
        set { estado = value; } 
        
        }

        public lusuarios() { }

        public lusuarios (int idUsuario, string usuario, string clave, byte[] icono, string estado)
        { Idusuario = idUsuario; Usuario = usuario; Clave = clave; Icono = icono; Estado = estado; }
    }
}

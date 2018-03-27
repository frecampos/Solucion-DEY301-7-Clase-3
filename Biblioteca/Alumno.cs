using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Alumno
    {
        //campos "atributos"
        private String _rut;
        private String _nombre;
        private String _apellido;
        private int _edad;
        private TipoCurso _curso;
        //propiedades "get/set"
        public string Rut
        {
            get
            {
                return _rut;
            }

            set
            {
                _rut = value;
            }
        }
        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }
        public string Apellido
        {
            get
            {
                return _apellido;
            }

            set
            {
                _apellido = value;
            }
        }
        public int Edad
        {
            get
            {
                return _edad;
            }

            set
            {
                if (value>=6 && value<=13)
                {
                    _edad = value;
                }
                else
                {
                    throw new ArgumentException("edad fuera de rango");
                }
                
            }
        }
        public TipoCurso Curso
        {
            get
            {
                return _curso;
            }

            set
            {
                _curso = value;
            }
        }

        public Alumno()
        {

        }


    }
}

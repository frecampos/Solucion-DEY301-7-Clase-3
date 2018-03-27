using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca;

namespace Controlador
{
    public class DaoAlumno
    {
        static List<Alumno> alumnos;
        public DaoAlumno()
        {
            if (alumnos==null)
            {
                alumnos = new List<Alumno>();
            }
        }
        //metodos C.R.U.D
        public Boolean Crear(Alumno alum) {
            if (ExisteAlumno(alum.Rut)==false)
            {
                alumnos.Add(alum);
                return true;
            }
            return false;
            
        }

        private bool ExisteAlumno(string rut)
        {
            foreach (Alumno item in alumnos)
            {
                if (item.Rut.Equals(rut))
                {
                    return true;
                }
            }
            return false;
        }
        public List<Alumno> Listar()
        {
            return alumnos;
        }
        public Boolean Eliminar(String rut)
        {
            foreach (Alumno item in alumnos)
            {
                if (item.Rut.Equals(rut))
                {
                    alumnos.Remove(item);
                    return true;
                }
            }
            return false;
        }
    }
}

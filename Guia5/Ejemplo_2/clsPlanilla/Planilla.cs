using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsPlanilla
{
    public class Planilla
    {
        /*
        *--------------------------------
        * Atributos
        * --------------------------------
        * Define avance de generacion planilla contable
        */
        private int Estado; //Valores:1.Sin iniciar, 2 en proceso, 3 finalizada
        //indentificacion de propietarop de planilla
        private string Empresa;
        private DateTime FechaPlanilla;

        //Diccionario de objetos con informe de c/u de los empleados
        private Dictionary<int,Empleado>
    }
}

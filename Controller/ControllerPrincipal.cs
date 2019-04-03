using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeto_calculadora.Controller
{
    class ControllerPrincipal
    {

        internal bool VerificaSeIgualZero(TextBox txt)
        {
            if (txt.Text.Trim().Equals("0")) return true;
            else return false;
        }

        internal bool VerificaSeVazio(TextBox txt)
        {
            if (txt.Text.Trim().Equals(string.Empty)) return true;
            else return false;
        }


        internal bool VerificaSeTemPonto(TextBox txt)
        {
            if (txt.Text.Trim().Contains(".")) return true;
            else return false;
        }

        internal bool VeriricaSeIgualPressionado(bool pressionouIgual)
        {
            if (pressionouIgual) return true;
            else return false;
        }

    }
}

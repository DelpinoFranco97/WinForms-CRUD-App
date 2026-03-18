using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helpers
{
    public static class HelperTextBox
    {

        public static bool validar(TextBox text, string nombreCampo)
        {
            if (!string.IsNullOrEmpty(text.Text))
            {
                return true;
            }

            else
            {
                return false;
            }


        }
    }
}

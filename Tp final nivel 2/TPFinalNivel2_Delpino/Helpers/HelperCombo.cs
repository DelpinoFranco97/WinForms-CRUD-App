using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helpers
{
    public  static class HelperCombo
    {

        public static bool validarComboBox(ComboBox comboBox, string nombreCampo)
        {
            if (comboBox.SelectedIndex == -1)
            {
                MessageBox.Show(
                  $"El campo {nombreCampo} esta sin seleccionar",
                  "Campo obligatorio",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
    


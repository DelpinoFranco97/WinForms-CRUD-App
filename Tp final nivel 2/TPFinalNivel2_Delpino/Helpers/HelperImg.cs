using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helpers
{
    public static class HelperImg
    {
        public static void CargarImagen(PictureBox picture, string url)
        {
            try
            {
                picture.Load(url);
            }
            catch
            {
                picture.Load("https://i.imgur.com/8Km9tLL.png");
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Imaging;


using EAN13_Code.Class;


namespace EAN13_Code
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string a;
            Console.WriteLine("Inserir código de 12 digitos");
            a = Console.ReadLine();


            EAN13 x = new EAN13(a);

            PointF firstLocation = new PointF(10f, 10f);

            Bitmap bitmap = new Bitmap(a.Length * 120, 550);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                using (Font oFont = new Font("EAN-13", 250))
                {
                    //graphics.FillRectangle(Brushes.White, 0, 0, bitmap.Width, bitmap.Height);
                    graphics.DrawString(x.BarCodeEAN, oFont, Brushes.Black, firstLocation);
                }
            }

            bitmap.Save(@"D:\BAR_"+x.FinalEAN+".png", ImageFormat.Png);
            //Font oFont = new Font("Fonts/EAN-13.ttf", 20);


            Console.WriteLine("Código Gerado    " + x.FinalEAN);
            Console.WriteLine("Código Barras   " + x.BarCodeEAN);
            Console.WriteLine("Dígito final " + x.Digit);
            Console.WriteLine("Grupo:   " + x.group);

            Console.WriteLine("Pressione Qualquer tecla para sair");
            a = Console.ReadLine();

        }
    }
}

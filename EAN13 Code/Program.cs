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
        private Image DrawText(String text, Font font, Color textColor, Color backColor)
        {
            //first, create a dummy bitmap just to get a graphics object
            Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);

            //measure the string to see how big the image needs to be
            SizeF textSize = drawing.MeasureString(text, font);

            //free up the dummy image and old graphics object
            img.Dispose();
            drawing.Dispose();

            //create a new image of the right size
            img = new Bitmap((int)textSize.Width, (int)textSize.Height);

            drawing = Graphics.FromImage(img);

            //paint the background
            drawing.Clear(backColor);

            //create a brush for the text
            Brush textBrush = new SolidBrush(textColor);

            drawing.DrawString(text, font, textBrush, 0, 0);

            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();

            return img;

        }
        static void Main(string[] args)
        {
            string a;
            Console.WriteLine("Inserir código de 12 digitos");
            a = Console.ReadLine();
            //a = "abcdefghi jklmno pqrstuvxwy z 0123456789 |[]><?";
            //a = "871125300120";
            //a = "002345678901";
            //a   = "999999999999";
            //EAN13 x = new EAN13("111111111111");
            EAN13 x = new EAN13(a);

            PointF firstLocation = new PointF(10f, 10f);

            //Bitmap bitmap = new Bitmap(x.FinalEAN.Length * 50, 250);
            Bitmap bitmap = new Bitmap(a.Length * 120, 550);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                //using (Font oFont = new Font(@"./Fonts/EAN-13.ttf", 10))
                using (Font oFont = new Font("EAN-13", 250))
                {
                    //graphics.FillRectangle(Brushes.White, 0, 0, bitmap.Width, bitmap.Height);
                    //graphics.DrawString(x.FinalEAN, oFont, Brushes.Black, firstLocation);
                    graphics.DrawString(x.BarCodeEAN, oFont, Brushes.Black, firstLocation);
                }
            }

            bitmap.Save(@"D:\BAR_"+x.FinalEAN+".png", ImageFormat.Png);
            //Font oFont = new Font("Fonts/EAN-13.ttf", 20);


            Console.WriteLine("Código Gerado    " + x.FinalEAN);
            Console.WriteLine("Código Barras   " + x.BarCodeEAN);
            Console.WriteLine("Dígito final " + x.Digit);
            Console.WriteLine("Grupo:   " + x.group);

            //using (Graphics graphics = Graphics.FromImage(bitmap))
            //{
            //    graphics.FillRectangle(, 0, 0, bitmap.Width, bitmap.Height);

            //}

            Console.WriteLine("Pressione Qualquer tecla para sair");
            a = Console.ReadLine();

        }
    }
}

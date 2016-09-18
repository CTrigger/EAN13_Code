using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAN13_Code.Class
{
    class EAN13
    {

        private int Impar;
        private int Par;

        public string FinalEAN;
        public string BarCodeEAN;
        public string group;


        public string Digit;
        public string BaseEAN;


        public EAN13(string EAN)
        {
            group = "";
            BaseEAN = EAN;
            Par = 0;
            Impar = 0;

            char[] R    = { 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y' };
            char[] r    = { 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y' };

            char[] G    = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] g    = { 'J', 'K', 'L', 'M', 'N', 'O', 'j', 'k', 'l', 'm' };

            char[] L    = { 'Z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I' };
            char[] l    = { 'z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i' };
            char[] first = { '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*' };
            char[] Code = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '1', '2' };

            for (int i = 0; i < EAN.Length; i++)
            {
                
                if (i % 2 == 0)
                {
                    Par += Convert.ToInt32(Char.GetNumericValue(EAN[i]));
                }

                else
                {
                    Impar += Convert.ToInt32(Char.GetNumericValue(EAN[i]));
                }

            }
            Impar = Impar * 3;

            Digit = Convert.ToString((10 - ((Par + Impar) % 10)) % 10);

            FinalEAN = BaseEAN + Digit;

            for (int i = 1; i <= 7; i++)
            {
                if (i < 7)
                {
                    //Tratamento do Grupo L
                    if (i == 1)
                    {
                        if (FinalEAN[i] != '1')
                        {
                            Code[i] = l[(int)Char.GetNumericValue(FinalEAN[i])];
                            group = group + "L";
                        }
                        else
                        {
                            Code[i] = g[(int)Char.GetNumericValue(FinalEAN[i])];
                            group = group + "G";
                        }
                    }

                    if (i == 2)
                    {
                        if (FinalEAN[i] == '0' || FinalEAN[i] == '2'|| FinalEAN[i] == '3')
                        {
                            Code[i] = L[(int)Char.GetNumericValue(FinalEAN[i])];
                            group = group + "L";
                        }
                        else
                        {
                            Code[i] = G[(int)Char.GetNumericValue(FinalEAN[i])];
                            group = group + "G";
                        }
                    }

                    if (i==3)
                    {
                        if (FinalEAN[i] == '0' || FinalEAN[i] == '1' || FinalEAN[i] == '4' || FinalEAN[i] == '7' || FinalEAN[i] == '8')
                        {
                            Code[i] = L[(int)Char.GetNumericValue(FinalEAN[i])];
                            group = group + "L";
                        }
                        else
                        {
                            Code[i] = G[(int)Char.GetNumericValue(FinalEAN[i])];
                            group = group + "G";
                        }
                    }

                    if (i == 4)
                    {
                        if (FinalEAN[i] == '0' || FinalEAN[i] == '4' || FinalEAN[i] == '5' || FinalEAN[i] == '9')
                        {
                            Code[i] = L[(int)Char.GetNumericValue(FinalEAN[i])];
                            group = group + "L";
                        }
                        else
                        {
                            Code[i] = G[(int)Char.GetNumericValue(FinalEAN[i])];
                            group = group + "G";
                        }
                    }

                    if (i == 5)
                    {
                        if (FinalEAN[i] == '0' || FinalEAN[i] == '1' || FinalEAN[i] == '2' || FinalEAN[i] == '5' || FinalEAN[i] == '6' || FinalEAN[i] == '7')
                        {
                            Code[i] = L[(int)Char.GetNumericValue(FinalEAN[i])];
                            group = group + "L";
                        }
                        else
                        {
                            Code[i] = G[(int)Char.GetNumericValue(FinalEAN[i])];
                            group = group + "G";
                        }
                    }

                    if (i == 6)
                    {
                        if (FinalEAN[i] == '0' || FinalEAN[i] == '1' || FinalEAN[i] == '3' || FinalEAN[i] == '6' || FinalEAN[i] == '8' || FinalEAN[i] == '9')
                        {
                            Code[i] = L[(int)Char.GetNumericValue(FinalEAN[i])];
                            group = group + "L";
                        }
                        else
                        {
                            Code[i] = G[(int)Char.GetNumericValue(FinalEAN[i])];
                            group = group + "G";
                        }
                    }
                }

                if (i == 7)
                {
                    Code[i + 0] = R[(int)Char.GetNumericValue(FinalEAN[i + 0])];
                    Code[i + 1] = R[(int)Char.GetNumericValue(FinalEAN[i + 1])];
                    Code[i + 2] = R[(int)Char.GetNumericValue(FinalEAN[i + 2])];
                    Code[i + 3] = R[(int)Char.GetNumericValue(FinalEAN[i + 3])];
                    Code[i + 4] = R[(int)Char.GetNumericValue(FinalEAN[i + 4])];
                    Code[i + 5] = r[(int)Char.GetNumericValue(FinalEAN[i + 5])];
                    group = group + " - RRRRRR";
                }
                    
            }
           
            BarCodeEAN =
                "" +
                first[(int)Char.GetNumericValue(EAN[0])] +
                Code[1] +
                Code[2] +
                Code[3] +
                Code[4] +
                Code[5] +
                Code[6] +
                "|" +
                Code[7] +
                Code[8] +
                Code[9] +
                Code[10] +
                Code[11] +
                Code[12];
                //"|";

        }

    }
}

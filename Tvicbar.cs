using System;
using System.Collections.Generic;
using System.Text;

namespace Terminal
{
    public class Tvicbar
    {
        static string gumar = null;

        public static string TvicBar(long tiv)
        {
            gumar = null;
            Tvanshan tvancshan = new Tvanshan();

            int[] TvanshanArray = Tvanshan.Tvanshanic(tiv);

            int lenghtDigit = TvanshanArray.Length;
            switch (lenghtDigit)
            {
                case 0: return "";

                case 1: MinchTas((int)tiv); return gumar;
                case 2: MinchHaryur((int)tiv); return gumar;
                case 3: MinchHazar((int)tiv); return gumar;
                case 4:
                case 5:
                case 6:
                    MinchMilion((int)tiv); return gumar;
                case 7:
                case 8:
                case 9:
                    MinchMiliard((int)tiv); return gumar;
                case 10:
                case 11:
                case 12:
                    MinchBiliard(tiv); return gumar;
                default:
                    return "";
            }

        }
        static void MinchTas(int tiv)
        {

            for (var i = Barer.zro; i < Barer.tas; i++)
            {
                if (((int)i).Equals(tiv))
                {
                    if (i != 0)
                    {
                        gumar += i.ToString() + " ";
                    }

                    break;
                }
            }
        }
        static void MinchHaryur(int tiv)
        {

            for (var i = Barer.tas; i < Barer.hazar; i += 10)
            {
                int a = tiv / 10 * 10;
                if (((int)i).Equals(a))
                {
                    gumar += i.ToString();
                    break;
                }

            }
            tiv %= 10;
            if (tiv != 0)
            {
                MinchTas(tiv);
            }


        }
        static void MinchHazar(int tiv)
        {
            for (var i = Barer.haryur; i < Barer.hazar; i++)
            {
                int a = 0, b = 0;
                if (tiv >= 100)
                {
                    a = tiv / tiv * 100;
                    b = tiv / 100;
                }
                if (tiv / 100 * 100 != 100)
                {
                    MinchTas(b);
                }
                if (((int)i).Equals(a))
                {
                    gumar += i.ToString() + " ";
                    break;
                }
            }
            tiv = tiv % 100;
            if (tiv != 0)
            {
                MinchHaryur(tiv);
            }
        }
        static void MinchMilion(int tiv)
        {

            for (var i = 1000; i < 1000000; i *= 10)
            {
                int b = 0;
                int a = 0;
                if (tiv / 1000 >= 0 & tiv / 1000 < 10)
                {
                    b = tiv / 1000;
                    a = tiv / tiv * 1000;
                    if (b != 1)
                    {
                        MinchTas(b);
                    }
                    if (((int)Barer.hazar).Equals(a))
                    {
                        gumar += Barer.hazar.ToString() + " ";
                        tiv = tiv % 1000;
                        if (tiv != 0)
                        {
                            MinchHazar(tiv);
                        }
                        break;
                    }

                }
                else if (tiv / 1000 >= 10 && tiv / 1000 < 100)
                {
                    b = tiv / 1000;
                    a = tiv / tiv * 1000;
                    MinchHaryur(b);
                    if (((int)Barer.hazar).Equals(a))
                    {
                        gumar += " " + Barer.hazar.ToString() + " ";
                        tiv = tiv % 1000;
                        if (tiv != 0)
                            if (tiv >= 100 && tiv < 1000)
                            {
                                MinchHazar(tiv);
                            }
                            else if (tiv > 0 && tiv < 10)
                            {
                                MinchTas(tiv);
                            }
                            else if (tiv >= 10 && tiv < 100)
                            {
                                MinchHaryur(tiv);
                            }
                        break;
                    }
                }
                else if (tiv / 1000 >= 100 && tiv / 1000 < 1000)
                {
                    b = tiv / 1000;
                    a = tiv / tiv * 1000;
                    MinchHazar(b);
                    if (((int)Barer.hazar).Equals(a))
                    {
                        gumar += " " + Barer.hazar.ToString() + " ";
                        tiv = tiv % 1000;
                        if (tiv != 0)
                            if (tiv >= 100 && tiv < 1000)
                            {
                                MinchHazar(tiv);
                            }
                            else if (tiv > 0 && tiv < 10)
                            {
                                MinchTas(tiv);
                            }
                            else if (tiv >= 10 && tiv < 100)
                            {
                                MinchHaryur(tiv);
                            }
                        break;
                    }
                }

            }

        }
        static void MinchMiliard(int tiv)
        {

            for (var i = 1000000; i < 1000000000; i *= 10)
            {
                int b = 0;
                int a = 0;
                if (tiv / 1000000 >= 0 & tiv / 1000000 < 10)
                {
                    b = tiv / 1000000;
                    a = tiv / tiv * 1000000;

                    MinchTas(b);

                    if (((int)Barer.milion).Equals(a))
                    {
                        gumar += " " + Barer.milion.ToString() + " ";
                        tiv = tiv % 1000000;


                        if (tiv >= 1000 && tiv < 1000000)
                        {
                            MinchMilion(tiv); break;
                        }
                        else if (tiv >= 0 && tiv < 100)
                        {

                            MinchHaryur(tiv); break;
                        }
                        else if (tiv >= 100 && tiv < 1000)
                        {
                            MinchHazar(tiv); break;
                        }

                    }
                }
                else if (tiv / 1000000 >= 10 && tiv / 1000000 < 100)
                {

                    b = tiv / 1000000;
                    a = tiv / tiv * 1000000;

                    MinchHaryur(b);

                    if (((int)Barer.milion).Equals(a))
                    {
                        gumar += Barer.milion.ToString() + " ";
                        tiv = tiv % 1000000;


                        if (tiv >= 1000 && tiv < 1000000)
                        {
                            MinchMilion(tiv); break;
                        }
                        else if (tiv >= 0 && tiv < 100)
                        {

                            MinchHaryur(tiv); break;
                        }
                        else if (tiv >= 100 && tiv < 1000)
                        {
                            MinchHazar(tiv); break;
                        }

                    }

                }
                else if (tiv / 1000000 >= 100 && tiv / 1000000 < 1000)
                {
                    b = tiv / 1000000;
                    a = tiv / tiv * 1000000;

                    MinchHazar(b);

                    if (((int)Barer.milion).Equals(a))
                    {
                        gumar += Barer.milion.ToString() + " ";
                        tiv = tiv % 1000000;


                        if (tiv >= 1000 && tiv < 1000000)
                        {
                            MinchMilion(tiv); break;
                        }
                        else if (tiv >= 0 && tiv < 100)
                        {

                            MinchHaryur(tiv); break;
                        }
                        else if (tiv >= 100 && tiv < 1000)
                        {
                            MinchHazar(tiv); break;
                        }
                    }
                }

            }

        }
        static void MinchBiliard(long tiv)
        {
            for (long i = 1000000000; i < 1000000000000; i *= 10)
            {
                long b = 0;
                long a = 0;
                if (tiv / 1000000000 >= 0 & tiv / 1000000000 < 10)
                {
                    b = tiv / 1000000000;
                    a = tiv / tiv * 1000000000;

                    MinchTas((int)b);

                    if (((long)(Barer.biliard)).Equals((a + 1)))
                    {
                        gumar += " " + Barer.miliard.ToString() + " ";
                        tiv = tiv % 1000000000;


                        if (tiv >= 1000000 && tiv < 100000000000)
                        {
                            MinchMiliard((int)tiv); break;
                        }
                        if (tiv >= 1000 && tiv < 10000000)
                        {
                            MinchMilion((int)tiv); break;
                        }
                        else if (tiv >= 0 && tiv < 100)
                        {

                            MinchHaryur((int)tiv); break;
                        }
                        else if (tiv >= 100 && tiv < 1000)
                        {
                            MinchHazar((int)tiv); break;
                        }

                    }
                }
                else if (tiv / 1000000000 >= 10 && tiv / 1000000000 < 100)
                {

                    b = tiv / 1000000000;
                    a = tiv / tiv * 1000000000;

                    MinchHaryur((int)b);

                    if (((long)(Barer.biliard)).Equals((a + 1)))
                    {
                        gumar += " " + Barer.miliard.ToString() + " ";
                        tiv = tiv % 1000000000;


                        if (tiv >= 1000000 && tiv < 100000000000)
                        {
                            MinchMiliard((int)tiv); break;
                        }
                        if (tiv >= 1000 && tiv < 10000000)
                        {
                            MinchMilion((int)tiv); break;
                        }
                        else if (tiv >= 0 && tiv < 100)
                        {

                            MinchHaryur((int)tiv); break;
                        }
                        else if (tiv >= 100 && tiv < 1000)
                        {
                            MinchHazar((int)tiv); break;
                        }

                    }

                }
                else if (tiv / 1000000000 >= 100 && tiv / 1000000000 < 1000)
                {
                    b = tiv / 1000000000;
                    a = tiv / tiv * 1000000000;

                    MinchHazar((int)b);

                    if (((long)(Barer.biliard)).Equals((a + 1)))
                    {
                        gumar += " " + Barer.miliard.ToString() + " ";
                        tiv = tiv % 1000000000;


                        if (tiv >= 1000000 && tiv < 100000000000)
                        {
                            MinchMiliard((int)tiv); break;
                        }
                        if (tiv >= 1000 && tiv < 10000000)
                        {
                            MinchMilion((int)tiv); break;
                        }
                        else if (tiv >= 0 && tiv < 100)
                        {

                            MinchHaryur((int)tiv); break;
                        }
                        else if (tiv >= 100 && tiv < 1000)
                        {
                            MinchHazar((int)tiv); break;
                        }

                    }
                }
                else if (tiv / 1000000000 >= 1000)
                {
                    break;
                }

            }

        }
    }
}

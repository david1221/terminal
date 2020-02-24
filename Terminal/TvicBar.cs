using System;
using System.Collections.Generic;
using System.Text;
using static Terminal.Words;

namespace Terminal
{
    public class Tvicbar
    {
        static string gumar = null;

        public static string TvicBar(long tiv)
        {
            gumar = null;
            Digits tvancshan = new Digits();

            int[] TvanshanArray = Digits.Tvanshanic(tiv);

            int lenghtDigit = TvanshanArray.Length;
            switch (lenghtDigit)
            {
                case 0: return "";

                case 1: Minchտաս((int)tiv); return gumar;
                case 2: Minchհարյուր((int)tiv); return gumar;
                case 3: Minchհազար((int)tiv); return gumar;
                case 4:
                case 5:
                case 6:
                    Minchմիլիոն((int)tiv); return gumar;
                case 7:
                case 8:
                case 9:
                    Minchմիլիարդ((int)tiv); return gumar;
                case 10:
                case 11:
                case 12:
                    MinchBiliard(tiv); return gumar;
                default:
                    return "";
            }

        }
        static void Minchտաս(int tiv)
        {

            for (var i = Word.զրո; i < Word.տաս; i++)
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
        static void Minchհարյուր(int tiv)
        {

            for (var i = Word.տաս; i < Word.հազար; i += 10)
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
                Minchտաս(tiv);
            }


        }
        static void Minchհազար(int tiv)
        {
            for (var i = Word.հարյուր; i < Word.հազար; i++)
            {
                int a = 0, b = 0;
                if (tiv >= 100)
                {
                    a = tiv / tiv * 100;
                    b = tiv / 100;
                }
                if (tiv / 100 * 100 != 100)
                {
                    Minchտաս(b);
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
                Minchհարյուր(tiv);
            }
        }
        static void Minchմիլիոն(int tiv)
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
                        Minchտաս(b);
                    }
                    if (((int)Word.հազար).Equals(a))
                    {
                        gumar += Word.հազար.ToString() + " ";
                        tiv = tiv % 1000;
                        if (tiv != 0)
                        {
                            Minchհազար(tiv);
                        }
                        break;
                    }

                }
                else if (tiv / 1000 >= 10 && tiv / 1000 < 100)
                {
                    b = tiv / 1000;
                    a = tiv / tiv * 1000;
                    Minchհարյուր(b);
                    if (((int)Word.հազար).Equals(a))
                    {
                        gumar += " " + Word.հազար.ToString() + " ";
                        tiv = tiv % 1000;
                        if (tiv != 0)
                            if (tiv >= 100 && tiv < 1000)
                            {
                                Minchհազար(tiv);
                            }
                            else if (tiv > 0 && tiv < 10)
                            {
                                Minchտաս(tiv);
                            }
                            else if (tiv >= 10 && tiv < 100)
                            {
                                Minchհարյուր(tiv);
                            }
                        break;
                    }
                }
                else if (tiv / 1000 >= 100 && tiv / 1000 < 1000)
                {
                    b = tiv / 1000;
                    a = tiv / tiv * 1000;
                    Minchհազար(b);
                    if (((int)Word.հազար).Equals(a))
                    {
                        gumar += " " + Word.հազար.ToString() + " ";
                        tiv = tiv % 1000;
                        if (tiv != 0)
                            if (tiv >= 100 && tiv < 1000)
                            {
                                Minchհազար(tiv);
                            }
                            else if (tiv > 0 && tiv < 10)
                            {
                                Minchտաս(tiv);
                            }
                            else if (tiv >= 10 && tiv < 100)
                            {
                                Minchհարյուր(tiv);
                            }
                        break;
                    }
                }

            }

        }
        static void Minchմիլիարդ(int tiv)
        {

            for (var i = 1000000; i < 1000000000; i *= 10)
            {
                int b = 0;
                int a = 0;
                if (tiv / 1000000 >= 0 & tiv / 1000000 < 10)
                {
                    b = tiv / 1000000;
                    a = tiv / tiv * 1000000;

                    Minchտաս(b);

                    if (((int)Word.միլիոն).Equals(a))
                    {
                        gumar += " " + Word.միլիոն.ToString() + " ";
                        tiv = tiv % 1000000;


                        if (tiv >= 1000 && tiv < 1000000)
                        {
                            Minchմիլիոն(tiv); break;
                        }
                        else if (tiv >= 0 && tiv < 100)
                        {

                            Minchհարյուր(tiv); break;
                        }
                        else if (tiv >= 100 && tiv < 1000)
                        {
                            Minchհազար(tiv); break;
                        }

                    }
                }
                else if (tiv / 1000000 >= 10 && tiv / 1000000 < 100)
                {

                    b = tiv / 1000000;
                    a = tiv / tiv * 1000000;

                    Minchհարյուր(b);

                    if (((int)Word.միլիոն).Equals(a))
                    {
                        gumar += Word.միլիոն.ToString() + " ";
                        tiv = tiv % 1000000;


                        if (tiv >= 1000 && tiv < 1000000)
                        {
                            Minchմիլիոն(tiv); break;
                        }
                        else if (tiv >= 0 && tiv < 100)
                        {

                            Minchհարյուր(tiv); break;
                        }
                        else if (tiv >= 100 && tiv < 1000)
                        {
                            Minchհազար(tiv); break;
                        }

                    }

                }
                else if (tiv / 1000000 >= 100 && tiv / 1000000 < 1000)
                {
                    b = tiv / 1000000;
                    a = tiv / tiv * 1000000;

                    Minchհազար(b);

                    if (((int)Word.միլիոն).Equals(a))
                    {
                        gumar += Word.միլիոն.ToString() + " ";
                        tiv = tiv % 1000000;


                        if (tiv >= 1000 && tiv < 1000000)
                        {
                            Minchմիլիոն(tiv); break;
                        }
                        else if (tiv >= 0 && tiv < 100)
                        {

                            Minchհարյուր(tiv); break;
                        }
                        else if (tiv >= 100 && tiv < 1000)
                        {
                            Minchհազար(tiv); break;
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

                    Minchտաս((int)b);

                    if (((long)(Word.biliard)).Equals((a + 1)))
                    {
                        gumar += " " + Word.միլիարդ.ToString() + " ";
                        tiv = tiv % 1000000000;


                        if (tiv >= 1000000 && tiv < 100000000000)
                        {
                            Minchմիլիարդ((int)tiv); break;
                        }
                        if (tiv >= 1000 && tiv < 10000000)
                        {
                            Minchմիլիոն((int)tiv); break;
                        }
                        else if (tiv >= 0 && tiv < 100)
                        {

                            Minchհարյուր((int)tiv); break;
                        }
                        else if (tiv >= 100 && tiv < 1000)
                        {
                            Minchհազար((int)tiv); break;
                        }

                    }
                }
                else if (tiv / 1000000000 >= 10 && tiv / 1000000000 < 100)
                {

                    b = tiv / 1000000000;
                    a = tiv / tiv * 1000000000;

                    Minchհարյուր((int)b);

                    if (((long)(Word.biliard)).Equals((a + 1)))
                    {
                        gumar += " " + Word.միլիարդ.ToString() + " ";
                        tiv = tiv % 1000000000;


                        if (tiv >= 1000000 && tiv < 100000000000)
                        {
                            Minchմիլիարդ((int)tiv); break;
                        }
                        if (tiv >= 1000 && tiv < 10000000)
                        {
                            Minchմիլիոն((int)tiv); break;
                        }
                        else if (tiv >= 0 && tiv < 100)
                        {

                            Minchհարյուր((int)tiv); break;
                        }
                        else if (tiv >= 100 && tiv < 1000)
                        {
                            Minchհազար((int)tiv); break;
                        }

                    }

                }
                else if (tiv / 1000000000 >= 100 && tiv / 1000000000 < 1000)
                {
                    b = tiv / 1000000000;
                    a = tiv / tiv * 1000000000;

                    Minchհազար((int)b);

                    if (((long)(Word.biliard)).Equals((a + 1)))
                    {
                        gumar += " " + Word.միլիարդ.ToString() + " ";
                        tiv = tiv % 1000000000;


                        if (tiv >= 1000000 && tiv < 100000000000)
                        {
                            Minchմիլիարդ((int)tiv); break;
                        }
                        if (tiv >= 1000 && tiv < 10000000)
                        {
                            Minchմիլիոն((int)tiv); break;
                        }
                        else if (tiv >= 0 && tiv < 100)
                        {

                            Minchհարյուր((int)tiv); break;
                        }
                        else if (tiv >= 100 && tiv < 1000)
                        {
                            Minchհազար((int)tiv); break;
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

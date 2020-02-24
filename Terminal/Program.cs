using System;
using System.Text;

namespace Terminal
{/// <summary>
/// from internet resources
/// </summary>
    //static class Program
    //{
    //    public static string NumberToText(this int n)
    //    {
    //        if (n < 0)
    //            return "Minus " + NumberToText(-n);
    //        else if (n == 0)
    //            return "";
    //        else if (n <= 19)
    //            return new string[] {"mek", "erku", "ereq", "chors", "hing", "vec", "yot", "ut",

    //"iny", "tas", "tasmek", "taserku", "tasereq", "taschors", "tashing","tasvec", "tasyot",
    //"tasut", "tasiny"}[n - 1] + " ";
    //        else if (n <= 99)
    //            return new string[] {"qsan", "eresun", "qarasun", "hitsun", "vatsun", "yotanasun",
    //"utsun", "insun"}[n / 10 - 2] + " " + NumberToText(n % 10);
    //        else if (n <= 199)
    //            return "Haryur " + NumberToText(n % 100);
    //        else if (n <= 999)
    //            return NumberToText(n / 100) + "haryur " + NumberToText(n % 100);
    //        else if (n <= 1999)
    //            return "hazar " + NumberToText(n % 1000);
    //        else if (n <= 999999)
    //            return NumberToText(n / 1000) + "hazar " + NumberToText(n % 1000);
    //        else if (n <= 1999999)
    //            return "mek milion " + NumberToText(n % 1000000);
    //        else if (n <= 999999999)
    //            return NumberToText(n / 1000000) + "milion " + NumberToText(n % 1000000);
    //        else if (n <= 1999999999)
    //            return "mek miliard " + NumberToText(n % 1000000000);
    //        else
    //            return NumberToText(n / 1000000000) + "miliard " + NumberToText(n % 1000000000);
    //    }
    //  static  void Main(string[] args)
    //    {
    //        Console.WriteLine(122545128.NumberToText());
    //    }
    class Program
    {
        class Account
        {
            string ToWord = null;

            public delegate void Gumar(string a);

            public event Gumar GumarHanelis;
            public event Gumar GumarMutqAnelis;

            public long gumarQanak;
            public Account(long sum)
            {
                this.gumarQanak = sum;

            }
            public long Nerka()
            {
                return gumarQanak;
            }
            public void MutqGumar(long mutqayin)
            {

                if (GumarMutqAnelis != null)
                {
                    gumarQanak += mutqayin;
                    ToWord = Tvicbar.TvicBar(gumarQanak);
                    GumarMutqAnelis.Invoke($" Հաշվին ավելացավ {mutqayin} և ներկա գումարն է {gumarQanak} դրամ");
                    GumarMutqAnelis.Invoke($"\"{ToWord} դրամ\"");
                }
            }

            public void ElqHashvic(long elqayin)
            {
                if (elqayin >= -gumarQanak)
                {
                    gumarQanak += elqayin;
                    ToWord = Tvicbar.TvicBar(gumarQanak);
                    if (GumarHanelis != null)
                    {
                        GumarHanelis.Invoke($" Ձեր հաշվից հանվեց {elqayin} և մնաց {gumarQanak} դրամ");

                        GumarMutqAnelis.Invoke($"\"{ToWord} դրամ\"");
                    }
                }
                else if (GumarHanelis != null)
                {
                    GumarHanelis($" Ձեր հաշվին չկա { elqayin } դրամի չափով գումար ,այլ մնացել է  {gumarQanak} չափով");
                    GumarMutqAnelis.Invoke($"\"{ToWord} դրամ\"");
                }
            }
        }
        private static void MessegeInfo(string mess)
        {
            Console.WriteLine(mess);
        }
      static  void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;


            Account account = new Account(100000);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"հաշվին առկա գումարի քանակը {(account.gumarQanak)} դրամ է");
            Console.ForegroundColor = ConsoleColor.Gray;
            account.GumarMutqAnelis += MessegeInfo;
            account.GumarHanelis += MessegeInfo;



            Console.WriteLine(" Ավելացնել գումար հաշվին (Օրինակ +5000) կամ հանել հաշվից (Օրիանկ -5000)");
            while (true)
            {
                long mutq = 0;
                try
                {
                    mutq = Convert.ToInt64(Console.ReadLine());
                }
                catch (Exception)
                {

                    Console.WriteLine("Գրել միայն թվեր ոչ ավել քան  999999999999"); ;
                }

                //կանչում ենք մեթոդը որը պետք է ավելացնի գումարը և կանչի սաբիտիայի ինվոկը
                if (mutq > 0)
                {
                    account.MutqGumar(mutq);

                }
                else if (mutq < 0)
                {
                    account.ElqHashvic(mutq);

                }
                else if (mutq == 0)
                {
                    Console.WriteLine("Դուք մուտքագրել եք 0 ");
                }
            }
        }
    }
}

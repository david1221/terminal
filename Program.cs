using System;

namespace Terminal
{

    class Program
    {
        class Account
        {
            string barerov = null;

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
                    barerov = Tvicbar.TvicBar(gumarQanak);
                    GumarMutqAnelis.Invoke($" hashvin avelacav {mutqayin} ev nerka gumarn e {gumarQanak} dram");
                    GumarMutqAnelis.Invoke($"\"{barerov} dram\"");
                }
            }

            public void ElqHashvic(long elqayin)
            {
                if (elqayin >= -gumarQanak)
                {
                    gumarQanak += elqayin;
                    barerov = Tvicbar.TvicBar(gumarQanak);
                    if (GumarHanelis != null)
                    {
                        GumarHanelis.Invoke($" Dzerhashvic hanvec {elqayin} ev mnac {gumarQanak} dram");

                        GumarMutqAnelis.Invoke($"\"{barerov} dram\"");
                    }
                }
                else if (GumarHanelis != null)
                {
                    GumarHanelis($" Dzer hashvin chka { elqayin } drami chapov gumar ,ayl mnacel e {gumarQanak} chapov");
                    GumarMutqAnelis.Invoke($"\"{barerov} dram\"");
                }
            }
        }
        private static void MessegeInfo(string mess)
        {
            Console.WriteLine(mess);
        }
        static void Main(string[] args)
        {


            Account account = new Account(100000);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($" Hashvin arka gumari qanaky {(account.gumarQanak)} dram e");
            Console.ForegroundColor = ConsoleColor.Gray;
            account.GumarMutqAnelis += MessegeInfo;
            account.GumarHanelis += MessegeInfo;



            Console.WriteLine(" Avelacnel gumar hasvin (Orinak +5000) kam hanel hashvic (Orinak -5000)");
            while (true)
            {
                long mutq = 0;
                try
                {
                    mutq = Convert.ToInt64(Console.ReadLine());
                }
                catch (Exception)
                {

                    Console.WriteLine("Grel miayn tver voch avel qan 999999999999"); ;
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
                    Console.WriteLine(" Duq mutqagrel eq 0 ");
                }
            }
        }
    }
}

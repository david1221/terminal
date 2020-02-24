using System;
using System.Collections.Generic;
using System.Text;

namespace Terminal
{
    public class Tvanshan
    {
        public static int[] Tvanshanic(long number)
        {
            long n = 0;
            
            long numberN = number;
          
            while (numberN > 0)
            {
                n++;
                numberN /= 10;
            }
            int[] numbers = new int[n];
            int[] numbersN = new int[n];
            
            for (int i = 0; i < n; i++)
            {
               numbers[i] = (int)(number % 10);
                number /= 10;
            }
           
            int m = 0;
            for (long i = n - 1; i > -1; i--)
            {
                numbersN[i] = numbers[m];
                m++;
            }

            

            return numbersN;
        }
    }
}

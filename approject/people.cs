using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace approject
{
    public class people
    {
        public string name;
        public string familyname;
        public int age;
        public string city;
        public string function1;
        public string function2;
        public double _x;
        public double _y;


        public people(string name , string familyname , int age , string city , string function1 , string function2)
        {
            this.name = name;
            this.familyname = familyname;
            this.city = city;
            this.age = age;
            this.function1 = function1;
            this.function2 = function2;
        }

        int i=0;
        char[] arr = new char[2];
        public void funcanswer()
        {
            for (int x=0; x < function1.Length ; x++)
            {
                if (function1[x] == 'a' || function1[x] == 'b' || function1[x] == 'c' || function1[x] == 'd' || function1[x] == 'e' || function1[x] == 'f'
                    || function1[x] == 'g' || function1[x] == 'h' || function1[x] == 'i' || function1[x] == 'j' || function1[x] == 'k' || function1[x] == 'l'
                    || function1[x] == 'm' || function1[x] == 'n' || function1[x] == 'o' || function1[x] == 'p' || function1[x] == 'q' || function1[x] == 'r'
                    || function1[x] == 's' || function1[x] == 't' || function1[x] == 'u' || function1[x] == 'v' || function1[x] == 'w' || function1[x] == 'x'
                    || function1[x] == 'y' || function1[x] == 'z')
                {
                    arr[i] = function1[x];
                    i++;
                }
            }
            List<int> Zarayeb1 = new List<int>();
            string[] x1 = function1.Split(arr[0]);

            if (x1[0] == "")
            {
                Zarayeb1.Add(1);
            }
            else
            {
                Zarayeb1.Add(int.Parse(x1[0]));
            }
            string[] y = x1[1].Split(arr[1]);
            string str = "";
           // for(int t=1;t<y[0].Length;t++)
            //{
              //  str += y[0][t];
            //}
            Zarayeb1.Add(int.Parse(y[0]));

            string[] str2;
            str2 = function1.Split('=');

            Zarayeb1.Add(int.Parse(str2[str2.Length - 1]));

            i = 0;
            for (int x = 0; x < function2.Length; x++)
            {
                if (function2[x] == 'a' || function2[x] == 'b' || function2[x] == 'c' || function2[x] == 'd' || function2[x] == 'e' || function2[x] == 'f'
                    || function2[x] == 'g' || function2[x] == 'h' || function2[x] == 'i' || function2[x] == 'j' || function2[x] == 'k' || function2[x] == 'l'
                    || function2[x] == 'm' || function2[x] == 'n' || function2[x] == 'o' || function2[x] == 'p' || function2[x] == 'q' || function2[x] == 'r'
                    || function2[x] == 's' || function2[x] == 't' || function2[x] == 'u' || function2[x] == 'v' || function2[x] == 'w' || function2[x] == 'x'
                    || function2[x] == 'y' || function2[x] == 'z')
                {
                    arr[i] = function2[x];
                    i++;
                }
            }
            List<int> Zarayeb2 = new List<int>();
             x1 = function2.Split(arr[0]);

            if (x1[0] == "")
            {
                Zarayeb2.Add(1);
            }
            else
            {
                Zarayeb2.Add(int.Parse(x1[0]));
            }
             y = x1[1].Split(arr[1]);
           
            str = "";
           // for (int t = 1; t < y[0].Length; t++)
            //{
              //  str += y[0][t];
           // }
            Zarayeb2.Add(int.Parse(y[0]));

        
            str2 = function2.Split('=');

            Zarayeb2.Add(int.Parse(str2[str2.Length - 1]));

            int a = Zarayeb1[0]; int b = Zarayeb1[1]; int c = -Zarayeb1[2];
            
            int p = Zarayeb2[0]; int q = Zarayeb2[1]; int r = -Zarayeb2[2];
            try
            {
                _x = (r * a - c * p) / (a * q - b * p);
                _y = (b * r - c * q) / (a * q - b * p);


            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Solution not possible", e);
                
            }
        }
    }
}

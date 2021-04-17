using System;

namespace Lab2
{
    class Licz
    {
        private int num;
        
        public Licz(int a)
        {
            num = a;
        }
        public void Dodaj(int a)
        {
            num += a;
        }
        public void Odejmij(int a)
        {
            num -= a;
        }
        public void Wypisz()
        {
            Console.WriteLine(num);
        }
    }
    class Sumator
    {
        private int[] nums = new int[10] {0,1,2,3,4,5,6,7,8,9};

        public void Suma()
        {
            int suma = 0;
            for(int i=0; i<nums.Length; i++)
            {
                suma += nums[i];
            }
            Console.WriteLine("Suma liczb w tab: " + suma);
        }
        public void SumaPodziel3()
        {
            int suma = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 3 == 0)
                {
                    suma += nums[i];
                }
            }
            Console.WriteLine("Suma liczb w tab podzielnych przez 3: " + suma);
        }

        public void IleElemtow()
        {
            Console.WriteLine(nums.Length);
        }
        public void WypiszElemety()
        {
            Console.WriteLine("Elementy tab: ");
            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write(nums[i] + ", ");
            }
        }

        public void ZakresTablicy(int lowIndex, int highIndex)
        {
            Console.WriteLine("ZakresTablicy: ");
            for(int i = 0; i < nums.Length; i++)
            {
                if (lowIndex <= nums[i] && highIndex >= nums[i])
                {
                    Console.Write(nums[i]+", ");
                }
            }
        }

    }
    class Data
    {
        /*public int day { get { return day; } set { if (value>=1 && value <= 31) { day = value; } else { Console.WriteLine("Month have 30 or 31days"); } } }
        public int month { get { return day; } set { if (value >= 1 && value <= 12) { day = value; } else { Console.WriteLine("Year have 12 month"); } } }
        public int year { get; set; }*/

        private int day, month, year;

        DateTime today = DateTime.Today;
        
        public string Error = String.Empty;
        public Data(int day, int month, int year)
        {
            if (day >= 1 && day <= 31) { this.day = day; }
            else
            {
                Error += "Error - Month have 30 or 31 days\n";
            }

            if (month >= 1 && month <= 12) { this.month = month; }
            else
            {
                Error += "Error - Year have 12 month";
            }
            this.year = year;
        }

        public void ErrorInform()
        {
            if(Error != String.Empty)
            {
                Console.WriteLine("Error!!\n{0}", Error);
            }
            else
            {
                Console.WriteLine("Your data is correct");
            }
        }

        public void TodayDay()
        {
            Console.WriteLine("Today: {0}",today.ToString("MM/dd/yyyy"));
        }

        public void WriteDayFromUser()
        {
            Console.WriteLine("MM-dd-yyyy:{0}/{1}/{2}", month,day,year);
        }

        public void NextWeek()
        {
            Console.WriteLine("Next week: {0}", today.AddDays(7).ToString("MM/dd/yyyy"));
        }

        public void PreviousWeek()
        {
            Console.WriteLine("Previous week: {0}", today.AddDays(-7).ToString("MM/dd/yyyy"));
        }

        public void FormatOfData()
        {
            if(day != null && month != null && year != null)
            {
                Console.WriteLine("MM-dd-yyyy:{0}/{1}/{2}", month, day, year);
                Console.WriteLine("dd-MM-yyyy:{0}/{1}/{2}", day, month, year);
            }
            else
            {
                Console.WriteLine(today.ToString("MM/dd/yyyy"));
            }
            
        }

    }
    class Liczba
    {
        private int size;
        private int[] nums;

        public Liczba(int sizeOfTable)
        {
            size = sizeOfTable;
            this.nums = new int[size];
        }

        public void WpiszLiczby()
        {
            Console.WriteLine("Podaj liczby:");
            for (int i=0; i <= nums.Length-1; i++)
            {
                string num = Console.ReadLine();
                nums[i] = Convert.ToInt32(num);
            }
        }

        public void WypiszTablice()
        {
            for (int i = 0; i <= nums.Length - 1; i++)
            {
                Console.Write(nums[i] + ", ");
            }
        }

        public void MnozenieTablicyPrzezLiczbe(int liczbaDoPomnozenia)
        {
            for (int i = 0; i <= nums.Length - 1; i++)
            {
                nums[i] *= liczbaDoPomnozenia;
            }

            Console.WriteLine("\nSilnia z podanej liczby: {0}",Silnia(liczbaDoPomnozenia));
        }

        public int Silnia(int n)
        {
            if (n == 0)
               return 1;
            else 
               return n * Silnia(n - 1);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            /*Lab2 - 1
            var obj = new Licz(1);
            obj.Wypisz();
            obj.Dodaj(7);
            obj.Wypisz();
            obj.Odejmij(2);
            obj.Wypisz();*/

            /*Lab2 -2
            var obj = new Sumator();
            obj.Suma();
            obj.SumaPodziel3();
            obj.IleElemtow();
            obj.WypiszElemety();
            obj.ZakresTablicy(3,6);*/

            /*Lab2 -3 
            Data obj = new Data(23,11,2000);
            obj.ErrorInform();
            obj.WriteDayFromUser();
            obj.TodayDay();
            obj.NextWeek();
            obj.PreviousWeek();
            obj.FormatOfData();*/

            Liczba obj = new Liczba(5);
            obj.WpiszLiczby();
            obj.WypiszTablice();
            obj.MnozenieTablicyPrzezLiczbe(3);
            obj.WypiszTablice();
        }
    }
}

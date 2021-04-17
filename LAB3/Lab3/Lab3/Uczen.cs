using System;
namespace Lab3
{
    class Uczen : Osoba
    {
        public String szkola;
        bool mozeWracacSamDoDomu = false;

        public void setSchool(String school)
        {
            szkola = school;
        }

        public void changeSchool(String school)
        {
            szkola = school;
        }

        public override void CanGoAloneToHome()
        {
            if (mozeWracacSamDoDomu) Console.WriteLine("Tak");
            else Console.WriteLine("NIE");
        }

        public void setCanGoHomeAlone(bool value)
        {
            mozeWracacSamDoDomu = value;
        }

        public bool getPerm()
        {
            return mozeWracacSamDoDomu;
        }

        public void info()
        {
            DateTime now = DateTime.Now;
            int age = this.getAge(now);

            if (age < 12) setCanGoHomeAlone(false);
            else setCanGoHomeAlone(true);
        }

    }
}

using System;
namespace Lab3
{
    class Osoba
    {
        public String imie;
        public String nazwisko;
        public String pesel;

        public virtual void GetEducationInfo() { }
        public virtual void GetFullName() { }
        public virtual void CanGoAloneToHome() { }

        public void setFirstName(String name)
        {
            imie = name;
        }

        public void setLastName(String name)
        {
            nazwisko = name;
        }

        public void setPesel(String pesel)
        {
            if (pesel.Length == 11)
            {
                this.pesel = pesel;
            }
        }

        public int getAge(DateTime val)
        {
            int year = Int32.Parse(pesel.Substring(0, 2)) + 1900;
            int month = Int32.Parse(pesel.Substring(2, 2));
            int day = Int32.Parse(pesel.Substring(4, 2));


            DateTime date = new DateTime(year: year, month: month, day: day);
            int age = val.Year - date.Year;

            if (date > val.AddYears(-age))
                age--;

            return age;
        }

        public String getGender()
        {
            if (Int32.Parse(pesel.Substring(10, 1)) % 2 == 0)
            {
                return "K";
            }
            else
            {
                return "M";
            }
        }

    }
}

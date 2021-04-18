using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Uczen : Osoba
    {

        string Szkola;
        bool MozeWracacSamDoDomu;

        public void SetSchool(string scl)
        {
            Szkola = scl;
        }

        public void ChangeSchool(string scl)
        {
            Szkola = scl;
        }

        public void SetCanGoHomeAlone()
        {
            if(GetAge()>12)
            {
                MozeWracacSamDoDomu = true;
            }
            else
            {
                MozeWracacSamDoDomu = false;
            }
        }

        public override bool CanGoAloneToHome()
        {
            if (MozeWracacSamDoDomu)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

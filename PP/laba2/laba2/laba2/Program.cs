using System;

namespace laba2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Organization gov = new Organization();
            Organization nat = new Organization(gov);
            Organization priv = new Organization(1, "name1", "n1", "address", DateTime.Now);

            University bgtu = new University();
            University bntu = new University(bgtu);
            University bgu = new University("name1", "n1", "address");

            Faculty tov = new Faculty();
            Faculty fit = new Faculty(tov);
            Faculty htit = new Faculty("name1", "n1", "address");

            gov.PrintInfo();
            nat.PrintInfo();
            priv.PrintInfo();

            bgtu.PrintInfo();
            bntu.PrintInfo();
            bgu.PrintInfo();

            tov.PrintInfo();
            fit.PrintInfo();
            htit.PrintInfo();

        }
    }
}
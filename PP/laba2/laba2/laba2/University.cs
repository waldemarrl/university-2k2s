using laba2;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

namespace laba2
{
    public class University : Organization, IStaff
    {
        protected List<Department> faculties;
        //public University()
        //{
        //    faculties = new List<Department>();
        //    Name = string.Empty;
        //    ShortName = string.Empty;
        //    Address = string.Empty;
        //}
        public University(University university)
        {
            faculties = new List<Department>();

            Name = university.Name;
            ShortName = university.ShortName;
            Address = university.Address;
        }
        public University(string _name, string _shortName, string _address)
        {
            faculties = new List<Department>();

            Name = _name;
            ShortName = _shortName;
            Address = _address;
        }
        public bool DelFaculty(int index)
        {
            if (index < 0 || index >= faculties.Count)
            {
                return false;
            }

            faculties.RemoveAt(index);
            return true;
        }
        public bool UpdFaculty(int index)
        {
            if (index < 0 || index >= faculties.Count)
            {
                return false;
            }

            faculties[index] = new Department();
            return true;
        }
        private bool VerFaculty(int index)
        {
            if (index < 0 || index >= faculties.Count)
            {
                return false;
            }
            return true;
        }
        public List<Department> GetFaculties()
        {
            return faculties;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}, ShortName: {ShortName}, Address: {Address}");
        }

        public new List<JobVacancy> GetJobVacancies() => new List<JobVacancy>();
        public new List<Employee> GetEmployees() => new List<Employee>();
        public new List<JobTitle> GetJobTitles() => new List<JobTitle>();

        public new int AddJobTitle(JobTitle title)
        {
            return 0;
        }
        public new string PrintJobVacancies() => "Vacancies";
        public new bool DelJobTitle(int a) => true;
        public new void OpenJobVacancy(JobVacancy vacancy)
        {

        }
        public new bool CloseJobVacancy(int a) => true;
        public new Employee Recruit(JobVacancy vacancy, Person person) => new Employee();
        public new bool Dismiss(int a, Reason r) => true;

        public University() : base() 
        {
        }
    }
}

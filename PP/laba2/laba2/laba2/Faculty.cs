using laba2;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

namespace laba2
{
    public class Faculty : Organization, IStaff
    {

        protected List<Department> departments;
        public Faculty()
        {
            departments = new List<Department>();
            Name = string.Empty;
            ShortName = string.Empty;
            Address = string.Empty;
        }
        public Faculty(Faculty faculty)
        {
            departments = new List<Department>();
            Name = faculty.Name;
            ShortName = faculty.ShortName;
            Address = faculty.Address;
        }
        public Faculty(string name, string shortName, string address)
        {
            departments = new List<Department>();
            Name = name;
            ShortName = shortName;
            Address = address;
        }
        public bool DelDepartment(int index)
        {
            if (index < 0 || index >= departments.Count)
            {
                return false;
            }

            departments.RemoveAt(index);
            return true;
        }
        public bool UpdDepartment(int index)
        {
            if (index < 0 || index >= departments.Count)
            {
                return false;
            }

            departments[index] = new Department();
            return true;
        }
        private bool VerDepartment(int index)
        {
            if (index < 0 || index >= departments.Count)
            {
                return false;
            }
            return true;
        }
        public List<Department> GetDepartment()
        {
            return departments;
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
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    public class Organization : IStaff
    {
        public int Id { get; private set; }
        public string Name { get; protected set; }
        public string ShortName { get; protected set; }
        public string Address { get; protected set; }
        public DateTime TimeStramp { get; protected set; }

        public Organization()
        {
            Id = 0;
            Name = string.Empty;
            ShortName = string.Empty;
            Address = string.Empty;
            TimeStramp = DateTime.Now;
        }
        public Organization(Organization organization)
        {
            Id = organization.Id + 1;
            Name = organization.Name;
            ShortName = organization.ShortName;
            Address = organization.Address;
            TimeStramp = organization.TimeStramp;
        }
        public Organization(int id, string name, string shortName, string address, DateTime timeStramp)
        {
            Id = id;
            Name = name;
            ShortName = shortName;
            Address = address;
            TimeStramp = timeStramp;
        }
        public virtual void PrintInfo()
        {
            Console.WriteLine($"Id: {Id}, Name: {Name}, ShortName: {ShortName}, Address: {Address}, TimeStramp: {TimeStramp}");
        }

        public List<JobVacancy> GetJobVacancies() => new List<JobVacancy>();
        public List<Employee> GetEmployees() => new List<Employee>();
        public List<JobTitle> GetJobTitles() => new List<JobTitle>();

        public int AddJobTitle(JobTitle title)
        {
            return 0;
        }
        public string PrintJobVacancies() => "Vacancies";
        public bool DelJobTitle(int a) => true;
        public void OpenJobVacancy(JobVacancy vacancy)
        {

        }
        public bool CloseJobVacancy(int a) => true;
        public Employee Recruit(JobVacancy vacancy, Person person) => new Employee();
        public bool Dismiss(int a, Reason r) => true;

    }
}

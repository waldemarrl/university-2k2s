using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace laba2
{
    public interface IStaff
    {
        List<JobVacancy> GetJobVacancies();
        List<Employee> GetEmployees();
        List<JobTitle> GetJobTitles();
        int AddJobTitle(JobTitle title);
        string PrintJobVacancies();
        bool DelJobTitle(int a);
        void OpenJobVacancy(JobVacancy vacancy);
        bool CloseJobVacancy(int a);
        Employee Recruit(JobVacancy vacancy, Person person);
        bool Dismiss(int a, Reason reason);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleLINQtoSQLITE
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDatabaseContext dbContext = new TestDatabaseContext("DbLinqProvider=Sqlite;" + @"Data Source=Database\Custom.db" + "DbLinqConnectionType=System.Data.SQLite.SQLiteConnection, System.Data.SQLite, Version=1.0.103.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139");

            List<Person> list = GetPeopleList(dbContext);
            PrintAllPeople(list);

            CreateNewCompany(dbContext);

            IQueryable<Company> query2 = SelectAllCompanies(dbContext);
            PrintAllCompanies(query2);
        }

        private static List<Person> GetPeopleList(TestDatabaseContext dbcon)
        {
            var q = from a in dbcon.GetTable<Person>()
                    select a;

            var list = q.ToList();
            return list;
        }

        private static void PrintAllPeople(List<Person> list)
        {
            Console.WriteLine("All the people!!");

            foreach (var item in list)
            {
                Console.WriteLine(item.PersonName);
            }
        }

        private static IQueryable<Company> SelectAllCompanies(TestDatabaseContext dbcon)
        {
            return from a in dbcon.GetTable<Company>()
                   select a;
        }

        private static void PrintAllCompanies(IQueryable<Company> q2)
        {
            Console.WriteLine("Here are the companies!");
            foreach (var item in q2.AsEnumerable())
            {
                Console.WriteLine($"CompanyID: {item.CompanyID}");
                Console.WriteLine($"Company Employee: {item.EmployeeID} Company Manager: {item.ManagerID}");
            }
        }

        private static void CreateNewCompany(TestDatabaseContext dbcon)
        {
            Company company = new Company();
            var matchedEmployee = (from a in dbcon.GetTable<Employee>()
                                   where a.EmployeeID == 4
                                   select a).SingleOrDefault();

            var matchedManager = (from a in dbcon.GetTable<Manager>()
                                   where a.ManagerRank == "Big Boss"
                                   select a).SingleOrDefault();

            company.EmployeeID = matchedEmployee.EmployeeID;
            company.ManagerID = matchedManager.ManagerID;
            dbcon.Company.InsertOnSubmit(company);
            dbcon.SubmitChanges();
        }
    }
}

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

        private static List<Person> GetPeopleList(TestDatabaseContext dbContext)
        {
            var q = from a in dbContext.GetTable<Person>()
                    select a;

            var list = q.ToList();
            return list;
        }

        private static void PrintAllPeople(List<Person> people)
        {
            Console.WriteLine("All the people!!");

            foreach (var item in people)
            {
                Console.WriteLine(item.PersonName);
            }
        }

        private static IQueryable<Company> SelectAllCompanies(TestDatabaseContext dbContext)
        {
            return from a in dbContext.GetTable<Company>()
                   select a;
        }

        private static void PrintAllCompanies(IQueryable<Company> companies)
        {
            Console.WriteLine("Here are the companies!");
            foreach (var item in companies.AsEnumerable())
            {
                Console.WriteLine($"CompanyID: {item.CompanyID}");
                Console.WriteLine($"Company Employee: {item.EmployeeID} Company Manager: {item.ManagerID}");
            }
        }

        private static void CreateNewCompany(TestDatabaseContext dbContext)
        {
            Company company = new Company();
            var matchedEmployee = (from a in dbContext.GetTable<Employee>()
                                   where a.EmployeeID == 4
                                   select a).SingleOrDefault();

            var matchedManager = (from a in dbContext.GetTable<Manager>()
                                   where a.ManagerRank == "Big Boss"
                                   select a).SingleOrDefault();

            company.EmployeeID = matchedEmployee.EmployeeID;
            company.ManagerID = matchedManager.ManagerID;
            dbContext.Company.InsertOnSubmit(company);
            dbContext.SubmitChanges();
        }
    }
}

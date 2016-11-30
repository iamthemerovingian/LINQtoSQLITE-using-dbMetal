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
            TestDatabaseContext dbContext = new TestDatabaseContext("DbLinqProvider=Sqlite;" + @"Data Source=Databasdfase\Custom.db" + "DbLinqConnectionType=System.Data.SQLite.SQLiteConnection, System.Data.SQLite, Version=1.0.103.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139");

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
            Console.WriteLine("all the people!!");

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
            Console.WriteLine("Company with 1 employee and 1 manager!");

            foreach (var item in q2.AsEnumerable())
            {
                Console.WriteLine($"Company Employee: {item.EmployeeID} Company Manaeger: {item.ManagerID}");
            }
        }

        private static void CreateNewCompany(TestDatabaseContext dbcon)
        {
            Company company = new Company();
            company.EmployeeID = 1;
            company.ManagerID = 5;
            dbcon.Company.InsertOnSubmit(company);
            dbcon.SubmitChanges();
        }
    }
}

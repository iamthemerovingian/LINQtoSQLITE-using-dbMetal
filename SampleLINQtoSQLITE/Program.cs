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
            //This is the dbconnection onject.
            TestDatabaseContext dbContext = new TestDatabaseContext("DbLinqProvider=Sqlite;" + @"Data Source=Database\Custom.db DbLinqConnectionType=System.Data.SQLite.SQLiteConnection, System.Data.SQLite, Version=1.0.103.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139");

            List<Person> list = GetPeopleList(dbContext);
            PrintAllPeople(list);

            CreateNewCompany(dbContext);

            IQueryable<Company> query2 = SelectAllCompanies(dbContext);
            PrintAllCompanies(query2);
        }

        /// <summary>
        /// This method will fetch the entire Person Table using LINQ.
        /// </summary>
        /// <param name="dbContext"> Is the parameter for the dbConnection</param>
        /// <returns></returns>
        private static List<Person> GetPeopleList(TestDatabaseContext dbContext)
        {
            var q = from a in dbContext.GetTable<Person>()
                    select a;

            var list = q.ToList();
            return list;
        }

        /// <summary>
        /// Prints all the people in the DB to the console.
        /// </summary>
        /// <param name="people"></param>
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

        /// <summary>
        /// This method simply prints the Employee ID and the ID for each company.
        /// </summary>
        /// <param name="companies"></param>
        private static void PrintAllCompanies(IQueryable<Company> companies)
        {
            Console.WriteLine("Here are the companies!");
            foreach (var item in companies.AsEnumerable())
            {
                Console.WriteLine($"CompanyID: {item.CompanyID}");
                Console.WriteLine($"Company Employee: {item.EmployeeID} Company Manager: {item.ManagerID}");
            }
        }

        /// <summary>
        /// This method will first fetch an employee and a manager and add them to the company.
        /// Then finally insert the new company into the SQLITE db.
        /// </summary>
        /// <param name="dbContext"></param>
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

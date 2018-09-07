using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryIt
{
    class Program
    {
        static void Main(string[] args)
        {
            //var repository = new Repository<Employee>(); //talks to real data base
            //AddEployee(repository);
            //AddManager(repository);
            //CountsEployees(repository);
            //PrintAllPeople(repository);

            Database.SetInitializer(new DropCreateDatabaseAlways<EmployeeDb>());

            using (IRepository<Employee> employeeRepository
                = new SqlRepository<Employee>(new EmployeeDb()))
            {
                AddEployees(employeeRepository);
                Addmanagers(employeeRepository);
                CountEmployyees(employeeRepository);
                QueryEmployee(employeeRepository);
                Console.WriteLine(" ");
                DumpPeaple(employeeRepository);

                IEnumerable<Person> temp = employeeRepository.FindAll();          
            }

        }

        private static void Addmanagers(IWriteoOnlyRepository<Manager> employeeRepository)
        {
            employeeRepository.Add(new Manager() {Name = "Baranauskas" });
            employeeRepository.Commit();
        }

        private static void DumpPeaple(IReadoOnlyRepository<Person> employeeRepository)
        {
            var employees = employeeRepository.FindAll();

            foreach (var emp in employees)
            {  
                Console.WriteLine(emp.Name);
            }
            
        }

        private static void QueryEmployee(IRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.FindById(3);
            Console.WriteLine(employee.Name);
        }

        private static void CountEmployyees(IRepository<Employee> employeeRepository)
        {
            Console.WriteLine($"Count of employees is : {employeeRepository.FindAll().Count()}");
        }

        private static void AddEployees(IRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee() { Name = "Aidas" });
            employeeRepository.Add(new Employee() { Name = "Chris" });
            employeeRepository.Add(new Employee() { Name = "Scott" });
            employeeRepository.Commit();
        }
    }
}

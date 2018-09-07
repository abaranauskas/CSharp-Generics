using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectIt
{
    class Program
    {
        static void Main(string[] args)
        {
            //var employeeList = new List<Employee>() { new Employee { Name = "john" } };
            //var employeeList = CreateColection(typeof(List<Employee>)); //kitoks budas sukurti objecta per
            //Activator.CreateInstance(type);

            var employeeList = CreateColection(typeof(List<>), typeof(Employee));


            Console.WriteLine(employeeList.GetType().Name);
            Console.WriteLine(employeeList.GetType().FullName);

            var genericArguments = employeeList.GetType().GetGenericArguments();
            foreach (var arg in genericArguments)
            {                
                Console.WriteLine(arg.Name);
            }

            Employee employee = new Employee();
            var employeeType = typeof(Employee);
            var methodInfo = employeeType.GetMethod("Speak");
            methodInfo = methodInfo.MakeGenericMethod(typeof(DateTime));

            methodInfo.Invoke(employee, null);


            //employee.Speak<int>();

        }

        private static object CreateColection(Type colectionType, Type itemType)
        {
            var closedType = colectionType.MakeGenericType(itemType);
            return Activator.CreateInstance(closedType);
        }
    }

    public class Employee
    {
        public string Name { get; set; }

        public void Speak<T>()
        {
            Console.WriteLine(typeof(T).Name);
        }
    }
}

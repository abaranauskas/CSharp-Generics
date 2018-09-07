using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectIt
{
    public class EmployeeCompare : IEqualityComparer<Employee>, IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return String.Compare(x.Name, y.Name);
        }

        public bool Equals(Employee x, Employee y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(Employee obj)
        {
            return obj.Name.GetHashCode();
        }
    }


    public class DepartmentColection : SortedDictionary<string, SortedSet<Employee>>
    {
        public DepartmentColection Add(string departmentName, Employee employee)
        {
            if (!ContainsKey(departmentName))
            {
                Add(departmentName, new SortedSet<Employee>(new EmployeeCompare()));
            }
            this[departmentName].Add(employee);
            return this;
        }
    }


    class Program
  {
        static void Main(string[] args)
        {
            var departments = new DepartmentColection(); ;

            departments.Add("Sales", new Employee() { Name = "Ian" })
                            .Add("Sales", new Employee() { Name = "Zohan" })
                            .Add("Sales", new Employee() { Name = "Jordan" })
                            .Add("Sales", new Employee() { Name = "Jordan" });


            departments.Add("Engineering", new Employee() { Name = "Zoe" })
                            .Add("Engineering", new Employee() { Name = "Aidas" })
                            .Add("Engineering", new Employee() { Name = "Chris" })
                            .Add("Engineering", new Employee() { Name = "Luke" })
                            .Add("Engineering", new Employee() { Name = "Jordan" })
                            .Add("Engineering", new Employee() { Name = "Chris" });






            foreach (var department in departments)
            {
                Console.WriteLine(department.Key+":");
                foreach (var emp in department.Value)
                {
                    Console.WriteLine("\t" + emp.Name);
                }
            }



            //----------------------------List<T> vardas---------------------

            //List<Employee> employees = new List<Employee>
            //{
            //    new Employee {Name = "Aidas" },
            //    new Employee {Name="Baras" }
            //};

            //employees.Add(new Employee { Name = "Daniel" });

            //foreach (var employee in employees)
            //{
            //    Console.WriteLine(employee.Name);
            //}

            //for (int i = 0; i < employees.Count; i++)
            //{
            //    Console.WriteLine(employees[i].Name);
            //}


            //var number = new List<int>(10);

            //Console.WriteLine(number.Capacity);

            //var capacity = -1;
            //while (true)
            //{
            //    if (number.Capacity != capacity)
            //    {
            //        capacity = number.Capacity;
            //        Console.WriteLine(capacity);
            //    }
            //    number.Add(1);
            //}

            //----------------------------Queue<T> vardas---------------------

            //Queue<Employee> line = new Queue<Employee>();

            //line.Enqueue(new Employee { Name = "Aidas" });
            //line.Enqueue(new Employee { Name = "Baras" });
            //line.Enqueue(new Employee { Name = "Alex" });

            //while (line.Count >0)
            //{
            //    Console.WriteLine(line.Dequeue().Name);
            //}


            //Console.WriteLine("--------------------");
            //----------------------------Stack<T> vardas---------------------

            //Stack<Employee> stack = new Stack<Employee>();


            //stack.Push(new Employee { Name = "Aidas" });
            //stack.Push(new Employee { Name = "Baras" });
            //stack.Push(new Employee { Name = "Alex" });

            //while (stack.Count > 0)
            //{   
            //   Console.WriteLine(stack.Pop().Name);
            //}

            //----------------------------HashSet<T> vardas---------------------

            /*HashSet<Employee> set = new HashSet<Employee>();

            set.Add(new Employee { Name = "Aidas" });
            set.Add(new Employee { Name = "Aidas" });
            set.Add(new Employee { Name = "Aidas" });
            set.Add(new Employee { Name = "Ben" });

            var employee = new Employee() { Name = "Alex" };

            set.Add(employee);
            set.Add(employee);
            set.Add(employee);
            //set.Add(3); //tik tiek kur nesikartoja, 
            //bet jei kuriam nauja objecta jis juos vertins 
            //kaip skirtingus nors reiksmes juose bus tokios pat cia 
            //reference visada bus skirtingas

            foreach (Employee item in set)
            {
                Console.WriteLine(item.Name);
            }*/

            //----------------------------LinkedList<T> vardas---------------------

            /*LinkedList<int> list = new LinkedList<int>();

            list.AddFirst(2);
            list.AddFirst(3); // 3 bus pirmesnis sarase uz 2

            //list[1]; //indexuiti per linedlist negalima

            var first = list.First; //reference i pirma sarase nari

            list.AddAfter(first, 22); //bus 2, 22, 3
            list.AddBefore(first, 55); //bus 55, 2, 22, 3 

            var node = list.First;

            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }

            employeeByName.Add("Ben", new Employee { Name = "Ben Noak" });

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(first.Previous.Value);*/

            //----------------------------Dictionary<TKey, TValue> vardas---------------------

            /* Dictionary<string, Employee> employeeByName = new Dictionary<string, Employee>();

             employeeByName.Add("Aidas", new Employee { Name = "Aidas Baranauskas" });
             employeeByName.Add("Ben", new Employee { Name = "Ben Noak" });
             employeeByName.Add("Chris", new Employee { Name = "Christopher Petrigno" });
             //employeeByName.Add("Ben", new Employee { Name = "Ben Dow" }); 
             //negalimas veiksmas Tkey turi but unikalus

             var ben = employeeByName["Ben"];

             foreach (var item in employeeByName)
             {
                 Console.WriteLine($"{item.Key} : {item.Value.Name}");
             }
             //----------------------------

             var employeesByDepartment = new Dictionary<string, List<Employee>>();

             employeesByDepartment.Add("Engineering", new List<Employee>
             {
                 new Employee { Name = "Aidas Baranauskas" },
                 new Employee { Name = "John Dow" },
                 new Employee { Name = "Lee Spokes" },
             });

             employeesByDepartment["Engineering"].Add(new Employee { Name = "Alex Garcia" });

             foreach (var item in employeesByDepartment)
             {
                 foreach (var employee in item.Value)
                 {
                     Console.WriteLine(employee.Name);
                 }
             }*/

            //----------------------------SortedDictionary<TKey, TValue> vardas---------------------
            //Sorted dictionary suruziuos pagal alfabeta arba skaiciu auromatiskai
            //Engineering bus pirmas tokiu atveju

            /*var employeesByName = new SortedDictionary<string, List<Employee>>();

            employeesByName.Add("Sales", new List<Employee>
             {
                 new Employee { Name = "Aidas Baranauskas" },
                 new Employee { Name = "John Dow" },
                 new Employee { Name = "Lee Spokes" }
             });

            employeesByName.Add("Engineering", new List<Employee>
             {
                 new Employee { Name = "Jonas Jonaitis" },
                 new Employee { Name = "Zoe ho" }
             });

            foreach (var item in employeesByName)
            {
                Console.WriteLine($"The count of employees for {item.Key} departmet is {item.Value.Count}");
            }

            //----------------------------SortedList<TKey, TValue> vardas---------------------
            //skirtumas nuo SortedDictonary maziau funkcionualumo
            //pvz nebus galima kreiptis employeesByName["Sales"]
            //Optimizuotas dictionary variantas

            var employeesByName2 = new SortedList<string, List<Employee>>();

            employeesByName2.Add("Sales", new List<Employee>
             {
                 new Employee { Name = "Aidas Baranauskas" },
                 new Employee { Name = "John Dow" },
                 new Employee { Name = "Lee Spokes" }
             });

            employeesByName2.Add("Engineering", new List<Employee>
             {
                 new Employee { Name = "Jonas Jonaitis" },
                 new Employee { Name = "Zoe ho" }
             });

            foreach (var item in employeesByName)
            {
                Console.WriteLine($"The count of employees for {item.Key} departmet is {item.Value.Count}");
            }*/


        }
    }
}

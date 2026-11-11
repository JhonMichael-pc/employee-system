
/*Name: Jhon Michael
 Matricula: 2025-1861*/


using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static int Main(string[] args)
    {
        string opcion = "";
        string exit = "no";

        List<Department> listdepartments = new List<Department>()
        {
            new Department { Id = 1, Name = "IT" },
            new Department { Id = 2, Name = "Human Resources" },
            new Department { Id = 3, Name = "Finance" },
            new Department { Id = 4, Name = "Sales" },
            new Department { Id = 5, Name = "Marketing" }
        };

        List<Position> listpositions = new List<Position>()
        {
            new Position { Id = 1, Name = "Developer" },
            new Position { Id = 2, Name = "Manager" },
            new Position { Id = 3, Name = "Accountant" },
            new Position { Id = 4, Name = "Sales Representative" },
            new Position { Id = 5, Name = "Designer" },
            new Position { Id = 6, Name = "Technician" }
        };

        Dictionary<int, Employee> employees = new Dictionary<int, Employee>()
        {
            { 1, new Employee { Id = 1, Name = "Michael", Lastname = "De La Rosa", Idcard = "00100000001", Department = listdepartments[0], Position = listpositions[0] } },
            { 2, new Employee { Id = 2, Name = "Carlos", Lastname = "Martinez", Idcard = "00100000002", Department = listdepartments[0], Position = listpositions[5] } },
            { 3, new Employee { Id = 3, Name = "Maria", Lastname = "Rodriguez", Idcard = "00100000003", Department = listdepartments[1], Position = listpositions[1] } },
            { 4, new Employee { Id = 4, Name = "Jose", Lastname = "Perez", Idcard = "00100000004", Department = listdepartments[2], Position = listpositions[2] } },
            { 5, new Employee { Id = 5, Name = "Ana", Lastname = "Gomez", Idcard = "00100000005", Department = listdepartments[3], Position = listpositions[3] } },
            { 6, new Employee { Id = 6, Name = "Pedro", Lastname = "Ramirez", Idcard = "00100000006", Department = listdepartments[4], Position = listpositions[4] } },
            { 7, new Employee { Id = 7, Name = "Laura", Lastname = "Fernandez", Idcard = "00100000007", Department = listdepartments[0], Position = listpositions[0] } },
            { 8, new Employee { Id = 8, Name = "Luis", Lastname = "Hernandez", Idcard = "00100000008", Department = listdepartments[2], Position = listpositions[2] } },
            { 9, new Employee { Id = 9, Name = "Sofia", Lastname = "Castillo", Idcard = "00100000009", Department = listdepartments[1], Position = listpositions[1] } },
            { 10, new Employee { Id = 10, Name = "Daniel", Lastname = "Torres", Idcard = "00100000010", Department = listdepartments[3], Position = listpositions[3] } }
        };

        do
        {
            Console.WriteLine("--------Welcome to the Employee System----------");
            Console.WriteLine("============================");
            Console.WriteLine("Select An Option");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Employee List");
            Console.WriteLine("3. Search Employee");
            Console.WriteLine("4. Modify Employee");
            Console.WriteLine("5. Delete Employee");
            Console.WriteLine("6. List by Department");
            Console.WriteLine("7. Add Department");
            Console.WriteLine("8. Add Position");
            Console.WriteLine("9. Exit");
            Console.WriteLine("============================");

            opcion = (Console.ReadLine() ?? "").Trim();

            try
            {
                switch (opcion)
                {
                    case "1":
                        {
                            exit = "yes";

                            do
                            {
                                Console.Clear();
                                Console.WriteLine("--------Adding New Employee----------");

                                Employee newemployee = new Employee();

                                int employeeId;

                                while (true)
                                {
                                    Console.WriteLine("Please enter the employee's ID:");

                                    if (!int.TryParse(Console.ReadLine(), out employeeId) || employeeId <= 0)
                                    {
                                        Console.WriteLine("Invalid ID format.");
                                        continue;
                                    }

                                    if (employees.ContainsKey(employeeId))
                                    {
                                        Console.WriteLine("This ID already exists.");
                                        continue;
                                    }

                                    break;
                                }

                                newemployee.Id = employeeId;

                                Console.WriteLine("Please enter the employee's name:");
                                string name = (Console.ReadLine() ?? "").Trim();

                                while (name == "")
                                {
                                    Console.WriteLine("ERROR: Please enter a name:");
                                    name = (Console.ReadLine() ?? "").Trim();
                                }

                                newemployee.Name = name;

                                Console.WriteLine("Please enter the employee's last name:");
                                string lastname = (Console.ReadLine() ?? "").Trim();

                                while (lastname == "")
                                {
                                    Console.WriteLine("ERROR: Please enter the last name:");
                                    lastname = (Console.ReadLine() ?? "").Trim();
                                }

                                newemployee.Lastname = lastname;

                                while (true)
                                {
                                    Console.WriteLine("Please enter the employee's ID card (11 digits):");
                                    string idcard = (Console.ReadLine() ?? "").Trim();

                                    if (idcard.Length != 11 || !idcard.All(char.IsDigit))
                                    {
                                        Console.WriteLine("ERROR: The ID card must have exactly 11 digits.");
                                        continue;
                                    }

                                    if (employees.Values.Any(e => e.Idcard == idcard))
                                    {
                                        Console.WriteLine("This ID card already exists.");
                                        continue;
                                    }

                                    newemployee.Idcard = idcard;
                                    break;
                                }

                                Department? selectedDepartment = null;

                                while (selectedDepartment == null)
                                {
                                    Console.WriteLine("Select the department:");

                                    foreach (Department dep in listdepartments)
                                    {
                                        Console.WriteLine($"{dep.Id}. {dep.Name}");
                                    }

                                    if (int.TryParse(Console.ReadLine(), out int depId))
                                    {
                                        selectedDepartment = listdepartments.Find(d => d.Id == depId);
                                    }

                                    if (selectedDepartment == null)
                                    {
                                        Console.WriteLine("Invalid selection.");
                                    }
                                }

                                newemployee.Department = selectedDepartment;

                                Position? selectedPosition = null;

                                while (selectedPosition == null)
                                {
                                    Console.WriteLine("Select the position:");

                                    foreach (Position pos in listpositions)
                                    {
                                        Console.WriteLine($"{pos.Id}. {pos.Name}");
                                    }

                                    if (int.TryParse(Console.ReadLine(), out int posId))
                                    {
                                        selectedPosition = listpositions.Find(p => p.Id == posId);
                                    }

                                    if (selectedPosition == null)
                                    {
                                        Console.WriteLine("Invalid selection.");
                                    }
                                }

                                newemployee.Position = selectedPosition;

                                employees.Add(newemployee.Id, newemployee);

                                Console.WriteLine("Employee added successfully.");
                                Console.WriteLine("Would you like to continue? (yes/no)");
                                exit = (Console.ReadLine() ?? "").Trim().ToLower();

                            } while (exit == "yes" || exit == "y");

                            Console.Clear();
                            break;
                        }

                    case "2":
                        {
                            Console.Clear();
                            Console.WriteLine("--------Employee List----------");

                            if (employees.Count == 0)
                            {
                                Console.WriteLine("No employees registered yet.");
                            }
                            else
                            {
                                foreach (Employee emp in employees.Values.OrderBy(e => e.Id))
                                {
                                    Console.WriteLine(emp);
                                }
                            }

                            Console.WriteLine("Press ENTER to return to the menu...");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }

                    case "3":
                        {
                            exit = "no";

                            do
                            {
                                Console.Clear();
                                Console.WriteLine("--------Search Employee--------");
                                Console.WriteLine("1. Search by ID");
                                Console.WriteLine("2. Search by ID Card");
                                Console.WriteLine("3. Search by Name or Last Name");
                                Console.WriteLine("4. Search by Department");

                                string searchOpcion = (Console.ReadLine() ?? "").Trim();

                                if (searchOpcion == "1")
                                {
                                    Console.WriteLine("Enter the employee ID:");
                                    int searchId;

                                    while (!int.TryParse(Console.ReadLine(), out searchId) || searchId <= 0)
                                    {
                                        Console.WriteLine("Invalid ID format. Try again:");
                                    }

                                    if (employees.TryGetValue(searchId, out Employee? found))
                                    {
                                        Console.WriteLine("FOUND:");
                                        Console.WriteLine(found);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Employee Not Found.");
                                    }
                                }
                                else if (searchOpcion == "2")
                                {
                                    Console.WriteLine("Enter the ID card:");
                                    string searchIdCard = (Console.ReadLine() ?? "").Trim();

                                    while (searchIdCard == "")
                                    {
                                        Console.WriteLine("ID card cannot be empty. Try again:");
                                        searchIdCard = (Console.ReadLine() ?? "").Trim();
                                    }

                                    Employee? foundByCard = employees.Values.FirstOrDefault(e => e.Idcard == searchIdCard);

                                    if (foundByCard != null)
                                    {
                                        Console.WriteLine("FOUND:");
                                        Console.WriteLine(foundByCard);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Employee Not Found.");
                                    }
                                }
                                else if (searchOpcion == "3")
                                {
                                    Console.WriteLine("Enter the name or last name:");
                                    string searchName = (Console.ReadLine() ?? "").Trim();

                                    while (searchName == "")
                                    {
                                        Console.WriteLine("Name cannot be empty. Try again:");
                                        searchName = (Console.ReadLine() ?? "").Trim();
                                    }

                                    List<Employee> foundByName = employees.Values
                                        .Where(e => e.Name.Contains(searchName, StringComparison.OrdinalIgnoreCase)
                                                 || e.Lastname.Contains(searchName, StringComparison.OrdinalIgnoreCase))
                                        .OrderBy(e => e.Id)
                                        .ToList();

                                    if (foundByName.Count == 0)
                                    {
                                        Console.WriteLine("Employee Not Found.");
                                    }
                                    else
                                    {
                                        foreach (Employee emp in foundByName)
                                        {
                                            Console.WriteLine(emp);
                                        }
                                    }
                                }
                                else if (searchOpcion == "4")
                                {
                                    Department? searchDepartment = null;

                                    while (searchDepartment == null)
                                    {
                                        Console.WriteLine("Select the department:");

                                        foreach (Department dep in listdepartments)
                                        {
                                            Console.WriteLine($"{dep.Id}. {dep.Name}");
                                        }

                                        if (int.TryParse(Console.ReadLine(), out int searchDepId))
                                        {
                                            searchDepartment = listdepartments.Find(d => d.Id == searchDepId);
                                        }

                                        if (searchDepartment == null)
                                        {
                                            Console.WriteLine("Invalid selection.");
                                        }
                                    }

                                    List<Employee> foundByDepartment = employees.Values
                                        .Where(e => e.Department.Id == searchDepartment.Id)
                                        .OrderBy(e => e.Id)
                                        .ToList();

                                    if (foundByDepartment.Count == 0)
                                    {
                                        Console.WriteLine("No employees found.");
                                    }
                                    else
                                    {
                                        foreach (Employee emp in foundByDepartment)
                                        {
                                            Console.WriteLine(emp);
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Option.");
                                }

                                Console.WriteLine("Do you want to return to the main menu? (yes/no)");
                                exit = (Console.ReadLine() ?? "").Trim().ToLower();

                            } while (exit == "no" || exit == "n");

                            Console.Clear();
                            break;
                        }

                    case "4":
                        {
                            exit = "no";

                            do
                            {
                                Console.Clear();
                                Console.WriteLine("--------Modifying Employee----------");
                                Console.WriteLine("Please enter the employee ID to modify:");

                                if (int.TryParse(Console.ReadLine(), out int modifyId) && modifyId > 0)
                                {
                                    if (employees.TryGetValue(modifyId, out Employee? employeeToModify))
                                    {
                                        Console.WriteLine("============================");
                                        Console.WriteLine($"Current information for employee ID {modifyId}:");
                                        Console.WriteLine(employeeToModify);
                                        Console.WriteLine("============================");

                                        Console.WriteLine("Enter the new name (ENTER to keep current):");
                                        string newName = (Console.ReadLine() ?? "").Trim();

                                        if (newName != "")
                                        {
                                            employeeToModify.Name = newName;
                                        }

                                        Console.WriteLine("Enter the new last name (ENTER to keep current):");
                                        string newLastname = (Console.ReadLine() ?? "").Trim();

                                        if (newLastname != "")
                                        {
                                            employeeToModify.Lastname = newLastname;
                                        }

                                        while (true)
                                        {
                                            Console.WriteLine("Enter the new ID card, 11 digits (ENTER to keep current):");
                                            string newIdcard = (Console.ReadLine() ?? "").Trim();

                                            if (newIdcard == "")
                                            {
                                                break;
                                            }

                                            if (newIdcard.Length != 11 || !newIdcard.All(char.IsDigit))
                                            {
                                                Console.WriteLine("ERROR: The ID card must have exactly 11 digits.");
                                                continue;
                                            }

                                            if (employees.Values.Any(e => e.Idcard == newIdcard && e.Id != modifyId))
                                            {
                                                Console.WriteLine("This ID card already exists.");
                                                continue;
                                            }

                                            employeeToModify.Idcard = newIdcard;
                                            break;
                                        }

                                        while (true)
                                        {
                                            Console.WriteLine("Select the new department (ENTER to keep current):");

                                            foreach (Department dep in listdepartments)
                                            {
                                                Console.WriteLine($"{dep.Id}. {dep.Name}");
                                            }

                                            string depInput = (Console.ReadLine() ?? "").Trim();

                                            if (depInput == "")
                                            {
                                                break;
                                            }

                                            if (int.TryParse(depInput, out int newDepId))
                                            {
                                                Department? newDepartment = listdepartments.Find(d => d.Id == newDepId);

                                                if (newDepartment != null)
                                                {
                                                    employeeToModify.Department = newDepartment;
                                                    break;
                                                }
                                            }

                                            Console.WriteLine("Invalid selection.");
                                        }

                                        while (true)
                                        {
                                            Console.WriteLine("Select the new position (ENTER to keep current):");

                                            foreach (Position pos in listpositions)
                                            {
                                                Console.WriteLine($"{pos.Id}. {pos.Name}");
                                            }

                                            string posInput = (Console.ReadLine() ?? "").Trim();

                                            if (posInput == "")
                                            {
                                                break;
                                            }

                                            if (int.TryParse(posInput, out int newPosId))
                                            {
                                                Position? newPosition = listpositions.Find(p => p.Id == newPosId);

                                                if (newPosition != null)
                                                {
                                                    employeeToModify.Position = newPosition;
                                                    break;
                                                }
                                            }

                                            Console.WriteLine("Invalid selection.");
                                        }

                                        Console.WriteLine("Employee information updated successfully.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Employee not found.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid ID format.");
                                }

                                Console.WriteLine("Do you want to return to the main menu? (yes/no)");
                                exit = (Console.ReadLine() ?? "").Trim().ToLower();

                            } while (exit == "no" || exit == "n");

                            Console.Clear();
                            break;
                        }

                    case "5":
                        {
                            exit = "no";

                            do
                            {
                                Console.Clear();
                                Console.WriteLine("--------Deleting Employee----------");
                                Console.WriteLine("Please enter the employee ID to delete:");

                                if (int.TryParse(Console.ReadLine(), out int deleteId) && deleteId > 0)
                                {
                                    if (employees.TryGetValue(deleteId, out Employee? employeeToDelete))
                                    {
                                        Console.WriteLine("============================");
                                        Console.WriteLine($"Current information for employee ID {deleteId}:");
                                        Console.WriteLine(employeeToDelete);
                                        Console.WriteLine("============================");

                                        Console.WriteLine("Are you sure you want to delete this employee? (yes/no)");
                                        string confirm = (Console.ReadLine() ?? "").Trim().ToLower();

                                        if (confirm == "yes" || confirm == "y")
                                        {
                                            employees.Remove(deleteId);
                                            Console.WriteLine("Employee deleted successfully.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Deletion cancelled.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Employee not found.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid ID format.");
                                }

                                Console.WriteLine("Do you want to return to the main menu? (yes/no)");
                                exit = (Console.ReadLine() ?? "").Trim().ToLower();

                            } while (exit == "no" || exit == "n");

                            Console.Clear();
                            break;
                        }

                    case "6":
                        {
                            Console.Clear();
                            Console.WriteLine("--------List by Department----------");

                            foreach (Department dep in listdepartments)
                            {
                                List<Employee> inDepartment = employees.Values
                                    .Where(e => e.Department.Id == dep.Id)
                                    .OrderBy(e => e.Id)
                                    .ToList();

                                Console.WriteLine($"== {dep.Name} ({inDepartment.Count} employees) ==");

                                if (inDepartment.Count == 0)
                                {
                                    Console.WriteLine("No employees in this department.");
                                }
                                else
                                {
                                    foreach (Employee emp in inDepartment)
                                    {
                                        Console.WriteLine(emp);
                                    }
                                }

                                Console.WriteLine();
                            }

                            Console.WriteLine("Press ENTER to return to the menu...");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }

                    case "7":
                        {
                            Console.Clear();
                            Console.WriteLine("--------Add Department----------");
                            Console.WriteLine("Enter the department name:");

                            string departmentName = (Console.ReadLine() ?? "").Trim();

                            while (departmentName == "")
                            {
                                Console.WriteLine("Department name cannot be empty:");
                                departmentName = (Console.ReadLine() ?? "").Trim();
                            }

                            if (listdepartments.Exists(d => d.Name.Equals(departmentName, StringComparison.OrdinalIgnoreCase)))
                            {
                                Console.WriteLine("Department already exists.");
                            }
                            else
                            {
                                listdepartments.Add(new Department
                                {
                                    Id = listdepartments.Count == 0 ? 1 : listdepartments.Max(d => d.Id) + 1,
                                    Name = departmentName
                                });

                                Console.WriteLine("Department added successfully.");
                            }

                            Console.WriteLine("Press ENTER to return to the menu...");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }

                    case "8":
                        {
                            Console.Clear();
                            Console.WriteLine("--------Add Position----------");
                            Console.WriteLine("Enter the position name:");

                            string positionName = (Console.ReadLine() ?? "").Trim();

                            while (positionName == "")
                            {
                                Console.WriteLine("Position name cannot be empty:");
                                positionName = (Console.ReadLine() ?? "").Trim();
                            }

                            if (listpositions.Exists(p => p.Name.Equals(positionName, StringComparison.OrdinalIgnoreCase)))
                            {
                                Console.WriteLine("Position already exists.");
                            }
                            else
                            {
                                listpositions.Add(new Position
                                {
                                    Id = listpositions.Count == 0 ? 1 : listpositions.Max(p => p.Id) + 1,
                                    Name = positionName
                                });

                                Console.WriteLine("Position added successfully.");
                            }

                            Console.WriteLine("Press ENTER to return to the menu...");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }

                    case "9":
                        {
                            Console.WriteLine("Exiting the program...");
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Invalid option. Please try again.");
                            Console.WriteLine("Press ENTER to continue...");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                Console.WriteLine("Press ENTER to return to the menu...");
                Console.ReadLine();
                Console.Clear();
            }

        } while (opcion != "9");

        Console.WriteLine("Thank you for using the Employee System.");

        return 0;
    }
}

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Lastname { get; set; } = "";
    public string Idcard { get; set; } = "";
    public Department Department { get; set; } = new Department();
    public Position Position { get; set; } = new Position();

    public override string ToString()
    {
        return $"ID: {Id} | {Name} {Lastname} | ID Card: {Idcard} | Department: {Department.Name} | Position: {Position.Name}";
    }
}

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
}

public class Position
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
}







/*Name: Jhon Michael
 Matricula: 2025-1861*/


using System;
using System.Collections.Generic;

class Program
{
    static int Main(string[] args)
    {
        string opcion = "";

        Dictionary<int, string> departments = new Dictionary<int, string>()
        {
            { 1, "IT" },
            { 2, "Human Resources" },
            { 3, "Finance" },
            { 4, "Sales" }
        };

        Dictionary<int, string> positions = new Dictionary<int, string>()
        {
            { 1, "Developer" },
            { 2, "Manager" },
            { 3, "Accountant" },
            { 4, "Sales Representative" }
        };

        List<int> ids = new List<int> { 1, 2, 3, 4, 5 };
        List<string> names = new List<string> { "Michael", "Carlos", "Maria", "Jose", "Ana" };
        List<string> lastnames = new List<string> { "De La Rosa", "Martinez", "Rodriguez", "Perez", "Gomez" };
        List<string> idcards = new List<string> { "00108450001", "00112300002", "00140840003", "00145060004", "00104289005" };
        List<string> empDepartments = new List<string> { "IT", "IT", "Human Resources", "Finance", "Sales" };
        List<string> empPositions = new List<string> { "Developer", "Developer", "Manager", "Accountant", "Sales Representative" };

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
            Console.WriteLine("7. Exit");
            Console.WriteLine("============================");

            opcion = (Console.ReadLine() ?? "").Trim();

            try
            {
                switch (opcion)
                {
                    case "1":
                        {
                            Console.WriteLine("--------Adding New Employee----------");

                            int id;

                            while (true)
                            {
                                Console.WriteLine("Enter the ID:");

                                if (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
                                {
                                    Console.WriteLine("Invalid ID.");
                                    continue;
                                }

                                if (ids.Contains(id))
                                {
                                    Console.WriteLine("This ID already exists.");
                                    continue;
                                }

                                break;
                            }

                            Console.WriteLine("Enter the name:");
                            string name = (Console.ReadLine() ?? "").Trim();

                            while (name == "")
                            {
                                Console.WriteLine("ERROR: The name cannot be empty:");
                                name = (Console.ReadLine() ?? "").Trim();
                            }

                            Console.WriteLine("Enter the last name:");
                            string lastname = (Console.ReadLine() ?? "").Trim();

                            while (lastname == "")
                            {
                                Console.WriteLine("ERROR: The last name cannot be empty:");
                                lastname = (Console.ReadLine() ?? "").Trim();
                            }

                            string idcard;

                            while (true)
                            {
                                Console.WriteLine("Enter the ID card (11 digits):");
                                idcard = (Console.ReadLine() ?? "").Trim();

                                bool onlyDigits = true;

                                foreach (char c in idcard)
                                {
                                    if (!char.IsDigit(c))
                                    {
                                        onlyDigits = false;
                                    }
                                }

                                if (idcard.Length != 11 || !onlyDigits)
                                {
                                    Console.WriteLine("The ID card must have exactly 11 digits.");
                                    continue;
                                }

                                if (idcards.Contains(idcard))
                                {
                                    Console.WriteLine("This ID card already exists.");
                                    continue;
                                }

                                break;
                            }

                            string department;

                            while (true)
                            {
                                Console.WriteLine("Select the department:");

                                foreach (KeyValuePair<int, string> d in departments)
                                {
                                    Console.WriteLine($"{d.Key}. {d.Value}");
                                }

                                if (int.TryParse(Console.ReadLine(), out int depId) && departments.TryGetValue(depId, out string? depName))
                                {
                                    department = depName;
                                    break;
                                }

                                Console.WriteLine("Invalid selection.");
                            }

                            string position;

                            while (true)
                            {
                                Console.WriteLine("Select the position:");

                                foreach (KeyValuePair<int, string> p in positions)
                                {
                                    Console.WriteLine($"{p.Key}. {p.Value}");
                                }

                                if (int.TryParse(Console.ReadLine(), out int posId) && positions.TryGetValue(posId, out string? posName))
                                {
                                    position = posName;
                                    break;
                                }

                                Console.WriteLine("Invalid selection.");
                            }

                            ids.Add(id);
                            names.Add(name);
                            lastnames.Add(lastname);
                            idcards.Add(idcard);
                            empDepartments.Add(department);
                            empPositions.Add(position);

                            Console.WriteLine("Employee added successfully.");
                            break;
                        }

                    case "2":
                        {
                            Console.WriteLine("--------Employee List----------");

                            if (ids.Count == 0)
                            {
                                Console.WriteLine("No employees registered yet.");
                            }
                            else
                            {
                                for (int i = 0; i < ids.Count; i++)
                                {
                                    Console.WriteLine($"ID: {ids[i]} | {names[i]} {lastnames[i]} | ID Card: {idcards[i]} | Department: {empDepartments[i]} | Position: {empPositions[i]}");
                                }
                            }

                            break;
                        }

                    case "3":
                        {
                            Console.WriteLine("--------Search Employee--------");
                            Console.WriteLine("1. Search by ID");
                            Console.WriteLine("2. Search by ID Card");
                            Console.WriteLine("3. Search by Name or Last Name");
                            Console.WriteLine("4. Search by Department");

                            string searchOpcion = (Console.ReadLine() ?? "").Trim();
                            List<int> results = new List<int>();
                            bool validSearch = true;

                            if (searchOpcion == "1")
                            {
                                Console.WriteLine("Enter the ID:");

                                if (int.TryParse(Console.ReadLine(), out int searchId))
                                {
                                    int found = ids.IndexOf(searchId);

                                    if (found != -1)
                                    {
                                        results.Add(found);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid ID format.");
                                    validSearch = false;
                                }
                            }
                            else if (searchOpcion == "2")
                            {
                                Console.WriteLine("Enter the ID card:");
                                string searchIdCard = (Console.ReadLine() ?? "").Trim();

                                int found = idcards.IndexOf(searchIdCard);

                                if (found != -1)
                                {
                                    results.Add(found);
                                }
                            }
                            else if (searchOpcion == "3")
                            {
                                Console.WriteLine("Enter the name or last name:");
                                string searchName = (Console.ReadLine() ?? "").Trim();

                                if (searchName == "")
                                {
                                    Console.WriteLine("The text cannot be empty.");
                                    validSearch = false;
                                }
                                else
                                {
                                    for (int i = 0; i < ids.Count; i++)
                                    {
                                        if (names[i].Contains(searchName, StringComparison.OrdinalIgnoreCase) || lastnames[i].Contains(searchName, StringComparison.OrdinalIgnoreCase))
                                        {
                                            results.Add(i);
                                        }
                                    }
                                }
                            }
                            else if (searchOpcion == "4")
                            {
                                Console.WriteLine("Select the department:");

                                foreach (KeyValuePair<int, string> d in departments)
                                {
                                    Console.WriteLine($"{d.Key}. {d.Value}");
                                }

                                if (int.TryParse(Console.ReadLine(), out int searchDepId) && departments.TryGetValue(searchDepId, out string? searchDepName))
                                {
                                    for (int i = 0; i < ids.Count; i++)
                                    {
                                        if (empDepartments[i] == searchDepName)
                                        {
                                            results.Add(i);
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid selection.");
                                    validSearch = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid option.");
                                validSearch = false;
                            }

                            if (validSearch)
                            {
                                if (results.Count == 0)
                                {
                                    Console.WriteLine("No employees found.");
                                }
                                else
                                {
                                    foreach (int r in results)
                                    {
                                        Console.WriteLine($"ID: {ids[r]} | {names[r]} {lastnames[r]} | ID Card: {idcards[r]} | Department: {empDepartments[r]} | Position: {empPositions[r]}");
                                    }
                                }
                            }

                            break;
                        }

                    case "4":
                        {
                            Console.WriteLine("--------Modifying Employee----------");
                            Console.WriteLine("Enter the employee ID to modify:");

                            if (int.TryParse(Console.ReadLine(), out int modifyId))
                            {
                                int index = ids.IndexOf(modifyId);

                                if (index != -1)
                                {
                                    Console.WriteLine("Current information:");
                                    Console.WriteLine($"ID: {ids[index]} | {names[index]} {lastnames[index]} | ID Card: {idcards[index]} | Department: {empDepartments[index]} | Position: {empPositions[index]}");

                                    Console.WriteLine("Enter the new name (ENTER to keep current):");
                                    string newName = (Console.ReadLine() ?? "").Trim();

                                    if (newName != "")
                                    {
                                        names[index] = newName;
                                    }

                                    Console.WriteLine("Enter the new last name (ENTER to keep current):");
                                    string newLastname = (Console.ReadLine() ?? "").Trim();

                                    if (newLastname != "")
                                    {
                                        lastnames[index] = newLastname;
                                    }

                                    while (true)
                                    {
                                        Console.WriteLine("Enter the new ID card, 11 digits (ENTER to keep current):");
                                        string newIdcard = (Console.ReadLine() ?? "").Trim();

                                        if (newIdcard == "")
                                        {
                                            break;
                                        }

                                        bool onlyDigits = true;

                                        foreach (char c in newIdcard)
                                        {
                                            if (!char.IsDigit(c))
                                            {
                                                onlyDigits = false;
                                            }
                                        }

                                        if (newIdcard.Length != 11 || !onlyDigits)
                                        {
                                            Console.WriteLine("The ID card must have exactly 11 digits.");
                                            continue;
                                        }

                                        int existing = idcards.IndexOf(newIdcard);

                                        if (existing != -1 && existing != index)
                                        {
                                            Console.WriteLine("This ID card already exists.");
                                            continue;
                                        }

                                        idcards[index] = newIdcard;
                                        break;
                                    }

                                    while (true)
                                    {
                                        Console.WriteLine("Select the new department (ENTER to keep current):");

                                        foreach (KeyValuePair<int, string> d in departments)
                                        {
                                            Console.WriteLine($"{d.Key}. {d.Value}");
                                        }

                                        string depInput = (Console.ReadLine() ?? "").Trim();

                                        if (depInput == "")
                                        {
                                            break;
                                        }

                                        if (int.TryParse(depInput, out int newDepId) && departments.TryGetValue(newDepId, out string? newDepName))
                                        {
                                            empDepartments[index] = newDepName;
                                            break;
                                        }

                                        Console.WriteLine("Invalid selection.");
                                    }

                                    while (true)
                                    {
                                        Console.WriteLine("Select the new position (ENTER to keep current):");

                                        foreach (KeyValuePair<int, string> p in positions)
                                        {
                                            Console.WriteLine($"{p.Key}. {p.Value}");
                                        }

                                        string posInput = (Console.ReadLine() ?? "").Trim();

                                        if (posInput == "")
                                        {
                                            break;
                                        }

                                        if (int.TryParse(posInput, out int newPosId) && positions.TryGetValue(newPosId, out string? newPosName))
                                        {
                                            empPositions[index] = newPosName;
                                            break;
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

                            break;
                        }

                    case "5":
                        {
                            Console.WriteLine("--------Deleting Employee----------");
                            Console.WriteLine("Enter the employee ID to delete:");

                            if (int.TryParse(Console.ReadLine(), out int deleteId))
                            {
                                int index = ids.IndexOf(deleteId);

                                if (index != -1)
                                {
                                    Console.WriteLine($"ID: {ids[index]} | {names[index]} {lastnames[index]} | ID Card: {idcards[index]} | Department: {empDepartments[index]} | Position: {empPositions[index]}");
                                    Console.WriteLine("Are you sure you want to delete this employee? (yes/no)");
                                    string confirm = (Console.ReadLine() ?? "").Trim().ToLower();

                                    if (confirm == "yes" || confirm == "y")
                                    {
                                        ids.RemoveAt(index);
                                        names.RemoveAt(index);
                                        lastnames.RemoveAt(index);
                                        idcards.RemoveAt(index);
                                        empDepartments.RemoveAt(index);
                                        empPositions.RemoveAt(index);

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

                            break;
                        }

                    case "6":
                        {
                            Console.WriteLine("--------List by Department----------");

                            foreach (KeyValuePair<int, string> d in departments)
                            {
                                Console.WriteLine($"== {d.Value} ==");
                                int count = 0;

                                for (int i = 0; i < ids.Count; i++)
                                {
                                    if (empDepartments[i] == d.Value)
                                    {
                                        Console.WriteLine($"ID: {ids[i]} | {names[i]} {lastnames[i]} | ID Card: {idcards[i]} | Position: {empPositions[i]}");
                                        count++;
                                    }
                                }

                                if (count == 0)
                                {
                                    Console.WriteLine("No employees in this department.");
                                }

                                Console.WriteLine();
                            }

                            break;
                        }

                    case "7":
                        {
                            Console.WriteLine("Exiting the program...");
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }

            if (opcion != "7")
            {
                Console.WriteLine("Press ENTER to return to the menu...");
                Console.ReadLine();
                Console.Clear();
            }

        } while (opcion != "7");

        Console.WriteLine("Thank you for using the Employee System.");

        return 0;
    }
}




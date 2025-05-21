class Program
{
  static void Main()
  {
    List<Staff> staffList = new();
    int command;
    Console.WriteLine(@"
╔═══════════════════════════════════════════════╗
║                 Welcome to                    ║
║    ***  TONY'S FOOD 'N STUFF EMPORIUM  ***    ║
║            We got food 'n stuff!              ║
╚═══════════════════════════════════════════════╝
");
      Console.WriteLine("Staff system 2000");
    do
    {
      Console.WriteLine();
      Console.WriteLine("What would you like to do?");
      Console.WriteLine("1. Add a Staff member");
      Console.WriteLine("2. Print staff registry");
      Console.WriteLine("3. Change salary");
      Console.WriteLine("4. Remove staff member");
      Console.WriteLine("5. Exit program");
      Console.Write("Enter command (1-5): ");
      string? input = Console.ReadLine();
      if (!int.TryParse(input, out command) || command < 1 || command > 5)
      {
        Console.WriteLine();
        Console.WriteLine("Invalid command, try again.");
        continue;
      }
      
      switch (command)
      {
        case 1:
          Console.Write("Enter staff name: ");
          string name = Console.ReadLine();
          Console.Write("Enter salary: ");
          int salary = int.Parse(Console.ReadLine());
          staffList.Add(new Staff(name, salary));
          Console.WriteLine();
          Console.WriteLine($"{name} has been added to the staff list!");
          break;
        case 2:
          Console.WriteLine();
          if (staffList.Count == 0) Console.WriteLine("You have no staff. Add staff members to print registry.");
          foreach (Staff staff in staffList)
          {
            Console.WriteLine($"{staff.Name} {staff.Salary}");
          }
          break;
        case 3:
        {
          Console.Write("Enter staff name: ");
          var editStaff = Console.ReadLine();
          var staffToEdit = staffList.Find(staff => staff.Name.Equals(editStaff, StringComparison.OrdinalIgnoreCase));
          if (staffToEdit == null)
          {
            Console.WriteLine();
            Console.WriteLine("No such staff");
            break;
          }
          Console.WriteLine();
          Console.WriteLine($"Current salary for {staffToEdit.Name} is {staffToEdit.Salary}");
          Console.Write("Enter new salary: ");
          int.TryParse(Console.ReadLine(), out int newSalary);
          staffToEdit.Salary = newSalary;
          Console.WriteLine();
          Console.WriteLine("Salary updated!");
          break;
        }case 4:
        {
          Console.Write("Enter staff name: ");
          var removeStaff = Console.ReadLine();
          var staffToRemove = staffList.Find(staff => staff.Name.Equals(removeStaff, StringComparison.OrdinalIgnoreCase));
          if (staffToRemove == null)
          {
            Console.WriteLine();
            Console.WriteLine("No such staff");
            break;
          }
          staffList.Remove(staffToRemove);
          Console.WriteLine();
          Console.WriteLine($"{staffToRemove.Name} has been removed");
          break;
        }
        case 5:
          Console.WriteLine("Exiting program...");
          break;
      }
    } while (command != 5);
    
  }
}

class Staff
{
  public string Name { get; }
  public int Salary { get; set; }

  public Staff(string name, int salary)
  {
    Name = name;
    Salary = salary;
  }
}


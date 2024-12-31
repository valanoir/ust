namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the name of the Bank: ");
            string bankName = Console.ReadLine();

            const int maxLockers = 100;
            int[] lockerNumbers = new int[maxLockers];
            string[] lockTypes = new string[maxLockers];
            string[] passwords = new string[maxLockers];
            double[] amounts = new double[maxLockers];
            string[] lastOpenedDates = new string[maxLockers];
            int lockerCount = 0;

            while (true)
            {
                Console.WriteLine("\n1.Add Locker");
                Console.WriteLine("2.Delete Locker");
                Console.WriteLine("3.Display Lockers");
                Console.WriteLine("4.Exit");
                Console.Write("Enter your choice: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a valid number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        if (lockerCount >= maxLockers)
                        {
                            Console.WriteLine("Maximum number of lockers reached. Cannot add more.");
                            break;
                        }

                        Console.Write("Enter locker details (Number,LockType,Password,Amount,LastOpened): ");
                        string[] input = Console.ReadLine()?.Split(',');
                        if (input == null || input.Length != 5)
                        {
                            Console.WriteLine("Invalid input format. Please try again.");
                            break;
                        }

                        try
                        {
                            lockerNumbers[lockerCount] = int.Parse(input[0]);
                            lockTypes[lockerCount] = input[1];
                            passwords[lockerCount] = input[2];
                            amounts[lockerCount] = double.Parse(input[3]);
                            lastOpenedDates[lockerCount] = input[4];
                            lockerCount++;
                            Console.WriteLine("Locker successfully added.");
                        }
                        catch
                        {
                            Console.WriteLine("Error parsing locker details. Please ensure correct format.");
                        }
                        break;

                    case 2:
                        Console.Write("Enter the locker number to be deleted: ");
                        int lockerToDelete;
                        if (!int.TryParse(Console.ReadLine(), out lockerToDelete))
                        {
                            Console.WriteLine("Invalid locker number. Please try again.");
                            break;
                        }

                        int indexToDelete = -1;
                        for (int i = 0; i < lockerCount; i++)
                        {
                            if (lockerNumbers[i] == lockerToDelete)
                            {
                                indexToDelete = i;
                                break;
                            }
                        }

                        if (indexToDelete != -1)
                        {
                            for (int i = indexToDelete; i < lockerCount - 1; i++)
                            {
                                lockerNumbers[i] = lockerNumbers[i + 1];
                                lockTypes[i] = lockTypes[i + 1];
                                passwords[i] = passwords[i + 1];
                                amounts[i] = amounts[i + 1];
                                lastOpenedDates[i] = lastOpenedDates[i + 1];
                            }
                            lockerCount--;
                            Console.WriteLine("Locker successfully deleted.");
                        }
                        else
                        {
                            Console.WriteLine("Locker not found in bank.");
                        }
                        break;

                    case 3:
                        if (lockerCount == 0)
                        {
                            Console.WriteLine("No lockers to show.");
                        }
                        else
                        {
                            Console.WriteLine($"\nLockers in {bankName}");
                            Console.WriteLine("Number Lock Type Password Amount Last Opened");
                            for (int i = 0; i < lockerCount; i++)
                            {
                                Console.WriteLine($"{lockerNumbers[i]} {lockTypes[i]} {passwords[i]} {amounts[i]} {lastOpenedDates[i]}");
                            }
                        }
                        break;

                    case 4:
                        Console.WriteLine("Exiting... Thank you!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }
    }
}

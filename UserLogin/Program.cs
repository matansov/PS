using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    internal class Program
    {
        public delegate void ActionOnError(string errorMsg);

        public static void ErrorMsg(string error)
        {
            Console.WriteLine("!!! " + error + " !!!");
        }
        
        public static void AdminMenu()
        {
            Console.WriteLine("0: Exit");
            Console.WriteLine("1: Change role of user");
            Console.WriteLine("2: Change active date of user");
            Console.WriteLine("3: User list");
            Console.WriteLine("4: Check log activity");
            Console.WriteLine("5: Check current activity");
            string tempUser;
            while(true)
            {
                Console.Write("Choose option:");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        return;
                    case 1:
                        Console.Write("Enter user to change role of: ");
                        tempUser = Console.ReadLine();

                        Console.Write("Enter role to assign: ");
                        int tempRole = Convert.ToInt32(Console.ReadLine());

                        UserData.AssignUserRole(tempUser, (UserRoles)tempRole);
                        break;
                    case 2:
                        Console.Write("Enter user to change active date of: ");
                        tempUser = Console.ReadLine();

                        Console.Write("Enter date to change to: ");
                        DateTime tempDate = Convert.ToDateTime(Console.ReadLine());

                        UserData.SetUserActiveTo(tempUser, tempDate);
                        break;
                    case 3:
                        break;
                    case 4:
                        IEnumerable<string> logActs = Logger.GetLogActivities();

                        StringBuilder inputStream = new StringBuilder();
                        foreach (string activity in logActs)
                        {
                            inputStream.Append(activity + Environment.NewLine);
                        }                                                                            //inputStream.Append(reader.ReadLine());
                        Console.WriteLine(inputStream.ToString());
                        break;
                    case 5:
                        Console.Write("Enter filter: ");
                        string filter = Console.ReadLine();
                        StringBuilder sb = new StringBuilder();
                        IEnumerable<string> currentActs = Logger.GetCurrentSessionActivities(filter);
                        foreach (string activity in currentActs)
                        {
                            sb.Append(activity + Environment.NewLine);
                        }
                        Console.WriteLine(sb.ToString());
                        break;
                    default:
                        Console.Write("Invalid input");
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            User user = new User();
            Console.Write("Enter username: ");
            user.username = Console.ReadLine();
            Console.Write("Enter password: ");
            user.password = Console.ReadLine();

            LoginValidation login = new LoginValidation(user.username, user.password, ErrorMsg);
            List<User> test = UserData.TestUsers;

            if (login.ValidateUserInput(ref user))
            {
                Console.WriteLine(user.username);
                Console.WriteLine(user.password);
                Console.WriteLine(user.facultyNumber);
                Console.WriteLine(user.userRole);
                switch (user.userRole)
                {
                    case 0:
                        Console.WriteLine("Your role is: " + LoginValidation.currentUserRole);
                        break;
                    case 1:
                        Console.WriteLine("Your role is: " + LoginValidation.currentUserRole);
                        AdminMenu();
                        break;
                    case 2:
                        Console.WriteLine("Your role is: " + LoginValidation.currentUserRole);
                        break;
                    case 3:
                        Console.WriteLine("Your role is: " + LoginValidation.currentUserRole);
                        break;
                    case 4:
                        Console.WriteLine("Your role is: " + LoginValidation.currentUserRole);
                        break;
                }
            }
        }
    }
}

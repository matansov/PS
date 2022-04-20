using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static public class UserData
    {
        static private List<User> _testUsers;

        static public List<User> TestUsers
        {
            get 
            {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }
        static private void ResetTestUserData()
        {
            if (_testUsers == null)
            {
                _testUsers = new List<User>(3);
                _testUsers.Add(new User());
                _testUsers[0].username = "Admin";
                _testUsers[0].password = "Admin";
                _testUsers[0].facultyNumber = "80081";
                _testUsers[0].userRole = 1;
                _testUsers[0].created = DateTime.Now;
                _testUsers[0].validTime = DateTime.MaxValue;

                _testUsers.Add(new User());
                _testUsers[1].username = "Petur";
                _testUsers[1].password = "kappa72";
                _testUsers[1].facultyNumber = "7282912";
                _testUsers[1].userRole = 4;
                _testUsers[1].created = DateTime.Now;
                _testUsers[1].validTime = DateTime.MaxValue;

                _testUsers.Add(new User());
                _testUsers[2].username = "Stoqn";
                _testUsers[2].password = "Dimitrov56";
                _testUsers[2].facultyNumber = "920426";
                _testUsers[2].userRole = 4;
                _testUsers[2].created = DateTime.Now;
                _testUsers[2].validTime = DateTime.MaxValue;
            }
        }

        static public User IsUserPassCorrect(string user, string pass)
        {
            User login = (from u in _testUsers where u.username == user && u.password == pass select u).First();

            if (login != null)
            {
                return login;
            }
            return null;
        }

        static public void SetUserActiveTo(string user, DateTime date)
        {
            foreach (User u in _testUsers)
            {
                if (u.username == user)
                {
                    u.validTime = date;
                    Logger.LogActivity("Active date changed of user: " + user);
                }
            }
        }

        static public void AssignUserRole(string user, UserRoles role)
        {
            foreach (User u in _testUsers)
            {
                if (u.username == user)
                {
                    u.userRole = Convert.ToInt32(role);
                    Logger.LogActivity("Role changed of user: " + user);
                }
            }
        }
    }
}

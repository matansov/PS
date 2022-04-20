using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static public class Logger
    {
        static private List<string>  currentSessionActivities = new List<string>();

        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";"
                + LoginValidation._userName + ";"
                + LoginValidation.currentUserRole + ";"
                + activity;
            currentSessionActivities.Add(activityLine);

            if (File.Exists("logger.txt") == true)
            {
                File.AppendAllText("logger.txt", activityLine);
            } else
            {
                File.WriteAllText("logger.txt", activityLine);
            }
        }

        static public IEnumerable<string> GetCurrentSessionActivities(string filter)
        {
            List<string> filteredActivities = (from activity in currentSessionActivities where activity.Contains(filter) select activity).ToList();

            return filteredActivities;
        }

        static public IEnumerable<string> GetLogActivities()
        {
            StreamReader reader = new StreamReader("logger.txt");
            List<string> activityLine = new List<string>();
            activityLine.Add(reader.ReadLine());
            return activityLine;
        }
    }
}

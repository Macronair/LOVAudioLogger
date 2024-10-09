using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MarcosIcecastRecorder
{
    internal class Values
    {
        public static string GetFileName()
        {
            string input = Config.FileName;

            string output = input
                .Replace("%d", DateTime.Now.ToString("dd"))
                .Replace("%m", DateTime.Now.ToString("MM"))
                .Replace("%y", DateTime.Now.ToString("yyyy"))
                .Replace("%H", DateTime.Now.ToString("HH"))
                .Replace("%M", DateTime.Now.ToString("mm"))
                .Replace("%S", DateTime.Now.ToString("ss"));

            return output;
        }

        public static string GetRecordPath(int recordmode)
        {
            string config_folder;
            if(Config.filePath == "*")
            {
                config_folder = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
            else
            {
                config_folder = Config.LoggerLocation;
            }
            string date_folder = DateTime.Now.ToString("yyyy-MM-dd (dddd)");
            string program_folder = GetCurrentProgram();

            if (config_folder.EndsWith(@"\") == true ) { config_folder.TrimEnd('\\'); }
            config_folder.Replace(@"\\", @"\");

            string output_folder = "";

            if (recordmode == 0)    // No structure
            {
                output_folder = $@"{config_folder}";
            }
            else if (recordmode == 1)   // By day
            {
                output_folder = $@"{config_folder}\{date_folder}";
            }
            else if (recordmode == 2)   // By program
            {
                output_folder = $@"{config_folder}\{program_folder}";
            }
            else if (recordmode == 3)   // By program + day
            {
                output_folder = $@"{config_folder}\{program_folder}\{date_folder}";
            }   
            else if (recordmode == 4)   // By day + program
            {
                output_folder = $@"{config_folder}\{date_folder}\{program_folder}";
            }
            return output_folder;
        }

        public static string GetCurrentProgram()
        {
            int day = (int)DateTime.Now.DayOfWeek;
            int hour = (int)DateTime.Now.Hour;

            switch (day)
            {
                case 1: // Maandag
                    switch(hour)
                    {
                        case 0:
                            return ProgramSchedule.Monday12PM;
                        case 1:
                            return ProgramSchedule.Monday1AM;
                        case 2:
                            return ProgramSchedule.Monday2AM;
                        case 3:
                            return ProgramSchedule.Monday3AM;
                        case 4:
                            return ProgramSchedule.Monday4AM;
                        case 5:
                            return ProgramSchedule.Monday5AM;
                        case 6:
                            return ProgramSchedule.Monday6AM;
                        case 7:
                            return ProgramSchedule.Monday7AM;
                        case 8:
                            return ProgramSchedule.Monday8AM;
                        case 9:
                            return ProgramSchedule.Monday9AM;
                        case 10:
                            return ProgramSchedule.Monday10AM;
                        case 11:
                            return ProgramSchedule.Monday11AM;
                        case 12:
                            return ProgramSchedule.Monday12AM;
                        case 13:
                            return ProgramSchedule.Monday1PM;
                        case 14:
                            return ProgramSchedule.Monday2PM;
                        case 15:
                            return ProgramSchedule.Monday3PM;
                        case 16:
                            return ProgramSchedule.Monday4PM;
                        case 17:
                            return ProgramSchedule.Monday5PM;
                        case 18:
                            return ProgramSchedule.Monday6PM;
                        case 19:
                            return ProgramSchedule.Monday7PM;
                        case 20:
                            return ProgramSchedule.Monday8PM;
                        case 21:
                            return ProgramSchedule.Monday9PM;
                        case 22:
                            return ProgramSchedule.Monday10PM;
                        case 23:
                            return ProgramSchedule.Monday11PM;
                    }
                    break;
                case 2: // Dinsdag
                    switch (hour)
                    {
                        case 0:
                            return ProgramSchedule.Tuesday12PM;
                        case 1:
                            return ProgramSchedule.Tuesday1AM;
                        case 2:
                            return ProgramSchedule.Tuesday2AM;
                        case 3:
                            return ProgramSchedule.Tuesday3AM;
                        case 4:
                            return ProgramSchedule.Tuesday4AM;
                        case 5:
                            return ProgramSchedule.Tuesday5AM;
                        case 6:
                            return ProgramSchedule.Tuesday6AM;
                        case 7:
                            return ProgramSchedule.Tuesday7AM;
                        case 8:
                            return ProgramSchedule.Tuesday8AM;
                        case 9:
                            return ProgramSchedule.Tuesday9AM;
                        case 10:
                            return ProgramSchedule.Tuesday10AM;
                        case 11:
                            return ProgramSchedule.Tuesday11AM;
                        case 12:
                            return ProgramSchedule.Tuesday12AM;
                        case 13:
                            return ProgramSchedule.Tuesday1PM;
                        case 14:
                            return ProgramSchedule.Tuesday2PM;
                        case 15:
                            return ProgramSchedule.Tuesday3PM;
                        case 16:
                            return ProgramSchedule.Tuesday4PM;
                        case 17:
                            return ProgramSchedule.Tuesday5PM;
                        case 18:
                            return ProgramSchedule.Tuesday6PM;
                        case 19:
                            return ProgramSchedule.Tuesday7PM;
                        case 20:
                            return ProgramSchedule.Tuesday8PM;
                        case 21:
                            return ProgramSchedule.Tuesday9PM;
                        case 22:
                            return ProgramSchedule.Tuesday10PM;
                        case 23:
                            return ProgramSchedule.Tuesday11PM;
                    }
                    break;
                case 3: // Woensdag
                    switch (hour)
                    {
                        case 0:
                            return ProgramSchedule.Wednesday12PM;
                        case 1:
                            return ProgramSchedule.Wednesday1AM;
                        case 2:
                            return ProgramSchedule.Wednesday2AM;
                        case 3:
                            return ProgramSchedule.Wednesday3AM;
                        case 4:
                            return ProgramSchedule.Wednesday4AM;
                        case 5:
                            return ProgramSchedule.Wednesday5AM;
                        case 6:
                            return ProgramSchedule.Wednesday6AM;
                        case 7:
                            return ProgramSchedule.Wednesday7AM;
                        case 8:
                            return ProgramSchedule.Wednesday8AM;
                        case 9:
                            return ProgramSchedule.Wednesday9AM;
                        case 10:
                            return ProgramSchedule.Wednesday10AM;
                        case 11:
                            return ProgramSchedule.Wednesday11AM;
                        case 12:
                            return ProgramSchedule.Wednesday12AM;
                        case 13:
                            return ProgramSchedule.Wednesday1PM;
                        case 14:
                            return ProgramSchedule.Wednesday2PM;
                        case 15:
                            return ProgramSchedule.Wednesday3PM;
                        case 16:
                            return ProgramSchedule.Wednesday4PM;
                        case 17:
                            return ProgramSchedule.Wednesday5PM;
                        case 18:
                            return ProgramSchedule.Wednesday6PM;
                        case 19:
                            return ProgramSchedule.Wednesday7PM;
                        case 20:
                            return ProgramSchedule.Wednesday8PM;
                        case 21:
                            return ProgramSchedule.Wednesday9PM;
                        case 22:
                            return ProgramSchedule.Wednesday10PM;
                        case 23:
                            return ProgramSchedule.Wednesday11PM;
                    }
                    break;
                case 4: // Donderdag
                    switch (hour)
                    {
                        case 0:
                            return ProgramSchedule.Thursday12PM;
                        case 1:
                            return ProgramSchedule.Thursday1AM;
                        case 2:
                            return ProgramSchedule.Thursday2AM;
                        case 3:
                            return ProgramSchedule.Thursday3AM;
                        case 4:
                            return ProgramSchedule.Thursday4AM;
                        case 5:
                            return ProgramSchedule.Thursday5AM;
                        case 6:
                            return ProgramSchedule.Thursday6AM;
                        case 7:
                            return ProgramSchedule.Thursday7AM;
                        case 8:
                            return ProgramSchedule.Thursday8AM;
                        case 9:
                            return ProgramSchedule.Thursday9AM;
                        case 10:
                            return ProgramSchedule.Thursday10AM;
                        case 11:
                            return ProgramSchedule.Thursday11AM;
                        case 12:
                            return ProgramSchedule.Thursday12AM;
                        case 13:
                            return ProgramSchedule.Thursday1PM;
                        case 14:
                            return ProgramSchedule.Thursday2PM;
                        case 15:
                            return ProgramSchedule.Thursday3PM;
                        case 16:
                            return ProgramSchedule.Thursday4PM;
                        case 17:
                            return ProgramSchedule.Thursday5PM;
                        case 18:
                            return ProgramSchedule.Thursday6PM;
                        case 19:
                            return ProgramSchedule.Thursday7PM;
                        case 20:
                            return ProgramSchedule.Thursday8PM;
                        case 21:
                            return ProgramSchedule.Thursday9PM;
                        case 22:
                            return ProgramSchedule.Thursday10PM;
                        case 23:
                            return ProgramSchedule.Thursday11PM;
                    }
                    break;
                case 5: // Vrijdag
                    switch (hour)
                    {
                        case 0:
                            return ProgramSchedule.Friday12PM;
                        case 1:
                            return ProgramSchedule.Friday1AM;
                        case 2:
                            return ProgramSchedule.Friday2AM;
                        case 3:
                            return ProgramSchedule.Friday3AM;
                        case 4:
                            return ProgramSchedule.Friday4AM;
                        case 5:
                            return ProgramSchedule.Friday5AM;
                        case 6:
                            return ProgramSchedule.Friday6AM;
                        case 7:
                            return ProgramSchedule.Friday7AM;
                        case 8:
                            return ProgramSchedule.Friday8AM;
                        case 9:
                            return ProgramSchedule.Friday9AM;
                        case 10:
                            return ProgramSchedule.Friday10AM;
                        case 11:
                            return ProgramSchedule.Friday11AM;
                        case 12:
                            return ProgramSchedule.Friday12AM;
                        case 13:
                            return ProgramSchedule.Friday1PM;
                        case 14:
                            return ProgramSchedule.Friday2PM;
                        case 15:
                            return ProgramSchedule.Friday3PM;
                        case 16:
                            return ProgramSchedule.Friday4PM;
                        case 17:
                            return ProgramSchedule.Friday5PM;
                        case 18:
                            return ProgramSchedule.Friday6PM;
                        case 19:
                            return ProgramSchedule.Friday7PM;
                        case 20:
                            return ProgramSchedule.Friday8PM;
                        case 21:
                            return ProgramSchedule.Friday9PM;
                        case 22:
                            return ProgramSchedule.Friday10PM;
                        case 23:
                            return ProgramSchedule.Friday11PM;
                    }
                    break;
                case 6: // Zaterdag
                    switch (hour)
                    {
                        case 0:
                            return ProgramSchedule.Saturday12PM;
                        case 1:
                            return ProgramSchedule.Saturday1AM;
                        case 2:
                            return ProgramSchedule.Saturday2AM;
                        case 3:
                            return ProgramSchedule.Saturday3AM;
                        case 4:
                            return ProgramSchedule.Saturday4AM;
                        case 5:
                            return ProgramSchedule.Saturday5AM;
                        case 6:
                            return ProgramSchedule.Saturday6AM;
                        case 7:
                            return ProgramSchedule.Saturday7AM;
                        case 8:
                            return ProgramSchedule.Saturday8AM;
                        case 9:
                            return ProgramSchedule.Saturday9AM;
                        case 10:
                            return ProgramSchedule.Saturday10AM;
                        case 11:
                            return ProgramSchedule.Saturday11AM;
                        case 12:
                            return ProgramSchedule.Saturday12AM;
                        case 13:
                            return ProgramSchedule.Saturday1PM;
                        case 14:
                            return ProgramSchedule.Saturday2PM;
                        case 15:
                            return ProgramSchedule.Saturday3PM;
                        case 16:
                            return ProgramSchedule.Saturday4PM;
                        case 17:
                            return ProgramSchedule.Saturday5PM;
                        case 18:
                            return ProgramSchedule.Saturday6PM;
                        case 19:
                            return ProgramSchedule.Saturday7PM;
                        case 20:
                            return ProgramSchedule.Saturday8PM;
                        case 21:
                            return ProgramSchedule.Saturday9PM;
                        case 22:
                            return ProgramSchedule.Saturday10PM;
                        case 23:
                            return ProgramSchedule.Saturday11PM;
                    }
                    break;
                case 0: // Zondag
                    switch (hour)
                    {
                        case 0:
                            return ProgramSchedule.Sunday12PM;
                        case 1:
                            return ProgramSchedule.Sunday1AM;
                        case 2:
                            return ProgramSchedule.Sunday2AM;
                        case 3:
                            return ProgramSchedule.Sunday3AM;
                        case 4:
                            return ProgramSchedule.Sunday4AM;
                        case 5:
                            return ProgramSchedule.Sunday5AM;
                        case 6:
                            return ProgramSchedule.Sunday6AM;
                        case 7:
                            return ProgramSchedule.Sunday7AM;
                        case 8:
                            return ProgramSchedule.Sunday8AM;
                        case 9:
                            return ProgramSchedule.Sunday9AM;
                        case 10:
                            return ProgramSchedule.Sunday10AM;
                        case 11:
                            return ProgramSchedule.Sunday11AM;
                        case 12:
                            return ProgramSchedule.Sunday12AM;
                        case 13:
                            return ProgramSchedule.Sunday1PM;
                        case 14:
                            return ProgramSchedule.Sunday2PM;
                        case 15:
                            return ProgramSchedule.Sunday3PM;
                        case 16:
                            return ProgramSchedule.Sunday4PM;
                        case 17:
                            return ProgramSchedule.Sunday5PM;
                        case 18:
                            return ProgramSchedule.Sunday6PM;
                        case 19:
                            return ProgramSchedule.Sunday7PM;
                        case 20:
                            return ProgramSchedule.Sunday8PM;
                        case 21:
                            return ProgramSchedule.Sunday9PM;
                        case 22:
                            return ProgramSchedule.Sunday10PM;
                        case 23:
                            return ProgramSchedule.Sunday11PM;
                    }
                    break;
                default:
                    return null;
            }
            return null;
        }
    }
}

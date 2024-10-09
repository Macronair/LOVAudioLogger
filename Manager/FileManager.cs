using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarcosIcecastRecorder
{
    public class Recording
    {
        public DateTime CreatedDate { get; set; }
        public string FileName { get; set; }
        public string ProgramName { get; set; }
        public DateTime RemovalDate { get; set; }
    }

    internal class FileManager
    {
        public static string logbuffer;
        public static bool enableLog = false;
        public static int bufferFlushCount = 0;
        public static int bufferFlushInterval = 2;
        public static int bufferEmptyContainers = 0;

        static DateTime currentDate;

        public static string l_filename;
        public static string l_folder;
        public static string l_prevfilename;
        public static string l_prevfolder;
        public static string l_prevprogram;

        public static void WriteAutoLogFile()
        {
            try
            {
                File.AppendAllText(Recorder.logFile, logbuffer);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when writing log file: " + ex.Message);
            }

            logbuffer = "";
            bufferFlushCount = 0;
        }

        public static void WriteLogFile(string data)
        {
            try
            {
                File.AppendAllText(Recorder.logFile, data);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when writing log file: " + ex.Message);
            }

            logbuffer = "";
            bufferFlushCount = 0;
        }

        public static void MoveAudioFile(object filename, object folder)
        {
            Console.WriteLine("Copying file(s) to: " + folder + "\\" +  filename);
            WriteLogFile("Copying file(s) to: " + folder + "\\" + filename);

            try
            {
                if (!Directory.Exists(folder.ToString()))
                {
                    Directory.CreateDirectory(folder.ToString());
                }

                string file = $@"{Config.tempPath}\{filename}";
                string moveto = $@"{folder}\{filename}";

                File.Move(file, moveto);
                WriteLogFile(Environment.NewLine + "File moved succesfully from temp to destination.");
                Console.WriteLine("File moved succesfully from temp to destination.");
            } catch (Exception ex)
            {
                WriteLogFile(Environment.NewLine + "Error when moving file to destination: " + ex.Message);
                Console.WriteLine("Error when moving file to destination: " + ex.Message);
            }
        }

        public static void UpdateJson()
        {
            //    // Voor bestaande records, update deze met een optelling in de CleanupCounter.
            // Lees het JSON-bestand en deserialiseer naar een lijst van Recording-objecten
            string jsonString = File.ReadAllText("records.json");
            try
            {
                List<Recording> records = JsonSerializer.Deserialize<List<Recording>>(jsonString);
                // Verhoog de CleanupCounter voor elke opname
                foreach (var record in records)
                {

                }

                // Serializeer de bijgewerkte lijst terug naar JSON
                string updatedJsonString = JsonSerializer.Serialize(records, new JsonSerializerOptions { WriteIndented = true });

                // Schrijf de JSON terug naar het bestand
                File.WriteAllText("records.json", updatedJsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when update to json: " + ex.Message);
            }

            DeleteOldRecordings();
        }

        public static void InsertToJson()
        {
            DateTime currentDate = DateTime.Now;
            DateTime removalDate = currentDate.AddDays(Config.DaysToKeep);

            string jsonString = File.ReadAllText("records.json");

            //    // Voor nieuwe records, voer deze code uit.
            List<Recording> records;
            if (jsonString == "")
            {
                records = new List<Recording>();
            }
            else
            {
                records = JsonSerializer.Deserialize<List<Recording>>(jsonString);
            }

            // Voeg nieuwe recording toe aan json string.
            records.Add(new Recording()
            {
                CreatedDate = currentDate,
                FileName = l_folder + "\\" + l_filename + ".mp3",
                ProgramName = Values.GetCurrentProgram(),
                RemovalDate = removalDate,
            });

            // Probeer het vervolgens goed weg te schrijven.
            try
            {
                var options = new JsonSerializerOptions() { WriteIndented = true };
                string insertedjsonstring = JsonSerializer.Serialize(records, options);
                File.WriteAllText("records.json", insertedjsonstring);
                WriteLogFile(Environment.NewLine + "RECORDS.JSON updated!");
                Console.WriteLine("RECORDS.JSON updated!");
            }
            catch (Exception ex)
            {
                WriteLogFile(Environment.NewLine + "Error when writing to json: " + ex.Message);
                Console.WriteLine("Error when writing to json: " + ex.Message);
            }
        }

        public static void DeleteOldRecordings()
        {
            Console.WriteLine("Searching for old recordings to cleanup...");
            int removedobjects = 0;

            string jsonString = File.ReadAllText("records.json");

            currentDate = DateTime.Now;

            List<Recording> records = JsonSerializer.Deserialize<List<Recording>>(jsonString);

            // Verhoog de CleanupCounter voor elke opname
            // Loop door de lijst van achter naar voren met een for-loop
            try
            {
                for (int i = records.Count - 1; i >= 0; i--)
                {
                    var record = records[i];

                    if (!File.Exists(record.FileName))
                    {
                        // Verwijder het record uit de lijst
                        records.RemoveAt(i); // RemoveAt verwijdert een element op een specifieke index

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"JSON entry removed because the file does not exist anymore: {record.FileName}");
                        WriteLogFile(Environment.NewLine + $"JSON entry removed because the file does not exist anymore: {record.FileName}");
                        removedobjects++;
                    }

                    if (currentDate >= record.RemovalDate)
                    {
                        // Verwijder het bestand van het bestandssysteem
                        File.Delete(record.FileName);

                        // Verwijder het record uit de lijst
                        records.RemoveAt(i); // RemoveAt verwijdert een element op een specifieke index

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Recording removed because it reached the removal date: {record.FileName}");
                        WriteLogFile(Environment.NewLine + $"Recording removed because it reached the removal date: {record.FileName}");
                        removedobjects++;
                    }
                }

                if (removedobjects > 0)
                {
                    var options = new JsonSerializerOptions() { WriteIndented = true };
                    string insertedjsonstring = JsonSerializer.Serialize(records, options);
                    File.WriteAllText("records.json", insertedjsonstring);
                    WriteLogFile(Environment.NewLine + "RECORDS.JSON updated!");
                    Console.WriteLine("RECORDS.JSON updated!");
                    removedobjects = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when writing to json file or modify files: " + ex.Message);
                WriteLogFile(Environment.NewLine + "Error when writing to json file or modify files: " + ex.Message);
            }

            bufferEmptyContainers++;
        }

        public static void DeleteEmptyDirectories(string directory)
        {
            if (bufferEmptyContainers >= 5)
            {
                try
                {
                    foreach (var dir in Directory.GetDirectories(directory))
                    {
                        Console.WriteLine($"Empty directory search in: {dir}");
                        WriteLogFile(Environment.NewLine + $"Empty directory search in: {dir}");

                        // Verwijder eerst lege submappen in de huidige map.
                        DeleteEmptyDirectories(dir);

                        // Controleer of de map leeg is.
                        if (Directory.GetFiles(dir).Length == 0 && Directory.GetDirectories(dir).Length == 0)
                        {
                            Console.WriteLine($"Found and removed empty folder: {dir}");
                            WriteLogFile(Environment.NewLine + $"Found and removed empty folder: {dir}");
                            Directory.Delete(dir);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error when deleting empty folders: " + ex.Message);
                    WriteLogFile(Environment.NewLine + "Error when deleting empty folders: " + ex.Message);
                }
                bufferEmptyContainers = 0;
            }
        }
    }
}

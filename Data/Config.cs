using System;
using System.Diagnostics;
using System.Security.Policy;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace MarcosIcecastRecorder
{

    public class AppSettings
    {
        public string Title { get; set; }

        public bool UsePhysicalDevice { get; set; }
        /// <summary>
        /// True = Use PhysicalDevice string
        /// False = Use StreamURL string
        /// </summary>

        public string StreamURL { get; set; }
        public string PhysicalDevice {  get; set; }

        public string LoggerLocation { get; set; }
        public string FileName { get; set; }
        public bool SyncToFullHour { get; set; }
        public bool UseTempFolder { get; set; }
        public int DaysToKeep { get; set; }

        public int RecDurationInSec { get; set; }
        
        public int RecordingMode { get; set; }
        /// <summary>
        /// Recording modes:
        /// 0. No Folder Structure
        /// 1. By Day
        /// 2. By Program
        /// 3. By Program + Day
        /// 4. By Day + Program
        /// </summary>
    }

    internal class Config
    {
        static public string Title;
        static public bool UsePhysicalDevice;

        static public string StreamURL;
        static public string PhysicalDevice;
        
        static public string LoggerLocation;
        static public string FileName;
        static public bool SyncToFullHour;
        static public bool UseTempFolder;
        static public int DaysToKeep;

        static public int RecDurationInSec;

        static public int RecordingMode;

        public static string filePath = "config.xml";
        public static string logPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Logs";
        public static string tempPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Temp";

        public static void SetDefaultConfig()
        {
            // Voorbeeldinstellingen
            var settings = new AppSettings
            {
                Title = "Icecast Recorder",

                UsePhysicalDevice = false,

                StreamURL = "https://www.yourstream.link/here.mp3",
                PhysicalDevice = "*",

                LoggerLocation = "*",
                FileName = "record",
                SyncToFullHour = true,
                UseTempFolder = true,
                DaysToKeep = 0,

                RecDurationInSec = 3600,

                RecordingMode = 0,
            };

            // Serializeer de instellingen naar XML en sla ze op in het bestand
            SerializeToXml(settings, filePath);

            Console.WriteLine("Config file is created. Please change settings.");

            GetConfig();
            
            Settings settings1 = new Settings();
            settings1.ShowDialog();
            Console.WriteLine("Finished. You need to restart this application.");
            Console.ReadKey();
            Environment.Exit(1);
        }

        public static void GetConfig()
        {
            // Roep de functie aan om instellingen uit het XML-bestand te lezen
            AppSettings settings = DeserializeFromXml(filePath);

            if (settings != null)
            {
                // Pas de gelezen instellingen toe op variabelen
                Config.Title = settings.Title;
                Config.UsePhysicalDevice = settings.UsePhysicalDevice;
                Config.StreamURL = settings.StreamURL;
                Config.PhysicalDevice = settings.PhysicalDevice;
                Config.LoggerLocation = settings.LoggerLocation;
                Config.FileName = settings.FileName;
                Config.SyncToFullHour = settings.SyncToFullHour;
                Config.UseTempFolder = settings.UseTempFolder;
                Config.DaysToKeep = settings.DaysToKeep;
                Config.RecDurationInSec = settings.RecDurationInSec;
                Config.RecordingMode = settings.RecordingMode;
            }
            else
            {
                SetDefaultConfig();
                Console.WriteLine("Config file cannot be loaded. New file generated");
                Console.ReadKey();
                Environment.Exit(2);
            }
        }

        public static AppSettings DeserializeFromXml(string filePath)
        {
            try
            {
                // Maak een XmlTextReader om het bestand te lezen
                using (XmlTextReader reader = new XmlTextReader(filePath))
                {
                    // Maak een XmlSerializer voor de AppSettings-klasse
                    XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));

                    // Deserialiseer de instellingen uit het bestand
                    AppSettings settings = (AppSettings)serializer.Deserialize(reader);

                    return settings;
                }
            }
            catch (Exception ex)
            {
                // Behandel fouten hier (bijv. bestand niet gevonden, ongeldige XML, etc.)
                Console.WriteLine("Error while reading config file: " + ex.Message);
                return null;
            }
        }

        public static void SerializeToXml(AppSettings settings, string filePath)
        {
            // Maak een XmlTextWriter om naar het bestand te schrijven
            using (var writer = new XmlTextWriter(filePath, null))
            {
                // Zorg voor nette opmaak van de XML
                writer.Formatting = Formatting.Indented;

                // Maak een XmlSerializer voor de AppSettings-klasse
                var serializer = new XmlSerializer(typeof(AppSettings));

                // Schrijf de instellingen naar het bestand
                serializer.Serialize(writer, settings);
            }
        }

    }
}

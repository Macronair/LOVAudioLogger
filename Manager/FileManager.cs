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
    // Alle velden die opgeslagen moeten worden in het gemaakte json bestand.
    public class Recording
    {
        public DateTime CreatedDate { get; set; }
        public string FileName { get; set; }
        public string ProgramName { get; set; }
        public DateTime RemovalDate { get; set; }    // Dit is de verloopdatum van een audiofile. Wanneer deze datum overschreden wordt, wordt de json entry en mp3 bestand automatisch verwijderd.
    }

    internal class FileManager
    {
        public static string logbuffer;    // Voor nu ingezet om het huidige logbestand niet constant bezet te houden. Om de zoveel seconden wordt deze geleegd in de log.
        public static bool enableLog = false;    // TODO: Nog goed implementeren in latere versies. Wordt nu nog niet gebruikt.
        public static int bufferFlushCount = 0;    // De optelklok naar de FlushInterval. Dit zorgt ervoor dat er niet constant naar het logbestand wordt geschreven.
        public static int bufferFlushInterval = 2;    // De treshold voor de FlushCount. Wanneer de FlushCount gelijk staat aan de FlushInterval, schrijf te buffer weg.
        public static int bufferEmptyContainers = 0;    // Deze integer wordt elke seconde verhoogd totdat de treshold bereikt wordt. Dan worden alle lege mappen verwijderd uit de destination folder.

        static DateTime currentDate;    // Sla de huidige tijd en datum op in deze variabel.

        public static string l_filename;    // Bestandsnaam waar nu in wordt opgenomen.
        public static string l_folder;    // De map waar het bestand nu in wordt gezet.
        public static string l_prevfilename;    // Bestandsnaam van de vorige opname. Goed voor het verwerken van andere acties nadat er een nieuwe opname is begonnen.
        public static string l_prevfolder;    // Maplocatie van de vorige opname. Hetzelfde verhaal als hierboven.
        public static string l_prevprogram;    // Naam van het programma wat werd gebruikt in de vorige opname.

        // Volgende method wordt automatisch aangeroepen om de logbuffer weg te schrijven.
        public static void WriteAutoLogFile()
        {
            try
            {
                File.AppendAllText(Recorder.logFile, logbuffer);    // Schrijf de buffer daadwerkerlijk naar het logbestand.
            }
            catch (Exception ex)    // Als bovenstaand niet goed gaat...
            {
                Console.WriteLine("Error when writing log file: " + ex.Message);
            }

            logbuffer = ""; // Leeg de logbuffer na het wegschrijven.
            bufferFlushCount = 0;    // Zet de counter weer op 0.
        }

        // Deze method kan met de hand aangeroepen worden als er iets buiten de buffer naar het logbestand geschreven moet worden.
        public static void WriteLogFile(string data)
        {
            try
            {
                File.AppendAllText(Recorder.logFile, data);    // Schrijf de opgegeven data daadwerkerlijk naar het logbestand.
            }
            catch (Exception ex)    // Wanneer bovenstaand mis gaat...
            {
                Console.WriteLine("Error when writing log file: " + ex.Message);
            }

            // Onderstaand stond eerder actief, maar is bij een handmatige actie niet nodig te resetten.
            //logbuffer = "";
            //bufferFlushCount = 0;
        }

        // Onderstaande method wordt alleen gebruikt bij het gebruik van de Temp map. Deze is in de instellingen aan of uit te zetten
        public static void MoveAudioFile(object filename, object folder)
        {
            // Uiteraard doen we dit netjes loggen in de console en logbestand.
            Console.WriteLine("Copying file(s) to: " + folder + "\\" +  filename);    // <-- Voor de console.
            WriteLogFile("Copying file(s) to: " + folder + "\\" + filename);    // <-- Voor het logbestand.

            // Het echte werk.
            try
            {
                // Check of de bestemmingsmap al bestaat.
                if (!Directory.Exists(folder.ToString()))    // Als deze nog niet bestaat,
                {
                    Directory.CreateDirectory(folder.ToString());    // Maak hem dan aan.
                }

                // Bepaal vervolgens welk bestand naar welke locatie verplaatst moet worden.
                string file = $@"{Config.tempPath}\{filename}";
                string moveto = $@"{folder}\{filename}";

                File.Move(file, moveto);    // Voer hier de daadwerkelijke verplaatsactie uit.
                WriteLogFile(Environment.NewLine + "File moved succesfully from temp to destination.");    // En log dit vervolgens in het logbestand (als het goed gaat tenminste)
                Console.WriteLine("File moved succesfully from temp to destination.");    // Schrijf het ondertussen ook in de console.
            } catch (Exception ex)    // Als er in bovenstaande code iets fout gaat, voer het onderstaande uit.
            {
                // Zet de foutmelding + reden in de console en log.
                WriteLogFile(Environment.NewLine + "Error when moving file to destination: " + ex.Message);
                Console.WriteLine("Error when moving file to destination: " + ex.Message);
            }
        }

        // Momenteel niet actief in gebruik, maar is in het script gelaten voor eventueel later gebruik.
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

        // Nieuwe opnames worden ook meteen in het json bestand gezet met de volgende method.
        public static void InsertToJson()
        {
            currentDate = DateTime.Now;    // Update de huidige tijd en datum.
            DateTime removalDate = currentDate.AddDays(Config.DaysToKeep);    // De huidige dag/tijd + de aantal dagen dat de opnames moeten worden bewaard maakt uiteindelijk de verloopdatum.

            string jsonString = File.ReadAllText("records.json");    // Lees alle bestaande data uit het json bestand.

            List<Recording> records;    // Initieer een nieuw List object.
            if (jsonString == "")    // Check of het bestand leeg is.
            {
                records = new List<Recording>();    // Maak dan een lege lijst aan.
            }
            else    // Als het bestand niet leeg is.
            {
                records = JsonSerializer.Deserialize<List<Recording>>(jsonString);    // Zet alle data uit het bestand in deze list.
            }

            // Voeg nieuwe recording toe aan json string.
            records.Add(new Recording()
            {
                // Onderstaande waardes komen overeen met de Recording class.
                CreatedDate = currentDate,
                FileName = l_folder + "\\" + l_filename + ".mp3",
                ProgramName = Values.GetCurrentProgram(),
                RemovalDate = removalDate,
            });

            // Probeer het vervolgens goed weg te schrijven.
            try
            {
                var options = new JsonSerializerOptions() { WriteIndented = true };    // Gebruik ook de goede formettering in het bestand. Anders staat alles zonder enters achter elkaar.
                string insertedjsonstring = JsonSerializer.Serialize(records, options);
                File.WriteAllText("records.json", insertedjsonstring);    // Hier wordt het bestand dan uiteindelijk weggeschreven en bijgewerkt.
                WriteLogFile(Environment.NewLine + "RECORDS.JSON updated!");    // Laat het weten via de console.
                Console.WriteLine("RECORDS.JSON updated!");    // En via het log bestand.
            }
            catch (Exception ex)    // Als er toch nog iets fout gaat, laat het de gebruiker weten via de log en console.
            {
                WriteLogFile(Environment.NewLine + "Error when writing to json: " + ex.Message);
                Console.WriteLine("Error when writing to json: " + ex.Message);
            }
        }

        // De method om oude opnames te scannen en te verwijderen.
        public static void DeleteOldRecordings()
        {
            Console.WriteLine("Searching for old recordings to cleanup...");
            int removedobjects = 0;    // In deze variabel wordt bijgehouden hoeveel bestanden er uiteindelijk zijn verwijderd. Bij elke trigger van deze method begint de counter weer op 0.

            string jsonString = File.ReadAllText("records.json");    // Lees het json bestand uit.

            currentDate = DateTime.Now;    // Verkrijg de huidige tijd/datum.

            List<Recording> records = JsonSerializer.Deserialize<List<Recording>>(jsonString);    // Zet alle verkregen data in een List.

            // Verhoog de CleanupCounter voor elke opname
            // Loop door de lijst van achter naar voren met een for-loop
            try
            {
                for (int i = records.Count - 1; i >= 0; i--)
                {
                    var record = records[i];

                    // Hier wordt nog gecontroleerd of het mp3 bestand niet al verwijderd is.
                    // Mocht deze inderdaad al verwijderd zijn, heeft het weinig zin om de json entry te bewaren omdat deze sowieso al geen bestanden meer verwijderd.
                    // Als het bestand toch bestaat, dan wordt dit stukje code helemaal overgeslagen.
                    if (!File.Exists(record.FileName))
                    {
                        // Verwijder het record uit de lijst
                        records.RemoveAt(i); // RemoveAt verwijdert een element op een specifieke index.

                        Console.ForegroundColor = ConsoleColor.Yellow;    // Even een ander kleurtje.
                        // En uiteraard... krijgt de gebruiker ook een melding.
                        Console.WriteLine($"JSON entry removed because the file does not exist anymore: {record.FileName}");
                        WriteLogFile(Environment.NewLine + $"JSON entry removed because the file does not exist anymore: {record.FileName}");
                        removedobjects++; // Tel de totaal verwijderde bestanden op met 1.
                    }

                    if (currentDate >= record.RemovalDate)
                    {
                        // Verwijder het bestand van het bestandssysteem.
                        File.Delete(record.FileName);

                        // Verwijder het record uit de lijst
                        records.RemoveAt(i); // RemoveAt verwijdert een element op een specifieke index

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        // Ook hier wordt de gebruiker geinformeerd.
                        Console.WriteLine($"Recording removed because it reached the removal date: {record.FileName}");
                        WriteLogFile(Environment.NewLine + $"Recording removed because it reached the removal date: {record.FileName}");
                        removedobjects++; // Tel de totaal verwijderde bestanden op met 1.
                    }
                }

                // Als er bestanden zijn verwijderd in dit proces, voer het volgende uit.
                if (removedobjects > 0)
                {
                    // Onderstaande code zorgt dat het json bestand wordt bijgewerkt met nieuwe informatie.
                    // Als er bij elke check niks wordt verwijderd, is het ook niet nodig om het bestand constant de updaten.
                    // Daarom wordt dit alleen uitgevoerd wanneer er daadwerkelijk verwijderacties zijn doorgevoerd.
                    var options = new JsonSerializerOptions() { WriteIndented = true };
                    string insertedjsonstring = JsonSerializer.Serialize(records, options);
                    File.WriteAllText("records.json", insertedjsonstring);
                    WriteLogFile(Environment.NewLine + "RECORDS.JSON updated!");
                    Console.WriteLine("RECORDS.JSON updated!");
                    removedobjects = 0;    // Reset tenslotte de counter weer op 0 voor de volgende keer.
                }
            }
            catch (Exception ex)    // Als failsafe in het geval dat er iets fout zou gaan, wordt onderstaand uitgevoerd. Enkel wat logacties op het moment.
            {
                Console.WriteLine("Error when writing to json file or modify files: " + ex.Message);
                WriteLogFile(Environment.NewLine + "Error when writing to json file or modify files: " + ex.Message);
            }

            bufferEmptyContainers++;
        }

        // Lege mappen worden met deze method uit het bestandssysteem gehaald. Dit zorgt voor wat extra overzicht.
        public static void DeleteEmptyDirectories(string directory)
        {
            // Wanneer de buffervariabel op 5 staat, wordt er gecontroleerd op lege mappen.
            // Dit hoeft niet perse heel vaak nagelopen te worden omdat er vrij weinig verandert en dit misschien een intensieve taak zou worden bij veel (lege) mappen.
            if (bufferEmptyContainers >= 5)
            {
                // Hier begint pas het echte werk.
                try
                {
                    // Er wordt in de opgegeven locatie in elke map gekeken of deze leeg is.
                    foreach (var dir in Directory.GetDirectories(directory))
                    {
                        Console.WriteLine($"Empty directory search in: {dir}");
                        WriteLogFile(Environment.NewLine + $"Empty directory search in: {dir}");

                        // Verwijder eerst lege submappen in de huidige map.
                        DeleteEmptyDirectories(dir);    // (Dit lijkt vrij risky, maar werkt vrij goed. Dus lekker laten staan)

                        // Controleer of de map leeg is.
                        if (Directory.GetFiles(dir).Length == 0 && Directory.GetDirectories(dir).Length == 0)
                        {
                            // Als deze daadwerkelijk leeg is, verwijder de map en laat het de gebruiker weten in de log en console.
                            Console.WriteLine($"Found and removed empty folder: {dir}");
                            WriteLogFile(Environment.NewLine + $"Found and removed empty folder: {dir}");
                            Directory.Delete(dir);
                        }
                    }
                }
                catch (Exception ex)    // Inmiddels is dit stukje code wel bekend. Je weet maar nooit of er iets fout gaat of niet.
                {
                    Console.WriteLine("Error when deleting empty folders: " + ex.Message);
                    WriteLogFile(Environment.NewLine + "Error when deleting empty folders: " + ex.Message);
                }
                bufferEmptyContainers = 0;    // Reset de buffer naar 0.
            }
        }
    }
}

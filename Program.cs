using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

/// <summary>
/// Marco's Icecast & Soundcard Recorder
/// Door: Marco Loenen
/// 
/// (NL)
/// Geschreven voor de lokale omroep in Venray: Omroep Venray.
/// Project gestart op 29 september 2023.
/// 
/// Deze applicatie is geschreven als een audiologger voor een radiosignaal zodat er een mogelijkheid is om vorige uitgezonden uren terug te luisteren
/// en te gebruiken door dj's, redactie en andere medewerkers binnen de omroep. Omdat het vorige systeem niet meer werkbaar was en er een alternatief
/// nodig was, is dit tot stand gekomen.
/// 
/// Mocht je dit lezen, heb je dit wellicht via GitHub gevonden en zijn deze project bestanden gecloned naar je eigen omgeving.
/// Pas de onderdelen aan wat nodig is, maar let uiteraard op om de scripts niet onbruikbaar te maken ;)
/// 
/// Bovendien, alle comments in de code zijn in het Nederlands!
/// 
/// Succes!
/// </summary>

namespace MarcosIcecastRecorder
{
    internal class Program
    {
        public static Thread recorder = new Thread(new ThreadStart(Recorder.SetRecordingMode));
        public static Thread time = new Thread(new ThreadStart(SyncTime));

        // Hier start de applicatie
        static void Main(string[] args)
        {
            frmSplash frmSplash = new frmSplash();
            frmSplash.ShowDialog();

            // Config.xml
            if (!File.Exists(Config.filePath))  // Mocht het bestand niet aanwezig zijn, genereer een nieuwe config.xml bestand.
            {
                Config.SetDefaultConfig();
            }
            else  // Lees anders het bestand uit en vul de variabelen in deze applicatie aan met de data uit het bestand.
            {
                Config.GetConfig();
            }

            // Programs.xml
            if (!File.Exists(ProgramSchedule.filePath))  // Mocht het bestand niet aanwezig zijn, genereer een nieuwe programs.xml bestand.
            {
                ProgramSchedule.SetDefaultSchedule();
            }
            else  // Lees anders het bestand uit en vul de variabelen in deze applicatie aan met de data uit het bestand.
            {
                ProgramSchedule.GetSchedule();
            }

            // Records.json
            if (!File.Exists("records.json"))  // Mocht het bestand niet aanwezig zijn, genereer een nieuwe programs.xml bestand.
            {
                System.IO.FileStream f = System.IO.File.Create("records.json");
                f.Close();
            }

            // Map: Logs
            if (!Directory.Exists(Config.logPath))   // Indien de map niet bestaat, maak deze aan.
            {
                Directory.CreateDirectory(Config.logPath);
            }

            // Map: Temp
            if(!Directory.Exists(Config.tempPath))  // Indien de map niet bestaat, maak deze aan.
            {
                Directory.CreateDirectory(Config.tempPath);
            }

            // Start de FFMPEG recorder thread. &
            // Start de tijd synchronisatie onderdeel om elk uur een nieuw bestand te maken.
            // Wordt tevens ook gebruikt om het complete bestand te verplaatsen naar de eindlocatie. Meer info bij de method.
            time.Start();
            recorder.Start();
            //TODO: Maak thread opnieuw wanneer de bestaande zonder gebruikers input is afgesloten.

            // Na het starten van de thread hierboven, blijft de applicatie in de onderstaande while loop hangen.
            // Wachtend op user input.
            while (true)
            {
                switch (Console.ReadKey().Key)  // Lees de ingedrukte toets uit.
                {
                    case ConsoleKey.End:        // END toets
                        FileManager.l_prevfolder = FileManager.l_folder ;
                        FileManager.l_prevfilename = FileManager.l_filename;
                        FileManager.l_prevprogram = Values.GetCurrentProgram();

                        recorder.Abort();   // Sluit de recorder thread
                        try {
                            // Detecteer alle openstaande ffmpeg.exe processen en sluit deze af.
                            Process proc = Process.GetProcessById(Recorder.procRec.Id);
                            if (!proc.HasExited) proc.Kill();
                            time.Abort();   // En stop de tijd synchronisatie script.
                        } catch {
                            // Als er geen ffmpeg processen open staan, zal dit gebied van de code uitgevoerd worden.
                            // Aangezien er geen output nodig is hiervoor, is dit stukje leeg.
                        }

                        if(Config.UseTempFolder == true)
                        {
                            // Vraag aan de gebruiker wat te doen met de overgebleven bestanden in de Temp map.
                            DialogResult savetodestination =
                            MessageBox.Show("Select an option for the remaining temporary files in the Temp folder." + Environment.NewLine +
                            "Yes = Move file to destination folder." + Environment.NewLine +
                            "No = Delete temp file(s).", "Closing action", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            //

                            // Als het antwoord 'JA' is...
                            if (savetodestination == DialogResult.Yes)
                            {
                                FileManager.MoveAudioFile(FileManager.l_filename + ".mp3", FileManager.l_folder);
                            }
                            // Als het antwoord 'NEE' is...
                            else if (savetodestination != DialogResult.No)
                            {
                                DirectoryInfo di = new DirectoryInfo(Config.tempPath); // Verzamel alle bestanden uit de Temp map

                                // Verwijder alles wat in deze map aanwezig is.
                                foreach (FileInfo file in di.GetFiles())
                                {
                                    file.Delete();  // <----- Dit spreekt boekdelen toch?
                                }
                            }
                            // Als de melding wordt weggeklikt.
                            else
                            {
                                // Hetzelfde wordt uitgevoerd wanneer er ook op NEE wordt geklikt.
                                DirectoryInfo di = new DirectoryInfo(Config.tempPath);

                                foreach (FileInfo file in di.GetFiles())
                                {
                                    file.Delete();
                                }
                            }
                        }
                        Thread.Sleep(20);
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.Home:   // HOME toets: Settings/Instellingen van de logger
                        // Start het instellingen venster naast de logger d.m.v. een nieuwe thread.
                        Thread settings = new Thread(new ThreadStart(OpenSettings));
                        settings.SetApartmentState(ApartmentState.STA);
                        settings.Start();
                        break;
                    case ConsoleKey.Delete: // DELETE toets: Verwijder alle output op het scherm.
                        Console.Clear();
                        break;
                    default:                // Bij alle andere toetsen: Geef alle mogelijke toetsen en hun bijbehorende functies aan.
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Hotkeys: [End] Exit logger | [Home] Settings | [Delete] Clear console");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }

                Thread.Sleep(10);
            }
        }

        // Deze void is gebruikt om de instellingen te laden.
        static void OpenSettings()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Settings()); // Open de nieuwe Form
        }

        // Een van de meest belangrijke onderdelen van de applicatie.
        // Hier draait de tijd synchronisatie script. Wat zorgt dat er automatisch elk uur een nieuw .mp3 bestand wordt gemaakt.
        static void SyncTime()
        {
            string currentTime; // Kleine voorbereiding.
            int waittime = 0;

            // Deze loop draait continu in de openstaande thread.
            while (true)
            {
                Thread.Sleep(1000);

                currentTime = DateTime.Now.ToString("mm:ss");   // Check de huidige tijd.

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Sync time: {currentTime} || New recording @ 00:10");    // Geef huidige tijd weer.

                if (currentTime == "00:01")     // Op deze minuut en seconde, voer het volgende uit.
                {

                }
                else if (currentTime == "00:10")
                {
                    Process[] proc = Process.GetProcessesByName("ffmpeg");  // Detecteer alle openstaande ffmpeg processen.
                    Recorder.RecordAgain = true;    // Zet deze naar true om een nieuwe ffmpeg opname te starten na onderstaande code.

                    if (proc != null)   // Wanneer er ffmpeg processen openstaan, sluit deze af en ruim het comsole scherm op.
                    {
                        Recorder.procRec.Kill();
                        Console.Clear();
                        Console.WriteLine("Syncing to full hour. Started new recording.");
                    }
                }
                else if (currentTime == "00:15")
                {
                    // Zet het audiobestand van het afgelopen uur over naar de permanente opslaglocatie.
                    if(Config.UseTempFolder == true)
                    {
                        Thread move = new Thread(() =>
                        {
                            FileManager.MoveAudioFile(FileManager.l_prevfilename + ".mp3", FileManager.l_prevfolder);
                        });
                        move.Start();
                    }
                }

                if(Config.DaysToKeep > 0)
                {
                    waittime++;
                    if (waittime == 5)
                    {
                        FileManager.DeleteOldRecordings();
                        FileManager.DeleteEmptyDirectories(Config.LoggerLocation);
                        waittime = 0;
                    }
                }

                // Logging naar txt
                FileManager.bufferFlushCount++; // Elke seconden, verhoog de buffercount
                if(FileManager.bufferFlushCount == FileManager.bufferFlushInterval) // Wanneer de buffercount limiet bereikt is.
                {
                    FileManager.WriteAutoLogFile(); // Sla de opgebouwde buffer op naar een text bestand.
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MarcosIcecastRecorder
{
    internal class Recorder
    {
        // Hoofdclass voor de daadwerkelijke opnames naar MP3.
        
        public static Process procRec;            // Het ffmpeg proces voor de opname
        static int pId;    	                      // Het ID van het lopende proces.
        public static bool RecordAgain = true;    // Deze staat meestal op true en laat het script opnieuw starten voor ee nieuwe opname. Wanneer deze op false staat, wordt de code maar 1x uitgevoerd.
        public static string recordTo;            // Het pad waar het audiobestand nu naar geschreven wordt.

        public static string logFile;             // Een buffer voor de logfile in de map van de applicatie.

        // In deze method wordt eerst bepaald welke opnamemodus er gebruikt dient te worden (Fysieke geluidskaart of URL) + de log instellingen.
        public static void SetRecordingMode()
        {
            // Zorg eerst dat de logbuffer leeg is.
            if (logFile != null)
            {
                FileManager.WriteAutoLogFile();    // Indien niet leeg, schrijf dit naar de huidige logfile.
            }

            // Vervolgens worden er nieuwe waardes ingeladen.
            logFile = Config.logPath + $@"\Log_{DateTime.Now.ToString("yyyy_MM_dd__HH_mm_ss")}.txt";    // De locatie van het nieuwe logbestand.
            FileManager.l_filename = Values.GetFileName();                                              // De nieuwe bestandsnaam voor de opname.
            FileManager.l_folder = Values.GetRecordPath(Config.RecordingMode);                          // De nieuwe bestandslocatie voor de opname.

            // Moet er eerst naar een tijdelijke map geschreven worden voordat de opname naar de eindlocatie gaat?
            if (Config.UseTempFolder == true )  // Als dit nodig is, dan...
            {
                recordTo = Config.tempPath;

                if (File.Exists(Config.tempPath + @"\" + FileManager.l_filename + ".mp3"))
                {
                    FileManager.l_filename = FileManager.l_filename + "_" + DateTime.Now.ToString("ss");
                }
            }
            else  // Als dit niet nodig is, dan...
            {
                recordTo = FileManager.l_folder;
                if(!Directory.Exists(FileManager.l_folder))
                {
                    Directory.CreateDirectory(FileManager.l_folder);
                }

                if (File.Exists(recordTo + @"\" + FileManager.l_filename + ".mp3"))
                {
                    FileManager.l_filename = FileManager.l_filename + "_" + DateTime.Now.ToString("ss");
                }
            }
            
            // Geef een overzicht in de console en logfile van de huidige instellingen.
            Console.WriteLine("Current program: " + Values.GetCurrentProgram());
            FileManager.WriteLogFile("Current program: " + Values.GetCurrentProgram());
            Console.WriteLine("Output file: " + recordTo + @"\" + FileManager.l_filename);
            FileManager.WriteLogFile("Output file: " + recordTo + @"\" + FileManager.l_filename);
            Console.WriteLine("Log file: " + logFile);
            FileManager.WriteLogFile("Log file: " + logFile);
            Console.WriteLine("Use physical audio device: " + Config.UsePhysicalDevice);
            FileManager.WriteLogFile("Use physical audio device: " + Config.UsePhysicalDevice);

            // Als er een verloopdatum zit aan de opnames, dan worden de opnames in een JSON bestand opgeslagen.
            // Hier wordt gekeken of dit nodig is.
            if (Config.DaysToKeep > 0)
            {
                FileManager.InsertToJson();
            }

            // De daadwerkelijke opnamemethode.
            if (Config.UsePhysicalDevice)
            {
                PhysicalStartRecord();    // Gebruik de fysieke geluidskaart.
            }
            else
            {
                URLStartRecord();         // Gebruik een Icecast URL.
            }
        }

        static void URLStartRecord()
        {
            while (true)
            {
                if (!RecordAgain)
                {
                    break;
                }
                else
                {
                    RecordAgain = false;
                }

                // Start het FFmpeg-proces om de opname te maken
                procRec = new Process()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "ffmpeg",
                        Arguments = $"-hide_banner -re -i {Config.StreamURL} -c:a copy -t {Config.RecDurationInSec + 10} " + $"{(char)34}{recordTo}\\{FileManager.l_filename}.mp3{(char)34}", // Pas argumenten aan zoals nodig
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    }
                };

                procRec.EnableRaisingEvents = true;
                procRec.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(process_OutputDataReceived);
                procRec.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(process_ErrorDataReceived);
                procRec.Exited += new System.EventHandler(process_Exited);

                procRec.Start();
                procRec.BeginErrorReadLine();
                procRec.BeginOutputReadLine();

                pId = procRec.Id;
                Console.Title = $"Running: {Config.Title} | PID: {pId} | Program: {Values.GetCurrentProgram()} | Started: {DateTime.Now.ToString("dd-MMMM-yyyy @ HH:mm:ss")}";

                // Wacht tot het FFmpeg-proces is voltooid (bijv. na 1 uur)
                procRec.WaitForExit();

                SetRecordingMode();
            }
        }

        static void PhysicalStartRecord()
        {
            while(true)
            {
                if (!RecordAgain)
                {
                    break;
                }
                else
                {
                    RecordAgain = false;
                }

                // Start het FFmpeg-proces om de opname te maken
                procRec = new Process()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "ffmpeg",
                        Arguments = $"-hide_banner -f dshow -re -i audio=" + $"{(char)34}{Config.PhysicalDevice}{(char)34}" + $" -b:a 192k -acodec libmp3lame -t {Config.RecDurationInSec + 10} " + $"{(char)34}{recordTo}\\{FileManager.l_filename}.mp3{(char)34}", // Pas argumenten aan zoals nodig
                        //Arguments = "-f dshow -re -i audio=" + $"{(char)34}{Config.PhysicalDevice}{(char)34}" + $" -b:a 192k -acodec libmp3lame -t {Config.RecDurationInSec} " + $"{(char)34}{l_folder}\\{l_filename}.mp3{(char)34}", // Pas argumenten aan zoals nodig
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    }
                };

                procRec.EnableRaisingEvents = true;
                procRec.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(process_OutputDataReceived);
                procRec.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(process_ErrorDataReceived);
                procRec.Exited += new System.EventHandler(process_Exited);

                procRec.Start();
                procRec.BeginErrorReadLine();
                procRec.BeginOutputReadLine();

                pId = procRec.Id;
                Console.Title = $"Running: {Config.Title} | PID: {pId} | Program: {Values.GetCurrentProgram()} | Started: {DateTime.Now.ToString("dd-MMMM-yyyy @ HH:mm:ss")}";

                // Wacht tot het FFmpeg-proces is voltooid (bijv. na 1 uur)
                procRec.WaitForExit();

                SetRecordingMode();
            }
        }

        static void process_Exited(object sender, EventArgs e)
        {
            Console.WriteLine(string.Format("Process exited with code {0}\n", procRec.ExitCode.ToString()));
        }

        static void process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(e.Data);
            FileManager.logbuffer = FileManager.logbuffer + Environment.NewLine + e.Data;
        }

        static void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            //Console.WriteLine(e.Data + "\n");
            Console.Write(e.Data);
        }

    }
}

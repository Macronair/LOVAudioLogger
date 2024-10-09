using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MarcosIcecastRecorder
{
    internal class URL
    {

        static Process ffmpegProcess;
        static string currentTime;
        static int pId;
        static int errorTimeOut;

        static void StartRecorder()
        {
            string outputFileName;

            while (true)
            {
                errorTimeOut = 0;
                // Genereer een unieke bestandsnaam op basis van de huidige datum en tijd

                string currentdate = DateTime.Now.ToString("yyyy-MM-dd (dddd)");
                string currentdir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                string filename;
                if (Config.FileName == "")
                {
                    filename = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                }
                else
                {
                    filename = $"{Config.FileName}";
                }

                if (Path == "*")
                {
                    if (!Directory.Exists(currentdate))
                    {
                        Directory.CreateDirectory(currentdate);
                    }
                    outputFileName = $@"{currentdir}\{currentdate}\{filename}.mp3";
                }
                else
                {
                    Console.WriteLine(Path + @"\" + currentdate);

                    if (!Directory.Exists(Path + @"\" + currentdate))
                    {
                        Directory.CreateDirectory(Path + @"\" + currentdate);
                    }
                    outputFileName = $@"{Path}\{currentdate}\{filename}.mp3";
                }

                // Start het FFmpeg-proces om de opname te maken
                ffmpegProcess = new Process()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "ffmpeg",
                        Arguments = $"-hide_banner -re -i {StreamURL} -c:a copy -t {RecDurationInSec} \"{outputFileName}\"", // Pas argumenten aan zoals nodig
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    }
                };
                ffmpegProcess.EnableRaisingEvents = true;
                ffmpegProcess.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(process_OutputDataReceived);
                ffmpegProcess.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(process_ErrorDataReceived);
                ffmpegProcess.Exited += new System.EventHandler(process_Exited);

                ffmpegProcess.Start();
                ffmpegProcess.BeginErrorReadLine();
                ffmpegProcess.BeginOutputReadLine();

                pId = ffmpegProcess.Id;
                Console.Title = $"Running: {Title} | Proc ID: {pId} | Rec. started: {DateTime.Now.ToString("dd-MMMM-yyyy @ HH:mm:ss")}";

                // Wacht tot het FFmpeg-proces is voltooid (bijv. na 1 uur)
                ffmpegProcess.WaitForExit();

                if (errorTimeOut < 60)
                {
                    break;
                }
                // Pauzeer het programma voor 1 uur voordat de volgende opname wordt gestart
                //Thread.Sleep(TimeSpan.FromMilliseconds(10));
            }
        }

        static void process_Exited(object sender, EventArgs e)
        {
            Console.WriteLine(string.Format("process exited with code {0}\n", ffmpegProcess.ExitCode.ToString()));
        }

        static void process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data);
        }

        static void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            //Console.WriteLine(e.Data + "\n");
            Console.Write(e.Data);
        }
    }
}

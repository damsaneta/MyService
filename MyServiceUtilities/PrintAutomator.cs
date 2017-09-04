using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace MyServiceUtilities
{
    public class PrintAutomator
    {
        private PrintableWatcher printableWatcher;

        public PrintAutomator(string fileType, string directory, string printerName = "aaa")
        {
            FileType = fileType;
            Directory = directory;
            PrinterName = printerName;
            printableWatcher = new PrintableWatcher();
        }

        public string FileType { get; private set; }

        public string Directory { get; private set; }

        public string PrinterName { get; private set; }

        public static void OnFileAdded(Object source, FileSystemEventArgs e)
            // drukujemy w nowym procesie "e-sciezka do pliku", okno ma być nie widoczne
        {
            var t = new Thread(() =>
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.Verb = "print";
                info.FileName = e.FullPath;
                info.CreateNoWindow = true;
                info.WindowStyle = ProcessWindowStyle.Hidden;

                Process p = new Process();
                p.StartInfo = info;
                p.Start();
                p.WaitForInputIdle(); //czeka az plik sie załaduje
                System.Threading.Thread.Sleep(30000);
                if (!p.HasExited && false == p.CloseMainWindow())
                {
                    p.Kill();
                }
            });
            t.Start();
        }

        public void StartWatching()
        {
            printableWatcher.Run(Directory, FileType);
        }

        public void StopWatching()
        {
            printableWatcher.Stop();
        }

        //public static void test(string path)// drukujemy w nowym procesie "e-sciezka do pliku", okno ma być nie widoczne
        //{
        //    var t = new Thread(() => {
        //        ProcessStartInfo info = new ProcessStartInfo();
        //        info.Verb = "print";
        //        info.FileName = path;
        //        info.CreateNoWindow = true;
        //        info.WindowStyle = ProcessWindowStyle.Hidden;

        //        Process p = new Process();
        //        p.StartInfo = info;
        //        p.Start();
        //        p.WaitForInputIdle(); //czeka az plik sie załaduje
        //        System.Threading.Thread.Sleep(30000);
        //        if (!p.HasExited && false == p.CloseMainWindow())
        //        {
        //            p.Kill();
        //        }
        //    });
        //    t.Start();

        //}
    }
}

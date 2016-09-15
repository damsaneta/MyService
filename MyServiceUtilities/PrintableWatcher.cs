using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace MyServiceUtilities
{
    public class PrintableWatcher
    {
        // Create a new FileSystemWatcher and set its properties. 
        public FileSystemWatcher watcher;

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")] //uprawnienia do wszystkiego - nadzorowania
        public void Run(string directory, string fileTypes)
        {
            watcher = new FileSystemWatcher();
            watcher.Path = directory;
            /* Watch for changes in LastWrite*/
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.LastAccess | NotifyFilters.FileName;
            // Only watch files. Example "*.txt" watch only for text files;
            watcher.Filter = fileTypes;

            // Add event handlers.
            watcher.Created += new FileSystemEventHandler(PrintAutomator.OnFileAdded);
            //watcher.Changed += new FileSystemEventHandler(Print);

            // Begin watching.
            watcher.EnableRaisingEvents = true;

        }

        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
        }
    }
}

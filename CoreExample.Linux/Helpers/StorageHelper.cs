using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using CoreExample.Common.Interfaces.Controllers.Helpers;
using CoreExample.Common.Models;
using NLog;

namespace CoreExample.Linux.Helpers
{
    public class StorageHelper : IStorageHelper
    {
        private Logger logger = NLog.LogManager.GetCurrentClassLogger();
        
        public StorageInfo GetStorageInfo()
        {
            logger.Info("Getting df info...");
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = "-c \"df / --output=used,avail\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

            proc.Start();
            proc.WaitForExit();

            if (proc.ExitCode != 0)
            {
                logger.Error("Failed to execute df: " + proc.ExitCode);
                return null;
            }
            
            string dfOutput = proc.StandardOutput.ReadToEnd();
            
            logger.Info("Got df output: " + dfOutput);

            Regex regex = new Regex(@"\d+");
            MatchCollection matches = regex.Matches(dfOutput);

            if (matches.Count < 2)
            {
                return null;
            }
            
            StorageInfo storageInfo = new StorageInfo();
            storageInfo.bytes_used = Int32.Parse(matches[0].ToString());
            storageInfo.bytes_free = Int32.Parse(matches[1].ToString());

            logger.Info("Returning StorageInfo.");
            return storageInfo;
        }
    }
}
using CoreExample.Common.Interfaces.Controllers.Helpers;
using CoreExample.Common.Models;
using NLog;
using System.IO;

namespace CoreExample.Windows.Helpers
{
    public class StorageHelper : IStorageHelper
    {
        Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public StorageInfo GetStorageInfo()
        {
            logger.Info("Starting storage read...");
            StorageInfo storageInfo = new StorageInfo();

            logger.Info("Storage foreach...");
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                logger.Info(drive.Name);
                if (drive.IsReady && drive.Name.Contains("C"))
                {
                    storageInfo.bytes_free = drive.TotalFreeSpace;
                    storageInfo.bytes_used = drive.TotalSize - drive.TotalFreeSpace;
                    logger.Info("Found C drive, returning data!");
                    return storageInfo;
                }
            }

            logger.Info("Didn't find C drive, returning null!");
            return null;
        }
    }
}

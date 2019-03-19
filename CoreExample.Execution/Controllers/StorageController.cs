using CoreExample.Common.Interfaces.Controllers;
using CoreExample.Common.Interfaces.Controllers.Helpers;
using CoreExample.Common.Models;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace CoreExample.Execution.Controllers
{
    
    public class StorageController : IStorageController
    {
        IStorageHelper storageHelper = null;
        Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public StorageController(IStorageHelper storageHelper)
        {
            this.storageHelper = storageHelper;
        }
        
        [HttpGet]
        public StorageInfo GetStorageInfo()
        {
            logger.Info("GetStorageInfo...");
            StorageInfo storageInfo = storageHelper.GetStorageInfo();
            logger.Info("Got info...");
            if (storageInfo != null)
            {
                logger.Info("Info not null!");
                storageInfo.result = true;
            }
            else
            {
                logger.Error("Info null!");
                storageInfo.result = false;
                storageInfo.error_text = "Failed to find root drive!";
            }

            return storageInfo;
        }
    }
}

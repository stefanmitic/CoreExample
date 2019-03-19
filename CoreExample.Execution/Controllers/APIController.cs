using CoreExample.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreExample.Execution.Controllers
{
    [Route("[controller]/[action]")]
    public class APIController : Controller
    {
        public StorageInfo StorageInfo()
        {
            return ExampleEnvironment.StorageController.GetStorageInfo();
        }
    }
}

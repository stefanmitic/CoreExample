using CoreExample.Common.Interfaces.Controllers;
using CoreExample.Execution.Controllers;
using CoreExample.Linux.Helpers;

namespace CoreExample.Linux
{
    public class ControllerFactoryLinux : IControllersFactory
    {
        public IStorageController CreateStorageController()
        {
            return new StorageController(new StorageHelper());
        }
    }
}
using CoreExample.Common.Interfaces.Controllers;
using CoreExample.Execution.Controllers;
using CoreExample.Windows.Helpers;

namespace CoreExample.Windows
{
    class ControllersFactoryWindows : IControllersFactory
    {
        public IStorageController CreateStorageController()
        {
            return new StorageController(new StorageHelper());
        }
    }
}

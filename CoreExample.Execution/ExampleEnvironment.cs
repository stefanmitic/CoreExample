using CoreExample.Common.Interfaces.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreExample.Execution
{
    public static class ExampleEnvironment
    {
        public static IStorageController StorageController { get; private set; }

        public static void InitEnvironment(IControllersFactory controllersFactory)
        {
            StorageController = controllersFactory.CreateStorageController();
        }
    }
}

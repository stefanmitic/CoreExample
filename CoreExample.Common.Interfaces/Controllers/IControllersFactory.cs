using System;
using System.Collections.Generic;
using System.Text;

namespace CoreExample.Common.Interfaces.Controllers
{
    public interface IControllersFactory
    {
        IStorageController CreateStorageController();
    }
}

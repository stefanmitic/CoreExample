namespace CoreExample.Common.Interfaces.Controllers
{
    public interface IControllersFactory
    {
        IStorageController CreateStorageController();
    }
}

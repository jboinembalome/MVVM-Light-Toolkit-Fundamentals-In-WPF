
namespace PlugInSample.Contracts
{
    public interface IPlugInHost
    {
        void Clear();
        void PlacePlugIn(IPlugIn plugIn, object dataContext);
    }
}

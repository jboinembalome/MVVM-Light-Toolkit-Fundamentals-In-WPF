
namespace PlugInSample.Contracts
{
    public static class Notifications
    {
        public static readonly string CleanupNotification
            = typeof(Notifications).FullName + ".Cleanup";

        public static readonly string NewUserNotification
            = typeof(Notifications).FullName + ".NewUser";
    }
}

namespace JoRoomWebApplication.Constants
{
    public class RouteConstants
    {
        public const string DefaultPattern = "{controller=Home}/{action=Index}/{id?}";
        public const string Get = "/[controller]/{id}";
        public const string GetList = "/[controller]/List";
        public const string Add = "/[controller]/Add";
        public const string Update = "/[controller]/Update";
        public const string Delete = "/[controller]/Delete/{id}";
    }
}
namespace WebApi.Constants
{
    public class RouteConstants
    {
        public const string Get = "/[controller]/{id}";
        public const string GetById = "/[controller]/GetById/{id}";
        public const string PostById = "/[controller]/GetById";
        public const string GetList = "/[controller]/List";
        public const string Add = "/[controller]/Add";
        public const string Update = "/[controller]/Update";
        public const string Delete = "/[controller]/Delete/{id}";
        public const string SingIn = "/[controller]/SingIn";
        public const string SingUp = "/[controller]/SingUp";
        public const string GetByToken = "/[controller]/GetByToken";
        public const string GetPostListByTag = "/[controller]/GetPostListByTag/{id}";
    }
}
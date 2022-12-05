namespace DataBase.Constants
{
    public static class DbConstants
    {
        const string serverName = "localhost";
        const string dBName = "JoRoom";
        const string trustedConnection = "True";
        const string encrypt = "False";

        public static string GetConnectionString()
        {
            return $"Server={serverName};Database={dBName};Trusted_Connection={trustedConnection};Encrypt={encrypt};";
        }
    }
}
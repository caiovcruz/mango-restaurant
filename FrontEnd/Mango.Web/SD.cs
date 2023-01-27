namespace Mango.Web
{
    public static class SD
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static string ProductAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE,
        }
    }
}
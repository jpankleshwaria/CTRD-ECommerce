namespace Common.Domain.Constants
{
    public static class Constants
    {
        /// <summary>
        /// CSP Database Connection String 
        /// </summary>

        public static string CspDbConnectionString;

        /// <summary>
        /// Page size constant
        /// </summary>
        public const int PageSize = 15;
        /// <summary>
        /// Page number constant
        /// </summary>
        public const int PageNumber = 1;

        /// <summary>
        /// Access token constant
        /// </summary>
        public const string AcessToken = "access_token";
        /// <summary>
        /// The system user
        /// </summary>
        public const string SystemUser = "System";
        /// <summary>
        /// The export page size
        /// </summary>
        public const int ExportPageSize = 5000;

        public static string AdminAPIURL;

        public const string GetModelAPIEndpoint = "api/Admin/GetModel/{0}";

        public const string GetProductLineAPIEndpoint = "api/Admin/productLines/{0}";



        public const string DefaultDateFormat = "{0:dd-MMM-yyyy}";


        public const string DefaultDatetimeFormat = "{0:dd-MMM-yyyy HH:mm:ss}";

        public const string FilenameDatetimeFormat = "{0:yyyyMMdd_HHmmss}";

        public const string DecimalFormat = "{0:C2}";

        public const string PercentageFormat = "{0:N2}";

        public static string ClientURL;


    }

}

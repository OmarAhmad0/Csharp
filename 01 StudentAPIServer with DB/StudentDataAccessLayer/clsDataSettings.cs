
using Microsoft.Extensions.Configuration;


namespace StudentDataAccessLayer
{
    public class clsDataSettings
    {
        public  static string? _connectionString;

        public static void Initilize(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

 
    }
}

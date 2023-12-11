using System.Data.SqlClient;
using System.Globalization;


namespace CRUDCORE.Datos
{
    public class Conexion
    {
        private String CadenaSQL = string.Empty;

        public Conexion() {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            CadenaSQL = builder.GetSection("ConnectionStrings:CadenaSql").Value;
        }

        public string getCadenaSQL()
        {

            return CadenaSQL;
        }
    }
}

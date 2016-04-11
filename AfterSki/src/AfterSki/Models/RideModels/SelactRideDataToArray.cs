using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace AfterSki.Models.RideModels
{
    
    public class SelactRideDataToArray
    {

        static int[] ridesPerHourArray;

        public static SqlConnection dbConnection()
        {
            return new SqlConnection("Data Source=localhost; Initial Catalog=Afterski; Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public int[] SelectHourData()
        {
            ridesPerHourArray = new int[1];


            SqlConnection conn = dbConnection();
            SqlCommand comm = new SqlCommand();
            bool dbExists = false;
            using (var connection = dbConnection())
            {
                using (var command = new SqlCommand(string.Format("RideStatistic.swipedate FROM RideStatistic WHere RideStatistic.swipedate = 'Sön, 27 Mar'group by swipedate"))
                {
                    connection.Open();
                return null;
                //dbExists = (command.BeginExecuteNonQuery() != DBNull.Value);
            }

            }
        }


            return null;
        }




    }
}

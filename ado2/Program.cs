using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ado2
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=192.168.111.139;Initial Catalog=shop;User ID=sa;Password=Ev4865";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionString;

            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "create table dan_TablesModel (intModelID INT IDENTITY, strName VARCHAR(100), ManufacturerID INT,intSMCSFamilyID INT, strImage VARCHAR(100))";
            cmd1.Connection = con;
            con.Open();
            //cmd1.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = "INSERT INTO dan_TablesModel VALUES ('SuperModel', 1, 1, 'someimage.png')";
            cmd2.Connection = con;
            //cmd2.ExecuteNonQuery();

            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandText = "select * from  dan_TablesModel";
            cmd3.Connection = con;

            SqlDataReader dr = cmd3.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"ID {dr[0]}");
                Console.WriteLine($"Name {dr[1]}");
                Console.WriteLine($"IDManuf {dr[2]}");
                Console.WriteLine($"IdSMCS {dr[3]}");
                Console.WriteLine($"Image {dr[4]}");
                Console.WriteLine();
            }

            dr.Close();
            cmd1.CommandText = "create table dan_TablesManufacturer (intManufID INT IDENTITY, strNameManuf VARCHAR(100))";
            //cmd1.ExecuteNonQuery();

            cmd1.CommandText = "create table dan_TablesStopReason(intStopReasonID INT IDENTITY, strReason VARCHAR(100), bitDowntime BIT,bitUnsceduled BIT,bitPMStopagges BIT,bitSceduledRepairsAndOthers BIT, intLocationID INT)";
            //cmd1.ExecuteNonQuery();
            con.Close();
            Console.ReadKey();
        }
    }
}

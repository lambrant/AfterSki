﻿using AfterSki.Models;
using AfterSki.Models.RideModels;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static AfterSki.Models.JsonData;


namespace AfterSki.Controllers
{

    public class DataImport
    {
        private RideStatisticDBContext _context;

        public DataImport(RideStatisticDBContext context)

        {
            _context = context;
        }

        public string dbName = "AfterSki";

        List<Models.RideModels.RideStatistic> dimp = new List<Models.RideModels.RideStatistic>(); // List that holds importdata


        private SqlConnection dbConnection()
        {
            ///<summary>
            ///SQL-Connection method
            /// </summary>
            return new SqlConnection("Data Source=localhost;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }


        public void ListToDB()
        {
            if (rideStatList == null)
            {
                return;
            }
            else {
                dimp = rideStatList.ToList();
                SqlConnection conn = dbConnection();
                SqlCommand comm = new SqlCommand();

                ///<summary>
                ///Check if database exists, if skip importfunction
                /// </summary>
                bool dbExists = false;
                using (var connection = dbConnection())
                {
                    using (var command = new SqlCommand(string.Format("SELECT db_id('{0}')", dbName), connection))
                    {
                        connection.Open();
                        dbExists = (command.ExecuteScalar() != DBNull.Value);
                    }
                }

                if (dbExists != true)
                {

                    comm.CommandText = "CREATE DATABASE " + dbName;
                    comm.Connection = conn;
                    conn.Open();

                    comm.ExecuteNonQuery();
                    conn.Close();
                    comm.CommandText = "CREATE TABLE AfterSki.dbo.RideStatistic " +
                                        "(ID int NOT NULL IDENTITY(1, 1) PRIMARY KEY, " +
                                        "destinationID int, " +
                                        "height int, " +
                                        "liftname nvarchar(50), " +
                                        "name nvarchar(50), " +
                                        "swipedate nvarchar(50), " +
                                        "swipetime datetime )";

                    comm.Connection = conn;
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();

                    for (int i = 0; i < dimp.Count; i++)
                    {
                        if (conn.ConnectionString == "")
                        {
                            conn = dbConnection();
                            comm.Parameters.Clear();
                        }
                        SqlParameter idDB = new SqlParameter();
                        idDB.Direction = ParameterDirection.Input;
                        idDB.ParameterName = "@destinationID";
                        idDB.SqlDbType = SqlDbType.Int;
                        idDB.SqlValue = dimp[i].destination.id;
                        comm.Parameters.Add(idDB);

                        SqlParameter nameDB = new SqlParameter();
                        nameDB.Direction = ParameterDirection.Input;
                        nameDB.ParameterName = "@name";
                        nameDB.SqlDbType = SqlDbType.NVarChar;
                        if (dimp[i].destination.name == null)
                        {
                            nameDB.SqlValue = DBNull.Value;
                        }
                        else
                        {
                            nameDB.SqlValue = dimp[i].destination.name;
                        }
                        comm.Parameters.Add(nameDB);

                        SqlParameter heightDB = new SqlParameter();
                        heightDB.Direction = ParameterDirection.Input;
                        heightDB.ParameterName = "@height";
                        heightDB.SqlDbType = SqlDbType.Int;
                        heightDB.SqlValue = dimp[i].height;
                        comm.Parameters.Add(heightDB);

                        SqlParameter liftnameDB = new SqlParameter();
                        liftnameDB.Direction = ParameterDirection.Input;
                        liftnameDB.ParameterName = "@liftname";
                        liftnameDB.SqlDbType = SqlDbType.NVarChar;
                        if (dimp[i].liftName == null)
                        {
                            liftnameDB.SqlValue = DBNull.Value;
                        }
                        else
                        {
                            liftnameDB.SqlValue = dimp[i].liftName;
                        }
                        comm.Parameters.Add(liftnameDB);

                        SqlParameter swipedateDB = new SqlParameter();
                        swipedateDB.Direction = ParameterDirection.Input;
                        swipedateDB.ParameterName = "@swipedate";
                        swipedateDB.SqlDbType = SqlDbType.NVarChar;
                        if (dimp[i].swipeDate == null)
                        {
                            swipedateDB.SqlValue = DBNull.Value;
                        }
                        else
                        {
                            swipedateDB.SqlValue = dimp[i].swipeDate;
                        }
                        comm.Parameters.Add(swipedateDB);

                        SqlParameter swipetimeDB = new SqlParameter();
                        swipetimeDB.Direction = ParameterDirection.Input;
                        swipetimeDB.ParameterName = "@swipetime";
                        swipetimeDB.SqlDbType = SqlDbType.DateTime;
                        swipetimeDB.SqlValue = dimp[i].swipeTime;
                        comm.Parameters.Add(swipetimeDB);

                        comm.CommandText = "INSERT INTO AfterSki.dbo.RideStatistic " +
                                            "(destinationID, height, liftname, name, swipedate, swipetime) " +
                                            "VALUES " +
                                            "(@destinationID, @height, @liftname, @name, @swipedate, @swipetime) ";

                        comm.Connection = conn;
                        conn.Open();
                        comm.ExecuteNonQuery();
                        conn.Close();
                        conn.Dispose();
                        comm.Dispose();
                    }
                }
                else
                {
                    UpdateRecordIfExists u = new UpdateRecordIfExists(_context);
                    u.UpdateData();
                }
            }
        }
    }
}
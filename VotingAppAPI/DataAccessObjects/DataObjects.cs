using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using VotingAppAPI.BusinessObjects;

namespace VotingAppAPI.DataAccessObjects
{
    public class DataObjects
    {
        private readonly DBHelper _dbHelper;
        public DataObjects(DBHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<Students> GetStudents()
        {
            var qInfo = new List<Students>();
            var sb = new StringBuilder();

            sb.AppendLine("SELECT * from Questions dbo.Voting");

            using (var cmd = new SqlCommand(sb.ToString(), _dbHelper.SQLConnection))
            {
                cmd.Connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        qInfo.Add(new Students
                        {
                            StudentNumber = (int)reader["StudentNumber"],
                            FirstName = reader["FirstName"].ToString(),


                        });
                    }

                }
            }

            return qInfo;
        }
    }
}
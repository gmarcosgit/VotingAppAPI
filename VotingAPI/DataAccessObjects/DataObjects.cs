using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using VotingAPI.BusinessObjects;

namespace VotingAPI.DataAccessObjects
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

            sb.AppendLine("SELECT * from dbo.Students");

            using (var cmd = new SqlCommand(sb.ToString(), _dbHelper.SQLConnection))
            {
                cmd.Connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        qInfo.Add(new Students
                        {
                            StudentNumber = reader["StudentNumber"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            MI = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            GradeLevel = (int)reader["GradeLevel"],
                            Section = reader["Section"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            Voted = (bool)reader["Voted"],
                            DateTimeVoted = (DateTime)reader["DateTimeVoted"],
                            FullName = reader["FullName"].ToString(),

                        });
                    }

                }
            }

            return qInfo;
        }


        public List<Candidates> GetAllCandidates()
        {
            var candidates = new List<Candidates>();
            var sb = new StringBuilder();

            sb.AppendLine("SELECT * from dbo.Candidates");

            using (var cmd = new SqlCommand(sb.ToString(), _dbHelper.SQLConnection))
            {
                cmd.Connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        candidates.Add(new Candidates
                        {
                            StudentNumber = reader["StudentNumber"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            MI = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            GradeLevel = Convert.ToInt32(reader["GradeLevel"]),
                            Section = reader["Section"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            Position = reader["Position"].ToString(),
                            FullName = reader["FullName"].ToString(),
                            SchoolYear = reader["SchoolYear"].ToString(),
                        });
                    }
                }
            }
            return candidates;
        }
    }
}
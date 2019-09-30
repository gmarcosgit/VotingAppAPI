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
                            StudentNumber = (int)reader["StudentNumber"],
                            FirstName = reader["FirstName"].ToString(),
                            MI = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            GradeLevel = (int)reader["GradeLevel"],
                            Section = reader["Section"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            Voted = (bool)reader["Voted"],
                            DateTimeVoted = (DateTime)reader["DateTimeVoted"],
                            FullName = reader["FullName"].ToString(),
                            Password = (reader["Password"].ToString()),

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
                            StudentNumber = Convert.ToInt32(reader["StudentNumber"]),
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


        public Students GetLoginStudents(Students student)
        {
            var _student = new Students();
            var sb = new StringBuilder();

            sb.AppendLine("SELECT * from dbo.Students WHERE StudentNumber = @UserName AND Password = @Password");

            using (var cmd = new SqlCommand(sb.ToString(), _dbHelper.SQLConnection))
            {
                cmd.Connection.Open();
                cmd.Parameters.Add(new SqlParameter("@UserName", student.StudentNumber));
                cmd.Parameters.Add(new SqlParameter("@Password", student.Password));

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _student.StudentNumber = (int)reader["StudentNumber"];
                        _student.FirstName = reader["FirstName"].ToString();
                        _student.MI = reader["FirstName"].ToString();
                        _student.LastName = reader["LastName"].ToString();
                        _student.GradeLevel = (int)reader["GradeLevel"];
                        _student.Section = reader["Section"].ToString();
                        _student.Gender = reader["Gender"].ToString();
                        _student.Voted = (bool)reader["Voted"];
                        _student.DateTimeVoted = (DateTime)reader["DateTimeVoted"];
                        _student.FullName = reader["FullName"].ToString();
                        _student.Password = (reader["Password"].ToString());
                    }

                }
            }

            return _student;
        }
    }
}
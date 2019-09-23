using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using VotingAPI.BusinessObjects;

namespace VotingAPI.DataAccessObjects
{
    public class PostObjects
    {
        private readonly DBHelper _dbHelper;
        public PostObjects(DBHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public bool InsertVotes(List<VoteData> votedata)
        {
            var sb = new StringBuilder();
            var result = 0;

            sb.AppendLine(
                "INSERT INTO dbo.VoteData (CandidateNumber,StudentNumber,FullName,GradeLevel,Section) " +
                "VALUES (@CandidateNumber, @StudentNumber,@FullName, @GradeLevel,@Section)");

            using (var cmd = new SqlCommand(sb.ToString(), _dbHelper.SQLConnection))
            {
                cmd.Connection.Open();

                foreach (var student in votedata)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@CandidateNumber", student.CandidateNumber);
                    cmd.Parameters.AddWithValue("@StudentNumber", student.StudentNumber);
                    cmd.Parameters.AddWithValue("@FullName", student.FullName);
                    cmd.Parameters.AddWithValue("@GradeLevel", student.GradeLevel);
                    cmd.Parameters.AddWithValue("@Section", student.Section);
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result > 0;
        }

        //public Students InsertStudents(Students students)
        //{
        //    var sb = new StringBuilder();

        //    sb.AppendLine("INSERT INTO dbo.Students(StudentNumber,FirstName,MI,LastName,Age,Gender)");
        //    sb.AppendLine(string.Format("OUTPUT INSERTED.CustomerNumber VALUES ('{0}', '{1}', '{2}');", cust.FirstName, cust.Age, cust.Gender));

        //    using (var cmd = new SqlCommand(sb.ToString(), _dbHelper.SQLConnection))
        //    {
        //        cmd.Connection.Open();
        //        cust.StudentNumber = (int)cmd.ExecuteScalar();
        //    }

        //    return cust;
        //}
    }
}
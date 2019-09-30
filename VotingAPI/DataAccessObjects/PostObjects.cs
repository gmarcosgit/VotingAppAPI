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
                "INSERT INTO dbo.VoteData (StudentNumber,FirstName,MI,LastName,GradeLevel,Section,CandidateStudentNumber,Position) " +
                "VALUES (@StudentNumber,@FirstName,@MI,@LastName,@GradeLevel,@Section,@CandidateStudentNumber,@Position)");

            using (var cmd = new SqlCommand(sb.ToString(), _dbHelper.SQLConnection))
            {
                cmd.Connection.Open();

                foreach (var student in votedata)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@StudentNumber", student.StudentNumber);
                    cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                    cmd.Parameters.AddWithValue("@MI", student.MI);
                    cmd.Parameters.AddWithValue("@LastName", student.LastName);
                    cmd.Parameters.AddWithValue("@GradeLevel", student.GradeLevel);
                    cmd.Parameters.AddWithValue("@Section", student.Section);
                    cmd.Parameters.AddWithValue("@CandidateStudentNumber", student.CandidateStudentNumber);
                    cmd.Parameters.AddWithValue("@Position", student.Position);

                    result = cmd.ExecuteNonQuery();
                }
            }
            return result > 0;
        }

        public bool SubmitVote(List<AuditTrailVote> votedata)
        {
            var sb = new StringBuilder();
            var result = 0;

            sb.AppendLine(
                "INSERT INTO dbo.AuditTrailVote (StudentNumber,President,VicePresident,Secretary,Treasurer,Auditor,BusinessManager,PublicInformationOfficer) " +
                "VALUES (@StudentNumber,@President,@VicePresident,@Secretary,@Treasurer,@Auditor,@BusinessManager,@PublicInformationOfficer)");

            using (var cmd = new SqlCommand(sb.ToString(), _dbHelper.SQLConnection))
            {
                cmd.Connection.Open();

                foreach (var student in votedata)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@StudentNumber", student.StudentNumber);
                    cmd.Parameters.AddWithValue("@President", student.President);
                    cmd.Parameters.AddWithValue("@VicePresident", student.VicePresident);
                    cmd.Parameters.AddWithValue("@Secretary", student.Secretary);
                    cmd.Parameters.AddWithValue("@Treasurer", student.Treasurer);
                    cmd.Parameters.AddWithValue("@Auditor", student.Auditor);
                    cmd.Parameters.AddWithValue("@BusinessManager", student.BusinessManager);
                    cmd.Parameters.AddWithValue("@PublicInformationOfficer", student.PublicInformationOfficer);

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
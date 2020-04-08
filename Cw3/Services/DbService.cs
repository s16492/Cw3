using cw3.DTOs.Requests;
using Cw3.DTOs.Requests;
using Cw3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Cw3.Services
{
    public class DbService : IDbService
    {
        public DbService()
        {

        }
      
        public void EnrollStudent(EnrollStudentRequest request)
        {



            var st = new Student();
            st.FirstName = request.FirstName;
            st.LastName = request.LastName;
            st.IndexNumber = request.IndexNumber;
            st.BirthDate = request.Birthdate;
            st.StudiesName = request.Studies;
            st.Semester = request.Semester;


            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s16492;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = con;

                con.Open();
                var tran = con.BeginTransaction();

                try
                {
                    
                    com.CommandText = "select IdStudies from studies where name=@studiesName";
                    com.Parameters.AddWithValue("studiesName", request.Studies);

                    var dr = com.ExecuteReader();
                    if (!dr.Read())
                    {
                        tran.Rollback();

                    }
                    int idstudies = (int)dr["IdStudies"];


                    com.CommandText = "Select IdEnrollment FROM Enrollments where semester=1 AND idStudy=@idstudy";
                    com.Parameters.AddWithValue("idStudy", idstudies);
                    dr = com.ExecuteReader();
                    if (!dr.Read())
                    {
                        com.CommandText = "Insert INTO Enrollemnts (StartDate, Semester, IdStudy) Values (@date,1,@idstudy)";
                        com.Parameters.AddWithValue("date", DateTime.Now);
                        com.CommandText = "Select IdEnrollment FROM Enrollments";
                        dr = com.ExecuteReader();

                    }
                 
                    com.ExecuteNonQuery();

                    tran.Commit();

                }
                catch (SqlException exc)
                {
                    tran.Rollback();
                }
            }

        }
        public bool CheckIndex(String index)
        {


         bool Check = false;

            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s16492;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "Select IndexNumber FROM Student WHERE IndexNumber = @IndexNumber; ";
                com.Parameters.AddWithValue("IndexNumber", index);

                con.Open();

                var dr = com.ExecuteReader();
                if (dr.Read()) Check = true;


            }

            return Check;
        }

        public void PromoteStudents(PromoteStudentRequest request)
        {

        }
        public void PromoteStudents(int semester, string studies)
        {
            throw new NotImplementedException();
        }

   
    }
}

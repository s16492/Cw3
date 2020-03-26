using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using Cw3.Models;
using Microsoft.AspNetCore.Mvc;
using Cw3.DAL;


namespace Cw3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {

        //private readonly IDBService _dbService;

        //public StudentsController(IDBService dbService)
        //{
        //    _dbService = dbService;
        //}

        //[HttpGet]
        //public IActionResult GetStudent(String orderBy)
        //{
        //    return Ok(_dbService.GetStudents());
        //}



        //[HttpGet("{id}")]
        //public IActionResult GetStudent(int id)
        //{
        //    if (id == 1)
        //    {
        //        return Ok("Kowalski");
        //    }
        //    else if (id == 2)
        //    {
        //        return Ok("Malewski");
        //    }

        //    return NotFound("Nie znaleziono studenta");
        //}

        //[HttpPost]
        //public IActionResult CreateSudent(Student student)
        //{
        //    student.IndexNumber = $"s{new Random().Next(1, 20000)}";
        //    return Ok(student);
        //}

        //        [HttpPut("{id:int}")]
        //public IActionResult UpdateStudent(int id)
        //{

        //    return Ok($"Aktualizacja dokonczona");
        //}

        //[HttpDelete("{id:int}")]
        //public IActionResult RemoveStudent(int id)
        //{

        //    return Ok($"Usuwanie ukonczone");
        //}


        [HttpGet]
        public IActionResult GetStudents()
        {
            var stud = new List<Student>();
            using (var con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s16492;Integrated Security=True"))
            using (var com = new SqlCommand())
            {
                string id = "1";

                com.Connection = con;
                com.CommandText = "select * from Student where IndexNumber=@id";
                com.Parameters.AddWithValue("id", id);
                con.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.BirthDate = DateTime.Parse(dr["BirthDate"].ToString());
                    st.IdEnrollment = int.Parse(dr["IdEnrollment"].ToString());
                    stud.Add(st);
                }
            }

            return Ok(stud);

        }



    }
}
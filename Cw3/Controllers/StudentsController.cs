﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw3.DAL;
using Cw3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cw3.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {

        private readonly IDBService _dbService;

        public StudentsController(IDBService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudent(String orderBy)
        {
            return Ok(_dbService.GetStudents());
        }



        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if (id == 1)
            {
                return Ok("Kowalski");
            }
            else if (id == 2)
            {
                return Ok("Malewski");
            }

            return NotFound("Nie znaleziono studenta");
        }

        [HttpPost]
        public IActionResult CreateSudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }

                [HttpPut("{id:int}")]
        public IActionResult UpdateStudent(int id)
        {

            return Ok($"Aktualizacja dokonczona");
        }

        [HttpDelete("{id:int}")]
        public IActionResult RemoveStudent(int id)
        {

            return Ok($"Usuwanie ukonczone");
        }




    }
}
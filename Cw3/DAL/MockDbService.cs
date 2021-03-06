﻿using Cw3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Cw3.DAL
{
    public class MockDbService : IDBService
    {
        private static IEnumerable<Student> students;

        static MockDbService()
        {
            students = new List<Student>
            {
                new Student{IdStudent = 1, FirstName = "Jan",LastName = "Kowalski"},
                new Student{IdStudent = 2, FirstName = "Annaq", LastName = "Malewski"},
                new Student{IdStudent = 3, FirstName = "Andrzej",LastName = "Andrzejewicz"}
            };

        }



        public IEnumerable<Student> GetStudents()
        {
            return students;
        }


    }
}


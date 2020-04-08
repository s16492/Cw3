using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cw3.DTOs.Requests
{
    public class EnrollStudentRequest
    {
        public string Semester { get; set; }

      
        public string IndexNumber { get; set; }


        [Required(ErrorMessage = "you must give name")]
        [MaxLength(10)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }
        public string Birthdate { get; set; }

        [Required]
        public string Studies { get; set; }
    }
}
using cw3.DTOs.Requests;
using Cw3.DTOs.Requests;
using System;


namespace Cw3.Services
{
    public interface IDbService
    {
        void EnrollStudent(EnrollStudentRequest request);
        void PromoteStudents(int semester, string studies);
        void PromoteStudents(PromoteStudentRequest request);
        bool CheckIndex(String index);

    }
}

using Common.Utilities.Services;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Contract
{
    public interface IStudentRepository
    {
        Task<Response<List<StudentDto>>> GetStudents();

        Task<Response<StudentDto>> CreateStudent(StudentDto student);

        Task<Response<StudentDto>> GetByIdStudent(int id);

        Task<Response<StudentDto>> UpdateStudent(StudentDto student);

        Task<Response<bool>> DeleteByIdStudent(int id);
    }
}

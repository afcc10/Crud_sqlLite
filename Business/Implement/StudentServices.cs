using Business.Contract;
using Common.Utilities.Services;
using DataAccess.Core.Contract;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implement
{
    public class StudentServices : IStudentServices
    {
        #region Propierties
        private readonly IStudentRepository _studentRepository;
        #endregion

        #region Constructor
        public StudentServices(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        
        #endregion

        public async Task<Response<List<StudentDto>>> GetStudents()
        {
            var result = await _studentRepository.GetStudents();
            return result;
        }

        public async Task<Response<bool>> UpdateStudent(StudentDto student)
        {
            var result = await _studentRepository.UpdateStudent(student);
            return result;
        }

        public async Task<Response<bool>> CreateStudent(StudentDto student)
        {
            var result = await _studentRepository.CreateStudent(student);
            return result;
        }

        public async Task<Response<bool>> DeleteByIdStudent(int id)
        {
            var result = await _studentRepository.DeleteByIdStudent(id);
            return result;
        }

        public async Task<Response<StudentDto>> GetByIdStudent(int id)
        {
            var result = await _studentRepository.GetByIdStudent(id);
            return result;
        }
    }
}

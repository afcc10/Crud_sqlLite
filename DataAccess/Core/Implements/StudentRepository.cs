using Common.Helpers;
using Common.Utilities.Resource;
using Common.Utilities.Services;
using DataAccess.Core.Contract;
using DataAccess.Models;
using Microsoft.Extensions.Logging;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Core.Implements
{
    public class StudentRepository : IStudentRepository
    {
        #region Propierties
        private readonly DbCrudContext context;
        private readonly ILogger<StudentRepository> _logger;
        #endregion

        #region Contructor
        public StudentRepository(DbCrudContext context,ILogger<StudentRepository> logger)
        {
            this.context = context;
            this._logger = logger;
        }
        
        #endregion

        #region Method
        public async Task<Response<List<StudentDto>>> GetStudents()
        {
            Response<List<StudentDto>> response = new();
            try
            {
                List<StudentDto> query = (from s in context.Student
                                           select new StudentDto
                                           {
                                               Id = s.Id,
                                               Age = s.Age,
                                               Career = s.Career,
                                               FirstName = s.FirstName,
                                               LastName = s.LastName,
                                               UserName = s.UserName
                                           }).ToList();                

                response = new()
                {
                    Status = query.Count == 0 ? false : true,
                    Message = query.Count == 0 ? MessageExtension.AddMessageList(Message_es.ConsultaNotFound) : MessageExtension.AddMessageList(Message_es.ConsultaExitosa),
                    ObjectResponse = query.Count != 0 ? query : null
                };

                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                
                return new Response<List<StudentDto>>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message),
                    ObjectResponse = null
                };
            }
        }

        public async Task<Response<StudentDto>> UpdateStudent(StudentDto _student)
        {
            Response<StudentDto> response = new();
            try
            {
                var student = context.Student.Where(x => x.Id == _student.Id).FirstOrDefault();

                student.Age = _student.Age;
                student.Career = _student.Career;
                student.FirstName = _student.FirstName;
                student.LastName = _student.LastName;
                student.UserName = _student.UserName;
                context.Update(student);
                context.SaveChanges();

                response = new()
                {
                    Status = true,
                    ObjectResponse = _student,
                    Message = MessageExtension.AddMessageList(Message_es.UpdateSucces)
                };

                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                return new Response<StudentDto>
                {
                    Status = false,
                    ObjectResponse = null,
                    Message = MessageExtension.AddMessageList(Message_es.UpdateError)
                };
            }
        }

        public async Task<Response<StudentDto>> CreateStudent(StudentDto _student)
        {
            Response<StudentDto> response = new();
            try
            {
                Student student = new();

                student.Age = _student.Age;
                student.Career = _student.Career;
                student.FirstName = _student.FirstName;
                student.LastName = _student.LastName;
                student.UserName = _student.UserName;
                context.Add(student);
                context.SaveChanges();

                StudentDto dto = new()
                {
                    Age = student.Age,
                    Career = student.Career,
                    FirstName = student.FirstName,
                    Id = student.Id,
                    LastName = student.LastName,
                    UserName = student.UserName
                };

                response = new()
                {
                    Status = true,
                    ObjectResponse = dto,
                    Message = MessageExtension.AddMessageList(Message_es.CreateSucces)
                };

                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                return new Response<StudentDto>
                {
                    Status = false,
                    ObjectResponse = null,
                    Message = MessageExtension.AddMessageList(Message_es.CreateError)
                };
            }
        }

        public async Task<Response<bool>> DeleteByIdStudent(int id)
        {
            Response<bool> response = new();
            try
            {
                var student = context.Student.Where(x => x.Id == id).FirstOrDefault();

                context.Remove(student);
                context.SaveChanges();

                response = new()
                {
                    Status = true,
                    ObjectResponse = true,
                    Message = MessageExtension.AddMessageList(Message_es.DeleteSucces)
                };

                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                return new Response<bool>
                {
                    Status = false,
                    ObjectResponse = false,
                    Message = MessageExtension.AddMessageList(Message_es.DeleteError)
                };
            }
        }

        public async Task<Response<StudentDto>> GetByIdStudent(int id)
        {
            Response<StudentDto> response = new();
            try
            {
                var student = context.Student.Where(x => x.Id == id).FirstOrDefault();
                StudentDto studentDto = new()
                {
                    Id = student.Id,
                    Age = student.Age,
                    Career = student.Career,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    UserName = student.UserName,
                };

                response = new()
                {
                    Status = true,
                    ObjectResponse = studentDto,
                    Message = MessageExtension.AddMessageList(Message_es.ConsultaExitosa)
                };

                return await Task.FromResult(response);
            }
            catch (Exception)
            {
                return new Response<StudentDto>
                {
                    Status = false,
                    ObjectResponse = null,
                    Message = MessageExtension.AddMessageList(Message_es.ConsultaNotFound)
                };
            }
        }
        #endregion
    }
}

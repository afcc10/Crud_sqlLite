using Business.Contract;
using Common.Helpers;
using Common.Utilities.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_sqlLite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        #region Propierties
        private readonly IStudentServices Service;
        private readonly ILogger<StudentController> _logger;
        #endregion

        #region Constructor
        public StudentController(IStudentServices service, ILogger<StudentController> logger)
        {
            Service = service;
            _logger = logger;
        }
        #endregion

        /// <summary>
        /// Obtener estudiantes
        /// </summary>
        /// <returns>Response model StudentDto</returns>
        /// <author>Andres Cabezas</author>
        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(Response<List<StudentDto>>), StatusCodes.Status200OK)]
        public async Task<Response<List<StudentDto>>> Get()
        {
            Response<List<StudentDto>> response;
            try
            {
                response = await Service.GetStudents();
                return response;
            }
            catch (Exception ex)
            {
                return new Response<List<StudentDto>>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }

        /// <summary>
        /// crear estudiantes
        /// </summary>
        /// <returns>Response bool</returns>
        /// <author>Andres Cabezas</author>
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        public async Task<Response<bool>> Post(StudentDto student)
        {
            Response<bool> response;
            try
            {
                response = await Service.CreateStudent(student);
                return response;
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }

        /// <summary>
        /// actualizar estudiantes
        /// </summary>
        /// <returns>Response bool</returns>
        /// <author>Andres Cabezas</author>
        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        public async Task<Response<bool>> Update(StudentDto student)
        {
            Response<bool> response;
            try
            {
                response = await Service.UpdateStudent(student);
                return response;
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }

        /// <summary>
        /// obtener estudiantes by id
        /// </summary>
        /// <returns>Response studentdto</returns>
        /// <author>Andres Cabezas</author>
        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(typeof(Response<StudentDto>), StatusCodes.Status200OK)]
        public async Task<Response<StudentDto>> GetById(int id)
        {
            Response<StudentDto> response;
            try
            {
                response = await Service.GetByIdStudent(id);
                return response;
            }
            catch (Exception ex)
            {
                return new Response<StudentDto>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }

        /// <summary>
        /// eliminar by id
        /// </summary>
        /// <returns>Response bool</returns>
        /// <author>Andres Cabezas</author>
        [HttpDelete]
        [Route("Delete")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        public async Task<Response<bool>> DeleteById(int id)
        {
            Response<bool> response;
            try
            {
                response = await Service.DeleteByIdStudent(id);
                return response;
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    Status = false,
                    Message = MessageExtension.AddMessageList(ex.Message)
                };
            }
        }
    }
}

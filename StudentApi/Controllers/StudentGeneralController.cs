using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GR.Service.Interface;
using Student.Repository;
using Microsoft.AspNetCore.Mvc;
using Student.Service.Interface;
using StudentApi.Logging;
using Student.Data;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    //[ServiceFilter(typeof(LoggingActionFilter))]
    public class StudentGeneralController : Controller
    {

        private readonly IStudentGeneralService _studentGeneral;

        private readonly IStudentGeneralServiceAsync _studentGeneralAsync;

        public StudentGeneralController(IStudentGeneralService studentGeneral, IStudentGeneralServiceAsync studentGeneralAsync)
        {
            _studentGeneral = studentGeneral;
            _studentGeneralAsync = studentGeneralAsync;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var requestId = ControllerContext.HttpContext.TraceIdentifier;
            var result = _studentGeneral.GetAllModel(requestId, null);
            return Ok(result); //result.Success ? (IActionResult)Ok(result) : BadRequest(result);

            //return new string[] { "value1", "value2" };
        }

        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var requestId = ControllerContext.HttpContext.TraceIdentifier;
        //    var result = await _studentGeneralAsync.GetAllAsync(requestId);
        //    return Ok(result); //result.Success ? (IActionResult)Ok(result) : BadRequest(result);

        //    //return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public IResponse Get(long id)
        {
            var requestId = ControllerContext.HttpContext.TraceIdentifier;
            var result = _studentGeneral.GetBy(requestId, x => x.StudentId == id, null);
            return result;   //.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }


        [HttpGet("GetByName/{name}")]
        public IResponse GetByName(string name)
        {
            var requestId = ControllerContext.HttpContext.TraceIdentifier;
            var result = _studentGeneral.GetBy(requestId, x => x.StudentName.Contains(name));
            return result;   //.Success ? (IActionResult)Ok(result) : BadRequest(result);
        }

        //POST api/values
        //[HttpPost]
        // public IResponse Post([FromBody] StudentGeneralModel value)
        // {
        //     if (ModelState.IsValid)
        //     {

        //         var requestId = ControllerContext.HttpContext.TraceIdentifier;
        //         var result = _studentGeneral.Add(requestId, value);
        //         return result;
        //     }

        //     return null;
        // }

        [HttpPost]
        public async Task<IResponse> Post([FromBody] StudentGeneralModel value)
        {
            if (ModelState.IsValid)
            {

                var requestId = ControllerContext.HttpContext.TraceIdentifier;
                var result = await _studentGeneralAsync.AddAsync(requestId, value);

                return result;

            }

            return null;
        }


        [HttpPut]
        public async Task<IResponse> Put([FromBody] StudentGeneralModel value)
        {
            if (ModelState.IsValid)
            {

                var requestId = ControllerContext.HttpContext.TraceIdentifier;
                var result = await _studentGeneralAsync.EditAsync(requestId, value);

                return result;

            }

            return null;
        }


        [HttpDelete("{id}")]
        public async Task<IResponse> Delete(long id)
        {
            if (ModelState.IsValid)
            {

                var requestId = ControllerContext.HttpContext.TraceIdentifier;
                //var value = await _studentGeneralAsync.GetSingleByAsync(requestId, );
                var result = await _studentGeneralAsync.DeleteAsync(requestId, x => x.StudentId == id);

                return result;

            }

            return null;
        }


        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var requestId = ControllerContext.HttpContext.TraceIdentifier;
        //    var result = await _studentGeneralAsync.GetAllAsync(requestId);
        //    return Ok(result); //result.Success ? (IActionResult)Ok(result) : BadRequest(result);

        //    //return new string[] { "value1", "value2" };
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

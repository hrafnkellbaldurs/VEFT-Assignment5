using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Http;
using CoursesAPI.Models;
using CoursesAPI.Services.DataAccess;
using CoursesAPI.Services.Services;

namespace CoursesAPI.Controllers
{
    [RoutePrefix("api/courses")]
    public class CoursesController : ApiController
    {
        private readonly CoursesServiceProvider _service;

        public CoursesController()
        {
            _service = new CoursesServiceProvider(new UnitOfWork<AppDataContext>());
        }

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetCoursesBySemester(string semester = null, int page = 1)
        {
            var language = this.Request.Headers.AcceptLanguage.First().ToString();
            return Ok(_service.GetCourseInstancesBySemester(language, semester, page));
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}/teachers")]
        public IHttpActionResult AddTeacher(int id, AddTeacherViewModel model)
        {
            var result = _service.AddTeacherToCourse(id, model);
            return Created("TODO", result);
        }
    }
}

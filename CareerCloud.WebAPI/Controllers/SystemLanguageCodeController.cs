using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CareerCloud.WebAPI.Controllers
{
    [RoutePrefix("api/careercloud/system/v1")]

    public class SystemLanguageCodeController : ApiController
    {
        private SystemLanguageCodeLogic _logic;

        public SystemLanguageCodeController()
        {
            var repo = new EFGenericRepository<SystemLanguageCodePoco>(false);

            _logic = new SystemLanguageCodeLogic(repo);

        }

        [HttpGet]
        [Route("languageCode/{languageId}")]
        [ResponseType(typeof(SystemLanguageCodePoco))]

        public IHttpActionResult GetSystemLanguageCode(String languageId)
        {
            SystemLanguageCodePoco poco = _logic.Get(languageId);
            if (poco == null)
            {
                return NotFound();
            }

            return Ok(poco);

        }
        [HttpGet]
        [Route("languageCode")]
        [ResponseType(typeof(List<SystemLanguageCodePoco>))]

        public IHttpActionResult GetAllSystemLanguageCode()
        {
            List<SystemLanguageCodePoco> result = _logic.GetAll();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }
        [HttpPost]
        [Route("languageCode")]
        public IHttpActionResult PostSystemLanguageCode
            ([FromBody] SystemLanguageCodePoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("languageCode")]
        public IHttpActionResult PutSystemLanguageCode
            ([FromBody] SystemLanguageCodePoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("languageCode")]
        public IHttpActionResult DeleteSystemLanguageCode
            ([FromBody] SystemLanguageCodePoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}

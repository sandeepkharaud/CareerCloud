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
    [RoutePrefix("api/careercloud/company/v1")]
    public class CompanyJobSkillController : ApiController
    {
        private CompanyJobSkillLogic _logic;

        public CompanyJobSkillController()
        {
            var repo = new EFGenericRepository<CompanyJobSkillPoco>(false);

            _logic = new CompanyJobSkillLogic(repo);

        }

        [HttpGet]
        [Route("jobSkill/{id}")]
        [ResponseType(typeof(CompanyJobSkillPoco))]

        public IHttpActionResult GetCompanyJobSkill(Guid id)
        {
            CompanyJobSkillPoco poco = _logic.Get(id);
            if (poco == null)
            {
                return NotFound();
            }

            return Ok(poco);

        }
        [HttpGet]
        [Route("jobSkill")]
        [ResponseType(typeof(List<CompanyJobSkillPoco>))]

        public IHttpActionResult GetAllCompanyJobSkill()
        {
            List<CompanyJobSkillPoco> result = _logic.GetAll();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }
        [HttpPost]
        [Route("jobSkill")]
        public IHttpActionResult PostCompanyJobSkill
            ([FromBody] CompanyJobSkillPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("jobSkill")]
        public IHttpActionResult PutCompanyJobSkill
            ([FromBody] CompanyJobSkillPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("jobSkill")]
        public IHttpActionResult DeleteCompanyJobSkill
            ([FromBody] CompanyJobSkillPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}

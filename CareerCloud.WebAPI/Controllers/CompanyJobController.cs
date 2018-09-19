﻿using CareerCloud.BusinessLogicLayer;
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
    public class CompanyJobController : ApiController
    {
        private CompanyJobLogic _logic;

        public CompanyJobController()
        {
            var repo = new EFGenericRepository<CompanyJobPoco>(false);

            _logic = new CompanyJobLogic(repo);

        }

        [HttpGet]
        [Route("job/{id}")]
        [ResponseType(typeof(CompanyJobPoco))]

        public IHttpActionResult GetCompanyJob(Guid id)
        {
            CompanyJobPoco poco = _logic.Get(id);
            if (poco == null)
            {
                return NotFound();
            }

            return Ok(poco);

        }
        [HttpGet]
        [Route("job")]
        [ResponseType(typeof(List<CompanyJobPoco>))]

        public IHttpActionResult GetAllCompanyJob()
        {
            List<CompanyJobPoco> result = _logic.GetAll();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }
        [HttpPost]
        [Route("job")]
        public IHttpActionResult PostCompanyJob
            ([FromBody] CompanyJobPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("job")]
        public IHttpActionResult PutCompanyJob
            ([FromBody] CompanyJobPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("job")]
        public IHttpActionResult DeleteCompanyJob
            ([FromBody] CompanyJobPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}

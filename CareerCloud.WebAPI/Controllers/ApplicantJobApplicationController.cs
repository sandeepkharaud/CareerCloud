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
    [RoutePrefix("api/careercloud/applicant/v1")]
    public class ApplicantJobApplicationController : ApiController
    {
        private ApplicantJobApplicationLogic _logic;

        public ApplicantJobApplicationController()
        {
            var repo = new EFGenericRepository<ApplicantJobApplicationPoco>(false);

            _logic = new ApplicantJobApplicationLogic(repo);

        }

        [HttpGet]
        [Route("jobApplication/{id}")]
        [ResponseType(typeof(ApplicantJobApplicationPoco))]

        public IHttpActionResult GetApplicantJobApplication(Guid id)
        {
            ApplicantJobApplicationPoco poco = _logic.Get(id);
            if (poco == null)
            {
                return NotFound();
            }

            return Ok(poco);

        }
        [HttpGet]
        [Route("jobApplication")]
        [ResponseType(typeof(List<ApplicantJobApplicationPoco>))]

        public IHttpActionResult GetAllApplicantJobApplication()
        {
            List<ApplicantJobApplicationPoco> result = _logic.GetAll();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }
        [HttpPost]
        [Route("jobApplication")]
        public IHttpActionResult PostApplicantJobApplication
            ([FromBody] ApplicantJobApplicationPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }

        [HttpPut]
        [Route("jobApplication")]
        public IHttpActionResult PutApplicantJobApplication
            ([FromBody] ApplicantJobApplicationPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("jobApplication")]
        public IHttpActionResult DeleteApplicantJobApplication
            ([FromBody] ApplicantJobApplicationPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;

namespace API.Controllers
{
    public class OrganizationsController : ApiController
    {
        private EntityConnection db = new EntityConnection();

        [Route("api/Organizations/StatisticPerMonth")]
        [HttpGet]
        public List<Statistics> Statistic()
        {
            List<Statistics> statistics = new List<Statistics>();
            DateTime curentime = DateTime.Now;
            for (int i = 1; i <= curentime.Month; i++)
            {
                int numberOfOrg = 0;
                DateTime from = new DateTime(curentime.Year, i, 1);
                DateTime to = new DateTime();
                if (from.Month == 12)
                    to = curentime;
                else
                    to = new DateTime(curentime.Year, i+1, 1);
                numberOfOrg = db.Organizations.Where(p => p.TimeCreate >= from && p.TimeCreate < to).Count();
                statistics.Add(new Statistics() { month = i, value = numberOfOrg });
            }
            return statistics;
        }

        [Route("api/Organizations/Remove")]
        [HttpPost]
        public IHttpActionResult Remove(int ID)
        {
            db.Organizations.Find(ID).Status = false;
            db.SaveChanges();
            return Ok("Remove success");
        }

        // GET: api/Organizations
        public IQueryable<Organization> GetOrganizations()
        {
            return db.Organizations;
        }

        // GET: api/Organizations/5
        [ResponseType(typeof(Organization))]
        public IHttpActionResult GetOrganization(int id)
        {
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return NotFound();
            }

            return Ok(organization);
        }

        // PUT: api/Organizations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrganization(int id, Organization organization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != organization.ID)
            {
                return BadRequest();
            }

            db.Entry(organization).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Organizations
        [ResponseType(typeof(Organization))]
        public IHttpActionResult PostOrganization(Organization organization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Organizations.Add(organization);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = organization.ID }, organization);
        }

        // DELETE: api/Organizations/5
        [ResponseType(typeof(Organization))]
        public IHttpActionResult DeleteOrganization(int id)
        {
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return NotFound();
            }

            db.Organizations.Remove(organization);
            db.SaveChanges();

            return Ok(organization);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrganizationExists(int id)
        {
            return db.Organizations.Count(e => e.ID == id) > 0;
        }
    }
}
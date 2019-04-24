using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;

namespace API.Controllers
{
    public class OrganizationMembersController : ApiController
    {
        private EntityConnection db = new EntityConnection();

        [Route("api/OrganizationMembers/Remove")]
        [HttpPost]
        public IHttpActionResult Remove(int ID)
        {
            db.OrganizationMembers.Find(ID).Status = false;
            db.SaveChanges();
            return Ok("Remove success");
        }
        // GET: api/OrganizationMembers
        public IQueryable<OrganizationMember> GetOrganizationMembers()
        {
            return db.OrganizationMembers;
        }

        // GET: api/OrganizationMembers/5
        [ResponseType(typeof(OrganizationMember))]
        public IHttpActionResult GetOrganizationMember(int id)
        {
            OrganizationMember organizationMember = db.OrganizationMembers.Find(id);
            if (organizationMember == null)
            {
                return NotFound();
            }

            return Ok(organizationMember);
        }

        /// Summary:
        ///     Api to get OrganizationMember by Username and Organization Name
        /// Parameters:
        ///     jObject: Json object contains 2 keys: UserName and OrgName
        [ResponseType(typeof(OrganizationMember))]
        [HttpPost]
        [Route("api/OrganizationMember")]
        public IHttpActionResult GetOrgMemberByOrgName(JObject jObject)
        {
            string username;
            string orgName;
            try
            {
                username = jObject[UrlParams.ParamUserName].Value<string>();
                orgName = jObject[UrlParams.ParamOrgName].Value<string>();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            Organization org = db.Organizations.Where(o => o.Name == orgName).FirstOrDefault<Organization>();
            Account account = db.Users.Where(u => u.UserName == username).FirstOrDefault<Account>();
            OrganizationMember orgMem = null;
            if (org != null)
            {
                orgMem = db.OrganizationMembers.Where(om => om.AccountID == account.Id && om.OrganizationID == org.ID).FirstOrDefault();
            }
            return Ok(orgMem);
        }

        // PUT: api/OrganizationMembers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrganizationMember(int id, OrganizationMember organizationMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != organizationMember.ID)
            {
                return BadRequest();
            }
            db.Entry(organizationMember).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationMemberExists(id))
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

        // POST: api/OrganizationMembers
        [ResponseType(typeof(OrganizationMember))]
        public IHttpActionResult PostOrganizationMember(OrganizationMember organizationMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrganizationMembers.Add(organizationMember);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = organizationMember.ID }, organizationMember);
        }

        // DELETE: api/OrganizationMembers/5
        [ResponseType(typeof(OrganizationMember))]
        public IHttpActionResult DeleteOrganizationMember(int id)
        {
            OrganizationMember organizationMember = db.OrganizationMembers.Find(id);
            if (organizationMember == null)
            {
                return NotFound();
            }

            db.OrganizationMembers.Remove(organizationMember);
            db.SaveChanges();

            return Ok(organizationMember);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrganizationMemberExists(int id)
        {
            return db.OrganizationMembers.Count(e => e.ID == id) > 0;
        }
    }
}
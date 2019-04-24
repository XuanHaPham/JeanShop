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
    public class EventVolunteerTypesController : ApiController
    {
        private EntityConnection db = new EntityConnection();

        [Route("api/EventVolunteerTypes/Remove")]
        [HttpPost]
        public IHttpActionResult Remove(int ID)
        {
            db.EventVolunteerTypes.Find(ID).Status = false;
            db.SaveChanges();
            return Ok("Remove success");
        }

        // GET: api/EventVolunteerTypes
        public IQueryable<EventVolunteerType> GetEventVolunteerTypes()
        {
            return db.EventVolunteerTypes;
        }

        // GET: api/EventVolunteerTypes/5
        [ResponseType(typeof(EventVolunteerType))]
        public IHttpActionResult GetEventVolunteerType(int id)
        {
            EventVolunteerType eventVolunteerType = db.EventVolunteerTypes.Find(id);
            if (eventVolunteerType == null)
            {
                return NotFound();
            }

            return Ok(eventVolunteerType);
        }

        // PUT: api/EventVolunteerTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEventVolunteerType(int id, EventVolunteerType eventVolunteerType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventVolunteerType.ID)
            {
                return BadRequest();
            }

            db.Entry(eventVolunteerType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventVolunteerTypeExists(id))
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

        // POST: api/EventVolunteerTypes
        [ResponseType(typeof(EventVolunteerType))]
        public IHttpActionResult PostEventVolunteerType(EventVolunteerType eventVolunteerType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EventVolunteerTypes.Add(eventVolunteerType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = eventVolunteerType.ID }, eventVolunteerType);
        }

        // DELETE: api/EventVolunteerTypes/5
        [ResponseType(typeof(EventVolunteerType))]
        public IHttpActionResult DeleteEventVolunteerType(int id)
        {
            EventVolunteerType eventVolunteerType = db.EventVolunteerTypes.Find(id);
            if (eventVolunteerType == null)
            {
                return NotFound();
            }

            db.EventVolunteerTypes.Remove(eventVolunteerType);
            db.SaveChanges();

            return Ok(eventVolunteerType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventVolunteerTypeExists(int id)
        {
            return db.EventVolunteerTypes.Count(e => e.ID == id) > 0;
        }
    }
}
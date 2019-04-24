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
    public class EventVolunteersController : ApiController
    {
        private EntityConnection db = new EntityConnection();

        [Route("api/EventVolunteers/Remove")]
        [HttpPost]
        public IHttpActionResult Remove(string ID)
        {
            db.EventVolunteers.Find(ID).Status = false;
            db.SaveChanges();
            return Ok("Remove success");
        }
        // GET: api/EventVolunteers
        public IQueryable<EventVolunteer> GetEventVolunteers()
        {
            return db.EventVolunteers;
        }

        // GET: api/EventVolunteers/5
        [ResponseType(typeof(EventVolunteer))]
        public IHttpActionResult GetEventVolunteer(int id)
        {
            EventVolunteer eventVolunteer = db.EventVolunteers.Find(id);
            if (eventVolunteer == null)
            {
                return NotFound();
            }

            return Ok(eventVolunteer);
        }

        // PUT: api/EventVolunteers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEventVolunteer(int id, EventVolunteer eventVolunteer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventVolunteer.ID)
            {
                return BadRequest();
            }

            db.Entry(eventVolunteer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventVolunteerExists(id))
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

        // POST: api/EventVolunteers
        [ResponseType(typeof(EventVolunteer))]
        public IHttpActionResult PostEventVolunteer(EventVolunteer eventVolunteer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EventVolunteers.Add(eventVolunteer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = eventVolunteer.ID }, eventVolunteer);
        }

        // DELETE: api/EventVolunteers/5
        [ResponseType(typeof(EventVolunteer))]
        public IHttpActionResult DeleteEventVolunteer(int id)
        {
            EventVolunteer eventVolunteer = db.EventVolunteers.Find(id);
            if (eventVolunteer == null)
            {
                return NotFound();
            }

            db.EventVolunteers.Remove(eventVolunteer);
            db.SaveChanges();

            return Ok(eventVolunteer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventVolunteerExists(int id)
        {
            return db.EventVolunteers.Count(e => e.ID == id) > 0;
        }
    }
}
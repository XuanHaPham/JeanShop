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
    public class EventTypesController : ApiController
    {
        private EntityConnection db = new EntityConnection();

        // GET: api/EventTypes
        public IQueryable<EventType> GetEventTypes()
        {
            return db.EventTypes;
        }

        [Route("api/EventTypes/Remove")]
        [HttpPost]
        public IHttpActionResult Remove(int ID)
        {
            db.EventTypes.Find(ID).Status = false;
            db.SaveChanges();
            return Ok("Remove success");
        }
        // GET: api/EventTypes/5
        [ResponseType(typeof(EventType))]
        public IHttpActionResult GetEventType(int id)
        {
            EventType eventType = db.EventTypes.Find(id);
            if (eventType == null)
            {
                return NotFound();
            }

            return Ok(eventType);
        }

        // PUT: api/EventTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEventType(int id, EventType eventType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventType.ID)
            {
                return BadRequest();
            }

            db.Entry(eventType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventTypeExists(id))
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

        // POST: api/EventTypes
        [ResponseType(typeof(EventType))]
        public IHttpActionResult PostEventType(EventType eventType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EventTypes.Add(eventType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = eventType.ID }, eventType);
        }

        // DELETE: api/EventTypes/5
        [ResponseType(typeof(EventType))]
        public IHttpActionResult DeleteEventType(int id)
        {
            EventType eventType = db.EventTypes.Find(id);
            if (eventType == null)
            {
                return NotFound();
            }

            db.EventVolunteerTypes.RemoveRange(db.EventVolunteerTypes.Where(t => t.EventTypeID == id));
            db.EventTypes.Remove(eventType);
            db.SaveChanges();

            return Ok(eventType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventTypeExists(int id)
        {
            return db.EventTypes.Count(e => e.ID == id) > 0;
        }
    }
}
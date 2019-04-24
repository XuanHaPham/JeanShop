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
    public class EventCommentsController : ApiController
    {
        private EntityConnection db = new EntityConnection();

        // GET: api/EventComments
        public IQueryable<EventComment> GetEventComments()
        {
            return db.EventComments;
        }


        [Route("api/EventComments/Remove")]
        [HttpPost]
        public IHttpActionResult Remove(int ID)
        {
            db.EventComments.Find(ID).Status = false;
            db.SaveChanges();
            return Ok("Remove success");
        }

        // GET: api/EventComments/5
        // id is the Event id, not EventComment id
        [ResponseType(typeof(IQueryable<EventComment>))]
        public IHttpActionResult GetEventComment(int id)
        {
            IQueryable<EventComment> eventComment = db.EventComments.Where(c => c.EventID == id);
            return Ok(eventComment);
        }

        // PUT: api/EventComments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEventComment(int id, EventComment eventComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventComment.ID)
            {
                return BadRequest();
            }

            db.Entry(eventComment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventCommentExists(id))
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

        // POST: api/EventComments
        [ResponseType(typeof(EventComment))]
        public IHttpActionResult PostEventComment(EventComment eventComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EventComments.Add(eventComment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = eventComment.ID }, eventComment);
        }

        // DELETE: api/EventComments/5
        [ResponseType(typeof(EventComment))]
        public IHttpActionResult DeleteEventComment(int id)
        {
            EventComment eventComment = db.EventComments.Find(id);
            if (eventComment == null)
            {
                return NotFound();
            }

            db.EventComments.Remove(eventComment);
            db.SaveChanges();

            return Ok(eventComment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventCommentExists(int id)
        {
            return db.EventComments.Count(e => e.ID == id) > 0;
        }
    }
}
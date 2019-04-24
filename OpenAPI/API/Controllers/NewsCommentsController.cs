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
    public class NewsCommentsController : ApiController
    {
        private EntityConnection db = new EntityConnection();

        [Route("api/NewsComments/Remove")]
        [HttpPost]
        public IHttpActionResult Remove(int ID)
        {
            db.NewsComments.Find(ID).Status = false;
            db.SaveChanges();
            return Ok("Remove success");
        }

        // GET: api/NewsComments
        public IQueryable<NewsComment> GetNewsComments()
        {
            return db.NewsComments;
        }

        // GET: api/NewsComments/5
        [ResponseType(typeof(NewsComment))]
        public IHttpActionResult GetNewsComment(int id)
        {
            NewsComment newsComment = db.NewsComments.Find(id);
            if (newsComment == null)
            {
                return NotFound();
            }

            return Ok(newsComment);
        }

        // PUT: api/NewsComments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNewsComment(int id, NewsComment newsComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newsComment.ID)
            {
                return BadRequest();
            }

            db.Entry(newsComment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsCommentExists(id))
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

        // POST: api/NewsComments
        [ResponseType(typeof(NewsComment))]
        public IHttpActionResult PostNewsComment(NewsComment newsComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NewsComments.Add(newsComment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = newsComment.ID }, newsComment);
        }

        // DELETE: api/NewsComments/5
        [ResponseType(typeof(NewsComment))]
        public IHttpActionResult DeleteNewsComment(int id)
        {
            NewsComment newsComment = db.NewsComments.Find(id);
            if (newsComment == null)
            {
                return NotFound();
            }

            db.NewsComments.Remove(newsComment);
            db.SaveChanges();

            return Ok(newsComment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NewsCommentExists(int id)
        {
            return db.NewsComments.Count(e => e.ID == id) > 0;
        }
    }
}
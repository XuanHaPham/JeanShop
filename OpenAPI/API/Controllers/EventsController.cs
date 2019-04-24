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
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace API.Controllers
{
    public class EventsController : ApiController
    {
        private EntityConnection db = new EntityConnection();

        [Route("api/Events/Remove")]
        [HttpPost]
        public IHttpActionResult Remove(int ID)
        {
            db.Events.Find(ID).Status = false;
            db.SaveChanges();
            return Ok("Remove success");
        }

        [Route("api/Events/StatisticPerMonth")]
        [HttpGet]
        public List<Statistics> Statistic()
        {
            List<Statistics> statistics = new List<Statistics>();
            DateTime curentime =  DateTime.Now;
            int numberOfEven = 0;
            for(int i = 1; i <= curentime.Month; i++)
            {
                DateTime from = new DateTime(curentime.Year, i, 1 );
                DateTime to = new DateTime();
                if (from.Month == 12)
                     to = curentime;
                else
                    to = new DateTime(curentime.Year, i+1, 1 );
                numberOfEven = db.Events.Where(p => p.TimeCreated >= from && p.TimeCreated < to).Count();
                statistics.Add(new Statistics() { month = i, value = numberOfEven });
            }
            return statistics;
        }

        //Get: List event by search params 
        
        [Route("api/Events/EventListBySearch")]
        [HttpGet]
        public List<Event> EventListBySearch(string keyword, double latitude, double longitude, List<int> typesID, int limit)
        {
            List<Event> result = new List<Event>();
            List<int> eventIDList = new List<int>();
            List<int> distance = new List<int>();
           
            foreach (var item in typesID)
            {
                List<EventVolunteerType> eventVolunteerTypeList = db.EventVolunteerTypes.Where(p => p.Status.GetValueOrDefault(true) && p.EventTypeID == item && !eventIDList.Contains(p.EventID)).ToList();
                foreach (var eventType in eventVolunteerTypeList)
                {
                    eventIDList.Add(eventType.EventID);
                }
            }
            foreach (var item in eventIDList)
            {
                result.Add(db.Events.Where(p => p.Status.GetValueOrDefault(true) && p.ID == item && p.Title.Contains(keyword)).FirstOrDefault());
            }

            if (longitude != 0 && latitude != 0)
            {
                for (int i = 0; i < result.Count - 2; i++)
                {
                    for (int j = 1; j < result.Count - 1; j++)
                    {
                        double dist1 = calculateDistance(latitude, longitude, result[i].Latitude, result[i].Longitude, "K");
                        double dist2 = calculateDistance(latitude, longitude, result[j].Latitude, result[j].Longitude, "K");
                        if (dist1 > dist2)
                        {
                            Event tmp = result[i];
                            result[i] = result[j];
                            result[j] = tmp;
                        }
                    }
                }
            }
            if (limit > result.Count)
                limit = result.Count;
            if (limit == 0 && db.Configurations.Where(p => p.Key.Equals("limit")).FirstOrDefault() != null)
            {
                var tmpLimit = db.Configurations.Where(p => p.Key.Equals("limit")).FirstOrDefault().Value;
                limit = Int32.Parse(tmpLimit);
               
            }
            if (limit != 0)

                result = result.GetRange(0, limit-1);
            else
                if(result.Count< 10)
                result = result.GetRange(0, result.Count);
            return result;
        }

        private double calculateDistance(double lat1, double lon1, double lat2, double lon2, string unit)
        {
            var radlat1 = Math.PI * lat1 / 180;
            var radlat2 = Math.PI * lat2 / 180;
            var radlon1 = Math.PI * lon1 / 180;
            var radlon2 = Math.PI * lon2 / 180;
            var theta = lon1 - lon2;
            var radtheta = Math.PI * theta / 180;
            var dist = Math.Sin(radlat1) * Math.Sin(radlat2) + Math.Cos(radlat1) * Math.Cos(radlat2) * Math.Cos(radtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;
            if (unit == "K") { dist = dist * 1.609344; }
            if (unit == "N") { dist = dist * 0.8684; }
            return dist;
}

        // GET: api/Events
        public IQueryable<Event> GetEvents()
        {
            return db.Events;
        }

        // GET: api/Events/5
        [ResponseType(typeof(Event))]
        public IHttpActionResult GetEvent(int id)
        {
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        // PUT: api/Events/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEvent(int id, Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @event.ID)
            {
                return BadRequest();
            }

            db.EventVolunteerTypes.RemoveRange(db.EventVolunteerTypes.Where(e => e.EventID == @event.ID));
            db.EventVolunteerTypes.AddRange(@event.EventVolunteerTypes);
            db.Entry(@event).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        // POST: api/Events
        [ResponseType(typeof(Event))]
        public IHttpActionResult PostEvent(Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Events.Add(@event);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = @event.ID }, @event);
        }

        // DELETE: api/Events/5
        [ResponseType(typeof(Event))]
        public IHttpActionResult DeleteEvent(int id)
        {
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return NotFound();
            }

            db.Events.Remove(@event);
            db.SaveChanges();

            return Ok(@event);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventExists(int id)
        {
            return db.Events.Count(e => e.ID == id) > 0;
        }
    }
}
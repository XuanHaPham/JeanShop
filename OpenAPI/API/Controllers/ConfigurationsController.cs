using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;
using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;

namespace API.Controllers
{
    public class ConfigurationsController : ApiController
    {
        private EntityConnection db = new EntityConnection();
        static List<PerformanceCounter> counters = new List<PerformanceCounter>();

        static ConfigurationsController()
        {
            try
            {
                var category = new PerformanceCounterCategory("Processor");
                var instances = category.GetInstanceNames();
                foreach (var instance in instances)
                {
                    foreach (var counter in category.GetCounters(instance))
                    {
                        counters.Add(counter);
                        counter.NextValue();
                    }
                }
            }
            catch (System.Exception) {}
        }

        // GET: api/Configurations
        public IQueryable<Configuration> GetConfigurations()
        {
            return db.Configurations;
        }

        // GET: api/Configurations/5
        [ResponseType(typeof(Configuration))]
        public IHttpActionResult GetConfiguaration(int id)
        {
            Configuration configuaration = db.Configurations.Find(id);
            if (configuaration == null)
            {
                return NotFound();
            }

            return Ok(configuaration);
        }

        // PUT: api/Configurations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConfiguaration(int id, Configuration configuaration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != configuaration.ID)
            {
                return BadRequest();
            }

            db.Entry(configuaration).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfiguarationExists(id))
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

        // POST: api/Configurations
        [ResponseType(typeof(Configuration))]
        public IHttpActionResult PostConfiguaration(Configuration configuaration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Configurations.Add(configuaration);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = configuaration.ID }, configuaration);
        }

        // DELETE: api/Configurations/5
        [ResponseType(typeof(Configuration))]
        public IHttpActionResult DeleteConfiguaration(int id)
        {
            Configuration configuaration = db.Configurations.Find(id);
            if (configuaration == null)
            {
                return NotFound();
            }

            db.Configurations.Remove(configuaration);
            db.SaveChanges();

            return Ok(configuaration);
        }

        [Route("api/SystemResources")]
        public object GetSystemResources()
        {
            var memory = new ComputerInfo();
            var cpu = new Dictionary<string, Dictionary<string, float>>();
            if (counters.Count > 0)
            {
                foreach (var counter in counters)
                {
                    if (!cpu.ContainsKey(counter.InstanceName))
                    {
                        cpu.Add(counter.InstanceName, new Dictionary<string, float>());
                    }
                    cpu[counter.InstanceName].Add(counter.CounterName, counter.NextValue());
                }
            }
            var disks = new List<object>();
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    disks.Add(new
                    {
                        drive.Name,
                        drive.AvailableFreeSpace,
                        drive.DriveFormat,
                        drive.DriveType,
                        drive.IsReady,
                        drive.RootDirectory,
                        drive.TotalFreeSpace,
                        drive.TotalSize,
                        drive.VolumeLabel
                    });
                }
            }
            var networks = new List<object>();
            foreach (NetworkInterface info in NetworkInterface.GetAllNetworkInterfaces())
            {
                var statistics = info.GetIPv4Statistics();
                networks.Add(new {
                    info,
                    statistics
                });
            }
            return new { memory, cpu, disks, networks};
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConfiguarationExists(int id)
        {
            return db.Configurations.Count(e => e.ID == id) > 0;
        }
    }
}
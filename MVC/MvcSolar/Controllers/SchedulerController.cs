using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


using Microsoft.EntityFrameworkCore;
using MvcSolar.Data;
using MvcSolar.Models;

namespace MvcSolar.Controllers
{
    public class SchedulerController : ApiController
    {



        private MvcSolarContext db;

        public SchedulerController(MvcSolarContext context)
        {
            db = context;
        }


        // GET: api/scheduler
        public IEnumerable<WebAPIEvent> Get()
        {
            return db.Eventos
                .ToList()
                .Select(e => (WebAPIEvent)e);
        }

        
        // GET: api/scheduler/5
        public WebAPIEvent Get(int id)
        {
            return (WebAPIEvent)db.Eventos.Find(id);
        }
        
        // PUT: api/scheduler/5
        [HttpPut]
        public IHttpActionResult EditSchedulerEvent(int id, WebAPIEvent webAPIEvent)
        {
            var updatedSchedulerEvent = (Evento)webAPIEvent;
            updatedSchedulerEvent.EventoId = id;
            db.Entry(updatedSchedulerEvent).State = EntityState.Modified;
            db.SaveChanges();

            return Ok(new
            {
                action = "updated"
            });
        }

        // POST: api/scheduler/5
        [HttpPost]
        public IHttpActionResult CreateSchedulerEvent(WebAPIEvent webAPIEvent)
        {
            var newSchedulerEvent = (Evento)webAPIEvent;
            db.Eventos.Add(newSchedulerEvent);
            db.SaveChanges();

            return Ok(new
            {
                tid = newSchedulerEvent.EventoId,
                action = "inserted"
            });
        }

        // DELETE: api/scheduler/5
        [HttpDelete]
        public IHttpActionResult DeleteSchedulerEvent(int id)
        {
            var schedulerEvent = db.Eventos.Find(id);
            if (schedulerEvent != null)
            {
                db.Eventos.Remove(schedulerEvent);
                db.SaveChanges();
            }

            return Ok(new
            {
                action = "deleted"
            });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
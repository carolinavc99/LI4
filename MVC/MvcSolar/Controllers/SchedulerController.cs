using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using MvcSolar.Data;
using MvcSolar.Models;
using EntityState = System.Data.Entity.EntityState;

namespace MvcSolar.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class SchedulerController : ApiController
    {
        private readonly MvcSolarContext _context;

        public SchedulerController(MvcSolarContext context)
        {
            _context = context;
        }

        // GET: api/SchedulerController
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IEnumerable<WebAPIEvent> GetEventos()
        {
            return _context.Eventos.ToList().Select(e => (WebAPIEvent) e);
            ;
        }

        // GET: api/SchedulerController/5
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public WebAPIEvent GetEvento(int id)
        {
            return (WebAPIEvent) _context.Eventos.Find(id);
        }

        // PUT: api/SchedulerController/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Microsoft.AspNetCore.Mvc.HttpPut("{id}")]
        public IHttpActionResult PutEvento(int id, WebAPIEvent evento)
        {
            var updatedSchedulerEvent = (Evento) evento;
            updatedSchedulerEvent.EventoId = id;
            _context.Entry(updatedSchedulerEvent).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(new {action = "updated"});
        }

        // POST: api/SchedulerController
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IHttpActionResult PostEvento(WebAPIEvent webAPIEvent)
        {
            var newSchedulerEvent = (Evento) webAPIEvent;
            _context.Eventos.Add(newSchedulerEvent);
            _context.SaveChanges();

            return Ok(new
            {
                tid = newSchedulerEvent.EventoId,
                action = "inserted"
            });
        }

        // DELETE: api/SchedulerController/5
        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
        public IHttpActionResult DeleteSchedulerEvent(int id)
        {
            var schedulerEvent = _context.Eventos.Find(id);
            if (schedulerEvent != null)
            {
                _context.Eventos.Remove(schedulerEvent);
                _context.SaveChanges();
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
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventoExists(int id)
        {
            return _context.Eventos.Any(e => e.EventoId == id);
        }
    }
}
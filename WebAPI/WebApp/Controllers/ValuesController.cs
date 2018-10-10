using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;


namespace WebApp.Controllers
{
    [Route("api/values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DeviceContext _context;

        public ValuesController(DeviceContext context)
        {
            _context = context;
            if (_context.DeviceInfos.Count() == 0)
            {
                _context.DeviceInfos.Add(new DeviceInfo { Rssi = -57, DeviceId = 1,
                    Sequence = 98543, StationId = 2, TimeStamp = DateTime.Now.ToLocalTime()});
                _context.SaveChanges();
            }
        }
        
        // GET api/values
        [HttpGet]
        public ActionResult<List<DeviceInfo>> GetAll()
        {
            var temp = from p in _context.DeviceInfos
                       group p by p.DeviceId into dt
                       select dt.OrderByDescending(p => p.Sequence).FirstOrDefault(); 
            ActionResult <List<DeviceInfo>> ar = new ActionResult<List<DeviceInfo>>(temp.ToList());
            return ar;
        }
        // GET api/values/5
        [HttpGet("{id}", Name = "GetDevice")]
        public ActionResult<DeviceInfo> GetById(int id)
        {
            var item = _context.DeviceInfos.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(DeviceInfo device)
        {
            if (device != null)
              device.TimeStamp = DateTime.Now.ToLocalTime();
            _context.DeviceInfos.Add(device);
            _context.SaveChanges();
            return CreatedAtRoute("GetDevice", new { id = device.DeviceId}, device);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, DeviceInfo device)
        {
            var dev = _context.DeviceInfos.Find(id);
            if (dev == null)
                return NotFound();
            dev.Rssi = device.Rssi;
            _context.DeviceInfos.Update(dev);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var dev = _context.DeviceInfos.Find(id);
            if (dev == null)
                return NotFound();
            _context.DeviceInfos.Remove(dev);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

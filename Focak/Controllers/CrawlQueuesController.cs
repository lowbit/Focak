using AutoMapper;
using Focak.Data;
using Focak.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Focak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrawlQueuesController : ControllerBase
    {
        private readonly FocakContext _context;
        private readonly IMapper _mapper;
        public CrawlQueuesController(FocakContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.CrawlQueues.OrderByDescending(x=>x.Id).ToList());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var entity = _context.CrawlQueues.Find(id);
            if (entity == null)
                return NotFound(entity);
            return Ok(entity);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] CrawlQueueDto value)
        {
            CrawlQueue entity = new();
            _mapper.Map(value, entity);
            _context.CrawlQueues.Add(entity);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), entity);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CrawlQueueDto value)
        {
            var entity = _context.CrawlQueues.Find(id);
            if(entity == null)
                return NotFound(entity);
            _mapper.Map(value, entity);
            entity.Modified = DateTime.Now;
            _context.CrawlQueues.Update(entity);
            _context.SaveChanges();
            return Ok(entity);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _context.CrawlQueues.Find(id);
            if (entity == null)
                return NotFound();
            _context.CrawlQueues.Remove(entity);
            _context.SaveChanges();
            return Ok();
        }
    }
}

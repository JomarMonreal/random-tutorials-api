using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomTutorialsAPI.Context;
using RandomTutorialsAPI.Models;

namespace RandomTutorialsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagTutorialMappingsController : ControllerBase
    {
        private readonly RandomTutorialsContext _context;

        public TagTutorialMappingsController(RandomTutorialsContext context)
        {
            _context = context;
        }

        // GET: api/TagTutorialMappings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagTutorialMapping>>> GetTagTutorialMapping()
        {
            return await _context.TagTutorialMapping.ToListAsync();
        }

        // GET: api/TagTutorialMappings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TagTutorialMapping>> GetTagTutorialMapping(int id)
        {
            var tagTutorialMapping = await _context.TagTutorialMapping.FindAsync(id);

            if (tagTutorialMapping == null)
            {
                return NotFound();
            }

            return tagTutorialMapping;
        }

        // PUT: api/TagTutorialMappings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTagTutorialMapping(int id, TagTutorialMapping tagTutorialMapping)
        {
            if (id != tagTutorialMapping.Id)
            {
                return BadRequest();
            }

            _context.Entry(tagTutorialMapping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagTutorialMappingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TagTutorialMappings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TagTutorialMapping>> PostTagTutorialMapping(TagTutorialMapping tagTutorialMapping)
        {
            _context.TagTutorialMapping.Add(tagTutorialMapping);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTagTutorialMapping", new { id = tagTutorialMapping.Id }, tagTutorialMapping);
        }

        // DELETE: api/TagTutorialMappings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTagTutorialMapping(int id)
        {
            var tagTutorialMapping = await _context.TagTutorialMapping.FindAsync(id);
            if (tagTutorialMapping == null)
            {
                return NotFound();
            }

            _context.TagTutorialMapping.Remove(tagTutorialMapping);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TagTutorialMappingExists(int id)
        {
            return _context.TagTutorialMapping.Any(e => e.Id == id);
        }
    }
}

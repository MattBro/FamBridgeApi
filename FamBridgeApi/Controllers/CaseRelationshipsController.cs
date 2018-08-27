using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FamBridgeApi.Models;

namespace FamBridgeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseRelationshipsController : ControllerBase
    {
        private readonly FamBridgeContext _context;

        public CaseRelationshipsController(FamBridgeContext context)
        {
            _context = context;
        }

        // GET: api/CaseRelationships
        [HttpGet]
        public IEnumerable<CaseRelationship> GetCaseRelationship()
        {
            return _context.CaseRelationship;
        }

        [HttpGet]
        [Route("GetCaseRelationshipsForUser/{id}")]
        public IEnumerable<CaseRelationship> GetCaseRelationshipsForUser([FromRoute] long id)
        {

            var caseRelationships = _context.CaseRelationship.Where(caseRelationshipSearch => caseRelationshipSearch.userId == id);
            
            return caseRelationships;
        }


        // GET: api/CaseRelationships/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCaseRelationship([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var caseRelationship = await _context.CaseRelationship.FindAsync(id);

            if (caseRelationship == null)
            {
                return NotFound();
            }

            return Ok(caseRelationship);
        }

        // PUT: api/CaseRelationships/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaseRelationship([FromRoute] long id, [FromBody] CaseRelationship caseRelationship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != caseRelationship.Id)
            {
                return BadRequest();
            }

            _context.Entry(caseRelationship).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseRelationshipExists(id))
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

        // POST: api/CaseRelationships
        [HttpPost]
        public async Task<IActionResult> PostCaseRelationship([FromBody] CaseRelationship caseRelationship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CaseRelationship.Add(caseRelationship);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaseRelationship", new { id = caseRelationship.Id }, caseRelationship);
        }

        // DELETE: api/CaseRelationships/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaseRelationship([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var caseRelationship = await _context.CaseRelationship.FindAsync(id);
            if (caseRelationship == null)
            {
                return NotFound();
            }

            _context.CaseRelationship.Remove(caseRelationship);
            await _context.SaveChangesAsync();

            return Ok(caseRelationship);
        }

        private bool CaseRelationshipExists(long id)
        {
            return _context.CaseRelationship.Any(e => e.Id == id);
        }
    }
}
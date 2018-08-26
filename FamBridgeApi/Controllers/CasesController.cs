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
    public class CasesController : ControllerBase
    {
        private readonly FamBridgeContext _context;

        public CasesController(FamBridgeContext context)
        {
            _context = context;
        }

        // GET: api/Cases
        [HttpGet]
        public IEnumerable<Case> GetCases()
        {
            return _context.Cases;
        }

        // GET: api/Cases/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCase([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @case = await _context.Cases.FindAsync(id);

            if (@case == null)
            {
                return NotFound();
            }

            return Ok(@case);
        }

        // PUT: api/Cases/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCase([FromRoute] long id, [FromBody] Case @case)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @case.Id)
            {
                return BadRequest();
            }

            _context.Entry(@case).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseExists(id))
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

        // POST: api/Cases
        [HttpPost]
        public async Task<IActionResult> PostCase([FromBody] Case @case)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cases.Add(@case);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCase", new { id = @case.Id }, @case);
        }

        // DELETE: api/Cases/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCase([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @case = await _context.Cases.FindAsync(id);
            if (@case == null)
            {
                return NotFound();
            }

            _context.Cases.Remove(@case);
            await _context.SaveChangesAsync();

            return Ok(@case);
        }

        private bool CaseExists(long id)
        {
            return _context.Cases.Any(e => e.Id == id);
        }
    }
}
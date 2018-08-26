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
    public class CaseTokensController : ControllerBase
    {
        private readonly FamBridgeContext _context;

        public CaseTokensController(FamBridgeContext context)
        {
            _context = context;
        }

        // GET: api/CaseTokens
        [HttpGet]
        public IEnumerable<CaseToken> GetCaseToken()
        {
            return _context.CaseToken;
        }

        
        [HttpGet]
        [Route("GetCaseTokenByToken/{token}")]
        public async Task<IActionResult> GetCaseTokenByToken([FromRoute] string token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var caseToken = _context.CaseToken.Where(findCaseToken => findCaseToken.Token == token);

            if (!caseToken.Any())
            {
                return NotFound();
            }

            return Ok(caseToken.Single());
        }

        // GET: api/CaseTokens/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCaseToken([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var caseToken = await _context.CaseToken.FindAsync(id);

            if (caseToken == null)
            {
                return NotFound();
            }

            return Ok(caseToken);
        }

        // PUT: api/CaseTokens/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaseToken([FromRoute] long id, [FromBody] CaseToken caseToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != caseToken.Id)
            {
                return BadRequest();
            }

            _context.Entry(caseToken).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseTokenExists(id))
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

        // POST: api/CaseTokens
        [HttpPost]
        public async Task<IActionResult> PostCaseToken([FromBody] CaseToken caseToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CaseToken.Add(caseToken);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaseToken", new { id = caseToken.Id }, caseToken);
        }

        // DELETE: api/CaseTokens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCaseToken([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var caseToken = await _context.CaseToken.FindAsync(id);
            if (caseToken == null)
            {
                return NotFound();
            }

            _context.CaseToken.Remove(caseToken);
            await _context.SaveChangesAsync();

            return Ok(caseToken);
        }

        private bool CaseTokenExists(long id)
        {
            return _context.CaseToken.Any(e => e.Id == id);
        }
    }
}
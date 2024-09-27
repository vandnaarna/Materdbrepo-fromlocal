using MasterdbAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;

namespace MasterdbAPI.Controllers
{
    public class MasterController : ControllerBase
    {
        private readonly EmpinfoContext _dbcontext;
        public MasterController(EmpinfoContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet("{city}")]
        public async Task<ActionResult<Master>> GetMasters(string city)
        {


            var x = await _dbcontext.Masters.FirstOrDefaultAsync(x => x.City == city);
            if (x == null)
            {
                return NotFound();
            }
            return x;
        }
        [HttpPost("{Pid}")]
        public async Task<ActionResult<Master>> PostMasters(Master x)
        {
            _dbcontext.Masters.Add(x);
            await _dbcontext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMasters), new { pid = x.Pid }, x);

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Master>> PutMasters(int id, Master x)
        {
            if (id != x.Pid)
            {
                return BadRequest(" id Mismatch");
            }
            _dbcontext.Entry(x).State = EntityState.Modified;
            try
            {
                await _dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MastersAvailable(id))
                {
                    return NotFound("Master with id {Pid} not found");
                }
                else
                {
                    throw;
                }
            }
            return Ok(x);
        }
        private bool MastersAvailable(int pid)
        {
            return (_dbcontext.Masters?.Any(x => x.Pid == pid)).GetValueOrDefault();
        }
        [HttpDelete("id")]
        public async Task<ActionResult<Master>> DeleteMasters(int id)
        {
            if (_dbcontext.Masters == null)
            {
                return NotFound();
            }
            var y = await _dbcontext.Masters.FindAsync(id);
            if (y == null)
            {
                return NotFound();
            }
            _dbcontext.Masters.Remove(y);
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult>PatchMasters(int id,[FromBody] 
          JsonPatchDocument<Master>patchDoc)
        {
            if(patchDoc == null)
            {
                return BadRequest("Invalid patch document.");
            }

            var  exist= await _dbcontext.Masters.FindAsync(id);
            if(exist == null)
            {
                return NotFound();
            }
            patchDoc.ApplyTo(exist,ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MastersAvailable(id))
                {
                    return NotFound("Master with id {Pid} not found");
                }
                else
                {
                    throw;
                }
            }
            return Ok(exist);
            //private bool MastersAvailable(int pid)
            //{
            //    return (_dbcontext.Masters?.Any(x => x.Pid ==id)).GetValueOrDefault();
            //}
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data.Repositories;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnoucementsController : ControllerBase
    {
        private readonly IAnnoucementRepository _repo;

        public AnnoucementsController(IAnnoucementRepository repo)
        {
            _repo = repo;
        }
        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var annoucements = await _repo.GetAll().Include(a => a.Category).ToListAsync();
            return Ok(annoucements);
        }        
        
        [HttpGet]
        [Route("user/{id}")]
        public async Task<IActionResult> GetAllFromUser([FromRoute]int id)
        {
            var annoucements = await _repo.GetAll()
                .Include(a => a.Category)
                //.Include(u => u.User)
                .Where(u => u.UserId == id)
                .ToListAsync();

            return Ok(annoucements);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var annoucement = await _repo.GetById(id);
            if (annoucement == null) 
            { 
                return NotFound();
            }
            return Ok(annoucement);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Annoucement annoucement)
        {

            await _repo.Create(annoucement);
            await _repo.Save();
            return CreatedAtAction("GetById", new { id = annoucement.AnnoucementId }, annoucement);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            await _repo.Delete(id);
            await _repo.Save();
            return Ok();
        }

        [HttpDelete]
        [Route("user/{id}")]
        public async Task<IActionResult> DeleteAllFromUser(int id)
        {
            var count = await _repo.DeleteAllFromUser(id);
            return Ok(count);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Annoucement annoucement)
        {
            await _repo.Update(annoucement);
            await _repo.Save();
            return Ok();
        }



    }
}
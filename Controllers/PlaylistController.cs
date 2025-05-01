
using Microsoft.AspNetCore.Mvc;
using MusicApp1.Data;
using MusicApp1.Models;

namespace Core_Task_SoftServe.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class PlaylistController : ControllerBase
    {
        private MusicApp1Context ctx;


        public PlaylistController()
        {
            ctx = new();
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(ctx.Playlists.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = ctx.Playlists.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(Playlist model)
        {
            ctx.Playlists.Add(model);
            ctx.SaveChanges();
            return Created();
        }

        [HttpPut]
        public IActionResult Edit(Playlist model)
        {
            ctx.Playlists.Update(model);
            ctx.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = ctx.Playlists.Find(id);
            if (item == null) return NotFound();
            ctx.Playlists.Remove(item);
            ctx.SaveChanges();
            return NoContent();
        }
    }
}

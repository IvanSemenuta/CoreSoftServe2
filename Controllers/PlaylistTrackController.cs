
using Microsoft.AspNetCore.Mvc;
using MusicApp1.Data;
using MusicApp1.Models;

namespace Core_Task_SoftServe.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class PlaylistTrackController : ControllerBase
    {
        private MusicApp1Context ctx;


        public PlaylistTrackController()
        {
            ctx = new();
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(ctx.PlaylistTracks.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = ctx.PlaylistTracks.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(PlaylistTrack model)
        {
            ctx.PlaylistTracks.Add(model);
            ctx.SaveChanges();
            return Created();
        }

        [HttpPut]
        public IActionResult Edit(PlaylistTrack model)
        {
            ctx.PlaylistTracks.Update(model);
            ctx.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = ctx.PlaylistTracks.Find(id);
            if (item == null) return NotFound();
            ctx.PlaylistTracks.Remove(item);
            ctx.SaveChanges();
            return NoContent();
        }
    }
}

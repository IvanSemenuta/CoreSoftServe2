
using Microsoft.AspNetCore.Mvc;
using MusicApp1.Data;
using MusicApp1.Models;

namespace Core_Task_SoftServe.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ReviewController : ControllerBase
    {
        private MusicApp1Context ctx;


        public ReviewController()
        {
            ctx = new();
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(ctx.Reviews.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = ctx.Reviews.Find(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(Review model)
        {
            ctx.Reviews.Add(model);
            ctx.SaveChanges();
            return Created();
        }

        [HttpPut]
        public IActionResult Edit(Review model)
        {
            ctx.Reviews.Update(model);
            ctx.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = ctx.Reviews.Find(id);
            if (item == null) return NotFound();
            ctx.Reviews.Remove(item);
            ctx.SaveChanges();
            return NoContent();
        }
    }
}

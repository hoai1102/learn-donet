using demo;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>
            {
                new SuperHero {
                    Id=1,
                    Name="Iron Man",
                    FistName="Tony",
                    LastName="Stark",
                    Place="New York"},
                 new SuperHero {
                    Id=2,
                    Name="Spider Man",
                    FistName="Peter",
                    LastName="Paker",
                    Place="New York"}
            };
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = heroes.Find(v => v.Id == id);
            if (hero == null)
                return BadRequest("Hero not found.");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var hero = heroes.Find(v => v.Id == request.Id);
            if (hero == null)
                return BadRequest("Hero not found.");

            hero.Name = request.Name;
            hero.FistName = request.FistName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            return Ok(hero);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var hero = heroes.Find(v => v.Id == id);
            if (hero == null)
                return BadRequest("Hero not found.");

            heroes.Remove(hero);
            return Ok(heroes);
        }
    }
}

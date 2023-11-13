using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    
    [ApiController]
    [Route("/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("ShowPlayers")]
        public IActionResult GetPlayers(){

         var data = _context.Players.ToList();
         return Ok(data);
        }


        [HttpPost]
        [Route("AddPlayer")]
        public IActionResult PostPlayers(Player p){

            if(ModelState.IsValid)
            {
                _context.Players.Add(p);
                _context.SaveChanges();
              

            }
               return Created("Record Added",p);

        }

        [HttpPost]
        [Route("AddTeam")]
        public IActionResult PostTeam(Team t)
        {
            if(ModelState.IsValid)
            {
                _context.Teams.Add(t);
                _context.SaveChanges();
            }
            return Created("Added Team",t);
        }

        [HttpGet]
        [Route("ShowTeam")]
        public IActionResult GetTeam()
        {
            var data = _context.Teams.ToList();
            return Ok(data);

        }

        [HttpPut]
        [Route("EditPlayer/{id}")]
        public IActionResult PutPlayer(int id,Player p)
        {

            Player player = _context.Players.Find(p.Id);

        }

        
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;

namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("/[controller]")]
        public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        [Route("ShowPlayers")]
        public IActionResult GetPlayers(){

         var data = _context.Players.ToList();
         return Ok(data);
        }

        [HttpGet]
        [Route("ShowTeam")]
        public IActionResult GetTeams()
        {
            var data = _context.Teams.ToList();
            return Ok(data);

        }

        [HttpGet]
        [Route("GetPlayer/{id}")]
 
        public IActionResult GetPlayer(int id){
            var data = _context.Players.Find(id);
            if(data==null)
            return NotFound();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetTeam/{id}")]
 
        public IActionResult GetTeam(int id){
            var data = _context.Teams.Find(id);
            if(data==null)
            return NotFound();
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
                int tID = t.Id;
                if(t.Id > 0) t.Id = 0;

                _context.Teams.Add(t);
                _context.SaveChanges();

                if(t.Id > 0) t.Id = tID;
            }
            return Created("Added Team",t);
        }

        

        [HttpPut]
        [Route("EditPlayer/{id}")]
        public IActionResult PutPlayer(int id,Player p)
        {


           try{
           
                Player player = _context.Players.Find(p.Id);
                player.Age = p.Age;
                player.Name = p.Name;
                player.BiddingPrice = p.BiddingPrice;
                player.Category = p.Category;
                _context.SaveChanges();
                return Ok();
            
           
        }
        catch(Exception e)
       {

       }
                   return BadRequest("Unable to Edit Player");


        }
        [HttpPut]
        [Route("EditTeam/{id}")]
         public IActionResult PutTeam(int id,Team t)
        {

            if(ModelState.IsValid)
            {
                Team team = _context.Teams.Find(t.Id);
                team.Name = t.Name;
                _context.SaveChanges();
                return Ok();
            
            }

            return BadRequest("Unable to Edit Team");

        }
         [HttpDelete]
        [Route("DeletePlayer/{id}")]
        public IActionResult DeletePlayer(int id){

                var data = _context.Players.Find(id);
                if(data==null)
                return NotFound();
                _context.Players.Remove(data);
                _context.SaveChanges();
                return Ok();


        }

        [HttpDelete]
        [Route("DeleteTeam/{id}")]
        public IActionResult DeleteTeam(int id)
        {

//        [18:32] Divakar S
// dotnet build && dotnet test -l "console;verbosity=normal"; 
            try {
                var detail=_context.Players.Where(d=>d.TeamID == id);
                if(detail.Count() != 0){
                    throw new System.Exception("Cannot Delete Teams because Team has Players");
                }
                var data= _context.Teams.Find(id);
                _context.Teams.Remove(data);
                _context.SaveChanges();
                return Ok();
            }
            catch(System.Exception ex){
                return BadRequest(ex.Message);
            }

             
        }

        
    }
}
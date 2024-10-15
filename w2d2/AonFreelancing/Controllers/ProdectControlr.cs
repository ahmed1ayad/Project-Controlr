using AonFreelancing.Models;
using Microsoft.AspNetCore.Mvc;
using static AonFreelancing.Controllers.ProdectControlr;

namespace AonFreelancing.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ProdectControlr : Controller
    {

        private static List<prodect> prodectList = new List<prodect>();
       // private static int nextId = 1;
        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(prodectList);
        }

        [HttpPost]
        public IActionResult Create([FromBody] prodect prodect)
        {
            prodectList.Add(prodect);
            return CreatedAtAction("Create", new { Id = prodect.Id },  prodectList);
        }

        [HttpGet("{id}")]
        public IActionResult GetProdectById(int id)
        {
            var prodect = prodectList.FirstOrDefault(t => t.Id == id);
            if (prodect == null)
            {
                return NotFound();
            }
            return Ok(prodect);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
           prodect f = prodectList.FirstOrDefault(f => f.Id == id);
            if (f != null)
            {
                prodectList.Remove(f);
                return Ok("Deleted");

            }
            return NoContent(); 
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProject(int id, prodect updatedProjec)
        {
            var prodect =prodectList.FirstOrDefault(t => t.Id == id);
            if (prodectList == null)
            {
                return NotFound();
            }


          prodect.Title =updatedProjec.Title;




            return NoContent(); 
        }

    }
}

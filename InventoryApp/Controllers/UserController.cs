using System.Linq;
using InventoryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DBContext dBContext;

        public UserController(DBContext DBContext)
        {
            dBContext = DBContext;
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            user.Id = System.Guid.NewGuid().ToString();

            dBContext.Add(user);
            dBContext.SaveChanges();

            return Ok(User);
        }

        [HttpGet("get-users")]
        public IActionResult test(string email, string password)
        {
            var user = dBContext.users.ToList();
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            var user = dBContext.users.FirstOrDefault(x => x.email == email && x.password == password);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

    }
}

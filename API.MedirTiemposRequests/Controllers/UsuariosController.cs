using Microsoft.AspNetCore.Mvc;

namespace API.MedirTiemposRequests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        List<string> usuarios;

        public UsuariosController()
        {
            this.usuarios = new List<string>(); 
            usuarios.Add("un user0");
            usuarios.Add("otro user1");
            usuarios.Add("otro user2");
            usuarios.Add("otro user3");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {     
            Thread.Sleep(6000);
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Thread.Sleep(2000);
            return Ok(usuarios[id]);
        }
    }
}

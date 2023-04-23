using ApiSoftFinance.Context;
using ApiSoftFinance.JWTConfig;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiSoftFinance.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        //[AllowAnonymous]
        [Route("/logar")]
        public async Task<IActionResult> Auth([FromBody] LoginRequest request)
        {
            try
            {
                var cliente = _context.Clientes.FirstOrDefault(c => c.Cpf == request.Cpf);
                if (cliente is null) return NotFound("Cliente não encontrado");

                if (cliente == null)
                    return BadRequest(new { Message = "cpf VER e/ou senha está(ão) inválido(s)." });

                if (cliente.Senha != request.Password)
                    return BadRequest(new { Message = "cpf OUTRO e/ou senha está(ão) inválido(s)." });

                var token = ConfigJwt.GenerateToken(cliente);

                return Ok(new
                {
                    Token = token,
                    Usuario = cliente,
                });
            }
            catch (Exception)
            {
                return BadRequest(new { Message = "Ocorreu algum erro interno na aplicação, por favor tente novamente. " });
            }
        }


        [HttpGet]
        //[Authorize]
        [Route("/autorizacao")]
        public IActionResult GetAutorizacao([FromHeader] string Authorization)
        {
            return Ok(new { Authorization });
        }
    }
}

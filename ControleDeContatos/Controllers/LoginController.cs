using AutoMapper;
using ControleDeContatos.Models.Contato;
using ControleDeContatos.Models.Login;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Servicies.Interfaces;

namespace ControleDeContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _service;
        private readonly IMapper _mapper;

        public LoginController(ILoginService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var loginDTO = _mapper.Map<LoginDTO>(loginModel);

                    var loginResponse = await _service.LoginAsync(loginDTO);

                    if(loginResponse != null)
                    {
                        if (loginModel.Login == loginResponse.Login && loginModel.Senha == loginResponse.Senha)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }

                    TempData["MensagemErro"] = $"Usuario e/ou senha inválido(s). Por favor, tente novamente.";
                    
                }

                return View("Index");
            }
            catch (Exception e)
            {

                TempData["MensagemErro"] = $"Error ao realizar o Login! Tente novamente! Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}

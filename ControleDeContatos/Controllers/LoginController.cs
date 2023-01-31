using AutoMapper;
using ControleDeContatos.Helper;
using ControleDeContatos.Models.Contato;
using ControleDeContatos.Models.Login;
using ControleDeContatos.Models.Usuario;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Servicies.Interfaces;

namespace ControleDeContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _service;
        private readonly ISessao _sessao;
        private readonly IMapper _mapper;

        public LoginController(ILoginService service, IMapper mapper, ISessao sessao)
        {
            _service = service;
            _mapper = mapper;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            //se o usuario estiver logado, redirecionar para home
            if(_sessao.BuscarSessaoDoUsuario() != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult RedefinirSenha()
        {
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();
            return RedirectToAction("Index", "Login");
        }



        [HttpPost]
        public async Task<IActionResult> Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    loginModel.SetSenhaHash();
                    var loginDTO = _mapper.Map<LoginDTO>(loginModel);

                    var usuarioResponseDTO = await _service.LoginAsync(loginDTO);

                    var usuarioModel = _mapper.Map<UsuarioModel>(usuarioResponseDTO);

                    if (usuarioModel != null)
                    {
                        if (loginModel.Login == usuarioModel.Login && loginModel.Senha == usuarioModel.Senha)
                        {
                            _sessao.CriarSessaoDoUsuario(usuarioModel);
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

        [HttpPost]
        public async Task<IActionResult> EnviarLinkParaRedefinirSenha(RedefinirSenhaModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var redefinirSenhaDTO = _mapper.Map<RedefinirSenhaDTO>(model);

                    var usuarioResponseDTO = await _service.BuscarPorEmailLoginAsync(redefinirSenhaDTO.Login, redefinirSenhaDTO.Email);

                    var usuarioModel = _mapper.Map<UsuarioModel>(usuarioResponseDTO);

                    if (usuarioModel != null)
                    {
                        string novaSenha = usuarioModel.GerarNovaSenha();

                        //Aqui vou atualizar a senha
                        //Fazer
                        TempData["MensagemSucesso"] = $"Enviamos para seu email cadastrado uma nova senha.";
                        return RedirectToAction("Index", "Login");
                    }

                    TempData["MensagemErro"] = $"Não conseguimos redefinir sua senha. Por favor, tente novamente.";

                }

                return View("RedefinirSenha");
            }
            catch (Exception e)
            {

                TempData["MensagemErro"] = $"Error, não conseguimos redefinir sua senha! Tente novamente! Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }
        }
        
    }
}

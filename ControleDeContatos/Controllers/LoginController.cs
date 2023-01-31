using AutoMapper;
using ControleDeContatos.Helper.Email;
using ControleDeContatos.Helper.Session;
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
        private readonly IEmail _email;
        private readonly IUsuarioService _serviceUsuario;
        private readonly IMapper _mapper;

        public LoginController(ILoginService service, IMapper mapper, ISessao sessao, IEmail email, IUsuarioService serviceUsuario)
        {
            _service = service;
            _mapper = mapper;
            _sessao = sessao;
            _email = email;
            _serviceUsuario = serviceUsuario;
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
                    //loginModel.SetSenhaHash();
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
                    var usuarioResponseDTO = await _service.BuscarPorEmailLoginAsync(model.Login, model.Email);

                    var usuarioModel = _mapper.Map<UsuarioModel>(usuarioResponseDTO);
                    

                    if (usuarioModel != null)
                    {
                        var senha = usuarioModel.GerarNovaSenha(); 
                        

                        // envio o email
                        string mensagem = $"Sua nova senha é: {senha}";
                        var emailEnviado = await _email.Enviar(usuarioModel.Email, "Sistema de Contatos - Nova Senha", mensagem);

                        //Aqui vou atualizar a senha
                        if (emailEnviado)
                        {
                            //usuarioModel.SetSenhaHash();
                            usuarioModel.Senha = senha;
                            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuarioModel);
                            await _serviceUsuario.UpdateAsync(usuarioDTO);
                            TempData["MensagemSucesso"] = $"Enviamos para seu email cadastrado uma nova senha.";
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"Não conseguimos enviar o email. Por favor, tente novamente.";
                        }
                        
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

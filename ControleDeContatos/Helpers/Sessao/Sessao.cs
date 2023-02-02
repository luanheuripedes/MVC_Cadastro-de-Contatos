using ControleDeContatos.Models.Usuario;
using Newtonsoft.Json;

namespace Services.Services.Sessao
{
    public class Sessao : ISessao
    {
        //PARA CRIAR SESSAO DO USUARIO E RECUPERAR
        private readonly IHttpContextAccessor _httpContexAcessor;

        public Sessao(IHttpContextAccessor httpContexAcessor)
        {
            _httpContexAcessor = httpContexAcessor;
        }

        public void CriarSessaoDoUsuario(UsuarioModel usuarioModel)
        {
            //transformando o usuarioModel em Json
            string valor = JsonConvert.SerializeObject(usuarioModel);


            _httpContexAcessor.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public UsuarioModel BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _httpContexAcessor.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }



        public void RemoverSessaoDoUsuario()
        {
            _httpContexAcessor.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}

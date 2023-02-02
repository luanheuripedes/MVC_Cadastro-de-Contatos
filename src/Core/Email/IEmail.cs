namespace ControleDeContatos.Helper.Email
{
    public interface IEmail
    {
        Task<bool> Enviar(string emailEndereco, string assunto, string mensagem);
    }
}

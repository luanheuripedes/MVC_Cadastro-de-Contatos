namespace Services.DTO
{
    public class AlterarSenhaDTO
    {
        public int Id { get; set; }
        public string SenhaAtual { get; set; }
        public string NovaSenha { get; set; }
        public string ConfirmarNovaSenha { get; set; }
    }
}

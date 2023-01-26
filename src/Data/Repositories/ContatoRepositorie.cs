using Data.Context;
using Data.Entities;
using Data.Repositories.Interface;
using Infrastructure.Repositories;


namespace Data.Repositories
{
    public class ContatoRepositorie : BaseRepositorie<Contato>, IContatoRepositorie
    {


        public ContatoRepositorie(BancoContext context) : base(context)
        {

        }


    }
}

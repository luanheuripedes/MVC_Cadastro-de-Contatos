using Data.Context;
using Data.Entities;
using Data.Repositories.Interface;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Data.Repositories
{
    public class ContatoRepositorie : BaseRepositorie<Contato>, IContatoRepositorie
    {


        public ContatoRepositorie(BancoContext context) : base(context)
        {

        }


    }
}

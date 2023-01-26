using Data.Entities;
using Data.Context;
using Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repositories;

namespace Data.Repositories
{
    public class UsuarioRepositorie : BaseRepositorie<Usuario>, IUsuarioRepositorie
    {

        public UsuarioRepositorie(BancoContext bancoContext):base(bancoContext)
        {
            
        }

    }
}

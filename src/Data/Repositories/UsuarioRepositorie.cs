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

        //public async Task AdicionarAsync(Usuario entite)
        //{
        //    entite.DataCadastro = DateTime.UtcNow;
        //    await _bancoContext.Usuarios.AddAsync(entite);
        //    await _bancoContext.SaveChangesAsync();
        //}

        //public async Task<bool> ApagarAsync(int id)
        //{
        //    try
        //    {
        //        var usuario = await BuscarPorIdAsync(id);
        //        if (usuario == null)
        //        {
        //            throw new Exception("Houve um erro na deleção do usuario!");
        //        }

        //        _bancoContext.Usuarios.Remove(usuario);
        //        await _bancoContext.SaveChangesAsync();
        //        return true;
        //    }
        //    catch (Exception e)
        //    {

        //        throw new Exception(e.Message);
        //    }

        //}

        //public async Task AtualizarAsync(Usuario entitie)
        //{
        //    var usuario = await BuscarPorIdAsync(entitie.Id);

        //    if(usuario == null)
        //    {
        //        throw new Exception("Houve um erro na atualização do usuario!");
        //    }

        //    usuario.Nome = entitie.Nome;
        //    usuario.Login = entitie.Login;
        //    usuario.Email = entitie.Email;
        //    usuario.Senha = entitie.Senha;
        //    usuario.Perfil = entitie.Perfil;
        //    usuario.DataAtualizacao = DateTime.Now;

        //     _bancoContext.Usuarios.Update(usuario);
        //    await _bancoContext.SaveChangesAsync();


        //}

        //public async Task<Usuario> BuscarPorIdAsync(int id)
        //{
        //    return await _bancoContext.Usuarios.AsNoTracking().FirstOrDefaultAsync(x =>x.Id == id);
        //}

        //public async Task<List<Usuario>> BuscarTodosAsync()
        //{
        //   return await _bancoContext.Usuarios.AsNoTracking().ToListAsync();
        //}
    }
}

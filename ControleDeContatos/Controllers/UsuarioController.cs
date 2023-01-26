using AutoMapper;
using ControleDeContatos.Models;
using Data.Entities;
using Data.Repositories;
using Data.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Servicies.Interfaces;

namespace ControleDeContatos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var usuarioDTO = await _usuarioService.GetAllAsync();

            var usuariosModel = _mapper.Map<List<UsuarioModel>>(usuarioDTO);


            return View(usuariosModel);
        }

        public IActionResult CriarUsuario()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario(UsuarioModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entitieDTO = _mapper.Map<UsuarioDTO>(model);

                    await _usuarioService.CreateAsync(entitieDTO);

                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso!";

                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception e)
            {

                TempData["MensagemErro"] = $"Error ao cadastrar! Tente novamente! Detalhe do erro: {e.Message}";
                return RedirectToAction("Index");
            }

        }
    }
}

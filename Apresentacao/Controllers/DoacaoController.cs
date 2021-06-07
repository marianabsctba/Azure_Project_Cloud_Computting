using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infraestrutura;
using Infraestrutura.Models;
using Infraestrutura.Repositories;

namespace Apresentacao.Controllers
{
    public class DoacaoController : Controller
    {
        private readonly IDoacaoRepository _doacaoRepository;
        public DoacaoController(IDoacaoRepository doacaoRepository)
        {
            _doacaoRepository = doacaoRepository;
        }
        public IActionResult Index(string search = null)
        {
            var doacoes = _doacaoRepository.GetAll(search);

            ViewData["Pesquisar"] = search;

            return View(doacoes);
        }

        public IActionResult Details(int id)
        {
            var doacao = _doacaoRepository.GetById(id);

            if (doacao != null)
            {
                return View(doacao);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DoacaoModel doacaoModel)
        {
            try
            {
                _doacaoRepository.Create(doacaoModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            var doacao = _doacaoRepository.GetById(id);

            if (doacao != null)
            {
                return View(doacao);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DoacaoModel doacaoModel)
        {
            try
            {
                var doacaoUpdate = _doacaoRepository.Edit(doacaoModel);

                if (doacaoUpdate != null)
                {
                    return RedirectToAction(nameof(Details), new { id = doacaoUpdate.Id });
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteFromMemory(int id)
        {
            try
            {
                _doacaoRepository.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }
    }
}


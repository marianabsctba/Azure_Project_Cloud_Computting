using Infraestrutura;
using Infraestrutura.Repositories;
using Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositories
{
    public class DoacaoMemoryRepository : IDoacaoRepository
    {
        private static List<DoacaoModel> Doacoes { get; } = new List<DoacaoModel> {
            new DoacaoModel
            {
                 Id = 0,
                 Estado = true,
                 Tipo = "Blusa",
                 Descricao = "Blusa de inverno",
                 DataRegistro = new DateTime(2021,2,4),
                 Frete = 10.00,
                 Quantidade = 1,
            },
            new DoacaoModel
            {
                 Id = 1,
                 Estado = false,
                 Tipo = "Fogão",
                 Descricao = "Fogão novo de 4 bocas",
                 DataRegistro = new DateTime(2021,1,1),
                 Frete = 200.00,
                 Quantidade = 1,
            }
            };

        public DoacaoModel Create(DoacaoModel doacaoModel)
        {
            throw new NotImplementedException();
        }

        public DoacaoModel Edit(DoacaoModel doacaoModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DoacaoModel> GetAll(string search)
        {
            throw new NotImplementedException();
        }

        public DoacaoModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        DoacaoModel IDoacaoRepository.Create(DoacaoModel doacaoModel)
        {
            Doacoes.Add(doacaoModel);

            return doacaoModel;
        }

        void IDoacaoRepository.Delete(int id)
        {
            DoacaoModel doacaoBuscada = null;

            foreach (var doacao in Doacoes)
            {
                if (doacao.Id == id)
                {
                    doacaoBuscada = doacao;
                }
            }

            if (doacaoBuscada != null)
            {
                Doacoes.Remove(doacaoBuscada);
            }
        }

        DoacaoModel IDoacaoRepository.Edit(DoacaoModel doacaoModel)
        {
            foreach (var doacao in Doacoes)
            {
                if (doacao.Id == doacaoModel.Id)
                {
                    doacao.Tipo = doacaoModel.Tipo;
                    doacao.Descricao = doacaoModel.Descricao;
                    doacao.Frete = doacaoModel.Frete;
                    doacao.DataRegistro = doacaoModel.DataRegistro;
                    doacao.Quantidade = doacaoModel.Quantidade;

                    return doacao;
                }
            }

            return null;
        }

        IEnumerable<DoacaoModel> IDoacaoRepository.GetAll(string search = null)
        {
            if (search == null)
            {
                return Doacoes;
            }

            var resultado = Doacoes.
                                Where(x =>
                                x.Tipo.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                                x.Descricao.Contains(search, StringComparison.OrdinalIgnoreCase));

            return resultado;
        }

        DoacaoModel IDoacaoRepository.GetById(int id)
        {
            foreach (var doacao in Doacoes)
            {
                if (doacao.Id == id)
                {
                    return doacao;
                }
            }

            return null;
        }
    }
}
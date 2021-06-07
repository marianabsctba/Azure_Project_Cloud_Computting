using Infraestrutura.Models;
using System.Collections.Generic;

namespace Infraestrutura.Repositories
{
    public interface IDoacaoRepository
    {
        IEnumerable<DoacaoModel> GetAll(string search);
        DoacaoModel GetById(int id);
        DoacaoModel Create(DoacaoModel doacaoModel);
        DoacaoModel Edit(DoacaoModel doacaoModel);
        void Delete(int id);
    }
}

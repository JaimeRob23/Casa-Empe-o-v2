using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaEmpeño.Model
{
    public interface IClienteRepository
    {
        bool Add(ClienteModel cliente);
        bool Edit(ClienteModel cliente);
        bool Delete(int id);
        IEnumerable<ClienteModel> GetAll();
        ClienteModel GetById(int id);
    }
}

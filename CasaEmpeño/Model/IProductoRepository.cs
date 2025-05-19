using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaEmpeño.Model
{
    public interface IProductoRepository
    {
        bool Add(ProductoModel producto);
        bool Edit(ProductoModel producto);
        bool Delete(int id);
        IEnumerable<ProductoModel> GetAll();
        ProductoModel GetById(int id);
    }
}

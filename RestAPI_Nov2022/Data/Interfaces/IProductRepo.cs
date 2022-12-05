using RestAPI_Nov2022.Models;
using RestAPI_Nov2022.ModelsDTO;

namespace RestAPI_Nov2022.Data.Interfaces
{
    public interface IProductRepo
    {
        IEnumerable<ProductReadDto> Get();
        ProductReadDto Get(int id);
        void Delete(int id);
        void Update(int id, ProductCreateDto product);
        void Create(ProductCreateDto product);
    }
}

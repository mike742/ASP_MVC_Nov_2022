using RestAPI_Nov2022.ModelsDTO;

namespace RestAPI_Nov2022.Data.Interfaces
{
    public interface IOrderRepo
    {
        IEnumerable<OrderReadDto> Get();
        OrderReadDto Get(int id);
        void Delete(int id);
        void Update(int id, OrderCreateDto product);
        void Create(OrderCreateDto product);
    }
}

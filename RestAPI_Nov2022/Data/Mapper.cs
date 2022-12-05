using RestAPI_Nov2022.Models;
using RestAPI_Nov2022.ModelsDTO;

namespace RestAPI_Nov2022.Data
{
    public class Mapper
    {
        public Product Map(ProductReadDto input)
        {
            return new Product {
                Id = input.Id,
                Name = input.Name,
                Price = input.Price
            };
        }

        public ProductReadDto Map(Product input)
        {
            return new ProductReadDto { 
                Id = input.Id,
                Name = input.Name,
                Price = input.Price
            };
        }

        public Product Map(ProductCreateDto input)
        {
            return new Product { 
                // Id = -1,
                Name = input.Name,
                Price = input.Price
            };
        }
    }
}

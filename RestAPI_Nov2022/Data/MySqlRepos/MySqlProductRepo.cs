using RestAPI_Nov2022.Data.Interfaces;
using RestAPI_Nov2022.Models;
using RestAPI_Nov2022.ModelsDTO;

namespace RestAPI_Nov2022.Data.MySqlRepos
{
    public class MySqlProductRepo : IProductRepo
    {
        private readonly AppDbContext _context;
        private readonly Mapper _mapper = new Mapper();

        public MySqlProductRepo(AppDbContext context)
        {
            _context = context;
        }
        public void Create(ProductCreateDto product)
        {
            Product newProduct = _mapper.Map(product);
            _context.Products.Add(newProduct);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Product productInDb = _context.Products.ToList().Find(p => p.Id == id);

            if (productInDb != null)
            {
                _context.Products.Remove(productInDb);
                _context.SaveChanges();
            }
        }

        public IEnumerable<ProductReadDto> Get()
        {
            return _context.Products.Select(p => _mapper.Map(p)).ToList();
        }

        public ProductReadDto Get(int id)
        {
            Product productInDb = _context.Products.ToList().Find(p => p.Id == id);

            return _mapper.Map(productInDb);
        }

        public void Update(int id, ProductCreateDto product)
        {
            Product productInDb = _context.Products.ToList().Find(p => p.Id == id);

            if (productInDb != null)
            {
                productInDb.Name = product.Name;
                productInDb.Price = product.Price;

                _context.SaveChanges();
            }
        }
    }
}

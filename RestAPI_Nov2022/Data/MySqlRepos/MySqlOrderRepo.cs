using RestAPI_Nov2022.Data.Interfaces;
using RestAPI_Nov2022.Models;
using RestAPI_Nov2022.ModelsDTO;

namespace RestAPI_Nov2022.Data.MySqlRepos
{
    public class MySqlOrderRepo : IOrderRepo
    {
        private readonly AppDbContext _context;
        private readonly Mapper _mapper = new Mapper();

        public MySqlOrderRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Create(OrderCreateDto product)
        {
            Order orderToAdd = _mapper.Map(product);
            _context.Orders.Add(orderToAdd);
            _context.SaveChanges();

            foreach (var id in product.ProductsIds)
            {
                var op = new OrderProducts
                {
                    OrderId = orderToAdd.Id,
                    ProductId = id
                };
                _context.OrderProducts.Add(op);
            }

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Order? orderToDelete = _context.Orders.Find(id);

            if (orderToDelete != null)
            {
                var productsRange = _context.OrderProducts.Where(op => op.OrderId == id).ToList();

                _context.OrderProducts.RemoveRange(productsRange);
                _context.Orders.Remove(orderToDelete);
                _context.SaveChanges();
            }

        }

        public IEnumerable<OrderReadDto> Get()
        {
            //var orders = _context.Orders.Select(o => _mapper.Map(o)).ToList();
            //var products = _context.Products.Select(p => _mapper.Map(p)).ToList();
            //var orderProducts = _context.OrderProducts.ToList();

            //foreach (var order in orders)
            //{
            //    List<ProductReadDto> productsToAdd = new List<ProductReadDto>();

            //    foreach (var op in orderProducts)
            //    {
            //        if (op.OrderId == order.Id)
            //        {
            //            var productInDb = products.FirstOrDefault(p => p.Id == op.ProductId);

            //            if (productInDb != null)
            //            {
            //                productsToAdd.Add(productInDb);
            //            }
            //        }
            //    }
            //    order.Products = productsToAdd;
            //}


            var orders = _context.Orders.Select(o => new OrderReadDto
            {
                Id = o.Id,
                Name = o.Name,
                Date = o.Date,
                Products = _context.OrderProducts
                                    .Where(op => op.OrderId == o.Id)
                                    .Select(c => new ProductReadDto { 
                                        Id = c.Product.Id,
                                        Name = c.Product.Name,
                                        Price = c.Product.Price
                                    }).ToList()
            });

            return orders;
        }

        public OrderReadDto Get(int id)
        {
            var order = _context.Orders
                .Where(o => o.Id == id)
                .Select(o => new OrderReadDto
            {
                Id = o.Id,
                Name = o.Name,
                Date = o.Date,
                Products = _context.OrderProducts
                                   .Where(op => op.OrderId == o.Id)
                                   .Select(c => new ProductReadDto
                                   {
                                       Id = c.Product.Id,
                                       Name = c.Product.Name,
                                       Price = c.Product.Price
                                   }).ToList()
            }).FirstOrDefault();

            return order;
        }

        public void Update(int id, OrderCreateDto product)
        {
            var orderInDb = _context.Orders.FirstOrDefault(o => o.Id == id);

            if (orderInDb != null)
            {
                orderInDb.Name = product.Name;
                orderInDb.Date = product.Date;

                var orderProductRange = _context.OrderProducts.Where(op => op.OrderId == id).ToList();
                _context.OrderProducts.RemoveRange(orderProductRange);

                foreach (var item in product.ProductsIds)
                {
                    var op = new OrderProducts
                    {
                        OrderId = id,
                        ProductId = item
                    };
                    _context.OrderProducts.Add(op);
                }

                _context.SaveChanges();

            }
        }
    }
}

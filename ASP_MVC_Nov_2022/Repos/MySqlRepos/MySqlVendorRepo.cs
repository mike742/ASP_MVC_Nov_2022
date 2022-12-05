using ASP_MVC_Nov_2022.Models;
using ASP_MVC_Nov_2022.Repos.Interfaces;

namespace ASP_MVC_Nov_2022.Repos.MySqlRepos
{
    public class MySqlVendorRepo : IVendorRepo
    {
        private readonly AppDbContext _context;

        public MySqlVendorRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Vendor newVendor)
        {
            if (newVendor == null)
            {
                throw new ArgumentException(nameof(newVendor));
            }
            _context.Add(newVendor);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var vendorToDelete = GetById(id);

            if (vendorToDelete != null)
            {
                _context.Remove(vendorToDelete);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Vendor> GetAll()
        {
            return _context.Vendors.ToList();
        }

        public Vendor GetById(int id) => _context.Vendors.FirstOrDefault(v => v.V_code == id);

        public void Update(int id, Vendor vendor)
        {
            var vendorToUpdate = GetById(id);

            if (vendorToUpdate != null)
            {
                vendorToUpdate.V_phone = vendor.V_phone;
                vendorToUpdate.V_state = vendor.V_state;
                vendorToUpdate.V_contact = vendor.V_contact;
                vendorToUpdate.V_name = vendor.V_name;
                vendorToUpdate.V_AreaCode = vendor.V_AreaCode;
                vendorToUpdate.V_order = vendor.V_order;
                _context.SaveChanges();
            }
        }
    }
}

using ASP_MVC_Nov_2022.Models;

namespace ASP_MVC_Nov_2022.Repos.Interfaces
{
    public interface IVendorRepo
    {
        public IEnumerable<Vendor> GetAll();
        public Vendor GetById(int id);
        public void Update(int id, Vendor vendor);
        public void Create(Vendor newVendor);
        public void Delete(int id);
    }
}

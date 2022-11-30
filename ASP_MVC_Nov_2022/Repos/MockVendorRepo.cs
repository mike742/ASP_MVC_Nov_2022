using ASP_MVC_Nov_2022.Models;

namespace ASP_MVC_Nov_2022.Repos
{
    public class MockVendorRepo
    {
        private static List<Vendor> vendors = new List<Vendor>
        {
            new Vendor { V_code = 21225, V_name = "Bryson, Inc",       V_contact = "Smithson",  V_AreaCode = 615, V_phone = "223-3234", V_state = "TN", V_order = "Y" },
            new Vendor { V_code = 21226, V_name = "SuperLoo, Inc",  V_contact = "Flushing",     V_AreaCode = 904, V_phone = "215-8995", V_state = "FL", V_order = "N" },
            new Vendor { V_code = 21231, V_name = "D&E Supply",        V_contact = "Singh",     V_AreaCode = 615, V_phone = "228-3245", V_state = "TN", V_order = "Y" },
            new Vendor { V_code = 21344, V_name = "Gomez Bros.",    V_contact = "Singh",        V_AreaCode = 615, V_phone = "889-2546", V_state = "KY", V_order = "N" },
            new Vendor { V_code = 22567, V_name = "Dome Supply",    V_contact = "Smith",        V_AreaCode = 901, V_phone = "878-1419", V_state = "GA", V_order = "N" },
            new Vendor { V_code = 23119, V_name = "Randset Ltd.",   V_contact = "Anderson",     V_AreaCode = 901, V_phone = "678-3998", V_state = "GA", V_order = "Y" },
            new Vendor { V_code = 24004, V_name = "Brackman Bros.", V_contact = "Brownling",    V_AreaCode = 615, V_phone = "228-1410", V_state = "TN", V_order = "N" },
            new Vendor { V_code = 24288, V_name = "ORDVA, Inc.",    V_contact = "Hakford",      V_AreaCode = 615, V_phone = "898-1234", V_state = "TN", V_order = "Y" },
            new Vendor { V_code = 25443, V_name = "B&K, Inc.",      V_contact = "Smith",        V_AreaCode = 904, V_phone = "227-0093", V_state = "FL", V_order = "N" },
            new Vendor { V_code = 25501, V_name = "Damal Supplies", V_contact = "Smythe",       V_AreaCode = 615, V_phone = "890-3529", V_state = "TN", V_order = "N" },
            new Vendor { V_code = 25595, V_name = "Rubicon Systems",V_contact = "Orton",        V_AreaCode = 904, V_phone = "456-0092", V_state = "FL", V_order = "Y" },
        };

        private readonly MockProductRepo productRepo = new MockProductRepo();

        public IEnumerable<Vendor> GetAll()
        {
            return vendors;
        }

        public Vendor? GetById(int id) => vendors.FirstOrDefault(v => v.V_code == id);

        public void Create(Vendor newVendor) 
        {
            int newVendorCode = vendors.Max(v => v.V_code) + 1;
            newVendor.V_code = newVendorCode;
            vendors.Add(newVendor);
        }

        public void Update(int id, Vendor vendor)
        {
            var res = GetById(id);

            if (res != null)
            {
                res.V_phone = vendor.V_phone;
                res.V_state = vendor.V_state;
                res.V_contact = vendor.V_contact;
                res.V_name = vendor.V_name;
                res.V_AreaCode = vendor.V_AreaCode;
                res.V_order = vendor.V_order;
            }
        }

        public void Delete(int id)
        {
            var res = GetById(id);

            if (res != null)
            {
                vendors.Remove(res);

                var products = productRepo.GetAll().Where(p => p.V_code == id).ToList();
                foreach (var product in products)
                {
                    product.V_code = null;
                }

            }
        }
    }
}

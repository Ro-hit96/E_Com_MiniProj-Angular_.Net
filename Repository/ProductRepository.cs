using E_ComMIniProj.Data;
using E_ComMIniProj.Model;
using Microsoft.EntityFrameworkCore;

namespace E_ComMIniProj.Repository
{
    // Implementing the IProductRepository interface
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext db;

        // Constructor injecting the application database context
        public ProductRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        // Implementing the method to add a product
        public async Task<int> AddProduct(Product product)
        {
            int result = 0;
            await db.Products.AddAsync(product);
            result = await db.SaveChangesAsync();
            return result;
        }

        // Implementing the method to delete a product by its ID
        public async Task<int> DeleteProduct(int id)
        {
            int result = 0;
            var product = await db.Products.Where(x => x.P_Id == id).FirstOrDefaultAsync();
            if (product != null)
            {
                db.Products.Remove(product);
                result = await db.SaveChangesAsync();
            }
            return result;
        }


        public async Task<Product> GetProductById(int id)
        {
            var product = await db.Products.Where(x => x.P_Id == id).FirstOrDefaultAsync();
            return product;
        }

    
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var res = await (from p in db.Products
                             join c in db.Categories on p.Category_id equals c.Category_id
                             select new Product
                             {
                                 P_Id = p.P_Id,
                                 P_name = p.P_name,
                                 Price = p.Price,
                                 image = p.image,
                                 Category_id = p.Category_id,
                                 Category_name = c.Category_name,
                             }).ToListAsync();
            return res;
        }

        public async Task<int> UpdateProduct(Product product)
        {
            int result = 0;
            var p = await db.Products.Where(x => x.P_Id == product.P_Id).FirstOrDefaultAsync();
            if (p != null)
            {
                p.P_name = product.P_name;
                p.Price = product.Price;
                p.image = product.image;
                p.Category_id = product.Category_id;
                result = await db.SaveChangesAsync();
            }
            return result;
        }
    }
}

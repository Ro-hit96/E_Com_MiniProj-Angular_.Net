using E_ComMIniProj.Model;
using E_ComMIniProj.Repository;

namespace E_ComMIniProj.Service
{
    // Implementing the IProductService interface
    public class ProductService : IProductService
    {
        // Declaring a private readonly field for the product repository
        private readonly IProductRepository repo;

        // Constructor injecting the product repository
        public ProductService(IProductRepository repo)
        {
            this.repo = repo;
        }

        public async Task<int> AddProduct(Product product)
        {
            return await repo.AddProduct(product);
        }

        public async Task<int> DeleteProduct(int id)
        {
            return await repo.DeleteProduct(id);
        }

   
        public async Task<Product> GetProductById(int id)
        {
            return await repo.GetProductById(id);
        }


        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await repo.GetProducts();
        }


        public Task<int> UpdateProduct(Product product)
        {
            return repo.UpdateProduct(product);
        }
    }
}

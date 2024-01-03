using E_ComMIniProj.Model;

namespace E_ComMIniProj.Repository
{
    // Defining the interface named 'IProductRepository' within the 'E_ComMIniProj.Repository' namespace
    public interface IProductRepository
    {
        // Declaring method to get all products
        Task<IEnumerable<Product>> GetProducts();

        // Declaring method to get a product by its ID
        Task<Product> GetProductById(int id);

        Task<int> AddProduct(Product product);

        Task<int> UpdateProduct(Product product);

        Task<int> DeleteProduct(int id);
    }
}

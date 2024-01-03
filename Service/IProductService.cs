using E_ComMIniProj.Model;

namespace E_ComMIniProj.Service
{
    // Defining the interface named 'IProductService' within the 'E_ComMIniProj.Service' namespace
    public interface IProductService
    {
        // Declaring method to get all products
        Task<IEnumerable<Product>> GetProducts();

        
        Task<Product> GetProductById(int id);


        Task<int> AddProduct(Product product);

        Task<int> UpdateProduct(Product product);

        Task<int> DeleteProduct(int id);
    }
}

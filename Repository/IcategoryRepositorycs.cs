
using E_ComMIniProj.Model;

namespace E_ComMIniProj.Repository
{
    // Defining the interface named 'IcategoryRepositorycs' within the 'E_ComMIniProj.Repository' namespace
    public interface IcategoryRepositorycs
    {
        // Declaring method to get all categories
        Task<IEnumerable<Category>> GetCategories();

        Task<Category> GetCategoryById(int id);

        Task<int> AddCategory(Category category);

        Task<int> UpdateCategory(Category category);

      
        Task<int> Deletecategory(int id);
    }
}

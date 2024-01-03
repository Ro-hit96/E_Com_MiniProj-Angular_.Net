using E_ComMIniProj.Model;

namespace E_ComMIniProj.Service
{
    // Defining the interface named 'ICategoryService' within the 'E_ComMIniProj.Service' namespace
    public interface ICategoryService
    {
        // Declaring method to get all categories
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategoryById(int id);
        Task<int> AddCategory(Category category);
        Task<int> UpdateCategory(Category category);
        Task<int> DeleteCategory(int id);
    }
}

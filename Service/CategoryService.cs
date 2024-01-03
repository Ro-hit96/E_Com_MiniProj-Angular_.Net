using E_ComMIniProj.Model;
using E_ComMIniProj.Repository;

namespace E_ComMIniProj.Service
{
    public class CategoryService:ICategoryService
    {
        private readonly IcategoryRepositorycs repo;
        public CategoryService(IcategoryRepositorycs repo)
        {
            this.repo = repo;    
        }

        public async Task<int> AddCategory(Category category)
        {
            return await repo.AddCategory(category);
        }

        public async Task<int> Deletecategory(int id)
        {
            return await repo.Deletecategory(id);
        }

        public Task<int> DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await repo.GetCategories();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await repo.GetCategoryById(id);
        }


        public async Task<int> UpdateCategory(Category category)
        {
            return await repo.UpdateCategory(category);
        }
    }
}

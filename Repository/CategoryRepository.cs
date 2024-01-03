// Importing necessary namespaces
using E_ComMIniProj.Data;
using E_ComMIniProj.Model;
using Microsoft.EntityFrameworkCore;

// Defining the namespace for the repository
namespace E_ComMIniProj.Repository
{
    // Implementing the IcategoryRepositorycs interface
    public class CategoryRepository : IcategoryRepositorycs
    {
        // Declaring a private readonly field for the application database context
        private readonly ApplicationDbContext db;

        // Constructor injecting the application database context
        public CategoryRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        // Implementing the method to add a category
        public async Task<int> AddCategory(Category category)
        {
            int result = 0;
            await db.Categories.AddAsync(category);
            result = await db.SaveChangesAsync();
            return result;
        }

        // Implementing the method to delete a category by its ID
        public async Task<int> Deletecategory(int id)
        {
            int result = 0;
            var category = await db.Categories.Where(x => x.Category_id == id).FirstOrDefaultAsync();
            if (category != null)
            {
                db.Categories.Remove(category);
                result = await db.SaveChangesAsync();
            }
            return result;
        }

        // Implementing the method to get all categories
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await db.Categories.ToListAsync();
        }

        // Implementing the method to get a category by its ID
        public async Task<Category> GetCategoryById(int id)
        {
            var category = await db.Categories.Where(x => x.Category_id == id).FirstOrDefaultAsync();
            return category;
        }

        // Implementing the method to update a category
        public async Task<int> UpdateCategory(Category category)
        {
            int result = 0;
            var c = await db.Categories.Where(x => x.Category_id == category.Category_id).FirstOrDefaultAsync();
            if (c != null)
            {
                c.Category_id = category.Category_id;
                c.Category_name = category.Category_name;
                result = await db.SaveChangesAsync();
            }
            return result;
        }
    }
}

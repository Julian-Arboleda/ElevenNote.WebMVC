using ElevenNote.Data;
using ElevenNote.Models.Category;
using ElevenNote.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryService
    {
        public bool CreateCategory(CategoryCreate model)
        {
            var entity =
                new Category()
                {
                    Name = model.Name
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return await ctx.Categories.ToListAsync();
            }
        }

        public async Task<IEnumerable<CategoryListItem>> GetCategoryList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Categories
                        .Select(
                            e =>
                            new CategoryListItem
                            {
                                CategoryId = e.CategoryId,
                                Name = e.Name
                            }
                       );
                return await query.ToListAsync();

            }
        }

        public CategoryDetail GetCategoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categories
                        .Single(e => e.CategoryId == id);
                return
                    new CategoryDetail
                    {
                        CategoryId = entity.CategoryId,
                        Name = entity.Name
                    };
            }
        }

        public bool UpdateCategory(CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Categories
                    .Single(c => c.CategoryId == model.CategoryId);

                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCategory(int CategoryId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categories
                        .Single(c => c.CategoryId == CategoryId);

                ctx.Categories.Remove(entity);

               return  ctx.SaveChanges() == 1;
            }
        }

    }
}

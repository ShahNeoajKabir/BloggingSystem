using BloggingSystem.DTO.DTO;
using BloggingSystemDatabase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystemBLLManager
{
    public class CategoriesBLLManager: ICategoriesBLLManager
    {
        private readonly BloggingSystemDbContext _blogging;
        public CategoriesBLLManager(BloggingSystemDbContext blogging)
        {
            _blogging = blogging;
        }

        public async Task<Categories> AddCategories(Categories categories)
        {
            try
            {
                var check = await _blogging.Categories.Where(c => c.CategoriesName == categories.CategoriesName).FirstOrDefaultAsync();
                if(check==null && categories.CategoriesName!=null && categories.Status > 0)
                {
                    categories.CreatedDate = DateTime.Now;
                    await _blogging.Categories.AddAsync(categories);
                    await _blogging.SaveChangesAsync();
                    return categories;
                }

                else
                {
                    throw new Exception("Something is wrong");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Cannot Added");
            }
        }

        public async Task<Categories> DeleteCategories(Categories categories)
        {
            try
            {
                var id = await _blogging.Categories.Where(p => p.CategoriesId == categories.CategoriesId).AsNoTracking().FirstOrDefaultAsync();
                if (id != null)
                {
                    _blogging.Categories.Remove(categories);
                    await _blogging.SaveChangesAsync();
                    return categories;
                }

                else
                {
                    throw new Exception("");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("");
            }
        }

        public List<Categories> GetAll()
        {
            List<Categories> categories = _blogging.Categories.ToList();
            return categories;
        }

        public async Task<Categories> GetById(Categories categories)
        {
            try
            {
                var res = await _blogging.Categories.Where(p => p.CategoriesId == categories.CategoriesId).FirstOrDefaultAsync();
                return res;
            }
            catch (Exception ex)
            {

                throw new Exception("");
            }
        }

        public async Task<Categories> UpdateCategories(Categories categories)
        {
            try
            {
                var res = await _blogging.Categories.Where(p => p.CategoriesId == categories.CategoriesId).AsNoTracking().FirstOrDefaultAsync();
                if (res != null)
                {

                    var check = await _blogging.Categories.Where(c => c.CategoriesName == categories.CategoriesName).AsNoTracking().FirstOrDefaultAsync();
                    if (check == null && categories.CategoriesName != null && categories.Status > 0)
                    {
                        categories.UpdatedDate = DateTime.Now;
                        _blogging.Categories.Update(categories);
                        await _blogging.SaveChangesAsync();
                        return categories;
                    }

                    else
                    {
                        throw new Exception("Something is wrong");
                    }
                }

                else
                {
                    throw new Exception("User Cannot Found");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }

    public interface ICategoriesBLLManager
    {
        Task<Categories> AddCategories(Categories categories);
        Task<Categories> DeleteCategories(Categories categories);
        Task<Categories> UpdateCategories(Categories categories);
        Task<Categories> GetById(Categories categories);
        List<Categories> GetAll();
    }
}

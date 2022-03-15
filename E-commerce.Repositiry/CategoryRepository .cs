using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Repositiry
{
    public class CategoryRepository
    {
        private EcommerceEntities db;
        public CategoryRepository()
        {
            db = new EcommerceEntities();
        }

        public Category Get (int id)
        {
            return db.Categories.FirstOrDefault(X => X.Id == id);
        }

        public Category Get (string name)
        {
            return db.Categories.FirstOrDefault(X => X.Name == name);
        }

        public Category Add (Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            var u = Get(category.Name);
            if (u != null)
            {
                throw new DuplicateWaitObjectException($"Category { category.Name } already exist !!!!!!");
            }


            category = db.Categories.Add(category);
            db.SaveChanges();

            return category;
        }

        public Category Set (Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            var currentDb = new EcommerceEntities();
            var oldUser = currentDb.Users.Find(category.Id);
            if (oldUser == null)
            {
                throw new KeyNotFoundException($"Category not found !!!!!!");
            }


            var u = currentDb.Categories.FirstOrDefault(X => X.Name == category.Name);
            if (u != null && u.Id != oldUser.Id)
            {
                throw new DuplicateWaitObjectException($"Category name { category.Name } already exist !!!!!!");
            }


            //user = db.Users.Add(user);
            db.Entry(category).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return category;
        }

        public Category Delete (int id)
        {
            var category = Get(id);
            db.Categories.Remove(category);
            db.SaveChanges();

            return category;
        }

        public IEnumerable <Category> Find (Func <Category, bool> predicate)
        {
            return db.Categories.Where(predicate).ToArray();
        }

    }
}

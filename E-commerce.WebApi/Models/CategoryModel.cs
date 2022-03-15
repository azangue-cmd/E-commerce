using E_commerce.Repositiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_commerce.WebApi.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public  UserModel User { get; set; }

        public CategoryModel()
        {
                
        }

        public CategoryModel(int id, string name, int userId, UserModel user)
        {
            Id = id;
            Name = name;
            UserId = userId;
            User = user;
        }

        public CategoryModel(Category category)
            : this(category?.Id ?? 0, category?.Name, category?.UserId ?? 0, new UserModel(category?.User))
        {

        }
    }
}
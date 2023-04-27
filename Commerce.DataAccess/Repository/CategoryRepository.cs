﻿using commerce.Models;
using Commerce.DataAccess.Data;
using Commerce.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category> , ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    
        public void save()
        {
            _db.SaveChanges();
        }

        public void Update(Category obj)
        {
            _db.categories.Update(obj);
        }
    }
}

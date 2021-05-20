﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyAPI.Models;

namespace UdemyAPI.Services
{
    public class DBService : IDB
    {
        UdemyContext _db;
        public DBService(UdemyContext db)
        {
            _db = db;
        }
        public List<Category> GetAllCategories()
        {
            return (_db.Categories.ToList());
        }
    }
}
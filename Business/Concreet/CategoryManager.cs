﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concreet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreet
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
          return  _categoryDal.GetAll();
        }

        public Category GetbyId(int categoryId)
        {
            return _categoryDal.Get(c=>c.CategoryId==categoryId);
        }
    }
}

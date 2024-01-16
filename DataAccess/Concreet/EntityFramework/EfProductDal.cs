﻿using Core.DataAccess.EntityRepository;
using DataAccess.Abstract;
using Entities.Concreet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concreet.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product,NortwindContext>,IProductDal
    {
      
    }
}

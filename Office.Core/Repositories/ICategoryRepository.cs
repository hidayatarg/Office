﻿using System;
using System.Threading.Tasks;
using Office.Core.Models;

namespace Office.Core.Repositories
{
    public interface ICategoryRepository: IRepository<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);
    }
}

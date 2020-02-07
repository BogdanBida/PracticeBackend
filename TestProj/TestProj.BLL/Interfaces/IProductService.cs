﻿using System;
using System.Collections.Generic;
using System.Text;
using TestProj.BLL.Models;
using TestProj.DAL.Entities;

namespace TestProj.BLL.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAllProducts();
        ProductDTO GetProductById(int id);
        ProductDTO AddProduct(ProductDTO model);
        ProductDTO DeleteProductById(int id);
        ProductDTO ChangeProduct(ProductDTO modelChanges);
    }
}
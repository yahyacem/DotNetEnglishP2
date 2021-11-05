﻿using P2FixAnAppDotNetCode.Models.Repositories;
using System;
using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models.Services
{
    /// <summary>
    /// This class provides services to manages the products
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public ProductService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Get all product from the inventory
        /// </summary>
        public List<Product> GetAllProducts()
        {
            // Return list of all products from repository
            return new List<Product>(_productRepository.GetAllProducts());
        }

        /// <summary>
        /// Get a product form the inventory by its id
        /// </summary>
        public Product GetProductById(int id)
        {
            // Return product by Id from product repository
            return _productRepository.GetAllProducts().Find(x => x.Id == id);
        }

        /// <summary>
        /// Update the quantities left for each product in the inventory depending of ordered the quantities
        /// </summary>
        public void UpdateProductQuantities(Cart cart)
        {
            // Update product inventory by using _productRepository.UpdateProductStocks() method
            foreach (CartLine cl in cart.Lines)
            {
                _productRepository.UpdateProductStocks(cl.Product.Id, cl.Quantity);
            }
        }
    }
}

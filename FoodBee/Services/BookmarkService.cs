using FoodBee.Models;
using System.Collections.Generic;

/// <summary>
/// 
/// This file contains two classes who handle bookmarking vendors and products. They both implment the generic
/// IFoodBeeService interface which makes more sense for the map layers/filter services however it can be extended
/// to work for us here.
/// 
/// The meaning of "Active" entities for these services will denote which vendors or products (by name) the user has saved.
/// 
/// </summary>
namespace FoodBee.Services
{
    public class ProductBookmarkService<T> : IFoodBeeService<Product>
    {

        /// <summary>
        /// List of products by name which the user has saved
        /// </summary>
        private List<string> _savedProducts;

        public ProductBookmarkService()
        {
            _savedProducts = new List<string>();
        }

        public void ClearActive() => _savedProducts.Clear();

        public List<string> GetActive() => _savedProducts;

        public List<Product> GetAll()
        {
            throw new System.NotSupportedException();
        }

        public int GetNumActive() => _savedProducts.Count;

        public void Toggle(string entity)
        {
            if (_savedProducts.Contains(entity))
            {
                _savedProducts.Remove(entity);
            }
            else
            {
                _savedProducts.Add(entity);
            }
        }
    }


    public class VednorBookmarkService<T> : IFoodBeeService<Vendor>
    {
        /// <summary>
        /// List of vendors by name the user has saved
        /// </summary>
        private List<string> _savedVendors;

        public VednorBookmarkService()
        {
            _savedVendors = new List<string>();
        }

        public void ClearActive() => _savedVendors.Clear();

        public List<string> GetActive() => _savedVendors;

        public List<Vendor> GetAll()
        {
            throw new System.NotSupportedException();
        }

        public int GetNumActive() => _savedVendors.Count;

        public void Toggle(string entity)
        {
            if (_savedVendors.Contains(entity))
            {
                _savedVendors.Remove(entity);
            }
            else
            {
                _savedVendors.Add(entity);
            }
        }
    }
}

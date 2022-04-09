using FoodBee.Models;
using System.Collections.Generic;
using System.Linq;

namespace FoodBee.Services
{

    public interface ISearchService
    {
        public string SearchString { get; set; }
        public SortPredicate SortBy { get; set; }
        public bool ShowVendors { get; set; }
        public List<Vendor> SearchVendors();
        public List<Product> SearchProducts();
    }

    /// <summary>
    /// The search service contains properties for searching products and vendors including the input search string, sort predicate as well
    /// as methods to filter all vendors/products and return a subset of the original items. This service allows for the properties to be 
    /// retained across page navigation.
    /// </summary>
    public class SearchService : ISearchService
    {
        /// <summary>
        /// The user inputted query string
        /// </summary>
        public string SearchString { get; set; }

        /// <summary>
        /// The active sort predicate. See type in Models.Filter
        /// </summary>
        public SortPredicate SortBy { get; set; }

        /// <summary>
        /// This is the flag indicating whether or not the UI is showing vendors or products on the search and saved pages
        /// </summary>
        public bool ShowVendors { get; set; }

        private readonly IFoodBeeService<Filter> _filters;
        private readonly IFoodBeeService<Product> _products;
        private readonly IFoodBeeService<Vendor> _vendors;

    
        /// <summary>
        /// Inject required services
        /// </summary>
        /// <param name="vendorService">Gives us the list of all known vendors</param>
        /// <param name="productService">Gives us the list of all known products</param>
        /// <param name="filterService">Gives us the filters activated by the user</param>
        /// <param name=""></param>
        public SearchService(IFoodBeeService<Vendor> vendorService, IFoodBeeService<Product> productService, IFoodBeeService<Filter> filterService)
        {
            _vendors = vendorService;
            _products = productService;
            _filters = filterService;
        }

        /// <summary>
        /// Search products based on input string, filter and sort.
        /// </summary>
        /// <returns>Products that satisfy the search parameters</returns>
        public List<Product> SearchProducts()
        {
            if (!_products.GetAll().Any()) return new List<Product>();

            List<Product> filteredProducts = _products.GetAll();

            // filter by search string
            if (!string.IsNullOrEmpty(SearchString))
            {
                filteredProducts = filteredProducts.FindAll(p => p.Name.ToLower().Contains(SearchString.ToLower()) || p.Description.ToLower().Contains(SearchString.ToLower()));
            }

            // filter by active filter selection
            List<Filter> active = _filters.GetAll().FindAll(f => _filters.GetActive().Contains(f.Name) && !string.IsNullOrEmpty(f.DataField));    // Get the active filters that have a DataField
            filteredProducts = filteredProducts.FindAll(p => active.Aggregate(true, (acc, val) => acc && p.GetType().GetProperty(val.DataField).GetValue(p, null).Equals(1)));      // filter to products that satisfy all actiuve filters

            // Sort the _products
            filteredProducts.Sort((p1, p2) =>
            {
                if (SortBy.Equals(SortPredicate.Closest))
                {     // Sort by booth asc
                    return _vendors.GetAll().Find(v => v.Name == p1.Vendor).Booth.CompareTo(_vendors.GetAll().Find(v => v.Name == p2.Vendor).Booth);
                }
                else if (SortBy.Equals(SortPredicate.Cheapest))
                {   // Sort by price asc  
                    return p1.Price.CompareTo(p2.Price);
                }
                else return 0;      // default (newest - we dont really have a way of finding this) 
            });

            return filteredProducts;
        }

        /// <summary>
        /// Search vendors based on input string, filter and sort.
        /// </summary>
        /// <returns>Vendors that satisfy the searcvh parameters</returns>
        public List<Vendor> SearchVendors()
        {
            if (!_vendors.GetAll().Any()) return new List<Vendor>();

            List<Vendor> filteredVendors = _vendors.GetAll();

            if (!string.IsNullOrEmpty(SearchString))
            {
                filteredVendors = filteredVendors.FindAll(p => p.Name.ToLower().Contains(SearchString.ToLower()) || p.Description.ToLower().Contains(SearchString.ToLower()));
            }

            // filter by active filter selection
            List<Filter> active = _filters.GetAll().FindAll(f => _filters.GetActive().Contains(f.Name) && !string.IsNullOrEmpty(f.DataField));    // Get the active filters that have a DataField
            filteredVendors = filteredVendors.FindAll(v =>
            {
                List<Product> vendorProducts = _products.GetAll().FindAll(p => p.Vendor == v.Name);
                // Look through the vendor's products, if at least one satifies the active filters we return true
                return vendorProducts.Aggregate(false, (accOuter, p) => accOuter || active.Aggregate(true, (accInner, f) => accInner && p.GetType().GetProperty(f.DataField).GetValue(p, null).Equals(1)));

            });

            // Sort the vendors
            filteredVendors.Sort((v1, v2) =>
            {
                if (SortBy.Equals(SortPredicate.Closest)) return v1.Booth.CompareTo(v2.Booth);    // Sort by booth asc
                else if (SortBy.Equals(SortPredicate.Cheapest))                                   // Sort by ave price asc
                {   // Return vendor with cheapest average price accross their products
                    List<Product> v1Products = _products.GetAll().Where(p => p.Vendor == v1.Name).ToList();
                    var v1PriceAve = v1Products.Aggregate(0, (acc, p) => acc + p.Price) / v1Products.Count();

                    List<Product> v2Products = _products.GetAll().Where(p => p.Vendor == v2.Name).ToList();
                    var v2PriceAve = v2Products.Aggregate(0, (acc, p) => acc + p.Price) / v2Products.Count();

                    return v1PriceAve.CompareTo(v2PriceAve);
                }
                else return 0;      // default - newest
            });

            return filteredVendors;
        }
    }
}

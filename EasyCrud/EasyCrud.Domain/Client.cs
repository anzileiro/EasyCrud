using System;
using System.Collections.Generic;

namespace EasyCrud.Domain
{
    public class Client
    {
        private IList<Product> _products;

        public Client()
        {
            this._products = new List<Product>();
        }

        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public ICollection<Product> Product
        {
            get
            {
                return this._products;
            }
            protected set
            {
                this._products = new List<Product>(value);
            }
        }

        public void AddProduct(Product product)
        {
            this._products.Add(product);
        }
    }
}
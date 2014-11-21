using System.Collections.Generic;

namespace EasyCrud.Domain
{
    public class Product
    {
        private IList<Client> _clients;

        protected Product()
        {
            this._clients = new List<Client>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ICollection<Client> Clients {
            get
            {
                return this._clients;
            }
            protected set
            {
                this._clients = new List<Client>(value);
            }
        }

        public void AddClients(Client client)
        {
            this._clients.Add(client);
        }
    }
}
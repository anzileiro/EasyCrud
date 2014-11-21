using EasyCrud.DataContext;
using EasyCrud.Domain;
using EasyCrud.Repository;

namespace EasyCrud.Console
{
    using System;

    class Program
    {
        private static ShopContext _context = new ShopContext();

        static void Main(string[] args)
        {
            var clientRepository = new Repository<Client>(_context);
            clientRepository.Insert(new Client
            {
                Address = "Foo street",
                Birthdate = Convert.ToDateTime("28/11/1996"),
                Email = "foo@bar.com",
                Name = "Foo Bar"
            });

            Console.Read();
        }
    }
}

using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarRent.Data
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly RentalCarsContext _context;

        public CustomerRepo(RentalCarsContext context)
        {
            _context = context;
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }

        public void AddCustomer(Customer customer)
        {
            if(customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            _context.Customers.Add(customer);
        }

        public void RemoveCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            _context.Customers.Remove(customer);
        }

        public bool UpdateCustomer(Customer customer)
        {
            //EF handles update
            return true;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public ICollection<Customer> GetByFunc(Expression<Func<Customer, bool>> predicate)
        {
            return _context.Customers.Where(predicate).ToList();
        }
    }
}

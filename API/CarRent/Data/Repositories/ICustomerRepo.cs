using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarRent.Data
{
    public interface ICustomerRepo
    {
        Customer GetCustomerById(int id);
        ICollection<Customer> GetByFunc(Expression<Func<Customer, bool>> predicate);
        void AddCustomer(Customer customer);
        void RemoveCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool SaveChanges();
    }
}

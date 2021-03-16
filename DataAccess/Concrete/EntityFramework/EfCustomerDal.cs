using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RecapProjectDBContext>, ICustomerDal
    {
        //EfCarDal daki gibi cuustomerDetailsDto ile ilgili kod blogu gelicek
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RecapProjectDBContext context = new RecapProjectDBContext())
            {
                var result = from c in context.Customers
                             join u in context.Users on c.UserId equals u.UserId
                             select new CustomerDetailDto
                             {
                                 CustomerId = c.CustomerId,
                                 UserId = u.UserId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 CompanyName = c.CompanyName
                             };

                return result.ToList();
            }
        }
    }
}

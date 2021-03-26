using System;
using System.Collections.Generic;
using System.Linq;
using CarRent.Models.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace CarRent.Data
{
    public class UserAuthenticationContext : IdentityDbContext<ApplicationUser>
    {
        public UserAuthenticationContext(DbContextOptions opt) : base(opt)
        {

        }
    }
}

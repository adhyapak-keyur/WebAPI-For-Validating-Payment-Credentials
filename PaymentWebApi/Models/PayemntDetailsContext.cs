using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentWebApi.Models
{
    public class PayemntDetailsContext : DbContext
    {
        public PayemntDetailsContext (DbContextOptions<PayemntDetailsContext> options) : base (options)
        {

        }

        public DbSet<PaymentDetails> PaymentDetails { get; set; }
    }
}

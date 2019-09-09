using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class appContext : DbContext
    {
        public appContext(DbContextOptions<appContext> options)
            : base(options)
        { }
        public DbSet<creditType> Credits { get; set; }
        public DbSet<accountType> Accounts { get; set; }
        public DbSet<interest> interests { get; set; }
        public DbSet<user> Users { get; set; }
    }
    public class user
    {
        public int ID { get; set; }
        public string userName { get; set; }
        public string userLastName { get; set; }
        public string email { get; set; }
        public string pass { get; set; }
        public int accountId { get; set; }
        public accountType account { get; set; }
    }
    public class creditType
    {
        public int ID { get; set; }
        public string creditName { get; set; }
    }
    public class accountType
    {
        public int ID { get; set; }
        public string accountName { get; set; }
    }
    public class interest
    {
        public int ID { get; set; }
        public int accountId { get; set; }
        public int creditId { get; set; }
        public  accountType account { get; set; }
        public  creditType credit { get; set; }
        public double value { get; set; }
    }
    public class userLogin
    {
       
        public string email { get; set; }
        public string pass { get; set; }
        
    }


}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Project_1.Models;

namespace Project_1.DAL
{
    public class MarvelContext : DbContext
    {
        public MarvelContext() : base("MarvelContext")
        {

        }

        public DbSet<CharacterDB> Characters { get; set; }
        public DbSet<UserDB> Users { get; set; }
    }
}
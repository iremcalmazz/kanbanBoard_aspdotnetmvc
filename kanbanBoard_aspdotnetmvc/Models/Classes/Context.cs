using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace kanbanBoard_aspdotnetmvc.Models.Classes
{
    public class Context: DbContext
    {

        public DbSet<Card> Cards { get; set; }
        public DbSet<Column> Columns { get; set; }



    }
}
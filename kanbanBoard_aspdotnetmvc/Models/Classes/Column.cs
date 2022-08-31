using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kanbanBoard_aspdotnetmvc.Models.Classes
{
    public class Column
    {
        [Key]
        public int ID { get; set; }
        public String Text { get; set; }
        public String Status { get; set; }
        public int Order { get; set; }
       
        public ICollection<Card> Cards { get; set; }

    }
}
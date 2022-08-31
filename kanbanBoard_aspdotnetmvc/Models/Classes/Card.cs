using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kanbanBoard_aspdotnetmvc.Models.Classes
{
    public class Card
    {
        [Key]
        public int ID { get; set; }
        public String CardTitle { get; set; }
        public String Description { get; set; }
        public String Category { get; set; }
        public int ColumnId { get; set; }
        public virtual Column CardStatus { get; set; }
        public String  Image { get; set; }
        public  string Order { get; set; }



    }
}
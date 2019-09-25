using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfCore_OneToOne_Mysql.Model
{
    public class Engine
    {
        public int Id { get; set; }


        [ForeignKey("Car")]
        public int CarId { get; set; }

        public string Model { get; set; }

        public string Make { get; set; }

        //      public string Type { get; set; }
        //      public int Cylinders { get; set; }
        public virtual Car Car { get; set; }
    }
}

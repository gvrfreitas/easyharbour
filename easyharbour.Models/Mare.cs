using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace easyharbour.Model
{

    [Table("TabuaMares")]
    public class TabuaMare
    {
        public Guid Id { get; set; }

        public DateTime Data { get; set; }

        public double Altura { get; set; }
    }
}

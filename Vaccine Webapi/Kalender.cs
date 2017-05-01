namespace Vaccine_Webapi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kalender")]
    public partial class Kalender
    {
        [Key]
        public DateTime Dato { get; set; }

        public int Barn_id { get; set; }

        public int Vac_id { get; set; }
    }
}

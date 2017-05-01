namespace Vaccine_Webapi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Historik")]
    public partial class Historik
    {
        [Key]
        public DateTime Dato_Vaccineret { get; set; }

        public int Barn_Id { get; set; }

        public int Vac_Id { get; set; }

        public int Vaccineret { get; set; }
    }
}

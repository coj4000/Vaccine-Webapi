namespace Vaccine_Webapi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vaccine")]
    public partial class Vaccine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Vac_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Vac_Navn { get; set; }

        [Required]
        [StringLength(100)]
        public string Vac_Info { get; set; }
    }
}

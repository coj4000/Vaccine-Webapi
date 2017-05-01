namespace Vaccine_Webapi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Barn")]
    public partial class Barn
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Barn_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Barn_Navn { get; set; }

        public int Device_id { get; set; }

        public int Gender { get; set; }
    }
}

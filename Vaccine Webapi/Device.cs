namespace Vaccine_Webapi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Device")]
    public partial class Device
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Device_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public int Telefon_nr { get; set; }
    }
}

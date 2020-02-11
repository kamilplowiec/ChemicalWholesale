namespace HurtowniaChemiczna
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Klient")]
    public partial class Klient
    {
        public int Id { get; set; }

        [Required]
        public string Nazwa { get; set; }

        [Required]
        public string Adres { get; set; }

        [Required]
        [StringLength(20)]
        public string NIP { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Haslo { get; set; }
    }
}

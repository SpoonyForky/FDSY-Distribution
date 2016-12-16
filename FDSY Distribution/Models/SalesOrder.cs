namespace FDSY_Distribution.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SalesOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalesOrder()
        {
            Bars = new HashSet<Bar>();
        }

        public int SalesOrderID { get; set; }

 
        [Required]
        public string Units { get; set; }

        [Required]
        public string TotalPrice { get; set; }

        public int Brewery_BreweryId { get; set; }

        public virtual Brewery Brewery { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bar> Bars { get; set; }
    }
}

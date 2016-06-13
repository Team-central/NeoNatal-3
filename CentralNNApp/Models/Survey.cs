namespace CentralNNApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Survey")]
    public partial class Survey
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Survey()
        {
            Interventions = new HashSet<Intervention>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? MotherID { get; set; }

        public int? Ward { get; set; }

        public int? Race { get; set; }

        public int? Premature { get; set; }

        [StringLength(50)]
        public string OBGYN { get; set; }

        [StringLength(50)]
        public string Age { get; set; }

        public int? StressLevel { get; set; }

        public int? Smoker { get; set; }

        public int? FamilySmoke { get; set; }

        public int? Alcohol { get; set; }

        public int? FamilyAlcohol { get; set; }

        public int? Drug { get; set; }

        public int? FamilyDrugs { get; set; }

        public int? ChronicIllness { get; set; }

        public int? Diet { get; set; }

        public int? GovAssit { get; set; }

        public int? Income { get; set; }

        public int? Education { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Intervention> Interventions { get; set; }

        public virtual Mother Mother { get; set; }
    }
}

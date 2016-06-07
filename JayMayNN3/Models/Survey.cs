namespace JayMayNN3.Models
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

        public int MotherID { get; set; }

        public DateTime CreatedAt { get; set; }

        public int Ward { get; set; }

        public int Race { get; set; }

        public int PreviousPremature { get; set; }

        [Required]
        [StringLength(50)]
        public string VisitOBGYN { get; set; }

        public int Age { get; set; }

        public int StressLevel { get; set; }

        public int Smoker { get; set; }

        public int FamilySmoker { get; set; }

        public int AlcoholConsumption { get; set; }

        public int FamilyAlcoholConsumption { get; set; }

        public int DrugUsage { get; set; }

        public int FamilyDrugUsage { get; set; }

        public int ChronicIllness { get; set; }

        [Required]
        [StringLength(50)]
        public string Diet { get; set; }

        public int GovAssit { get; set; }

        public int Income { get; set; }

        public int Education { get; set; }

        [Required]
        [StringLength(50)]
        public string RiskScore { get; set; }

        public int InterventionID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Intervention> Interventions { get; set; }
    }
}

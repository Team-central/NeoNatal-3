namespace CentralNNApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Intervention")]
    public partial class Intervention
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? SurveyID { get; set; }

        public string Notes_Description { get; set; }

        public virtual Survey Survey { get; set; }
    }
}

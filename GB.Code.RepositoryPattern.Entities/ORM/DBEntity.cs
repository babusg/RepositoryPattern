
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GB.Code.RepositoryPattern.Entities.ORM
{
    public partial class DBEntity
    {
        [Column("CREATEDDATE")]
        public DateTime? CreatedDate { get; set; }

        [Column("CREATEDBY")]
        [StringLength(20)]
        public string CreatedBy { get; set; }

        [Column("UPDATEDDATE")]
        public DateTime? UpdatedDate { get; set; }

        [Column("UPDATEDBY")]
        [StringLength(20)]
        public string UpdatedBy { get; set; }

    }
}

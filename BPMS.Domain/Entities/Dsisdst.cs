using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BPMS.Domain.Entities;

[Table("DSISDST", Schema = "ADMIN")]
[Index("DsCode", Name = "DSISDS_DS_CODE_UK", IsUnique = true)]
[Index("IssinfSrl", Name = "DSISDS_ISSINF_FK_I")]
[Index("UauserSrl", Name = "DSISDS_UAUSER_FK_I")]
public partial class Dsisdst
{
    [Key]
    [Column("SRL")]
    [Precision(6)]
    public int Srl { get; set; }

    [Column("ISSINF_SRL")]
    [Precision(6)]
    public int IssinfSrl { get; set; }

    [Column("DS_CODE")]
    [StringLength(20)]
    [Unicode(false)]
    public string DsCode { get; set; } = null!;

    [Column("DS_TITLE")]
    [StringLength(300)]
    [Unicode(false)]
    public string DsTitle { get; set; } = null!;

    [Column("UAUSER_SRL")]
    [Precision(6)]
    public int UauserSrl { get; set; }

    [Column("U_DATE_TIME")]
    [StringLength(20)]
    [Unicode(false)]
    public string UDateTime { get; set; } = null!;

    [InverseProperty("DsisdsSrlNavigation")]
    public virtual ICollection<Dsauddt> Dsauddts { get; set; } = new List<Dsauddt>();
}

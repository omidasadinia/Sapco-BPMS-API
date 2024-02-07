using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BPMS.Domain.Entities;

[Table("DSAUDMT", Schema = "ADMIN")]
[Index("IssinfSrl", Name = "DSAUDM_ISSINF_FK_I")]
[Index("UauserSrl", Name = "DSAUDM_UAUSER_FK_I")]
[Index("UauserSrlKk", Name = "DSAUDM_UAUSER_KK_FK_I")]
[Index("UauserSrlKm", Name = "DSAUDM_UAUSER_KM_FK_I")]
[Index("UauserSrlT", Name = "DSAUDM_UAUSER_T_FK_I")]
public partial class Dsaudmt
{
    [Key]
    [Column("SRL")]
    [Precision(6)]
    public int Srl { get; set; }

    [Column("SAL")]
    [Precision(4)]
    public int Sal { get; set; }

    [Column("MAH")]
    [Precision(2)]
    public int Mah { get; set; }

    [Column("ROZ")]
    [Precision(2)]
    public int Roz { get; set; }

    [Column("STATUS")]
    [Precision(1)]
    public bool Status { get; set; }

    [Column("UAUSER_SRL")]
    [Precision(6)]
    public int UauserSrl { get; set; }

    [Column("ISSINF_SRL")]
    [Precision(6)]
    public int IssinfSrl { get; set; }

    [Column("TOZIHAT")]
    [StringLength(1000)]
    [Unicode(false)]
    public string? Tozihat { get; set; }

    [Column("ISS_NM")]
    [StringLength(1000)]
    [Unicode(false)]
    public string? IssNm { get; set; }

    [Column("UAUSER_SRL_KM")]
    [Precision(6)]
    public int? UauserSrlKm { get; set; }

    [Column("DATE_KM")]
    [StringLength(10)]
    [Unicode(false)]
    public string? DateKm { get; set; }

    [Column("UAUSER_SRL_KK")]
    [Precision(6)]
    public int? UauserSrlKk { get; set; }

    [Column("DATE_KK")]
    [StringLength(10)]
    [Unicode(false)]
    public string? DateKk { get; set; }

    [Column("UAUSER_SRL_T")]
    [Precision(6)]
    public int? UauserSrlT { get; set; }

    [Column("DATE_T")]
    [StringLength(10)]
    [Unicode(false)]
    public string? DateT { get; set; }

    [Column("U_DATE_TIME")]
    [StringLength(20)]
    [Unicode(false)]
    public string UDateTime { get; set; } = null!;

    [InverseProperty("DsaudmSrlNavigation")]
    public virtual ICollection<Dsaudct> Dsaudcts { get; set; } = new List<Dsaudct>();

    [InverseProperty("DsaudmSrlNavigation")]
    public virtual ICollection<Dsauddt> Dsauddts { get; set; } = new List<Dsauddt>();
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BPMS.Domain.Entities;

[PrimaryKey("DsaudmSrl", "DsisdsSrl")]
[Table("DSAUDDT", Schema = "ADMIN")]
[Index("DsisdsSrl", Name = "DSAUDD_DSISDS_FK_I")]
[Index("UauserSrl", Name = "DSAUDD_UAUSER_FK_I")]
public partial class Dsauddt
{
    [Key]
    [Column("DSAUDM_SRL")]
    [Precision(6)]
    public int DsaudmSrl { get; set; }

    [Key]
    [Column("DSISDS_SRL")]
    [Precision(6)]
    public int DsisdsSrl { get; set; }

    [Column("AUD_SAL")]
    [Precision(4)]
    public int? AudSal { get; set; }

    [Column("AUD_MAH")]
    [Precision(2)]
    public int? AudMah { get; set; }

    [Column("AUD_ROZ")]
    [Precision(2)]
    public int? AudRoz { get; set; }

    [Column("T_SAL")]
    [Precision(4)]
    public int? TSal { get; set; }

    [Column("T_MAH")]
    [Precision(2)]
    public int? TMah { get; set; }

    [Column("T_ROZ")]
    [Precision(2)]
    public int? TRoz { get; set; }

    [Column("E_SAL")]
    [Precision(4)]
    public int? ESal { get; set; }

    [Column("E_MAH")]
    [Precision(2)]
    public int? EMah { get; set; }

    [Column("E_ROZ")]
    [Precision(2)]
    public int? ERoz { get; set; }

    [Column("TOZIHAT")]
    [StringLength(1000)]
    [Unicode(false)]
    public string? Tozihat { get; set; }

    [Column("UAUSER_SRL")]
    [Precision(6)]
    public int UauserSrl { get; set; }

    [Column("U_DATE_TIME")]
    [StringLength(20)]
    [Unicode(false)]
    public string UDateTime { get; set; } = null!;

    [ForeignKey("DsaudmSrl")]
    [InverseProperty("Dsauddts")]
    public virtual Dsaudmt DsaudmSrlNavigation { get; set; } = null!;

    [InverseProperty("DsauddDs")]
    public virtual ICollection<Dsddert> Dsdderts { get; set; } = new List<Dsddert>();

    [ForeignKey("DsisdsSrl")]
    [InverseProperty("Dsauddts")]
    public virtual Dsisdst DsisdsSrlNavigation { get; set; } = null!;
}

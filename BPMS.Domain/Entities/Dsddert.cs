using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BPMS.Domain.Entities;

[PrimaryKey("DsauddDsaudmSrl", "DsauddDsisdsSrl", "DsiradSrl")]
[Table("DSDDERT", Schema = "ADMIN")]
[Index("DsiradSrl", Name = "DSDDER_DSIRAD_FK_I")]
[Index("UauserSrl", Name = "DSDDER_UAUSER_FK_I")]
public partial class Dsddert
{
    [Key]
    [Column("DSAUDD_DSAUDM_SRL")]
    [Precision(6)]
    public int DsauddDsaudmSrl { get; set; }

    [Key]
    [Column("DSAUDD_DSISDS_SRL")]
    [Precision(6)]
    public int DsauddDsisdsSrl { get; set; }

    [Key]
    [Column("DSIRAD_SRL")]
    [Precision(6)]
    public int DsiradSrl { get; set; }

    [Column("UAUSER_SRL")]
    [Precision(6)]
    public int UauserSrl { get; set; }

    [Column("U_DATE_TIME")]
    [StringLength(20)]
    [Unicode(false)]
    public string UDateTime { get; set; } = null!;

    [ForeignKey("DsauddDsaudmSrl, DsauddDsisdsSrl")]
    [InverseProperty("Dsdderts")]
    public virtual Dsauddt DsauddDs { get; set; } = null!;

    [ForeignKey("DsiradSrl")]
    [InverseProperty("Dsdderts")]
    public virtual Dsiradt DsiradSrlNavigation { get; set; } = null!;
}

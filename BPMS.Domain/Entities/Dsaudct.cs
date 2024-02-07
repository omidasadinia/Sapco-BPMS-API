using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BPMS.Domain.Entities;

[PrimaryKey("DsaudmSrl", "Seq")]
[Table("DSAUDCT", Schema = "ADMIN")]
[Index("UauserSrl", Name = "DSAUDC_UAUSER_FK_I")]
public partial class Dsaudct
{
    [Key]
    [Column("DSAUDM_SRL")]
    [Precision(6)]
    public int DsaudmSrl { get; set; }

    [Key]
    [Column("SEQ")]
    [Precision(3)]
    public int Seq { get; set; }

    [Column("TITLE")]
    [StringLength(300)]
    [Unicode(false)]
    public string Title { get; set; } = null!;

    [Column("FILE_NAME")]
    [StringLength(200)]
    [Unicode(false)]
    public string? FileName { get; set; }

    [Column("UAUSER_SRL")]
    [Precision(6)]
    public int UauserSrl { get; set; }

    [Column("U_DATE_TIME")]
    [StringLength(20)]
    [Unicode(false)]
    public string UDateTime { get; set; } = null!;

    [ForeignKey("DsaudmSrl")]
    [InverseProperty("Dsaudcts")]
    public virtual Dsaudmt DsaudmSrlNavigation { get; set; } = null!;
}

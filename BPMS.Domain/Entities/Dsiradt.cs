using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BPMS.Domain.Entities;

[Table("DSIRADT", Schema = "ADMIN")]
[Index("Title", Name = "DSIRAD_TITLE_UK", IsUnique = true)]
[Index("UauserSrl", Name = "DSIRAD_UAUSER_FK_I")]
public partial class Dsiradt
{
    [Key]
    [Column("SRL")]
    [Precision(6)]
    public int Srl { get; set; }

    [Column("TITLE")]
    [StringLength(50)]
    [Unicode(false)]
    public string Title { get; set; } = null!;

    [Column("U_DATE_TIME")]
    [StringLength(20)]
    [Unicode(false)]
    public string UDateTime { get; set; } = null!;

    [Column("VER")]
    [Precision(4)]
    public int Ver { get; set; }

    [Column("UAUSER_SRL")]
    [Precision(6)]
    public int UauserSrl { get; set; }

    [InverseProperty("DsiradSrlNavigation")]
    public virtual ICollection<Dsddert> Dsdderts { get; set; } = new List<Dsddert>();
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Facturacion.Data.Models
{
    [Index(nameof(Name), Name = "RoleNameIndex", IsUnique = true)]
    public partial class AspNetRole
    {
        public AspNetRole()
        {
            Users = new HashSet<AspNetUser>();
        }

        [Key]
        [StringLength(128)]
        public string Id { get; set; } = null!;
        [StringLength(256)]
        public string Name { get; set; } = null!;

        [ForeignKey("RoleId")]
        [InverseProperty(nameof(AspNetUser.Roles))]
        public virtual ICollection<AspNetUser> Users { get; set; }
    }
}

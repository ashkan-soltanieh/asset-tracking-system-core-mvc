using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CPRG214.ATS.Domain
{
    [Table("AssetType")]
    public class AssetType
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Asset Type")]
        public string Name { get; set; }
        //navigation properties here
        public ICollection<Asset> Assets { get; set; }
    }
}

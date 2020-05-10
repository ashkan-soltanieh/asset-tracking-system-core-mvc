using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CPRG214.ATS.Domain
{
    [Table("Asset")]
    public class Asset
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tag Number")]
        public string TagNumber { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
        //required FK
        [Display(Name = "Asset Type")]
        public int AssetTypeId { get; set; }
        //navigation properties here
        public AssetType AssetType { get; set; }
    }
}

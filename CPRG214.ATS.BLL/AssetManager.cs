using CPRG214.ATS.Data;
using CPRG214.ATS.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CPRG214.ATS.BLL
{
    public class AssetManager
    {
        public static List<Asset> GetAll()
        {
            AssetsContext context = new AssetsContext();
            List<Asset> assets = context.Assets.Include(type => type.AssetType).ToList();
            return assets;
        }
        public static List<Asset> GetAllByAssetType(int id)
        {
            AssetsContext context = new AssetsContext();
            var assets = context.Assets.
                Where(asset => asset.AssetTypeId == id).
                Include(at => at.AssetType).ToList();
            return assets;
        }

        public static void Add(Asset asset)
        {
            AssetsContext context = new AssetsContext();
            context.Assets.Add(asset);
            context.SaveChanges();
        }
    }
}

using CPRG214.ATS.Data;
using CPRG214.ATS.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPRG214.ATS.BLL
{
    public class AssetTypeManager
    {
        //key value pair for dropdown list
        public static IList GetAsKeyValuePairs()
        {
            var context = new AssetsContext();
            var types = context.AssetTypes.Select(at => new
            {
                Value = at.Id,
                Text = at.Name
            }).ToList();

            return types;
        }

        public static void Add(AssetType assetType)
        {
            AssetsContext context = new AssetsContext();
            context.AssetTypes.Add(assetType);
            context.SaveChanges();
        }
    }
}

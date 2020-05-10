using CPRG214.ATS.AssetTracking.Models;
using CPRG214.ATS.BLL;
using CPRG214.ATS.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.ATS.AssetTracking.ViewComponents
{
    public class AssetsByTypeViewComponent : ViewComponent
    {
        //
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            List<Asset> assets;

            if (id == 0)
                assets = AssetManager.GetAll();
            else
                assets = AssetManager.GetAllByAssetType(id);

            var assetsViewModel = assets.Select(asset => new AssetViewModel
            {
                Description = asset.Description,
                AssetType = asset.AssetType.Name,
                TagNumber = asset.TagNumber,
                SerialNumber = asset.SerialNumber
            }).ToList();

            return View(assetsViewModel); 
            //this view returns assetsViewModel to view component section on Home view(Search.cshtml)
            //using Default.cshtml in shared foleder as ViewComponentLayout
        }
    }
}

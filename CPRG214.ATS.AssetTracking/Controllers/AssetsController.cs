using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRG214.ATS.AssetTracking.Models;
using CPRG214.ATS.BLL;
using CPRG214.ATS.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CPRG214.ATS.AssetTracking.Controllers
{
    public class AssetsController : Controller
    {
        //View for homepage
        public IActionResult Search()
        {
            ViewBag.AssetTypes = GetAssetTypes();
            return View();
        }
       
        // Utlized in ViewComponent class(AssetByType) with default layout in shared folder (2nd step on diagram)
        public IActionResult ChosenAssets(int id)
        {
            return ViewComponent("AssetsByType", id);
        }

        //Create new asset with asset type drop down
        public IActionResult Create()
        {
            var types = AssetTypeManager.GetAsKeyValuePairs();
            var typeList = new SelectList(types, "Value", "Text");
            ViewBag.AssetTypeId = typeList;
            return View();
        }

        //overloading create for post
        [HttpPost]
        public IActionResult Create(Asset asset)
        {
            try
            {
                AssetManager.Add(asset);
                return RedirectToAction("Search","Assets");
            }
            catch
            {
                return View();
            }
        }

        //To be used only for dropdown on home page. it has All Types Selection
        protected IEnumerable GetAssetTypes()
        {
            var types = AssetTypeManager.GetAsKeyValuePairs();
            var typeList = new SelectList(types, "Value", "Text");
            var typeListWithAllTypes = typeList.ToList();
            typeListWithAllTypes.Insert(0, new SelectListItem
            {
                Text = "All Types",
                Value = "0"
            });
            return typeListWithAllTypes;
        }
    }
}
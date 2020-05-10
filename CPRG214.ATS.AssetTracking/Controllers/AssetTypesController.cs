using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRG214.ATS.BLL;
using CPRG214.ATS.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CPRG214.ATS.AssetTracking.Controllers
{
    public class AssetTypesController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
        //overloading create for post
        [HttpPost]
        public IActionResult Create(AssetType assetType)
        {
            try
            {
                AssetTypeManager.Add(assetType);
                return Redirect("/Successful.html");
            }
            catch
            {
                return View();
            }
        }
    }
}
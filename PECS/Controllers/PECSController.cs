using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Hosting;
using System.IO;




// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PECS.Controllers
{
    public class PECSController : Controller
    {

		private readonly IHostingEnvironment _hostingEnvironment;
		private string rootPath;
		private string outputPath;
		List<string> Images;
		private string filePath = "";



		public PECSController(IHostingEnvironment hostingEnvironment)
		{

			_hostingEnvironment = hostingEnvironment;
			rootPath = _hostingEnvironment.ContentRootPath;
			filePath = Path.Combine(rootPath, "wwwroot\\PECSImages");
			Images = new List<string>();
	
		}


		// GET: /<controller>/
		public IActionResult PECS()
        {
			var width = 0;
			var files = Directory.GetFiles(filePath);
			foreach (var file in files)
			{
				width += 100;
				Images.Add("/PECSImages/" + Path.GetFileName(file));
			}
			ViewBag.Images = Images;
			ViewBag.optionWidth = width + "px";

			return View();
        }
    }
}

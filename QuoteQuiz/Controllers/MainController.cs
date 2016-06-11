using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuoteQuiz.Controllers
{
    public class MainController : BaseController
    {
        // GET: Main
        public ActionResult Index()
        {
            
            return View(db.Binaries.OrderBy(q => Guid.NewGuid()).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Index(int id, string correct)
        {
            var binary = db.Binaries.FirstOrDefault(b => b.Id == id);
            if (binary == null)
                return HttpNotFound();
            else {
                if (correct == "Yes")
                {
                    if (binary.Answer == true)
                        return View("Correct",binary);
                }
                 if (correct == "No")
                    if(binary.Answer == false)
                    return View("Correct", binary);
            }
            
            return View("Incorrect", binary);
            
        }

    }
}
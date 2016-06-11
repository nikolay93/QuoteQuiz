using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace QuoteQuiz.Controllers
{
    public class MultipleController : BaseController
    {
        // GET: Multiple
        public ActionResult Index()
        {
            return View(db.Multiples.Include(i => i.Answers).OrderBy(q => Guid.NewGuid()).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Index(int id, int correct)
        {
            var multiple = db.Multiples.Include(i => i.Answers).FirstOrDefault(b => b.Id == id);
            if (multiple == null)
                return HttpNotFound();
            var answer = multiple.Answers.FirstOrDefault(a => a.Id == correct);

            if (answer.Correct)
                return View("Correct",multiple);

            return View("Incorrect", multiple);

        }
    }
}
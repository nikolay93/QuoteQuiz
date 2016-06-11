using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuoteQuizModel;

namespace QuoteQuiz.Controllers
{
    public class BaseController : Controller
    {
        protected readonly QuoteQuizEntities db = new QuoteQuizEntities();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
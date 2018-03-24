using FlagQuizWebApp.Models;
using FlagQuizWebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlagQuizWebApp.Controllers
{
    public class FlagsController : Controller
    {
        FlagRepository _Repository  = new FlagRepository();

        // GET: Flags
        public ActionResult Index()
        {
            return View();
        }

        // GET: Flags
        public JsonResult Flag(int id)
        {
            Question question = new Question(_Repository.GetFlag(id), _Repository);
            return Json(new { Id = question.Id, Options = question.Options }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Answer(Answer answer)
        {
            Flag flag = _Repository.GetFlag(answer.Id);

            return Json(new { Status = flag.Name == answer.Value, Answer = answer }, JsonRequestBehavior.AllowGet);
        }

        // POST: Flags/Result
        [HttpPost]
        public JsonResult Result(List<Answer> answers)
        {
            int score = 0;

            List<string> summaries = new List<string>();

            foreach (Answer answer in answers)
            {
                string summary = "";

                Flag flag = _Repository.GetFlag(answer.Id);

                if (answer.Value == flag.Name)
                {
                    int currentScore = flag.Ratio * 10;
                    score += currentScore;
                    summary = string.Format("Bandeira {0}: Você escolheu {1}, e estava correto. :) (ganhou {2} pontos)", flag.Id, flag.Name, currentScore);
                }
                else
                {
                    summary = string.Format("Bandeira {0}: Você escolheu {1}, e o correto seria {2}. :(", flag.Id, answer.Value, flag.Name);
                }

                summaries.Add(summary);
            }

            summaries.Add(string.Format("Sua Pontuação final foi de: {0}.", score));

            return Json(new { Summary = summaries }, JsonRequestBehavior.AllowGet);
        }
    }
}

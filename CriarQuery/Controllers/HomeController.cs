using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CriarQuery.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CriarQuery()
        {
            return View();
        }

        
        public class Solicitacao
        {
            public string RESolicitante { get; set; }
            public string REFuncionario { get; set; }
            public string PeriodoAquisitivo { get; set; }
            public DateTime DataInicio { get; set; }
            public int QuantidadeDias { get; set; }
        }

        [HttpPost]
        public JsonResult CriarQueryJson(List<Solicitacao> Solicitacao)
        {
            string query = "";

            foreach (var solicitacao in Solicitacao)
            {
                var data = solicitacao.DataInicio.Year + "-" + (solicitacao.DataInicio.Month).ToString().PadLeft(2, '0') + "-" + (solicitacao.DataInicio.Day).ToString().PadLeft(2, '0');

                query += string.Format("INSERT INTO Solicitacao VALUES ('{0}', '{1}', '{2}', '{3}', GETDATE(), 2, {4}, '01');\n",
                    solicitacao.RESolicitante,
                    solicitacao.REFuncionario,
                    solicitacao.PeriodoAquisitivo,
                    data,
                    solicitacao.QuantidadeDias);
            }

            return Json(query, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
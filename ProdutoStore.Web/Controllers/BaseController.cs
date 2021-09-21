using System.Collections.Generic;
using System.Web.Mvc;

namespace ProdutoStore.Web.Controllers
{
    public class BaseController : Controller
    {
        public string Sucesso
        {
            get
            {
                if (TempData[nameof(Sucesso)] == null)
                {
                    return string.Empty;
                }

                return (string)TempData[nameof(Sucesso)];
            }

            set
            {
                TempData[nameof(Sucesso)] = value;
            }
        }

        public ICollection<string> Avisos
        {
            get
            {
                if (TempData[nameof(Avisos)] == null)
                {
                    return null;
                }

                return (ICollection<string>)TempData[nameof(Avisos)];
            }

            set
            {
                TempData[nameof(Avisos)] = value;
            }
        }

        public ICollection<string> Erros
        {
            get
            {
                if (TempData[nameof(Erros)] == null)
                {
                    return null;
                }

                return (ICollection<string>)TempData[nameof(Erros)];
            }

            set
            {
                TempData[nameof(Erros)] = value;
            }
        }

        public string UrlAtual { get => HttpContext.Request.UrlReferrer.ToString(); }
    }
}
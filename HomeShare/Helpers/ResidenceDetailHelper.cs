using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeShare.Helpers
{
    public static class ResidenceDetailHelper
    {
        public static MvcHtmlString GetDetailledList(this HtmlHelper h, IEnumerable<Residence> models)
        {
            foreach (Residence item in models)
            {

            }
            return null;
        }
    }
}
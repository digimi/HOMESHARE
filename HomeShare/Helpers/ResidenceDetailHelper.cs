﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeShare.Helpers
{
    public static class ResidenceDetailHelper
    {
        public static string GetDetailledList(this HtmlHelper h, IEnumerable<DAL.Residence> models)
        {
            foreach (DAL.Residence item in models)
            {

            }
            return "";
        }
    }
}
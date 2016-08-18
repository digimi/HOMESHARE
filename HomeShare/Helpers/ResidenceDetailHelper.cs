using DAL;
using HomeShare.Attributes;
using HomeShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HomeShare.Helpers
{
    public static class ResidenceDetailHelper
    {
        public static MvcHtmlString GetDetailledListFor<T, TValue>(this HtmlHelper h, IEnumerable<IViewModel<T>> models, Expression<Func<T, TValue>> lambda, Object htmlAttributes) where T : class 
        {
            String PropName = h.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(lambda));

            TagBuilder tag = new TagBuilder("select");
            tag.MergeAttribute("id", PropName.Replace(".", "_"));
            tag.MergeAttribute("name", PropName);
            tag.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            foreach (var item in models)
            {
                PropertyInfo ValueProperty = item.GetType().GetProperties().Where(p => p.GetCustomAttributes(typeof(ValueMemberAttribute), false) != null).FirstOrDefault();
                if(ValueProperty == null)
                {
                    throw new Exception("No property found with ValueMemberAttribute attribute");
                }
                PropertyInfo DisplayProperty = item.GetType().GetProperties().Where(p => p.GetCustomAttributes(typeof(DisplayMemberAttribute), false) != null).FirstOrDefault();
                if (DisplayProperty == null)
                {
                    throw new Exception("No property found with DisplayMemberAttribute attribute");
                }

                TagBuilder optionValue = new TagBuilder("option");
                optionValue.MergeAttribute("value", item.GetType().GetProperty(ValueProperty.Name).GetValue(item).ToString());
                optionValue.SetInnerText(item.GetType().GetProperty(DisplayProperty.Name).GetValue(item).ToString());
                tag.InnerHtml += optionValue.ToString();
            }

            return new MvcHtmlString(tag.ToString());
        }
    }
}
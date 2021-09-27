using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace EmployeeInfo.Services
{

    public class BreadcrumbService : IViewContextAware
    {
        IList<Breadcrumb> breadcrumbs;
        IList<Breadcrumb> distinctbreadcrumbs;

        public void Contextualize(ViewContext viewContext)
        {           
            breadcrumbs = new List<Breadcrumb>();
            string area = $"{viewContext.RouteData.Values["area"]}";
            string page = $"{viewContext.RouteData.Values["page"]}";
            string action = $"{viewContext.RouteData.Values["action"]}";
            object id = viewContext.RouteData.Values["id"];
            string title = $"{viewContext.ViewData["Title"]}";
            breadcrumbs.Add(new Breadcrumb(area, page, action, title, id));
            if (!string.Equals(action, "index", StringComparison.OrdinalIgnoreCase))
            {
                breadcrumbs.Insert(0, new Breadcrumb(area, page, "index", title));
            }
            distinctbreadcrumbs = breadcrumbs.Distinct(new ItemEqualityComparer()).ToList();
        }

        public IList<Breadcrumb> GetBreadcrumbs()
        {
            return distinctbreadcrumbs;
        }
    }

    public class ItemEqualityComparer : IEqualityComparer<Breadcrumb>
    {
        public bool Equals(Breadcrumb x, Breadcrumb y)
        {
            // Two items are equal if their keys are equal.
            return x.Title == y.Title;
        }
        public int GetHashCode(Breadcrumb obj)
        {
            return obj.Title.GetHashCode();
        }

    }

    public class Breadcrumb
    {
        public Breadcrumb(string area, string page, string action, string title, object id) : this(area, page, action, title)
        {
            Id = id;
        }

        public Breadcrumb(string area, string page, string action, string title)
        {
            Area = area;
            Page = page;
            Action = action;

            if (string.IsNullOrWhiteSpace(title))
            {
                Title = Regex.Replace(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(string.Equals(action, "Index", StringComparison.OrdinalIgnoreCase) ? page : action), "[a-z][A-Z]", m => m.Value[0] + " " + char.ToLower(m.Value[1]));
            }
            else
            {
                Title = title;
            }
        }

        public string Area { get; set; }
        public string Page { get; set; }
        public string Action { get; set; }
        public object Id { get; set; }
        public string Title { get; set; }
    }

}

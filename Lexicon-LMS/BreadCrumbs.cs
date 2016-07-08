using Lexicon_LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.WebPages;


namespace Lexicon_LMS
{
    public static class BreadCrumbs
    {
        private static string Linkify(this UrlHelper url, string name, string controller, string action, object id)
        {
            var link = url.RouteUrl(new { controller, action, id });
            return $"<a href=\"{link}\">{controller}: {name}</a>";
        }

        public static string BreadCrumb(this UrlHelper url, Activity entity)
        {
            var breadcrumb = url.BreadCrumb(entity.Module);
            breadcrumb += " > " + url.Linkify(entity.Name, "Activity", "Details", entity.ActivityId);
            return breadcrumb.ToString();
        }

        public static string BreadCrumb(this UrlHelper url, Module entity)
        {
            var breadcrumb = url.BreadCrumb(entity.Course);
            breadcrumb += " > " + url.Linkify(entity.Name, "Module", "Details", entity.ModuleId);
            return breadcrumb.ToString();
        }

        public static string BreadCrumb(this UrlHelper url, Course entity)
        {
            var breadcrumb = url.Linkify(entity.Name, "Course", "Details", entity.CourseId);
            return breadcrumb.ToString();
        }

        public static string BreadCrumb(this UrlHelper url, string title)
        {
            return title;
        }

    }
}
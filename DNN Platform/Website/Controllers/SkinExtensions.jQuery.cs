﻿using System;
using System.Web;
using System.Web.Mvc;

namespace DotNetNuke.Web.Mvc.Skins
{
    public static partial class SkinExtensions
    {
        public static IHtmlString jQuery(this HtmlHelper<DotNetNuke.Framework.Models.PageModel> helper, bool dnnjQueryPlugins = false, bool jQueryHoverIntent = false, bool jQueryUI = false)
        {
            var script = new TagBuilder("script");
            script.Attributes.Add("src", "~/Resources/Shared/Scripts/jquery/jquery.js");
            script.Attributes.Add("type", "text/javascript");

            if (dnnjQueryPlugins)
            {
                script.InnerHtml += "<script src=\"~/Resources/Shared/Scripts/dnn.jquery.js\" type=\"text/javascript\"></script>";
            }

            if (jQueryHoverIntent)
            {
                script.InnerHtml += "<script src=\"~/Resources/Shared/Scripts/jquery/jquery.hoverIntent.js\" type=\"text/javascript\"></script>";
            }

            if (jQueryUI)
            {
                script.InnerHtml += "<script src=\"~/Resources/Shared/Scripts/jquery/jquery-ui.js\" type=\"text/javascript\"></script>";
            }

            return new MvcHtmlString(script.ToString());
        }
    }
}

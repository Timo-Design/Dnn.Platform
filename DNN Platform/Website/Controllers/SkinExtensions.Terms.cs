﻿using System;
using System.Web;
using System.Web.Mvc;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Services.Localization;


namespace DotNetNuke.Web.Mvc.Skins
{
    public static partial class SkinExtensions
    {
        public static IHtmlString Terms(this HtmlHelper<DotNetNuke.Framework.Models.PageModel> helper, string cssClass = "SkinObject")
        {
            var portalSettings = PortalSettings.Current;
            var link = new TagBuilder("a");

            link.Attributes.Add("href", portalSettings.PortalAlias.HTTPAlias);
            link.SetInnerText(Localization.GetString("Terms.Text", Localization.GetResourceFile(helper.ViewContext.Controller, "Terms.ascx")));

            return new MvcHtmlString(link.ToString());
        }
    }
}

﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information

namespace DotNetNuke.Web.Mvc.Skins
{
    using System;
    using System.Web;
    using System.Web.Mvc;

    public static partial class SkinHelpers
    {
        public static IHtmlString CurrentDate(this HtmlHelper<DotNetNuke.Framework.Models.PageModel> helper, string cssClass = "SkinObject")
        {
            var lblDate = new TagBuilder("span");

            if (!string.IsNullOrEmpty(cssClass))
            {
                lblDate.AddCssClass(cssClass);
            }

            lblDate.SetInnerText(DateTime.Now.ToString("D"));

            return new MvcHtmlString(lblDate.ToString());
        }
    }
}

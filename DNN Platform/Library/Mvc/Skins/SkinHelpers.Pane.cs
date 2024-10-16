﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information

namespace DotNetNuke.Web.Mvc.Skins
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using DotNetNuke.Common;
    using DotNetNuke.Common.Utilities;
    using DotNetNuke.Entities.Modules;
    using DotNetNuke.Framework.JavaScriptLibraries;
    using DotNetNuke.Framework.Models;
    using DotNetNuke.UI.Modules;
    using DotNetNuke.UI.Skins;
    using DotNetNuke.Web.Client.ClientResourceManagement;

    public static partial class SkinExtensions
    {
        public static IHtmlString Pane(this HtmlHelper<DotNetNuke.Framework.Models.PageModel> htmlHelper, string paneName)
        {
            var model = htmlHelper.ViewData.Model;
            if (model == null)
            {
                throw new InvalidOperationException("The model need to be present.");
            }

            var paneDiv = new TagBuilder("div");
            paneDiv.GenerateId("dnn_" + paneName);
            paneDiv.AddCssClass("dnnPane");

            // paneDiv.AddCssClass(model.Skin.PaneCssClass);
            paneDiv.Attributes["data-name"] = paneName;

            if (model.Skin.Panes.ContainsKey(paneName))
            {
                var pane = model.Skin.Panes[paneName];
                paneDiv.AddCssClass(pane.CssClass);
                foreach (var container in pane.Containers)
                {
                    string sanitizedModuleName = Null.NullString;
                    if (!string.IsNullOrEmpty(container.Value.ModuleConfiguration.DesktopModule.ModuleName))
                    {
                        sanitizedModuleName = Globals.CreateValidClass(container.Value.ModuleConfiguration.DesktopModule.ModuleName, false);
                    }

                    var moduleDiv = new TagBuilder("div");
                    moduleDiv.AddCssClass("DnnModule-" + container.Value.ModuleConfiguration.ModuleID);
                    moduleDiv.AddCssClass("DnnModule-" + sanitizedModuleName);
                    moduleDiv.AddCssClass("DnnModule");
                    if (model.IsEditMode)
                    {
                        moduleDiv.Attributes["data-module-title"] = container.Value.ModuleConfiguration.ModuleTitle;
                    }

                    if (Globals.IsAdminControl())
                    {
                        moduleDiv.AddCssClass("DnnModule-Admin");
                    }

                    var anchor = new TagBuilder("a");
                    anchor.Attributes["name"] = container.Value.ModuleConfiguration.ModuleID.ToString();
                    moduleDiv.InnerHtml += anchor.ToString();

                    moduleDiv.InnerHtml += htmlHelper.Partial(container.Value.ContainerRazorFile, container.Value).ToHtmlString();
                    paneDiv.InnerHtml += moduleDiv.ToString();
                }
            }
            else
            {
                paneDiv.AddCssClass("DNNEmptyPane");
            }

            if (model.IsEditMode)
            {
                return MvcHtmlString.Create(paneDiv.ToString());
            }
            else
            {
                return MvcHtmlString.Create(paneDiv.InnerHtml);
            }
        }
    }
}

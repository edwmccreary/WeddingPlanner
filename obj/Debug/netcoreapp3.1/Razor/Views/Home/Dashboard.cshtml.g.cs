#pragma checksum "C:\Users\edwmc\Documents\Coding Dojo\CSharp\WeddingPlanner\Views\Home\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "15358b1dad852427313637f3700b09a448e76f4f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Dashboard), @"mvc.1.0.view", @"/Views/Home/Dashboard.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\edwmc\Documents\Coding Dojo\CSharp\WeddingPlanner\Views\_ViewImports.cshtml"
using WeddingPlanner;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\edwmc\Documents\Coding Dojo\CSharp\WeddingPlanner\Views\_ViewImports.cshtml"
using WeddingPlanner.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\edwmc\Documents\Coding Dojo\CSharp\WeddingPlanner\Views\Home\Dashboard.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15358b1dad852427313637f3700b09a448e76f4f", @"/Views/Home/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e9e38482b8beecdb199b7be73dfa5c3d6a2f574", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Wedding>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1>Welcome to the Wedding Planner</h1>\r\n    <br>\r\n    <h3>");
#nullable restore
#line 7 "C:\Users\edwmc\Documents\Coding Dojo\CSharp\WeddingPlanner\Views\Home\Dashboard.cshtml"
   Write(Context.Session.GetString("FirstName"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 7 "C:\Users\edwmc\Documents\Coding Dojo\CSharp\WeddingPlanner\Views\Home\Dashboard.cshtml"
                                           Write(Context.Session.GetString("LastName"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
    <br>
    <a href=""/wedding/new"" class=""btn btn-primary"">New Wedding</a>
    <br>
    <br>
    <table class=""table table-striped"">
        <tr>
            <th>Wedding</th>
            <th>Date</th>
            <th>Guest(s)</th>
            <th>Action</th>
        </tr>
");
#nullable restore
#line 19 "C:\Users\edwmc\Documents\Coding Dojo\CSharp\WeddingPlanner\Views\Home\Dashboard.cshtml"
          
            foreach(Wedding w in ViewBag.AllWeddings)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 642, "\"", 670, 2);
            WriteAttributeValue("", 649, "/wedding/", 649, 9, true);
#nullable restore
#line 23 "C:\Users\edwmc\Documents\Coding Dojo\CSharp\WeddingPlanner\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 658, w.WeddingId, 658, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 23 "C:\Users\edwmc\Documents\Coding Dojo\CSharp\WeddingPlanner\Views\Home\Dashboard.cshtml"
                                                   Write(w.WedderOne);

#line default
#line hidden
#nullable disable
            WriteLiteral(" & ");
#nullable restore
#line 23 "C:\Users\edwmc\Documents\Coding Dojo\CSharp\WeddingPlanner\Views\Home\Dashboard.cshtml"
                                                                  Write(w.WedderTwo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n                    <td>");
#nullable restore
#line 24 "C:\Users\edwmc\Documents\Coding Dojo\CSharp\WeddingPlanner\Views\Home\Dashboard.cshtml"
                   Write(w.Date.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 25 "C:\Users\edwmc\Documents\Coding Dojo\CSharp\WeddingPlanner\Views\Home\Dashboard.cshtml"
                   Write(w.Guests.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n");
#nullable restore
#line 27 "C:\Users\edwmc\Documents\Coding Dojo\CSharp\WeddingPlanner\Views\Home\Dashboard.cshtml"
                          
                            if(Context.Session.GetInt32("UserId") == w.UserId)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a");
            BeginWriteAttribute("href", " href=\"", 1013, "\"", 1048, 2);
            WriteAttributeValue("", 1020, "/wedding/delete/", 1020, 16, true);
#nullable restore
#line 30 "C:\Users\edwmc\Documents\Coding Dojo\CSharp\WeddingPlanner\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 1036, w.WeddingId, 1036, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">DELETE</a>\r\n");
#nullable restore
#line 31 "C:\Users\edwmc\Documents\Coding Dojo\CSharp\WeddingPlanner\Views\Home\Dashboard.cshtml"
                            }
                            else if(w.Guests.Any(g => g.UserId == Context.Session.GetInt32("UserId")))
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a");
            BeginWriteAttribute("href", " href=\"", 1262, "\"", 1297, 2);
            WriteAttributeValue("", 1269, "/wedding/unrsvp/", 1269, 16, true);
#nullable restore
#line 34 "C:\Users\edwmc\Documents\Coding Dojo\CSharp\WeddingPlanner\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 1285, w.WeddingId, 1285, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Un-RSVP</a>\r\n");
#nullable restore
#line 35 "C:\Users\edwmc\Documents\Coding Dojo\CSharp\WeddingPlanner\Views\Home\Dashboard.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a");
            BeginWriteAttribute("href", " href=\"", 1442, "\"", 1475, 2);
            WriteAttributeValue("", 1449, "/wedding/rsvp/", 1449, 14, true);
#nullable restore
#line 38 "C:\Users\edwmc\Documents\Coding Dojo\CSharp\WeddingPlanner\Views\Home\Dashboard.cshtml"
WriteAttributeValue("", 1463, w.WeddingId, 1463, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">RSVP</a>\r\n");
#nullable restore
#line 39 "C:\Users\edwmc\Documents\Coding Dojo\CSharp\WeddingPlanner\Views\Home\Dashboard.cshtml"
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 43 "C:\Users\edwmc\Documents\Coding Dojo\CSharp\WeddingPlanner\Views\Home\Dashboard.cshtml"
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Wedding> Html { get; private set; }
    }
}
#pragma warning restore 1591

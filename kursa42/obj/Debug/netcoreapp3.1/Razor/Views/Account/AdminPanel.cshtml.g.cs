#pragma checksum "C:\Users\Михаил\source\repos\kursa42\kursa42\Views\Account\AdminPanel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9d2e6a83a50dd1a9e775211ac9d8868d08b82a9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_AdminPanel), @"mvc.1.0.view", @"/Views/Account/AdminPanel.cshtml")]
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
#line 1 "C:\Users\Михаил\source\repos\kursa42\kursa42\Views\_ViewImports.cshtml"
using kursa42;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Михаил\source\repos\kursa42\kursa42\Views\_ViewImports.cshtml"
using kursa42.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9d2e6a83a50dd1a9e775211ac9d8868d08b82a9", @"/Views/Account/AdminPanel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"07b231a359eba0dc5422628f559822307b959bab", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_AdminPanel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<kursa42.Models.Soobshenie>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<table class=""table table-bordered table-dark"">
    <thead class=""border-primary"">
        <tr>
            <td scope=""col"">#</td>
            <td scope=""col"">Имя</td>
            <td scope=""col"">Фамилия</td>
            <td scope=""col"">Email</td>
            <td scope=""col"">Заметка</td>
            <td scope=""col"">Статус заявки</td>
            <td scope=""col""></td>
            <td scope=""col""></td>
        </tr>
    </thead>
    <tbody class=""border-primary"">
");
#nullable restore
#line 17 "C:\Users\Михаил\source\repos\kursa42\kursa42\Views\Account\AdminPanel.cshtml"
          
            int i = 1;
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\Михаил\source\repos\kursa42\kursa42\Views\Account\AdminPanel.cshtml"
         foreach (var messeng in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td scope=\"row\">");
#nullable restore
#line 23 "C:\Users\Михаил\source\repos\kursa42\kursa42\Views\Account\AdminPanel.cshtml"
                       Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 24 "C:\Users\Михаил\source\repos\kursa42\kursa42\Views\Account\AdminPanel.cshtml"
           Write(messeng.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 25 "C:\Users\Михаил\source\repos\kursa42\kursa42\Views\Account\AdminPanel.cshtml"
           Write(messeng.SurName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 26 "C:\Users\Михаил\source\repos\kursa42\kursa42\Views\Account\AdminPanel.cshtml"
           Write(messeng.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 27 "C:\Users\Михаил\source\repos\kursa42\kursa42\Views\Account\AdminPanel.cshtml"
           Write(messeng.Comment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 28 "C:\Users\Михаил\source\repos\kursa42\kursa42\Views\Account\AdminPanel.cshtml"
           Write(messeng.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td><a");
            BeginWriteAttribute("href", " href=\"", 886, "\"", 921, 2);
            WriteAttributeValue("", 893, "/Account/Editing/", 893, 17, true);
#nullable restore
#line 29 "C:\Users\Михаил\source\repos\kursa42\kursa42\Views\Account\AdminPanel.cshtml"
WriteAttributeValue("", 910, messeng.Id, 910, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" role=\"button\" class=\"btn btn-warning\" style=\"margin-left:10px\">Редактировать</a></td>\r\n            <td><a");
            BeginWriteAttribute("href", " href=\"", 1028, "\"", 1062, 2);
            WriteAttributeValue("", 1035, "/Account/Delete/", 1035, 16, true);
#nullable restore
#line 30 "C:\Users\Михаил\source\repos\kursa42\kursa42\Views\Account\AdminPanel.cshtml"
WriteAttributeValue("", 1051, messeng.Id, 1051, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" role=\"button\" class=\"btn btn-warning\" style=\"margin-left:10px\">Удалить</a></td>\r\n        </tr>\r\n");
#nullable restore
#line 32 "C:\Users\Михаил\source\repos\kursa42\kursa42\Views\Account\AdminPanel.cshtml"
            {
                i = i + 1;
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<kursa42.Models.Soobshenie>> Html { get; private set; }
    }
}
#pragma warning restore 1591
#pragma checksum "C:\Users\gabre\source\repos\CarrosMotosBob\Views\Perfil\Logado.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eb52836b8cabcbe2bbb9e7359f1fcf954dfddedf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Perfil_Logado), @"mvc.1.0.view", @"/Views/Perfil/Logado.cshtml")]
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
#line 1 "C:\Users\gabre\source\repos\CarrosMotosBob\Views\_ViewImports.cshtml"
using CarrosMotosBob;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\gabre\source\repos\CarrosMotosBob\Views\_ViewImports.cshtml"
using CarrosMotosBob.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb52836b8cabcbe2bbb9e7359f1fcf954dfddedf", @"/Views/Perfil/Logado.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f392620dbb6891e9ab1b62c5c67d801f203a0df7", @"/Views/_ViewImports.cshtml")]
    public class Views_Perfil_Logado : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CarrosMotosBob.Models.PerfilCliente.PerfilClienteIndexModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div id=\"clientes\">\r\n    <h3>Perfil do Usuario ");
#nullable restore
#line 3 "C:\Users\gabre\source\repos\CarrosMotosBob\Views\Perfil\Logado.cshtml"
                     Write(Model.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
    <div id=""clientesTable"">
        <table class=""table table-condensed"" id=""baseClientesIndextable"">
            <thead>
            <tr>
                <th>Nome</th>
                <th>Endereço</th>
                <th>CPF</th>
                <th>E-Mail</th>
                <th>Telefone</th>

            </tr>
            </thead>
            <tbody>
            <tr class=""clienteRow"">
                    <td");
            BeginWriteAttribute("class", " class=\"", 565, "\"", 573, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 18 "C:\Users\gabre\source\repos\CarrosMotosBob\Views\Perfil\Logado.cshtml"
                            Write(Model.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td");
            BeginWriteAttribute("class", " class=\"", 616, "\"", 624, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 19 "C:\Users\gabre\source\repos\CarrosMotosBob\Views\Perfil\Logado.cshtml"
                            Write(Model.Endereco);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td");
            BeginWriteAttribute("class", " class=\"", 671, "\"", 679, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 20 "C:\Users\gabre\source\repos\CarrosMotosBob\Views\Perfil\Logado.cshtml"
                            Write(Model.CPF);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td");
            BeginWriteAttribute("class", " class=\"", 721, "\"", 729, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 21 "C:\Users\gabre\source\repos\CarrosMotosBob\Views\Perfil\Logado.cshtml"
                            Write(Model.EMail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td");
            BeginWriteAttribute("class", " class=\"", 773, "\"", 781, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 22 "C:\Users\gabre\source\repos\CarrosMotosBob\Views\Perfil\Logado.cshtml"
                            Write(Model.Telefone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CarrosMotosBob.Models.PerfilCliente.PerfilClienteIndexModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

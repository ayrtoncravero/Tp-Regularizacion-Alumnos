#pragma checksum "D:\Users\Ayrton\Desktop\Tp - pelado\Tp-Regularizacion-Alumnos\App-web\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d807b0406fa91875177b602ea09d22b0f639c170"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages_Account_RegisterConfirmation), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Account/RegisterConfirmation.cshtml")]
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
#line 1 "D:\Users\Ayrton\Desktop\Tp - pelado\Tp-Regularizacion-Alumnos\App-web\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Users\Ayrton\Desktop\Tp - pelado\Tp-Regularizacion-Alumnos\App-web\Areas\Identity\Pages\_ViewImports.cshtml"
using App_web.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Users\Ayrton\Desktop\Tp - pelado\Tp-Regularizacion-Alumnos\App-web\Areas\Identity\Pages\_ViewImports.cshtml"
using App_web.Areas.Identity.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Users\Ayrton\Desktop\Tp - pelado\Tp-Regularizacion-Alumnos\App-web\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using App_web.Areas.Identity.Pages.Account;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d807b0406fa91875177b602ea09d22b0f639c170", @"/Areas/Identity/Pages/Account/RegisterConfirmation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a1ad27f0c1a9457c35e496a3ee25d1a14136198f", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d73cd9cd3033dc25f7f1867479acec7917ef35de", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_RegisterConfirmation : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Users\Ayrton\Desktop\Tp - pelado\Tp-Regularizacion-Alumnos\App-web\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml"
  
    ViewData["Title"] = "Confirmación de registro";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 7 "D:\Users\Ayrton\Desktop\Tp - pelado\Tp-Regularizacion-Alumnos\App-web\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
#nullable restore
#line 8 "D:\Users\Ayrton\Desktop\Tp - pelado\Tp-Regularizacion-Alumnos\App-web\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml"
  
    if (@Model.DisplayConfirmAccountLink)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <p>
        Esta aplicación actualmente no tiene un remitente de correo electrónico real registrado, consulte
        <a href=""https://aka.ms/aspaccountconf"">
            estos documentos
        </a> para saber cómo configurar un remitente de correo electrónico real.

        Normalmente esto se enviaría por correo electrónico:
        <a id=""confirm-link""");
            BeginWriteAttribute("href", " href=\"", 556, "\"", 590, 1);
#nullable restore
#line 18 "D:\Users\Ayrton\Desktop\Tp - pelado\Tp-Regularizacion-Alumnos\App-web\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml"
WriteAttributeValue("", 563, Model.EmailConfirmationUrl, 563, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            Haga clic aquí para confirmar su cuenta\r\n        </a>\r\n    </p>\r\n");
#nullable restore
#line 22 "D:\Users\Ayrton\Desktop\Tp - pelado\Tp-Regularizacion-Alumnos\App-web\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<p>\r\n    Por favor revise su correo electrónico para confirmar su cuenta.\r\n\r\n</p>\r\n");
#nullable restore
#line 29 "D:\Users\Ayrton\Desktop\Tp - pelado\Tp-Regularizacion-Alumnos\App-web\Areas\Identity\Pages\Account\RegisterConfirmation.cshtml"
    }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RegisterConfirmationModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RegisterConfirmationModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RegisterConfirmationModel>)PageContext?.ViewData;
        public RegisterConfirmationModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591

#pragma checksum "D:\Razvoj softvera 1\Razvoj-Softvera-1-master\U slucaju zajeba\Razvoj-Softvera-1-master\Ispiti\2020-01-30\Postavka\RS1_2020_01_30\Views\Takmicenje\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b6b2260aa5e617809d5ebc13a30d7d93817d6aa4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Takmicenje_Index), @"mvc.1.0.view", @"/Views/Takmicenje/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Takmicenje/Index.cshtml", typeof(AspNetCore.Views_Takmicenje_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6b2260aa5e617809d5ebc13a30d7d93817d6aa4", @"/Views/Takmicenje/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0f6eb31d1c8637546d58ee5a6164dbc58c0c748", @"/Views/_ViewImports.cshtml")]
    public class Views_Takmicenje_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RS1_2020_01_30.ViewModels.TakmicenjeIndexVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(52, 43, true);
            WriteLiteral("\r\n\r\n\r\n\r\n<h3>Korisnik moze odabrati</h3>\r\n\r\n");
            EndContext();
#line 8 "D:\Razvoj softvera 1\Razvoj-Softvera-1-master\U slucaju zajeba\Razvoj-Softvera-1-master\Ispiti\2020-01-30\Postavka\RS1_2020_01_30\Views\Takmicenje\Index.cshtml"
 using (Html.BeginForm("Choose","Takmicenje")) //ovo mi je neophodno
{

#line default
#line hidden
            BeginContext(168, 19, true);
            WriteLiteral("    <div>\r\n        ");
            EndContext();
            BeginContext(188, 29, false);
#line 11 "D:\Razvoj softvera 1\Razvoj-Softvera-1-master\U slucaju zajeba\Razvoj-Softvera-1-master\Ispiti\2020-01-30\Postavka\RS1_2020_01_30\Views\Takmicenje\Index.cshtml"
   Write(Html.Label("Skola domacin: "));

#line default
#line hidden
            EndContext();
            BeginContext(217, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(228, 85, false);
#line 12 "D:\Razvoj softvera 1\Razvoj-Softvera-1-master\U slucaju zajeba\Razvoj-Softvera-1-master\Ispiti\2020-01-30\Postavka\RS1_2020_01_30\Views\Takmicenje\Index.cshtml"
   Write(Html.DropDownListFor(x => x.SkolaId, Model.domacini,"",new { @class="form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(313, 33, true);
            WriteLiteral("\r\n    </div>\r\n    <div>\r\n        ");
            EndContext();
            BeginContext(347, 22, false);
#line 15 "D:\Razvoj softvera 1\Razvoj-Softvera-1-master\U slucaju zajeba\Razvoj-Softvera-1-master\Ispiti\2020-01-30\Postavka\RS1_2020_01_30\Views\Takmicenje\Index.cshtml"
   Write(Html.Label("Razred: "));

#line default
#line hidden
            EndContext();
            BeginContext(369, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(380, 89, false);
#line 16 "D:\Razvoj softvera 1\Razvoj-Softvera-1-master\U slucaju zajeba\Razvoj-Softvera-1-master\Ispiti\2020-01-30\Postavka\RS1_2020_01_30\Views\Takmicenje\Index.cshtml"
   Write(Html.DropDownListFor(x => x.RazredID, Model.razredi, "", new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(469, 94, true);
            WriteLiteral("\r\n    </div>\r\n    <br />\r\n    <input type=\"submit\" class=\"btn btn-default\" value=\"Odaberi\" /> ");
            EndContext();
#line 19 "D:\Razvoj softvera 1\Razvoj-Softvera-1-master\U slucaju zajeba\Razvoj-Softvera-1-master\Ispiti\2020-01-30\Postavka\RS1_2020_01_30\Views\Takmicenje\Index.cshtml"
                                                                    //nekad umjesto obicnog ActionLinka je dovoljan input type
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RS1_2020_01_30.ViewModels.TakmicenjeIndexVM> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\CreateBill.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "f1312134894d53296d7da92cf71599ef1f8c835d038eccaa7fc9a0432059db0d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_CreateBill), @"mvc.1.0.view", @"/Views/Home/CreateBill.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\_ViewImports.cshtml"
using WeSimMobifone;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\_ViewImports.cshtml"
using WeSimMobifone.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"f1312134894d53296d7da92cf71599ef1f8c835d038eccaa7fc9a0432059db0d", @"/Views/Home/CreateBill.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"bd2967129ce10f1efde1c6901f2ad8c85487520892dfef92457a1c5e49bc7d25", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_CreateBill : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\CreateBill.cshtml"
  
    ViewData["Title"] = "Đặt hàng thành công";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container px-4 px-lg-5 mt-1\">\r\n    <h3>Đặt hàng thành công</h3>\r\n    <p>Đơn hàng mã số ");
#nullable restore
#line 7 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\CreateBill.cshtml"
                 Write(Model.MaHd);

#line default
#line hidden
#nullable disable
            WriteLiteral(" trị giá ");
#nullable restore
#line 7 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\CreateBill.cshtml"
                                      Write(((int)Model.TongTien).ToString("n0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("đ đã được hệ thống ghi nhận. Chúng tôi sẽ sớm liên hệ bạn để xác nhận...</p>\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
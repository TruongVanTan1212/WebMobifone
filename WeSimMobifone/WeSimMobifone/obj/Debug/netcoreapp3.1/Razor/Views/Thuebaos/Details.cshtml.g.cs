#pragma checksum "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\Details.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3596c796283ae048fe72e34972cfdce02831a080733492716202b682cce4c8bd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Thuebaos_Details), @"mvc.1.0.view", @"/Views/Thuebaos/Details.cshtml")]
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
#line 1 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\_ViewImports.cshtml"
using WeSimMobifone;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\_ViewImports.cshtml"
using WeSimMobifone.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"3596c796283ae048fe72e34972cfdce02831a080733492716202b682cce4c8bd", @"/Views/Thuebaos/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"bd2967129ce10f1efde1c6901f2ad8c85487520892dfef92457a1c5e49bc7d25", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Thuebaos_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WeSimMobifone.Models.Thuebao>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-block btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-block btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<section class=""content"">
    <!-- row -->
    <div class=""row"">
        <div class=""col-md-3""></div>
        <div class=""col-md-6"">
            <div class=""box"">
                <div class=""box box-warning"">
                    <div class=""box-header"">
                        <i class=""fa fa-rss""></i>
                        <h3 class=""box-title"">Thông tin chi tiết thuê bao : ");
#nullable restore
#line 15 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\Details.cshtml"
                                                                       Write(Html.DisplayFor(model => model.SoThueBao));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
                        <!-- tools box -->
                    </div>
                    <div class=""box-body"">
                        <table class=""table "" style=""font-size: 15px;"">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th></th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td style=""font-weight: bold; width: 50%""> ");
#nullable restore
#line 29 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\Details.cshtml"
                                                                          Write(Html.DisplayNameFor(model => model.PhiHoaMang));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td style=\"text-align: right;\">");
#nullable restore
#line 30 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\Details.cshtml"
                                                               Write(Model.PhiHoaMang.ToString("n0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" VNĐ</td>
                                    <td style=""width: 10%""></td>
                                </tr>
                                <tr>
                                    <td style=""font-weight: bold; width: 50%"">Danh mục SIM</td>
                                    <td style=""text-align: right;"">");
#nullable restore
#line 35 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\Details.cshtml"
                                                              Write(Html.DisplayFor(model => model.MaDmNavigation.TenDm));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                    <td style=""width: 10%""></td>
                                </tr>
                                <tr>
                                    <td style=""font-weight: bold; width: 50%"">Loại thuê bao:</td>
                                    <td style=""text-align: right;"">");
#nullable restore
#line 40 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\Details.cshtml"
                                                              Write(Html.DisplayFor(model => model.MaLtbNavigation.TenL));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td style=\"width: 10%\"></td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td style=\"font-weight: bold; width: 50%\"> ");
#nullable restore
#line 44 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\Details.cshtml"
                                                                          Write(Html.DisplayNameFor(model => model.LoaiSo));

#line default
#line hidden
#nullable disable
            WriteLiteral(":</td>\r\n                                    <td style=\"text-align: right;\">");
#nullable restore
#line 45 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\Details.cshtml"
                                                              Write(Html.DisplayFor(model => model.LoaiSo));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td style=\"width: 10% \"></td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td style=\"font-weight: bold; width: 50%\"> ");
#nullable restore
#line 49 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\Details.cshtml"
                                                                          Write(Html.DisplayNameFor(model => model.DiaDiemHm));

#line default
#line hidden
#nullable disable
            WriteLiteral(":</td>\r\n                                    <td style=\"text-align: right;\">");
#nullable restore
#line 50 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\Details.cshtml"
                                                              Write(Html.DisplayFor(model => model.DiaDiemHm));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td style=\"width: 10%\"></td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td style=\"font-weight: bold; width: 50%\">");
#nullable restore
#line 54 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\Details.cshtml"
                                                                         Write(Html.DisplayNameFor(model => model.TrangThai));

#line default
#line hidden
#nullable disable
            WriteLiteral(":</td>\r\n");
#nullable restore
#line 55 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\Details.cshtml"
                                     if(Model.TrangThai == 0)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td style=\"text-align: right;\"><span class=\"label label-success\">Trống</span></td>\r\n");
#nullable restore
#line 58 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\Details.cshtml"
                                    }
                                    else
                                    {
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\Details.cshtml"
                                         if (Model.TrangThai == 1)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td style=\"text-align: right;\"><span class=\"label label-warning\">Đang giao dịch</span></td>\r\n");
#nullable restore
#line 64 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\Details.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td style=\"text-align: right;\"><span class=\"label label-info\">Kích hoạt</span></td>\r\n");
#nullable restore
#line 68 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\Details.cshtml"
                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 68 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\Details.cshtml"
                                         
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    <td style=\"width: 10%\"></td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3596c796283ae048fe72e34972cfdce02831a080733492716202b682cce4c8bd14140", async() => {
                WriteLiteral("Sửa");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 75 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\Details.cshtml"
                                                                                                 WriteLiteral(Model.MaTb);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3596c796283ae048fe72e34972cfdce02831a080733492716202b682cce4c8bd16640", async() => {
                WriteLiteral("Trở về");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                    </td>
                                    <td></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class=""col-md-3""></div>
    </div>
    <!-- /.row -->
</section><!-- /.content -->
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WeSimMobifone.Models.Thuebao> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

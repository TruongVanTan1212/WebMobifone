#pragma checksum "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "851e7f829c83990caa52a6e99999da08adb7740a6b503944ad068a73de84e28c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Details), @"mvc.1.0.view", @"/Views/Home/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"851e7f829c83990caa52a6e99999da08adb7740a6b503944ad068a73de84e28c", @"/Views/Home/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"bd2967129ce10f1efde1c6901f2ad8c85487520892dfef92457a1c5e49bc7d25", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WeSimMobifone.Models.Thuebao>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Homes", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("50px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("80px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateBill", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
  
    ViewData["Title"] = "Đăng ký thuê bao";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container-xxl py-5  hero-header mb-5"" style=""background-color: #007AFE;"">
    <div class=""container my-5 py-5 px-lg-5"">
        <div class=""row g-5 py-5"">
            <div class=""col-12 text-center m-4"">
                <h1 class=""text-white animated zoomIn"">Thanh Toán</h1>
                <hr class=""bg-white mx-auto mt-0"" style=""width: 90px;"">
                <nav aria-label=""breadcrumb"">
                    <ol class=""breadcrumb justify-content-center"">
                        <li class=""breadcrumb-item"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "851e7f829c83990caa52a6e99999da08adb7740a6b503944ad068a73de84e28c6492", async() => {
                WriteLiteral("Trang Chủ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</li>
                        <li class=""breadcrumb-item""><a class=""text-white"" href=""#""></a></li>
                        <li class=""breadcrumb-item text-white active"" aria-current=""page"">Thanh Toán</li>
                    </ol>
                </nav>
            </div>
        </div>
    </div>
</div>
</div>
<!-- Navbar & Hero End-->


<div class=""container-xxl py-5"">
    <div class=""container px-lg-5"">
        <div class=""section-title position-relative text-center mb-5 pb-2 wow fadeInUp"" data-wow-delay=""0.1s"">
            <h6 class=""position-relative d-inline text-primary ps-4"">Đăng ký thuê bao</h6>
            <h2 class=""mt-2""> Thông tin đăng ký thuê bao </h2>
        </div>
        <div class=""row g-4"">
            <div class=""col-md-6"">
                <h3>Thông tin khách hàng</h3>

");
#nullable restore
#line 36 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                 if (ViewBag.khachhang != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "851e7f829c83990caa52a6e99999da08adb7740a6b503944ad068a73de84e28c9108", async() => {
                WriteLiteral("\r\n                        <input type=\"hidden\"");
                BeginWriteAttribute("value", "  value=\"", 1714, "\"", 1740, 1);
#nullable restore
#line 39 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
WriteAttributeValue("", 1723, Model.PhiHoaMang, 1723, 17, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"phihoamang\" />\r\n                        <div class=\"my-3\">\r\n                            <label>Họ tên</label>\r\n                            <input type=\"text\" disabled");
                BeginWriteAttribute("value", " value=\"", 1914, "\"", 1944, 1);
#nullable restore
#line 42 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
WriteAttributeValue("", 1922, ViewBag.khachhang.Ten, 1922, 22, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"hoten\" class=\"form-control\" />\r\n                        </div>\r\n                        <div class=\"my-3\">\r\n                            <label>Email</label>\r\n                            <input type=\"email\" disabled");
                BeginWriteAttribute("value", " value=\"", 2166, "\"", 2198, 1);
#nullable restore
#line 46 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
WriteAttributeValue("", 2174, ViewBag.khachhang.Email, 2174, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"email\" class=\"form-control\" />\r\n                        </div>\r\n                        <div class=\"my-3\">\r\n                            <label>Điện thoại</label>\r\n                            <input type=\"text\" disabled");
                BeginWriteAttribute("value", " value=\"", 2424, "\"", 2460, 1);
#nullable restore
#line 50 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
WriteAttributeValue("", 2432, ViewBag.khachhang.DienThoai, 2432, 28, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"dienthoai\" class=\"form-control\" />\r\n                        </div>\r\n                        <div class=\"my-3\">\r\n                            <label>Căn cước công dân</label>\r\n");
#nullable restore
#line 54 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                             if (@ViewBag.khachhang.Cccd == null)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <input type=\"text\"");
                BeginWriteAttribute("value", " value=\"", 2790, "\"", 2821, 1);
#nullable restore
#line 56 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
WriteAttributeValue("", 2798, ViewBag.khachhang.Cccd, 2798, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"cccd\" class=\"form-control\" />\r\n");
#nullable restore
#line 57 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <input type=\"text\" disabled");
                BeginWriteAttribute("value", " value=\"", 3015, "\"", 3046, 1);
#nullable restore
#line 60 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
WriteAttributeValue("", 3023, ViewBag.khachhang.Cccd, 3023, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"cccd\" class=\"form-control\" />\r\n");
#nullable restore
#line 61 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </div>\r\n                        <div class=\"my-3\">\r\n                            <label>Ảnh căn cước công dân mặt trước</label>\r\n");
#nullable restore
#line 65 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                             if (@ViewBag.khachhang.HinhT == null)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <input type=\"file\" name=\"hinht\" class=\"form-control\" />\r\n");
#nullable restore
#line 68 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "851e7f829c83990caa52a6e99999da08adb7740a6b503944ad068a73de84e28c14699", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 3594, "~/img/", 3594, 6, true);
#nullable restore
#line 71 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
AddHtmlAttributeValue("", 3600, ViewBag.khachhang.HinhT, 3600, 24, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 72 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </div>\r\n                        <div class=\"my-3\">\r\n                            <label>Ảnh căn cước công dân mặt sau</label>\r\n");
#nullable restore
#line 76 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                             if (@ViewBag.khachhang.HinhS == null)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <input type=\"file\" name=\"hinhs\" class=\"form-control\" />\r\n");
#nullable restore
#line 79 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "851e7f829c83990caa52a6e99999da08adb7740a6b503944ad068a73de84e28c17620", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 4164, "~/img/", 4164, 6, true);
#nullable restore
#line 82 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
AddHtmlAttributeValue("", 4170, ViewBag.khachhang.HinhS, 4170, 24, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 83 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </div>\r\n                        <div class=\"my-3\">\r\n                            <label>Địa chỉ 1</label> <br />\r\n");
#nullable restore
#line 87 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                             foreach (Diachi dc in ViewBag.diachi)
                            {
                                string tmp = dc.DiaChi1 + ", " + dc.PhuongXa + ", " + dc.QuanHuyen + ", " + dc.TinhThanh;
                                if (dc.MacDinh == 1)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <input type=\"radio\"");
                BeginWriteAttribute("id", " id=\"", 4761, "\"", 4774, 1);
#nullable restore
#line 92 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
WriteAttributeValue("", 4766, dc.MaDc, 4766, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"madiachi\"");
                BeginWriteAttribute("value", " value=\"", 4791, "\"", 4807, 1);
#nullable restore
#line 92 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
WriteAttributeValue("", 4799, dc.MaDc, 4799, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" checked=\"True\">\r\n                                    <label");
                BeginWriteAttribute("for", " for=\"", 4868, "\"", 4882, 1);
#nullable restore
#line 93 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
WriteAttributeValue("", 4874, dc.MaDc, 4874, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 93 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                                                     Write(tmp);

#line default
#line hidden
#nullable disable
                WriteLiteral(" (Mặc định)</label>\r\n                                    <br>\r\n");
#nullable restore
#line 95 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <input type=\"radio\"");
                BeginWriteAttribute("id", " id=\"", 5114, "\"", 5127, 1);
#nullable restore
#line 98 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
WriteAttributeValue("", 5119, dc.MaDc, 5119, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"madiachi\"");
                BeginWriteAttribute("value", " value=\"", 5144, "\"", 5160, 1);
#nullable restore
#line 98 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
WriteAttributeValue("", 5152, dc.MaDc, 5152, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                    <label");
                BeginWriteAttribute("for", " for=\"", 5206, "\"", 5220, 1);
#nullable restore
#line 99 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
WriteAttributeValue("", 5212, dc.MaDc, 5212, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 99 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                                                     Write(tmp);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                                    <br>\r\n");
#nullable restore
#line 101 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                                }
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        </div>
                        }
                        <div class=""my-3"">
                            <input type=""submit"" value=""Xác nhận đặt hàng"" class=""btn btn-success"" />
                        </div>
                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 38 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                                                    WriteLiteral(Model.MaTb);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 109 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n            <div class=\"col-md-6\">\r\n                <dl class=\"dl-horizontal\">\r\n                    <dt>\r\n                        ");
#nullable restore
#line 114 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.SoThueBao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd>\r\n                        ");
#nullable restore
#line 117 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                   Write(Html.DisplayFor(model => model.SoThueBao));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt>\r\n                        ");
#nullable restore
#line 120 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.PhiHoaMang));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd>\r\n                        ");
#nullable restore
#line 123 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                   Write(Html.DisplayFor(model => model.PhiHoaMang));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt>\r\n                        ");
#nullable restore
#line 126 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.LoaiSo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd>\r\n                        ");
#nullable restore
#line 129 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                   Write(Html.DisplayFor(model => model.LoaiSo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt>\r\n                        ");
#nullable restore
#line 132 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.DiaDiemHm));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd>\r\n                        ");
#nullable restore
#line 135 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                   Write(Html.DisplayFor(model => model.DiaDiemHm));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt>\r\n                        ");
#nullable restore
#line 138 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.TrangThai));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd>\r\n                        ");
#nullable restore
#line 141 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                   Write(Html.DisplayFor(model => model.TrangThai));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt>\r\n                        ");
#nullable restore
#line 144 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.MaDmNavigation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd>\r\n                        ");
#nullable restore
#line 147 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                   Write(Html.DisplayFor(model => model.MaDmNavigation.TenDm));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                    <dt>\r\n                        ");
#nullable restore
#line 150 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                   Write(Html.DisplayNameFor(model => model.MaLtbNavigation));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dt>\r\n                    <dd>\r\n                        ");
#nullable restore
#line 153 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Home\Details.cshtml"
                   Write(Html.DisplayFor(model => model.MaLtbNavigation.TenL));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </dd>\r\n                </dl>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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

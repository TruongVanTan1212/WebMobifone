#pragma checksum "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\ShowThueBaoKhachHuy.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "427df854d49ec4f72171dc46e7371f788f48acb4acd32f21c0b20590cb2b793c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ShowThueBaoKhachHuy), @"mvc.1.0.view", @"/Views/Admin/ShowThueBaoKhachHuy.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"427df854d49ec4f72171dc46e7371f788f48acb4acd32f21c0b20590cb2b793c", @"/Views/Admin/ShowThueBaoKhachHuy.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"bd2967129ce10f1efde1c6901f2ad8c85487520892dfef92457a1c5e49bc7d25", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_ShowThueBaoKhachHuy : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WeSimMobifone.Models.Qlthuebao>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\ShowThueBaoKhachHuy.cshtml"
  
    ViewData["Title"] = "Thông tin thuê bao hủy khách hàng";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- Main content -->
<section class=""content"">
    <div class=""row"">
        <div class=""col-md-1""></div>
        <div class=""col-md-10"">
            <div class=""box box-primary"">
                <div class=""box-header"">
                    <h3>Thuê bao đã đăng ký</h3>
                </div><!-- /.box-header -->
                <div class=""box-body"">
                    <table id=""example1"" class=""table table-bordered text-center"">
                        <thead>
                            <tr>
                                <th style=""width:5%;"">
                                    Stt
                                </th>
                                <th style=""width:40%;"">
                                    Số thuê bao
                                </th>
                                <th style=""width:40%;"">
                                    Ngày kích hoạt
                                </th>
                                <th style=""width:10%;"">
                       ");
            WriteLiteral("             Trạng thái\r\n                                </th>\r\n                                <th style=\"width:5%;\"></th>\r\n                            </tr>\r\n                        </thead>\r\n                        <tbody>\r\n");
#nullable restore
#line 34 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\ShowThueBaoKhachHuy.cshtml"
                              
                                int stt = 1;
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\ShowThueBaoKhachHuy.cshtml"
                                 foreach (Qlthuebao i in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr class=\"table-success\">\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 40 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\ShowThueBaoKhachHuy.cshtml"
                                        Write(stt);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 43 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\ShowThueBaoKhachHuy.cshtml"
                                       Write(i.MaTbNavigation.SoThueBao);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 46 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\ShowThueBaoKhachHuy.cshtml"
                                       Write(i.NgayKichHoat);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </td>
                                        <td>

                                           <span class=""label label-danger"">Đã hủy</span>
                                        </td>
                                        <td></td>
                                    </tr>
");
#nullable restore
#line 54 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\ShowThueBaoKhachHuy.cshtml"
                                    stt++;
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"col-md-1\"></div>\r\n    </div>\r\n</section>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WeSimMobifone.Models.Qlthuebao>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
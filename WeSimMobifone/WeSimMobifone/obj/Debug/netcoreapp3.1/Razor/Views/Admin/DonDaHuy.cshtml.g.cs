#pragma checksum "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\DonDaHuy.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "c75b98ea8c2d53fa7729c84e7a4680dc9ec7da43d03267c8f216a00e27d757d2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_DonDaHuy), @"mvc.1.0.view", @"/Views/Admin/DonDaHuy.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"c75b98ea8c2d53fa7729c84e7a4680dc9ec7da43d03267c8f216a00e27d757d2", @"/Views/Admin/DonDaHuy.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"bd2967129ce10f1efde1c6901f2ad8c85487520892dfef92457a1c5e49bc7d25", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_DonDaHuy : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WeSimMobifone.Models.Hoadon>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\DonDaHuy.cshtml"
  
    ViewData["Title"] = "Hoá Đơn khách hàng";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- Main content -->
<section class=""content"">
    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""box box-primary"">
                <div class=""box-header"">
                    <div class=""col-lg-4"">
                        <h3>Lịch sử đơn hàng đã huỷ</h3>
                    </div>
                </div><!-- /.box-header -->
                <div class=""box-body"">
                    <table id=""example1"" class=""table table-bordered text-center"">
                        <thead>
                            <tr>
                                <th style=""width:5%;"">
                                    Stt
                                </th>
                                <th style=""width:15%;"">
                                    Số thuê bao
                                </th>
                                <th style=""width:10%;"">
                                    Ngày đặt
                                </th>
                                <th style=""w");
            WriteLiteral(@"idth:40%;"">
                                    Địa Chỉ
                                </th>
                                <th style=""width:10%;"">
                                    Tổng tiền
                                </th>
                                <th style=""width:10%;"">
                                    Trạng thái
                                </th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 41 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\DonDaHuy.cshtml"
                              
                                int stt = 1;
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\DonDaHuy.cshtml"
                                 foreach (Hoadon i in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr class=\"table-success\">\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 47 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\DonDaHuy.cshtml"
                                        Write(stt);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 50 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\DonDaHuy.cshtml"
                                       Write(i.MaTbNavigation.SoThueBao);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 53 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\DonDaHuy.cshtml"
                                       Write(i.Ngay);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 56 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\DonDaHuy.cshtml"
                                       Write(i.MaDcNavigation.DiaChi1);

#line default
#line hidden
#nullable disable
            WriteLiteral(",");
#nullable restore
#line 56 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\DonDaHuy.cshtml"
                                                                 Write(i.MaDcNavigation.PhuongXa);

#line default
#line hidden
#nullable disable
            WriteLiteral(",");
#nullable restore
#line 56 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\DonDaHuy.cshtml"
                                                                                            Write(i.MaDcNavigation.QuanHuyen);

#line default
#line hidden
#nullable disable
            WriteLiteral(",");
#nullable restore
#line 56 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\DonDaHuy.cshtml"
                                                                                                                        Write(i.MaDcNavigation.TinhThanh);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 59 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\DonDaHuy.cshtml"
                                       Write(i.TongTien.ToString("n0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" VNĐ
                                        </td>
                                        <td>
                                            <span class=""label label-danger"">Đã huỷ</span>
                                        </td>
                                    </tr>
");
#nullable restore
#line 65 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\DonDaHuy.cshtml"
                                    stt++;
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n                <div class=\"box-footer\">\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WeSimMobifone.Models.Hoadon>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

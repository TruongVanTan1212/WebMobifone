#pragma checksum "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "be798c09cbd3c032e81c9756738dab838a937e375cd4621e3dd8a801a10c20e4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_InHoaDon1), @"mvc.1.0.view", @"/Views/Admin/InHoaDon1.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"be798c09cbd3c032e81c9756738dab838a937e375cd4621e3dd8a801a10c20e4", @"/Views/Admin/InHoaDon1.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"bd2967129ce10f1efde1c6901f2ad8c85487520892dfef92457a1c5e49bc7d25", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_InHoaDon1 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WeSimMobifone.Models.Hoadon>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml"
  
    ViewData["Title"] = "In hoá đơn";
    Layout = "~/Views/Shared/_LayoutIn.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- Main content -->
<section class=""invoice"">
    <!-- title row -->
    <div class=""row"">
        <div class=""col-xs-12"">
            <h2 class=""page-header"">
                <i class=""fa fa-globe""></i> Thông tin chi tiết hoá đơn
                <small class=""pull-right"">");
#nullable restore
#line 14 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml"
                                     Write(Html.DisplayFor(model => model.Ngay));

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n            </h2>\r\n        </div><!-- /.col -->\r\n    </div>\r\n    <!-- info row -->\r\n    <div class=\"row invoice-info\">\r\n        <div class=\"col-sm-4 invoice-col\">\r\n            From\r\n");
#nullable restore
#line 22 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml"
             foreach (var i in (List<Cuahang>)ViewBag.cuahang)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <address>\r\n                    <strong>");
#nullable restore
#line 25 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml"
                       Write(i.Ten);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong><br />\r\n                    ");
#nullable restore
#line 26 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml"
               Write(i.DiaChi);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                    Điện thoại: ");
#nullable restore
#line 27 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml"
                           Write(i.DienThoai);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                    Email: ");
#nullable restore
#line 28 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml"
                      Write(i.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </address>\r\n");
#nullable restore
#line 30 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div><!-- /.col -->\r\n        <div class=\"col-sm-4 invoice-col\">\r\n            To\r\n            <address>\r\n                <strong>");
#nullable restore
#line 35 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml"
                   Write(Html.DisplayFor(model => model.MaKhNavigation.Ten));

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong><br />\r\n                ");
#nullable restore
#line 36 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml"
           Write(Html.DisplayFor(model => model.MaDcNavigation.DiaChi1));

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 36 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml"
                                                                    Write(Html.DisplayFor(model => model.MaDcNavigation.PhuongXa));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br>\r\n                ");
#nullable restore
#line 37 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml"
           Write(Html.DisplayFor(model => model.MaDcNavigation.QuanHuyen));

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 37 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml"
                                                                      Write(Html.DisplayFor(model => model.MaDcNavigation.TinhThanh));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br>\r\n                Phone: ");
#nullable restore
#line 38 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml"
                  Write(Html.DisplayFor(model => model.MaKhNavigation.DienThoai));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                Email: ");
#nullable restore
#line 39 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml"
                  Write(Html.DisplayFor(model => model.MaKhNavigation.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                Căn Cước Công Dân : ");
#nullable restore
#line 40 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml"
                               Write(Html.DisplayFor(model => model.MaKhNavigation.Cccd));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n            </address>\r\n        </div><!-- /.col -->\r\n        <div class=\"col-sm-4 invoice-col\">\r\n            <b>Thông tin đơn hàng</b><br />\r\n            <br />\r\n            <b>Mã hoá đơn:</b> ");
#nullable restore
#line 46 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml"
                          Write(Html.DisplayFor(model => model.MaHd));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n            <b>Ngày đặt:</b> ");
#nullable restore
#line 47 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml"
                        Write(Html.DisplayFor(model => model.Ngay));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n            <b>Mã khách hàng:</b> ");
#nullable restore
#line 48 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml"
                             Write(Html.DisplayFor(model => model.MaKhNavigation.MaKh));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </div><!-- /.col -->
    </div><!-- /.row -->
    <!-- Table row -->
    <div class=""row"">
        <div class=""col-xs-12 table-responsive"">
            <table class=""table table-striped"">
                <thead>
                    <tr>
                        <th>Mã thuê bao</th>
                        <th>Số Thuê bao</th>
                        <th>Loại số</th>
                        <th>Địa điểm hoà mạng</th>
                        <th>Phí Hoà mạng</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>");
#nullable restore
#line 66 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml"
                       Write(Html.DisplayFor(model => model.MaTbNavigation.MaTb));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 67 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml"
                       Write(Html.DisplayFor(model => model.MaTbNavigation.SoThueBao));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 68 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml"
                       Write(Html.DisplayFor(model => model.MaTbNavigation.LoaiSo));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 69 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml"
                       Write(Html.DisplayFor(model => model.MaTbNavigation.DiaDiemHm));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 70 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml"
                       Write(Html.DisplayFor(model => model.MaTbNavigation.PhiHoaMang));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" VNĐ</td>
                    </tr>
                </tbody>
            </table>
        </div><!-- /.col -->
    </div><!-- /.row -->

    <div class=""row"">
        <!-- accepted payments column -->
        <div class=""col-xs-6"">
            <p class=""lead"">Payment Methods:</p>
            <img src=""../../dist/img/credit/visa.png"" alt=""Visa"" />
            <img src=""../../dist/img/credit/mastercard.png"" alt=""Mastercard"" />
            <img src=""../../dist/img/credit/american-express.png"" alt=""American Express"" />
            <img src=""../../dist/img/credit/paypal2.png"" alt=""Paypal"" />
            <p class=""text-muted well well-sm no-shadow"" style=""margin-top: 10px;"">
                Sau khi nhận được SIM , xin quý khách vui lòng truy cập trang website Mobifone An Giang vào mục <b>"" hướng dẫn ""</b> chọn phần <b>"" Kích hoạt ""</b> làm theo hướng dẫn để có thể sử dụng SIM . Sau khi kích hoạt xong xin nhấn vào nút <b>""Kích hoạt"" </b> tại mục<b>"" lịch sử hoá đơn ""</b>. Xin chân thành cảm ơn quý kh");
            WriteLiteral("ách !\r\n            </p>\r\n        </div><!-- /.col -->\r\n        <div class=\"col-xs-6\">\r\n            <p class=\"lead\">Ngày đặt hàng: ");
#nullable restore
#line 90 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml"
                                      Write(Html.DisplayFor(model => model.Ngay));

#line default
#line hidden
#nullable disable
            WriteLiteral("  </p>\r\n            <div class=\"table-responsive\">\r\n                <table class=\"table\">\r\n                    <tr>\r\n                        <th style=\"width:50%\">Phí hoà mạng:</th>\r\n                        <td>");
#nullable restore
#line 95 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml"
                       Write(Html.DisplayFor(model => model.MaTbNavigation.PhiHoaMang));

#line default
#line hidden
#nullable disable
            WriteLiteral(@" VNĐ</td>
                    </tr>
                    <tr>
                        <th>Phí giữ số:</th>
                        <td> 0 VND</td>
                    </tr>
                    <tr>
                        <th>Phí vận chuyển:</th>
                        <td> 0 VND</td>
                    </tr>
                    <tr>
                        <th>Thành tiền:</th>
                        <td>");
#nullable restore
#line 107 "C:\Users\DELL\OneDrive\Desktop\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Admin\InHoaDon1.cshtml"
                       Write(Html.DisplayFor(model => model.MaTbNavigation.PhiHoaMang));

#line default
#line hidden
#nullable disable
            WriteLiteral(" VNĐ</td>\r\n                    </tr>\r\n                </table>\r\n            </div>\r\n        </div><!-- /.col -->\r\n    </div><!-- /.row -->\r\n    <!-- this row will not appear when printing -->\r\n</section><!-- /.content -->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WeSimMobifone.Models.Hoadon> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

#pragma checksum "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "bd02745bcd5da83aa795c5ca7cad7b46328e5c80a2c178e67af5e89f32cfc90f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Thuebaos_InHoaDonKH), @"mvc.1.0.view", @"/Views/Thuebaos/InHoaDonKH.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"bd02745bcd5da83aa795c5ca7cad7b46328e5c80a2c178e67af5e89f32cfc90f", @"/Views/Thuebaos/InHoaDonKH.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"bd2967129ce10f1efde1c6901f2ad8c85487520892dfef92457a1c5e49bc7d25", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Thuebaos_InHoaDonKH : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WeSimMobifone.Models.Hoadon>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml"
  
    ViewData["Title"] = "In hoá đơn";
    Layout = "~/Views/Shared/_LayoutIn.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- Main content -->\r\n<section class=\"invoice\">\r\n");
#nullable restore
#line 9 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml"
     foreach (Hoadon item in ViewBag.Hoadon)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <!-- title row -->
        <div class=""row"">
            <div class=""col-xs-12"">
                <h2 class=""page-header"">
                    <i class=""fa fa-globe""></i> Thông tin chi tiết hoá đơn
                    <small class=""pull-right"">");
#nullable restore
#line 16 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml"
                                         Write(item.Ngay);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</small>
                </h2>
            </div><!-- /.col -->
        </div>
        <!-- info row -->
        <div class=""row invoice-info"">
            <div class=""col-sm-4 invoice-col"">
                From
                    <address>
                    <strong>");
#nullable restore
#line 25 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml"
                       Write(ViewBag.cuahang.Ten);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong><br />\r\n                    ");
#nullable restore
#line 26 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml"
               Write(ViewBag.cuahang.DiaChi);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                    Điện thoại: ");
#nullable restore
#line 27 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml"
                           Write(ViewBag.cuahang.DienThoai);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                    Email: ");
#nullable restore
#line 28 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml"
                      Write(ViewBag.cuahang.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </address>\r\n            </div><!-- /.col -->\r\n            <div class=\"col-sm-4 invoice-col\">\r\n                To\r\n                <address>\r\n                    <strong>");
#nullable restore
#line 34 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml"
                       Write(item.MaKhNavigation.Ten);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong><br>\r\n                    ");
#nullable restore
#line 35 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml"
               Write(item.MaDcNavigation.DiaChi1);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 35 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml"
                                             Write(item.MaDcNavigation.PhuongXa);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br>\r\n                    ");
#nullable restore
#line 36 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml"
               Write(item.MaDcNavigation.QuanHuyen);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 36 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml"
                                               Write(item.MaDcNavigation.TinhThanh);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br>\r\n                    Điện thoại: ");
#nullable restore
#line 37 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml"
                           Write(item.MaKhNavigation.DienThoai);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                    Email: ");
#nullable restore
#line 38 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml"
                      Write(item.MaKhNavigation.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                    Căn Cước Công Dân : ");
#nullable restore
#line 39 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml"
                                   Write(item.MaKhNavigation.Cccd);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                </address>\r\n            </div><!-- /.col -->\r\n            <div class=\"col-sm-4 invoice-col\">\r\n                <b>Thông tin đơn hàng</b><br />\r\n                <br />\r\n                <b>Mã hoá đơn:</b> ");
#nullable restore
#line 45 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml"
                              Write(item.MaHd);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                <b>Ngày đặt:</b> ");
#nullable restore
#line 46 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml"
                            Write(item.Ngay);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                <b>Mã khách hàng:</b> ");
#nullable restore
#line 47 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml"
                                 Write(item.MaKhNavigation.MaKh);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div><!-- /.col -->\r\n        </div>\r\n");
            WriteLiteral(@"        <!-- /.row -->
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
#line 67 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml"
                           Write(item.MaTbNavigation.MaTb);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 68 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml"
                           Write(item.MaTbNavigation.SoThueBao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 69 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml"
                           Write(item.MaTbNavigation.LoaiSo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 70 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml"
                           Write(item.MaTbNavigation.DiaDiemHm);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 71 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml"
                           Write(item.MaTbNavigation.PhiHoaMang.ToString("n0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" VNĐ</td>\r\n                        </tr>\r\n                    </tbody>\r\n                </table>\r\n            </div><!-- /.col -->\r\n        </div>\r\n");
            WriteLiteral("        <!-- /.row -->\r\n");
            WriteLiteral(@"        <div class=""row"">
            <!-- accepted payments column -->
            <div class=""col-xs-6"">
                <p class=""lead"">Payment Methods:</p>
                <img src=""../../dist/img/credit/visa.png"" alt=""Visa"" />
                <img src=""../../dist/img/credit/mastercard.png"" alt=""Mastercard"" />
                <img src=""../../dist/img/credit/american-express.png"" alt=""American Express"" />
                <img src=""../../dist/img/credit/paypal2.png"" alt=""Paypal"" />
                <p class=""text-muted well well-sm no-shadow"" style=""margin-top: 10px;"">
                    Sau khi nhận được SIM , xin quý khách vui lòng truy cập trang website Mobifone An Giang vào mục <b>"" hướng dẫn ""</b> chọn phần <b>"" Kích hoạt ""</b> làm theo hướng dẫn để có thể sử dụng SIM . Sau khi kích hoạt xong xin nhấn vào nút <b>""Kích hoạt"" </b> tại mục<b>"" lịch sử hoá đơn ""</b>. Xin chân thành cảm ơn quý khách !
                </p>
            </div><!-- /.col -->
            <div class=""col-xs-6"">
     ");
            WriteLiteral("           <p class=\"lead\">Ngày đặt hàng: ");
#nullable restore
#line 93 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml"
                                          Write(item.Ngay);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                <div class=\"table-responsive\">\r\n                    <table class=\"table\">\r\n                        <tr>\r\n                            <th style=\"width:50%\">Phí hoà mạng:</th>\r\n                            <td>");
#nullable restore
#line 98 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml"
                           Write(item.MaTbNavigation.PhiHoaMang.ToString("n0"));

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
                            <th>
                            <td>");
#nullable restore
#line 110 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml"
                           Write(item.MaTbNavigation.PhiHoaMang.ToString("n0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" VNĐ</td>\r\n                        </tr>\r\n                    </table>\r\n                </div>\r\n            </div><!-- /.col -->\r\n        </div>\r\n        <!-- /.row -->\r\n");
#nullable restore
#line 117 "D:\báo Cáo thực tập\DTH205971_TruongVanTan\DTH205971_TruongVanTan\WebMobifone\WeSimMobifone\WeSimMobifone\Views\Thuebaos\InHoaDonKH.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</section><!-- /.content -->\r\n\r\n");
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

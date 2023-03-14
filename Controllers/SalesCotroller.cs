using Microsoft.AspNetCore.Mvc;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;
namespace html_pdf_api.Controllers;

[ApiController]
[Route("[controller]")]
public class SalesController : ControllerBase
{
    [HttpPost("generatepdf")]
    public FileContentResult GeneratePDF([FromBody] SalesReportI body)
    {
        var document = new PdfDocument();

        var utils = new Utils();
        string htmlcontent = "<!DOCTYPE html>";
        htmlcontent += "<html lang='en'>";
        htmlcontent += "<head>";
        htmlcontent += "<meta charset='UTF-8'>";
        htmlcontent += " <meta http-equiv='X-UA-Compatible' content='IE=edge'>";
        htmlcontent += " <meta name='viewport' content='width=device-width, initial-scale=1' />";
        htmlcontent += "<style>";
        htmlcontent += "html { -webkit-print-color-adjust: exact;style='page-break-after:always;' } @page { margin: 10px;}";
        htmlcontent += "</style>";
        htmlcontent += "</head>";
        htmlcontent += "<body class='h-screen p-5' style='page-break-after:always;height:100vh !important;'>";
        htmlcontent += "<table style='width:100%'>";
        htmlcontent += "<tr>";
        htmlcontent += "<td style='width:80%;font-weight:600;font-size:20px'>";
        htmlcontent += $"El Sotano - {body.title}";
        htmlcontent += "</td>";
        htmlcontent += "<td style='width:20%'>";
        htmlcontent += "<img style='width:70px;float:right;' src='https://afraco-admin-app-5sl9b.ondigitalocean.app/assets/logo.7b275812.png'>";
        htmlcontent += "</td>";
        htmlcontent += "</tr>";
        htmlcontent += "</table>";
        htmlcontent += "<div style='margin-top:10px'>";
        htmlcontent += "<table>";
        htmlcontent += " <tr>";
        htmlcontent += "<td style='width:50%'>";
        htmlcontent += $"Fecha: {body.data?.date}";
        htmlcontent += "</td>";
        htmlcontent += " <td style='width:50%'>";
        htmlcontent += $"Cantidad de productos vendidos: {body.data?.qt_product_sale}";
        htmlcontent += "</td>";
        htmlcontent += "</tr>";
        htmlcontent += " <tr>";
        htmlcontent += "<td style='width:50%'>";
        htmlcontent += $"Fecha inicio: {body.data?.start_date}";
        htmlcontent += "</td>";
        htmlcontent += " <td style='width:50%'>";
        htmlcontent += $"No. de ventas: {body.data?.no_sales}";
        htmlcontent += "</td>";
        htmlcontent += "</tr>";
        htmlcontent += " <tr>";
        htmlcontent += "<td style='width:50%'>";
        htmlcontent += $"Fecha fin: {body.data?.final_date}";
        htmlcontent += "</td>";
        htmlcontent += " <td style='width:50%'>";
        htmlcontent += $"Total en ventas: ${body.data?.total_sales}";
        htmlcontent += "</td>";
        htmlcontent += "</tr>";
        htmlcontent += "<table>";
        htmlcontent += "</div>";
        htmlcontent += "<div style='margin-top:10px'>";
        htmlcontent += "<table cellspacing='0' cellpadding='0'>";
        htmlcontent += "<thead style='background-color:#092E60'>";
        htmlcontent += "<tr style='background-color:#092E60;width:100%'>";
        htmlcontent += "<th style='color:#000;padding:5px;background-color:#092E60;border:none;width:20%;color:#fff;font-weight:600'>No.</th>";
        htmlcontent += "<th style='color:#000;padding:5px;background-color:#092E60;border:none;width:20%;color:#fff;font-weight:600'>No. Ticket</th>";
        htmlcontent += "<th style='color:#000;padding:5px;background-color:#092E60;border:none;width:20%;color:#fff;font-weight:600'>Sucursal</th>";
        htmlcontent += "<th style='color:#000;padding:5px;background-color:#092E60;border:none;width:20%;color:#fff;font-weight:600'>Fecha</th>";
        htmlcontent += "<th style='color:#000;padding:5px;background-color:#092E60;border:none;width:20%;color:#fff;font-weight:600'>Total</th>";
        htmlcontent += "</tr>";
        htmlcontent += "</thead>";
        htmlcontent += "<tbody style='border:solid 1px #eee'>";
        foreach (SalesI sale in body.sales)
        {
            htmlcontent += "<tr style='border:solid 1px #eee'>";
            htmlcontent += $"<td style='text-align:center;font-weight:500;border:solid 1px #eee;padding:2px'>{sale.no}</td>";
            htmlcontent += $"<td style='text-align:center;font-weight:500;border:solid 1px #eee;padding:2px'>{sale.ticket}</td>";
            htmlcontent += $"<td style='text-align:center;font-weight:500;border:solid 1px #eee;padding:2px'>{sale.branch}</td>";
            htmlcontent += $"<td style='text-align:center;font-weight:500;border:solid 1px #eee;padding:2px'>{String.Format("{0:M/d/yyyy}",sale.date)}</td>";
            htmlcontent += $"<td style='text-align:center;font-weight:500;border:solid 1px #eee;padding:2px'>{sale.total}</td>";
            htmlcontent += "</tr>";
        }
        htmlcontent += "</tbody>";
        htmlcontent += "</table>";
        htmlcontent += "</div>";
        htmlcontent += "</body>";
        htmlcontent += "</html>";

        PdfGenerator.AddPdfPages(document, htmlcontent, PageSize.A4,20);
        byte[]? response = null;
        using (MemoryStream ms = new MemoryStream())
        {
            document.Save(ms);
            response = ms.ToArray();
        }
        string Filename = "Invoice_" + ".pdf";
        return File(response, "application/pdf", Filename);
    }
}

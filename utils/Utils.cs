namespace html_pdf_api;

public class Utils
{
    public string Makeheader(string? title)
    {
        string htmlcontent = "";
        htmlcontent += "<table style='width:100%'>";
        htmlcontent += "<td style='width:80%;font-weight:600;font-size:20px'>";
        htmlcontent += $"El Sotano - {title}";
        htmlcontent += "</td>";
        htmlcontent += "<td style='width:20%'>";
        htmlcontent += "<img style='width:70px;float:right;' src='https://afraco-admin-app-5sl9b.ondigitalocean.app/assets/logo.7b275812.png'>";
        htmlcontent += "</td>";
        htmlcontent += "<tr>";
        htmlcontent += "</tr>";
        htmlcontent += "</table>";
        return htmlcontent;
    }
}
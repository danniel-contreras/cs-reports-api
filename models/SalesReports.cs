namespace html_pdf_api;

public class SalesReportI
{
    public DataI? data { get; set; }
    public string? title { get; set; }
    public List<SalesI>? sales { get; set; }
}

public class DataI
{
    public string? start_date { get; set; }
    public string? final_date { get; set; }
    public double total_sales { get; set; }
    public int qt_product_sale { get; set; }
    public int no_sales { get; set; }
    public string? date { get; set; }
}

public class SalesI
{
    public int no { get; set; }
    public int ticket { get; set; }
    public string? salesman { get; set; }
    public string? branch { get; set; }
    public DateTime? date { get; set; }
    public double total { get; set; }
}
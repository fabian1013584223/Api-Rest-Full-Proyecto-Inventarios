﻿using Entities.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Shared.DataTransferObjects;
using System.Text;

namespace APIRestProyecto;

public class CsvOutputFormatter : TextOutputFormatter
{
    public CsvOutputFormatter()
    {
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
        SupportedEncodings.Add(Encoding.UTF8);
        SupportedEncodings.Add(Encoding.Unicode);
    }
    protected override bool CanWriteType(Type? type)
    {
        if (typeof(StockDTO).IsAssignableFrom(type) ||
            typeof(IEnumerable<StockDTO>).IsAssignableFrom(type))
        {
            return base.CanWriteType(type);
        }
        return false;
    }
    public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
    {
        var response = context.HttpContext.Response;
        var buffer = new StringBuilder();
        if (context.Object is IEnumerable<StockDTO>)
        {
            foreach (var stock in (IEnumerable<StockDTO>)context.Object)
            {
                FormatCsv(buffer, stock);
            }
        }
        else
        {
            FormatCsv(buffer, (StockDTO)context.Object);
        }
        await response.WriteAsync(buffer.ToString());
    }
    private static void FormatCsv(StringBuilder buffer, StockDTO stock)
    {
        buffer.AppendLine($"{stock.StockId},\"{stock.CantidadReal},\"{stock.FechaIngreso}\"");
    }
}

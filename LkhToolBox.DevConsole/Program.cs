using LkhToolBox.DevConsole.PdfSamples;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using System.Reflection.Metadata;

QuestPDF.Settings.License = LicenseType.Community;

var document = DefaultDocument.GenerateDocument();
   
 document.GeneratePdf("D:\\云盘下载\\Hello.PDF");

// use the following invocation
document.ShowInPreviewer();


Console.WriteLine("Over!");
Console.ReadLine();

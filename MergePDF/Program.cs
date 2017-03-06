using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;


namespace MergePDF
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Temp\1-1000";
            string dioImenaimeMergeFile = @"/Cycle_de_lumiere_2_";
            var listFolder =  Directory.GetDirectories(path);
            foreach(var folder in listFolder)
            {
                Console.WriteLine(folder);
                using (PdfDocument targetDoc = new PdfDocument())
                {
                    var listFiles = Directory.GetFiles(folder.ToString(), "*.pdf");

                    foreach (var pdf in listFiles)
                    {
                        //  pdf.FullName
                        //Console.WriteLine(pdf);
                        using (PdfDocument pdfDoc = PdfReader.Open(pdf, PdfDocumentOpenMode.Import))
                        {
                            for (int i = 0; i < pdfDoc.PageCount; i++)
                            {
                                targetDoc.AddPage(pdfDoc.Pages[i]);
                            }
                        }

                    }
                    string serija = folder.ToString().Substring(folder.ToString().Length - 4, 4);
                    string imeMergeFile = folder + dioImenaimeMergeFile + serija + ".pdf";
                    Console.WriteLine($"Ime merge fajla:{imeMergeFile}");

                    targetDoc.Save(imeMergeFile);
                }
            }
            Console.ReadKey();
        }
    }
}

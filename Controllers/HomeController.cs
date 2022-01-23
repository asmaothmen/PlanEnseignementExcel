using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlanEnseignementExcel.Models;
using PlanEnseignementExcel.Models.BLL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PlanEnseignementExcel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<UniteEnseignement> uniteEn = BLL_UniteEnseignement.GetAll();
        private PlanEnseignementContext Context = new PlanEnseignementContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private static Regex ALL_Z_REGEX = new Regex("^[zZ]+$");
        public static string GetNextColumn(string currentColumn)
        { // AZ would become BA
            char lastPosition = currentColumn[currentColumn.Length - 1];
            if (ALL_Z_REGEX.IsMatch(currentColumn))
            {
                string result = String.Empty;
                for (int i = 0; i < currentColumn.Length; i++)
                    result += "A"; return result + "A";
            }
            else if (lastPosition == 'Z') return GetNextColumn(currentColumn.Remove(currentColumn.Length - 1, 1)) + "A";
            else return currentColumn.Remove(currentColumn.Length - 1, 1) + (++lastPosition).ToString();
        }
        const int ColumnBase = 26; const int DigitMax = 7;
        // ceil(log26(Int32.Max))
        const string Digits = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string IndexToColumn(int index)
        {
            if (index <= 0)
                throw new IndexOutOfRangeException("index must be a positive number");
            if (index <= ColumnBase) return Digits[index - 1].ToString();
            var sb = new StringBuilder().Append(' ', DigitMax);
            var current = index; var offset = DigitMax;
            while (current > 0) { sb[--offset] = Digits[--current % ColumnBase]; current /= ColumnBase; }
            return sb.ToString(offset, DigitMax - offset);
        }
        public FileResult ExportToExcel()
        {

            XLWorkbook workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("Plan D'Enseignement");
            var headerRow = ws.Row(7);
            headerRow.Height = 20;
            ws.Cell("A1").Value = "Licence Fondamentale Science Informatique";
            var titlerange = ws.Range("A1:W1");
            titlerange.Merge().Style.Font.SetBold().Font.FontSize = 13;
            ws.Cell("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            //ws.Cell(1, 7).Style.Border.BottomBorder = XLBorderStyleValues.Thick;
            ws.Cell("A2").Value = "Unité d'Enseignement";
            var addressrange = ws.Range("A2:G2");
            addressrange.Merge().Style.Font.SetBold().Font.FontSize = 12;
            ws.Cell("A2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("H2").Value = "Elements constitutif de l'UE";
            var addressrange2 = ws.Range("H2:M2");
            addressrange2.Merge().Style.Font.SetBold().Font.FontSize = 12;
            ws.Cell("H2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("N2").Value = "volume Horaire Semesteriel";
            var addressrange3 = ws.Range("N2:Q2");
            addressrange3.Merge().Style.Font.SetBold().Font.FontSize = 12;
            ws.Cell("N2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("R2").Value = "Credits";
            var addressrange4 = ws.Range("R2:S2");
            addressrange4.Merge().Style.Font.SetBold().Font.FontSize = 12;
            ws.Cell("R2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("T2").Value = "Coefficient";
            var addressrange5 = ws.Range("T2:U2");
            addressrange5.Merge().Style.Font.SetBold().Font.FontSize = 12;
            ws.Cell("T2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("V2").Value = "Regime d'Examen";
            var addressrange6 = ws.Range("V2:W2");
            addressrange6.Merge().Style.Font.SetBold().Font.FontSize = 12;
            ws.Cell("V2").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("B3").Value = "Intitule";
            var reportrange = ws.Range("B3:G3");
            reportrange.Merge().Style.Font.SetBold().Font.FontSize = 10;
            ws.Cell("B3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            ws.Cell("A3").Value = "Code";
            var panRange = ws.Range("A3:A3");
            panRange.Merge().Style.Font.SetBold().Font.FontSize = 10;
            ws.Cell("A3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            ws.Cell("H3").Value = "Code";
            var panRangecode = ws.Range("H3:H3");
            panRangecode.Merge().Style.Font.SetBold().Font.FontSize = 10;
            ws.Cell("H3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            ws.Cell("I3").Value = "Intitule";
            var reportrangeIntitule = ws.Range("I3:M3");
            reportrangeIntitule.Merge().Style.Font.SetBold().Font.FontSize = 10;
            ws.Cell("I3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            ws.Cell("N3").Value = "   Cours   ";
            ws.Cell("N3").Style.Font.SetBold().Font.FontSize = 10;
            ws.Cell("N3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            ws.Cell("O3").Value = "   TD   ";
            ws.Cell("O3").Style.Font.SetBold().Font.FontSize = 10;
            ws.Cell("O3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            ws.Cell("P3").Value = "   TP   ";
            ws.Cell("P3").Style.Font.SetBold().Font.FontSize = 10;
            ws.Cell("P3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell("Q3").Value = "   Total   ";
            ws.Cell("Q3").Style.Font.SetBold().Font.FontSize = 10;
            ws.Cell("Q3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            ws.Cell("R3").Value = "   ECUE   ";
            ws.Cell("R3").Style.Font.SetBold().Font.FontSize = 10;
            ws.Cell("R3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            ws.Cell("S3").Value = "   UE   ";
            ws.Cell("S3").Style.Font.SetBold().Font.FontSize = 10;
            ws.Cell("S3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            ws.Cell("T3").Value = "   ECUE   ";
            ws.Cell("T3").Style.Font.SetBold().Font.FontSize = 10;
            ws.Cell("T3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            ws.Cell("U3").Value = "   UE   ";
            ws.Cell("U3").Style.Font.SetBold().Font.FontSize = 10;
            ws.Cell("U3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            ws.Cell("V3").Value = "   CC   ";
            ws.Cell("V3").Style.Font.SetBold().Font.FontSize = 10;
            ws.Cell("V3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            ws.Cell("W3").Value = "   Mixte   ";
            ws.Cell("W3").Style.Font.SetBold().Font.FontSize = 10;
            ws.Cell("W3").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Columns().Width = 10;
            // data 
            int countcolumn = 4;
            var distinctNature  = uniteEn.Select(o=>o.Nature).Distinct();
            foreach (string item in distinctNature)
            {
                ws.Cell("A" + countcolumn).Value = item;
                var nature = ws.Range("A" + countcolumn + ":W" + countcolumn);
                nature.Merge().Style.Font.FontSize = 10;
                ws.Cell("A" + countcolumn).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                countcolumn += 1;
                foreach(UniteEnseignement unite in uniteEn)
                {
                    if (unite.Nature == item)
                    {
                        ws.Cell("A" + countcolumn).Value = unite.Code;
                        ws.Cell("B" + countcolumn).Value = unite.IntituleFr;
                        var nom = ws.Range("B" + countcolumn + ":G" + countcolumn);
                        nom.Merge().Style.Font.FontSize = 10;

                    }
                }
             

            }
            //Setting borders to each used cell in excel  
            ws.CellsUsed().Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.CellsUsed().Style.Border.BottomBorderColor = XLColor.Black;
            ws.CellsUsed().Style.Border.TopBorder = XLBorderStyleValues.Thin;
            ws.CellsUsed().Style.Border.TopBorderColor = XLColor.Black;
            ws.CellsUsed().Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            ws.CellsUsed().Style.Border.LeftBorderColor = XLColor.Black;
            ws.CellsUsed().Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.CellsUsed().Style.Border.RightBorderColor =XLColor.Black;

            using (MemoryStream stream = new MemoryStream()) //using System.IO;  
            {
                workbook.SaveAs(stream);
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ExcelFile.xlsx");
            }

        }



    }
}

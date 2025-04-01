using ClosedXML.Excel;
using aztro_cchardos_back_group2.Application.DTOs.Responses;

namespace aztro_cchardos_back_group2.Application.Services
{
    public class ExportService
    {
        public byte[] ExportToExcel(ReportResponse report)
        {
            using var workbook = new XLWorkbook();
            
            // Answers worksheet
            var answersSheet = workbook.Worksheets.Add("Answer Statistics");
            answersSheet.Cell(1, 1).Value = "Category";
            answersSheet.Cell(1, 2).Value = "Question";
            answersSheet.Cell(1, 3).Value = "Option";
            answersSheet.Cell(1, 4).Value = "Count";
            answersSheet.Cell(1, 5).Value = "Percentage";

            var row = 2;
            foreach (var stat in report.AnswerStats)
            {
                foreach (var option in stat.OptionCounts)
                {
                    answersSheet.Cell(row, 1).Value = stat.Category;
                    answersSheet.Cell(row, 2).Value = stat.QuestionText;
                    answersSheet.Cell(row, 3).Value = option.OptionDescription;
                    answersSheet.Cell(row, 4).Value = option.Count;
                    answersSheet.Cell(row, 5).Value = option.Percentage;
                    row++;
                }
            }

            // Destinations worksheet
            var destinationsSheet = workbook.Worksheets.Add("Destination Statistics");
            destinationsSheet.Cell(1, 1).Value = "First City";
            destinationsSheet.Cell(1, 2).Value = "Second City";
            destinationsSheet.Cell(1, 3).Value = "Times Shown";
            destinationsSheet.Cell(1, 4).Value = "Last Shown Date";

            row = 2;
            foreach (var stat in report.DestinationStats)
            {
                destinationsSheet.Cell(row, 1).Value = stat.FirstCityName;
                destinationsSheet.Cell(row, 2).Value = stat.SecondCityName;
                destinationsSheet.Cell(row, 3).Value = stat.TimesShown;
                destinationsSheet.Cell(row, 4).Value = stat.LastShownDate;
                row++;
            }

            // Users worksheet
            var usersSheet = workbook.Worksheets.Add("User Statistics");
            usersSheet.Cell(1, 1).Value = "Email";
            usersSheet.Cell(1, 2).Value = "Questions Answered";
            usersSheet.Cell(1, 3).Value = "Last Activity";
            usersSheet.Cell(1, 4).Value = "Preferred Destinations";

            row = 2;
            foreach (var stat in report.UserStats)
            {
                usersSheet.Cell(row, 1).Value = stat.UserEmail;
                usersSheet.Cell(row, 2).Value = stat.QuestionsAnswered;
                usersSheet.Cell(row, 3).Value = stat.LastActivity;
                usersSheet.Cell(row, 4).Value = string.Join(", ", stat.PreferredDestinations);
                row++;
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }
    }
}
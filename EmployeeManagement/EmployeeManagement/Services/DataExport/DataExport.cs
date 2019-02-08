using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Pocos;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace EmployeeManagement.Services.DataExport
{
    public class DataExport : IDataExport
    {
        public void ExportSkillsToExcel(Skill[] skills)
        {
            using (var fs = new FileStream(@"wwwroot/Skills.xlsx", FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet sheet1 = workbook.CreateSheet("Skills");

                IRow row = sheet1.CreateRow(0);
                string[] skillPropertyNames = typeof(Skill).GetProperties().Select(p => p.Name).ToArray();
                row.CreateCell(0).SetCellValue(skillPropertyNames[1]);
                row.CreateCell(1).SetCellValue(skillPropertyNames[2]);
                row.CreateCell(2).SetCellValue(skillPropertyNames[3]);

                for (int rowIndex = 0; rowIndex < skills.GetLength(0); rowIndex++)
                {
                    row = sheet1.CreateRow(rowIndex + 1);
                    row.CreateCell(0).SetCellValue(skills[rowIndex].Name);
                    row.CreateCell(1).SetCellValue(skills[rowIndex].Description);
                    row.CreateCell(2).SetCellValue(skills[rowIndex].CreationDate.ToShortDateString());
                }

                workbook.Write(fs);
            }

        }

    }
}

using C_sharp_egzaminas.Entity;

namespace C_sharp_egzaminas.Service.Generate
{

    public static class HTMLGenerator
    {
        public static string GenerateHTML(List<ReportItem> reportItems)
        {
            string result = "<style type=\"text/css\">\r\n.tg  {border-collapse:collapse;border-spacing:0;}\r\n.tg td{border-color:black;border-style:solid;border-width:1px;font-family:Arial, sans-serif;font-size:14px;\r\n  overflow:hidden;padding:10px 5px;word-break:normal;}\r\n.tg th{border-color:black;border-style:solid;border-width:1px;font-family:Arial, sans-serif;font-size:14px;\r\n  font-weight:normal;overflow:hidden;padding:10px 5px;word-break:normal;}\r\n.tg .tg-du61{background-color:#ffce93;color:#9b9b9b;text-align:left;vertical-align:top}\r\n.tg .tg-2gvg{background-color:#ffce93;border-color:inherit;color:#9b9b9b;text-align:left;vertical-align:top}\r\n.tg .tg-llyw{background-color:#c0c0c0;border-color:inherit;text-align:left;vertical-align:top}\r\n.tg .tg-y6fn{background-color:#c0c0c0;text-align:left;vertical-align:top}\r\n.tg .tg-ncd7{background-color:#ffffc7;border-color:inherit;text-align:left;vertical-align:top}\r\n.tg .tg-m9r4{background-color:#ffffc7;text-align:left;vertical-align:top}\r\n</style>\r\n<table class=\"tg\">\r\n<thead>\r\n  <tr>\r\n    <th class=\"tg-llyw\">Row</th>\r\n    <th class=\"tg-llyw\">Student</th>\r\n    <th class=\"tg-llyw\">Lesson</th>\r\n    <th class=\"tg-llyw\">Grade</th>\r\n    <th class=\"tg-llyw\">Teacher</th>\r\n    <th class=\"tg-llyw\">Message</th>\r\n    <th class=\"tg-y6fn\">Date</th>\r\n  </tr>\r\n</thead>\r\n<tbody>";
            int row = 1;
            foreach (ReportItem item in reportItems)
            {
                if (!item.IsActive)
                {
                    continue;
                }
               
                result += item.Type == "titleItem"
                    ? $"  <tr>\r\n    <td class=\"tg-2gvg\">{row}</td>\r\n    <td class=\"tg-2gvg\">{item.StudentName}</td>\r\n    <td class=\"tg-2gvg\">{item.Lesson}</td>\r\n    <td class=\"tg-2gvg\">{item.GradeAverage}</td>\r\n    <td class=\"tg-2gvg\">-</td>\r\n    <td class=\"tg-2gvg\">-</td>\r\n    <td class=\"tg-du61\">-</td>\r\n  </tr>"
                    : $"  <tr>\r\n    <td class=\"tg-ncd7\">{row}</td>\r\n    <td class=\"tg-ncd7\">{item.StudentName}</td>\r\n    <td class=\"tg-ncd7\">{item.Lesson}</td>\r\n    <td class=\"tg-ncd7\">{item.Grade}</td>\r\n    <td class=\"tg-ncd7\">{item.TeacherName}</td>\r\n    <td class=\"tg-ncd7\">{item.Message}</td>\r\n    <td class=\"tg-m9r4\">{item.Date}</td>\r\n  </tr>";
                row++;
            }

            return result += "</tbody>\r\n</table>";

        }

    }
}
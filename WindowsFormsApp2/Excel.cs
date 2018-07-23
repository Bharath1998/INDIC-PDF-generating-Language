using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApp2
{
    class Excel
    {
        _Application excel = new _Excel.Application();
        string path = "";
        Workbook wb;
        Worksheet ws;
        public Excel(string path, int sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = excel.Worksheets[sheet];

        }
        public string ReadCell(int i, int j)
        {
            //i++;
            //j++;
            if (ws.Cells[i, j].Value2 != null)
            {
                double double1;
               // double ret = ws.Cells[i, j].Value2;
                if(ws.Cells[i, j].Value2 is string)
                {
                    return ws.Cells[i, j].Value2;
                }
                else
                {
                    double ret1 = ws.Cells[i, j].Value2;
                    string yet = ret1.ToString();
                    return yet;
                }

         
              
               // return ws.Cells[i, j].Value2;
            }
            else
            {
                return "";
            }
        }
        public void close()
        {
            wb.Close();
        }
    }
}

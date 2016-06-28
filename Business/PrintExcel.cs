using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.IO;
using System.Data;

namespace BHair.Business
{
    public class PrintExcel
    {
        public bool OutPutXLS(DataTable AppDT,DataTable DetailDT,string ExcelPath)
        {
            try
            {
                CreateXLS(AppDT, DetailDT,ExcelPath);
                //string sourcePath = System.IO.Directory.GetCurrentDirectory() + @"\tempPDF\tempExcel.xls";
                //string targetPath = System.IO.Directory.GetCurrentDirectory() + @"\tempPDF\tempPDF.pdf";
                //XLSConvertToPDF(sourcePath, targetPath);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

       

        private bool CreateXLS(DataTable AppDT, DataTable DetailDT,string ExcelPath)
        {
            string XLSName;
            XLSName = System.IO.Directory.GetCurrentDirectory() + @"\templet\转货申请表模板.xls";
            Excel.Application app = new Excel.Application();
            app.DisplayAlerts = false;
            Excel.Workbooks wbks = app.Workbooks;
            Excel._Workbook _wbk = wbks.Add(XLSName);
            Excel.Sheets shs = _wbk.Sheets;
            Excel._Worksheet _wsh = (Excel._Worksheet)shs.get_Item(1);


            //写入
            _wsh.Cells[2, 13] = AppDT.Rows[0]["CtrlID"].ToString();
            _wsh.Cells[4, 2] = AppDT.Rows[0]["ApplicantsName"].ToString();
            _wsh.Cells[5, 2] = AppDT.Rows[0]["ApplicantsPos"].ToString();
            _wsh.Cells[7, 2] = AppDT.Rows[0]["ApplicantsDate"].ToString();
            _wsh.Cells[9, 2] = AppDT.Rows[0]["DeliverStore"].ToString();
            _wsh.Cells[10, 2] = AppDT.Rows[0]["ReceiptStore"].ToString();
            _wsh.Cells[12, 2] = AppDT.Rows[0]["ApprovalName"].ToString();
            _wsh.Cells[13, 2] = AppDT.Rows[0]["ApprovalPos"].ToString();
            _wsh.Cells[18, 1] = AppDT.Rows[0]["DeliverCheck"].ToString();
            _wsh.Cells[19, 2] = AppDT.Rows[0]["DeliverCheckerName"].ToString();
            _wsh.Cells[24, 1] = AppDT.Rows[0]["ReceiptCheck"].ToString();
            _wsh.Cells[25, 2] = AppDT.Rows[0]["ReceiptCheckerName"].ToString();
            _wsh.Cells[25, 13] = AppDT.Rows[0]["TotalPrice"].ToString();

            int j = 0;
            int i = 0;
            foreach(DataRow dr in DetailDT.Rows)
            {
                if(i<21)
                {
                    _wsh.Cells[5 + i, 6] = dr["Department"].ToString();
                    _wsh.Cells[5 + i, 7] = dr["App_Level"].ToString();
                    _wsh.Cells[5 + i, 8] = dr["ItemID"].ToString();
                    _wsh.Cells[5 + i, 9] = dr["ItemID2"].ToString();
                    _wsh.Cells[5 + i, 10] = dr["Detail"].ToString();

                    _wsh.Cells[5 + i, 11] = dr["Price"].ToString();
                    _wsh.Cells[5 + i, 12] = dr["App_Count"].ToString();
                    _wsh.Cells[5 + i, 13] = double.Parse(dr["Price"].ToString()) * double.Parse(dr["App_Count"].ToString());
                    i++;
                }
              
            }


            //保存
            //string filePath = System.IO.Directory.GetCurrentDirectory() + @"\tempPDF\tempExcel.xls";
            string filePath = ExcelPath;
            app.AlertBeforeOverwriting = false;
            _wbk.SaveAs(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //退出和释放
            _wbk.Close(null, null, null);
            wbks.Close();
            app.Quit();
            //释放掉多余的excel进程
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            app = null;
            return true;
        }

       


        /// <summary>
        /// 把Excel文件转换成PDF格式文件
        /// </summary>
        /// <param name="sourcePath">源文件路径</param>
        /// <param name="targetPath">目标文件路径</param>
        /// <returns>true=转换成功</returns>
        private bool XLSConvertToPDF(string sourcePath, string targetPath)
        {
            bool result = false;
            Excel.XlFixedFormatType targetType = Excel.XlFixedFormatType.xlTypePDF;
            object missing = Type.Missing;
            Excel.ApplicationClass application = null;
            Excel.Workbook workBook = null;
            try
            {
                application = new Excel.ApplicationClass();
                object target = targetPath;
                object type = targetType;
                workBook = application.Workbooks.Open(sourcePath, missing, missing, missing, missing, missing,
                        missing, missing, missing, missing, missing, missing, missing, missing, missing);

                workBook.ExportAsFixedFormat(targetType, target, Excel.XlFixedFormatQuality.xlQualityStandard, true, false, missing, missing, missing, missing);
                result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                if (workBook != null)
                {
                    workBook.Close(true, missing, missing);
                    workBook = null;
                }
                if (application != null)
                {
                    application.Quit();
                    application = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            if(workBook!=null)workBook.Close();
            if (application != null) application.Quit();
            return result;
        }



        public DataTable ExcelToDataTable_Items(string filePath)
        {
            DataTable Result = new DataTable();
            Result.Columns.Add(new DataColumn("ID", typeof(Int32)));
            Result.Columns.Add(new DataColumn("ItemID", typeof(string)));
            Result.Columns.Add(new DataColumn("ItemID2", typeof(string)));
            Result.Columns.Add(new DataColumn("Price", typeof(double)));
            Result.Columns.Add(new DataColumn("ItemName", typeof(string)));
            Result.Columns.Add(new DataColumn("Detail", typeof(string)));
            Result.Columns.Add(new DataColumn("IsDelete", typeof(double)));


            Excel.Application app = new Excel.Application();
            Excel.Sheets sheets;
            object oMissiong = System.Reflection.Missing.Value;
            Excel.Workbook workbook = null;

            try
            {
                if (app == null) return null;
                workbook = app.Workbooks.Open(filePath, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong,
                    oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
                sheets = workbook.Worksheets;

                //将数据读入到DataTable中
                Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);//读取第一张表  
                if (worksheet == null) return null;

                int iRowCount = worksheet.UsedRange.Rows.Count;
                int iColCount = worksheet.UsedRange.Columns.Count;
                
                //生成行数据
                Excel.Range range;
                for (int iRow = 2; iRow <= iRowCount; iRow++)
                {
                    int validate = 0;
                    DataRow dr = Result.NewRow();

                    dr["ItemID"] = ((Excel.Range)worksheet.Cells[iRow, 1]).Text;
                    dr["ItemID2"] = ((Excel.Range)worksheet.Cells[iRow, 2]).Text;
                    double price=0;
                    if (!double.TryParse(((Excel.Range)worksheet.Cells[iRow, 3]).Text.ToString(), out price))
                        validate++;
                    dr["Price"] = price;
                    dr["Detail"] = ((Excel.Range)worksheet.Cells[iRow, 4]).Text;
                    dr["IsDelete"] = 0;

                    if (dr["ItemID"].ToString() == "") validate++;
                    //if (dr["ItemID2"].ToString() == "") validate++;
                    //if (dr["Detail"].ToString() == "") validate++;

                    if(validate==0)Result.Rows.Add(dr);
                }
                return Result;
            }
            catch { return null; }
            finally
            {
                workbook.Close(false, oMissiong, oMissiong);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                workbook = null;
                app.Workbooks.Close();
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                app = null;
            }
        }


        public DataTable ExcelToDataTable_Member(string filePath,DataTable Result,string sha1pwd)
        {
            //DataTable Result = new DataTable();


            Excel.Application app = new Excel.Application();
            Excel.Sheets sheets;
            object oMissiong = System.Reflection.Missing.Value;
            Excel.Workbook workbook = null;

            try
            {
                if (app == null) return null;
                workbook = app.Workbooks.Open(filePath, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong,
                    oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
                sheets = workbook.Worksheets;

                //将数据读入到DataTable中
                Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);//读取第一张表  
                if (worksheet == null) return null;

                int iRowCount = worksheet.UsedRange.Rows.Count;
                int iColCount = worksheet.UsedRange.Columns.Count;

                //生成行数据
                Excel.Range range;
                for (int iRow = 2; iRow <= iRowCount; iRow++)
                {
                    int validate = 0;
                    DataRow dr = Result.NewRow();

                    dr["UID"] = ((Excel.Range)worksheet.Cells[iRow, 1]).Text;
                    dr["UserName"] = ((Excel.Range)worksheet.Cells[iRow, 2]).Text;
                    dr["Email"] = ((Excel.Range)worksheet.Cells[iRow, 3]).Text;
                    dr["Position"] = ((Excel.Range)worksheet.Cells[iRow, 4]).Text;
                    dr["Department"] = ((Excel.Range)worksheet.Cells[iRow, 5]).Text;
                    dr["Store"] = ((Excel.Range)worksheet.Cells[iRow, 6]).Text;
                    double character = 0;
                    if (!double.TryParse(((Excel.Range)worksheet.Cells[iRow, 7]).Text.ToString(), out character))
                        validate++;
                    dr["Character"] = character;
                    dr["IsDelete"] = 0;
                    dr["IsAble"] = 1;
                    dr["IsAdmin"] = 0;
                    dr["UserPwd"] = sha1pwd;

                    if (dr["UID"].ToString() == "") validate++;
                    if (dr["UserName"].ToString() == "") validate++;
                    //if (dr["Email"].ToString() == "") validate++;
                    //if (dr["Position"].ToString() == "") validate++;
                    //if (dr["Department"].ToString() == "") validate++;
                    if (dr["Character"].ToString() != "1" && dr["Character"].ToString() != "2" && dr["Character"].ToString() != "3" && dr["Character"].ToString() != "4") validate++;
                    if (dr["Character"].ToString()=="3"&&dr["Store"].ToString() == "") validate++;

                    if (validate == 0) Result.Rows.Add(dr);
                }
                return Result;
            }
            catch { return null; }
            finally
            {
                workbook.Close(false, oMissiong, oMissiong);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                workbook = null;
                app.Workbooks.Close();
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                app = null;
            }
        }
    }
}

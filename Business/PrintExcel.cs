using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;
using System.IO;
using System.Data;
using System.Windows.Forms;
using BHair.Business.BaseData;
using BHair.Business.Table;

namespace BHair.Business
{
    public class PrintExcel
    {
        public bool OutPutXLS(DataTable AppDT, DataTable DetailDT, string ExcelPath)
        {
            try
            {
                CreateXLS(AppDT, DetailDT, ExcelPath);
                //string sourcePath = System.IO.Directory.GetCurrentDirectory() + @"\tempPDF\tempExcel.xls";
                //string targetPath = System.IO.Directory.GetCurrentDirectory() + @"\tempPDF\tempPDF.pdf";
                //XLSConvertToPDF(sourcePath, targetPath);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        private bool CreateXLS(DataTable AppDT, DataTable DetailDT, string ExcelPath)
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
            _wsh.Cells[12, 2] = AppDT.Rows[0]["ApprovalName2"].ToString();
            _wsh.Cells[13, 2] = AppDT.Rows[0]["ApprovalPos2"].ToString();
            _wsh.Cells[18, 1] = AppDT.Rows[0]["DeliverCheck"].ToString();
            _wsh.Cells[19, 2] = AppDT.Rows[0]["DeliverCheckerName"].ToString();
            _wsh.Cells[24, 1] = AppDT.Rows[0]["ReceiptCheck"].ToString();
            _wsh.Cells[25, 2] = AppDT.Rows[0]["ReceiptCheckerName"].ToString();
            _wsh.Cells[25, 13] = AppDT.Rows[0]["TotalPrice"].ToString();

            int j = 0;
            int i = 0;
            foreach (DataRow dr in DetailDT.Rows)
            {
                if (i < 21)
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

            if (workBook != null) workBook.Close();
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
            Result.Columns.Add(new DataColumn("Department", typeof(string)));
            Result.Columns.Add(new DataColumn("Class", typeof(string)));
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
                    double price = 0;
                    if (!double.TryParse(((Excel.Range)worksheet.Cells[iRow, 3]).Text.ToString(), out price))
                        validate++;
                    dr["Price"] = price;
                    dr["Detail"] = ((Excel.Range)worksheet.Cells[iRow, 4]).Text;
                    dr["IsDelete"] = 0;
                    dr["Department"] = ((Excel.Range)worksheet.Cells[iRow, 5]).Text;
                    dr["Class"] = ((Excel.Range)worksheet.Cells[iRow, 6]).Text;

                    if (dr["ItemID"].ToString() == "") validate++;
                    //if (dr["ItemID2"].ToString() == "") validate++;
                    //if (dr["Detail"].ToString() == "") validate++;

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


        public DataTable ExcelToDataTable_Member(string filePath, DataTable Result, string sha1pwd)
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
                    if (dr["Character"].ToString() == "3" && dr["Store"].ToString() == "") validate++;

                    if (validate == 0) Result.Rows.Add(dr);
                }
                return Result;
            }
            catch (Exception ex) { return null; }
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

        ///
        /// 將 DataTable 資料轉換至 Excel
        /// 
        /// thisTable -- 欲轉換之DataTable
        /// FileName -- 賦予檔案名稱
        /// sheetName -- 寫入之sheet名稱

        public void WriteToExcel(DataTable thisTable, string FileName, string sheetName)
        {
            string strFilePath = FileName;
            string XLSName = System.IO.Directory.GetCurrentDirectory() + @"\templet\报告模板.xls";
            Excel.Application app = new Excel.Application();
            app.DisplayAlerts = false;
            Excel.Workbooks wbks = app.Workbooks;
            Excel._Workbook _wbk = wbks.Add(XLSName);
            Excel.Sheets shs = _wbk.Sheets;
            Excel._Worksheet _wsh = (Excel._Worksheet)shs.get_Item(1);
            try
            {
                int sheetRowsCount = _wsh.UsedRange.Rows.Count;
                int count = thisTable.Columns.Count;

                //设置列名
                //foreach (DataColumn myNewColumn in thisTable.Columns)
                //{
                //    _wsh.Cells[0, count] = myNewColumn.ColumnName;
                //    count = count + 1;
                //}er
                for (int i = 0; i < count - 1; i++)
                {
                    _wsh.Cells[1, i + 1] = thisTable.Columns[i].ColumnName;
                }

                //加入內容
                for (int i = 1; i <= thisTable.Rows.Count; i++)
                {
                    for (int j = 1; j <= thisTable.Columns.Count - 1; j++)
                    {
                        if ((j == 7 && thisTable.Rows[i - 1]["ItemHighlight"].ToString() == "1") || (j == 8 && thisTable.Rows[i - 1]["ItemHighlight"].ToString() == "2"))
                        {
                            Excel.Range range = _wsh.get_Range(_wsh.Cells[i + sheetRowsCount, j], _wsh.Cells[i + sheetRowsCount, j]);
                            range.Interior.ColorIndex = 3;
                        }
                        _wsh.Cells[i + sheetRowsCount, j] = thisTable.Rows[i - 1][j - 1];
                    }
                }
                _wsh.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                _wsh.Cells.Columns.AutoFit();
                _wsh.Cells.Rows.AutoFit();
                //若為EXCEL2000, 將最後一個參數拿掉即可             
                _wbk.SaveAs(strFilePath, Excel.XlFileFormat.xlWorkbookNormal,
                    null, null, false, false, Excel.XlSaveAsAccessMode.xlShared,
                    false, false, null, null, null);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                //關閉文件
                _wbk.Close(false, Type.Missing, Type.Missing);
                app.Workbooks.Close();
                app.Quit();

                //釋放資源
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_wsh);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_wbk);
                _wsh = null;
                _wbk = null;
                app = null;
            }
        }

        public void WriteToExcelReport(DataTable thisTable, string FileName, string sheetName)
        {
            string strFilePath = FileName;
            string XLSName = System.IO.Directory.GetCurrentDirectory() + @"\templet\报告模板.xls";
            Excel.Application app = new Excel.Application();
            app.DisplayAlerts = false;
            Excel.Workbooks wbks = app.Workbooks;
            Excel._Workbook _wbk = wbks.Add(XLSName);
            Excel.Sheets shs = _wbk.Sheets;
            Excel._Worksheet _wsh = (Excel._Worksheet)shs.get_Item(1);
            try
            {
                int sheetRowsCount = _wsh.UsedRange.Rows.Count;
                int count = thisTable.Columns.Count;

                //设置列名
                //foreach (DataColumn myNewColumn in thisTable.Columns)
                //{
                //    _wsh.Cells[0, count] = myNewColumn.ColumnName;
                //    count = count + 1;
                //}er
                for (int i = 0; i < count; i++)
                {
                    _wsh.Cells[1, i + 1] = thisTable.Columns[i].ColumnName;
                }

                //加入內容
                for (int i = 1; i <= thisTable.Rows.Count; i++)
                {
                    for (int j = 1; j <= thisTable.Columns.Count; j++)
                    {
                        //if ((j == 7 && thisTable.Rows[i - 1]["ItemHighlight"].ToString() == "1") || (j == 8 && thisTable.Rows[i - 1]["ItemHighlight"].ToString() == "2"))
                        //{
                        //    Excel.Range range = _wsh.get_Range(_wsh.Cells[i + sheetRowsCount, j], _wsh.Cells[i + sheetRowsCount, j]);
                        //    range.Interior.ColorIndex = 3;
                        //}
                        _wsh.Cells[i + sheetRowsCount, j] = thisTable.Rows[i - 1][j - 1];
                    }
                }
                _wsh.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                _wsh.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperB4;
                _wsh.Cells.Columns.AutoFit();
                _wsh.Cells.Rows.AutoFit();
                //若為EXCEL2000, 將最後一個參數拿掉即可             
                _wbk.SaveAs(strFilePath, Excel.XlFileFormat.xlWorkbookNormal,
                    null, null, false, false, Excel.XlSaveAsAccessMode.xlShared,
                    false, false, null, null, null);

            }
            catch (Exception ex)
            {
                if(ex.HResult== -2146827284)
                {
                    MessageBox.Show("Print Spooler服务未启动", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }               
            }
            finally
            {
                //關閉文件
                _wbk.Close(false, Type.Missing, Type.Missing);
                app.Workbooks.Close();
                app.Quit();

                //釋放資源
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_wsh);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_wbk);
                _wsh = null;
                _wbk = null;
                app = null;
            }
        }

        public DataTable exporeDataToTable(DataGridView dataGridView)
        {
            //将datagridview中的数据导入到表中
            DataTable tempTable = new DataTable("tempTable");
            //定义一个模板表，专门用来获取列名
            DataTable modelTable = new DataTable("ModelTable");
            //创建列
            for (int column = 0; column < dataGridView.Columns.Count; column++)
            {
                //可见的列才显示出来
                if (dataGridView.Columns[column].Visible == true)
                {
                    DataColumn tempColumn = new DataColumn(dataGridView.Columns[column].HeaderText, typeof(string));
                    tempTable.Columns.Add(tempColumn);
                    DataColumn modelColumn = new DataColumn(dataGridView.Columns[column].Name, typeof(string));
                    modelTable.Columns.Add(modelColumn);
                }
            }
            //添加datagridview中行的数据到表
            for (int row = 0; row < dataGridView.Rows.Count; row++)
            {
                if (dataGridView.Rows[row].Visible == false)
                {
                    continue;
                }
                DataRow tempRow = tempTable.NewRow();
                for (int i = 0; i < tempTable.Columns.Count; i++)
                {
                    tempRow[i] = dataGridView.Rows[row].Cells[modelTable.Columns[i].ColumnName].Value;
                }
                tempTable.Rows.Add(tempRow);
            }
            return tempTable;
        }

        public void OutputAsExcelFile(DataGridView dataGridView)
        {
            //将datagridView中的数据导出到一张表中
            DataTable tempTable = this.exporeDataToTable(dataGridView);
            //导出信息到Excel表
            Microsoft.Office.Interop.Excel.ApplicationClass myExcel;
            Microsoft.Office.Interop.Excel.Workbooks myWorkBooks;
            Microsoft.Office.Interop.Excel.Workbook myWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet myWorkSheet;
            char myColumns;
            Microsoft.Office.Interop.Excel.Range myRange;
            //object[,] myData = new object[500, 35];
            object[,] myData = new object[tempTable.Rows.Count + 1, tempTable.Columns.Count + 1];
            int i, j;//j代表行,i代表列
            myExcel = new Microsoft.Office.Interop.Excel.ApplicationClass();
            //显示EXCEL
            //myExcel.Visible = true;
            if (myExcel == null)
            {
                MessageBox.Show("本地Excel程序无法启动!请检查您的Microsoft Office正确安装并能正常使用", "提示");
                return;
            }
            myWorkBooks = myExcel.Workbooks;
            myWorkBook = myWorkBooks.Add(System.Reflection.Missing.Value);
            myWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)myWorkBook.Worksheets[1];
            myColumns = (char)(tempTable.Columns.Count + 64);//设置列
            myRange = myWorkSheet.get_Range("A4", myColumns.ToString() + "5");//设置列宽
            int count = 0;            
            //设置列名
            foreach (DataColumn myNewColumn in tempTable.Columns)
            {
                myData[0, count] = myNewColumn.ColumnName;
                count = count + 1;
            }
            //输出datagridview中的数据记录并放在一个二维数组中
            j = 1;
            foreach (DataRow myRow in tempTable.Rows)//循环行
            {
                for (i = 0; i < tempTable.Columns.Count; i++)//循环列
                {
                    myData[j, i] = myRow[i].ToString();
                }
                j++;
            }
            //将二维数组中的数据写到Excel中
            myRange = myRange.get_Resize(tempTable.Rows.Count + 1, tempTable.Columns.Count);//创建列和行
            myRange.Value2 = myData;
            myRange.EntireColumn.AutoFit();
        }
        public DataTable[] ExcelToDataTable_Application(string filePath, DataTable[] Result)
        {
            Items items = new Items();
            items.ItemsDT = items.SelectAllItem();
            Store store = new Store();
            store.StoreDT = store.SelectAllStoreInfo();
            Users users = new Users();
            users.UsersDT = users.SelectAllUsers("");
            ApplicationInfo applicationInfo = new ApplicationInfo();
            DataTable applicationInfoDT = applicationInfo.SelectAllApplicationInfo("");

            Excel.Application app = new Excel.Application();
            Excel.Sheets sheets;
            object oMissiong = System.Reflection.Missing.Value;
            Excel.Workbook workbook = null;

            int intError = 0;
            DataRow drError = Result[2].NewRow();

            try
            {
                if (app == null) return null;
                workbook = app.Workbooks.Open(filePath, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong,
                    oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
                sheets = workbook.Worksheets;

                //将数据读入到DataTable中
                Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);//读取第一张表  
                DataTable dtWorkSheet = GenClass.GetDataTableFromWorksheet(true, true, worksheet);
                if (worksheet == null) return null;

                int iRowCount = worksheet.UsedRange.Rows.Count;
                int iColCount = worksheet.UsedRange.Columns.Count;

                string strLastFailCID = "";

                //生成申请单行数据
                Excel.Range range;

                for (int iRow = 2; iRow <= iRowCount; iRow++)
                {
                    int validate = 0;
                    DataRow dr = Result[0].NewRow();
                    dr["CtrlID"] = ((Excel.Range)worksheet.Cells[iRow, 2]).Text;
                    if (dtWorkSheet.Select(string.Format("column1='{0}'", dr["CtrlID"])).Length <= 20)
                    {
                        if (Result[0].Select(string.Format("CtrlID='{0}'", dr["CtrlID"])).Length != 0)//重复控制号
                        {
                            try
                            {
                                dr = Result[0].Select(string.Format("CtrlID='{0}'", dr["CtrlID"])).First();
                                double price = 0;
                                DataRow[] itemDr = items.ItemsDT.Select(string.Format("ItemID='{0}' or ItemID2='{0}'", ((Excel.Range)worksheet.Cells[iRow, 10]).Text.ToString()));
                                if (itemDr.Length != 0)
                                { double.TryParse(itemDr[0]["Price"].ToString(), out price); }
                                int count = 0;
                                if (!int.TryParse(((Excel.Range)worksheet.Cells[iRow, 11]).Text.ToString(), out count))
                                    dr["TotalCount"] = double.Parse(dr["TotalCount"].ToString()) + count;
                                dr["TotalPrice"] = double.Parse(dr["TotalPrice"].ToString()) + price * count;
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        else
                        {
                            dr["Applicants"] = ((Excel.Range)worksheet.Cells[iRow, 3]).Text;
                            if (users.UsersDT.Select(string.Format("UID='{0}'", dr["Applicants"].ToString())).Length == 0)
                            {
                                validate++;
                                intError++;
                                drError = Result[2].NewRow();
                                drError["ID"] = intError;
                                drError["eCtrlID"] = dr["CtrlID"].ToString();
                                drError["eItemID"] = "-";
                                drError["ErrorString"] = ((Excel.Range)worksheet.Cells[iRow, 3]).Text + "::用户不存在!";
                                Result[2].Rows.Add(drError);
                            }
                            dr["ApplicantsName"] = ((Excel.Range)worksheet.Cells[iRow, 4]).Text;
                            dr["ApplicantsPos"] = ((Excel.Range)worksheet.Cells[iRow, 5]).Text;
                            DateTime applicationsDate = DateTime.Now;
                            if (!DateTime.TryParse(((Excel.Range)worksheet.Cells[iRow, 6]).Text.ToString(), out applicationsDate) && ((Excel.Range)worksheet.Cells[iRow, 6]).Text.ToString() != "")
                            {
                                validate++;
                                intError++;
                                drError = Result[2].NewRow();
                                drError["ID"] = intError;
                                drError["eCtrlID"] = dr["CtrlID"].ToString();
                                drError["eItemID"] = "-";
                                drError["ErrorString"] = ((Excel.Range)worksheet.Cells[iRow, 6]).Text.ToString() + "::日期错误!";
                                Result[2].Rows.Add(drError);
                            }
                            if (((Excel.Range)worksheet.Cells[iRow, 6]).Text.ToString() == "")
                            {
                                //validate--;
                                applicationsDate = DateTime.Now;
                            }
                            dr["ApplicantsDate"] = applicationsDate;
                            dr["DeliverStore"] = ((Excel.Range)worksheet.Cells[iRow, 7]).Text;
                            if (store.StoreDT.Select(string.Format("StoreName='{0}'", dr["DeliverStore"].ToString())).Length == 0)
                            {
                                validate++;
                                intError++;
                                drError = Result[2].NewRow();
                                drError["ID"] = intError;
                                drError["eCtrlID"] = dr["CtrlID"].ToString();
                                drError["eItemID"] = "-";
                                drError["ErrorString"] = ((Excel.Range)worksheet.Cells[iRow, 7]).Text + "::店铺错误!";
                                Result[2].Rows.Add(drError);
                            }
                            dr["ReceiptStore"] = ((Excel.Range)worksheet.Cells[iRow, 8]).Text;
                            if (store.StoreDT.Select(string.Format("StoreName='{0}'", dr["ReceiptStore"].ToString())).Length == 0)
                            {
                                validate++;
                                intError++;
                                drError = Result[2].NewRow();
                                drError["ID"] = intError;
                                drError["eCtrlID"] = dr["CtrlID"].ToString();
                                drError["eItemID"] = "-";
                                drError["ErrorString"] = ((Excel.Range)worksheet.Cells[iRow, 8]).Text + "::店铺错误!";
                                Result[2].Rows.Add(drError);
                            }

                            double totalPrice = 0;
                            DataRow[] itemDr = items.ItemsDT.Select(string.Format("ItemID='{0}' or ItemID2='{0}'", ((Excel.Range)worksheet.Cells[iRow, 10]).Text.ToString()));
                            if (itemDr.Length != 0)
                            {
                                double.TryParse(itemDr[0]["Price"].ToString(), out totalPrice);
                            }
                            else
                            {
                                validate++;
                                intError++;
                                drError = Result[2].NewRow();
                                drError["ID"] = intError;
                                drError["eCtrlID"] = dr["CtrlID"].ToString();
                                drError["eItemID"] = "-";
                                drError["ErrorString"] = ((Excel.Range)worksheet.Cells[iRow, 10]).Text.ToString() + "::货物号错误!";
                                Result[2].Rows.Add(drError);
                            }


                            int totalCount = 0;
                            if (!int.TryParse(((Excel.Range)worksheet.Cells[iRow, 11]).Text.ToString(), out totalCount))
                            {
                                validate++;
                                intError++;
                                drError = Result[2].NewRow();
                                drError["ID"] = intError;
                                drError["eCtrlID"] = dr["CtrlID"].ToString();
                                drError["eItemID"] = "-";
                                drError["ErrorString"] = ((Excel.Range)worksheet.Cells[iRow, 10]).Text.ToString() + "::货物数量错误!";
                                Result[2].Rows.Add(drError);
                            }
                            dr["TotalCount"] = totalCount;
                            dr["TotalPrice"] = totalPrice * totalCount;

                            dr["IsDelete"] = 0;
                            dr["ApprovalState"] = 0;
                            dr["ApprovalState2"] = 0;
                            dr["DeliverState"] = 0;
                            dr["ReceiptState"] = 0;
                            dr["AppState"] = 0;
                            dr["Alert_Approval"] = 0;
                            dr["Alert_Deliver"] = 0;
                            dr["Alert_Receipt"] = 0;

                            if (dr["CtrlID"].ToString() == "")
                            {
                                validate++;
                                intError++;
                                drError = Result[2].NewRow();
                                drError["ID"] = intError;
                                drError["eCtrlID"] = dr["CtrlID"].ToString();
                                drError["eItemID"] = "-";
                                drError["ErrorString"] = ((Excel.Range)worksheet.Cells[iRow, 2]).Text + "::控制号错误!";
                                Result[2].Rows.Add(drError);
                            }

                            if (validate == 0) Result[0].Rows.Add(dr);
                        }
                    }
                    else if (strLastFailCID != dr["CtrlID"].ToString())
                    {
                        strLastFailCID = dr["CtrlID"].ToString();
                        validate++;
                        intError++;
                        drError = Result[2].NewRow();
                        drError["ID"] = intError;
                        drError["eCtrlID"] = dr["CtrlID"].ToString();
                        drError["eItemID"] = "-";
                        drError["ErrorString"] = ((Excel.Range)worksheet.Cells[iRow, 2]).Text + "::货品超过20条!";
                        Result[2].Rows.Add(drError);
                    }
                }



                //生成货物行数据
                for (int iRow = 2; iRow <= iRowCount; iRow++)
                {
                    int validate = 0;
                    DataRow dr = Result[1].NewRow();

                    dr["CtrlID"] = ((Excel.Range)worksheet.Cells[iRow, 2]).Text;
                    if (Result[2].Select(string.Format("eCtrlID='{0}'", dr["CtrlID"])).Length == 0)
                    {
                        DataRow[] itemDr;
                        string itemID = ((Excel.Range)worksheet.Cells[iRow, 10]).Text.ToString();
                        itemDr = items.ItemsDT.Select(string.Format("ItemID='{0}'", itemID));//货号
                        if (itemDr.Length > 0)
                        {
                            dr["ItemID"] = itemDr[0]["ItemID"];
                            dr["ItemID2"] = itemDr[0]["ItemID2"];
                            dr["Price"] = itemDr[0]["Price"];
                            if (itemDr[0]["Detail"].ToString().IndexOf("'") > -1 || itemDr[0]["Detail"].ToString().IndexOf("\"") > -1)
                            {
                                validate++;
                                intError++;
                                drError = Result[2].NewRow();
                                drError["ID"] = intError;
                                drError["eCtrlID"] = dr["CtrlID"].ToString();
                                drError["eItemID"] = itemID;
                                drError["ErrorString"] = ((Excel.Range)worksheet.Cells[iRow, 10]).Text.ToString() + "::货物描述有被禁止的符号(单引号,双引号,单撇号)!";
                                Result[2].Rows.Add(drError);
                            }
                            else
                            {
                                dr["Detail"] = itemDr[0]["Detail"];
                            }
                            dr["Department"] = itemDr[0]["Department"];
                            dr["App_Level"] = itemDr[0]["Class"];

                            int count = 0;
                            if (!int.TryParse(((Excel.Range)worksheet.Cells[iRow, 11]).Text.ToString(), out count) || count == 0)
                            {
                                validate++;
                                intError++;
                                drError = Result[2].NewRow();
                                drError["ID"] = intError;
                                drError["eCtrlID"] = dr["CtrlID"].ToString();
                                drError["eItemID"] = itemID;
                                drError["ErrorString"] = ((Excel.Range)worksheet.Cells[iRow, 10]).Text.ToString() + "::货物数量错误!";
                                Result[2].Rows.Add(drError);
                            }
                            else
                                dr["App_Count"] = count;

                            dr["ItemHighlight"] = 1;

                        }
                        else
                        {
                            itemDr.Initialize();
                            itemDr = items.ItemsDT.Select(string.Format("ItemID2='{0}'", itemID));//双货号
                            if (itemDr.Length > 0)
                            {
                                dr["ItemID"] = itemDr[0]["ItemID"];
                                dr["ItemID2"] = itemDr[0]["ItemID2"];
                                dr["Price"] = itemDr[0]["Price"];
                                if (itemDr[0]["Detail"].ToString().IndexOf("'") > -1 || itemDr[0]["Detail"].ToString().IndexOf("\"") > -1)
                                {
                                    validate++;
                                    intError++;
                                    drError = Result[2].NewRow();
                                    drError["ID"] = intError;
                                    drError["eCtrlID"] = dr["CtrlID"].ToString();
                                    drError["eItemID"] = itemID;
                                    drError["ErrorString"] = ((Excel.Range)worksheet.Cells[iRow, 10]).Text.ToString() + "::货物描述有被禁止的符号(单引号,双引号,单撇号)!";
                                    Result[2].Rows.Add(drError);
                                }
                                else
                                {
                                    dr["Detail"] = itemDr[0]["Detail"];
                                }
                                dr["Department"] = itemDr[0]["Department"];
                                dr["App_Level"] = itemDr[0]["Class"];

                                int count = 0;
                                if (!int.TryParse(((Excel.Range)worksheet.Cells[iRow, 11]).Text.ToString(), out count) || count == 0)
                                {
                                    validate++;
                                    intError++;
                                    drError = Result[2].NewRow();
                                    drError["ID"] = intError;
                                    drError["eCtrlID"] = dr["CtrlID"].ToString();
                                    drError["eItemID"] = itemID;
                                    drError["ErrorString"] = ((Excel.Range)worksheet.Cells[iRow, 10]).Text.ToString() + "::货物数量错误!";
                                    Result[2].Rows.Add(drError);
                                }
                                else
                                    dr["App_Count"] = count;

                                dr["ItemHighlight"] = 2;
                            }
                        }


                        dr["IsDelete"] = 0;

                        if (dr["ItemID"].ToString() == "" && dr["ItemID2"].ToString() == "")
                        {
                            validate++;
                            intError++;
                            drError = Result[2].NewRow();
                            drError["ID"] = intError;
                            drError["eCtrlID"] = dr["CtrlID"].ToString();
                            drError["eItemID"] = itemID;
                            drError["ErrorString"] = ((Excel.Range)worksheet.Cells[iRow, 10]).Text.ToString() + "::货号错误!";
                            Result[2].Rows.Add(drError);
                        }

                        if (validate == 0) Result[1].Rows.Add(dr);
                    }
                }


                //与数据库对照重复控制号

                for (int i = 0; i < Result[0].Rows.Count; i++)
                {
                    DataRow[] repeatDr = applicationInfoDT.Select(string.Format("CtrlID='{0}'", Result[0].Rows[i]["CtrlID"]));
                    if (repeatDr.Length > 0)
                    {
                        Result[0].Rows[i].Delete();
                        i--;
                    }
                }
                for (int i = 0; i < Result[1].Rows.Count; i++)
                {
                    DataRow[] repeatDr = applicationInfoDT.Select(string.Format("CtrlID='{0}'", Result[1].Rows[i]["CtrlID"]));
                    if (repeatDr.Length > 0)
                    {
                        Result[1].Rows[i].Delete();
                        i--;
                    }
                }

                //货物详细表与申请表对照多余控制号

                for (int i = 0; i < Result[1].Rows.Count; i++)
                {
                    DataRow[] repeatDr = Result[0].Select(string.Format("CtrlID='{0}'", Result[1].Rows[i]["CtrlID"]));
                    if (repeatDr.Length == 0)
                    {
                        Result[1].Rows[i].Delete();
                        i--;
                    }
                }


                return Result;
            }
            catch { Exception ex; return null; }
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

        public void ExcelToDataTable_Wuliu(string filePath, DataTable Result, string strUsername)
        {
            //DataTable Result = new DataTable();


            Excel.Application app = new Excel.Application();
            Excel.Sheets sheets;
            object oMissiong = System.Reflection.Missing.Value;
            Excel.Workbook workbook = null;

            try
            {
                //if (app == null) return null;
                workbook = app.Workbooks.Open(filePath, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong,
                    oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
                sheets = workbook.Worksheets;

                //将数据读入到DataTable中
                Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);//读取第一张表  
                //if (worksheet == null) return null;

                int iRowCount = worksheet.UsedRange.Rows.Count;
                int iColCount = worksheet.UsedRange.Columns.Count;

                //生成行数据
                Excel.Range range;
                for (int iRow = 2; iRow <= iRowCount; iRow++)
                {
                    //((Excel.Range)worksheet.Cells[iRow, 1]).Text;
                    string strCtrlid = ((Excel.Range)worksheet.Cells[iRow, 1]).Text.ToString();
                    string s_o = ((Excel.Range)worksheet.Cells[iRow, 2]).Text.ToString();
                    string s_o_str = ((Excel.Range)worksheet.Cells[iRow, 3]).Text.ToString();
                    string o_o = ((Excel.Range)worksheet.Cells[iRow, 4]).Text.ToString();
                    string o_o_str = ((Excel.Range)worksheet.Cells[iRow, 5]).Text.ToString();
                    string batchnum1 = ((Excel.Range)worksheet.Cells[iRow, 6]).Text.ToString();
                    string batchnum2 = ((Excel.Range)worksheet.Cells[iRow, 7]).Text.ToString();

                    string sql = "update ApplicationInfo set S_O='" + s_o + "',O_O='" + o_o + "',Batch_Num1='" + batchnum1 + "',Batch_Num2='" + batchnum2 + "',WuliuUser='" + strUsername + "',WuliuDate='" + DateTime.Now.ToString() + "',S_O_Str='" + s_o_str + "',O_O_Str='" + o_o_str + "',AppState=9  where AppState=4 and CtrlID='" + strCtrlid + "' ";
                    AccessHelper ah = new AccessHelper();
                    Boolean boolResult = ah.ExecuteSQLNonquery(sql);
                }
            }
            catch (Exception ex) { }
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
        public void WriteToExcelSPB(DataTable thisTable, string FileName, string sheetName)
        {
            string strFilePath = FileName;
            string XLSName = System.IO.Directory.GetCurrentDirectory() + @"\templet\商品部模板.xls";
            Excel.Application app = new Excel.Application();
            app.DisplayAlerts = false;
            app.ScreenUpdating = false;
            Excel.Workbooks wbks = app.Workbooks;
            Excel._Workbook _wbk = wbks.Add(XLSName);
            Excel.Sheets shs = _wbk.Sheets;
            Excel._Worksheet _wsh = (Excel._Worksheet)shs.get_Item(1);
            try
            {
                int sheetRowsCount = _wsh.UsedRange.Rows.Count;
                int count = thisTable.Columns.Count;

                //设置列名
                //foreach (DataColumn myNewColumn in thisTable.Columns)
                //{
                //    _wsh.Cells[0, count] = myNewColumn.ColumnName;
                //    count = count + 1;
                //}er
                //for (int i = 0; i < count; i++)
                //{
                //    _wsh.Cells[1, i + 1] = thisTable.Columns[i].ColumnName;
                //}

                //加入內容
                string strLastCtrlID = "";
                string strLastFinishState = "";
                for (int i = 1; i <= thisTable.Rows.Count; i++)
                {
                    _wsh.Cells[i + sheetRowsCount, 1] = "'" + thisTable.Rows[i - 1]["CtrlID"].ToString();
                    _wsh.Cells[i + sheetRowsCount, 2] = "'" + thisTable.Rows[i - 1]["ItemID"].ToString();
                    _wsh.Cells[i + sheetRowsCount, 3] = "'" + thisTable.Rows[i - 1]["ItemID2"].ToString();
                    _wsh.Cells[i + sheetRowsCount, 4] = "'" + thisTable.Rows[i - 1]["DeliverStore"].ToString();
                    _wsh.Cells[i + sheetRowsCount, 5] = "'" + thisTable.Rows[i - 1]["ReceiptStore"].ToString();
                    _wsh.Cells[i + sheetRowsCount, 6] = "'" + thisTable.Rows[i - 1]["ApplicantsDate"].ToString();
                    _wsh.Cells[i + sheetRowsCount, 7] = "'" + thisTable.Rows[i - 1]["ApplicantsName"].ToString();
                    _wsh.Cells[i + sheetRowsCount, 8] = "'" + thisTable.Rows[i - 1]["TotalPrice"].ToString();
                    if (thisTable.Rows[i - 1]["CtrlID"].ToString() == strLastCtrlID)
                    {
                        _wsh.Cells[i + sheetRowsCount, 9] = strLastFinishState;
                    }
                    else
                    {
                        strLastFinishState = "'" + strFinishState(thisTable.Rows[i - 1]["CtrlID"].ToString(), thisTable.Rows[i - 1]["AppState"].ToString());
                        strLastCtrlID = thisTable.Rows[i - 1]["CtrlID"].ToString();
                        _wsh.Cells[i + sheetRowsCount, 9] = strLastFinishState;
                    }
                    _wsh.Cells[i + sheetRowsCount, 10] = "'" + strAppState(thisTable.Rows[i - 1]["AppState"].ToString(), thisTable.Rows[i - 1]["IsDelete"].ToString());
                }
                _wsh.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                _wsh.Cells.Columns.AutoFit();
                _wsh.Cells.Rows.AutoFit();
                app.ScreenUpdating = true;
                //若為EXCEL2000, 將最後一個參數拿掉即可             
                _wbk.SaveAs(strFilePath, Excel.XlFileFormat.xlWorkbookNormal,
                    null, null, false, false, Excel.XlSaveAsAccessMode.xlShared,
                    false, false, null, null, null);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                //關閉文件
                _wbk.Close(false, Type.Missing, Type.Missing);
                app.Workbooks.Close();
                app.Quit();

                //釋放資源
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_wsh);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(_wbk);
                _wsh = null;
                _wbk = null;
                app = null;
            }
        }
        public string strAppState(string strIN1, string strIN2)
        {
            string strResult = "";
            if (strIN2 != null && strIN2 != "1")
            {
                switch (strIN1)
                {
                    case "0":
                        strResult = "未审核";
                        break;
                    case "1":
                        strResult = "商品部审核通过";
                        break;
                    case "2":
                        strResult = "财务部审核通过";
                        break;
                    case "3":
                        strResult = "转出店面确认通过";
                        break;
                    case "4":
                        strResult = "转入店面确认通过";
                        break;
                    case "5":
                        strResult = "物流确认通过";
                        break;
                    case "9":
                        strResult = "已完成";
                        break;
                    default:
                        strResult = "无";
                        break;
                }
            }
            else
            {
                strResult = "已撤销";
            }
            return strResult;
        }
        public string strFinishState(string strIN1, string strIN2)
        {
            string strResult = "";
            BaseProcess bp = new Business.BaseProcess();
            if (strIN2 != null && strIN1 != null && strIN2 == "9")
            {
                if (bp.boolCampareOrder(strIN1))
                {
                    strResult = "异常";
                }
                else
                {
                    strResult = "正常";
                }

            }
            else
            {
                strResult = "-";
            }
            return strResult;
        }
    }
}

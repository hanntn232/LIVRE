using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Microsoft.Win32;
using System.Windows;
using System.IO;

namespace tabDonHang.Sản_phẩm
{
    class XuatExcelDanhSachSanPham
    {
        public void xuatExcelDSSP_Nhap(List<SanPham> ListSanPham)
        {
            string filePath = "";
            SaveFileDialog dialog = new SaveFileDialog();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";
            if (dialog.ShowDialog() == true)
            {
                filePath = dialog.FileName;
            }
            if (string.IsNullOrEmpty(filePath))
            {
                if (filePath != "")
                    MessageBox.Show("Đường dẫn không hợp lệ");
                return;
            }
            try
            {
                using (ExcelPackage p = new ExcelPackage())
                {
                    p.Workbook.Properties.Author = "Livre";
                    p.Workbook.Properties.Title = "Thống kê danh sách sản phẩm nhập";
                    p.Workbook.Worksheets.Add("Sheet1");
                    ExcelWorksheet worksheet = p.Workbook.Worksheets["Sheet1"];
                    worksheet.Name = "Sheet1";
                    worksheet.Cells.Style.Font.Size = 12;
                    worksheet.Cells.Style.Font.Name = "Arial";
                    string[] columnHeader = { "STT", "Tên sản phẩm", "Mã sản phẩm", "Số lượng", "Mã nhà cung cấp", "Giá gốc", "Giá bán" };
                    var numberOfColumn = columnHeader.Count();
                    worksheet.Cells[1, 1].Value = "Thống kê danh sách sản phẩm nhập";
                    worksheet.Cells[1, 1, 1, numberOfColumn].Merge = true;
                    worksheet.Cells[1, 1, 1, numberOfColumn].Style.Font.Bold = true;
                    worksheet.Cells[1, 1, 1, numberOfColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    int columnIndex = 1, rowIndex = 2;
                    foreach (var item in columnHeader)
                    {
                        var cell = worksheet.Cells[rowIndex, columnIndex];
                        cell.Value = item;
                        columnIndex++;
                    }
                    foreach (var item in ListSanPham)
                    {
                        columnIndex = 1;
                        rowIndex++;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.STT;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.TenSanPham;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.MaSanPham;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.TenNCC;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.GiaGoc;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.GiaBan;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.SoLuongNhap;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.SoLuongBan;
                        worksheet.Cells[rowIndex, columnIndex++].Value = item.SoLuongTon;
                    }
                    Byte[] bin = p.GetAsByteArray();
                    File.WriteAllBytes(filePath, bin);
                    MessageBox.Show("Xuất excel thành công!");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }




    }
}

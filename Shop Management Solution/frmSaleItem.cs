using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Shop_Management_Solution.lib.util;
using Shop_Management_Solution.lib;
using Shop_Management_Solution.lib.dal;

using System.IO;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;



namespace Shop_Management_Solution
{
    public partial class frmSaleItem : Form
    {
        private long saleCounter;
        private double saleTotalPrice;

        public frmSaleItem()
        {
            InitializeComponent();
            this.saleCounter = 0;
            this.saleTotalPrice = 0;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public double getSaleTotalPrice()
        {
            return this.saleTotalPrice;
        }
        private void frmSaleItem_Load(object sender, EventArgs e)
        {


            try
            {
                bool isExist = ShopDAL.isItemTypeExists();
                if (isExist)
                {
                    ShopDAL db = new ShopDAL();
                    DataSet ds = db.GetItemsType();
                    
                    // Inserting Default Row for Selection
                    DataRow defaultRow = ds.Tables[0].NewRow();
                    defaultRow["Type_ID"] = "0";
                    defaultRow["Name"] = "---------------- Select Item Type ----------------";
                    ds.Tables[0].Rows.InsertAt(defaultRow, 0);

                    cmb_itemType.DataSource = ds.Tables[0];
                    cmb_itemType.DisplayMember = "Name";
                    cmb_itemType.ValueMember = "Type_ID";
                    cmb_itemType.SelectedIndex = 0;
                    lstView_sales.Columns[0].Width = 0;
                    lblItemCount.Text = "0";
                    lblTotalPrice.Text = ConfigurationDAL.GetCurrentCurrency() + " 0.00";
                    txtSalePrice.Text = "0";
                  



                }
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(this, "Add atleast one item type to Sale Item(s)", "Error:Sale Item(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Error:Sale Item(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }


            //string[] row1 = { "CD-Software", "2", "30" };
            //string[] row2 = { "CD-Software", "2", "30" };
            /*lstView_sales.Items.Add("1").SubItems.AddRange(row1);
            lstView_sales.Items.Add("1").SubItems.AddRange(row2);

            foreach(ListViewItem lvi in lstView_sales.Items)
            {
                MessageBox.Show(lvi.SubItems[3].Text);
            }*/
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            String itemTypeId = cmb_itemType.SelectedValue.ToString();
            String itemTypeValue = cmb_itemType.Text;
            String quantity = txtQuantity.Value.ToString();
            String salePrice = txtSalePrice.Text;
            try
            {
                double price = double.Parse(salePrice);
                if (!String.IsNullOrEmpty(salePrice) && txtQuantity.Value > 0 && price > 0)
                {
                    string[] newRecord = { itemTypeValue, quantity, salePrice };
                    lstView_sales.Items.Add(itemTypeId).SubItems.AddRange(newRecord);
                    //updateCounter("ADD");
                    updateTotalPrice(quantity, salePrice, "ADD");
                    cmb_itemType.SelectedIndex = 0;
                    txtQuantity.Value = 0;
                    txtSalePrice.Text = "0";
                }
                else
                {
                    throw new Exception("Invalid Price or Quantity");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Error: Sale Item(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Error: Sale Item(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private List<Sale> getListofItemsToBeAdded()
        {
            List<Sale> lstOfSaleItem = new List<Sale>();
            foreach (ListViewItem lvi in lstView_sales.Items)
            {
                long itemTypeId = long.Parse(lvi.SubItems[0].Text);
                string itemTypeName = lvi.SubItems[1].Text;
                long quantity = long.Parse(lvi.SubItems[2].Text);
                double price = double.Parse(lvi.SubItems[3].Text);
                Sale item = new Sale();
                item.ItemTypeId = itemTypeId;
                item.ItemName = itemTypeName;
                item.Quantity = quantity;
                item.SalePrice = price;
                lstOfSaleItem.Add(item);
            }
            return lstOfSaleItem;
        }

        private void updateTotalPrice(String quantity, String price, String action)
        {


            long actualQuantity = long.Parse(quantity);
            double actualPrice = double.Parse(price);

            double totalPrice = actualPrice * actualQuantity;

            if (action == "ADD")
            {
                this.saleTotalPrice = this.saleTotalPrice + totalPrice;
                this.saleCounter = this.saleCounter + actualQuantity;
            }
            else if (action == "REMOVE")
            {
                this.saleTotalPrice = this.saleTotalPrice - totalPrice;
                this.saleCounter = this.saleCounter - actualQuantity;
            }
            else
            {
                throw new Exception("Invalid Action");
            }

            lblItemCount.Text = this.saleCounter.ToString();
            lblTotalPrice.Text = ConfigurationDAL.GetCurrentCurrency() + " " + this.saleTotalPrice;
        }
        /*private void updateCounter(String action)
        {

            if (action == "ADD")
            {
                this.saleCounter = this.saleCounter + 1;
            }
            else if (action == "REMOVE")
            {
                this.saleCounter = this.saleCounter - 1;
            }
            else
            {
                throw new Exception("Invalid Action");
            }

           
            lblItemCount.Text = this.saleCounter.ToString();
        }*/

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstView_sales.SelectedItems)
            {
                String quantity = item.SubItems[2].Text;
                String salePrice = item.SubItems[3].Text;
                lstView_sales.Items.Remove(item);
                //updateCounter("REMOVE");
                updateTotalPrice(quantity, salePrice, "REMOVE");
            }

        }

        private void btn_Save_And_Print_Click(object sender, EventArgs e)
        {

            try
            {
                List<Sale> saleItems = this.getListofItemsToBeAdded();
                if (saleItems.Count >= 1)
                {
                    string path = "";

                    FileDialog dialog = new SaveFileDialog();
                    dialog.Title = "Save file as...";
                    long nextInvoiceId = DBUtil.GetNextID("Sale_ID", "Sales");
                    dialog.FileName = "Sale_No_" + nextInvoiceId.ToString() + "_Dated_" + System.DateTime.Now.Day.ToString() + "-" + System.DateTime.Now.Month.ToString() + "-" + System.DateTime.Now.Year.ToString();                    
                    dialog.RestoreDirectory = true;
                    dialog.Filter = "Adobe Acrobat Reader PDF (*.pdf)|*.*";
                    DialogResult result = dialog.ShowDialog();                    

                    if (result == DialogResult.OK)
                    {
                        String saleDate = dateOfSale.Text;
                        long invoiceID = ShopDAL.SaleItems(saleDate, saleItems);

                        path = dialog.FileName;
                        Document myDocument = new Document(PageSize.A4.Rotate());


                        // step 2:
                        // Now create a writer that listens to this doucment and writes the document to desired Stream.

                        PdfWriter.GetInstance(myDocument, new FileStream(path+".pdf", FileMode.Create));

                        // step 3:  Open the document now using
                        myDocument.Open();

                        // step 4: Now add some contents to the document
                        PdfPTable table = new PdfPTable(6);
                        table.WidthPercentage = 50;

                        dateOfSale.Format = DateTimePickerFormat.Long;
                        String displayDate = dateOfSale.Text;

                        //String displayDate = System.DateTime.Now.ToLongDateString() + " " + System.DateTime.Now.ToLongTimeString();

                        // Printing Header
                        PdfPCell cellShopName = new PdfPCell(new Paragraph(ConfigurationDAL.GetShopName(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 14)));
                        table.HorizontalAlignment = Element.ALIGN_LEFT;
                        cellShopName.Colspan = 6;
                        cellShopName.BackgroundColor = new BaseColor(204, 204, 204);
                        cellShopName.BorderColor = new BaseColor(204, 204, 204);
                        cellShopName.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(cellShopName);

                        PdfPCell cellCurrentDate = new PdfPCell(new Paragraph("Dated: " + displayDate));
                        cellCurrentDate.Colspan = 6;
                        cellCurrentDate.BackgroundColor = new BaseColor(204, 204, 204);
                        cellCurrentDate.BorderColor = new BaseColor(204, 204, 204);
                        cellCurrentDate.HorizontalAlignment = Element.ALIGN_CENTER;         
                        table.AddCell(cellCurrentDate);

                        PdfPCell cellInvoiceID = new PdfPCell(new Paragraph("Invoice ID: " + invoiceID.ToString()));
                        cellInvoiceID.Colspan = 6;
                        cellInvoiceID.BackgroundColor = new BaseColor(204, 204, 204);
                        cellInvoiceID.BorderColor = new BaseColor(204, 204, 204);
                        cellInvoiceID.HorizontalAlignment = Element.ALIGN_LEFT;
                        table.AddCell(cellInvoiceID);
         


                        // Printing Items

                        PdfPCell cellItemHeader = new PdfPCell(new Paragraph("Item Name"));
                        cellItemHeader.Colspan = 2;
                        table.AddCell(cellItemHeader);
                        PdfPCell cellQuantityHeader = new PdfPCell(new Paragraph("Quantity"));
                        cellQuantityHeader.Colspan = 2;
                        table.AddCell(cellQuantityHeader);
                        PdfPCell cellPriceHeader = new PdfPCell(new Paragraph("Price"));
                        cellPriceHeader.Colspan = 2;
                        table.AddCell(cellPriceHeader);                        

                        foreach (Sale item in saleItems)
                        {

                            PdfPCell cellItemName = new PdfPCell(new Paragraph(item.ItemName));
                            cellItemName.Colspan = 2;
                            table.AddCell(cellItemName);

                            PdfPCell cellQuantity = new PdfPCell(new Paragraph(item.Quantity.ToString()));
                            cellQuantity.Colspan = 2;
                            table.AddCell(cellQuantity);

                            PdfPCell cellPrice = new PdfPCell(new Paragraph(ConfigurationDAL.GetCurrentCurrency() + " " + item.SalePrice.ToString()));
                            cellPrice.Colspan = 2;
                            table.AddCell(cellPrice);

                        }

                        // Printing Total Quantity and Price
                        PdfPCell cellTotalQtyHeader = new PdfPCell(new Paragraph("Total Quantity "));
                        cellTotalQtyHeader.Colspan = 2;
                        cellTotalQtyHeader.HorizontalAlignment = Element.ALIGN_RIGHT;
                        cellTotalQtyHeader.BackgroundColor = new BaseColor(200, 200, 200);
                        table.AddCell(cellTotalQtyHeader);

                        PdfPCell cellTotalQtyValue = new PdfPCell(new Paragraph(this.saleCounter.ToString()));
                        cellTotalQtyValue.BackgroundColor = new BaseColor(200, 200, 200);
                        table.AddCell(cellTotalQtyValue); 
                        

                        PdfPCell cellTotalPriceHeader = new PdfPCell(new Paragraph("Total Price"));
                        cellTotalPriceHeader.BackgroundColor = new BaseColor(200, 200, 200);
                        table.AddCell(cellTotalPriceHeader);  

                        PdfPCell cellTotalPriceValue = new PdfPCell(new Paragraph(ConfigurationDAL.GetCurrentCurrency() + " " + this.saleTotalPrice.ToString()));
                        cellTotalPriceValue.Colspan = 2;
                        cellTotalPriceValue.BackgroundColor = new BaseColor(200, 200, 200);
                        table.AddCell(cellTotalPriceValue); 
                        
                        // Printing iWorker Footer 
                        PdfPCell cellFooter = new PdfPCell(new Paragraph("Shop Management Solution by www.XtraWebApps.com", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN , 10 )));
                        cellFooter.Colspan = 6;
                        cellFooter.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(cellFooter); 

                        // Add cells to table and close it.
                        myDocument.Add(table);
                        myDocument.Close();

                        //Launch the PDF Generated.
                        System.Diagnostics.Process.Start(path + ".pdf");

                        this.Close();
                        MessageBox.Show(this, "Item sold successfully.", "Sale Item(s)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    throw new Exception("Please add some item(s) in list");
                }

            }
            catch (DocumentException de)
            {

                MessageBox.Show(de.Message);
            }
            catch (IOException ioe)
            {
                MessageBox.Show(ioe.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Error: Sale Item(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




            /* try
             {
                 List<Sale> saleItems = this.getListofItemsToBeAdded();
                 if (saleItems.Count >= 1)
                 {
                     String saleDate = dateOfSale.Text;
                     ShopDAL.SaleItems(saleDate, saleItems);

                   
                     dateOfSale.Format = DateTimePickerFormat.Long;                   
                     String displayDate = dateOfSale.Text;
                     PCPrint printer = new PCPrint();
                   
                     printer.PrinterFont = new Font("Times New Roman", 18);
                     printer.TextToPrint = " \n " + ConfigurationDAL.GetShopName();
                     printer.PrinterFont = new Font("Verdana", 10);
                     printer.TextToPrint += " \n Dated: " + displayDate;                   
                     printer.TextToPrint += " \n_________________________________";

                     printer.TextToPrint += " \n Item Name  Quantity    Price";
                     printer.TextToPrint += " \n_________________________________";
                     foreach (Sale item in saleItems)
                     {
                         printer.TextToPrint += " \n  " + item.ItemName + "    " + item.Quantity+"    "+ ConfigurationDAL.GetCurrentCurrency() + " " + +item.SalePrice;

                     }
                     printer.TextToPrint += " \n_________________________________";
                     printer.PrinterFont = new Font("Verdana", 12);
                     printer.TextToPrint += " \n Total Items:  " + this.saleCounter + "       Total Price:  "+ConfigurationDAL.GetCurrentCurrency() +" "+ this.saleTotalPrice;
                     printer.TextToPrint += " \n_________________________________";
                     printer.TextToPrint += " \nProduct by: www.iWorker4U.com";


                     printer.Print();
                     this.Close();
                     MessageBox.Show(this, "Item sold successfully.", "Sale Item(s)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }
                 else
                 {
                     throw new Exception("Please add some item(s) in list");
                 }
               
               
             }
             catch (Exception ex)
             {
                 MessageBox.Show(this, ex.Message.ToString(), "Error: Sale Item(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }*/

        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            cmb_itemType.SelectedIndex = 0;
            txtQuantity.Value = 0;
            txtSalePrice.Text = "0";
        }

        private void onItemTypeChange(object sender, EventArgs e)
        {

        }

        private void onItemTypeValueChange(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            String selectedItemTypeIndex = cb.SelectedValue.ToString();
            if (selectedItemTypeIndex != "System.Data.DataRowView")
            {
                long itemId = long.Parse(selectedItemTypeIndex);

                if (itemId.ToString() == "0")
                {
                    lblAvailableQuantity.Text = "0";
                    txtSalePrice.Text = "0";
                    txtQuantity.Maximum = 0;
                }
                else
                {
                    long availableQuantity = ShopDAL.getStockInHandQuantity(itemId);
                    long salePrice = ShopDAL.getItemTypeSalePrice(itemId);
                    lblAvailableQuantity.Text = availableQuantity.ToString();
                    txtSalePrice.Text = salePrice.ToString();
                    txtQuantity.Maximum = availableQuantity;
                }
                

            }

        }

        private void txtSalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Code to Ensure that only numberic value with 
            if (!char.IsControl(e.KeyChar)
                 && !char.IsDigit(e.KeyChar)
                 && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void lstView_sales_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.Item.Selected)
            {
                btn_Delete.Enabled = true;
                // listView.ItemSettings.SelectedAppearance.BackColor = Color.LightBlue;
                //listView.ItemSettings.SelectedAppearance.BackColor2 = SystemColors.Highlight;
                //listView.ItemSettings.SelectedAppearance.BackGradientStyle = GradientStyle.Vertical;
            }
            else
            {
                btn_Delete.Enabled = false;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
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
        private Dictionary<string, string> quantitiesLeft;
        private long invoiceID;

        // for Invoice Head:
        private string invoiceTitle;
        private string invoiceSubTitle1;
        private string invoiceSubTitle2;
        private string invoiceSubTitle3;
        private string invoiceImage;

        // for Report:
        private int currentY;
        private int currentX;
        private int leftMargin;
        private int rightMargin;
        private int topMargin;
        private int bottomMargin;
        private int InvoiceWidth;
        private int InvoiceHeight;
        private string customerName;
        private string customerCity;
        private string sellerName;
        private string saleID;
        private string saleDate;
        private decimal saleFreight;
        private decimal subTotal;
        private decimal invoiceTotal;
        private bool readInvoice;
        private int amountPosition;

        // Font and Color:------------------
        // Title Font
        private System.Drawing.Font invoiceTitleFont = new System.Drawing.Font("Arial", 24, FontStyle.Regular);
        // Title Font height
        private int invoiceTitleHeight;
        // SubTitle Font
        private System.Drawing.Font invoiceSubTitleFont = new System.Drawing.Font("Arial", 14, FontStyle.Regular);
        // SubTitle Font height
        private int InvSubTitleHeight;
        // Invoice Font
        private System.Drawing.Font invoiceFont = new System.Drawing.Font("Arial", 12, FontStyle.Regular);
        // Invoice Font height
        private int invoiceFontHeight;
        // Blue Color
        private SolidBrush blueBrush = new SolidBrush(Color.Blue);
        // Red Color
        private SolidBrush redBrush = new SolidBrush(Color.Red);
        // Black Color
        private SolidBrush blackBrush = new SolidBrush(Color.Black);

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

                    //Creating dictionary to handle available quantity of all items. It's made of pair (Type_ID, Quantity)
                    quantitiesLeft = new Dictionary<string, string>();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        quantitiesLeft.Add(dr["Type_ID"].ToString(), ShopDAL.getStockInHandQuantity(long.Parse(dr["Type_ID"].ToString())).ToString());
                    }

                    // Inserting Default Row for Selection
                    DataRow defaultRow = ds.Tables[0].NewRow();
                    defaultRow["Type_ID"] = "0";
                    defaultRow["Name"] = "---------------- Select Item Type ----------------";
                    ds.Tables[0].Rows.InsertAt(defaultRow, 0);

                    cmb_itemType.DataSource = ds.Tables[0];
                    cmb_itemType.DisplayMember = "Name";
                    cmb_itemType.ValueMember = "Type_ID";
                    cmb_itemType.SelectedIndex = 0;

                    cmb_itemType.AutoCompleteMode = AutoCompleteMode.Append;
                    cmb_itemType.AutoCompleteSource = AutoCompleteSource.ListItems;

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
            String uom = lblUoM.Text;
            try
            {
                float price = NumberUtils.SafeParse(salePrice);
                if (!String.IsNullOrEmpty(salePrice) && txtQuantity.Value > 0 && price > 0)
                {

                    string[] newRecord = { itemTypeValue, quantity, salePrice, uom };
                    lstView_sales.Items.Add(itemTypeId).SubItems.AddRange(newRecord);
                    //updateCounter("ADD");
                    updateTotalPrice(quantity, salePrice, "ADD");
                    cmb_itemType.SelectedIndex = 0;
                    txtQuantity.Value = 0;
                    txtSalePrice.Text = "0";
                    lblUoM.Text = "N/A";
                    quantitiesLeft[itemTypeId] = (Decimal.Parse(quantitiesLeft[itemTypeId]) - Decimal.Parse(quantity)).ToString();
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
                double price = NumberUtils.SafeParse( lvi.SubItems[3].Text );
                string uom = lvi.SubItems[4].Text;

                Sale item = new Sale();
                item.ItemTypeId = itemTypeId;
                item.ItemName = itemTypeName;
                item.Quantity = quantity;
                item.SalePrice = price;
                item.UomName = uom;
                lstOfSaleItem.Add(item);
            }
            return lstOfSaleItem;
        }

        private void updateTotalPrice(String quantity, String price, String action)
        {


            long actualQuantity = long.Parse(quantity);
            float actualPrice = NumberUtils.SafeParse(price);

            double totalPrice = actualPrice * actualQuantity;
            totalPrice = Math.Round(totalPrice, 2);
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

                quantitiesLeft[item.SubItems[0].Text] = (Decimal.Parse(quantitiesLeft[item.SubItems[0].Text]) + Decimal.Parse(quantity)).ToString();
                //Updating quantity if the same item is currently chosen in combo box
                if ((cmb_itemType.SelectedIndex != 0) && (cmb_itemType.SelectedValue.ToString() == item.SubItems[0].Text))
                    lblAvailableQuantity.Text = quantitiesLeft[item.SubItems[0].Text];

            }

        }


        private void btn_Reset_Click(object sender, EventArgs e)
        {
            cmb_itemType.SelectedIndex = 0;
            txtQuantity.Value = 0;
            txtSalePrice.Text = "0";
            lblUoM.Text = "N/A";
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
                    float salePrice =  ShopDAL.getItemTypeSalePrice(itemId);
                    string uomName = ShopDAL.getItemTypeUoM(itemId);

                    lblAvailableQuantity.Text = quantitiesLeft[itemId.ToString()];
                    lblUoM.Text = uomName;
                    //lblAvailableQuantity.Text = availableQuantity.ToString();
                    txtSalePrice.Text = salePrice.ToString(CultureInfo.InvariantCulture);
                    txtQuantity.Maximum = Decimal.Parse(quantitiesLeft[itemId.ToString()]);
                    //txtQuantity.Maximum = availableQuantity;
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

        private void lstView_sales_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Delete) && (lstView_sales.Items.Count > 0) && (lstView_sales.SelectedItems.Count > 0))
            {
                btn_Delete_Click(lstView_sales, null);
            }
        }

        private void btnSaveAsPDF_Click(object sender, EventArgs e)
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

                        PdfWriter.GetInstance(myDocument, new FileStream(path + ".pdf", FileMode.Create));

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


                        PdfPCell cellAddress = new PdfPCell(new Paragraph("Address: " + ConfigurationDAL.GetCurrentAddress()));
                        cellAddress.Colspan = 6;
                        cellAddress.BackgroundColor = new BaseColor(204, 204, 204);
                        cellAddress.BorderColor = new BaseColor(204, 204, 204);
                        cellAddress.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(cellAddress);

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

                            PdfPCell cellQuantity = new PdfPCell(new Paragraph(item.Quantity.ToString() + "  " + item.UomName));
                            cellQuantity.Colspan = 2;
                            table.AddCell(cellQuantity);

                            string pricewithUnit = ConfigurationDAL.GetCurrentCurrency() + " " + string.Format("{0:N2}", item.SalePrice);
                            PdfPCell cellPrice = new PdfPCell(new Paragraph(pricewithUnit));
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

                        // Printing XtraWebApps Footer 
                        PdfPCell cellFooter = new PdfPCell(new Paragraph("Shop Management Solution by www.XtraWebApps.com", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 10)));
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
        }

        private void prnDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            leftMargin = (int)e.MarginBounds.Left;
            rightMargin = (int)e.MarginBounds.Right;
            topMargin = (int)e.MarginBounds.Top;
            bottomMargin = (int)e.MarginBounds.Bottom;
            InvoiceWidth = (int)e.MarginBounds.Width;
            InvoiceHeight = (int)e.MarginBounds.Height;

            setInvoiceHead(e.Graphics); // Draw Invoice Head
            setOrderData(e.Graphics); // Draw Order Data
            setInvoiceData(e.Graphics, e); // Draw Invoice Data

            readInvoice = true;
        }

        private void readInvoiceHead()
        {
            dateOfSale.Format = DateTimePickerFormat.Long;
            String displayDate = dateOfSale.Text;

            //Titles and Image of invoice:
            invoiceTitle = ConfigurationDAL.GetShopName(); // "International Food Company";
            invoiceSubTitle1 = "Address:" + ConfigurationDAL.GetCurrentAddress() + "\nDated :" + displayDate.ToString();
            invoiceImage = Application.StartupPath + @"\Images\" + "Header.jpg";
        }

        private void setInvoiceHead(Graphics g)
        {
            readInvoiceHead();

            currentY = topMargin;
            currentX = leftMargin;
            int ImageHeight = 0;

            // Draw Invoice image:
            if (System.IO.File.Exists(invoiceImage))
            {
                Bitmap oinvoiceImage = new Bitmap(invoiceImage);
                // Set Image Left to center Image:
                int xImage = currentX + (InvoiceWidth - oinvoiceImage.Width) / 2;
                ImageHeight = oinvoiceImage.Height; // Get Image Height
                g.DrawImage(oinvoiceImage, xImage, currentY);
            }

            invoiceTitleHeight = (int)(invoiceTitleFont.GetHeight(g));
            InvSubTitleHeight = (int)(invoiceSubTitleFont.GetHeight(g));

            // Get Titles Length:
            int leninvoiceTitle = (int)g.MeasureString(invoiceTitle, invoiceTitleFont).Width;
            int leninvoiceSubTitle1 = (int)g.MeasureString(invoiceSubTitle1, invoiceSubTitleFont).Width;

            // Set Titles Left:
            int xinvoiceTitle = currentX + (InvoiceWidth - leninvoiceTitle) / 2;
            int xinvoiceSubTitle1 = currentX + (InvoiceWidth - leninvoiceSubTitle1) / 2;

            // Draw Invoice Head:
            if (invoiceTitle != "")
            {
                currentY = currentY + ImageHeight;
                g.DrawString(invoiceTitle, invoiceTitleFont, blueBrush, xinvoiceTitle, currentY);
            }
            if (invoiceSubTitle1 != "")
            {
                currentY = currentY + invoiceTitleHeight;
                g.DrawString(invoiceSubTitle1, invoiceSubTitleFont, blueBrush, xinvoiceSubTitle1, currentY);
            }

            // Draw line:
            currentY = currentY + InvSubTitleHeight + 8;
            g.DrawLine(new Pen(Brushes.Black, 2), currentX, currentY, rightMargin, currentY);
        }

        private void setOrderData(Graphics g)
        {

            // Set Invoice
            string FieldValue = "";
            invoiceFontHeight = (int)(invoiceFont.GetHeight(g));

            // Set Invoice Value:
            currentX = leftMargin;
            currentY = currentY + 8;
            FieldValue = "Invoice ID: " + invoiceID.ToString();
            g.DrawString(FieldValue, invoiceFont, blackBrush, currentX, currentY);

            // Draw line:
            currentY = currentY + invoiceFontHeight + 8;
            g.DrawLine(new Pen(Brushes.Black), leftMargin, currentY, rightMargin, currentY);
        }

        private void setInvoiceData(Graphics g, System.Drawing.Printing.PrintPageEventArgs e)
        {

            List<Sale> saleItems = this.getListofItemsToBeAdded();

            // Set Invoice Table:
            string FieldValue = "";
            int CurrentRecord = 0;
            int RecordsPerPage = 20; // twenty items in a page
            decimal Amount = 0;
            bool StopReading = false;

            // Set Table Head:

            int xItemName = leftMargin;
            currentY = currentY + invoiceFontHeight;
            g.DrawString("Item Name", invoiceFont, blueBrush, xItemName, currentY);

            int xQuantity = xItemName + (int)g.MeasureString("Quantity", invoiceFont).Width + 72;
            g.DrawString("Quantity", invoiceFont, blueBrush, xQuantity, currentY);

            int xUnitPrice = xQuantity + (int)g.MeasureString("Unit Price", invoiceFont).Width + 72;
            g.DrawString("Unit Price", invoiceFont, blueBrush, xUnitPrice, currentY);


            currentY = currentY + invoiceFontHeight + 8;
            foreach( Sale item in saleItems)
            {
                FieldValue = item.ItemName;
                g.DrawString(FieldValue, invoiceFont, blackBrush, xItemName, currentY);

                FieldValue = item.Quantity + " "+item.UomName;
                g.DrawString(FieldValue, invoiceFont, blackBrush, xQuantity, currentY);

                FieldValue = ConfigurationDAL.GetCurrentCurrency() + " " + string.Format("{0:N2}", item.SalePrice);
                g.DrawString(FieldValue, invoiceFont, blackBrush, xUnitPrice, currentY);

                currentY = currentY + invoiceFontHeight;
            }
            setinvoiceTotal(g);

            g.Dispose();
        }

        private void setinvoiceTotal(Graphics g)
        {
            string fieldValue = "";
            string totalQuantity = this.saleCounter.ToString();
            string totalPrice = ConfigurationDAL.GetCurrentCurrency() + " " + this.saleTotalPrice.ToString(); this.saleCounter.ToString();
            
            // Draw line:
            currentY = currentY + 8;
            g.DrawLine(new Pen(Brushes.Black), leftMargin, currentY, rightMargin, currentY);

            invoiceFontHeight = (int)(invoiceFont.GetHeight(g));
            // Set Total Quantity:
            currentX = leftMargin;
            currentY =currentY + 8;
            fieldValue = "Total Quantity:     " + totalQuantity;
            g.DrawString(fieldValue, invoiceFont, blackBrush, currentX, currentY);

            // Set Total Price:
            currentX = currentX + (int)g.MeasureString(fieldValue, invoiceFont).Width + 25;
            fieldValue = "Total Price:      " + totalPrice;
            g.DrawString(fieldValue, invoiceFont, blackBrush, currentX, currentY);

        }

        private void btnSaveAndPrint_Click(object sender, EventArgs e)
        {
            try
            {
                List<Sale> saleItems = this.getListofItemsToBeAdded();
                if (saleItems.Count >= 1)
                {
                         prnDialog.Document = this.prnDocument;
                         DialogResult result = prnDialog.ShowDialog();
                         if (result == DialogResult.OK)
                         {
                             String saleDate = dateOfSale.Text;
                             invoiceID = ShopDAL.SaleItems(saleDate, saleItems);

                             prnDialog.Document.Print();

                             this.Close();
                             MessageBox.Show(this, "Item sold successfully. Collect printout from printer.", "Sale Item(s)", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }

        private void cmb_itemType_TextChanged(object sender, EventArgs e)
        {
            if (cmb_itemType.SelectedIndex <= 0)
            {
                cmb_itemType.BackColor = Color.Pink;

            }
            else
            {
                cmb_itemType.BackColor = Color.White;
            }
        }

    }
}

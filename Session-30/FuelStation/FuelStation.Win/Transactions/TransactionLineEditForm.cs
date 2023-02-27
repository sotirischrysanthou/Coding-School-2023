using DevExpress.XtraEditors;
using DevExpress.XtraScheduler.Outlook.Interop;
using FuelStation.Model.Enums;
using FuelStation.Web.Blazor.Shared;
using FuelStation.Win.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuelStation.Win.Transactions {
    public partial class TransactionLineEditForm : Form {
        private readonly List<ItemListDto> _items;
        private readonly bool _canBefuel;
        private bool _isClosingFromXButton = true;

        public ItemListDto? Item { get; set; }
        public int Quantity { get; set; }
        public decimal NetValue { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal TotalValue { get; set; }
        public decimal Price { get; set; }
        public TransactionLineEditForm(List<ItemListDto> items, ItemListDto? item, bool canBeFuel, int quantity = 1) {
            InitializeComponent();
            _items = items;
            Item = item;
            Quantity = quantity;
            _canBefuel = canBeFuel;
        }
        private void TransactionLineEditForm_Load(object sender, EventArgs e) {
            SetControlProperties();
            UpdateValues();
            numQuantity.Value = Quantity;
            cbItemType.Properties.Items.AddRange(typeof(ItemType).GetEnumValues());
        }

        private void SetControlProperties() {

            var tempItem = Item;
            bsItems.DataSource = _items;
            grdItems.DataSource = bsItems;
            Item = tempItem;
            if (Item != null) {
                txtCode.Text = Item.Code;
                Search();
            }

        }

        private void txtCode_TextChanged(object sender, EventArgs e) {
            Search();
        }

        private void Search() {
            String searchCodeTerm = (String)txtCode.EditValue;
            String searchDescriptionTerm = (String)txtDescription.EditValue;
            if (String.IsNullOrEmpty(searchCodeTerm)) { searchCodeTerm = ""; }
            if (String.IsNullOrEmpty(searchDescriptionTerm)) { searchDescriptionTerm = ""; }

            bsItems.DataSource = _items.Where(item => item.Code.StartsWith(searchCodeTerm)
                                                                &&
                                              item.Description.StartsWith(searchDescriptionTerm))
                                              .ToList();
            if (cbItemType.SelectedItem != null) {
                bsItems.DataSource = ((List<ItemListDto>)bsItems.DataSource).Where(item => item.ItemType == (ItemType)cbItemType.SelectedItem);
            }
            gridView1.RefreshData();
        }

        private void bsItems_CurrentChanged(object sender, EventArgs e) {
            UpdateValues();
        }

        private void UpdateValues() {
            Item = (ItemListDto)bsItems.Current;
            if (Item != null) {
                Price = Item.Price;
                if (Quantity == 0) {
                    NetValue = 0;
                    DiscountPercent = 0;
                    DiscountValue = 0;
                    TotalValue = 0;
                } else {
                    Price = Item.Price;
                    NetValue = Price * Quantity;
                    if (Item.ItemType == ItemType.Fuel && NetValue > 20) {
                        DiscountPercent = 10;
                    } else {
                        DiscountPercent = 0;
                    }
                    DiscountValue = NetValue * DiscountPercent / 100;
                    TotalValue = NetValue - DiscountValue;
                }
                lblPrice.Text = $"€ {Price}";
                lblNetValue.Text = $"€ {NetValue}";
                lblDiscountPercent.Text = $"{DiscountPercent}%";
                lblDiscountValue.Text = $"€ {DiscountValue}";
                lblTotalValue.Text = $"€ {TotalValue}";
            }
        }

        private void txtDescription_EditValueChanged(object sender, EventArgs e) {
            Search();
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e) {
            Quantity = (int)numQuantity.Value;
            UpdateValues();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            _isClosingFromXButton = false;
            bool flag = true;
            if (Item is null) {
                XtraMessageBox.Show("Please select valid Item");
                return;
            }
            if (Quantity < 1) {
                XtraMessageBox.Show("Quantity must be [1 - 99]");
                flag = false;
            }
            if (!_canBefuel && Item.ItemType == ItemType.Fuel) {
                XtraMessageBox.Show("Can not add more than 1 fuel Items");
                flag = false;
            }
            if (flag) {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            _isClosingFromXButton = false;
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            if (_isClosingFromXButton && e.CloseReason == CloseReason.UserClosing) {
                this.DialogResult = DialogResult.Continue;
            }
        }

        private void cbItemType_SelectedIndexChanged(object sender, EventArgs e) {
            Search();
        }
    }
}

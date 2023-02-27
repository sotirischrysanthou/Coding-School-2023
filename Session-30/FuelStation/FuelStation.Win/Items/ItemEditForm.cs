using DevExpress.XtraEditors;
using DevExpress.XtraReports.Serialization;
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

namespace FuelStation.Win.Items {
    public partial class ItemEditForm : Form {
        // Properties
        private readonly List<ItemListDto> _items;
        private readonly ItemListDto? _item;
        private bool _isClosingFromXButton = true;

        public String Code { get; set; } = null!;
        public String Description { get; set; } = null!;
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public ItemType ItemType { get; set; }

        // Constructors
        public ItemEditForm(List<ItemListDto> items, ItemListDto? item = null) {
            InitializeComponent();
            _items = items;
            _item = item;
        }

        // Methods
        private void ItemEditForm_Load(object sender, EventArgs e) {
            cbItemType.Properties.Items.AddRange(typeof(ItemType).GetEnumValues());
            if (_item != null) {
                txtCode.Text = _item.Code;
                txtDecription.Text = _item.Description;
                numCost.Value = _item.Cost;
                numPrice.Value = _item.Price;
                cbItemType.SelectedItem = _item.ItemType;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            _isClosingFromXButton = false;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            _isClosingFromXButton = false;
            bool flag = true;
            if (String.IsNullOrEmpty(txtCode.Text)) {
                XtraMessageBox.Show("Please enter code");
                flag = false;
            } else if (_items.FirstOrDefault(i => i.Code == txtCode.Text && (_item is not null ? i.Id != _item.Id : true)) != null) {
                XtraMessageBox.Show($"Code must be unique among the items.\n" +
                                    $"Code {txtCode.Text} is already taken by another item\n\n" +
                                    $"Suggestions:\n" +
                                    $"------------\n" +
                                    $"   1. Select another Code\n" +
                                    $"   2. Edit first the item with code {txtCode.Text}\n" +
                                    $"      and the add a new with this code");

                flag = false;
            }
            if (String.IsNullOrEmpty(txtDecription.Text)) {
                XtraMessageBox.Show("Please enter description");
                flag = false;
            }
            if (numPrice.Value <= 0 || numCost.Value < 0) {
                XtraMessageBox.Show("Price and cost can not have negative values");
                flag = false;
            }
            if (cbItemType.SelectedItem == null) {
                XtraMessageBox.Show("Please select type");
                flag = false;
            } else if (flag) {
                Code = txtCode.Text;
                Description = txtDecription.Text;
                Cost = numCost.Value;
                Price = numPrice.Value;
                ItemType = (ItemType)cbItemType.SelectedItem;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e) {
            base.OnFormClosing(e);
            if (_isClosingFromXButton && e.CloseReason == CloseReason.UserClosing) {
                this.DialogResult = DialogResult.Continue;
            }
        }
    }
}

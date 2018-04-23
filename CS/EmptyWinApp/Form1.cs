using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Data;

namespace EmptyWinApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            this.productReportsTableAdapter.Fill(this.productReports._ProductReports);
        }
        private void pivotGridControl1_CustomFilterPopupItems(object sender, 
                                                        PivotCustomFilterPopupItemsEventArgs e) {

            // Fetches and sorts visible values of the current field.
            List<object> values = e.Field.GetVisibleValues();
            values.Sort();

            // Checks whether the filter drop-down customization logic differs
            // depending on the currently selected filter type.
            // If so, the filter type decides which filter items
            // will be hidden.
            bool? removingCriteria;
            if (((PivotGridControl)sender).OptionsFilterPopup.AllowFilterTypeChanging == false)
                removingCriteria = true;
            else
                removingCriteria =  e.Field.FilterValues.FilterType != PivotFilterType.Excluded;
            
            // Hides filter items that are not currently visible
            // due to the filtering applied.
            for(int i = e.Items.Count - 1; i >= 0; i--) {
                if (e.Items[i].IsChecked == removingCriteria && 
                                values.BinarySearch(e.Items[i].Value) < 0)
                    e.Items.RemoveAt(i);                
            }
        }
    }
}
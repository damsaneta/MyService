using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WfaServer.Model;

namespace WfaServer
{
    public partial class MainForm : Form
    {
        private static readonly IList<Promotion> Promotions = new List<Promotion>();
        private readonly BindingSource bindingSource;
        private Promotion current;

        public MainForm()
        {
            InitializeComponent();
            Promotions.Add(new Promotion() {Name = "Foo", MinimalCount = 7});
            this.bindingSource = new BindingSource(Promotions, "");
            this.dgv.DataSource = this.bindingSource;
            this.dgv.Columns["Id"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddForm();
            var result = addForm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var toAdd = addForm.Model;
                Promotions.Add(toAdd);
                this.bindingSource.ResetBindings(false);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgv.CurrentRow.Index == -1)
            {
                this.btnCancel.Enabled = false;
            }
            else
            {
                var currentPromotion = Promotions[this.dgv.CurrentRow.Index];
                this.btnCancel.Enabled = true;
            }

        }
    }
}

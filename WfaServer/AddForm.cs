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
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
   
        }

        public Promotion Model { get; set; }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Model = new Promotion
            {
                Id = Guid.NewGuid(),
                Name = this.txbName.Text,
                MinimalCount = (int) this.nudMinimalCount.Value
            };
        }
    }
}

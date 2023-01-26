using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session_11_Car_Service_Center {
    public partial class LogIn : Form {
        public LogIn() {
            InitializeComponent();
        }

        public bool LogedIn() {
            return true;
        }

        private void btnLogIn_Click(object sender, EventArgs e) {
            string  username = txtUsername.Text;

        }
    }
}

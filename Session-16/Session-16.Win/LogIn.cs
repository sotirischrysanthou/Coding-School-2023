using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session_16.Win {
    public partial class LogIn : Form {
        public LogIn() {
            InitializeComponent();
        }

        public bool LogedIn() {
            return true;
        }

        private void btnLogIn_Click(object sender, EventArgs e) {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == "admin" && password == "admin") {
                MessageBox.Show("Successful Admin Login");
                MainMenuForm mainMenuForm = new MainMenuForm();
                this.Hide();
                mainMenuForm.ShowDialog();
                this.Close();
            } else if (username == "user" && password == "user") {
                MessageBox.Show("Successful User Login");
            } else {
                MessageBox.Show("ERROR: Incorrect username or password.");
            }
        }
    }
}
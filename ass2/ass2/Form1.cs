using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ass2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadDB();
        }

        List<Customer> CustomerDB = new List<Customer>();


        public void LoadDB()
        {
            CustomerDB.Add(new Customer("Jim", "Smith", "346-2514"));
            CustomerDB.Add(new Customer("Jo", "Baker", "346-1263"));
            CustomerDB.Add(new Customer("Aimee", "Ellery", "346-3658"));
            CustomerDB.Add(new Customer("Sam", "Herewini", "346-9898"));
        }

        public void ClearDisplay()
        {
            ListBoxDB.Items.Clear();
        }
        public void DisplayCustomers()
        {
            foreach (Customer x in CustomerDB)
            {
                ListBoxDB.Items.Add(x.GetCustomer());
            }            
        }

        //Search button click event
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchName = textBoxSearch.Text;
            textBoxSearch.Clear();

            foreach (Customer x in CustomerDB)
            {
                if (x.FName == searchName)
                {
                    ListBoxDB.Items.Add(x.GetCustomer());
                }
                else if (x.LName == searchName)
                {
                    ListBoxDB.Items.Add(x.GetCustomer());
                }
                else if (x.Phone == searchName)
                {
                    ListBoxDB.Items.Add(x.GetCustomer());
                }
            }
                   
            

        }
        //List customers click event
        private void btnListCustomers_Click(object sender, EventArgs e)
        {
            ClearDisplay();
            DisplayCustomers();
        }
        //Clear list click event
        private void btnClearList_Click(object sender, EventArgs e)
        {
            ClearDisplay();
            btnSearch.Focus();
        }

    }
}

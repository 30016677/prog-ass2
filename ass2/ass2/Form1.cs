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
        int indexDB;

        //Add customers to the Customer DB
        public void LoadDB()
        {
            CustomerDB.Add(new Customer("Jim", "Smith", "346-2514"));
            CustomerDB.Add(new Customer("Jo", "Baker", "346-1263"));
            CustomerDB.Add(new Customer("Aimee", "Ellery", "346-3658"));
            CustomerDB.Add(new Customer("Sam", "Herewini", "346-9898"));
        }
        //Clear the input textboxes
        public void ClearBoxes()
        {
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxPhone.Clear();
        }
        //clear the output list box
        public void ClearDisplay()
        {
            ListBoxDB.Items.Clear();
        }
        //populate the list box with the customers from the customer DB
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
            bool found = false;

            foreach (Customer x in CustomerDB)
            {
                if (x.FName == searchName)
                {
                    ListBoxDB.Items.Add(x.GetCustomer());
                    found = true;
                }
                else if (x.LName == searchName)
                {
                    ListBoxDB.Items.Add(x.GetCustomer());
                    found = true;
                }
                else if (x.Phone == searchName)
                {
                    ListBoxDB.Items.Add(x.GetCustomer());
                    found = true;
                }    
            }
            if (found == false)
            {
                MessageBox.Show("Customer not found, please try again", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxSearch.Focus();
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
            btnAdd.Enabled = true;
        }
        //Clear text boxes click event
        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearBoxes();
        }



        //List Box item selected
        private void ListBoxDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //disable Add button
            btnAdd.Enabled = false; 

            //split list item into array
            string[] splitListItems = (ListBoxDB.SelectedItem.ToString()).Split('\t');

            //populate textboxes with the split list item
            textBoxFirstName.Text = splitListItems[0];
            textBoxLastName.Text = splitListItems[1];
            textBoxPhone.Text = splitListItems[2];

            indexDB = ListBoxDB.SelectedIndex;


        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (indexDB != -1)
            {
                if (textBoxFirstName.Text == "" || textBoxLastName.Text == "" || textBoxPhone.Text == "")
                {
                    MessageBox.Show("All textboxes must be filled to continue");
                }
                else
                {
                    CustomerDB.RemoveAt(indexDB);
                    CustomerDB.Add(new Customer(textBoxFirstName.Text, textBoxLastName.Text, textBoxPhone.Text));                    
                    ClearDisplay();
                    DisplayCustomers();
                    MessageBox.Show("Customer details updated");
                    btnAdd.Enabled = true;
                }


            }
            else
            {
                MessageBox.Show("Please select a customer to update.");
            }
            
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (textBoxFirstName.Text == "" || textBoxLastName.Text == "" || textBoxPhone.Text == "")
            {
                MessageBox.Show("All textboxes must be filled to continue");
            }
            else
            {
                
                CustomerDB.Add(new Customer(textBoxFirstName.Text, textBoxLastName.Text, textBoxPhone.Text));
                ClearDisplay();
                DisplayCustomers();
                MessageBox.Show("New customer has been added");
                btnAdd.Enabled = true;
            }
        }
    }
}

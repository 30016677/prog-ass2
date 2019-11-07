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
        //Kris Boyte 30016677
        public Form1()
        {
            InitializeComponent();
            LoadDB();
        }

        List<Customer> CustomerDB = new List<Customer>();        

        //Add customers to the Customer DB
        public void LoadDB()
        {
            CustomerDB.Add(new Customer("Jim", "Smith", "346-2514"));
            CustomerDB.Add(new Customer("Jo", "Baker", "346-1263"));
            CustomerDB.Add(new Customer("Aimee", "Ellery", "346-3658"));
            CustomerDB.Add(new Customer("Sam", "Herewini", "346-9898"));
        }
        //Clear the textboxes
        public void ClearBoxes()
        {
            textBoxFirstName.Clear();
            textBoxLastName.Clear();
            textBoxPhone.Clear();
        }
        //clear the listbox
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
            if (textBoxSearch.Text == "")
            {
                MessageBox.Show("You must enter a customer name.");
                textBoxSearch.Focus();
            }
            else
            {
                string searchName = textBoxSearch.Text;
                textBoxSearch.Clear();
                bool found = false;
                ClearDisplay();

                foreach (Customer x in CustomerDB)
                {
                    if (x.FName == searchName || x.LName == searchName || x.Phone == searchName)
                    {
                        ListBoxDB.Items.Add(x.GetCustomer());
                        found = true;
                    }
                }
                if (found == false)
                {
                    MessageBox.Show("Customer not found, please try again");
                    textBoxSearch.Focus();

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
            textBoxSearch.Focus();
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

            //Assign index to integer variable because the marking schedule says so?
            int DBIndex = ListBoxDB.SelectedIndex;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (ListBoxDB.SelectedIndex >= 0) //if customer is selected
            {
                if (textBoxFirstName.Text == "" || textBoxLastName.Text == "" || textBoxPhone.Text == "")
                {
                    MessageBox.Show("All textboxes must be filled to continue");
                }
                else
                {
                    CustomerDB.RemoveAt(ListBoxDB.SelectedIndex); //delete selected customer
                    CustomerDB.Add(new Customer(textBoxFirstName.Text, textBoxLastName.Text, textBoxPhone.Text));  //add updated customer                   
                    ClearDisplay();
                    DisplayCustomers();
                    MessageBox.Show("Customer details updated");
                    ClearBoxes();
                    btnAdd.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to update.");
            }            
        }
        //Add button click event
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
                ClearBoxes();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (ListBoxDB.SelectedIndex >= 0)
            {
                DialogResult yesno = MessageBox.Show("Are you sure you want to delete this customer?", "Warning", MessageBoxButtons.YesNo);
                if (yesno == DialogResult.Yes)
                {
                    CustomerDB.RemoveAt(ListBoxDB.SelectedIndex);
                    ClearBoxes();
                    ClearDisplay();
                    DisplayCustomers();
                    MessageBox.Show("The customer has been deleted.");
                    btnAdd.Enabled = true;
                    ListBoxDB.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Operation cancelled");
                }


            }
            else
            {
                MessageBox.Show("Please select a customer to delete.");
                
            }
        }
    }
}

//Estimated Time: 3 hours
//Actual Time: 6 hours.  I did have some complications getting the HIPPA form done, but that wasn't part of the module, necessarily.
//I also had some issues getting the pages to close or hide when I ran the code. I did try to both hide and close methods. To prevent
//this large amount of time difference could have been resolved if I had planned more time into the planning step. 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //create the form from the path specified on the HIPPA_FORM
            HIPPA_Form hIPPA_Form = new HIPPA_Form();

            //I had to specify the path to the form again
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HIPPA_Comp.txt");

            //Calling the text to display on the filepath through from the HIPPA Form
            //this part was difficult.  I started getting confused about my nameing conventions with HIPPA_Form and "hIPPA_FORM"
            hIPPA_Form.HIPPATxtFile(filepath);

            //Now to show the Dialog
            hIPPA_Form.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        //the random password involved the use of a random string. Though I attemped on my own
        //I was unsuccessful.  I've implemented code found on the following reference:
        //Chand, M. (n.d.). How to generate random password in C#? C# Corner - Community of Software and Data Developers.
        //   https://www.c-sharpcorner.com/article/how-to-generate-a-random-password-in-c-sharp-and-net-core/#:~:text=A%20random%20password%20can%20simply,two%20methods%20%2D%20RandomNumbe
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public String RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char rd;
            for (int i = 0; i < size; i++)
            {
                rd = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(rd);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        //Function to create a random password
        private String RandomPassword(int size = 3)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(RandomString(2, false));
            sb.Append(RandomNumber(10, 99));
            sb.Append(RandomString(1, true));
            return sb.ToString();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            String passButton = RandomPassword(10);
            textBox8.Text = passButton;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Declare form variables to be added to the .txt and the path to the userData.txt file (/bin)
            string firstName = textBox1.Text;
            string middleName = textBox2.Text;
            string lastName = textBox3.Text;
            string DOB = maskedTextBox1.Text;
            string userName = textBox5.Text;
            string phone = textBox6.Text;
            string email = textBox7.Text;
            string password = textBox8.Text;
            string sex = comboBox1.Text;
            string filePath = "userData.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("First Name: " + firstName);
                    writer.WriteLine("Middle Name: " + middleName);
                    writer.WriteLine("Last Name: " + lastName);
                    writer.WriteLine("DOB : " + DOB);
                    writer.WriteLine("userName: " + userName);
                    writer.WriteLine("phone: " + phone);
                    writer.WriteLine("email: " + email);
                    writer.WriteLine("password: " + password);
                    writer.WriteLine("email: " + email);
                    writer.WriteLine("sex: " + sex);
                    writer.WriteLine("-----------------new UserControl -------------- -");
                }
                MessageBox.Show("Congratulations, you are now registered");

                //This checkbox is setting a requirement for HIPPA to be approved
                if (checkBox1.Checked)
                {
                    MessageBox.Show("Thank you for registering.  You will be redirected back to the login page");
                    Form2 loginForm = new Form2(medCon);


                    loginForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("You must acknowledge HIPPA");
                }
            }
            catch
            {
                MessageBox.Show("Sorry, but an error has occurred. You will be returned to the Login Page");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //had to add the medCon list for form 2 to recieve from form 3
            Form2 form2 = new Form2(medCon);
            form2.Show();
            this.Close();

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        //created a string list to collect medical conditions added to for the user
        List<string> medCon = new List<string>();
        private void button4_Click(object sender, EventArgs e)
        {
            //the textbox that we are referencing to add to the list
            string condition = textBox9.Text;

            //adding the textbox to the list if not null
            if (!string.IsNullOrEmpty(condition))
            {
                medCon.Add(condition);
                //Sting Function Join the Environment with a new line for each item in "medCon"
                //I have to update the listbox, or there won't be anything for the user to update
                UpdateListBox();
                textBox9.Clear();
            }
            else
            {
                MessageBox.Show("Please enter your specific medical condition before pressing add button");
            }

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }


        //Clicking on this button will allow you to edit the list box of conditions
        private void button5_Click(object sender, EventArgs e)
        {


            //I have to declare the index from the list box. By clarifying that the paramenters cannot see
            //any index below "0", we must specify that index cannot go reach (-1) or below
            if (listBox1.SelectedIndex != -1)
            {
                int SelectedIndex = listBox1.SelectedIndex;

                //must create a variable for the new condition the user wants to input
                string newCondition = textBox10.Text;
                if (!string.IsNullOrEmpty(newCondition))
                {
                    //update the selected item from the medCon list
                    medCon[SelectedIndex] = newCondition;

                    //refresh the box to show the update using the UpdateListBox method Created
                    UpdateListBox();

                    MessageBox.Show("You have updated your Medical Conditions List");
                }
                else
                {
                    MessageBox.Show("Please update your Medical Considtion List or cancel");
                }
            }
            else
            {
                MessageBox.Show("Please select a condition to edit");
            }
        }
        //Custom method for updating the list box
        private void UpdateListBox()
        {
            listBox1.Items.Clear();
            foreach (string condition in medCon)
            {
                listBox1.Items.Add(condition);
            }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Check if an item is selected in the listBox
            if (listBox1.SelectedItem != null)
            {
                // Get the selected condition
                string selectedCondition = listBox1.SelectedItem.ToString();

                // Remove the selected item from the ListBox
                listBox1.Items.Remove(selectedCondition);

                // Remove the selected condition from the medCon list
                medCon.Remove(selectedCondition);
            }
            else
            {
                MessageBox.Show("Please select a condition to delete.");
            }

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            //Update with IF statements and validations
  
            
        }
    }
}

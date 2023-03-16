namespace Organizer
{
    public partial class AuthForm : Form
    {
        const String login = "admin";
        const String password = "admin";
        public AuthForm()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String tmpLogin = textBox1.Text.Trim();
            String tmpPassword = textBox2.Text.Trim();
            if (!tmpLogin.Equals(login) || !tmpPassword.Equals(password))
                MessageBox.Show("Данные аккаунта не верны!");
            else
            {
                MessageBox.Show("Данные введены правильно!");
                OrganizerForm organizerForm= new OrganizerForm();
                organizerForm.Show();
                this.Hide();
            }
            

            
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            Boolean isShowPassword = checkBox1.Checked;
            textBox2.PasswordChar = !isShowPassword ? '*' : '\0';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ну и ливай", "Прощальный", MessageBoxButtons.OK)==DialogResult.OK)
            {
                Close();
            }
            
        }
    }
}
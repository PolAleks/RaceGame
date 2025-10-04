namespace Race
{
    public partial class WelcomForm : Form
    {
        public string Name { get; private set; }
        public WelcomForm()
        {
            InitializeComponent();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            Name = textBoxNameValue.Text;
            if (string.IsNullOrEmpty(Name))
            {
                MessageBox.Show("Вы не ввели свое имя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void TextBoxNameValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ButtonStart_Click(sender, e);
            }
        }
    }
}

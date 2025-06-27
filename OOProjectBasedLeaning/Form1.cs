namespace OOProjectBasedLeaning
{

    public partial class Form1 : Form
    {

        public Form1()
        {

            InitializeComponent();

            // ]‹Æˆõ‚Ìì¬
            new EmployeeCreatorForm().Show();

            // ‰Æ
            new HomeForm().Show();

            // ‰ïĞ
            new CompanyForm().Show();

            //Form1‚ğ‰B‚·
            this.WindowState = FormWindowState.Minimized;

        }

    }

}

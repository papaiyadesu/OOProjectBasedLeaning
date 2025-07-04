using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OOProjectBasedLeaning
{

    public class EmployeePanel : DragDropPanel
    {

        private Employee employee;

        public EmployeePanel(Employee employee)
        {

            this.employee = employee;

            InitializeComponent();

        }

        private void InitializeComponent()
        {
            // 従業員の状態ラベルを作成
            EmployeeStatusLabel employeeStatusLabel = new EmployeeStatusLabel(employee)
            {

                Location = new Point(20, 10),

            };

            Label employeeNameLabel = new Label
            {
                Text = employee.Name,
                AutoSize = true,
                Location = new Point(20, 30)
            };

            TextBox employeeNameTextBox = new TextBox
            {
                Text = employee.Name,
                Location = new Point(130, 26),

                Width = 160
            };

            //パネルの色と大きさ
            this.BackColor = Color.LightGreen;
            this.Size = new Size(100, 50);

            Controls.Add(employeeStatusLabel);
            Controls.Add(employeeNameLabel);
            Controls.Add(employeeNameTextBox);


            // テキストボックスの変更イベントを登録
            employeeNameTextBox.TextChanged += (sender, e) =>
            {
                employee.Name = employeeNameTextBox.Text;
                employeeNameLabel.Text = employee.Name;
            };
        }

        protected override void OnPanelMouseDown()
        {
            DoDragDropMove();

            if (GetForm() is not EmployeeCreatorForm)
            {

                // 従業員名のテキストボックスを編集不可にして非表示にする
                //employeeNameTextBox.ReadOnly = true;
                //employeeNameTextBox.Hide();

                try
                {

                    if (GetForm() is CompanyForm)
                    {

                        // 会社フォームにドロップされた場合、「出勤」する
                        employee.Go2Company().ClockIn();

                    }
                    else if (GetForm() is HomeForm)
                    {

                        // ホームフォームにドロップされた場合、「退勤」する
                        employee.ClockOut();

                        // 従業員が帰宅する
                        employee.Go2Home();

                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            else
            {

                // 従業員名のテキストボックスを編集可能にして表示する
                //employeeNameTextBox.ReadOnly = false;
                //employeeNameTextBox.Show();

            }



            //if (GetForm() is HomeForm)
            //{
            //    employee.Name = "帰宅";
            //}
            //else
            //{
            //    employee.Name = "Drop at " + DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]");
            //}
        }

        public void AddCompany(Company company)
        {

            employee.AddCompany(company);

        }

        public void RemoveCompany()
        {

            employee.RemoveCompany();

        }


        //public void AddHome(Home home)
        //{

        //    employee.AddHome(home);

        //}

        //public void RemoveHome()
        //{

        //    employee.RemoveHome();

        //}
    }
}

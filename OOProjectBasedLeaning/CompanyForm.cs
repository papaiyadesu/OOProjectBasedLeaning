using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOProjectBasedLeaning
{

    public partial class CompanyForm : DragDropForm
    {

        private Company company = NullCompany.Instance;
        int countY = 10;
        private Label employeeNamesLabel;

        public CompanyForm()
        {

            InitializeComponent();
            //表示位置の指定
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(557, 10);

            company = new CompanyModel("MyCompany");

            // TODO: タイムレコーダーのパネルを設置する
            new TimeTrackerModel(company);

            //従業員一覧ラベル追加
            employeeNamesLabel = new Label
            {

                Location = new Point(20, 20),
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Regular),

            };
            Controls.Add(employeeNamesLabel);

            UpdateDisplay();

        }

        protected override void OnFormDragEnterSerializable(DragEventArgs dragEventArgs)
        {

            dragEventArgs.Effect = DragDropEffects.Move;

        }

        protected override void OnFormDragDropSerializable(object? serializableObject, DragEventArgs dragEventArgs)
        {

            if (serializableObject is DragDropPanel)
            {

                (serializableObject as DragDropPanel).AddDragDropForm(this, PointToClient(new Point(dragEventArgs.X, dragEventArgs.Y)));

                //// 左上から順に並べる
                //int fixedX = 10;
                //int fixedY = countY;

                //// 位置を取得と次の位置の指定
                //Point dropPoint = new Point(fixedX, fixedY);

                //countY += 50;

                //(serializableObject as DragDropPanel).AddDragDropForm(this, dropPoint);

            }

        }

        private void UpdateDisplay()
        {

            StringBuilder employeeNames = new StringBuilder();
            company.Employees().ForEach(employee =>
            {

                employeeNames.Append(employee.Name);
                employeeNames.Append("\n");

            });

            employeeNamesLabel.Text = employeeNames.ToString();

        }

    }

}

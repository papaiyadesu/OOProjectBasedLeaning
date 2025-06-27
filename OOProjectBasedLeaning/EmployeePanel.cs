﻿using System;
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

            TextBox guestNameTextBox = new TextBox
            {
                Text = employee.Name,
                Location = new Point(140, 26),

                Width = 160
            };

            Controls.Add(employeeStatusLabel);
            Controls.Add(employeeNameLabel);
            Controls.Add(guestNameTextBox);

        }

        protected override void OnPanelMouseDown()
        {
            DoDragDropMove();

            if (GetForm() is HomeForm)
            {
                employee.Name = "帰宅";
            }
            else
            {
                employee.Name = "Drop at " + DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss]");
            }
           

        }
    }

}

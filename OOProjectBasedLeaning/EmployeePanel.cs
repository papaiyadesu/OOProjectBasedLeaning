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

            Label employeeNameLabel = new Label
            {
                Text = employee.Name,
                AutoSize = true,
                Location = new Point(20, 10)
            };

            TextBox guestNameTextBox = new TextBox
            {
                Text = employee.Name,
                Location = new Point(140, 6),
                Width = 160
            };

            //パネルの色と大きさ
            this.BackColor = Color.LightGreen;
            this.Size = new Size(100, 30);

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

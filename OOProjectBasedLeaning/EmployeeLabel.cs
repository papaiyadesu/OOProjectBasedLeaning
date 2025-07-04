using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OOProjectBasedLeaning
{
    public class EmployeeStatusLabel : Label, Observer
    {

        private Employee employee = NullEmployee.Instance;

        public EmployeeStatusLabel()
        {

            InitializeComponent();

        }
        public EmployeeStatusLabel(Employee employee)
        {

            if (employee is NotifierModelEntity)
            {

                (employee as NotifierModelEntity).AddObserver(this);

            }

            this.employee = employee;

            InitializeComponent();

        }

        private void InitializeComponent()
        {

            this.AutoSize = true;
            this.Font = new System.Drawing.Font("Arial", 10, FontStyle.Regular);

            Update(this);

        }

        public void Update(object sender)
        {

            if (employee.IsAtWork())
            {

                Text = "勤務中";
                ForeColor = Color.Red;

            }
            else if (employee.IsAtHome())
            {

                Text = "帰宅中";
                ForeColor = Color.Blue;

            }
            else
            {

                Text = "－－－";
                ForeColor = Color.Gray;

            }

        }

    }
}

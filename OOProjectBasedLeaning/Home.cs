using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOProjectBasedLeaning
{
    public interface Home : Model,Place
    {
        Home AddEmployee(Employee employee);

        Home RemoveEmployee(Employee employee);
    }


    public class NullHome : ModelEntity, Home, NullObject
    {

        private static readonly Home instance = new NullHome();

        private NullHome()
        {

        }

        public override string Name
        {

            get { return string.Empty; }
            set { /* Do nothing */ }

        }

        public static Home Instance
        {
            get { return instance; }
        }

        public Home AddEmployee(Employee employee)
        {

            return this;

        }

        public Home RemoveEmployee(Employee employee)
        {

            return this;

        }

    }
}

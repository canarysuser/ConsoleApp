using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Employee
    {
        #region Fields 
        private int _id; 
        private string _name;
        private double _salary;
        private DateTime _hireDate;
        #endregion

        #region Constructors
        public Employee(int id, string name, double salary, DateTime hiredate)
        {
            _id = id;
            _name = name;
            _salary = salary;
            _hireDate = hiredate;
        }
        public Employee()
        {
            _name = "Unassigned";
            _hireDate= DateTime.Now;
        }

        #endregion


        #region Properties 
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public double Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
        public DateTime HireDate
        {
            get { return _hireDate; }
            set { _hireDate = value; }
        }
        public string Address { get; set; }

        #endregion

        #region Methods 
        public void Show()
        {
            //using System.Text namespace 
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Employee Details")
                .AppendLine($"ID: {_id}\tName: {_name}")
                .AppendLine($"Salary: {_salary}\tHire Date: {_hireDate}")
                .AppendLine($"{"".PadLeft(45, '=')}");
            Console.WriteLine(sb.ToString());
        }
        #endregion


    }



    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1
{
    class CaptureData
    {
        private string name;
        private string status;
        private int yearsjob;
        private int yearsresidence;
        private int children;
        private float salary;
        private float debt;

        public CaptureData(string name, string status, int yearsjob, int yearsresidence, int children, float salary, float debt)
        {
            this.Name = name;
            this.Status = status;
            this.Yearsjob = yearsjob;
            this.Yearsresidence = yearsresidence;
            this.Children = children;
            this.Salary = salary;
            this.Debt = debt;
        }

        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
        public int Yearsjob { get => yearsjob; set => yearsjob = value; }
        public int Yearsresidence { get => yearsresidence; set => yearsresidence = value; }
        public int Children { get => children; set => children = value; }
        public float Salary { get => salary; set => salary = value; }
        public float Debt { get => debt; set => debt = value; }
    }
}

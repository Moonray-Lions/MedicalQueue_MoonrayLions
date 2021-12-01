using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalQueue_MoonrayLions
{
    class Patient
    {
        private string _name;
        private int _priority;
        private Patient _next;
        private Patient _previous;
        public Patient(string name, int priority)
        {
            _name = name;
            _priority = priority;
        }
        public Patient Next
        {
            get { return _next; }
            set { _next = value; }
        }
        public Patient Previous
        {
            get { return _previous; }
            set { _previous = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }
    }
}

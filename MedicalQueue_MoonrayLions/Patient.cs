using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalQueue_MoonrayLions
{
    class Patient
    {
        private string _firstName;
        private string _lastName;
        private int _priority;
        private Patient _next;
        private Patient _previous;
        public Patient(string first, string last, int priority)
        {
            _firstName = first;
            _lastName = last;
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
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public int Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }
    }
}

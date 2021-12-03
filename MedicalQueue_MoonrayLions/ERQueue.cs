using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalQueue_MoonrayLions
{
    class ERQueue
    {
        private Patient _head = null;
        private Patient _tail = null;
        private int _count = 0;

        // ADD PRIORITY LOGIC IN ADD() !!!
        public int Enqueue(Patient newPatient)
        {
            _count++;

            // EDGE CASE: ER QUEUE IS EMPTY
            if (_head == null)
            {
                _head = newPatient;
                _tail = newPatient;
                return _count;
            } 
            Patient current = _head;

            // FIND END OF QUEUE, ADD PATIENT THERE
            while (current != null)
            {
                Patient next = current.Next;

                //handle new head
                if (newPatient.Priority.CompareTo(current.Priority) > 0)
                {
                    Patient temp = newPatient;
                    temp.Next = _head;
                    _head = temp;
                    return _count;
                }

                // insert in the middle
                else if (newPatient.Priority.CompareTo(current.Priority) < 0 && 
                    newPatient.Priority.CompareTo(next.Priority) >= 0)
                {
                    current.Next = newPatient;
                    current.Next.Previous = current;
                    current.Next.Next = next;
                    next.Previous = current.Next;
                    return _count;
                }

                ////handle null tail
                //else if (next == null)
                //{
                //    _tail.Previous = current;
                //    _tail.Next = newPatient;
                //    _tail.Next.Previous = _tail;
                //    _tail = _tail.Next;
                //    return _count;
                //}

                else
                {
                    current = current.Next;
                }
            };
            return _count;
        }

        // CHANGE METHOD TO GRAB PATIENT AT TAIL OF ER QUEUE
        //public Patient Dequeue()
        //{
        //    // EDGE CASE: NO PATIENTS
        //    if (_head == null)
        //        return null;


        //    // EDGE CASE: ONLY ITEM IN LIST
        //    if (_head == _tail)
        //    {
        //        return _tail;
        //    }


        //    Patient current = _head;


        //    while (current.Next != null)
        //    { // INSTEAD OF STORING "PREVIOUS PATIENT", DECIDED TO LOOK 2 SPOTS AHEAD IN LIST FROM CURRENT
        //        if (current.Next.Name.ToLower() == item.ToLower() && current.Next.Next == null)
        //        { // EDGE CASE: SEARCHED PATIENT IS LAST IN LIST
        //            current.Next = null;
        //            return head;
        //        }
        //        else if (current.Next.Name.ToLower() == item.ToLower())
        //        { // ELSE: EXAMPLE LIST - "1 "2" "3" / LINK "1" TO "3"
        //            current.Next = current.Next.Next;
        //            return head;
        //        }
        //        else
        //            current = current.Next;
        //    };
        //    return head; // THIS SHOULD NEVER FIRE
        //}

        public string List()
        { // EDGE CASE: LINKED LIST IS EMPTY
            if (_head == null)
                return "ALERT: ER QUEUE IS EMPTY";

            Patient current = _head;
            string patients = $"{current.Priority}: {current.LastName}, {current.FirstName}";

            while (current.Next != null)
            {
                current = current.Next;
                patients += $"\n{current.Priority}: {current.LastName}, {current.FirstName}";
            }
            return patients;
        }
        public override string ToString()
        {
            return List();
        }
    }
}

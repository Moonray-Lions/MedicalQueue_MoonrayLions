namespace MedicalQueue_MoonrayLions
{
    class ERQueue
    {
        private Patient _head = null;
        private Patient _tail = null;
        private int _count = 0;

        public int Enqueue(Patient newPatient)
        {
            _count++;
            Patient current = _head;

            // HEAD LOGIC -----------------------------------------------------
            if (_head == null) // ER QUEUE IS EMPTY
            {
                _head = newPatient;
                _tail = newPatient;
                return _count;
            } 
            else if (_head == _tail) // ONLY 1 IN QUEUE
            {
                if (newPatient.Priority >= _head.Priority)
                {
                    _head = newPatient;
                    _head.Next = _tail;
                    _tail.Previous = _head;
                    return _count;
                }
                else
                {
                    _tail = newPatient;
                    _head.Next = _tail;
                    _tail.Previous = _head;
                    return _count;
                }
            }
            // MIDDLE LOGIC ---------------------------------------------------
            while (current.Next != null)
            {
                if (newPatient.Priority >= current.Priority &&
                    current == _head) 
                    // IF NEW PATIENT >= HEAD, ASSIGN TO HEAD
                {
                    _head = newPatient;
                    _head.Next = current;
                    current.Previous = _head;
                    return _count;
                }
                else if (newPatient.Priority >= current.Priority)
                    // NEW PATIENT PRIORITY >= PATIENT IN LIST (!REACHING TAIL)
                {
                    current.Previous.Next = newPatient;
                    newPatient.Next = current;
                    newPatient.Previous = current.Previous;
                    current.Previous = newPatient;
                    return _count;
                }
                current = current.Next;
            }
            // TAIL LOGIC -----------------------------------------------------
            if (newPatient.Priority >= current.Priority) 
                // NEW PATIENT PRIORITY >= TAIL: PLEACE BEFORE TAIL
            {
                newPatient.Next = current;
                newPatient.Previous = current.Previous;
                current.Previous = newPatient;
                return _count;
            }
            else
            // PLACE AT END OF LIST & ASSIGN TO TAIL
            {
                current.Next = newPatient;
                newPatient.Previous = current;
                _tail = newPatient;
                return _count;
            }

            //// FIND END OF QUEUE, ADD PATIENT THERE
            //while (current != null)
            //{
            //    Patient next = current.Next;

            //    //handle new head
            //    if (newPatient.Priority.CompareTo(current.Priority) > 0)
            //    {
            //        Patient temp = newPatient;
            //        temp.Next = _head;
            //        _head = temp;
            //        return _count;
            //    }

            //    // insert in the middle
            //    else if (newPatient.Priority.CompareTo(current.Priority) < 0 && 
            //        newPatient.Priority.CompareTo(next.Priority) >= 0)
            //    {
            //        current.Next = newPatient;
            //        current.Next.Previous = current;
            //        current.Next.Next = next;
            //        next.Previous = current.Next;
            //        return _count;
            //    }

            //    ////handle null tail
            //    //else if (next == null)
            //    //{
            //    //    _tail.Previous = current;
            //    //    _tail.Next = newPatient;
            //    //    _tail.Next.Previous = _tail;
            //    //    _tail = _tail.Next;
            //    //    return _count;
            //    //}

            //    else
            //    {
            //        current = current.Next;
            //    }
            //};
        }
        public Patient Dequeue()
        {
            if (_head == null) // NO PATIENTS IN QUEUE
            {
                return null;
            }

            _count--;
            Patient temp = _tail;

            if (_tail == _head) // 1 PATIENT IN QUEUE
            {
                _head = null;
                _tail = null;
                return temp;
            }
            else
            {
                _tail = _tail.Previous;
                return temp;
            }
        }

        public string List()
        {
            if (_tail == null) // QUEUE IS EMPTY
            {
                return "ALERT: ER QUEUE IS EMPTY";
            }

            Patient current = _tail;
            string patients = current.ToString();

            while (current.Previous != null)
            {
                current = current.Previous;
                patients += $"\n{current}";
            }
            return patients;
        }
    }
}

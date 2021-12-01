using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalQueue_MoonrayLions
{
    class ERQueue
    {
        public Patient Add(Patient head, Patient newNode)
        {
            // EDGE CASE: LINKED LIST IS EMPTY
            if (head == null)
                return newNode;

            Patient current = head;
            // FIND END OF LIST, ADD NODE THERE
            while (current != null)
            {
                if (current.Next == null)
                {   // NEW NODE GOES TO END OF LIST
                    current.Next = newNode;
                    return head;
                }
                else
                    current = current.Next; // STEP TO NEXT NODE
            };
            return head;
        }
        public Patient Contains(Patient head, string item)
        {   // EDGE CASE: LINKED LIST IS EMPTY
            if (head == null)
                return null;

            Patient current = head;
            // RUN THROUGH LIST FROM HEAD TO TOE ... SORRY
            while (current != null)
            {   // IF MATCH IS FOUND: RETURN MATCH
                if (current.Name.ToLower() == item.ToLower())
                    return current;
                else
                    current = current.Next; // STEP TO NEXT NODE
            };
            return null; // ELSE: RETURN NULL
        }
        public Patient Remove(Patient head, string item)
        {   // EDGE CASE: MATCH, BUT ONLY ITEM IN LIST
            if (head.Name.ToLower() == item.ToLower() && head.Next == null)
            {
                head = null;
                return head;
            }
            // EDGE CASE: HEAD IS MATCH + OTHER ITEM(S) IN LIST
            else if (head.Name.ToLower() == item.ToLower())
            {
                head = head.Next;
                return head;
            }

            Patient current = head;

            while (current.Next != null)
            {   // INSTEAD OF STORING "PREVIOUS NODE", DECIDED TO LOOK 2 SPOTS AHEAD IN LIST FROM CURRENT
                if (current.Next.Name.ToLower() == item.ToLower() && current.Next.Next == null)
                {   // EDGE CASE: SEARCHED NODE IS LAST IN LIST
                    current.Next = null;
                    return head;
                }
                else if (current.Next.Name.ToLower() == item.ToLower())
                {   // ELSE: EXAMPLE LIST - "1 "2" "3" / LINK "1" TO "3" 
                    current.Next = current.Next.Next;
                    return head;
                }
                else
                    current = current.Next;
            };
            return head; // THIS SHOULD NEVER FIRE
        }
        public string PrintAllNodes(Patient head)
        {   // EDGE CASE: LINKED LIST IS EMPTY
            if (head == null)
                return "ALERT: LINKED LIST IS EMPTY";

            Patient current = head;
            string allNodeData = "- " + current.Name; // GRAB FIRST NODE DATA

            while (current.Next != null)
            {   // WHILE ADDITIONAL NODES EXIST: ADD THEIR DATA ON A NEW LINE
                current = current.Next;
                allNodeData += $"\n- {current.Name}";
            };
            return allNodeData; // RETURN A STRING
        }
    }
}

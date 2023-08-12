using System.Diagnostics;

namespace timedQueue_Ex_
{
    class Node
    {
        private readonly string m_message;
        private readonly int m_when;

        public Node(string a_message, int a_when)
        {
            m_message = a_message;
            m_when = a_when;
        }

        public string Message()
        {
            return m_message;
        }

        public int DelayTime()
        {
            return m_when;
        }
    }

   

    class ListElements {
        public ListElements Next { get; set; }
        public Node Data { get; set; }
        public ListElements(Node a_node)
        {
            Next = null;
           Data = a_node;
        }
    }
    class TimeQueue
    {
        private ListElements Last(ListElements a_element, ref ListElements a_oneBeforLast)
        {
            if (a_element == null) {
                return new ListElements(new Node("empty!!!!", 0));
            }
            ListElements last = a_element;
            while (last.Next != null)
            {
                a_oneBeforLast = last;
                last = last.Next;
            }
            return last;
        }
        public ListElements FirstElement { get; set; }
        public TimeQueue(ListElements a_first = null)
        {
            FirstElement = a_first;
        }

        public void Enqueue(Node a_newData)
        {
            ListElements temp = new ListElements(a_newData);
            temp.Next = FirstElement;
            FirstElement = temp;
        }

        public ListElements Dequeue()
        {
            ListElements oneBeforLast = null;
            ListElements last = Last(FirstElement, ref oneBeforLast);
            //make it the last Node
            if (oneBeforLast != null && oneBeforLast.Next != null)
            {
                oneBeforLast.Next = null;
            }
            //or was only one or it is the last now!
            else if (oneBeforLast == null || oneBeforLast.Next == null)
            {
                FirstElement = null;
            }
            return last;
        }

        public bool IsEmpty()
        {
            return FirstElement == null;
        }

        public Node First()
        {
            return FirstElement.Data;
        }

    }
}
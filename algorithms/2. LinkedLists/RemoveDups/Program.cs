using System;
using System.Collections.Generic;

namespace RemoveDups
{
    class Program
    {
        static void Main(string[] args)
        {
            Node head = new Node { 
                value = 10, 
                next = new Node {
                    value = 10,
                    next = new Node {
                        value = 10,
                        next = new Node {
                            value = 5,
                            next = new Node {
                                value = 7,
                                next = new Node {
                                    value = 3,
                                    next = null
                                }
                            }
                        }
                    }
                } 
            };

            PrintList(head);
           // RemoveDups(head);
            RemoveDupsOpt(head);
            PrintList(head);
        }

        static void RemoveDups(Node head)
        {
            if (head == null)
                return;
            
            Node current = head;
            while(current.next != null)
            {
                Node iter = current;
                while(iter.next != null)
                {
                    if(iter.next.value == current.value)
                    {
                        iter.next = iter.next.next;
                        continue;
                    }

                    iter = iter.next;
                }

                current = current.next;
            }
        }

        static void RemoveDupsOpt(Node head)
        {
            if (head == null)
                return;

            HashSet<int> table = new HashSet<int>();
            Node current = head;
            table.Add(current.value);

            while(current.next != null)
            {
                if (table.Contains(current.next.value))
                {
                    current.next = current.next.next;
                    continue;
                }

                table.Add(current.next.value);
                current = current.next;
            }
        }

        static void PrintList(Node head)
        {
            Console.WriteLine("--- List ---");
            Console.Write(head.value + " ");
            Node n = head;
            while(n.next != null)
            {
               Console.Write(n.next.value + " "); 
               n = n.next;
            }
            Console.WriteLine();
            Console.WriteLine("-----------");
        }
    }

    class Node 
    {
        public Node next;
        public int value;
    }
}

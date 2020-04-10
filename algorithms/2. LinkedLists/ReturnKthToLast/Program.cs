using System;

namespace ReturnKthToLast
{
    class Program
    {
        static void Main(string[] args)
        {
            Node head = new Node {
                value = 1,
                next = new Node {
                    value = 2,
                    next = new Node {
                        value = 3,
                        next = new Node {
                            value = 4,
                            next = new Node {
                                value = 5,
                                next = new Node {
                                    value = 6,
                                    next = new Node {
                                        value = 7,
                                        next = null
                                    }
                                }
                            }
                        }
                    }
                }
            };

            // var element = Find(head, 1);
            Node element = null;
            // FindRecursively(head, ref element, 2);
            int counter = -1;
            element = FindRecursively(head, ref counter, 2);

            Console.WriteLine("Find returned: " + (element == null ? " Not found" : element.value.ToString()));
        }

        // iterative solution
        static Node Find(Node head, int k)
        {
            if(head == null) return null;

            int count = 1;
            int counter = 1;
            Node iter = head;

            while(iter.next != null)
            {
                count++;
                iter = iter.next;
            }

            iter = head;

            while(iter != null)
            {
                if(counter == count - k)
                    return iter;
                
                iter = iter.next;
                counter++;
            }

            return null;
        }

        // recursive solution (pass node by ref)
        static int FindRecursively(Node node,ref Node element, int k)
        {
            if(node == null)
                return 0;

            int index = FindRecursively(node.next,ref element, k);

            if(index == k)
                element = node;

            return index + 1;
        }

        // pass int by ref
        static Node FindRecursively(Node node,ref int counter, int k)
        {
            if(node == null)
                return null;

            Node n = FindRecursively(node.next,ref counter, k);

            counter++;   

            if(counter == k)
                return node;         

            return n;
        }
    }

    class Node
    {
        public int value;
        public Node next;
    }
}

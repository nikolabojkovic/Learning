using System;
using Xunit;

namespace Intersaction
{
    public class IntersactionTest
    {
        [Fact]
        public void IntersactionTest_ShouldReturnTrue()
        {
            // Arrange
            Node intersectionNode = new Node {
                value = 6,
                next = new Node {
                    value = 7, 
                    next = new Node {
                        value = 8,
                        next = new Node {
                            value = 9,
                            next = null
                        }
                    }
                }
            };

            Node l1 = new Node {
                value = 1,
                next = new Node {
                    value = 2,
                    next = new Node {
                        value = 3,
                        next = intersectionNode 
                    }
                }
            };

            Node l2 = new Node {
                value = 4,
                next = new Node {
                    value = 5,
                    next = intersectionNode
                }
            };

            PrintList(l1);
            PrintList(l2);
            
            // Act
            Node result = FindIntersaction(l1, l2);

            // Assert
            Assert.Equal(result, intersectionNode);
            Assert.Equal(result.value, intersectionNode.value);
        }

        [Fact]
        public void IntersactionTest_ShouldReturnFalse()
        {
            // Arrange
            Node l1 = new Node {
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
                                    next = null
                                }
                            }
                        } 
                    }
                }
            };

            Node l2 = new Node {
                value = 7,
                next = new Node {
                    value = 8,
                    next = new Node {
                        value = 9, 
                        next = new Node {
                            value = 10,
                            next = new Node {
                                value = 11,
                                next = null
                            }
                        }
                    }
                }
            };

            PrintList(l1);
            PrintList(l2);

            // Act
            Node result = FindIntersaction(l1, l2);

            // Assert
            Assert.Null(result);
        }

        private Node FindIntersaction(Node l1, Node l2)
        {
            if(l1 == null || l2 == null)
                return null;

            // get size and tail
            Result l1Result = GetSizeAndTail(l1);
            Result l2Result = GetSizeAndTail(l2);

            // chck if intersect 
            if(l1Result.tail != l2Result.tail)
                return null;

            // find which node is longer
            Node longer = l1Result.size < l2Result.size ? l2 : l1;
            Node shorter = l2Result.size < l1Result.size ? l2 : l1;

            // advance longer list
            longer = GEtKthNode(longer, Math.Abs(l1Result.size - l2Result.size));

            // find intersaction node
            while(longer != shorter)
            {
                longer = longer.next;
                shorter = shorter.next;
            }

            return longer;
        }

        private Node GEtKthNode(Node head, int k)
        {
            while (k > 0 && head != null)
            {
                head = head.next;
                k--;
            }

            return head;
        }

        private Result GetSizeAndTail(Node head)
        {
           int size = 1;
           while(head.next != null)
           {
               size++;
               head = head.next;
           }

           return new Result{ size = size, tail = head};
        }

        private void PrintList(Node head)
        {
            Console.WriteLine("-- List --");
            while(head != null)
            {
                Console.Write(head.value + " -> ");
                head = head.next;
            }
            Console.WriteLine();
            Console.WriteLine("-- End List --");
        }
    }

       class Node
        {
            public int value;
            public Node next;
        }

        class Result
        {
            public int size;
            public Node tail;
        }
}

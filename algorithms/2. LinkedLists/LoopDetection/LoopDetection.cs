using System;
using System.Collections.Generic;
using Xunit;

namespace LoopDetection
{
    public class LoopDetection
    {
        // hashtable approach
        [Fact]
        public void FindLoopNode_ShouldReturnNode_Hastable()
        {
            // Arrange
            Node loopStartingNode = new Node {
                value = 'D',
                next = null
            };

            Node loop = new Node {
                value = 'E',
                next = new Node {
                    value = 'F',
                    next = new Node {
                        value = 'G',
                        next = new Node {
                            value = 'H',
                            next = new Node {
                                value = 'J',
                                next = loopStartingNode
                            }
                        }
                    }
                }
            };

            loopStartingNode.next = loop;

            Node head = new Node {
                value = 'A',
                next = new Node {
                    value = 'B',
                    next = new Node {
                        value = 'C',
                        next = loopStartingNode
                    }
                }
            };

            // Act
            Node result = FindLoopStartingNode(head);

            // Assert
            Assert.Equal(loopStartingNode, result);
            Assert.Equal('D', result.value);
        }

        [Fact]
        public void FindLoopNode_ShouldReturnNull_Hastable()
        {
            // Arrange
            Node head = new Node {
                value = 'A',
                next = new Node {
                    value = 'B',
                    next = new Node {
                        value = 'C',
                        next = new Node {
                            value = 'E',
                            next = new Node {
                                value = 'F',
                                next = new Node {
                                    value = 'G',
                                    next = new Node {
                                        value = 'H',
                                        next = new Node {
                                            value = 'J',
                                            next = null
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            // Act
            Node result = FindLoopStartingNode(head);

            // Assert
            Assert.Null(result); 
        }

        private Node FindLoopStartingNode(Node head)
        {
            if (head == null)
                return null;

            HashSet<Node> table = new HashSet<Node>();

            while (head != null)
            {
                if (table.Contains(head))
                    return head;

                table.Add(head);
                head = head.next;
            }

            return null;
        }

        // Fast runner / slow runner approach
        [Fact]
        public void FindLoopNode_ShouldReturnNode_Fast_Slow_Runner()
        { // Arrange
            Node loopStartingNode = new Node {
                value = 'D',
                next = null
            };

            Node loop = new Node {
                value = 'E',
                next = new Node {
                    value = 'F',
                    next = new Node {
                        value = 'G',
                        next = new Node {
                            value = 'H',
                            next = new Node {
                                value = 'J',
                                next = loopStartingNode
                            }
                        }
                    }
                }
            };

            loopStartingNode.next = loop;

            Node head = new Node {
                value = 'A',
                next = new Node {
                    value = 'B',
                    next = new Node {
                        value = 'C',
                        next = loopStartingNode
                    }
                }
            };

            // Act
            Node result = FindLoopStartingNodeFastSlow(head);

            // Assert
            Assert.Equal(loopStartingNode, result);
            Assert.Equal('D', result.value);
        }
        
        [Fact]
        public void FindLoopNode_ShouldReturnNull_Fast_Slow_Runner()
        {
               // Arrange
            Node head = new Node {
                value = 'A',
                next = new Node {
                    value = 'B',
                    next = new Node {
                        value = 'C',
                        next = new Node {
                            value = 'E',
                            next = new Node {
                                value = 'F',
                                next = new Node {
                                    value = 'G',
                                    next = new Node {
                                        value = 'H',
                                        next = new Node {
                                            value = 'J',
                                            next = null
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

               // Act
            Node result = FindLoopStartingNodeFastSlow(head);

            // Assert
            Assert.Null(result); 
        }

        private Node FindLoopStartingNodeFastSlow(Node head)
        {
            if (head == null)
                return null;

            Node fast = head;
            Node slow = head;

            // collision point after Loop size - k (k is number of nodes before loop size)
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;

                if(slow == fast)
                    break;
            }

            if(fast == null || fast.next == null)
                return null;

            // reset slow to beginning of the list
            slow = head;

            // both references will meet after k steps

            // after collision move both of them at a same speed
            while(slow != fast)
            {
                slow = slow.next;
                fast = fast.next;
            } 

            return slow;
        }
    }

    public class Node
    {
        public char value;
        public Node next;
    }
}

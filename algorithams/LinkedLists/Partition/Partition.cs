using System;
using Xunit;

namespace Partition
{
    public class UnitTest1
    {
        [Fact]
        public void PartitionListBruteForce()
        {
            // Arrange
            Node head =  new Node {
                    value = 3,
                    next = new Node {
                        value = 5,
                        next = new Node {
                            value = 8,
                            next = new Node {
                                value = 5,
                                next = new Node {
                                    value = 10,
                                    next = new Node {
                                        value = 2,
                                        next = new Node {
                                            value = 1,
                                            next = null
                                        }
                                    }
                                }
                            }
                        }
                    }
                };

            // Act
            PartitionList(ref head, 5);

            // Assert
            Assert.Equal(3,  head.value);
            Assert.Equal(1,  head.next.value);
            Assert.Equal(2,  head.next.next.value);
            Assert.Equal(5,  head.next.next.next.value);
            Assert.Equal(8,  head.next.next.next.next.value);
            Assert.Equal(5,  head.next.next.next.next.next.value);
            Assert.Equal(10, head.next.next.next.next.next.next.value);
        }

        [Fact]
        public void PartitionListBruteForceScenario2()
        {
            // Arrange
            Node head = new Node {
                        value = 5,
                        next = new Node {
                            value = 8,
                            next = new Node {
                                value = 5,
                                next = new Node {
                                    value = 10,
                                    next = new Node {
                                        value = 2,
                                        next = new Node {
                                            value = 1,
                                            next = null
                                        }
                                    }
                                }
                            }
                        }
                };

            // Act
            PartitionList(ref head, 5);

            // Assert
            Assert.Equal(2,  head.value);
            Assert.Equal(1,  head.next.value);
            Assert.Equal(5,  head.next.next.value);
            Assert.Equal(8,  head.next.next.next.value);
            Assert.Equal(5,  head.next.next.next.next.value);
            Assert.Equal(10, head.next.next.next.next.next.value);
        }
       
        [Fact]
        public void PartitionListBruteForce3()
        {
            // Arrange
            Node head =  new Node {
                    value = 3,
                    next = new Node {
                        value = 5,
                        next = new Node {
                            value = 8,
                            next = new Node {
                                value = 5,
                                next = new Node {
                                    value = 10,
                                    next = new Node {
                                        value = 2,
                                        next = new Node {
                                            value = 1,
                                            next = null
                                        }
                                    }
                                }
                            }
                        }
                    }
                };

            // Act
            PartitionList(ref head, 3);

            // Assert
            Assert.Equal(2,  head.value);
            Assert.Equal(1,  head.next.value);
            Assert.Equal(3,  head.next.next.value);
            Assert.Equal(5,  head.next.next.next.value);
            Assert.Equal(8,  head.next.next.next.next.value);
            Assert.Equal(5,  head.next.next.next.next.next.value);
            Assert.Equal(10, head.next.next.next.next.next.next.value);
        }

        private  void PartitionList(ref Node head, int partition)
        {
            if(head == null)
                return;

            Node temp = null;
            Node curr = head;

            while(curr.next != null)
            {
                if(curr.next.value < partition)
                {
                    temp = curr.next;
                    curr.next = curr.next.next;

                    if(head.value < partition)
                    {
                        temp.next = head.next;
                        head.next = temp;
                    }
                    else 
                    {
                        temp.next = head;
                        head = temp;
                    }
                }
                else
                    curr = curr.next;
            }
        }

        [Fact]
         public void PartitionWithMergeScenario1()
        {
            // Arrange
            Node head =  new Node {
                    value = 3,
                    next = new Node {
                        value = 5,
                        next = new Node {
                            value = 8,
                            next = new Node {
                                value = 5,
                                next = new Node {
                                    value = 10,
                                    next = new Node {
                                        value = 2,
                                        next = new Node {
                                            value = 1,
                                            next = null
                                        }
                                    }
                                }
                            }
                        }
                    }
                };

            // Act
            PartitionWithMerge(ref head, 5);

            // Assert
            Assert.Equal(3,  head.value);
            Assert.Equal(2,  head.next.value);
            Assert.Equal(1,  head.next.next.value);
            Assert.Equal(5,  head.next.next.next.value);
            Assert.Equal(8,  head.next.next.next.next.value);
            Assert.Equal(5,  head.next.next.next.next.next.value);
            Assert.Equal(10, head.next.next.next.next.next.next.value);
        }

        [Fact]
        public void PartitionWithMergeScenario2()
        {
            // Arrange
            Node head =  new Node {
                    value = 6,
                    next = new Node {
                        value = 5,
                        next = new Node {
                            value = 8,
                            next = new Node {
                                value = 5,
                                next = new Node {
                                    value = 10,
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
                    }
                };

            // Act
            PartitionWithMerge(ref head, 5);

            // Assert
            Assert.Equal(6,  head.value);
            Assert.Equal(5,  head.next.value);
            Assert.Equal(8,  head.next.next.value);
            Assert.Equal(5,  head.next.next.next.value);
            Assert.Equal(10,  head.next.next.next.next.value);
            Assert.Equal(5,  head.next.next.next.next.next.value);
            Assert.Equal(6, head.next.next.next.next.next.next.value);
        }

        [Fact]
        public void PartitionWithMergeScenario3()
        {
            // Arrange
            Node head =  new Node {
                    value = 1,
                    next = new Node {
                        value = 2,
                        next = new Node {
                            value = 1,
                            next = new Node {
                                value = 2,
                                next = new Node {
                                    value = 3,
                                    next = new Node {
                                        value = 1,
                                        next = new Node {
                                            value = 2,
                                            next = null
                                        }
                                    }
                                }
                            }
                        }
                    }
                };

            // Act
            PartitionWithMerge(ref head, 5);

            // Assert
            Assert.Equal(1,  head.value);
            Assert.Equal(2,  head.next.value);
            Assert.Equal(1,  head.next.next.value);
            Assert.Equal(2,  head.next.next.next.value);
            Assert.Equal(3,  head.next.next.next.next.value);
            Assert.Equal(1,  head.next.next.next.next.next.value);
            Assert.Equal(2, head.next.next.next.next.next.next.value);
        }

        [Fact]
         public void PartitionWithMergeScenario4()
        {
            // Arrange
            Node head =  new Node {
                    value = 3,
                    next = new Node {
                        value = 5,
                        next = new Node {
                            value = 8,
                            next = new Node {
                                value = 5,
                                next = new Node {
                                    value = 10,
                                    next = new Node {
                                        value = 2,
                                        next = new Node {
                                            value = 1,
                                            next = null
                                        }
                                    }
                                }
                            }
                        }
                    }
                };

            // Act
            PartitionWithMerge(ref head, 3);

            // Assert
            Assert.Equal(2,  head.value);
            Assert.Equal(1,  head.next.value);
            Assert.Equal(3,  head.next.next.value);
            Assert.Equal(5,  head.next.next.next.value);
            Assert.Equal(8,  head.next.next.next.next.value);
            Assert.Equal(5,  head.next.next.next.next.next.value);
            Assert.Equal(10, head.next.next.next.next.next.next.value);
        }

        private void PartitionWithMerge(ref Node head, int partition)
        {
            if (head == null)
                return;

            Node beforeHead = null;
            Node beforeTail = null;
            Node afterHead = null;
            Node afterTail = null;

            Node curr = head;
            
            while(curr != null)
            {
                if(curr.value < partition)
                {
                    if(beforeHead == null)
                    {
                        beforeHead = curr;
                        beforeTail = curr;
                    }
                    else 
                    {
                        beforeTail.next = curr;
                        beforeTail = curr;
                    }
                }
                else 
                {
                    if(afterHead == null)
                    {
                        afterHead = curr;
                        afterTail = curr;
                    }
                    else
                    {
                        afterTail.next = curr;
                        afterTail = curr;
                    }
                }

                curr = curr.next;
            }

            if(beforeHead == null)
            {
                head = afterHead;
                return;
            }
            
            beforeTail.next = afterHead;
            head = beforeHead;
        }
    }

    public class Node 
    {
        public int value;
        public Node next;
    }
}

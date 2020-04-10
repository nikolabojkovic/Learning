using System;
using Xunit;

namespace SumLists
{
    public class UnitTest1
    {
        [Fact]
        public void SumListsScenario1()
        {
            Node l1 = new Node {
                value = 7,
                next = new Node {
                    value = 1,
                    next = new Node {
                        value = 6,
                        next = null
                    }
                }
            };

            Node l2 = new Node {
                value = 5,
                next = new Node {
                    value = 9,
                    next = new Node {
                        value = 2,
                        next = null
                    }
                }
            };

            Node result = Sum(l1, l2, 0);

            Node expectedResult = new Node {
                value = 2,
                next = new Node {
                    value = 1,
                    next = new Node {
                        value = 9,
                        next = null
                    }
                }
            };

            while(result != null)
            {
               Assert.Equal(expectedResult.value, result.value);
               result = result.next;
               expectedResult = expectedResult.next;
            }
        }
        
        [Fact]
        public void SumListsScenario2()
        {
            Node l1 = new Node {
                value = 7,
                next = new Node {
                    value = 1,
                    next = new Node {
                        value = 6,
                        next = null
                    }
                }
            };

            Node l2 = new Node {
                value = 5,
                next = new Node {
                    value = 9,
                    next = null
                }
            };

            Node result = Sum(l1, l2, 0);

            Node expectedResult = new Node {
                value = 2,
                next = new Node {
                    value = 1,
                    next = new Node {
                        value = 7,
                        next = null
                    }
                }
            };

            while(result != null)
            {
               Assert.Equal(expectedResult.value, result.value);
               result = result.next;
               expectedResult = expectedResult.next;
            }
        }
 
        [Fact]
        public void SumListsScenario3()
        {
            Node l1 = new Node {
                value = 7,
                next = null
            };

            Node l2 = new Node {
                value = 5,
                next = new Node {
                    value = 9,
                    next = null
                }
            };

            Node result = Sum(l1, l2, 0);

            Node expectedResult = new Node {
                value = 2,
                next = new Node {
                    value = 0,
                    next = new Node {
                        value = 1,
                        next = null
                    }
                }
            };

            while(result != null)
            {
               Assert.Equal(expectedResult.value, result.value);
               result = result.next;
               expectedResult = expectedResult.next;
            }
        }


        // Sum lists forward scenario
        [Fact]
        public void SumListsForwardScenario1()
        {
            Node l1 = new Node {
                value = 7,
                next = null
            };

            Node l2 = new Node {
                value = 9,
                next = new Node {
                    value = 5,
                    next = null
                }
            };

            Node result = SumListsForwards(l1, l2);

            Node expectedResult = new Node {
                value = 1,
                next = new Node {
                    value = 0,
                    next = new Node {
                        value = 2,
                        next = null
                    }
                }
            };

            while(result != null)
            {
               Assert.Equal(expectedResult.value, result.value);
               result = result.next;
               expectedResult = expectedResult.next;
            }
        }

        [Fact]
        public void SumListsFowradScenario2()
        {
            Node l1 = new Node {
                value = 6,
                next = new Node {
                    value = 1,
                    next = new Node {
                        value = 7,
                        next = null
                    }
                }
            };

            Node l2 = new Node {
                value = 2,
                next = new Node {
                    value = 9,
                    next = new Node {
                        value = 5,
                        next = null
                    }
                }
            };

            Node result = SumListsForwards(l1, l2);

            Node expectedResult = new Node {
                value = 9,
                next = new Node {
                    value = 1,
                    next = new Node {
                        value = 2,
                        next = null
                    }
                }
            };

            while(result != null)
            {
               Assert.Equal(expectedResult.value, result.value);
               result = result.next;
               expectedResult = expectedResult.next;
            }
        }

        [Fact]
        public void SumListsForwardScenario3()
        {
            Node l2 = new Node {
                value = 7,
                next = null
            };

            Node l1 = new Node {
                value = 9,
                next = new Node {
                    value = 5,
                    next = null
                }
            };

            Node result = SumListsForwards(l1, l2);

            Node expectedResult = new Node {
                value = 1,
                next = new Node {
                    value = 0,
                    next = new Node {
                        value = 2,
                        next = null
                    }
                }
            };

            while(result != null)
            {
               Assert.Equal(expectedResult.value, result.value);
               result = result.next;
               expectedResult = expectedResult.next;
            }
        }

         [Fact]
        public void SumListsForwardScenario4()
        {
            Node l2 = null;

            Node l1 = null;

            Node result = SumListsForwards(l1, l2);

            Node expectedResult = null;

            Assert.Equal(expectedResult, result);
        }

         [Fact]
        public void SumListsForwardScenario5()
        {
            Node l2 = null;

            Node l1 = new Node {
                value = 9,
                next = new Node {
                    value = 5,
                    next = null
                }
            };

            Node result = SumListsForwards(l1, l2);

            Node expectedResult = new Node {
                value = 9,
                next = new Node {
                    value = 5,
                    next = null
                }
            };

            while(result != null)
            {
               Assert.Equal(expectedResult.value, result.value);
               result = result.next;
               expectedResult = expectedResult.next;
            }
        }

        private Node Sum(Node l1, Node l2, int carry)
        {
            if(l1 == null && l2 == null && carry == 0)
                return null;

            int value = carry;

            if(l1 != null)
                value += l1.value;

            if(l2 != null)
                value += l2.value;

            carry = value / 10;

            Node n = new Node { 
                value = value % 10,
                next = Sum((l1 != null ? l1.next : null), (l2 != null ? l2.next : null), carry)
            };

            return n;
        }

        // Sum forwards
        private Node SumForwards(Node l1, Node l2, ref int carry)
        {
            if(l1 == null && l2 == null)
                return null;

            Node next = SumForwards(l1.next, l2.next, ref carry);
            int value = carry;
            value += l1.value + l2.value;

            Node n = new Node { value = value % 10, next = next };
            carry = value / 10;
            return n;
        }

        int Count(Node head)
        {
            int counter = 0;

            while(head != null)
            {
                counter++;
                head = head.next;
            }

            return counter;
        }

        Node AppendZeros(Node head, int count)
        {
            while(count > 0)
            {
                Node node = new Node { value = 0, next = head };
                head = node;
                count--;
            }

            return head;
        }

        Node SumListsForwards(Node l1, Node l2)
        {
            if(l1 == null && l2 == null)
                return null;

            Node result = null;
            int carry = 0;
            int l1Count = Count(l1);
            int l2Count = Count(l2);

            if(l1Count < l2Count)
                l1 = AppendZeros(l1, l2Count - l1Count);
            else
                l2 = AppendZeros(l2, l1Count - l2Count);

            result = SumForwards(l1, l2, ref carry);

            if(carry > 0) 
            {
                Node head = new Node { value = carry, next = result };
                result = head;
            }

            return result;
        }
    }

    class Node 
    {
        public int value;
        public Node next;
    }
}

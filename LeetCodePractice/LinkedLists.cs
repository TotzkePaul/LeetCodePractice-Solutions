﻿using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Extensions;

namespace LeetCodePractice
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    public class LinkedLists
    {
        // Assert Helper to validate 2 ListNodes are equal
        private static void CompareListNode(ListNode expected, ListNode actual)
        {
            Assert.Equal(expected == null, actual == null);
            if (expected == null || actual == null)
                return;


            ListNode l1 = expected;
            ListNode l2 = actual;


            while (l1.val == l2.val && l1.next != null && l2.next != null)
            {
                l1 = l1.next;
                l2 = l2.next;
            }
            Assert.Equal(l1.val, l2.val);
            Assert.True(l1.next == null && l2.next == null);
        }

        // 2. Add Two Numbers [MEDIUM] https://leetcode.com/problems/add-two-numbers/
        /// <summary>
        /// You are given two *non-empty* linked lists representing two non-negative integers. 
        /// The digits are stored in *reverse order* and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.
        /// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
        /// </summary>
        [Theory]
        [MemberData(nameof(GetValidateBinarySearchTreeData))]
        public void AddTwoNumbers(ListNode l1, ListNode l2, ListNode expected)
        {
            // 3/25/2020
            // Comment: The only difficulty I had a difficult time figuring out what carried should be. Some reason carried = (val-10); seemed about like it only needed a little tweeking
            // https://www.youtube.com/watch?v=aM4Iv7eEr2o
            // I waited to watch until I figure this out on my own but the similarities surprised me that its easier to describe the diffferences:
            // I preserve the values of l1 and l2 (purely for debugging). He uses null checking while I use null propagation and coalescing. 
            // Runtime: 104 ms, faster than 85.25% of C# online submissions for Add Two Numbers.
            // Memory Usage: 27.6 MB, less than 9.09 % of C# online submissions for Add Two Numbers.

            ListNode result = new ListNode(0); // while loop assumes non-null. Dummy gets "Popped off" at the end of the function 

            ListNode current1 = l1;
            ListNode current2 = l2;

            int carried = 0;

            ListNode next = result;

            while (current1 != null || current2 != null)
            {
                int val = (current1?.val?? 0) + (current2?.val ?? 0) + carried;
                int digit = val % 10; 
                carried = val / 10 % 10;
                ListNode newest = new ListNode(digit);
                next.next = newest;
                next = next.next;
                current1 = current1?.next;
                current2 = current2?.next;
            }

            if (carried > 0)
            {
                next.next = new ListNode(carried);
            }

            result = result.next;

            CompareListNode(expected, result);
        }

        public static IEnumerable<object[]> GetValidateBinarySearchTreeData()
        {
            return new[]
            {
                new object[] { new ListNode(9), new ListNode(1), new ListNode(0){ next= new ListNode(1) } },
                new object[] { new ListNode(5), new ListNode(5), new ListNode(0){ next= new ListNode(1) } },
                new object[] { new ListNode(9), new ListNode(9), new ListNode(8){ next= new ListNode(1) } },                
                new object[] { new ListNode(2) { next = new ListNode(4) { next = new ListNode(3) } }, new ListNode(5) { next = new ListNode(6) { next = new ListNode(4) } }, new ListNode(7) { next = new ListNode(0) { next = new ListNode(8) } } },
                new object[] { new ListNode(9) { next = new ListNode(9) { next = new ListNode(9) } }, new ListNode(1), new ListNode(0) { next = new ListNode(0) { next = new ListNode(0) { next = new ListNode(1) } } } },
            };
        }


        // 19. Remove Nth Node From End of List https://leetcode.com/problems/remove-nth-node-from-end-of-list/
        // Given a linked list, remove the n-th node from the end of list and return its head.
        // Note: Given n will always be valid.
        [Theory]
        [MemberData(nameof(GetRemoveNthFromEndData))]
        public void RemoveNthFromEnd(ListNode head, int n, ListNode expected)
        {
            ListNode result = new ListNode(0);

            CompareListNode(expected, result);
        }

        public static IEnumerable<object[]> GetRemoveNthFromEndData()
        {
            return new[]
            {   // After removing the second node from the end, the linked list becomes 1->2->3->5.
                new object[] { new ListNode(1) { next = new ListNode(2) { next = new ListNode(3) } }, new ListNode(4) { next = new ListNode(5) }, 2, new ListNode(1) { next = new ListNode(3) { next = new ListNode(4) } }, new ListNode(5) },
            };
        }

        // 142. Linked List Cycle II
        /// <summary>
        /// Given a linked list, return the node where the cycle begins. If there is no cycle, return null.
        /// To represent a cycle in the given linked list, we use an integer pos which represents the position(0-indexed) in the linked list where tail connects to.If pos is -1, then there is no cycle in the linked list.
        /// Note: Do not modify the linked list.
        /// </summary>
        [Theory]
        [MemberData(nameof(GetLinkedListCycleIIData))]
        public void LinkedListCycleII(ListNode head, ListNode expected)
        {
            ListNode result = new ListNode(0);

            CompareListNode(expected, result);
        }

        public static IEnumerable<object[]> GetLinkedListCycleIIData()
        {
            ListNode ans1 = new ListNode(2) { next = new ListNode(0) { next = new ListNode(-4) } };
            ans1.next.next.next = ans1;
            ListNode input1 = new ListNode(3) { next = ans1 };
            ListNode ans2 = new ListNode(1) { next = new ListNode(2) };
            ListNode input2 = ans2;
            return new[]
            {   
                new object[] { input1, ans1 },
                new object[] { input2, ans2},
                new object[] { new ListNode(1), null }
            };
        }

        // 234. Palindrome Linked List https://leetcode.com/problems/palindrome-linked-list/
        // Given a singly linked list, determine if it is a palindrome.
        // Follow up: Could you do it in O(n) time and O(1) space?
        [Theory]
        [MemberData(nameof(GetPalindromeLinkedListData))]
        public void PalindromeLinkedList(ListNode head, bool expected)
        {
            bool result = false;

            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> GetPalindromeLinkedListData()
        {            
            return new[]
            {   
                new object[] { new ListNode(2) { next = new ListNode(1) { next = new ListNode(2) } }, false },
                new object[] { new ListNode(2) { next = new ListNode(1) { next = new ListNode(2) { next = new ListNode(2) { next = new ListNode(1) } } } }, true }
            };
        }

        // 160. Intersection of Two Linked Lists https://leetcode.com/problems/intersection-of-two-linked-lists/
        /// <summary>
        /// Write a program to find the node at which the intersection of two singly linked lists begins.
        /// Notes:
        ///     If the two linked lists have no intersection at all, return null.
        ///     The linked lists must retain their original structure after the function returns.
        ///     You may assume there are no cycles anywhere in the entire linked structure.
        ///     Your code should preferably run in O(n) time and use only O(1) memory.
        /// </summary>
        [Theory]
        [MemberData(nameof(GetIntersectionOfTwoLinkedListsData))]
        public void IntersectionOfTwoLinkedLists(ListNode headA, ListNode headB, ListNode expected)
        {
            ListNode result = new ListNode(0);

            CompareListNode(expected, result);
        }

        public static IEnumerable<object[]> GetIntersectionOfTwoLinkedListsData()
        {
            /*
             * Input Explanation: The intersected node's value is 8 (note that this must not be 0 if the two lists intersect). 
             * From the head of A, it reads as [4,1,8,4,5]. From the head of B, it reads as [5,0,1,8,4,5]. 
             * There are 2 nodes before the intersected node in A; There are 3 nodes before the intersected node in B.
             */ 
            ListNode end1 = new ListNode(8) { next = new ListNode(4) { next = new ListNode(5) } };
            ListNode headA1 = new ListNode(4) { next = new ListNode(1) { next = end1 } };
            ListNode headB1 = new ListNode(5) { next = new ListNode(0) { next = new ListNode(1) { next = end1 } } };

            /*
             * Input Explanation: The intersected node's value is 2 (note that this must not be 0 if the two lists intersect). 
             * From the head of A, it reads as [0,9,1,2,4]. From the head of B, it reads as [3,2,4]. 
             * There are 3 nodes before the intersected node in A; There are 1 node before the intersected node in B.
             */ 
            ListNode end2 = new ListNode(2) { next = new ListNode(4) };
            ListNode headA2 = new ListNode(0) { next = new ListNode(9) { next = new ListNode(1) { next = end2} } };
            ListNode headB2 = new ListNode(3) { next = end2 };

            /*
             * Input Explanation: From the head of A, it reads as [2,6,4]. * From the head of B, it reads as [1,5]. 
             * Since the two lists do not intersect, intersectVal must be 0, while skipA and skipB can be arbitrary values.
             * Explanation: The two lists do not intersect, so return null.
             */
            ListNode end3 = null;
            ListNode headA3 = new ListNode(2) { next = new ListNode(6) { next = new ListNode(4) } };
            ListNode headB3 = new ListNode(1) { next = new ListNode(5) };

            return new[]
            {
                new object[] { headA1, headB1, end1 },
                new object[] { headA2, headB2, end2 },
                new object[] { headA3, headB3, end3 }
            };
        }

        // 23. Merge k Sorted Lists https://leetcode.com/problems/merge-k-sorted-lists/
        // Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity.
        [Theory]
        [MemberData(nameof(GetMergeKSortedListsData))]
        public void MergeKSortedLists(ListNode head, ListNode expected)
        {
            ListNode result = new ListNode(0);

            CompareListNode(expected, result); 
        }

        public static IEnumerable<object[]> GetMergeKSortedListsData()
        {
            ListNode[] input = new ListNode[]
            {
                  new ListNode(1) { next = new ListNode(4) { next = new ListNode(5) } },
                  new ListNode(1) { next = new ListNode(3) { next = new ListNode(4) } },
                  new ListNode(2) { next = new ListNode(6) }
            };

            ListNode output = new ListNode(1) { next = new ListNode(1) { next = new ListNode(2) { next = new ListNode(3) { next = new ListNode(4) { next = new ListNode(4) { next = new ListNode(5) { next = new ListNode(6) } } } } } } };

            return new[]
            {
                new object[] { input, output },
            };
        }

        // 148. Sort List https://leetcode.com/problems/sort-list/
        // Sort a linked list in O(n log n) time using constant space complexity.
        [Theory]
        [MemberData(nameof(GetSortListData))]
        public void SortList(ListNode head, ListNode expected)
        {
            ListNode result = new ListNode(0);

            CompareListNode(expected, result);
        }

        public static IEnumerable<object[]> GetSortListData()
        {
            ListNode[] input = new ListNode[]
            {
                  new ListNode(1) { next = new ListNode(4) { next = new ListNode(5) } },
                  new ListNode(1) { next = new ListNode(3) { next = new ListNode(4) } },
                  new ListNode(2) { next = new ListNode(6) }
            };

            ListNode output = new ListNode(4) { next = new ListNode(2) { next = new ListNode(1) { next = new ListNode(3) } } };

            return new[]
            {
                new object[] { input, output },
            };
        }


        // 141. Linked List Cycle https://leetcode.com/problems/linked-list-cycle/
        /// <summary>
        /// Given a linked list, determine if it has a cycle in it.
        /// To represent a cycle in the given linked list, we use an integer pos which represents the position(0-indexed) in the linked list where tail connects to.
        /// If pos is -1, then there is no cycle in the linked list.
        /// Follow up:
        ///     Can you solve it using O(1) (i.e.constant) memory?
        /// </summary>
        [Theory]
        [MemberData(nameof(GetLinkedListCycleData))]
        public void LinkedListCycle(ListNode head, bool expected)
        {
            bool result = false;

            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> GetLinkedListCycleData()
        {
            ListNode ans1 = new ListNode(2) { next = new ListNode(0) { next = new ListNode(-4) } };
            ans1.next.next.next = ans1;
            ListNode input1 = new ListNode(3) { next = ans1 };
            ListNode ans2 = new ListNode(1) { next = new ListNode(2) };
            ListNode input2 = ans2;
            return new[]
            {
                new object[] { input1, true }, // Explanation: There is a cycle in the linked list, where tail connects to the second node.
                new object[] { input2, true}, //Explanation: There is a cycle in the linked list, where tail connects to the first node.
                new object[] { new ListNode(1), false } //Explanation: There is no cycle in the linked list.
            };
        }


        // 21. Merge Two Sorted Lists https://leetcode.com/problems/merge-two-sorted-lists/
        // Merge two sorted linked lists and return it as a new list. The new list should be made by splicing together the nodes of the first two lists.
        [Theory]
        [MemberData(nameof(GetMergeTwoSortedListsData))]
        public void MergeTwoSortedLists(ListNode l1, ListNode l2, ListNode expected)
        {
            ListNode result = new ListNode(0);

            CompareListNode(expected, result);
        }

        public static IEnumerable<object[]> GetMergeTwoSortedListsData()
        {
            // Input: 1->2->4, 1->3->4
            // Output: 1->1->2->3->4->4
            return new[]
            {
                new object[] { new ListNode(1) { next = new ListNode(2) { next = new ListNode(4) } }, new ListNode(1) { next = new ListNode(3) { next = new ListNode(4) } }, new ListNode(1) { next = new ListNode(1) { next = new ListNode(2) { next = new ListNode(3) { next = new ListNode(4) { next = new ListNode(4) } } } } } },
            };
        }

        // 206. Reverse Linked List https://leetcode.com/problems/reverse-linked-list/
        // Reverse a singly linked list.
        // Follow up: A linked list can be reversed either iteratively or recursively.Could you implement both?
        [Theory]
        [MemberData(nameof(GetReverseLinkedListData))]
        public void ReverseLinkedList(ListNode head, ListNode expected)
        {
            // Runtime: 100 ms, faster than 11.92% of C# online submissions for Reverse Linked List.
            // Memory Usage: 24.6 MB, less than 8.00 % of C# online submissions for Reverse Linked List.
            ListNode headptr = head;
            ListNode current = head;
            while (current.next != null)
            {
                ListNode prev = current.next;
                current.next = prev.next;
                prev.next = headptr;
                headptr = prev;
            }
            

            ListNode result = headptr;

            CompareListNode(expected, result);
        }

        public static IEnumerable<object[]> GetReverseLinkedListData()
        {
            // Input: 1->2->3->4->5->NULL
            // Output: 5->4->3->2->1->NULL
            return new[]
            {
                new object[] { new ListNode(1) { next = new ListNode(2) { next = new ListNode(3) { next = new ListNode(4) { next = new ListNode(5) } } } } ,  new ListNode(5) { next = new ListNode(4) { next = new ListNode(3) { next = new ListNode(2) { next = new ListNode(1) } } } } },
            };
        }
    }
}

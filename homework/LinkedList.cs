using System.Collections.Generic;
using System;
using System.Reflection;
class LinkedList
{
    private Node? head; //Head of LinkedList
    private Node? tail; //Back of LinkedList used to ensure that pop is O(1)
    private Node? maxNode; //Max of LinkdeList
    private Node? minNode; //Min of LinkdeList

    public LinkedList(Node? startNode = null)
    {
        // Has the option of starting with a previously existing Node by default is null

        head = startNode;
        tail = startNode;
        maxNode = startNode;
        minNode = startNode;

        if(tail != null)
        {
            while(tail.GetNext() != null)
            {

                tail = tail.GetNext();
                UpdateMaxAndMin(tail);
            }
        }

    }

    private void UpdateMaxAndMin(Node? compareNode){
        if(maxNode == null)
        {
            maxNode = compareNode;
        }
        if(minNode == null)
        {
            minNode = compareNode;
        }
        if(compareNode != null)
        {
            if(compareNode.GetValue() > maxNode.GetValue()){
                maxNode = compareNode;
            }

            if(compareNode.GetValue() < minNode.GetValue()){
                minNode = compareNode;
            }
        }
    }

    public void Append(int NewNum){
        if(head == null){
            head = new Node(NewNum);
            tail = head;
            maxNode = head;
            minNode = head;
        }
        
        else{
            tail.SetNext(new Node(NewNum));
            tail = tail.GetNext();
            UpdateMaxAndMin(tail);
        }
    }

    public void Prepend(int NewNum){
        head = new Node(NewNum, head);
        UpdateMaxAndMin(head);
    }

    public int Pop(){
        //removes element from the back of the array will throw error if there is no head
        maxNode = head;
        minNode = head;
        Node? ptr = head;
        while(ptr.GetNext() != tail){
            ptr = ptr.GetNext();
            UpdateMaxAndMin(ptr);
        }
        int ret = tail.GetValue();
        ptr.SetNext(null);
        tail = ptr;
        return ret;
    }

    public int Unqueue(){
        //removes element from the head of the array will throw error if there is no head
        int ret = head.GetValue();
        if(head.GetHashCode() == maxNode.GetHashCode() || head.GetHashCode() == minNode.GetHashCode())
        {
            head = head.GetNext();
            maxNode = head;
            minNode = head;
            Node? ptr = head;
            while(ptr != null){
                UpdateMaxAndMin(ptr);
                ptr = ptr.GetNext();
            
            }
        }
        return ret;

    }

    public IEnumerable<int> ToList(){
        //retruns a list of all the numbers in the LinkedList
        List<int> List = [];
        Node? ptr = head;
        while(ptr != null){
            List.Add(ptr.GetValue());
            ptr = ptr.GetNext();
        }
        return List;
    }

    public bool IsCircular(){
        //checks for a cicle in the list
        if(head == null){
            return false;
        }
        //uses Tortoise and hare method
        Node? slow = head;
        Node? fast = head.GetNext();
        while(fast != slow){
            if(fast == null || slow == null){
                return false;
            }
            slow = slow.GetNext();
            if(slow == null){
                return false;
            }
            fast = fast.GetNext();
        }
        return true;
    }

    public Node? GetMaxNode(){
        return maxNode;
    }

    public Node? GetMinNode(){
        return minNode;
    }

    private void SwapNodes(Node nodeA, Node nodeB){
        //internal method used for swaping the values of nodes
        int temp = nodeA.GetValue();
        nodeA.SetValue(nodeB.GetValue());
        nodeB.SetValue(temp);
    }

    public void Sort(){
        //Sorts LinkedList
        Node? prev = head;
        if(prev == null) return; //list does not exist yet

        Node? curr = prev.GetNext();
        Node? end = tail;

        //uses bubble sort
        while(prev != end){
            while(curr != end){
                if(prev.GetValue() > curr.GetValue()){
                    SwapNodes(prev, curr);
                }
                prev = prev.GetNext();
                curr = curr.GetNext();
            }

            if(prev.GetValue() > curr.GetValue()){
                SwapNodes(prev, curr);
            }

            end = prev;
            prev = head;
            curr = prev.GetNext();
        }

    }
    public override string ToString(){
        //returns string of all nodes in LinkedList will not work if there is a cycle
        if(IsCircular()){
            return "cycle in list could not get ToString";
        }
        Node? ptr = head;
        string st = "";
        while(ptr != null){
            st += ptr.GetValue()+" ";
            ptr = ptr.GetNext();
        }
        return st;
    }

}
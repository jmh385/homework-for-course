class Node{
    private int Value;
    private Node? Next;

    public Node(int Value=0, Node? Next=null){
        this.Value = Value;
        this.Next = Next;
    }

    public void SetValue(int Value){
        this.Value = Value;
    }

    public int GetValue(){
        return Value;
    }

    public void SetNext(Node Next){
        this.Next = Next;
    }

    public Node? GetNext(){
        return Next;
    }

}
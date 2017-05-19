public class MyQueue : _Queue
{
    public string name;
    public string ip;
    public string ranking = null;
        
    public MyQueue(){}
        
    public MyQueue(string name, string ip, string ranking)
    {
        this.name = name;
        this.ip = ip;
        this.ranking = ranking;
    }
        
}
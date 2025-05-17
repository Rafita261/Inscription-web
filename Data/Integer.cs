public class Integer
{
    private int n = int.MaxValue;
    private string N = "";

    public Integer(int n)
    {
        this.N = n.ToString();
    }
    public Integer(string N)
    {
        int s = 0;
        foreach (var k in N)
        {
            s = s * 10 + (int)new StringReader(k.ToString()).Read() - 48;
        }
        this.n = s;
    }
    public int toInt()
    {
        if (this.n == int.MaxValue)
        {
            return new Integer(this.N).toInt();
        }
        return this.n;
    }
    public string toString()
    {
        if (this.N == "") return this.n.ToString();
        return this.N;
    }
}
 
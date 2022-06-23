namespace HelloWorld
{
  internal class TextData
  {
    public string Text {get; set;}
  }
  internal class TextTokens
  {
    public string[] Tokens {get; set;}
  }
  
  internal class IntString
  {
    private int v;
    private string token;
    
    public IntString(string token)
    {
      this.v = 1;
      this.token = token;
    }
    
    public int getCount()
    {
      return this.v;
    }
    
    public string getToken()
    {
      return this.token;
    }
    public void addValue()
    {
      this.v++;
    }
    
  }
}

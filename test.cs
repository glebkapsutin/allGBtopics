
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class CustomNameAttribute : Attribute
{
    public string Name{get;}
    public CustomNameAttribute(string name)=>this.Name=name;

}
class TestClass
{
    [CustomName("CustomFieldName")]
    public int I { get; set; }
    public string? S { get; set; }
    public decimal D { get; set; }
    public char[]? C { get; set; }

    public TestClass()
    { }
    private TestClass(int i)
    {
    this.I = i;
    }
    public TestClass(int i, string s, decimal d, char[] c):this(i)
    {
    this.S = s;
    this.D = d;
    this.C = c;
    }
      public static TestClass MakeTestclass()
    {
        Type testclass = typeof(TestClass);
        return Activator.CreateInstance(testclass) as TestClass;
       
    }
    public static TestClass MakeTestclass(int i)
    {
        Type testclass = typeof(TestClass);
        return Activator.CreateInstance(testclass, new object[] { i}) as TestClass;
       
    }
    public static TestClass MakeTestclass(int i,string s,decimal d,char [] c)
    {
        Type testclass = typeof(TestClass);
        return Activator.CreateInstance(testclass,new object[]{i,s,d,c}) as TestClass;
       
    }
}
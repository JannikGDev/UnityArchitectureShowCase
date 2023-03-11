using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyTestScript : MonoBehaviour, ITestInterface
{
    public void Test(int testnumber)
    {
        Debug.Log("nö");
    }

    public void Test2(int testnumber)
    {
        
    }
}

public class AssemblyTestScript2 : MonoBehaviour, ITestInterface
{
    public void Test(int testnumber)
    {
        Debug.Log(testnumber);
    }

    public void Test2(int testnumber)
    {
        Debug.Log(testnumber*2);
    }
}


public interface ITestInterface
{
    public void Test(int testnumber);

    public void Test2(int testnumber);
}


public class InterfaceUser
{
    public void UseInterface()
    {
        ITestInterface test = new AssemblyTestScript2();
        
        test.Test(10);

        test.Test2(23);
    }
}
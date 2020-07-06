using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseChar 
{
    private string name;
    private string job;
    private string hobby;
    private string alibi;
    private string car;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Job
    {
        get { return job; }
        set { job = value; }
    }
    public string Hobby
    {
        get { return hobby; }
        set { hobby = value; }
    }
    public string Alibi
    {
        get { return alibi; }
        set { alibi = value; }
    }
    public string Car
    {
        get { return car; }
        set { car = value; }
    }
}

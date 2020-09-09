using System;
using UnityEngine;

public class FeatureTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print(System.Environment.Version);

        var theThing = new Thing();
        var theThingsName = theThing.GetName;
        print(theThingsName);
        
        GetAGreeting(theThingsName, out string greeting); //Inline out parameter, c# 7.0
        print(greeting);

        (string n, string g) data = (theThingsName, greeting); //Named property tuples, c# 7.0
        print($"n: {data.n}, g: {data.g}");

        var moreData = (theThingsName, greeting); //Inferred tuple names, c# 7.1
        print(moreData.greeting);

        int binaryValue = 0b_0101_0101; //Leading underscore for binary and hex literals, c# 7.2
        print(binaryValue);

        var moreData2 = (theThingsName, greeting); //Tuple equality, c# 7.3
        if (moreData == moreData2)
        {
            print("Tuples are equal");
        }

        Point p = new Point() { X = 10.1, Y = 12.4 };
        print(p.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetAGreeting(string name, out string greeting)
    {        
        greeting = $"Hello {name}";
    }

    internal class Thing
    {
        private string Name { get; set; } = "TheThing"; //Auto property initializer, c# 6.0

        public string GetName => Name; //Expression bodied function members, c# 6.0
    }

    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Distance => Math.Sqrt(X * X + Y * Y);

        //adding readonly to this member (a c# 8.0 feature) broke things :(
        public override string ToString() => $"({X}, {Y}) is {Distance} from the origin";
        
    }
}

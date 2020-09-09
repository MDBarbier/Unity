using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatureTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var colour = FromRainbow(Rainbow.Red);
        print($"{colour.r},{colour.g},{colour.b}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Simplified switch statements - C# 8.0 feature
    public static Color FromRainbow(Rainbow colourBand) =>
        colourBand switch
        {
            Rainbow.Red => Color.red,
            Rainbow.Green => Color.green,
            Rainbow.Orange => throw new System.NotImplementedException(),
            Rainbow.Yellow => throw new System.NotImplementedException(),
            Rainbow.Blue => throw new System.NotImplementedException(),
            Rainbow.Indigo => throw new System.NotImplementedException(),
            Rainbow.Violet => throw new System.NotImplementedException(),
            _ => throw new System.NotImplementedException(),
        };

public enum Rainbow
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Violet
    }
}

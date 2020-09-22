using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);    
    [SerializeField] float period = 2f;

    private Vector3 startingPosition;
    private const float tau = Mathf.PI * 2;
    private const float half = 2f;
    private const float offsetVal = 0.5f;
    private const string periodLessThanOrEqualsZeroError = "Period field value cannot be empty or zero!";

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;        
    }

    // Update is called once per frame
    void Update()
    {
        //Check that the period is not zero (or less) to avoid divide by zero exceptions
        if (period <= Mathf.Epsilon)
        {
            Debug.LogError(periodLessThanOrEqualsZeroError);
            return;            
        }

        //Divide the time by our chosen period (arbitrary value) which represents how many "cycles" our game has gone through
        //Using Time.time makes this process frame rate independant
        float cycles = Time.time / period;

        //Calculate the raw sine wave by multiplying our no of cycles by tau then put it through the unity Sin function (which will be between -1 and 1)
        float rawSinWave = Mathf.Sin(cycles * tau);

        //Now we divude our sine wave by the sum of our period and an offset of 0.5 
        //The raw sine is -1 to +1, so we divide by 2 (because we only want movement to half way not all the way back again)
        //and then give an offset to get it to between 0 and 1
        var movementFactor = rawSinWave / half + offsetVal;

        //Multiple the movement vector (direction of travel) by the movement factor we just calculate (how much to move and speed)
        Vector3 offsetPositionForTransform = movementVector * movementFactor;        

        //Apply the offset to our transform
        transform.position = startingPosition + offsetPositionForTransform;        
    }
}

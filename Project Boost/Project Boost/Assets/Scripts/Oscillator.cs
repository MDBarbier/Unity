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

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        print(startingPosition);
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period;

        float rawSinWave = Mathf.Sin(cycles * tau);

        var movementFactor = rawSinWave / 2f + 0.5f;

        Vector3 offset = movementVector * movementFactor;        
        transform.position = startingPosition + offset;        
    }
}

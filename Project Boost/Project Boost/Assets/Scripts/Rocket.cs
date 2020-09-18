using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource audioSource;

    [SerializeField]
    float lateralRotation = 90f;

    [SerializeField]
    float hover = 2f;

    [SerializeField]
    float thrust = 8f;

    [SerializeField]
    int sceneLoadDelay = 1;
    
    [SerializeField]
    States state = States.Alive;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (state == States.Alive)
        {
            HandleThrust();
            HandleLateralRotation(); 
        }

        //todo, stop engine noise on death
    }

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    private void OnCollisionEnter(Collision collision)
    {
        if (state != States.Alive) return;

        var contact = collision.GetContact(0);
        
        switch (collision.transform.gameObject.tag)
        {       
            case "Friendly":                
                break;
            case "Finish":

                if (contact.thisCollider.tag == "Booster")
                {
                    print("Touchdown!");
                    Invoke("LoadNextScene", sceneLoadDelay);
                    state = States.Transcending;
                }

                break;
            case "Hazard":
            default:                         
                print("BOOOOOM");
                state = States.Dying;
                Invoke("LoadInitialScene", sceneLoadDelay);
                break;
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(1); //todo calculate next scene
    }

    private void LoadInitialScene()
    {
        SceneManager.LoadScene(0);
    }

    private void HandleLateralRotation()
    {
        rigidBody.freezeRotation = true; //take manual control of rotation

        var rotation = lateralRotation * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
           transform.Rotate(Vector3.forward * rotation);
        }
        else if (Input.GetKey(KeyCode.D))
        {
           transform.Rotate(Vector3.forward * -rotation);
        }

        rigidBody.freezeRotation = false; //release manual control of rotation
    }

    private void HandleThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ApplyVerticalImpetus(thrust); //Todo refactor delegate
        }
        else if (Input.GetKey(KeyCode.W))
        {
            ApplyVerticalImpetus(hover);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            ApplyVerticalImpetus(-hover);
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void ApplyVerticalImpetus(float velocity)
    {
        rigidBody.AddRelativeForce(new Vector3(0f, velocity, 0f));

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}

public enum States
{
    Alive,Dying,Transcending
}

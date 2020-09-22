using UnityEngine;

public class Rocket : MonoBehaviour
{
    private const string BoosterTag = "Booster";
    private const string FriendlyTag = "Friendly";
    private const string FinishTag = "Finish";
    private const string HazardTag = "Hazard";
    [SerializeField] float lateralRotation = 90f;
    [SerializeField] float hover = 2f;
    [SerializeField] float thrust = 8f;    
    [SerializeField] States state = States.Alive;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] AudioClip explosion;
    [SerializeField] AudioClip missionSuccess;
    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem rearEngineParticles;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem deathParticles;

    private Rigidbody rigidBody;
    private AudioSource audioSource;
    private LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {        
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {        
        ProcessInput();
        HandleThrustParticles();
    }

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider
    private void OnCollisionEnter(Collision collision)
    {
        if (state != States.Alive) return;

        var contact = collision.GetContact(0);

        switch (collision.transform.gameObject.tag)
        {
            case FriendlyTag:
                break;
            case FinishTag:

                if (contact.thisCollider.CompareTag(BoosterTag))
                {
                    state = States.Transcending;
                    audioSource.PlayOneShot(missionSuccess);
                    successParticles.Play();
                    rigidBody.isKinematic = true;
                    levelManager.LoadNextScene();

                }

                break;
            case HazardTag:
            default:
                audioSource.PlayOneShot(explosion);
                deathParticles.Play();
                state = States.Dying;
                levelManager.LoadInitialScene(); //nameof allows you to avoid magic strings for invoke
                break;
        }
    }

    private void HandleThrustParticles()
    {
        if (state == States.Alive)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
            {
                if (!mainEngineParticles.isPlaying)
                {
                    mainEngineParticles.Play();
                }
            }
            else
            {
                if (mainEngineParticles.isPlaying)
                {
                    mainEngineParticles.Stop();
                }
            }

            if (Input.GetKey(KeyCode.S))
            {
                if (!rearEngineParticles.isPlaying)
                {
                    rearEngineParticles.Play();
                }
            }
            else
            {
                if (rearEngineParticles.isPlaying)
                {
                    rearEngineParticles.Stop();
                }
            } 
        }
        else
        {
            mainEngineParticles.Stop();
            rearEngineParticles.Stop();
        }
    }

    private void ProcessInput()
    {
        if (state == States.Alive)
        {
            HandleThrust();
            HandleLateralRotation(); 
        }
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
            PlayAudio(mainEngine);
            ApplyVerticalImpetus(thrust); //todo refactor delegate
        }
        else if (Input.GetKey(KeyCode.W))
        {
            PlayAudio(mainEngine);            
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
        rigidBody.AddRelativeForce(new Vector3(0f, velocity, 0f) * Time.deltaTime);        
    }    

    private void PlayAudio(AudioClip audioClip)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}

public enum States
{
    Alive,Dying,Transcending
}
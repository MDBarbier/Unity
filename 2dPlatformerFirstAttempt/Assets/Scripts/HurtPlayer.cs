using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public LevelManager levelManager;
    public int damageToInflict;
    
    // Start is called before the first frame update
    public void Start()
    {        
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            levelManager.HurtPlayer(damageToInflict);            
        }
    }
}

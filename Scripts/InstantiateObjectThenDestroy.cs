using UnityEngine;

public class UsingInstantiateExample: MonoBehaviour
{
    public RigidBody projectile;
    public Transform positionForProjectilesToAppear;

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RigidBody projectileInstance = Instantiate(projectile, positionForProjectilesToAppear.position, 
                positionForProjectilesToAppear.rotation) as RigidBody;

            projectileInstance.AddForce(positionForProjectilesToAppear.up * 350f);
        }
    }
}

public class DestroyAfterTime: MonoBehaviour
{
    public void Start()
    {
        Destroy(gameObject, 3.5f); //destroys the gameobject the script is attached to after 3.5 seconds
    }
}
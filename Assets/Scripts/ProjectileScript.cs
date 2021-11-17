using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public int projectileBounce = 3;

    
    void Update()
    {
        if (projectileBounce <=0)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (collider.gameObject.tag == "Terrain")
        {
            projectileBounce -= 1;
        }
    }
}

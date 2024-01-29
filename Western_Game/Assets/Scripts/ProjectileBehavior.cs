using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float projectileSpeed;

    public float projectileLifetime = 3;

    private float life = 0;
    void FixedUpdate()
    {

        life += Time.fixedDeltaTime;

        if(life >= projectileLifetime)
        {
            Destroy(gameObject);
        }

        transform.position += transform.forward * projectileSpeed / 1000;
    }
}

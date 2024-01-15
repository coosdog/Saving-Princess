using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    int moveSpeed = 5;
    void Update()
    {
        transform.position += this.transform.forward * Time.deltaTime *moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
            Destroy(gameObject);
    }
}

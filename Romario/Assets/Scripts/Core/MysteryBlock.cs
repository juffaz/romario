using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBlock : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.bounds.max.y < transform.position.y &&
            col.collider.bounds.min.x < transform.position.x + 0.5f &&
            col.collider.bounds.max.x > transform.position.x - 0.5f &&
            col.collider.tag == "Player")
        {
            Debug.Log("Mystery Open");
        }
    }
}

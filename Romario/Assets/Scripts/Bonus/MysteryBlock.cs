using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBlock : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _bonus;

    
    bool isUsing = false;
    private void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.bounds.max.y < transform.position.y &&
            col.collider.bounds.min.x < transform.position.x + 0.5f &&
            col.collider.bounds.max.x > transform.position.x - 0.5f &&
            col.collider.tag == "Player")
        {
            if(isUsing == false) { 

                _animator.SetBool("GoUp", true);
                isUsing = true;

                _bonus.SetBool("GoUp", true);

            }
            else
            {
                
            }
        
        }
    }
}

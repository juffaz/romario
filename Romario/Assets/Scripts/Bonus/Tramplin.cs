using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tramplin : MonoBehaviour
{
    [SerializeField] private float _power = 10f;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
        {
            animator.SetBool("Jump", true);

            col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _power, ForceMode2D.Impulse);
            FindAnyObjectByType<AudioManager>().Play("Jump");
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
        {
            animator.SetBool("Jump", false);
        }
    }

    //private void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.gameObject.CompareTag("Player"))
    //    {
    //        animator.SetBool("Jump", true);

    //        col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _power, ForceMode2D.Impulse);


    //        Debug.Log("enter");
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D col)
    //{
    //    if (col.gameObject.CompareTag("Player"))
    //    {
    //        animator.SetBool("Jump", false);
    //        Debug.Log("exit");
    //    }
    //}


}

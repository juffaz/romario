using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour
{
    [SerializeField] private float _knockbackForce = 20f;
    [SerializeField] private Health _health;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && _health.isStartDamaget == false)
        {
            _health.isStartDamaget = true;
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
            rb.AddForce(knockbackDirection * _knockbackForce, ForceMode2D.Impulse);
            FindAnyObjectByType<AudioManager>().Play("Damage");
            StartCoroutine(WaitDamage());
            
        }
    }

    IEnumerator WaitDamage()
    {
        yield return new WaitForSeconds(.1f);
        _health.RemoveHeart();
        _health.isStartDamaget = false;
    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public Transform[] movePoints;
    private int currentPoint;

    private Rigidbody2D rb;
    private Collider2D col;
    public LayerMask playerLayer;
    public float stompingArea = 0.5f;
    public float sideAttackArea = 0.5f;

    [SerializeField] private Health health;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        

        if (movePoints.Length > 0)
        {
            transform.position = movePoints[0].position;
            currentPoint = 1;
        }
    }

    private void Update()
    {
        Move();
        
    }

    private void Move()
    {
        if (movePoints.Length > 0)
        {
            rb.MovePosition(Vector2.MoveTowards(rb.position, movePoints[currentPoint].position, moveSpeed * Time.deltaTime));

            if (Vector2.Distance(rb.position, movePoints[currentPoint].position) < 0.1f)
            {
                currentPoint = (currentPoint + 1) % movePoints.Length;
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            FindAnyObjectByType<AudioManager>().Play("KillEnemy1");
            Destroy(transform.gameObject);
        }
    }

    IEnumerator DeadEnemy()
    {
        
        yield return new WaitForSeconds(1f);
        Destroy(transform);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerBafs _bufs;

    private void Start()
    {
        _bufs = FindAnyObjectByType<PlayerBafs>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(GetBuf());
        }
    }

    IEnumerator GetBuf()
    {
        _animator.SetBool("isTake", true);
        yield return new WaitForSeconds(.2f);
        _bufs.GetRandomBaf();
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}

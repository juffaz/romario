using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MysteryBox : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    //[SerializeField] private Animator _bonus;
    [SerializeField] private bool isRandom;
    [SerializeField] private List<GameObject> _bonusList;
    [SerializeField] private List<float> _bonusEndValue;
    [SerializeField] private GameObject _bonus;
    [SerializeField] private float _endValue = 1f;

    bool isUsing = false;
    

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.bounds.max.y < transform.position.y &&
            col.collider.bounds.min.x < transform.position.x + 0.5f &&
            col.collider.bounds.max.x > transform.position.x - 0.5f &&
            col.collider.tag == "Player")
        {
            if (isUsing == false)
            {

                _animator.SetBool("GoUp", true);
                isUsing = true;

                CreateBonus();

                FindAnyObjectByType<AudioManager>().Play("OpenBox");
            }
            else
            {

            }

        }
    }

    public void CreateBonus()
    {
        if(isRandom)
        {

            var rand = Random.Range(0, _bonusList.Count);
            var newObj = Instantiate(_bonusList[rand]);


            newObj.transform.position = transform.position;
            newObj.transform.DOMoveY(_bonusEndValue[rand], 0.1f).SetEase(Ease.OutQuad);


        }
        else
        {
            var newObj = Instantiate(_bonus);

            newObj.transform.position = transform.position;
            newObj.transform.DOMoveY(_endValue, 0.1f).SetEase(Ease.OutQuad);
            //newObj.transform.position = new Vector3(transform.position.x, transform.position.y, 40);
            //newObj.transform.DOMoveY(5f, 1f).SetRelative(true).SetEase(Ease.OutQuad);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private GameObject _heartsUi;
    [SerializeField] private GameObject _heartPrefab;
    [SerializeField] private GameObject _shieldPrefab;
    [SerializeField] private List<GameObject> _heartsList;
    [SerializeField] private GameObject _deadPanel;

    public int Value = 3;
    public bool isStartDamaget = false;
    public bool isInvulnerability = false;
    private GameObject shield;
    private void Start()
    {
        Time.timeScale = 1;
        SetHeartOnUi(Value);

        
    }

    private void Update()
    {
        if(Value <= 0)
        {
            _deadPanel.SetActive(true);
            FindAnyObjectByType<AudioManager>().Play("Dead");
            Time.timeScale = 0;
            
        }
    }

    public void SetHeartOnUi(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var newHeart = Instantiate(_heartPrefab);

            newHeart.transform.parent = _heartsUi.transform;
            newHeart.transform.localScale = Vector3.one;
            _heartsList.Add(newHeart);
        }
        
    }

    public void RemoveHeart()
    {
        if(!isInvulnerability)
        {
            Destroy(_heartsList[_heartsList.Count - 1]);
            _heartsList.RemoveAt(_heartsList.Count - 1);

            Value--;
            Debug.Log(_heartsList.Count + " " + Value);
        }
        else
        {
            //TODO: Звук
        }
        
    }

    public void AddHeart()
    {
        var newHeart = Instantiate(_heartPrefab);

        newHeart.transform.parent = _heartsUi.transform;
        newHeart.transform.localScale = Vector3.one;
        _heartsList.Add(newHeart);
        Value++;
        
    }

    public void AddShield()
    {
        if(isInvulnerability)
        {
            var newHeart = Instantiate(_shieldPrefab);

            newHeart.transform.parent = _heartsUi.transform;
            newHeart.transform.localScale = Vector3.one;
            shield = newHeart;
        }
    }

    public void RemoveShield()
    {
        if(isInvulnerability)
        {
            Destroy(shield);
        }
    }

}

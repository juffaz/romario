using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBafs : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private CharacterController2D _characterController;
    [SerializeField] private PlayerMovement _playerMovement;


    public void GetRandomBaf()
    {
        int baf = Random.Range(1, 8);
        Debug.Log(baf);
        switch(baf)
        {
            case 1:
                StartCoroutine(LoweringJump());
                
                break;
            case 2:
                RemoveOneHP();
                break;
            case 3:
                StartCoroutine(LoweringSpeed()); //TODO: Заглушка, поменять на затухание экрана с приколом
                break;
            case 4:
                StartCoroutine(LoweringSpeed());
                break;
            case 5:
                StartCoroutine(Invulnerability());
                break;
            case 6:
                StartCoroutine(IncreaseJump());
                break;
            case 7:
                AddOneHp();
                break;
            case 8:
                StartCoroutine(IncreaseSpeed());
                break;
        }
    }

    public void RemoveOneHP()
    {
        _health.RemoveHeart();
    }

    public void AddOneHp()
    {
        _health.AddHeart();
    }

    IEnumerator Invulnerability()
    {
        _health.isInvulnerability = true;
        _health.AddShield();
        yield return new WaitForSeconds(10f);
        _health.RemoveShield();
        _health.isInvulnerability = false;
    }

    IEnumerator IncreaseJump()
    {
        
        var temp = _characterController.m_JumpForce;
       
        _characterController.m_JumpForce = temp * 1.5f;

        yield return new WaitForSeconds(5f);

        _characterController.m_JumpForce = temp;
        
    }

    IEnumerator LoweringJump()
    {
        var temp = _characterController.m_JumpForce;
        
        _characterController.m_JumpForce = temp * 0.5f;

        yield return new WaitForSeconds(5f);

        _characterController.m_JumpForce = temp;
       
    }

    IEnumerator IncreaseSpeed()
    {
        var temp = _playerMovement.moveSpeed;
        _playerMovement.moveSpeed = temp * 1.5f;

        yield return new WaitForSeconds(5f);

        _playerMovement.moveSpeed = temp;
    }

    IEnumerator LoweringSpeed()
    {
        var temp = _playerMovement.moveSpeed;
        _playerMovement.moveSpeed = temp * 0.5f;

        yield return new WaitForSeconds(5f);

        _playerMovement.moveSpeed = temp;
    }
}

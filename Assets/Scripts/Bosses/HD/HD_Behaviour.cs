using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HD_Behaviour : MonoBehaviour
{
    [SerializeField]
    float _timeToAttack = 2f, _rotationSpeedLookAt;
    float _currentTimeToAttack;

    [SerializeField]
    GameObject _throwFilesGO;

    GameObject _player;
    HD_Dash_Attack _dash_Attack;
    HD_ThrowFiles_Attack _throwFiles_Attack;
    
    [HideInInspector]
    public bool posLocked = false;

    void Start()
    {
        _dash_Attack = GetComponent<HD_Dash_Attack>();
        _throwFiles_Attack = GetComponent<HD_ThrowFiles_Attack>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        if (_currentTimeToAttack <= 0)
        {
            int attack = Random.Range(0, 2);
            switch (attack)
            {
                default:
                    break;
                case 0:
                    DashAttack();
                    _currentTimeToAttack = _timeToAttack;
                    break;
                case 1:
                    ThrowFilesAttack();
                    _currentTimeToAttack = _timeToAttack;
                    break;
            }
            _currentTimeToAttack = _timeToAttack;
        }
        else
            _currentTimeToAttack -= Time.deltaTime;
    }


    private void FixedUpdate()
    {
        if (!posLocked)
        {
            // gira o hd em direção ao jogador de forma suave
            var targetRotation = Quaternion.LookRotation(_player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeedLookAt * Time.deltaTime);
        }
    }

    void DashAttack()
    {
        StartCoroutine(_dash_Attack.SpinIntoPlayer());
    }

    void ThrowFilesAttack()
    {
        Instantiate(_throwFilesGO, transform.position, Quaternion.Euler(new Vector3(45,0,0)));
    }
}

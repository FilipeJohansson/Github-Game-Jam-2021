using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HD_Behaviour : MonoBehaviour
{
    [SerializeField]
    float _timeToAttack = 2f, _rotationSpeedLookAt;
    float _currentTimeToAttack;

    [SerializeField]
    GameObject _throwFilesGO, _discGO;

    GameObject _player;
    HD_Dash_Attack _dashAttack;
    HD_ThrowFiles_Attack _throwFilesAttack;
    HD_Disc_Attack _discAttack;
    
    [HideInInspector]
    public bool rotationLocked = false;

    void Start()
    {
        _dashAttack = GetComponent<HD_Dash_Attack>();
        _throwFilesAttack = GetComponent<HD_ThrowFiles_Attack>();
        _discAttack = GetComponent<HD_Disc_Attack>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }


    void FixedUpdate()
    {

        if (!rotationLocked)
        {
            // gira o hd em direção ao jogador de forma suave
            var targetRotation = Quaternion.LookRotation(_player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeedLookAt * Time.deltaTime);
        }

        if (_currentTimeToAttack <= 0)
        {
            int attack = Random.Range(0, 3);
            switch (attack)
            {
                default:
                    break;
                case 0:
                    if (!rotationLocked)
                    {
                        DashAttack();
                        _currentTimeToAttack = _timeToAttack;
                    }
                    break;
                case 1:
                    ThrowFilesAttack();
                    _currentTimeToAttack = _timeToAttack;
                    break;
                case 2:
                    DiscAttack();
                    _currentTimeToAttack = _timeToAttack;
                    break;
            }
            _currentTimeToAttack = _timeToAttack;
        }
        else
            _currentTimeToAttack -= Time.deltaTime;
    }

    void DiscAttack()
    {
        Instantiate(_discGO, transform.position, Quaternion.Euler(new Vector3(45, 0, 0)));
    }

    void DashAttack()
    {
        StartCoroutine(_dashAttack.SpinIntoPlayer());
    }

    void ThrowFilesAttack()
    {
        Instantiate(_throwFilesGO, transform.position, Quaternion.Euler(new Vector3(45,0,0)));
    }
}

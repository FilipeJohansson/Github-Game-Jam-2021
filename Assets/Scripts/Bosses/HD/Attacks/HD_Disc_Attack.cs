using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HD_Disc_Attack : MonoBehaviour {
    [SerializeField] float _attackDuration, _travelToSpeed, _travelBackSpeed;
    float _currentAttackTime;

    bool _collidedPlayer = false;
    bool _collidedHD = false;
    bool _returning = false;

    GameObject _player, _hd;
    HD_Behaviour _hdBehaviour;

    // Start is called before the first frame update
   /*  void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
        _hd = GameObject.FindGameObjectWithTag("Boss");

        _currentAttackTime = _attackDuration;

        _hdBehaviour = _hd.GetComponent<HD_Behaviour>();
        _hdBehaviour.rotationLocked = true;
    }

    void FixedUpdate() {
        transform.Rotate(new Vector3(0, 0, -30));

        _returning = _currentAttackTime <= 0 || _collidedPlayer ? true : false;

        if (_returning) {
            transform.position = Vector3.Lerp(transform.position, _hd.transform.position, _travelBackSpeed * Time.deltaTime);
            if (_collidedHD) {
                _hdBehaviour.rotationLocked = false;
                Destroy(gameObject);
            }
        } else {
            transform.position = Vector3.Lerp(transform.position, _player.transform.position, _travelToSpeed * Time.deltaTime);
            _currentAttackTime -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Player")
            _collidedPlayer = true;

        if (collision.collider.tag == "Boss")
            _collidedHD = true;
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.collider.tag == "Boss")
            _collidedHD = false;
    } */
}

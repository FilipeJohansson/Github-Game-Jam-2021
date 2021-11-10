using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disc_Attack : Attack_Base {
    [Header("Disc Attack")]
    [SerializeField] float _travelToSpeed;
    [SerializeField] float _travelBackSpeed;
    bool _collidedPlayer = false;
    bool _collidedHD = false;
    bool _returning = false;

    GameObject _hd;
    HD_Behaviour _hdBehaviour;

    // Start is called before the first frame update
   void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        _hd = GameObject.FindGameObjectWithTag("Boss");

        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		transform.forward = mainCamera.transform.forward;

        _hdBehaviour = _hd.GetComponent<HD_Behaviour>();
        _hdBehaviour.posLocked = true;
        _hdBehaviour.isAttacking = true;

        currentTimeToDestroy = timeToDestroy;
    }

    void FixedUpdate() {
        transform.Rotate(new Vector3(0, 0, -30));

        _returning = currentTimeToDestroy <= 0 || _collidedPlayer ? true : false;

        if (_returning) {
            transform.position = Vector3.Lerp(transform.position, _hd.transform.position, _travelBackSpeed * Time.deltaTime);
            if (_collidedHD) {
                _hdBehaviour.posLocked = false;
                _hdBehaviour.isAttacking = false;
                Destroy(gameObject);
            }
        } else {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, _travelToSpeed * Time.deltaTime);
            currentTimeToDestroy -= Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
            _collidedPlayer = true;

        if (other.tag == "Boss")
            _collidedHD = true;
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Boss")
            _collidedHD = false;
    }
}

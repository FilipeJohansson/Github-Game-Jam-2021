using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HD_ThrowFiles_Attack : MonoBehaviour
{
    [SerializeField]
    Sprite[] _FilesSprites;

    [SerializeField]
    float _travelSpeed, timeToDestroy;
    float currentTimeToDestroy;

    GameObject _player;
    Vector3 _target;
    bool _collided = false;

    // Start is called before the first frame update
    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _target = _player.transform.position;
        currentTimeToDestroy = timeToDestroy;
        GetComponent<SpriteRenderer>().sprite = _FilesSprites[Random.Range(0, _FilesSprites.Length)];
    }

    void FixedUpdate()
    {
        if (currentTimeToDestroy <= 0 || _collided)
            Destroy(gameObject);
        else 
        {
            transform.position = Vector3.Lerp(transform.position, _target, _travelSpeed * Time.deltaTime);
            currentTimeToDestroy -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
            _collided = true;
    }
}

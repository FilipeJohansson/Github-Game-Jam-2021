using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HD_ThrowFiles_Attack : MonoBehaviour
{
    [SerializeField]
    Sprite[] _FilesSprites;

    [SerializeField]
    float _travelSpeed, _timeToDestroy;
    float _currentTimeToDestroy;

    GameObject _player;
    Vector3 _target;
    bool _collided = false;
    Sprite _chosenFileSprite;

    // Start is called before the first frame update
    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _target = _player.transform.position;

        _chosenFileSprite = _FilesSprites[Random.Range(0, _FilesSprites.Length)];
        GetComponent<SpriteRenderer>().sprite = _chosenFileSprite;
        
        _currentTimeToDestroy = _timeToDestroy;
    }

    void FixedUpdate()
    {
        if (_currentTimeToDestroy <= 0 || _collided) 
        {
            if (_chosenFileSprite.name != "fileBat.png")
            {
                //TODO: Acionar efeito no player (slow, dano reduzido ou algo assim sei la)
            }

            Destroy(gameObject);
        }
        else 
        {
            // viaja ate o player
            transform.position = Vector3.Lerp(transform.position, _target, _travelSpeed * Time.deltaTime);
            _currentTimeToDestroy -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
            _collided = true;
    }
}

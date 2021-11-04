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

    //public IEnumerator Travel2Player()
    //{
    //    bool travelling = true;
    //    while (travelling)
    //    {
    //        transform.position += Vector3.Lerp(transform.position, _target, _travelSpeed * Time.deltaTime);
    //        transform.Rotate(new Vector3(0, 5, 0));

    //        if (transform.position == _target ||
    //            _collided)
    //        {
    //            Destroy(this.gameObject);
    //            break;
    //        }
    //        else
    //            yield return null;
    //    }
    //}

    void FixedUpdate()
    {
        if (currentTimeToDestroy <= 0 || _collided)
            Destroy(gameObject);
        else 
        {
            //transform.Translate((_target - transform.position) * _travelSpeed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, _target, _travelSpeed * Time.deltaTime);
            currentTimeToDestroy -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _collided = true;
    }
}

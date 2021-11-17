using UnityEngine;

public class PlayerBehaviour : MonoBehaviour, IMovement {
    
    [SerializeField] private float MAX_LIFE = 40;
    [SerializeField] private float _life = 40;

    public void Move(GameObject entity) {
        entity.transform.Translate(Time.deltaTime * 10, 0f, 0f);
    }

    // when player touch in enemy attack it take damage
    // after call to gamecontroller kill the player
    public void TakeDamage(float damage)
    {
        if (_life > 0)
        {
            // just lost life points
            _life -= damage;
            Debug.Log("Life points: " + _life);
            // add a call to game controller show in the IU
        } else
        {
            //dead
        }
    }

    public void ReceiveLife(float lifePoints)
    {
        float aux = _life + lifePoints;
        
        if(aux > MAX_LIFE) _life = MAX_LIFE;
        else _life = aux;
    }
}

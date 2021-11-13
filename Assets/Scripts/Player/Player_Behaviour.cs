using UnityEngine;

public class Player_Behaviour : MonoBehaviour, IMovement {
    
    [SerializeField]
    private float _life = 40;

    public void Move(GameObject entity) {
        entity.transform.Translate(Time.deltaTime * 10, 0f, 0f);
    }

    // when player touch in enemy attack it take damage
    // after call to gamecontroller kill the player
    public void takeDamage(float damage)
    {
        if (_life > 0)
        {
            _life -= damage;
            Debug.Log("Life points: " + _life);
            // just lost life points
        } else
        {
            //dead
        }
    }
}

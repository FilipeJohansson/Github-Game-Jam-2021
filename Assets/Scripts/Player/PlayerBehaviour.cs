using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    [SerializeField] private float MAX_LIFE = 40;
    [SerializeField] private float life = 40;
    [SerializeField] private float moveSpeed = 5;

    private float horizontalInput;
    private float verticalInput;

    void FixedUpdate() {
        Move();
    }

    private void Move() {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime);
    }

    // when player touch in enemy attack it take damage
    // after call to gamecontroller kill the player
    public void TakeDamage(float damage) {
        if (life > 0) {
            // just lost life points
            life -= damage;
            Debug.Log("Life points: " + life);
            // add a call to game controller show in the IU
        } else {
            //dead
        }
    }

    public void ReceiveLife(float lifePoints) {
        float aux = life + lifePoints;

        if (aux > MAX_LIFE) life = MAX_LIFE;
        else life = aux;
    }
}

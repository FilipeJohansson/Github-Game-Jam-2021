using UnityEngine;

public class Player_Behaviour : MonoBehaviour, IMovement {
    public void Move(GameObject entity) {
        entity.transform.Translate(Time.deltaTime * 10, 0f, 0f);
    }
}

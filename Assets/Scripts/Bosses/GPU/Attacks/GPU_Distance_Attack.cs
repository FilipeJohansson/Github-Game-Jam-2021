using UnityEngine;
public class GPU_Distance_Attack : IAttack {
    GameObject owner;

    public GPU_Distance_Attack(GameObject _owner) {
        owner = _owner;
    }

    public void Attack(MonoBehaviour mono) {
        GameObject.Instantiate(GM.GPU_Distance_Projectile, owner.transform.position, owner.transform.rotation);
    }
}

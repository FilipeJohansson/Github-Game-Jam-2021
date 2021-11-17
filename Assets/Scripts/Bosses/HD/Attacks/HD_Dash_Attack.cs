using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HD_Dash_Attack : IAttack {
    GameObject owner;
    bool collided = false;
    [SerializeField] float spinSpeed = 5f;

    public HD_Dash_Attack(GameObject _owner) {
        owner = _owner;
    }

    public void Attack(MonoBehaviour mono) {
        mono.StartCoroutine(SpinIntoPlayer(owner));
    }

    IEnumerator SpinIntoPlayer(GameObject _owner) {
        HDBehaviour hd_behaviour = _owner.GetComponent<HDBehaviour>();

        // delay antes do dash
        yield return new WaitForSeconds(0.5f);

        bool dashing = true;
        hd_behaviour.posLocked = true; // tranca o LookAt do HD

        // pega a posi��o do player quando � acionado o ataque (sem atualizar mais, pra que ele v� na dire��o q o jogador estava e nao a atual)
        Vector3 targetV3 = hd_behaviour.player.transform.position;
        // um vector2 pra poder comparar as posi��es sem se preocupar com Y. aproveito pra arredondar pq se n da uns comportamentos estranhos de lerp infinito. (interessante testar dnv)
        Vector2 targetV2 = new Vector2(Mathf.Round(targetV3.x), Mathf.Round(targetV3.z));

        // enquanto n�o tiver chego no target OU n�o ter encostado no jogador, anda na dire��o do target
        while (dashing) {
            hd_behaviour.isAttacking = true;

            // lerp padrao
            hd_behaviour.transform.position = Vector3.Lerp(hd_behaviour.transform.position, targetV3, spinSpeed * Time.deltaTime);
            hd_behaviour.transform.Rotate(new Vector3(0, 10, 0));

            // vector2 com a posi��o arredondada do HD
            Vector2 currentPos = new Vector2(Mathf.Round(hd_behaviour.transform.position.x), Mathf.Round(hd_behaviour.transform.position.z));

            // se o HD estiver no target ou bateu no player, sai do while
            //Pra n ter q usar o OnCollisionEnter e zoar a Coroutine, acho que um jeito bom seria s� ver se ele vai estar na posi��o do player. Se sim, corta fora
            if (currentPos == targetV2 || collided) {
                break;
            } else {
                yield return null;
            }

        }

        hd_behaviour.posLocked = false;
        hd_behaviour.isAttacking = false;

        yield return null;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
            collided = true;
    }
}

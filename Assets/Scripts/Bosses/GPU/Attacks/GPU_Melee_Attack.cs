using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPU_Melee_Attack : IAttack  {
    GameObject owner;

    [SerializeField] float spinSpeed = 5f;

    public GPU_Melee_Attack(GameObject _owner) {
        owner = _owner;
    }

    public void Attack(MonoBehaviour mono) {
        mono.StartCoroutine(DashIntoPlayer(owner));
    }

    IEnumerator DashIntoPlayer(GameObject _owner) {
        GPU_Behaviour gpu = _owner.GetComponent<GPU_Behaviour>();
        
        // Get the actual pos
        Vector3 initialPos = owner.transform.position;

        bool dashing = true;

        // delay antes do dash
        yield return new WaitForSeconds(0.5f);


        // pega a posi��o do player quando � acionado o ataque (sem atualizar mais, pra que ele v� na dire��o q o jogador estava e nao a atual)
        Vector3 targetV3 = gpu.player.transform.position;
        // um vector2 pra poder comparar as posi��es sem se preocupar com Y. aproveito pra arredondar pq se n da uns comportamentos estranhos de coisa infinita. (interessante testar dnv)
        Vector2 targetV2 = new Vector2(Mathf.Round(targetV3.x), Mathf.Round(targetV3.z));

        // enquanto n�o tiver chego no target OU n�o ter encostado no jogador, anda na dire��o do target
        while (dashing) {
            gpu.posLocked = true; // tranca o LookAt do HD
            
            // lerp padrao
            owner.transform.position = Vector3.Lerp(owner.transform.position, targetV3, spinSpeed * Time.deltaTime);

            // vector2 com a posi��o arredondada do HD
            Vector2 currentPos = new Vector2(Mathf.Round(owner.transform.position.x), Mathf.Round(owner.transform.position.z));

            // se o HD estiver no target ou bateu no player, sai do while
            //TODO: fazer a detec��o de colis�o de forma mais inteligente, pq assim ele vai clippar.
            //Pra n ter q usar o OnCollisionEnter e zoar a Coroutine, acho que um jeito bom seria s� ver se ele vai estar na posi��o do player. Se sim, corta fora
            if (currentPos == targetV2 ||
                currentPos == new Vector2(Mathf.Round(gpu.player.transform.position.x), Mathf.Round(gpu.player.transform.position.z))) {
                yield return new WaitForSeconds(1f);

                while (dashing) {
                    // Lerp to back to initial pos
                    owner.transform.position = Vector3.Lerp(owner.transform.position, initialPos, spinSpeed * Time.deltaTime);

                    currentPos = new Vector2(Mathf.Round(owner.transform.position.x), Mathf.Round(owner.transform.position.z));
                    if (currentPos == new Vector2(Mathf.Round(initialPos.x), Mathf.Round(initialPos.z)))
                        break;
                    else
                        yield return null;
                }

                // TODO: runs attack animation and take damage to player

                break;
            } else
                yield return null;

        }

        gpu.posLocked = false;
    }
}

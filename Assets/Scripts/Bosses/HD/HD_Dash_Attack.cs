using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HD_Dash_Attack : MonoBehaviour
{
    public float spinSpeed;

    GameObject player;
    HD_Behaviour hd_behaviour;

    private void Start()
    {
        hd_behaviour = GetComponent<HD_Behaviour>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // enquanto n tem algo inteligente q manda executar o dash, faz manualmente, fodas
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpinIntoPlayer();
        }
    }

    public IEnumerator SpinIntoPlayer()
    {
        bool dashing = true;
        hd_behaviour.posLocked = true; // tranca o LookAt do HD

        // delay antes do dash
        yield return new WaitForSeconds(0.5f);


        // pega a posição do player quando é acionado o ataque (sem atualizar mais, pra que ele vá na direção q o jogador estava e nao a atual)
        Vector3 targetV3 = player.transform.position;
        // um vector2 pra poder comparar as posições sem se preocupar com Y. aproveito pra arredondar pq se n da uns comportamentos estranhos de coisa infinita. (interessante testar dnv)
        Vector2 targetV2 = new Vector2(Mathf.Round(targetV3.x), Mathf.Round(targetV3.z));

        // enquanto não tiver chego no target OU não ter encostado no jogador, anda na direção do target
        while (dashing)
        {
            // lerp padrao
            transform.position = Vector3.Lerp(transform.position, targetV3, spinSpeed * Time.deltaTime);

            // vector2 com a posição arredondada do HD
            Vector2 currentPos = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.z));

            // se o HD estiver no target ou bateu no player, sai do while
            //TODO: fazer a detecção de colisão de forma mais inteligente, pq assim ele vai clippar.
            //Pra n ter q usar o OnCollisionEnter e zoar a Coroutine, acho que um jeito bom seria só ver se ele vai estar na posição do player. Se sim, corta fora
            if (currentPos == targetV2 ||
                currentPos == new Vector2(Mathf.Round(player.transform.position.x), Mathf.Round(player.transform.position.z)))
            {
                break;
            }
            else
            {
                yield return null;
            }

        }

        hd_behaviour.posLocked = false;
    }

}

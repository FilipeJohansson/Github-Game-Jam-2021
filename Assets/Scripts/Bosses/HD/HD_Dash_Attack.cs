using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HD_Dash_Attack : MonoBehaviour
{
    public float _spinSpeed;

    GameObject _player;
    HD_Behaviour _hd_behaviour;

    bool _collided = false;

    private void Start()
    {
        _hd_behaviour = GetComponent<HD_Behaviour>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public IEnumerator SpinIntoPlayer()
    {
        // delay antes do dash
        yield return new WaitForSeconds(0.5f);

        bool dashing = true;
        _hd_behaviour.rotationLocked = true; // tranca o LookAt do HD

        // pega a posição do player quando é acionado o ataque (sem atualizar mais, pra que ele vá na direção q o jogador estava e nao a atual)
        Vector3 targetV3 = _player.transform.position;
        // um vector2 pra poder comparar as posições sem se preocupar com Y. aproveito pra arredondar pq se n da uns comportamentos estranhos de lerp infinito. (interessante testar dnv)
        Vector2 targetV2 = new Vector2(Mathf.Round(targetV3.x), Mathf.Round(targetV3.z));

        // enquanto não tiver chego no target OU não ter encostado no jogador, anda na direção do target
        while (dashing)
        {
            // lerp padrao
            transform.position = Vector3.Lerp(transform.position, targetV3, _spinSpeed * Time.deltaTime);
            transform.Rotate(new Vector3(0, 10, 0));

            // vector2 com a posição arredondada do HD
            Vector2 currentPos = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.z));

            // se o HD estiver no target ou bateu no player, sai do while
            //Pra n ter q usar o OnCollisionEnter e zoar a Coroutine, acho que um jeito bom seria só ver se ele vai estar na posição do player. Se sim, corta fora
            if (currentPos == targetV2 || _collided)
            {
                break;
            }
            else
            {
                yield return null;
            }

        }

        _hd_behaviour.rotationLocked = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
            _collided = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
            _collided = false;
    }
}

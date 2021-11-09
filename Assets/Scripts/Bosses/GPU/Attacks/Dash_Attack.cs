using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_Attack : MonoBehaviour {
    public GameObject swordObject;
    Transform spriteChild;
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Sprite[] swordsSprite;

    GameObject mainCamera;

    GPU_Behaviour gpu_behaviour;

    public bool isFacing = true;

    // Start is called before the first frame update
    void Awake() {
        gpu_behaviour = GetComponent<GPU_Behaviour>();

        // Get the child that will have the sprite
        spriteChild = swordObject.transform.GetChild(0);
        // Get the sprite renderer of object
        spriteRenderer = spriteChild.GetComponent<SpriteRenderer>();
        // Set the sprite to a random sprite
        spriteRenderer.sprite = swordsSprite[Random.Range(0, swordsSprite.Length)];
    }

    // Update is called once per frame
    void FixedUpdate() {
        LookAtTheCamera();
    }

    void LookAtTheCamera() {
        // Get the main camera object
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        // Do the sword sprite look at the camera
        spriteChild.transform.LookAt(mainCamera.transform);

        float dot = Vector3.Dot(transform.forward, (mainCamera.transform.position - transform.position).normalized);
        if (dot < -0.1f && isFacing)
            Flip();
		else if (dot > 0.1f && !isFacing)
			Flip();
    }

   /*  IEnumerator DashIntoPlayer() {
        // Get the actual pos
        Vector3 initialPos = transform.position;

        bool dashing = true;
        gpu_behaviour.posLocked = true; // tranca o LookAt do HD

        // delay antes do dash
        yield return new WaitForSeconds(0.5f);


        // pega a posi��o do player quando � acionado o ataque (sem atualizar mais, pra que ele v� na dire��o q o jogador estava e nao a atual)
        Vector3 targetV3 = gpu_behaviour.player.transform.position;
        // um vector2 pra poder comparar as posi��es sem se preocupar com Y. aproveito pra arredondar pq se n da uns comportamentos estranhos de coisa infinita. (interessante testar dnv)
        Vector2 targetV2 = new Vector2(Mathf.Round(targetV3.x), Mathf.Round(targetV3.z));

        // enquanto n�o tiver chego no target OU n�o ter encostado no jogador, anda na dire��o do target
        while (dashing) {
            // lerp padrao
            transform.position = Vector3.Lerp(transform.position, targetV3, spinSpeed * Time.deltaTime);

            // vector2 com a posi��o arredondada do HD
            Vector2 currentPos = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.z));

            // se o HD estiver no target ou bateu no player, sai do while
            //TODO: fazer a detec��o de colis�o de forma mais inteligente, pq assim ele vai clippar.
            //Pra n ter q usar o OnCollisionEnter e zoar a Coroutine, acho que um jeito bom seria s� ver se ele vai estar na posi��o do player. Se sim, corta fora
            if (currentPos == targetV2 ||
                currentPos == new Vector2(Mathf.Round(gpu_behaviour.player.transform.position.x), Mathf.Round(gpu_behaviour.player.transform.position.z))) {
                yield return new WaitForSeconds(1f);

                while (dashing) {
                    // Lerp to back to initial pos
                    transform.position = Vector3.Lerp(transform.position, initialPos, spinSpeed * Time.deltaTime);

                    currentPos = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.z));
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

        gpu_behaviour.posLocked = false;
    }
 */
    void Flip() {
		isFacing = !isFacing;

        Vector3 Scaler = spriteChild.transform.localScale;
        Scaler.x *= -1;
        spriteChild.transform.localScale = Scaler;
    }
}

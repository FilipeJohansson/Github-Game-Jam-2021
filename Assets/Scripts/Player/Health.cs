using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public GameManager gameManager;
    private float TOTAL_HEALTH = 10; // quantidade de vida que a poção da

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        
        if (other.tag == "Player")
        {
            gameManager.PlayerReceiveLife(TOTAL_HEALTH);
            Destroy(this.gameObject);
        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HD_Behaviour : MonoBehaviour
{
    public float rotationSpeedLookAt;

    GameObject player;
    HD_Dash_Attack dash_Attack;
    
    [HideInInspector]
    public bool posLocked = false;

    void Start()
    {
        dash_Attack = GetComponent<HD_Dash_Attack>();
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        // enquanto n tem algo inteligente q manda executar o dash, faz manualmente, fodas
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(dash_Attack.SpinIntoPlayer());
        }
    }


    private void FixedUpdate()
    {
        if (!posLocked)
        {
            // gira o hd em direção ao jogador de forma suave
            var targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeedLookAt * Time.deltaTime);
        }
    }
}

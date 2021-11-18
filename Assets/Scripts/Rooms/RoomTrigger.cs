using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomTrigger : MonoBehaviour {
    private RoomEntered roomEntered;
    private UnityAction<GameObject> m_roomEntered;

    private RoomExited roomExited;
    private UnityAction m_roomExited;

    private void Start() {
        if (roomEntered == null)
            roomEntered = new RoomEntered();

        if (roomExited == null)
            roomExited = new RoomExited();

        m_roomEntered += GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>().RoomEntered;
        roomEntered.AddListener(m_roomEntered);

        m_roomExited += GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>().RoomExited;
        roomExited.AddListener(m_roomExited);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
            roomEntered.Invoke(this.gameObject);
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player")
            roomExited.Invoke();
    }

}

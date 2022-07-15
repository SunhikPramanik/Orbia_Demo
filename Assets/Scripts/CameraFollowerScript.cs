using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowerScript : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = this.transform.position-player.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.position+offset;
    }
}

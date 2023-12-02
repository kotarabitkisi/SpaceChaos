using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] Vector3 offset;
    [SerializeField] float speed;
    void Update()
    {

     transform.position += (Player.transform.position+offset- transform.position)*speed;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform m_player = null;
    [SerializeField] private Vector3 offset = new Vector3(0,10,0); 
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 cameraPos = m_player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, cameraPos, 1);
        transform.position = smoothedPosition;
    }
}

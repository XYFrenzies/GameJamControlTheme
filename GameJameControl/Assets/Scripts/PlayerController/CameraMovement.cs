using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform m_player = null;
    [SerializeField] private float height = 10; 
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 cameraPos = m_player.position + new Vector3(0, height, 0);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, cameraPos, 1);
        transform.position = smoothedPosition;
    }
}

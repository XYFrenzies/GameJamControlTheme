using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform m_player = null;
     private Vector3 offset;
    private void Start()
    {
        offset = gameObject.transform.position;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 cameraPos = m_player.position + offset - new Vector3(4.41f, 1, -3.78f);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, cameraPos, 1);
        transform.position = smoothedPosition;
    }
}

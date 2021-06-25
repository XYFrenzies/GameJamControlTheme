using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraMovement : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + offset;
    }
}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//[ExecuteAlways]
//public class CameraMovement : MonoBehaviour
//{
//    [SerializeField] private Transform m_player = null;
//    [SerializeField] private Vector3 offset = Vector3.zero;
//    [SerializeField] private Vector3 rotation = Vector3.zero;
//    private void Start()
//    {
//        offset = gameObject.transform.position;

//    }
//    // Update is called once per frame
//    void LateUpdate()
//    {
//        transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
//        Vector3 cameraPos = m_player.position + offset;
//        Vector3 smoothedPosition = Vector3.Lerp(transform.position, cameraPos, 1);
//        transform.position = smoothedPosition;
//    }
//}

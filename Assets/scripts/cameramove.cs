using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    public float smoothing = 5f;
    Vector3 offset;
    Vector3 offset2;
    private float m_cameraY;
    // Use this for initialization
    void Start()
    {
        offset = transform.position - target.position;
        offset2= transform.position - target2.position;
        m_cameraY = transform.position.y;

    }
 
    // Update is called once per frame
    void LateUpdate()
    {
        if (playercontrol.Dieflag1 != 1)
        {
            Vector3 targetCamPos = target.position + offset;
            targetCamPos.y = m_cameraY;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
        else if(playercontrol.Dieflag1 == 1 && playercontrol2.Dieflag2 != 1)
        {
            Vector3 targetCamPos2 = target2.position + offset2;
            targetCamPos2.y = m_cameraY;
            transform.position = Vector3.Lerp(transform.position, targetCamPos2, smoothing * Time.deltaTime);

        }
    }
}

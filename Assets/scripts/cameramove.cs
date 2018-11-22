using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;
    Vector3 offset;
    private float m_cameraY;
    // Use this for initialization
    void Start()
    {
        offset = transform.position - target.position;
        m_cameraY = transform.position.y;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        targetCamPos.y = m_cameraY;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}

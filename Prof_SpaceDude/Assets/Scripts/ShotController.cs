using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    //CONTROL THE LINE WITH TOUCH

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touches.Length > 0)
        {
            Ray r = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hitInfo;
            /*
            if (Physics2D.Raycast(r);
            {
                GameObject g = hitInfo.collider.gameObject;
                transform.position = hitInfo.point + 0.1f * Vector3.up;
            }
            */
        }
    }
}

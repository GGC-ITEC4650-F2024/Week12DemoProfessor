using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRubberBand : MonoBehaviour
{
    Transform camSpotTran;

    public float strength;

    // Start is called before the first frame update
    void Start()
    {
        camSpotTran = GameObject.Find("CamSpot").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            camSpotTran.position,
            Time.deltaTime * strength
        );
    }
}

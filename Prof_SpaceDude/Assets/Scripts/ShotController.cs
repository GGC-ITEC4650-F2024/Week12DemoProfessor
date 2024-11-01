using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float knockBackPower;

    //CONTROL THE LINE WITH TOUCH
    LineRenderer myLine;
    Rigidbody2D myBod;

    // Start is called before the first frame update
    void Start()
    {
        myLine = GetComponentInChildren<LineRenderer>();
        //hide the line by setting endpoints to the same spot
        myLine.SetPosition(0, Vector3.zero);
        myLine.SetPosition(1, Vector3.zero);

        myBod = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Touch[] fingers = Input.touches;
        if (fingers.Length > 0)
        {
            Touch t = fingers[0];
            Vector3 fingerPos = scenePos(t.position);
            if (t.phase == TouchPhase.Began)
            {
                myLine.SetPosition(0, fingerPos);
                myLine.SetPosition(1, fingerPos);
            }
            else if (t.phase == TouchPhase.Moved)
            {
                myLine.SetPosition(1, fingerPos);
                Vector3 dir = myLine.GetPosition(1) - myLine.GetPosition(0);
                transform.right = dir;
            }
            else if (t.phase == TouchPhase.Ended)
            {
                Vector3 lineVec = myLine.GetPosition(1) - myLine.GetPosition(0);
                shoot(lineVec);

                if (fingers.Length == 1)
                {
                    myBod.AddForce(-1 * lineVec * knockBackPower, ForceMode2D.Impulse);
                }

                myLine.SetPosition(0, Vector3.zero);
                myLine.SetPosition(1, Vector3.zero);
            }
        }
    }

    private void shoot(Vector3 v)
    {
        GameObject bullet = GameObject.Instantiate(bulletPrefab,
            transform.position + transform.right, Quaternion.identity);
        bullet.transform.localScale = new Vector3(v.magnitude, v.magnitude, v.magnitude);
        
        //set the player as immune from this bullet.
        bullet.GetComponent<BulletController>().immuneGO = gameObject;
        
        Rigidbody2D bod = bullet.GetComponent<Rigidbody2D>();
        bod.velocity = v * bulletSpeed;
    }

    private Vector3 scenePos(Vector3 screenPos)
    {
        Ray r = Camera.main.ScreenPointToRay(screenPos);
        RaycastHit2D hitInfo = Physics2D.Raycast(r.origin, r.direction);
        return hitInfo.point;
    }
}

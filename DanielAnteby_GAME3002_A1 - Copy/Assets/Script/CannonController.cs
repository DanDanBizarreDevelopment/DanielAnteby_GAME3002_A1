using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonController : MonoBehaviour
{
    //Cannon Rotation Variables
    public int speed;
    public float friction;
    public float lerpSpeed;
    float xDegrees;
    float yDegrees;
    Quaternion fromRotation;
    Quaternion toRotation;
    Camera look;

    //Cannon Firing Variables
    public GameObject cannonBall;
    public Slider slider;
    Rigidbody cannonBallRB;
    public Transform shotPos;
    public float firePower;
    public int powerMultiplier;


    // Start is called before the first frame update
    void Start()
    {
            look = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = look.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            //Hold Left-Click and move Mouse to move rotate the Cannon
            if (hit.transform.gameObject.tag == "Cannon")
            {
                if (Input.GetMouseButton(0))
                {
                    xDegrees -= Input.GetAxis("Mouse Y") * speed * friction;
                    yDegrees += Input.GetAxis("Mouse X") * speed * friction;
                    fromRotation = transform.rotation;
                    toRotation = Quaternion.Euler(xDegrees, yDegrees, 0);
                    transform.rotation = Quaternion.Lerp(fromRotation, toRotation, Time.deltaTime * lerpSpeed);
                }
            }
        }

    }

    public void FireCannon()
    {
        firePower = slider.value * powerMultiplier;
        GameObject cannonBallCopy = Instantiate(cannonBall, shotPos.position, transform.rotation) as GameObject;
        cannonBallRB = cannonBallCopy.GetComponent<Rigidbody>();
        cannonBallRB.AddForce(transform.up * firePower);
    }
}

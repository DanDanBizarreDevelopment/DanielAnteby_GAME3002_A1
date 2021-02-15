using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{

    public float lifeTime = 5f;
    public float minY = -20f;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = (GameManager)FindObjectOfType(typeof(GameManager));   
    }

    // Update is called once per frame
    void Update()
    {
        StatusCheck();
    }

    void StatusCheck()
    {
        lifeTime -= Time.deltaTime;
        //Destroy CannonBall when timer runs out
        if(lifeTime < 0)
        {
            CannonBallDestroy();
        }
        //Destroy CannonBall when it falls too low below Plane
        if(transform.position.y < minY)
        {
            CannonBallDestroy();
        }
    }

    void CannonBallDestroy()
    {
        Destroy(this.gameObject);
    }


    //Destroy Cannonball when it hits the target
    private void OnCollisionEnter(Collision collision)
    {
     if (collision.gameObject.tag == "GreenTarget")
        {
            gameManager.GreenTargetHit();
            CannonBallDestroy();
        }

        if (collision.gameObject.tag == "YellowTarget")
        {
            gameManager.YellowTargetHit();
            CannonBallDestroy();
        }

        if (collision.gameObject.tag == "RedTarget")
        {
            gameManager.RedTargetHit();
            CannonBallDestroy();
        }
    }
}

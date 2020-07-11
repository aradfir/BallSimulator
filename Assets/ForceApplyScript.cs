using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceApplyScript : MonoBehaviour
{
    private Assets.BallType ballType;

    internal BallType BallType { get => ballType; set => ballType = value; }
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.drag = 0;
        
        
     //   BallType = new BallType("red", Color.red, 0.01f);
     //   BallType.Radius = 0.2f;
     //   BallType.Forces.Add(BallType, Relation.GetRandomRelation(BallType, BallType, 1500f, 100f));
        GetComponent<SpriteRenderer>().color = ballType.Color;
        transform.localScale *= BallType.Radius*2;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] gobj=GameObject.FindGameObjectsWithTag("ball");
        rb.velocity *= (1 - ballType.FrictionMult)*Time.deltaTime*Time.timeScale;
        //Debug.LogError(gobj.Length);
        foreach (GameObject otherBall in gobj)
        {
            if (otherBall.transform==this.transform)
            {
                continue;
            }
            ForceApplyScript script = otherBall.GetComponent<ForceApplyScript>();
            BallType otherType=script.BallType;
           // Debug.Log(otherType.Equals(this.ballType));
            //Debug.Log(otherType.Name);

            Relation relationOfBalls;
            
            ballType.Forces.TryGetValue(otherType, out relationOfBalls);
            Vector2 diff=otherBall.transform.position - this.gameObject.transform.position;
            float force=relationOfBalls.interpolateForce(diff.magnitude);
            Debug.Log(force);
            if(relationOfBalls.Attract)
            {
                rb.AddForce(diff.normalized* force*Time.deltaTime* Time.timeScale);
            }
            else
            {
                rb.AddForce(-diff.normalized * force* Time.deltaTime* Time.timeScale);
            }
            
        }
        //float vertExtent = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize;
        //var horzExtent = vertExtent * Screen.width / Screen.height;
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x , -horzExtent + BallType.Radius, horzExtent - BallType.Radius), Mathf.Clamp(transform.position.y,  -vertExtent + BallType.Radius, vertExtent - BallType.Radius));
        
    }
}

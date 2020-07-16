using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceApplyScript : MonoBehaviour
{
    private Assets.BallType ballType;

    internal BallType BallType { get => ballType; set => ballType = value; }
    Rigidbody2D rb;
    static List<ForceApplyScript> everyObject;
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
        if (everyObject == null)
            everyObject = new List<ForceApplyScript>();
        everyObject.Add(this);
    }

    void FixedUpdate()
    {
        //*Time.deltaTime
        rb.velocity *= (1 - ballType.FrictionMult)*Time.timeScale;
        //Debug.LogError(gobj.Length);
        foreach (ForceApplyScript script in everyObject)
        {
            if (script==this)
            {
                continue;
            }
            
            BallType otherType=script.BallType;
           // Debug.Log(otherType.Equals(this.ballType));
            //Debug.Log(otherType.Name);

            Relation relationOfBalls;
            

            ballType.Forces.TryGetValue(otherType, out relationOfBalls);
            Vector2 diff=script.gameObject.transform.position - this.gameObject.transform.position;
            
            float force=relationOfBalls.interpolateForce(diff.magnitude);
            if(relationOfBalls.Attract)
            {
                rb.AddForce(diff.normalized* force* Time.timeScale);
            }
            else
            {
                rb.AddForce(-diff.normalized * force* Time.timeScale);
            }
            
        }
        //float vertExtent = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize;
        //var horzExtent = vertExtent * Screen.width / Screen.height;
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x , -horzExtent + BallType.Radius, horzExtent - BallType.Radius), Mathf.Clamp(transform.position.y,  -vertExtent + BallType.Radius, vertExtent - BallType.Radius));
        
    }
}

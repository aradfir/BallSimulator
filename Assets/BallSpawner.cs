using Assets;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class BallSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    Random R = new Random();
    private Color getRandomColor()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    public static OrderedDictionary typesAndCounts;
    public GameObject newType;
    public GameObject newRelation;
    public GameObject circleUnitPrefab;
    void Start()
    {
        typesAndCounts = new OrderedDictionary();
        newType.SetActive(true);
        newRelation.SetActive(false);
        // BallType t1 = new BallType("1", getRandomColor(), 0.03f,new Dictionary<BallType, Relation>(),0.5f);
        // BallType t2 = new BallType("2", getRandomColor(), 0.03f, new Dictionary<BallType, Relation>(), 0.4f);
        // BallType t3 = new BallType("3", getRandomColor(), 0.03f, new Dictionary<BallType, Relation>(), 0.3f);
         //t1.Forces.Add(t2, Relation.GetRandomRelation(t1, t2, 2000f, 100f));
        // t1.Forces.Add(t3, Relation.GetRandomRelation(t1, t3, 2000f, 10f));
        // t1.Forces.Add(t1, Relation.GetRandomRelation(t1, t1, 100f, 1000f));
        //
        // t2.Forces.Add(t2, Relation.GetRandomRelation(t2, t2, 2000f, 100f));
        // t2.Forces.Add(t3, Relation.GetRandomRelation(t2, t3, 2000f, 10f));
        // t2.Forces.Add(t1, Relation.GetRandomRelation(t2, t1, 1000f, 1000f));
        //
        // t3.Forces.Add(t2, Relation.GetRandomRelation(t3, t2, 2000f, 100f));
        // t3.Forces.Add(t3, Relation.GetRandomRelation(t3, t3, 20f, 100000f));
        // t3.Forces.Add(t1, Relation.GetRandomRelation(t3, t1, 1000f, 1000f));
        // for (int i = 0; i < 5; i++)
        // {
        //
        //     GameObject unit = Instantiate<GameObject>(circleUnitPrefab, Random.insideUnitCircle * 15, Quaternion.identity);
        //     unit.GetComponent<ForceApplyScript>().BallType = t1;
        // }
        // for (int i = 0; i < 10; i++)
        // {
        //
        //     GameObject unit = Instantiate<GameObject>(circleUnitPrefab, Random.insideUnitCircle * 15, Quaternion.identity);
        //     unit.GetComponent<ForceApplyScript>().BallType = t2;
        // }
        // for (int i = 0; i < 15; i++)
        // {
        //
        //     GameObject unit = Instantiate<GameObject>(circleUnitPrefab, Random.insideUnitCircle * 15, Quaternion.identity);
        //     unit.GetComponent<ForceApplyScript>().BallType = t3;
        // }
    }
    public void spawn()
    {
        foreach(BallType type in typesAndCounts.Keys)
        {
            for(int i=0;i<(int)typesAndCounts[type]; i++)
            {
                GameObject unit = Instantiate<GameObject>(circleUnitPrefab, Random.insideUnitCircle * 15, Quaternion.identity);
                unit.GetComponent<ForceApplyScript>().BallType = type;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

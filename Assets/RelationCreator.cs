using Assets;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RelationCreator : MonoBehaviour
{
    private int i = 0, j = 0;
    public Text AppliedBy;
    public Text AppliedTo;
    public InputField minDist;
    public InputField maxDist;
    public InputField peakDist;
    public InputField peakVal;
    public Toggle attract;
    public GameObject relationCreatorPanel;
    public static BallType appliedOn;
    public static BallType appliedFrom;
    private void endRelationMaking()
    {
        CameraMoveScript.enableMovement = true;
        relationCreatorPanel.SetActive(false);
        Component.FindObjectOfType<BallSpawner>().spawn();
        return;

    }
    public void addRelation()
    {
       
        int size = BallSpawner.typesAndCounts.Count;
        Relation r = new Relation(appliedOn, appliedFrom, attract.isOn, float.Parse(maxDist.text), float.Parse(peakVal.text), float.Parse(minDist.text), float.Parse(peakDist.text));
        appliedOn.Forces.Add(appliedFrom, r);
        j++;
        
        if (j >= size)
        {
            //define relations for next type;
            j = 0;
            i++;

        }
        if(i>=size)
        {
            //spawn balls
            endRelationMaking();
            return;
        }
        appliedOn = (BallType)BallSpawner.typesAndCounts.Cast<DictionaryEntry>().ElementAt(i).Key;
        appliedFrom = (BallType)BallSpawner.typesAndCounts.Cast<DictionaryEntry>().ElementAt(j).Key;
        AppliedTo.text = "Applied to :" + (appliedOn).Name;
        AppliedBy.text = "Applied by :" + (appliedFrom).Name;
        minDist.text = "";
        maxDist.text = "";
        peakDist.text = "";
        peakVal.text = "";

    }
    public void randomize()
    {
        Relation r = Relation.GetRandomRelation(appliedOn, appliedFrom, 20f, 20f);
        minDist.text = r.MinEffectiveRange.ToString();
        maxDist.text = r.MaxEffectiveRange.ToString();
        peakDist.text = r.PeakDistance.ToString();
        attract.isOn = r.Attract;
        peakVal.text = r.PeakValue.ToString();
    }
    public void randomizeRest(){
        //addRelation();
        int size = BallSpawner.typesAndCounts.Count;
        for (; i < size; i++)
        {
            for(j=0;j<size;j++)
            {
                BallType appliedOn = (BallType)BallSpawner.typesAndCounts.Cast<DictionaryEntry>().ElementAt(i).Key;
                BallType appliedFrom = (BallType)BallSpawner.typesAndCounts.Cast<DictionaryEntry>().ElementAt(j).Key;
                appliedOn.Forces.Add(appliedFrom, Relation.GetRandomRelation(appliedOn, appliedFrom, 20f, 20f));
            }
        }
        endRelationMaking();
    }

}

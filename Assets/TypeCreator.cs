using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets;
using System.Linq;

public class TypeCreator : MonoBehaviour
{
    public InputField inputRadius;
    public InputField inputName;
    public InputField inputFriction;
    public InputField countInput;
    public InputField color;
    

    public GameObject newType;
    public GameObject newRelation;

    public Text relationAppliedOn; 
    public Text relationAppliedFrom;
    public void addType()
    {
        Color finalColor = new Color();
        Debug.Log(ColorUtility.TryParseHtmlString(color.text, out finalColor));
        BallSpawner.typesAndCounts.Add(new BallType(inputName.text, finalColor, float.Parse(inputFriction.text), new Dictionary<BallType, Relation>(), float.Parse(inputRadius.text)), int.Parse(countInput.text));
        inputName.text = "";
        inputRadius.text = "";
        inputFriction.text = "";
        countInput.text = "";
        
    }
    public void doneTypes()
    {
        addType();
        newType.SetActive(false);
        newRelation.SetActive(true);
         RelationCreator.appliedOn = (BallType)BallSpawner.typesAndCounts.Cast<DictionaryEntry>().ElementAt(0).Key;
        RelationCreator.appliedFrom = (BallType)BallSpawner.typesAndCounts.Cast<DictionaryEntry>().ElementAt(0).Key;

        relationAppliedOn.text = "Applied to :"+ RelationCreator.appliedOn.Name;
        relationAppliedFrom.text = "Applied on :"+ RelationCreator.appliedFrom.Name;


    }
  
}

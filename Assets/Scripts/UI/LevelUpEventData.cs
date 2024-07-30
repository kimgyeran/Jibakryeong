using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelUP Data", menuName = "Scriptable Object/LevelUP Data", order = int.MaxValue)]
public class LevelUpEventData : ScriptableObject
{ 
    [SerializeField]
    private string eventName;
    public string EventName { get { return eventName; } }
    [SerializeField]
    private string description;
    public string Description { get {

            string modify = description.Replace("{Impact}", ((int)Impact).ToString()+"%");
            return modify;
        } }
    [SerializeField]
    private int eventId;
    public int EventId { get { return eventId; } }

    [SerializeField]
    private int pictureId;
    public int PictureId { get { return pictureId; } }

    [SerializeField]
    private int minImpact;
    [SerializeField]
    private int maxImpact;
    private int? impact = null;
    public int? Impact { get {

            if (impact == null )
            {
                impact = Random.Range(minImpact, maxImpact+1);
            }
            else if (used == true)
            {
                used = false;
                impact = Random.Range(minImpact, maxImpact + 1);
            }
            return impact;
        } }

    public bool used = false;

}
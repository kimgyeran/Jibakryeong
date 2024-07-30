using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_LevelUpCardController : MonoBehaviour, IPointerClickHandler
{
    public static UI_LevelUpCardWrapper wrapper = null;
    public LevelUpEventData data;
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        wrapper.OnCardSelected(data);
    }


    public void applyData()
    {
        LevelUpPicture.sprite = getImage(data.PictureId);
        LevelUpName.text = data.EventName;
        LevelUpDescription.text = data.Description;
        data.used = true;
    }

    private Sprite getImage(int index)
    {
        Sprite temp = null;
        switch(index)
        {
            case 0:
                temp = Resources.Load<Sprite>("UI/Images/Skill_Scream");
                break;
            case 1:
                temp = Resources.Load<Sprite>("UI/Images/Skill_Attack");
                break;
            case 2:
                temp = Resources.Load<Sprite>("UI/Images/LevelUP");
                break;
        }
        return temp;
    }

    Image LevelUpPicture;
    Text LevelUpName;
    Text LevelUpDescription;
    private void Start()
    {
        LevelUpPicture = transform.GetChild(0).GetComponent<Image>();
        LevelUpName = transform.GetChild(1).GetComponent<Text>();
        LevelUpDescription = transform.GetChild(2).GetComponent<Text>();
    }
}

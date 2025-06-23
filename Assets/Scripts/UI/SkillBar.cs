using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBar : MonoBehaviour
{
    [Header("技能图标")]
    [SerializeField]
    private Image skillIcon;
    [Header("技能图标列表")]
    [SerializeField]
    private List<Sprite> skillSprites;

    private void OnEnable()
    {
        EventHandler.UpdateSkillBarEvent += UpdateSkillIcon;
    }

    private void OnDisable()
    {
        EventHandler.UpdateSkillBarEvent -= UpdateSkillIcon;
    }

    private void UpdateSkillIcon(E_SkillType type)
    {
        switch(type)
        {
            case E_SkillType.BigBone:
                skillIcon.sprite = skillSprites[(int)E_SkillType.BigBone];
                break;
            case E_SkillType.IceCream:
                skillIcon.sprite = skillSprites[(int)E_SkillType.IceCream];
                break;
            case E_SkillType.Shell:
                skillIcon.sprite = skillSprites[(int)E_SkillType.Shell];
                break;
            case E_SkillType.Egg:
                skillIcon.sprite = skillSprites[(int)E_SkillType.Egg];
                break;
        }
    }
}

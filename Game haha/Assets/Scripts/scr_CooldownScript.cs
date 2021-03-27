using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scr_CooldownScript : MonoBehaviour
{
    TextMeshPro cooldownText;
    Ability abilityController;
    public int abilityNumber;

    private void Start()
    {
        cooldownText = GetComponent<TextMeshPro>();
        Debug.Log("obj_SkillAbility" + abilityNumber.ToString("n0"));
        abilityController = GameObject.Find("obj_SkillAbility"+abilityNumber.ToString("n0")).GetComponent<Ability>();

    }

    private void FixedUpdate()
    {
        if (abilityController.GetCooldown() != 0) { cooldownText.SetText(abilityController.GetCooldown().ToString("##0.0")); }
        else { cooldownText.SetText(abilityController.GetCooldown().ToString(" ")); }
        
    }
}

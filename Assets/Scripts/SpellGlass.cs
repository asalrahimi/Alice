using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpellGlass : MonoBehaviour
{
    private static GameObject spell;
    private TextMeshProUGUI collectedSpellTxt;
    private GameObject textProObj;

    public void UpdateSpellCount() 
    {
        Debug.Log(ProjectalBehavior.Spell);
        textProObj = GameObject.Find("PlayerSpellCount");
        collectedSpellTxt = textProObj.GetComponent<TextMeshProUGUI>();
        collectedSpellTxt.text = ProjectalBehavior.Spell.ToString();
    }

    public static void Collect(Collision2D collision) 
    {
        //find current spell
        spell = GameObject.Find(collision.transform.name);

        //destroy current spell after collision
        Destroy(spell);

        //update count of collected spell
        ProjectalBehavior.Spell += 1;
        SpellGlass spellIns = new SpellGlass();
        spellIns.UpdateSpellCount();
    }
}

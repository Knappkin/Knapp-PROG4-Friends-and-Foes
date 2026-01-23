using UnityEngine;

[CreateAssetMenu(fileName = "Spells", menuName = "Scriptable Objects/Spells")]
public class Spells : ScriptableObject
{
    public string spellName;
    public float manaCost;
}

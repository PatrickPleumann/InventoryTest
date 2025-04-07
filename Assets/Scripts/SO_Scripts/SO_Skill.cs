using UnityEngine;

[CreateAssetMenu(fileName = "SO_Skill", menuName = "Scriptable Objects/SO_Skill")]
public class SO_Skill : ScriptableObject
{
    
    public enum SkillTypes { SingleTarget, AOE, Shield}

    [SerializeField] public SkillTypes skillTypes;
    [SerializeField] public float damage;
    [SerializeField] public Sprite icon;
}

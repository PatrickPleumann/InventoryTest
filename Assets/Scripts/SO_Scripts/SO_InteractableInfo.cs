using UnityEngine;

[CreateAssetMenu(fileName = "SO_InteractableInfo", menuName = "Interactables/InteractableInfo")]
public class SO_InteractableInfo : ScriptableObject
{
    [SerializeField] public string inputAction;
    [SerializeField] public string callToAction;
}

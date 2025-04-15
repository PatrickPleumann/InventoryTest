using TMPro;
using UnityEngine;
using UnityEngine.Events;

//public class SwitchInteractable : IAmInteractable
//{
//    public UnityEvent OnSwitchOn;
//    public UnityEvent OnSwitchOff;

//    public Color ColorOff = Color.green;
//    public Color ColorOn = Color.red;

//    private bool switchIsOn = false;

//    private MeshRenderer meshRenderer;


//    private void Awake()
//    {
//        meshRenderer = GetComponent<MeshRenderer>();
//    }
//    public override void Interact()
//    {
//        switchIsOn = !switchIsOn;
//        if (switchIsOn)
//        {
//            SwitchOff();
//        }
//        if (!switchIsOn)
//        {
//            SwitchOn();
//        }
//    }

//    private void SwitchOn()
//    {
//        ChangeColor(ColorOn);
//        OnSwitchOn?.Invoke();
//    }

//    private void SwitchOff()
//    {
//        ChangeColor(ColorOff);
//        OnSwitchOff?.Invoke();
//    }

//    private void ChangeColor(Color _color)
//    {
//        meshRenderer.material.color = _color;
//    }
//}

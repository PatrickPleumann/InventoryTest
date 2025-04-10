using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableInfoPresenter : MonoBehaviour
{
    public InteractableInfoProvider model;
    public InteractableView view;
    public ClosestTargetProvider targetProvider;
    public PlayerInput input;

    private Interactable closestInteractable;

    private bool hasValidModel;
    private bool modelChanged;
    private void Update()
    {
        UpdateModel();

        if (hasValidModel == true && modelChanged == false)
        {
            ShowView();
        }
        if (hasValidModel == true && modelChanged == true)
        {
            UpdateView();
            ShowView();
        }
        if (hasValidModel == false)
        {
            HideView();
        }
    }

    private void UpdateModel()
    {
        hasValidModel = false;

        closestInteractable = targetProvider.GetTarget<Interactable>();
        if (closestInteractable == false)
        {
            return;
        }

        var newInteractableInfoProvider = closestInteractable.GetComponent<InteractableInfoProvider>();
        if (model == false)
        {
            return;
        }

        modelChanged = model != newInteractableInfoProvider;
        if (modelChanged)
        {
            model = newInteractableInfoProvider;
        }

        hasValidModel = true;
    }

    private void ShowView()
    {
        view.Show();
    }
    private void HideView()
    {
        view.Hide();
    }

    private void UpdateView()
    {
        var interactableInfo = model.interactableInfo;
        var inputKey = input.actions[interactableInfo.inputAction].GetBindingDisplayString();
        var callToAction = interactableInfo.callToAction;

        view.Setup(callToAction, inputKey);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Action_StartDialog : BaseAction
{
    [SerializeField]
    DialogObject dialog;
    
    [SerializeField]
    UnityEvent OnDialogFinished;
    
    public override void X_PerformAction()
    {
        IDialogService dialogService = Game.Services.GetService<IDialogService>();
        dialogService.ShowDialog(dialog, DialogCallback);
    }

    private void DialogCallback()
    {
        OnDialogFinished.Invoke();
    }
}

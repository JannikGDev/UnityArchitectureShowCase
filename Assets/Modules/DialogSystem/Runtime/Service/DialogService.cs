using System;
using System.Collections;
using System.Collections.Generic;
using Modules.Core.ServiceLocator;
using UnityEngine;

public class DialogService : BaseService<IDialogService>, IDialogService
{
    [SerializeField] 
    private DialogBaseServiceConfig config;

    public void ShowDialog(DialogObject dialog, Action dialogFinishedCallback = null)
    {
        var dialogController = GameObject.Instantiate<DialogController>(config.dialogDisplay);
        dialogController.finishCallback = dialogFinishedCallback;
        dialogController.StartDialog(dialog);
        
    }
}

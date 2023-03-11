using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDialogService : IGameService
{
    public void ShowDialog(DialogObject dialog, Action dialogFinishedCallback = null);
}

public class DummyDialogService : IDialogService
{
    public void ShowDialog(DialogObject dialog, Action dialogFinishedCallback = null)
    {
        
    }
}

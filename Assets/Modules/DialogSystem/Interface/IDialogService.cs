using System;

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
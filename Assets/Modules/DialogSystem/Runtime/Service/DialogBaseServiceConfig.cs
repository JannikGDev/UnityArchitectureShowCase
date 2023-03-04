using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Systems/Dialog/Config")]
public class DialogBaseServiceConfig : BaseServiceConfig<IDialogService>
{
    [SerializeField] 
    public DialogController dialogDisplay;
}

using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI dialogText;
    
    [SerializeField]
    private Image LeftAvatar;
    
    [SerializeField]
    private TextMeshProUGUI LeftName;
    
    [SerializeField]
    private GameObject LeftNamePlate;
    
    [SerializeField]
    private Image RightAvatar;
    
    [SerializeField]
    private GameObject RightNamePlate;
    
    [SerializeField]
    private TextMeshProUGUI RightName;


    [SerializeField] private Color activeTint = Color.white;
    [SerializeField] private Color inactiveTint = new Color(0.5f, 0.5f, 0.5f);
    
    private DialogObject dialog;

    public Action finishCallback;

    public void Continue()
    {
        var totalPages = dialogText.textInfo.pageCount;
        if (dialogText.pageToDisplay < totalPages)
            dialogText.pageToDisplay++;
        else
            OnPartEnd();
    }
    
    public void StartDialog(DialogObject dialog)
    {
        this.dialog = dialog;
        ShowPart(this.dialog.Part);
    }

    public void ShowPart(DialogPart part)
    {
        dialogText.pageToDisplay = 1;
        dialogText.text = dialog.Part.Text;
        
        LeftAvatar.sprite = part.LeftAvatar;
        RightAvatar.sprite = part.RightAvatar;
        
        RightAvatar.gameObject.SetActive(part.RightAvatar != null);
        LeftAvatar.gameObject.SetActive(part.LeftAvatar != null);
        
        LeftName.text = part.LeftName;
        RightName.text = part.RightName;
        
        LeftNamePlate.gameObject.SetActive(LeftName.text.Length > 0);
        RightNamePlate.gameObject.SetActive(RightName.text.Length > 0);
        
        LeftAvatar.color = part.LeftActive ? activeTint : inactiveTint;
        RightAvatar.color = part.RightActive ? activeTint : inactiveTint;
        LeftName.color = part.LeftActive ? activeTint : inactiveTint;
        RightName.color = part.RightActive ? activeTint : inactiveTint;
    }
    
    public void OnPartEnd()
    {
        if(!dialog.NextPart())
            OnDialogEnd();

        ShowPart(dialog.Part);
    }

    public void OnDialogEnd()
    {
        finishCallback?.Invoke();
        Destroy(this.gameObject);
    }
}

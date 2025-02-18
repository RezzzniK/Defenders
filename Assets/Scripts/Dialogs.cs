using TMPro;
using UnityEngine;

public class Dialogs : MonoBehaviour
{
    [SerializeField] string [] timeLineTextLines;
    [SerializeField] TMP_Text dialougeText;
    int currentDialouge=0;

    public void NextDialouge(){//to make this method be accssesable in Unity
        currentDialouge++;
        dialougeText.SetText(timeLineTextLines[currentDialouge]);
    }
}

using UnityEngine;

public class OpenLinkAction : MonoBehaviour
{
    public void OpenLink(string link)
    {
        Application.OpenURL(link);
    }
}

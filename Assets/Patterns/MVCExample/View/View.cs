using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class View : MonoBehaviour
{
    public abstract void DisplaySpinResult(List<int> values);
    public abstract void DisplayYouWinText(bool isActive);
}

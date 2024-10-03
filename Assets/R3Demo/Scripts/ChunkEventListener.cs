using TMPro;
using UnityEngine;
using R3;

public class ChunkEventListener : MonoBehaviour
{
    [SerializeField] private ParamsEventInvoker _paramsEventInvoker_1;
    [SerializeField] private TextMeshProUGUI _buttonText;


    private void Awake()
    {
        _paramsEventInvoker_1.ParamsR3Event
        .Chunk(3)
        .Subscribe(x => DisplayText(x))
        .AddTo(this);
    }

    private void DisplayText(int[] x)
    {
        var str = string.Empty;
        
        foreach (var item in x)
        {
            str += item.ToString() + " ";
        }
        _buttonText.text = str;
    }
}

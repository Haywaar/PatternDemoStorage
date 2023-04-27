using Patterns.MVVMExample_Simple;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    [SerializeField] private View _viewPrefab;

    private void Start()
    {
        var model = new PlayerModel("Oleg", 15, 15, 15, 5);
        var viewModel = new DefaultViewModel(model);
        var view = GameObject.Instantiate(_viewPrefab);
        view.Init(viewModel);
    }
}
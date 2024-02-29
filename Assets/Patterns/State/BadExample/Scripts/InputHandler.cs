using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] TowerActionPopup _towerActionPopup;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.tag.Equals("Tower"))
                {
                    var tower = hit.transform.GetComponentInParent<Tower>();
                    if (tower != null)
                    {
                      var data = tower.GetActionData();
                      _towerActionPopup.ShowPopup(data);
                    }
                }
                else
                {
                     _towerActionPopup.Hide();
                }
            }
            else
            {
               _towerActionPopup.Hide();
            }
        }
    }
}

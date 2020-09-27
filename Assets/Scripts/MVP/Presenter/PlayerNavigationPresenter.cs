using UnityEngine;

public class PlayerNavigationPresenter : MonoBehaviour
{
    [SerializeField]
    private PlayerNavigationDataValue _navigationData;

    private void Update()
    {
        _navigationData.Position = transform.position;
        _navigationData.Rotation = transform.rotation;
    }

}

using System;
using UnityEngine;

//объявляю делегаты явно, чтобы назвать параметры - так понятнее, чего от них ожидать
public delegate void MoveNavigationHandler(Vector2 localPositionDelta);
public delegate void RotateNavigationHandler(Vector3 eulerAngles);

public interface INavigationModel
{
    event MoveNavigationHandler OnMove;
    event RotateNavigationHandler OnRotate;
}

[Serializable]
public class NavigationModelSerializableInterface : IUnifiedContainer<INavigationModel> { }
using System;

[Serializable]
public class GunnerModelSerializableInterface : IUnifiedContainer<IGunnerModel> { }

/// <summary>
/// Интерфейс обозначает кого-то кто отдает команду стрелять
/// </summary>
public interface IGunnerModel
{
    event Action OnShoot;
}

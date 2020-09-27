using System;

[Serializable]
public class GunModelSerializableInterface : IUnifiedContainer<IGunModel> { }

public interface IGunModel
{
    void Shoot();
}
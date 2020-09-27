using System;

[Serializable]
public class NavigationStateModelSerializableInterface : IUnifiedContainer<INavigationStateModel> { }

public interface INavigationStateModel
{
    void UpdateState();
}

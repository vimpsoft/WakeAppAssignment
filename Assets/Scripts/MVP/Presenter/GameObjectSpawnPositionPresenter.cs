using UnityEngine;

/// <summary>
/// Презентер отвечает за то, чтобы установить изначальную позицию геймобъекта
/// Это нужно, чтобы патрулирующие враги появлялись в правильном месте
/// Потребность в этом классе вызывана тем, что я изначально начал разрабатывать не вью актера, а вью игрока
/// - этот вью принимает только дельты перемещения и поворта, тогда как для врагов удобнее было бы работать не 
/// дельтами а уже конкретно позициями и поворотами. Сказывается отсутствие опыта разработки FPS.
/// </summary>
public class GameObjectSpawnPositionPresenter : MonoBehaviour
{
    [SerializeField]
    private Transform _spawnPosition;

    private void Start()
    {
        if (_spawnPosition != default)
            transform.position = _spawnPosition.position;
    }
}

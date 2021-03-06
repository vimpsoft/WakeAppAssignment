﻿using UnityEngine;

public class BulletPresenter : MonoBehaviour
{
    [SerializeField]
    private FloatValue _speed;
    [SerializeField]
    private BulletModel _model;
    [SerializeField]
    private BulletView _view;

    private void Start()
    {
        _view.OnCollided += _model.ProcessCollision;
        _view.Push(_speed.Value);
    }

    //private void Update() => _view.Move(_speed.Value); //Это было до того как пуля стала баллистической
}

using System;
using UniRx;
using UnityEngine;
using Zenject;

public class CameraMotion : MonoBehaviour
{
    [Inject]
    private ICameraMotion cameraMotion;

    private CompositeDisposable disposables;

    private void CameraUpdate()
    {
        transform.localPosition = cameraMotion.CameraLocalPosition(transform.localPosition);
        transform.localRotation = cameraMotion.CameraLocalOrientation(transform.localRotation);
    }

    private void OnEnable()
    {
        if (disposables == null)
            disposables = new CompositeDisposable();

        Observable.EveryUpdate().Repeat().Subscribe(_ =>
        {
            CameraUpdate();
        }).AddTo(disposables);
    }

    private void OnDisable()
    {
        if (disposables != null)
        {
            disposables.Dispose();
        }
    }
}
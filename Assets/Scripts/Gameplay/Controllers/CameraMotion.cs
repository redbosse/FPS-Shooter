using UniRx;
using UnityEngine;
using Zenject;

namespace Gameplay.Controllers
{
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
            disposables ??= new CompositeDisposable();

            Observable.EveryUpdate().Repeat().Subscribe(_ =>
            {
                CameraUpdate();
            }).AddTo(disposables);
        }

        private void OnDisable()
        {
            disposables?.Dispose();
        }
    }
}
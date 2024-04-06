using UnityEngine;

namespace OIMOD.Core.GameMech
{
    public class OI_CameraManager : MonoBehaviour
    {
        [Header("Camera Setup")]
        [SerializeField] private Transform _camera;
        [SerializeField] private Transform _cameraTarget;
        [SerializeField] private Transform _background;
        [Space]
        [SerializeField] private float _cameraSmooth;

        private void Awake()
        {
            Application.targetFrameRate = 60;
        }
        void Update()
        {
            if (_camera.position.y <= _cameraTarget.position.y)
                CameraFollowTarget();
        }
        private void CameraFollowTarget()
        {
            var targetCameraPos = new Vector3
                (_camera.position.x,
                _cameraTarget.position.y,
                _camera.position.z);
            var targeBackgroundPos = new Vector3
                (_background.position.x,
                _camera.position.y,
                _background.position.z);

            _background.position = targeBackgroundPos;

            _camera.position = Vector3.Lerp
                (_camera.position, targetCameraPos,
                _cameraSmooth*Time.deltaTime);

        }
    }
}


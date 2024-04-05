using UnityEngine;

namespace OIMOD.Core.GameMech
{
    public class OI_CameraManager : MonoBehaviour
    {
        [Header("Camera Setup")]
        [SerializeField] private Camera _camera;
        [SerializeField] private GameObject _cameraTarget;
        [SerializeField] private GameObject _background;
        [Space]
        [SerializeField] private float _cameraSmooth;
        void Update()
        {
            CameraFollowTarget();
        }
        private void CameraFollowTarget()
        {
            var targetCameraPos = new Vector3
                (_camera.transform.position.x,
                _cameraTarget.transform.position.y,
                _camera.transform.position.z);
            var targeBackgroundPos = new Vector3
                (_background.transform.position.x,
                _cameraTarget.transform.position.y,
                _background.transform.position.z);
            _camera.transform.position = Vector3.Lerp
                (_camera.transform.position, targetCameraPos,
                _cameraSmooth*Time.deltaTime);
            _background.transform.position = Vector3.Lerp
                (_background.transform.position, targeBackgroundPos,
                _cameraSmooth * Time.deltaTime);

        }
    }
}


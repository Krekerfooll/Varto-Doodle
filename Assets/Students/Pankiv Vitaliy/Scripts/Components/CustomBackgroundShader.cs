using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PVitaliy.Components
{
    public class CustomBackgroundShader : MonoBehaviour
    {
        [SerializeField] private MeshRenderer rendererWithMaterial;
        [SerializeField] private float interpolationPower = .15f;
        private Color _targetBottomColor;
        private Color _targetTopColor;

        private Color BottomColor
        {
            get => rendererWithMaterial.materials[0].GetColor("_colorBottom");
            set => rendererWithMaterial.materials[0].SetColor("_colorBottom", value);
        }

        private Color TopColor
        {
            get => rendererWithMaterial.materials[0].GetColor("_colorTop");
            set => rendererWithMaterial.materials[0].SetColor("_colorTop", value);
        }
        private float LerpPower => interpolationPower * Time.deltaTime * 60;

        private void Awake()
        {
            TopColor = rendererWithMaterial.materials[0].GetColor("_colorTop");
            StartCoroutine(nameof(BackgroundChangeCoroutine));
        }

        private void ChangeTargetColor(Color newColor)
        {
            _targetBottomColor = newColor;
            Color.RGBToHSV(newColor, out var h, out var s, out var v);
            h = (h + .3f) % 1;
            _targetTopColor = Color.HSVToRGB(h, s, v);
        }

        private void Update()
        {
            var bottomColor = BottomColor;
            var topColor = TopColor;
            BottomColor = Color.Lerp(bottomColor, _targetBottomColor, LerpPower);
            TopColor = Color.Lerp(topColor, _targetTopColor, LerpPower);
        }

        private IEnumerator BackgroundChangeCoroutine()
        {
            while (true)
            {
                ChangeTargetColor(Random.ColorHSV(0, 1, .8f, 1, 0.07f, .2f));
                yield return new WaitForSeconds(10);
            }
        }
    }
}
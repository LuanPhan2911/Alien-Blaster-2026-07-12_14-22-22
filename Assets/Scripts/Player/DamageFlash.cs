using UnityEngine;

public class DamageFlash : MonoBehaviour
{



    [SerializeField] private float _flashDuration = 0.2f;

    private Material _flashMaterial;

    [SerializeField] private Color _flashColor = Color.white;

    private SpriteRenderer _spriteRenderer;
    private Coroutine _flashCoroutin;


    private const string FLASH_COLOR_PROPERTY = "_FlashColor";
    private const string FLASH_AMOUNT_PROPERTY = "_FlashAmount";
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _flashMaterial = _spriteRenderer.material;
    }

    public void Flash()
    {
        if (_flashCoroutin != null)
        {
            StopCoroutine(_flashCoroutin);

        }
        _flashCoroutin = StartCoroutine(FlashCoroutine());
    }

    private System.Collections.IEnumerator FlashCoroutine()
    {

        float elapsedTime = 0f;

        // set the flash color to the material
        _flashMaterial.SetColor(FLASH_COLOR_PROPERTY, _flashColor);

        while (elapsedTime < _flashDuration)
        {
            elapsedTime += Time.deltaTime;
            float flashAmount = Mathf.Lerp(1f, 0f, elapsedTime / _flashDuration);

            // set the flash amount to the material
            _flashMaterial.SetFloat(FLASH_AMOUNT_PROPERTY, flashAmount);

            yield return null;
        }
    }


}

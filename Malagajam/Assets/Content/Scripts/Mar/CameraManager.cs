using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    private static CameraManager _instance;
    public static CameraManager Instance = _instance;

    private CameraMovement _camMovement;

    [SerializeField] private Image _fadeImage;
    [SerializeField] private float _timeToFadeInSeconds = 1f;
    private Transform _playerTransform;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;

        _camMovement = Camera.main.GetComponent<CameraMovement>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TransitionToNewScreen(LevelCameraBox newCamBox, Vector3 targetPosition)
    {
        StartCoroutine(CamTransition(newCamBox, targetPosition));
    }

    private IEnumerator CamTransition(LevelCameraBox newCamBox, Vector3 targetPosition)
    {
        GameManager.Instance.PauseGame(true);

        float timer = 0f;
        while (timer < 1)
        {
            _fadeImage.color = new Color(_fadeImage.color.r, _fadeImage.color.g, _fadeImage.color.b, timer);
            timer += Time.unscaledDeltaTime / _timeToFadeInSeconds;
            Mathf.Clamp01(timer);
            yield return null;
        }

        _playerTransform.position = targetPosition;
        _camMovement.MoveToNewScreen(newCamBox);

        while (timer > 0)
        {
            _fadeImage.color = new Color(_fadeImage.color.r, _fadeImage.color.g, _fadeImage.color.b, timer);
            timer -= Time.unscaledDeltaTime / _timeToFadeInSeconds;
            Mathf.Clamp01(timer);
            yield return null;
        }

        GameManager.Instance.PauseGame(false);
    }
}

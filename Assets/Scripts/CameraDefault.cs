using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraDefault : MonoBehaviour {
    public CinemachineVirtualCamera idleCamera;
    public CinemachineVirtualCamera runCamera;
    public CinemachineVirtualCamera climbingCamera;

    public float newIdleOrthoSize = 5f;
    public float newRunOrthoSize = 6f;
    public float newClimbingOrthoSize = 7f;

    public float transitionDuration = 1f; // Geçiş süresi

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            StartCoroutine(ChangeLensOrthoSize(idleCamera, newIdleOrthoSize));
            StartCoroutine(ChangeLensOrthoSize(runCamera, newRunOrthoSize));
            StartCoroutine(ChangeLensOrthoSize(climbingCamera, newClimbingOrthoSize));
        }
    }

    private IEnumerator ChangeLensOrthoSize(CinemachineVirtualCamera vCam, float targetSize) {
        float startSize = vCam.m_Lens.OrthographicSize;
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration) {
            vCam.m_Lens.OrthographicSize = Mathf.Lerp(startSize, targetSize, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        vCam.m_Lens.OrthographicSize = targetSize;
    }
}

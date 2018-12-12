using UnityEngine;

[ExecuteInEditMode]
public class CutOff : MonoBehaviour {

    [SerializeField, Header("For edit mode. Effects performance...")]
    bool m_continuousUpdate = true;

    [SerializeField]
    Transform m_cutoffPoint = null;

    [SerializeField]
	Renderer m_renderer = null;

    [SerializeField]
    Texture m_mainTex = null;

    [SerializeField]
    Texture m_secTex = null;

    [SerializeField]
    Color m_mainColor = Color.white;

    [SerializeField]
    Color m_secColor = Color.black;

    void OnEnable() {
        if (m_renderer == null) {
            return;
        }

        UpdateRenderer();
        UpdateCutoffPoint();
    }

    // Update is called once per frame
    void Update () {
		if(m_renderer == null){
			return;
		}

        if (m_cutoffPoint == null) {
            m_cutoffPoint = transform;
        }

        if (Application.isPlaying || !m_continuousUpdate) {
            if (m_cutoffPoint.hasChanged || m_renderer.transform.hasChanged) {
                m_cutoffPoint.hasChanged = false;
                m_renderer.transform.hasChanged = false;
                UpdateCutoffPoint();
            }
        }
        else {
            UpdateCutoffPoint();
        }
    }

    void OnValidate() {
        if (m_renderer == null) {
            return;
        }

        UpdateRenderer();
        UpdateCutoffPoint();
    }

    void UpdateRenderer() {
        Material material = Application.isPlaying ?
           m_renderer.material : m_renderer.sharedMaterial;

        material.SetTexture("_MainTex", m_mainTex);
        material.SetTexture("_SecTex", m_secTex);
        material.SetColor("_Color", m_mainColor);
        material.SetColor("_SecColor", m_secColor);
    }

    void UpdateCutoffPoint() {
        Material material = Application.isPlaying ?
            m_renderer.material : m_renderer.sharedMaterial;

        if (m_cutoffPoint == null) {
            m_cutoffPoint = transform;
        }

        Vector4 cutoffPoint = Vector4.zero;
        cutoffPoint.x = m_cutoffPoint.position.x;
        cutoffPoint.y = m_cutoffPoint.position.y;
        cutoffPoint.z = m_cutoffPoint.position.z;

        Vector4 cutoffDir = Vector4.zero;
        cutoffDir.x = m_cutoffPoint.forward.x;
        cutoffDir.y = m_cutoffPoint.forward.y;
        cutoffDir.z = m_cutoffPoint.forward.z;

        material.SetVector("_CutoffPoint", cutoffPoint);
        material.SetVector("_CutoffDir", cutoffDir);
    }
}

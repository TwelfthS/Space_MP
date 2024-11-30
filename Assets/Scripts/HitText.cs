using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitText : MonoBehaviour
{
    TMP_Text text;
    float timer;
    void Start()
    {
        text = this.GetComponent<TMP_Text>();
        text.enabled = false;
    }

    void FixedUpdate() {
        if (timer > 0) {
            timer -= Time.fixedDeltaTime;
            if (timer <= 0) {
                timer = 0;
                text.enabled = false;
            }
        }
    }

    public void UpdateText(string updatedText) {
        text.enabled = true;
        text.text = updatedText;
        timer = 3f;
    }
}

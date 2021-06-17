using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TestPadd : MonoBehaviour
{
    TextMeshProUGUI Text = null;

    void Awake()
    {
        Text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (Text == null) return;

        // 確認用
        string sbutton = "GetKey: ";
        for (int i = 0; i < (int)ePad.PadMax; i++)
        {
            ePad epad = (ePad)System.Enum.ToObject(typeof(ePad), i);
            // GetKey を他のものに変えれば、各種判定を確認できる
            if (Padd.GetKey(epad) == true)
            {
                sbutton += $"{epad} ";
            }
        }

        sbutton += "\r\n";

        sbutton += "GetKeyDown: ";
        for (int i = 0; i < (int)ePad.PadMax; i++)
        {
            ePad epad = (ePad)System.Enum.ToObject(typeof(ePad), i);
            // GetKey を他のものに変えれば、各種判定を確認できる
            if (Padd.GetKeyDown(epad) == true)
            {
                sbutton += $"{epad} ";
            }
        }

        sbutton += "\r\n";

        sbutton += "GetKeyDelay: ";
        for (int i = 0; i < (int)ePad.PadMax; i++)
        {
            ePad epad = (ePad)System.Enum.ToObject(typeof(ePad), i);
            // GetKey を他のものに変えれば、各種判定を確認できる
            if (Padd.GetKeyDelay(epad) == true)
            {
                sbutton += $"{epad} ";
            }
        }

        sbutton += "\r\n";

        string[] names = new string[]
        {
            "axisL",
            "axisR",
            "trigger",
            "mouse",
            "touch1",
        };
        PadInput.PadVector[] vecs = new PadInput.PadVector[]
        {
            Padd.GetAxisL(),
            Padd.GetAxisR(),
            Padd.GetTrigger(),
            Padd.GetMouse(),
            Padd.GetTouchPos(0)
        }; 

        for (int i = 0; i < names.Length; i++)
        {
            if (vecs[i].Position.x != 0 || vecs[i].Position.y != 0)
            {
                sbutton += $"{names[i]}: {vecs[i].IsMoved} {vecs[i].Position.x} {vecs[i].Position.y} {vecs[i].TouchMove.x} {vecs[i].TouchMove.y}\r\n";
            }
        }

        Text.SetText(sbutton);
    }
}

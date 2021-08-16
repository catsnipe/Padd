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
            "touch1",
        };
        PadInput.PadVector[] vecs = new PadInput.PadVector[]
        {
            Padd.GetAxisL(),
            Padd.GetAxisR(),
            Padd.GetTrigger(),
            Padd.GetTouchPos(0)
        }; 

        PadInput.MouseVector mouse = Padd.GetMouse();

        for (int i = 0; i < names.Length; i++)
        {
            if (vecs[i].Position.x != 0 || vecs[i].Position.y != 0)
            {
                sbutton += $"{names[i]}: {vecs[i].IsMoved} {vecs[i].Position.x} {vecs[i].Position.y}\r\n";
                sbutton += $"{names[i]} move: {vecs[i].Move.x} {vecs[i].Move.y}\r\n";
            }
        }
        sbutton += $"mouse: {mouse.IsMoved} {mouse.Position.x} {mouse.Position.y}\r\n";
        sbutton += $"mouse move: {mouse.Move.x} {mouse.Move.y}\r\n";
        sbutton += $"mouse touchmove: {mouse.TouchMove.x} {mouse.TouchMove.y}\r\n";

        Text.SetText(sbutton);
    }
}

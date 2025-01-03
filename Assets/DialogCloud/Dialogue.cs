using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float textSpeed;

    private string[] lines;
    private int index;
    private GameObject dialogCloud;

    // Start is called before the first frame update
    void Start()
    {
        lines = new string[3];
        lines[0] = "�����, � �� ��������!";
        lines[1] = "� ���, ��� ��������� ��� �\n�������� �������. ��� ���� �\n������� ���� ����� �����\n�������� �� �����������!";
        lines[2] = "� ����� ���� � �������������\n���� � ��� �������\n�����������.";
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        dialogCloud = GameObject.FindGameObjectWithTag("DialogCloud");
        if (Input.GetKeyDown("1") && dialogCloud != null)
        {
            if(textComponent.text == lines[index]) 
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }

        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began && dialogCloud != null)
            {
                if (textComponent.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(index < lines.Length -1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            Destroy(dialogCloud);
        }
    }
}

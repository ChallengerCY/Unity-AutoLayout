using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestAutoLayout : MonoBehaviour
{
    public Text text1, text2, text3, text4;
    public Image image1, image2, image3, image4;

    // Update is called once per frame
    void Update()
    {

        text1.text = "Flexable" + "\n" + "With:" + image1.GetComponent<RectTransform>().rect.width +
            "\n" + "preferredWidth" + image1.GetComponent<LayoutElement>().preferredWidth +
             "\n" + "minWidth" + image1.GetComponent<LayoutElement>().minWidth +
              "\n" + "flexibleWidth" + image1.GetComponent<LayoutElement>().flexibleWidth;
        text2.text = "Flexable" + "\n" + "With:" + image2.GetComponent<RectTransform>().rect.width +
            "\n" + "preferredWidth" + image2.GetComponent<LayoutElement>().preferredWidth +
             "\n" + "minWidth" + image2.GetComponent<LayoutElement>().minWidth +
              "\n" + "flexibleWidth" + image2.GetComponent<LayoutElement>().flexibleWidth;
        text3.text = "Flexable" + "\n" + "With:" + image3.GetComponent<RectTransform>().rect.width +
            "\n" + "preferredWidth" + image3.GetComponent<LayoutElement>().preferredWidth +
             "\n" + "minWidth" + image3.GetComponent<LayoutElement>().minWidth +
              "\n" + "flexibleWidth" + image3.GetComponent<LayoutElement>().flexibleWidth;
        text4.text = "Flexable" + "\n" + "With:" + image4.GetComponent<RectTransform>().rect.width +
            "\n" + "preferredWidth" + image4.GetComponent<LayoutElement>().preferredWidth +
             "\n" + "minWidth" + image4.GetComponent<LayoutElement>().minWidth +
              "\n" + "flexibleWidth" + image4.GetComponent<LayoutElement>().flexibleWidth;
    }
}

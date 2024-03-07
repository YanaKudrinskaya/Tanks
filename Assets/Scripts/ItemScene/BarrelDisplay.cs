using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarrelDisplay : MonoBehaviour
{

    [SerializeField] private Barrel _barrel;
    [SerializeField] private Text _titleText;
    [SerializeField] private Text _descriptionText;
    [SerializeField] private Text _radiusText;
    [SerializeField] private Image _image;

    private void Start()
    {
        _titleText.text = _barrel.title;
        _descriptionText.text = _barrel.description;
        _radiusText.text = _barrel.radius.ToString();
        _image.sprite = _barrel.sprite;
    }
}

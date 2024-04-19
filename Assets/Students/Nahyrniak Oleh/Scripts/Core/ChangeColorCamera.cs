using Doodle.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace Doodle.Core
{
    public class ChangeColorCamera : Action
    {
        [SerializeField] private List<Color> _colorList;

        private int _currentColorIndex = 0;

        public override void Execute()
        {
            _currentColorIndex++;

            if (_currentColorIndex >= _colorList.Count) _currentColorIndex = 0;

            Camera.main.backgroundColor = _colorList[_currentColorIndex];
        }
    }

    //To create parent ChangeColor once it's needed:
    /*public class ChangeColor : Action
    {
        [SerializeField] private List<Color> _colorList;

        private int _currentColorIndex = 0;

        public override void Execute()
        {
            _currentColorIndex++;

            if (_currentColorIndex >= _colorList.Count) _currentColorIndex = 0;

            //in childs remains only to specify object to change color and change it
        }
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom
{

    [CreateAssetMenu()]
    public class CursorIconSO : ScriptableObject
    {
        [SerializeField] private Texture2D _baseIcon;
        [SerializeField] private Texture2D _buildIcon;
        [SerializeField] private Texture2D _moveIcon;
        [SerializeField] private Texture2D _removeIcon;

        public Texture2D BaseIcon => _baseIcon;
        public Texture2D BuildIcon => _buildIcon;
        public Texture2D MoveIcon => _moveIcon;
        public Texture2D RemoveIcon => _removeIcon;

    }
}

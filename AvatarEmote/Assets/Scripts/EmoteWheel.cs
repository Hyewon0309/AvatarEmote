using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StarterAssets
{
    [System.Serializable]
    public class MenuButton
    {
        public string name;
        public Image sceneImage;
        public Color normalColor = Color.white;
        public Color highlightColor = Color.grey;
        public Color pressedColor = Color.gray;
    }


    public class EmoteWheel : MonoBehaviour
    {
        [SerializeField] GameObject m_emoteCanvas;
        [SerializeField] ThirdPersonController m_avatarController;

        public List<MenuButton> m_buttons = new List<MenuButton>();
        private Vector2 m_mousePosition;
        private Vector2 m_fromVector2M = new Vector2(.5f, 1f);
        private Vector2 m_centerCircle = new Vector2(.5f, .5f);
        private Vector2 m_toVector2M;

        public int m_menuItem;
        public int m_curMenuItem;
        private int m_oldMenuItem;

        private void Start()
        {
            m_emoteCanvas.SetActive(false);
            m_menuItem = m_buttons.Count;
            foreach (MenuButton button in m_buttons) button.sceneImage.color = button.normalColor;
            m_curMenuItem = 0;
            m_oldMenuItem = 0;
        }

        private void Update()
        {
            GetCurrentMenuItem();
            if (Input.GetKey(KeyCode.T)) { m_avatarController.enabled = false; Cursor.visible = true; m_emoteCanvas.SetActive(true); Debug.Log("Showing Wheel Menu"); }
            if (Input.GetKeyUp(KeyCode.T)) { m_avatarController.enabled = true; Cursor.visible = false; m_emoteCanvas.SetActive(false); Debug.Log("Hide Wheel Menu"); }
            if (Input.GetKey(KeyCode.Mouse0)) ButtonAction();
        }

        public void GetCurrentMenuItem()
        {
            if (m_emoteCanvas.activeSelf)
            {
                m_mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                m_toVector2M = new Vector2(m_mousePosition.x / Screen.width, m_mousePosition.y / Screen.height);
                float angle = (Mathf.Atan2(m_fromVector2M.y - m_centerCircle.y, m_fromVector2M.x - m_centerCircle.x) - Mathf.Atan2(m_toVector2M.y - m_centerCircle.y, m_toVector2M.x - m_centerCircle.x)) * Mathf.Rad2Deg;
                if (angle < 0) angle += 360;

                m_curMenuItem = (int)(angle / (360 / m_menuItem));

                if (m_curMenuItem != m_oldMenuItem)
                {
                    m_buttons[m_oldMenuItem].sceneImage.color = m_buttons[m_oldMenuItem].normalColor;
                    m_oldMenuItem = m_curMenuItem;
                    m_buttons[m_curMenuItem].sceneImage.color = m_buttons[m_curMenuItem].highlightColor;
                }
            }
        }

        public void ButtonAction()
        {
            m_buttons[m_curMenuItem].sceneImage.color = m_buttons[m_curMenuItem].pressedColor;
            if (m_curMenuItem == 0) Debug.Log("You have pressed the first button");
        }
    }
}


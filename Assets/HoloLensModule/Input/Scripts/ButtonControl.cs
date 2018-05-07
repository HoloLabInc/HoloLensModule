﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HoloLensModule.Input
{
    public abstract class ButtonControl : MonoBehaviour, IFocusInterface, IClickInterface
    {
        public UnityEvent ClickEvent;

        private bool isFocus = false;
        public void RaycastClick()
        {
            ClickButton();
            if (ClickEvent != null) ClickEvent.Invoke();
        }

        public void RaycastHit()
        {
            FocusIn();
            isFocus = true;
        }

        public void RaycastOut()
        {
            FocusOut();
            isFocus = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (isFocus == true) FocusUpdate();
        }

        protected abstract void FocusIn();
        protected abstract void FocusUpdate();
        protected abstract void FocusOut();
        protected abstract void ClickButton();
    }
}

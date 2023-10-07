﻿using DevExpress.ExpressApp;
using OutlookInspired.Module.BusinessObjects;

namespace OutlookInspired.Module.Controllers{
    public class WelcomeController:ObjectViewController<DetailView,Welcome>{
        protected override void OnActivated(){
            base.OnActivated();
            View.CurrentObject = new Welcome();
        }
    }
}
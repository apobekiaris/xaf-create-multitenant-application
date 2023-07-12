﻿using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;

namespace OutlookInspired.Module.BusinessObjects{
    public abstract class BaseObject : IXafEntityObject, IObjectSpaceLink{
        protected IObjectSpace ObjectSpace;
        [System.ComponentModel.DataAnnotations.Key]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [VisibleInLookupListView(false)]
        public virtual long ID { get; set; }
        public virtual void OnCreated(){ }
        public virtual void OnSaving(){ }
        public virtual void OnLoaded(){ }

        IObjectSpace IObjectSpaceLink.ObjectSpace{
            get => ObjectSpace;
            set => ObjectSpace = value;
        }
    }
}
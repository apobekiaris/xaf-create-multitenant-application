﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace OutlookInspired.Module.BusinessObjects {
	[DefaultProperty(nameof(FullName))]
	public class CustomerEmployee :MigrationBaseObject{
		[RuleRequiredField]
		public virtual string FirstName { get; set; }
		[RuleRequiredField]
		public virtual string LastName { get; set; }
		public virtual string FullName { get; set; }
		public virtual PersonPrefix Prefix { get; set; }
		[RuleRequiredField, Attributes.Validation.Phone]
		public virtual string MobilePhone { get; set; }
		[RuleRequiredField, Attributes.Validation.EmailAddress]
		public virtual string Email { get; set; }
		public virtual Picture Picture { get; set; }
		public virtual Customer Customer { get; set; }
		public virtual CustomerStore CustomerStore { get; set; }
		public virtual string Position { get; set; }
		public virtual bool IsPurchaseAuthority { get; set; }
		[Aggregated]
		public virtual ObservableCollection<CustomerCommunication> CustomerCommunications{ get; set; } = new();
		[Aggregated]
		public virtual ObservableCollection<EmployeeTask> EmployeeTasks{ get; set; } = new();

	}
	public enum PersonPrefix {
		[ImageName("Doctor")]
		Dr,
		[ImageName("Mr")]
		Mr,
		[ImageName("Ms")]
		Ms,
		[ImageName("Miss")]
		Miss,
		[ImageName("Mrs")]
		Mrs
	}

}

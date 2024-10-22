﻿using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Blazor.Components;
using DevExpress.ExpressApp.Blazor.Components.Models;
using DevExpress.ExpressApp.Blazor.Editors;
using OutlookInspired.Module.BusinessObjects;
using OutlookInspired.Module.Services.Internal;

namespace OutlookInspired.Blazor.Server.Features.Employees.Tasks{
    public class EmployeeTasksController:ObjectViewController<ListView,EmployeeTask>{
        public EmployeeTasksController() => TargetViewNesting=Nesting.Nested;

        protected override void OnViewControlsCreated(){
            base.OnViewControlsCreated();
            if (View.Editor is not DxGridListEditor editor) return;
            var dataColumnModel = editor.GridDataColumnModels.First(model => model.FieldName == View.Model.VisibleMemberViewItems().First().PropertyName);
            dataColumnModel.HeaderCaptionTemplate = _ => _ => { };
            
            dataColumnModel.CellDisplayTemplate = value => {
                var employeeTask = ((EmployeeTask)value.DataItem);
                var model = new TasksColumnTemplateModel(){
                    Subject = employeeTask.Subject,Description = employeeTask.Description.ToDocumentText(),
                    Date = employeeTask.DueDate.GetValueOrDefault().ToString("MMMM dd, yyyy"),
                    Progress = employeeTask.Completion
                };
                return ComponentModelObserver.Create(model, model.GetComponentContent());
            };

        }
    }
}
﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestClient.NoValidationService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserBaseDto", Namespace="http://schemas.datacontract.org/2004/07/MainService")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TestClient.NoValidationService.UserDto))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TestClient.NoValidationService.UserCrDto))]
    public partial class UserBaseDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<long> CityIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GroupField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NicknameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PhoneField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SurnameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<long> UniversityIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<long> CityId {
            get {
                return this.CityIdField;
            }
            set {
                if ((this.CityIdField.Equals(value) != true)) {
                    this.CityIdField = value;
                    this.RaisePropertyChanged("CityId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Group {
            get {
                return this.GroupField;
            }
            set {
                if ((object.ReferenceEquals(this.GroupField, value) != true)) {
                    this.GroupField = value;
                    this.RaisePropertyChanged("Group");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nickname {
            get {
                return this.NicknameField;
            }
            set {
                if ((object.ReferenceEquals(this.NicknameField, value) != true)) {
                    this.NicknameField = value;
                    this.RaisePropertyChanged("Nickname");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Phone {
            get {
                return this.PhoneField;
            }
            set {
                if ((object.ReferenceEquals(this.PhoneField, value) != true)) {
                    this.PhoneField = value;
                    this.RaisePropertyChanged("Phone");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Surname {
            get {
                return this.SurnameField;
            }
            set {
                if ((object.ReferenceEquals(this.SurnameField, value) != true)) {
                    this.SurnameField = value;
                    this.RaisePropertyChanged("Surname");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<long> UniversityId {
            get {
                return this.UniversityIdField;
            }
            set {
                if ((this.UniversityIdField.Equals(value) != true)) {
                    this.UniversityIdField = value;
                    this.RaisePropertyChanged("UniversityId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserDto", Namespace="http://schemas.datacontract.org/2004/07/MainService")]
    [System.SerializableAttribute()]
    public partial class UserDto : TestClient.NoValidationService.UserBaseDto {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long IdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserCrDto", Namespace="http://schemas.datacontract.org/2004/07/MainService")]
    [System.SerializableAttribute()]
    public partial class UserCrDto : TestClient.NoValidationService.UserBaseDto {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResultBase", Namespace="http://schemas.datacontract.org/2004/07/MainService")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TestClient.NoValidationService.Result))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TestClient.NoValidationService.CrResultOfUserDtoGvCn2ESm))]
    public partial class ResultBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private TestClient.NoValidationService.ActionResult ActionResultField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public TestClient.NoValidationService.ActionResult ActionResult {
            get {
                return this.ActionResultField;
            }
            set {
                if ((this.ActionResultField.Equals(value) != true)) {
                    this.ActionResultField = value;
                    this.RaisePropertyChanged("ActionResult");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Result", Namespace="http://schemas.datacontract.org/2004/07/MainService")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TestClient.NoValidationService.CrResultOfUserDtoGvCn2ESm))]
    public partial class Result : TestClient.NoValidationService.ResultBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private TestClient.NoValidationService.Error[] ErrorsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public TestClient.NoValidationService.Error[] Errors {
            get {
                return this.ErrorsField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorsField, value) != true)) {
                    this.ErrorsField = value;
                    this.RaisePropertyChanged("Errors");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CrResultOfUserDtoGvCn2ESm", Namespace="http://schemas.datacontract.org/2004/07/MainService")]
    [System.SerializableAttribute()]
    public partial class CrResultOfUserDtoGvCn2ESm : TestClient.NoValidationService.Result {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private TestClient.NoValidationService.UserDto CreatedObjectField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public TestClient.NoValidationService.UserDto CreatedObject {
            get {
                return this.CreatedObjectField;
            }
            set {
                if ((object.ReferenceEquals(this.CreatedObjectField, value) != true)) {
                    this.CreatedObjectField = value;
                    this.RaisePropertyChanged("CreatedObject");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ActionResult", Namespace="http://schemas.datacontract.org/2004/07/MainService")]
    public enum ActionResult : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Success = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        PermissionDenied = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        DatabaseError = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        IncorrectParameter = 3,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Error", Namespace="http://schemas.datacontract.org/2004/07/MainService")]
    [System.SerializableAttribute()]
    public partial class Error : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private TestClient.NoValidationService.CheckStatus CheckStatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string VariableField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public TestClient.NoValidationService.CheckStatus CheckStatus {
            get {
                return this.CheckStatusField;
            }
            set {
                if ((this.CheckStatusField.Equals(value) != true)) {
                    this.CheckStatusField = value;
                    this.RaisePropertyChanged("CheckStatus");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Variable {
            get {
                return this.VariableField;
            }
            set {
                if ((object.ReferenceEquals(this.VariableField, value) != true)) {
                    this.VariableField = value;
                    this.RaisePropertyChanged("Variable");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CheckStatus", Namespace="http://schemas.datacontract.org/2004/07/MainService")]
    public enum CheckStatus : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Success = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ArgumentIsNull = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        LenghtIsIncorrect = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        IdDoesNotExist = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ArgumentDoesNotMatchFormat = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ArgumentIsNotUnique = 5,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        IncorrectParametr = 6,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CityDto", Namespace="http://schemas.datacontract.org/2004/07/MainService")]
    [System.SerializableAttribute()]
    public partial class CityDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UniversityDto", Namespace="http://schemas.datacontract.org/2004/07/MainService")]
    [System.SerializableAttribute()]
    public partial class UniversityDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ShortNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ShortName {
            get {
                return this.ShortNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ShortNameField, value) != true)) {
                    this.ShortNameField = value;
                    this.RaisePropertyChanged("ShortName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ImportanceDto", Namespace="http://schemas.datacontract.org/2004/07/MainService")]
    [System.SerializableAttribute()]
    public partial class ImportanceDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ImportanceDescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long ImportanceIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ImportanceDescription {
            get {
                return this.ImportanceDescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.ImportanceDescriptionField, value) != true)) {
                    this.ImportanceDescriptionField = value;
                    this.RaisePropertyChanged("ImportanceDescription");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long ImportanceId {
            get {
                return this.ImportanceIdField;
            }
            set {
                if ((this.ImportanceIdField.Equals(value) != true)) {
                    this.ImportanceIdField = value;
                    this.RaisePropertyChanged("ImportanceId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RolePermitions", Namespace="http://schemas.datacontract.org/2004/07/MainService")]
    [System.SerializableAttribute()]
    public partial class RolePermitions : TestClient.NoValidationService.RoleDto {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private TestClient.NoValidationService.PermitionDto[] PermitionsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public TestClient.NoValidationService.PermitionDto[] Permitions {
            get {
                return this.PermitionsField;
            }
            set {
                if ((object.ReferenceEquals(this.PermitionsField, value) != true)) {
                    this.PermitionsField = value;
                    this.RaisePropertyChanged("Permitions");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RoleDto", Namespace="http://schemas.datacontract.org/2004/07/MainService")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TestClient.NoValidationService.RolePermitions))]
    public partial class RoleDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RoleDescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long RoleIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RoleNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RoleDescription {
            get {
                return this.RoleDescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.RoleDescriptionField, value) != true)) {
                    this.RoleDescriptionField = value;
                    this.RaisePropertyChanged("RoleDescription");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long RoleId {
            get {
                return this.RoleIdField;
            }
            set {
                if ((this.RoleIdField.Equals(value) != true)) {
                    this.RoleIdField = value;
                    this.RaisePropertyChanged("RoleId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RoleName {
            get {
                return this.RoleNameField;
            }
            set {
                if ((object.ReferenceEquals(this.RoleNameField, value) != true)) {
                    this.RoleNameField = value;
                    this.RaisePropertyChanged("RoleName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PermitionDto", Namespace="http://schemas.datacontract.org/2004/07/MainService")]
    [System.SerializableAttribute()]
    public partial class PermitionDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long RermitionIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RermitionNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long RermitionId {
            get {
                return this.RermitionIdField;
            }
            set {
                if ((this.RermitionIdField.Equals(value) != true)) {
                    this.RermitionIdField = value;
                    this.RaisePropertyChanged("RermitionId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RermitionName {
            get {
                return this.RermitionNameField;
            }
            set {
                if ((object.ReferenceEquals(this.RermitionNameField, value) != true)) {
                    this.RermitionNameField = value;
                    this.RaisePropertyChanged("RermitionName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="NoValidationService.INoValidationService")]
    public interface INoValidationService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INoValidationService/Register", ReplyAction="http://tempuri.org/INoValidationService/RegisterResponse")]
        TestClient.NoValidationService.CrResultOfUserDtoGvCn2ESm Register(TestClient.NoValidationService.UserCrDto user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INoValidationService/Register", ReplyAction="http://tempuri.org/INoValidationService/RegisterResponse")]
        System.Threading.Tasks.Task<TestClient.NoValidationService.CrResultOfUserDtoGvCn2ESm> RegisterAsync(TestClient.NoValidationService.UserCrDto user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INoValidationService/GetCities", ReplyAction="http://tempuri.org/INoValidationService/GetCitiesResponse")]
        TestClient.NoValidationService.CityDto[] GetCities();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INoValidationService/GetCities", ReplyAction="http://tempuri.org/INoValidationService/GetCitiesResponse")]
        System.Threading.Tasks.Task<TestClient.NoValidationService.CityDto[]> GetCitiesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INoValidationService/GetUnivercities", ReplyAction="http://tempuri.org/INoValidationService/GetUnivercitiesResponse")]
        TestClient.NoValidationService.UniversityDto[] GetUnivercities(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INoValidationService/GetUnivercities", ReplyAction="http://tempuri.org/INoValidationService/GetUnivercitiesResponse")]
        System.Threading.Tasks.Task<TestClient.NoValidationService.UniversityDto[]> GetUnivercitiesAsync(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INoValidationService/GetImportanceScale", ReplyAction="http://tempuri.org/INoValidationService/GetImportanceScaleResponse")]
        TestClient.NoValidationService.ImportanceDto[] GetImportanceScale();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INoValidationService/GetImportanceScale", ReplyAction="http://tempuri.org/INoValidationService/GetImportanceScaleResponse")]
        System.Threading.Tasks.Task<TestClient.NoValidationService.ImportanceDto[]> GetImportanceScaleAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INoValidationService/GetRolePermitions", ReplyAction="http://tempuri.org/INoValidationService/GetRolePermitionsResponse")]
        TestClient.NoValidationService.RolePermitions[] GetRolePermitions();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INoValidationService/GetRolePermitions", ReplyAction="http://tempuri.org/INoValidationService/GetRolePermitionsResponse")]
        System.Threading.Tasks.Task<TestClient.NoValidationService.RolePermitions[]> GetRolePermitionsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface INoValidationServiceChannel : TestClient.NoValidationService.INoValidationService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class NoValidationServiceClient : System.ServiceModel.ClientBase<TestClient.NoValidationService.INoValidationService>, TestClient.NoValidationService.INoValidationService {
        
        public NoValidationServiceClient() {
        }
        
        public NoValidationServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public NoValidationServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NoValidationServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NoValidationServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public TestClient.NoValidationService.CrResultOfUserDtoGvCn2ESm Register(TestClient.NoValidationService.UserCrDto user) {
            return base.Channel.Register(user);
        }
        
        public System.Threading.Tasks.Task<TestClient.NoValidationService.CrResultOfUserDtoGvCn2ESm> RegisterAsync(TestClient.NoValidationService.UserCrDto user) {
            return base.Channel.RegisterAsync(user);
        }
        
        public TestClient.NoValidationService.CityDto[] GetCities() {
            return base.Channel.GetCities();
        }
        
        public System.Threading.Tasks.Task<TestClient.NoValidationService.CityDto[]> GetCitiesAsync() {
            return base.Channel.GetCitiesAsync();
        }
        
        public TestClient.NoValidationService.UniversityDto[] GetUnivercities(string value) {
            return base.Channel.GetUnivercities(value);
        }
        
        public System.Threading.Tasks.Task<TestClient.NoValidationService.UniversityDto[]> GetUnivercitiesAsync(string value) {
            return base.Channel.GetUnivercitiesAsync(value);
        }
        
        public TestClient.NoValidationService.ImportanceDto[] GetImportanceScale() {
            return base.Channel.GetImportanceScale();
        }
        
        public System.Threading.Tasks.Task<TestClient.NoValidationService.ImportanceDto[]> GetImportanceScaleAsync() {
            return base.Channel.GetImportanceScaleAsync();
        }
        
        public TestClient.NoValidationService.RolePermitions[] GetRolePermitions() {
            return base.Channel.GetRolePermitions();
        }
        
        public System.Threading.Tasks.Task<TestClient.NoValidationService.RolePermitions[]> GetRolePermitionsAsync() {
            return base.Channel.GetRolePermitionsAsync();
        }
    }
}
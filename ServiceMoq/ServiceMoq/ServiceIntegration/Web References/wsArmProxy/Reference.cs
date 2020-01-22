﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace ServiceIntegration.wsArmProxy {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="IAPO2_ARM_READERbinding", Namespace="http://tempuri.org/")]
    public partial class IAPO2_ARM_READERservice : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback Check_BSOOperationCompleted;
        
        private System.Threading.SendOrPostCallback Check_BSO2OperationCompleted;
        
        private System.Threading.SendOrPostCallback Check_BSO3OperationCompleted;
        
        private System.Threading.SendOrPostCallback Check_BSO4OperationCompleted;
        
        private System.Threading.SendOrPostCallback Check_BSO5OperationCompleted;
        
        private System.Threading.SendOrPostCallback GetDataOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetFactDatabyAgentIDOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetAgentsByLNR_INNOperationCompleted;
        
        private System.Threading.SendOrPostCallback CheckPreferentialExtensionOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetInfoContractsOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public IAPO2_ARM_READERservice() {
            this.Url = global::ServiceIntegration.Properties.Settings.Default.ServiceIntegration_wsArmProxy_IAPO2_ARM_READERservice;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event Check_BSOCompletedEventHandler Check_BSOCompleted;
        
        /// <remarks/>
        public event Check_BSO2CompletedEventHandler Check_BSO2Completed;
        
        /// <remarks/>
        public event Check_BSO3CompletedEventHandler Check_BSO3Completed;
        
        /// <remarks/>
        public event Check_BSO4CompletedEventHandler Check_BSO4Completed;
        
        /// <remarks/>
        public event Check_BSO5CompletedEventHandler Check_BSO5Completed;
        
        /// <remarks/>
        public event GetDataCompletedEventHandler GetDataCompleted;
        
        /// <remarks/>
        public event GetFactDatabyAgentIDCompletedEventHandler GetFactDatabyAgentIDCompleted;
        
        /// <remarks/>
        public event GetAgentsByLNR_INNCompletedEventHandler GetAgentsByLNR_INNCompleted;
        
        /// <remarks/>
        public event CheckPreferentialExtensionCompletedEventHandler CheckPreferentialExtensionCompleted;
        
        /// <remarks/>
        public event GetInfoContractsCompletedEventHandler GetInfoContractsCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:APO2_ARM_READER_c-IAPO2_ARM_READER#Check_BSO", RequestNamespace="urn:APO2_ARM_READER_c-IAPO2_ARM_READER", ResponseNamespace="urn:APO2_ARM_READER_c-IAPO2_ARM_READER")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public int Check_BSO(string BSO_ser, string BSO_num, string ARM_Agent_ID) {
            object[] results = this.Invoke("Check_BSO", new object[] {
                        BSO_ser,
                        BSO_num,
                        ARM_Agent_ID});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void Check_BSOAsync(string BSO_ser, string BSO_num, string ARM_Agent_ID) {
            this.Check_BSOAsync(BSO_ser, BSO_num, ARM_Agent_ID, null);
        }
        
        /// <remarks/>
        public void Check_BSOAsync(string BSO_ser, string BSO_num, string ARM_Agent_ID, object userState) {
            if ((this.Check_BSOOperationCompleted == null)) {
                this.Check_BSOOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCheck_BSOOperationCompleted);
            }
            this.InvokeAsync("Check_BSO", new object[] {
                        BSO_ser,
                        BSO_num,
                        ARM_Agent_ID}, this.Check_BSOOperationCompleted, userState);
        }
        
        private void OnCheck_BSOOperationCompleted(object arg) {
            if ((this.Check_BSOCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Check_BSOCompleted(this, new Check_BSOCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:APO2_ARM_READER_c-IAPO2_ARM_READER#Check_BSO2", RequestNamespace="urn:APO2_ARM_READER_c-IAPO2_ARM_READER", ResponseNamespace="urn:APO2_ARM_READER_c-IAPO2_ARM_READER")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public int Check_BSO2(string BSO_ser, string BSO_num, string ARM_Agent_ID, int bso_type_id) {
            object[] results = this.Invoke("Check_BSO2", new object[] {
                        BSO_ser,
                        BSO_num,
                        ARM_Agent_ID,
                        bso_type_id});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void Check_BSO2Async(string BSO_ser, string BSO_num, string ARM_Agent_ID, int bso_type_id) {
            this.Check_BSO2Async(BSO_ser, BSO_num, ARM_Agent_ID, bso_type_id, null);
        }
        
        /// <remarks/>
        public void Check_BSO2Async(string BSO_ser, string BSO_num, string ARM_Agent_ID, int bso_type_id, object userState) {
            if ((this.Check_BSO2OperationCompleted == null)) {
                this.Check_BSO2OperationCompleted = new System.Threading.SendOrPostCallback(this.OnCheck_BSO2OperationCompleted);
            }
            this.InvokeAsync("Check_BSO2", new object[] {
                        BSO_ser,
                        BSO_num,
                        ARM_Agent_ID,
                        bso_type_id}, this.Check_BSO2OperationCompleted, userState);
        }
        
        private void OnCheck_BSO2OperationCompleted(object arg) {
            if ((this.Check_BSO2Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Check_BSO2Completed(this, new Check_BSO2CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:APO2_ARM_READER_c-IAPO2_ARM_READER#Check_BSO3", RequestNamespace="urn:APO2_ARM_READER_c-IAPO2_ARM_READER", ResponseNamespace="urn:APO2_ARM_READER_c-IAPO2_ARM_READER")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public int Check_BSO3(string BSO_ser, string BSO_num) {
            object[] results = this.Invoke("Check_BSO3", new object[] {
                        BSO_ser,
                        BSO_num});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void Check_BSO3Async(string BSO_ser, string BSO_num) {
            this.Check_BSO3Async(BSO_ser, BSO_num, null);
        }
        
        /// <remarks/>
        public void Check_BSO3Async(string BSO_ser, string BSO_num, object userState) {
            if ((this.Check_BSO3OperationCompleted == null)) {
                this.Check_BSO3OperationCompleted = new System.Threading.SendOrPostCallback(this.OnCheck_BSO3OperationCompleted);
            }
            this.InvokeAsync("Check_BSO3", new object[] {
                        BSO_ser,
                        BSO_num}, this.Check_BSO3OperationCompleted, userState);
        }
        
        private void OnCheck_BSO3OperationCompleted(object arg) {
            if ((this.Check_BSO3Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Check_BSO3Completed(this, new Check_BSO3CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:APO2_ARM_READER_c-IAPO2_ARM_READER#Check_BSO4", RequestNamespace="urn:APO2_ARM_READER_c-IAPO2_ARM_READER", ResponseNamespace="urn:APO2_ARM_READER_c-IAPO2_ARM_READER")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string Check_BSO4(string BSO_ser, string BSO_num, int BSO_TypeID, string Agent_LNR, string Agent_SKK) {
            object[] results = this.Invoke("Check_BSO4", new object[] {
                        BSO_ser,
                        BSO_num,
                        BSO_TypeID,
                        Agent_LNR,
                        Agent_SKK});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void Check_BSO4Async(string BSO_ser, string BSO_num, int BSO_TypeID, string Agent_LNR, string Agent_SKK) {
            this.Check_BSO4Async(BSO_ser, BSO_num, BSO_TypeID, Agent_LNR, Agent_SKK, null);
        }
        
        /// <remarks/>
        public void Check_BSO4Async(string BSO_ser, string BSO_num, int BSO_TypeID, string Agent_LNR, string Agent_SKK, object userState) {
            if ((this.Check_BSO4OperationCompleted == null)) {
                this.Check_BSO4OperationCompleted = new System.Threading.SendOrPostCallback(this.OnCheck_BSO4OperationCompleted);
            }
            this.InvokeAsync("Check_BSO4", new object[] {
                        BSO_ser,
                        BSO_num,
                        BSO_TypeID,
                        Agent_LNR,
                        Agent_SKK}, this.Check_BSO4OperationCompleted, userState);
        }
        
        private void OnCheck_BSO4OperationCompleted(object arg) {
            if ((this.Check_BSO4Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Check_BSO4Completed(this, new Check_BSO4CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:APO2_ARM_READER_c-IAPO2_ARM_READER#Check_BSO5", RequestNamespace="urn:APO2_ARM_READER_c-IAPO2_ARM_READER", ResponseNamespace="urn:APO2_ARM_READER_c-IAPO2_ARM_READER")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string Check_BSO5(string BSO_ser, string BSO_num, int BSO_TypeID, string Agent_LNR, string Agent_SKK, string Date_of_Issue) {
            object[] results = this.Invoke("Check_BSO5", new object[] {
                        BSO_ser,
                        BSO_num,
                        BSO_TypeID,
                        Agent_LNR,
                        Agent_SKK,
                        Date_of_Issue});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void Check_BSO5Async(string BSO_ser, string BSO_num, int BSO_TypeID, string Agent_LNR, string Agent_SKK, string Date_of_Issue) {
            this.Check_BSO5Async(BSO_ser, BSO_num, BSO_TypeID, Agent_LNR, Agent_SKK, Date_of_Issue, null);
        }
        
        /// <remarks/>
        public void Check_BSO5Async(string BSO_ser, string BSO_num, int BSO_TypeID, string Agent_LNR, string Agent_SKK, string Date_of_Issue, object userState) {
            if ((this.Check_BSO5OperationCompleted == null)) {
                this.Check_BSO5OperationCompleted = new System.Threading.SendOrPostCallback(this.OnCheck_BSO5OperationCompleted);
            }
            this.InvokeAsync("Check_BSO5", new object[] {
                        BSO_ser,
                        BSO_num,
                        BSO_TypeID,
                        Agent_LNR,
                        Agent_SKK,
                        Date_of_Issue}, this.Check_BSO5OperationCompleted, userState);
        }
        
        private void OnCheck_BSO5OperationCompleted(object arg) {
            if ((this.Check_BSO5Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Check_BSO5Completed(this, new Check_BSO5CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:APO2_ARM_READER_c-IAPO2_ARM_READER#GetData", RequestNamespace="urn:APO2_ARM_READER_c-IAPO2_ARM_READER", ResponseNamespace="urn:APO2_ARM_READER_c-IAPO2_ARM_READER")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string GetData(string XML) {
            object[] results = this.Invoke("GetData", new object[] {
                        XML});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetDataAsync(string XML) {
            this.GetDataAsync(XML, null);
        }
        
        /// <remarks/>
        public void GetDataAsync(string XML, object userState) {
            if ((this.GetDataOperationCompleted == null)) {
                this.GetDataOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDataOperationCompleted);
            }
            this.InvokeAsync("GetData", new object[] {
                        XML}, this.GetDataOperationCompleted, userState);
        }
        
        private void OnGetDataOperationCompleted(object arg) {
            if ((this.GetDataCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetDataCompleted(this, new GetDataCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:APO2_ARM_READER_c-IAPO2_ARM_READER#GetFactDatabyAgentID", RequestNamespace="urn:APO2_ARM_READER_c-IAPO2_ARM_READER", ResponseNamespace="urn:APO2_ARM_READER_c-IAPO2_ARM_READER")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string GetFactDatabyAgentID(string AgentID, [System.Xml.Serialization.SoapElementAttribute(DataType="date")] System.DateTime dt) {
            object[] results = this.Invoke("GetFactDatabyAgentID", new object[] {
                        AgentID,
                        dt});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetFactDatabyAgentIDAsync(string AgentID, System.DateTime dt) {
            this.GetFactDatabyAgentIDAsync(AgentID, dt, null);
        }
        
        /// <remarks/>
        public void GetFactDatabyAgentIDAsync(string AgentID, System.DateTime dt, object userState) {
            if ((this.GetFactDatabyAgentIDOperationCompleted == null)) {
                this.GetFactDatabyAgentIDOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetFactDatabyAgentIDOperationCompleted);
            }
            this.InvokeAsync("GetFactDatabyAgentID", new object[] {
                        AgentID,
                        dt}, this.GetFactDatabyAgentIDOperationCompleted, userState);
        }
        
        private void OnGetFactDatabyAgentIDOperationCompleted(object arg) {
            if ((this.GetFactDatabyAgentIDCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetFactDatabyAgentIDCompleted(this, new GetFactDatabyAgentIDCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:APO2_ARM_READER_c-IAPO2_ARM_READER#GetAgentsByLNR_INN", RequestNamespace="urn:APO2_ARM_READER_c-IAPO2_ARM_READER", ResponseNamespace="urn:APO2_ARM_READER_c-IAPO2_ARM_READER")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string GetAgentsByLNR_INN(string LNR_INN, int fuz_yur_ii) {
            object[] results = this.Invoke("GetAgentsByLNR_INN", new object[] {
                        LNR_INN,
                        fuz_yur_ii});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetAgentsByLNR_INNAsync(string LNR_INN, int fuz_yur_ii) {
            this.GetAgentsByLNR_INNAsync(LNR_INN, fuz_yur_ii, null);
        }
        
        /// <remarks/>
        public void GetAgentsByLNR_INNAsync(string LNR_INN, int fuz_yur_ii, object userState) {
            if ((this.GetAgentsByLNR_INNOperationCompleted == null)) {
                this.GetAgentsByLNR_INNOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAgentsByLNR_INNOperationCompleted);
            }
            this.InvokeAsync("GetAgentsByLNR_INN", new object[] {
                        LNR_INN,
                        fuz_yur_ii}, this.GetAgentsByLNR_INNOperationCompleted, userState);
        }
        
        private void OnGetAgentsByLNR_INNOperationCompleted(object arg) {
            if ((this.GetAgentsByLNR_INNCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAgentsByLNR_INNCompleted(this, new GetAgentsByLNR_INNCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:APO2_ARM_READER_c-IAPO2_ARM_READER#CheckPreferentialExtension", RequestNamespace="urn:APO2_ARM_READER_c-IAPO2_ARM_READER", ResponseNamespace="urn:APO2_ARM_READER_c-IAPO2_ARM_READER")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string CheckPreferentialExtension(string request_xml) {
            object[] results = this.Invoke("CheckPreferentialExtension", new object[] {
                        request_xml});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void CheckPreferentialExtensionAsync(string request_xml) {
            this.CheckPreferentialExtensionAsync(request_xml, null);
        }
        
        /// <remarks/>
        public void CheckPreferentialExtensionAsync(string request_xml, object userState) {
            if ((this.CheckPreferentialExtensionOperationCompleted == null)) {
                this.CheckPreferentialExtensionOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCheckPreferentialExtensionOperationCompleted);
            }
            this.InvokeAsync("CheckPreferentialExtension", new object[] {
                        request_xml}, this.CheckPreferentialExtensionOperationCompleted, userState);
        }
        
        private void OnCheckPreferentialExtensionOperationCompleted(object arg) {
            if ((this.CheckPreferentialExtensionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CheckPreferentialExtensionCompleted(this, new CheckPreferentialExtensionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:APO2_ARM_READER_c-IAPO2_ARM_READER#GetInfoContracts", RequestNamespace="urn:APO2_ARM_READER_c-IAPO2_ARM_READER", ResponseNamespace="urn:APO2_ARM_READER_c-IAPO2_ARM_READER")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string GetInfoContracts(string request_xml) {
            object[] results = this.Invoke("GetInfoContracts", new object[] {
                        request_xml});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetInfoContractsAsync(string request_xml) {
            this.GetInfoContractsAsync(request_xml, null);
        }
        
        /// <remarks/>
        public void GetInfoContractsAsync(string request_xml, object userState) {
            if ((this.GetInfoContractsOperationCompleted == null)) {
                this.GetInfoContractsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetInfoContractsOperationCompleted);
            }
            this.InvokeAsync("GetInfoContracts", new object[] {
                        request_xml}, this.GetInfoContractsOperationCompleted, userState);
        }
        
        private void OnGetInfoContractsOperationCompleted(object arg) {
            if ((this.GetInfoContractsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetInfoContractsCompleted(this, new GetInfoContractsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    public delegate void Check_BSOCompletedEventHandler(object sender, Check_BSOCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Check_BSOCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Check_BSOCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    public delegate void Check_BSO2CompletedEventHandler(object sender, Check_BSO2CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Check_BSO2CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Check_BSO2CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    public delegate void Check_BSO3CompletedEventHandler(object sender, Check_BSO3CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Check_BSO3CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Check_BSO3CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    public delegate void Check_BSO4CompletedEventHandler(object sender, Check_BSO4CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Check_BSO4CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Check_BSO4CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    public delegate void Check_BSO5CompletedEventHandler(object sender, Check_BSO5CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Check_BSO5CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Check_BSO5CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    public delegate void GetDataCompletedEventHandler(object sender, GetDataCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetDataCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetDataCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    public delegate void GetFactDatabyAgentIDCompletedEventHandler(object sender, GetFactDatabyAgentIDCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetFactDatabyAgentIDCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetFactDatabyAgentIDCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    public delegate void GetAgentsByLNR_INNCompletedEventHandler(object sender, GetAgentsByLNR_INNCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAgentsByLNR_INNCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAgentsByLNR_INNCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    public delegate void CheckPreferentialExtensionCompletedEventHandler(object sender, CheckPreferentialExtensionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CheckPreferentialExtensionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CheckPreferentialExtensionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    public delegate void GetInfoContractsCompletedEventHandler(object sender, GetInfoContractsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3761.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetInfoContractsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetInfoContractsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591
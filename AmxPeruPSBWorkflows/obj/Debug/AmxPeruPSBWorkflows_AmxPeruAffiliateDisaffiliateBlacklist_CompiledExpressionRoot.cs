namespace AmxPeruPSBWorkflows {
    
    #line 29 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruAffiliateDisaffiliateBlacklist.xaml"
    using System;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruAffiliateDisaffiliateBlacklist.xaml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 30 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruAffiliateDisaffiliateBlacklist.xaml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruAffiliateDisaffiliateBlacklist.xaml"
    using System.Activities;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruAffiliateDisaffiliateBlacklist.xaml"
    using System.Activities.Expressions;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruAffiliateDisaffiliateBlacklist.xaml"
    using System.Activities.Statements;
    
    #line default
    #line hidden
    
    #line 31 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruAffiliateDisaffiliateBlacklist.xaml"
    using System.Data;
    
    #line default
    #line hidden
    
    #line 32 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruAffiliateDisaffiliateBlacklist.xaml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 33 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruAffiliateDisaffiliateBlacklist.xaml"
    using System.Text;
    
    #line default
    #line hidden
    
    #line 34 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruAffiliateDisaffiliateBlacklist.xaml"
    using AmxPeruPSBActivities.Model.AffiliateDisaffiliate;
    
    #line default
    #line hidden
    
    #line 35 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruAffiliateDisaffiliateBlacklist.xaml"
    using AmxPeruPSBActivities.Model.OrderCaptureSubmit;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruAffiliateDisaffiliateBlacklist.xaml"
    using System.Activities.XamlIntegration;
    
    #line default
    #line hidden
    
    
    public partial class AmxPeruAffiliateDisaffiliateBlacklist : System.Activities.XamlIntegration.ICompiledExpressionRoot {
        
        private System.Activities.Activity rootActivity;
        
        private object dataContextActivities;
        
        private bool forImplementation = true;
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string GetLanguage() {
            return "C#";
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public object InvokeExpression(int expressionId, System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext) {
            if ((this.rootActivity == null)) {
                this.rootActivity = this;
            }
            if ((this.dataContextActivities == null)) {
                this.dataContextActivities = AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2.GetDataContextActivitiesHelper(this.rootActivity, this.forImplementation);
            }
            if ((expressionId == 0)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 5);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2(locations, activityContext, true);
                }
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2 refDataContext0 = ((AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 1)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 5);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2_ForReadOnly valDataContext1 = ((AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 5);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly valDataContext2 = ((AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext2.ValueType___Expr2Get();
            }
            if ((expressionId == 3)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 5);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3(locations, activityContext, true);
                }
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3 refDataContext3 = ((AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext3.GetLocation<AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest>(refDataContext3.ValueType___Expr3Get, refDataContext3.ValueType___Expr3Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 4)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 5);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3(locations, activityContext, true);
                }
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3 refDataContext4 = ((AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext4.GetLocation<string>(refDataContext4.ValueType___Expr4Get, refDataContext4.ValueType___Expr4Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 5)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 5);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3(locations, activityContext, true);
                }
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3 refDataContext5 = ((AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext5.GetLocation<string>(refDataContext5.ValueType___Expr5Get, refDataContext5.ValueType___Expr5Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 6)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 5);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly valDataContext6 = ((AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 5);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly valDataContext7 = ((AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 5);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3(locations, activityContext, true);
                }
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3 refDataContext8 = ((AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext8.GetLocation<AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest>(refDataContext8.ValueType___Expr8Get, refDataContext8.ValueType___Expr8Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 9)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 5);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly valDataContext9 = ((AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext9.ValueType___Expr9Get();
            }
            if ((expressionId == 10)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 5);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly valDataContext10 = ((AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 5);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3(locations, activityContext, true);
                }
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3 refDataContext11 = ((AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext11.GetLocation<AmxPeruPSBActivities.Model.AffiliateDisaffiliate.SubscriptionBlacklistResponse>(refDataContext11.ValueType___Expr11Get, refDataContext11.ValueType___Expr11Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 12)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 5);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly valDataContext12 = ((AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext12.ValueType___Expr12Get();
            }
            if ((expressionId == 13)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 5);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext4_ForReadOnly valDataContext13 = ((AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext13.ValueType___Expr13Get();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public object InvokeExpression(int expressionId, System.Collections.Generic.IList<System.Activities.Location> locations) {
            if ((this.rootActivity == null)) {
                this.rootActivity = this;
            }
            if ((expressionId == 0)) {
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2 refDataContext0 = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2(locations, true);
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set);
            }
            if ((expressionId == 1)) {
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2_ForReadOnly valDataContext1 = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly valDataContext2 = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext2.ValueType___Expr2Get();
            }
            if ((expressionId == 3)) {
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3 refDataContext3 = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3(locations, true);
                return refDataContext3.GetLocation<AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest>(refDataContext3.ValueType___Expr3Get, refDataContext3.ValueType___Expr3Set);
            }
            if ((expressionId == 4)) {
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3 refDataContext4 = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3(locations, true);
                return refDataContext4.GetLocation<string>(refDataContext4.ValueType___Expr4Get, refDataContext4.ValueType___Expr4Set);
            }
            if ((expressionId == 5)) {
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3 refDataContext5 = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3(locations, true);
                return refDataContext5.GetLocation<string>(refDataContext5.ValueType___Expr5Get, refDataContext5.ValueType___Expr5Set);
            }
            if ((expressionId == 6)) {
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly valDataContext6 = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly valDataContext7 = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3 refDataContext8 = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3(locations, true);
                return refDataContext8.GetLocation<AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest>(refDataContext8.ValueType___Expr8Get, refDataContext8.ValueType___Expr8Set);
            }
            if ((expressionId == 9)) {
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly valDataContext9 = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext9.ValueType___Expr9Get();
            }
            if ((expressionId == 10)) {
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly valDataContext10 = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3 refDataContext11 = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3(locations, true);
                return refDataContext11.GetLocation<AmxPeruPSBActivities.Model.AffiliateDisaffiliate.SubscriptionBlacklistResponse>(refDataContext11.ValueType___Expr11Get, refDataContext11.ValueType___Expr11Set);
            }
            if ((expressionId == 12)) {
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly valDataContext12 = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext12.ValueType___Expr12Get();
            }
            if ((expressionId == 13)) {
                AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext4_ForReadOnly valDataContext13 = new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext13.ValueType___Expr13Get();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool CanExecuteExpression(string expressionText, bool isReference, System.Collections.Generic.IList<System.Activities.LocationReference> locations, out int expressionId) {
            if (((isReference == true) 
                        && ((expressionText == "connectionString") 
                        && (AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 0;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "connectionString") 
                        && (AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 1;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "BlacklistRequest") 
                        && (AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 2;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "BlacklistResponse") 
                        && (AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 3;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "orderSubmitEndpoint") 
                        && (AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 4;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "eocTimoutInMiliseconds") 
                        && (AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 5;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "BlacklistResponse") 
                        && (AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 6;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "Ericsson.PSB.Workflow.Client.Core.Serializer.JsonSettings.Custom") 
                        && (AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 7;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "omResponse") 
                        && (AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 8;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "eocTimoutInMiliseconds") 
                        && (AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 9;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "orderSubmitEndpoint") 
                        && (AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 10;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "SubscriptionResponse") 
                        && (AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 11;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "BlacklistRequest") 
                        && (AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 12;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new Exception(httpRequestException.Message)") 
                        && (AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 13;
                return true;
            }
            expressionId = -1;
            return false;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Collections.Generic.IList<string> GetRequiredLocations(int expressionId) {
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Linq.Expressions.Expression GetExpressionTreeForExpression(int expressionId, System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) {
            if ((expressionId == 0)) {
                return new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2(locationReferences).@__Expr0GetTree();
            }
            if ((expressionId == 1)) {
                return new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2_ForReadOnly(locationReferences).@__Expr1GetTree();
            }
            if ((expressionId == 2)) {
                return new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly(locationReferences).@__Expr2GetTree();
            }
            if ((expressionId == 3)) {
                return new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3(locationReferences).@__Expr3GetTree();
            }
            if ((expressionId == 4)) {
                return new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3(locationReferences).@__Expr4GetTree();
            }
            if ((expressionId == 5)) {
                return new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3(locationReferences).@__Expr5GetTree();
            }
            if ((expressionId == 6)) {
                return new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly(locationReferences).@__Expr6GetTree();
            }
            if ((expressionId == 7)) {
                return new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly(locationReferences).@__Expr7GetTree();
            }
            if ((expressionId == 8)) {
                return new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3(locationReferences).@__Expr8GetTree();
            }
            if ((expressionId == 9)) {
                return new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly(locationReferences).@__Expr9GetTree();
            }
            if ((expressionId == 10)) {
                return new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly(locationReferences).@__Expr10GetTree();
            }
            if ((expressionId == 11)) {
                return new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3(locationReferences).@__Expr11GetTree();
            }
            if ((expressionId == 12)) {
                return new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly(locationReferences).@__Expr12GetTree();
            }
            if ((expressionId == 13)) {
                return new AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext4_ForReadOnly(locationReferences).@__Expr13GetTree();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext0 : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext0(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal static object GetDataContextActivitiesHelper(System.Activities.Activity compiledRoot, bool forImplementation) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetDataContextActivities(compiledRoot, forImplementation);
            }
            
            internal static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
            }
            
            public static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 0))) {
                    return false;
                }
                expectedLocationsCount = 0;
                return true;
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext0_ForReadOnly : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            internal static object GetDataContextActivitiesHelper(System.Activities.Activity compiledRoot, bool forImplementation) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetDataContextActivities(compiledRoot, forImplementation);
            }
            
            internal static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
            }
            
            public static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 0))) {
                    return false;
                }
                expectedLocationsCount = 0;
                return true;
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext1 : AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext0 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext1(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected AmxPeruPSBActivities.Model.AffiliateDisaffiliate.SubscriptionBlacklistResponse SubscriptionResponse {
                get {
                    return ((AmxPeruPSBActivities.Model.AffiliateDisaffiliate.SubscriptionBlacklistResponse)(this.GetVariableValue((0 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((0 + locationsOffset), value);
                }
            }
            
            protected AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AffiliateDisaffilateBlacklistRequest BlacklistRequest {
                get {
                    return ((AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AffiliateDisaffilateBlacklistRequest)(this.GetVariableValue((1 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((1 + locationsOffset), value);
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 2))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 2);
                }
                expectedLocationsCount = 2;
                if (((locationReferences[(offset + 0)].Name != "SubscriptionResponse") 
                            || (locationReferences[(offset + 0)].Type != typeof(AmxPeruPSBActivities.Model.AffiliateDisaffiliate.SubscriptionBlacklistResponse)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "BlacklistRequest") 
                            || (locationReferences[(offset + 1)].Type != typeof(AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AffiliateDisaffilateBlacklistRequest)))) {
                    return false;
                }
                return AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext0.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext1_ForReadOnly : AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext0_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected AmxPeruPSBActivities.Model.AffiliateDisaffiliate.SubscriptionBlacklistResponse SubscriptionResponse {
                get {
                    return ((AmxPeruPSBActivities.Model.AffiliateDisaffiliate.SubscriptionBlacklistResponse)(this.GetVariableValue((0 + locationsOffset))));
                }
            }
            
            protected AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AffiliateDisaffilateBlacklistRequest BlacklistRequest {
                get {
                    return ((AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AffiliateDisaffilateBlacklistRequest)(this.GetVariableValue((1 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 2))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 2);
                }
                expectedLocationsCount = 2;
                if (((locationReferences[(offset + 0)].Name != "SubscriptionResponse") 
                            || (locationReferences[(offset + 0)].Type != typeof(AmxPeruPSBActivities.Model.AffiliateDisaffiliate.SubscriptionBlacklistResponse)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "BlacklistRequest") 
                            || (locationReferences[(offset + 1)].Type != typeof(AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AffiliateDisaffilateBlacklistRequest)))) {
                    return false;
                }
                return AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext0_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2 : AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext1 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string connectionString {
                get {
                    return ((string)(this.GetVariableValue((2 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((2 + locationsOffset), value);
                }
            }
            
            protected string orderSubmitEndpoint {
                get {
                    return ((string)(this.GetVariableValue((3 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((3 + locationsOffset), value);
                }
            }
            
            protected string eocTimoutInMiliseconds {
                get {
                    return ((string)(this.GetVariableValue((4 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((4 + locationsOffset), value);
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr0GetTree() {
                
                #line 84 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
              connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr0Get() {
                
                #line 84 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                return 
              connectionString;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr0Get() {
                this.GetValueTypeValues();
                return this.@__Expr0Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr0Set(string value) {
                
                #line 84 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                
              connectionString = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr0Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr0Set(value);
                this.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 5))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 5);
                }
                expectedLocationsCount = 5;
                if (((locationReferences[(offset + 2)].Name != "connectionString") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "orderSubmitEndpoint") 
                            || (locationReferences[(offset + 3)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "eocTimoutInMiliseconds") 
                            || (locationReferences[(offset + 4)].Type != typeof(string)))) {
                    return false;
                }
                return AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext1.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2_ForReadOnly : AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext1_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string connectionString {
                get {
                    return ((string)(this.GetVariableValue((2 + locationsOffset))));
                }
            }
            
            protected string orderSubmitEndpoint {
                get {
                    return ((string)(this.GetVariableValue((3 + locationsOffset))));
                }
            }
            
            protected string eocTimoutInMiliseconds {
                get {
                    return ((string)(this.GetVariableValue((4 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr1GetTree() {
                
                #line 184 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr1Get() {
                
                #line 184 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                return 
                  connectionString;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr1Get() {
                this.GetValueTypeValues();
                return this.@__Expr1Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 5))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 5);
                }
                expectedLocationsCount = 5;
                if (((locationReferences[(offset + 2)].Name != "connectionString") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "orderSubmitEndpoint") 
                            || (locationReferences[(offset + 3)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "eocTimoutInMiliseconds") 
                            || (locationReferences[(offset + 4)].Type != typeof(string)))) {
                    return false;
                }
                return AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext1_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3 : AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest omResponse {
                get {
                    return ((AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest)(this.GetVariableValue((5 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((5 + locationsOffset), value);
                }
            }
            
            protected AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest BlacklistResponse {
                get {
                    return ((AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest)(this.GetVariableValue((6 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((6 + locationsOffset), value);
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr3GetTree() {
                
                #line 107 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest>> expression = () => 
                            BlacklistResponse;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest @__Expr3Get() {
                
                #line 107 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                return 
                            BlacklistResponse;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest ValueType___Expr3Get() {
                this.GetValueTypeValues();
                return this.@__Expr3Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr3Set(AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest value) {
                
                #line 107 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                
                            BlacklistResponse = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr3Set(AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest value) {
                this.GetValueTypeValues();
                this.@__Expr3Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr4GetTree() {
                
                #line 114 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                            orderSubmitEndpoint;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr4Get() {
                
                #line 114 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                return 
                            orderSubmitEndpoint;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr4Get() {
                this.GetValueTypeValues();
                return this.@__Expr4Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr4Set(string value) {
                
                #line 114 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                
                            orderSubmitEndpoint = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr4Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr4Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr5GetTree() {
                
                #line 121 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                            eocTimoutInMiliseconds;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr5Get() {
                
                #line 121 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                return 
                            eocTimoutInMiliseconds;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr5Get() {
                this.GetValueTypeValues();
                return this.@__Expr5Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr5Set(string value) {
                
                #line 121 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                
                            eocTimoutInMiliseconds = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr5Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr5Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr8GetTree() {
                
                #line 138 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest>> expression = () => 
                            omResponse;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest @__Expr8Get() {
                
                #line 138 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                return 
                            omResponse;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest ValueType___Expr8Get() {
                this.GetValueTypeValues();
                return this.@__Expr8Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr8Set(AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest value) {
                
                #line 138 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                
                            omResponse = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr8Set(AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest value) {
                this.GetValueTypeValues();
                this.@__Expr8Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr11GetTree() {
                
                #line 160 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.AffiliateDisaffiliate.SubscriptionBlacklistResponse>> expression = () => 
                            SubscriptionResponse;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.AffiliateDisaffiliate.SubscriptionBlacklistResponse @__Expr11Get() {
                
                #line 160 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                return 
                            SubscriptionResponse;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.AffiliateDisaffiliate.SubscriptionBlacklistResponse ValueType___Expr11Get() {
                this.GetValueTypeValues();
                return this.@__Expr11Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr11Set(AmxPeruPSBActivities.Model.AffiliateDisaffiliate.SubscriptionBlacklistResponse value) {
                
                #line 160 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                
                            SubscriptionResponse = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr11Set(AmxPeruPSBActivities.Model.AffiliateDisaffiliate.SubscriptionBlacklistResponse value) {
                this.GetValueTypeValues();
                this.@__Expr11Set(value);
                this.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 7))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 7);
                }
                expectedLocationsCount = 7;
                if (((locationReferences[(offset + 5)].Name != "omResponse") 
                            || (locationReferences[(offset + 5)].Type != typeof(AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "BlacklistResponse") 
                            || (locationReferences[(offset + 6)].Type != typeof(AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest)))) {
                    return false;
                }
                return AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly : AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest omResponse {
                get {
                    return ((AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest)(this.GetVariableValue((5 + locationsOffset))));
                }
            }
            
            protected AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest BlacklistResponse {
                get {
                    return ((AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest)(this.GetVariableValue((6 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr2GetTree() {
                
                #line 102 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AffiliateDisaffilateBlacklistRequest>> expression = () => 
                            BlacklistRequest;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AffiliateDisaffilateBlacklistRequest @__Expr2Get() {
                
                #line 102 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                return 
                            BlacklistRequest;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AffiliateDisaffilateBlacklistRequest ValueType___Expr2Get() {
                this.GetValueTypeValues();
                return this.@__Expr2Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr6GetTree() {
                
                #line 133 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest>> expression = () => 
                            BlacklistResponse;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest @__Expr6Get() {
                
                #line 133 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                return 
                            BlacklistResponse;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest ValueType___Expr6Get() {
                this.GetValueTypeValues();
                return this.@__Expr6Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr7GetTree() {
                
                #line 128 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                System.Linq.Expressions.Expression<System.Func<Ericsson.PSB.Workflow.Client.Core.Serializer.JsonSettings>> expression = () => 
                            Ericsson.PSB.Workflow.Client.Core.Serializer.JsonSettings.Custom;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Ericsson.PSB.Workflow.Client.Core.Serializer.JsonSettings @__Expr7Get() {
                
                #line 128 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                return 
                            Ericsson.PSB.Workflow.Client.Core.Serializer.JsonSettings.Custom;
                
                #line default
                #line hidden
            }
            
            public Ericsson.PSB.Workflow.Client.Core.Serializer.JsonSettings ValueType___Expr7Get() {
                this.GetValueTypeValues();
                return this.@__Expr7Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr9GetTree() {
                
                #line 143 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                            eocTimoutInMiliseconds;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr9Get() {
                
                #line 143 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                return 
                            eocTimoutInMiliseconds;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr9Get() {
                this.GetValueTypeValues();
                return this.@__Expr9Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr10GetTree() {
                
                #line 148 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                            orderSubmitEndpoint;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr10Get() {
                
                #line 148 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                return 
                            orderSubmitEndpoint;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr10Get() {
                this.GetValueTypeValues();
                return this.@__Expr10Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr12GetTree() {
                
                #line 155 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AffiliateDisaffilateBlacklistRequest>> expression = () => 
                            BlacklistRequest;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AffiliateDisaffilateBlacklistRequest @__Expr12Get() {
                
                #line 155 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                return 
                            BlacklistRequest;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AffiliateDisaffilateBlacklistRequest ValueType___Expr12Get() {
                this.GetValueTypeValues();
                return this.@__Expr12Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 7))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 7);
                }
                expectedLocationsCount = 7;
                if (((locationReferences[(offset + 5)].Name != "omResponse") 
                            || (locationReferences[(offset + 5)].Type != typeof(AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "BlacklistResponse") 
                            || (locationReferences[(offset + 6)].Type != typeof(AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest)))) {
                    return false;
                }
                return AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext2_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext4 : AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext4(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext4(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext4(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected System.Net.Http.HttpRequestException httpRequestException {
                get {
                    return ((System.Net.Http.HttpRequestException)(this.GetVariableValue((7 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((7 + locationsOffset), value);
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 8))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 8);
                }
                expectedLocationsCount = 8;
                if (((locationReferences[(offset + 7)].Name != "httpRequestException") 
                            || (locationReferences[(offset + 7)].Type != typeof(System.Net.Http.HttpRequestException)))) {
                    return false;
                }
                return AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext4_ForReadOnly : AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext4_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext4_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext4_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected System.Net.Http.HttpRequestException httpRequestException {
                get {
                    return ((System.Net.Http.HttpRequestException)(this.GetVariableValue((7 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr13GetTree() {
                
                #line 174 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Exception>> expression = () => 
                            new Exception(httpRequestException.Message);
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Exception @__Expr13Get() {
                
                #line 174 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATEBLACKLIST.XAML"
                return 
                            new Exception(httpRequestException.Message);
                
                #line default
                #line hidden
            }
            
            public System.Exception ValueType___Expr13Get() {
                this.GetValueTypeValues();
                return this.@__Expr13Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 8))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 8);
                }
                expectedLocationsCount = 8;
                if (((locationReferences[(offset + 7)].Name != "httpRequestException") 
                            || (locationReferences[(offset + 7)].Type != typeof(System.Net.Http.HttpRequestException)))) {
                    return false;
                }
                return AmxPeruAffiliateDisaffiliateBlacklist_TypedDataContext3_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
    }
}

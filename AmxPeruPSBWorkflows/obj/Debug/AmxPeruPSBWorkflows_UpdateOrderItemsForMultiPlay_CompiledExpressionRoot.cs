namespace AmxPeruPSBWorkflows {
    
    #line 25 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\UpdateOrderItemsForMultiPlay.xaml"
    using System;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\UpdateOrderItemsForMultiPlay.xaml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 26 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\UpdateOrderItemsForMultiPlay.xaml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\UpdateOrderItemsForMultiPlay.xaml"
    using System.Activities;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\UpdateOrderItemsForMultiPlay.xaml"
    using System.Activities.Expressions;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\UpdateOrderItemsForMultiPlay.xaml"
    using System.Activities.Statements;
    
    #line default
    #line hidden
    
    #line 27 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\UpdateOrderItemsForMultiPlay.xaml"
    using System.Data;
    
    #line default
    #line hidden
    
    #line 28 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\UpdateOrderItemsForMultiPlay.xaml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 29 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\UpdateOrderItemsForMultiPlay.xaml"
    using System.Text;
    
    #line default
    #line hidden
    
    #line 30 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\UpdateOrderItemsForMultiPlay.xaml"
    using AmxPeruPSBActivities.Model;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\UpdateOrderItemsForMultiPlay.xaml"
    using System.Activities.XamlIntegration;
    
    #line default
    #line hidden
    
    
    public partial class UpdateOrderItemsForMultiPlay : System.Activities.XamlIntegration.ICompiledExpressionRoot {
        
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
                this.dataContextActivities = UpdateOrderItemsForMultiPlay_TypedDataContext2.GetDataContextActivitiesHelper(this.rootActivity, this.forImplementation);
            }
            if ((expressionId == 0)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateOrderItemsForMultiPlay_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new UpdateOrderItemsForMultiPlay_TypedDataContext2(locations, activityContext, true);
                }
                UpdateOrderItemsForMultiPlay_TypedDataContext2 refDataContext0 = ((UpdateOrderItemsForMultiPlay_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 1)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateOrderItemsForMultiPlay_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new UpdateOrderItemsForMultiPlay_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                UpdateOrderItemsForMultiPlay_TypedDataContext2_ForReadOnly valDataContext1 = ((UpdateOrderItemsForMultiPlay_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly valDataContext2 = ((UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext2.ValueType___Expr2Get();
            }
            if ((expressionId == 3)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateOrderItemsForMultiPlay_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new UpdateOrderItemsForMultiPlay_TypedDataContext3(locations, activityContext, true);
                }
                UpdateOrderItemsForMultiPlay_TypedDataContext3 refDataContext3 = ((UpdateOrderItemsForMultiPlay_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext3.GetLocation<System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>>(refDataContext3.ValueType___Expr3Get, refDataContext3.ValueType___Expr3Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 4)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateOrderItemsForMultiPlay_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new UpdateOrderItemsForMultiPlay_TypedDataContext3(locations, activityContext, true);
                }
                UpdateOrderItemsForMultiPlay_TypedDataContext3 refDataContext4 = ((UpdateOrderItemsForMultiPlay_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext4.GetLocation<System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>>(refDataContext4.ValueType___Expr4Get, refDataContext4.ValueType___Expr4Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 5)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateOrderItemsForMultiPlay_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new UpdateOrderItemsForMultiPlay_TypedDataContext3(locations, activityContext, true);
                }
                UpdateOrderItemsForMultiPlay_TypedDataContext3 refDataContext5 = ((UpdateOrderItemsForMultiPlay_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext5.GetLocation<AmxPeruPSBActivities.Model.Internet>(refDataContext5.ValueType___Expr5Get, refDataContext5.ValueType___Expr5Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 6)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly valDataContext6 = ((UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateOrderItemsForMultiPlay_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new UpdateOrderItemsForMultiPlay_TypedDataContext3(locations, activityContext, true);
                }
                UpdateOrderItemsForMultiPlay_TypedDataContext3 refDataContext7 = ((UpdateOrderItemsForMultiPlay_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext7.GetLocation<AmxPeruPSBActivities.Model.Tv>(refDataContext7.ValueType___Expr7Get, refDataContext7.ValueType___Expr7Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 8)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateOrderItemsForMultiPlay_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new UpdateOrderItemsForMultiPlay_TypedDataContext3(locations, activityContext, true);
                }
                UpdateOrderItemsForMultiPlay_TypedDataContext3 refDataContext8 = ((UpdateOrderItemsForMultiPlay_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext8.GetLocation<AmxPeruPSBActivities.Model.Telephony>(refDataContext8.ValueType___Expr8Get, refDataContext8.ValueType___Expr8Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 9)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly valDataContext9 = ((UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext9.ValueType___Expr9Get();
            }
            if ((expressionId == 10)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly valDataContext10 = ((UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly valDataContext11 = ((UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext11.ValueType___Expr11Get();
            }
            if ((expressionId == 12)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly valDataContext12 = ((UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext12.ValueType___Expr12Get();
            }
            if ((expressionId == 13)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly valDataContext13 = ((UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
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
                UpdateOrderItemsForMultiPlay_TypedDataContext2 refDataContext0 = new UpdateOrderItemsForMultiPlay_TypedDataContext2(locations, true);
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set);
            }
            if ((expressionId == 1)) {
                UpdateOrderItemsForMultiPlay_TypedDataContext2_ForReadOnly valDataContext1 = new UpdateOrderItemsForMultiPlay_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly valDataContext2 = new UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext2.ValueType___Expr2Get();
            }
            if ((expressionId == 3)) {
                UpdateOrderItemsForMultiPlay_TypedDataContext3 refDataContext3 = new UpdateOrderItemsForMultiPlay_TypedDataContext3(locations, true);
                return refDataContext3.GetLocation<System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>>(refDataContext3.ValueType___Expr3Get, refDataContext3.ValueType___Expr3Set);
            }
            if ((expressionId == 4)) {
                UpdateOrderItemsForMultiPlay_TypedDataContext3 refDataContext4 = new UpdateOrderItemsForMultiPlay_TypedDataContext3(locations, true);
                return refDataContext4.GetLocation<System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>>(refDataContext4.ValueType___Expr4Get, refDataContext4.ValueType___Expr4Set);
            }
            if ((expressionId == 5)) {
                UpdateOrderItemsForMultiPlay_TypedDataContext3 refDataContext5 = new UpdateOrderItemsForMultiPlay_TypedDataContext3(locations, true);
                return refDataContext5.GetLocation<AmxPeruPSBActivities.Model.Internet>(refDataContext5.ValueType___Expr5Get, refDataContext5.ValueType___Expr5Set);
            }
            if ((expressionId == 6)) {
                UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly valDataContext6 = new UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                UpdateOrderItemsForMultiPlay_TypedDataContext3 refDataContext7 = new UpdateOrderItemsForMultiPlay_TypedDataContext3(locations, true);
                return refDataContext7.GetLocation<AmxPeruPSBActivities.Model.Tv>(refDataContext7.ValueType___Expr7Get, refDataContext7.ValueType___Expr7Set);
            }
            if ((expressionId == 8)) {
                UpdateOrderItemsForMultiPlay_TypedDataContext3 refDataContext8 = new UpdateOrderItemsForMultiPlay_TypedDataContext3(locations, true);
                return refDataContext8.GetLocation<AmxPeruPSBActivities.Model.Telephony>(refDataContext8.ValueType___Expr8Get, refDataContext8.ValueType___Expr8Set);
            }
            if ((expressionId == 9)) {
                UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly valDataContext9 = new UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext9.ValueType___Expr9Get();
            }
            if ((expressionId == 10)) {
                UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly valDataContext10 = new UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly valDataContext11 = new UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext11.ValueType___Expr11Get();
            }
            if ((expressionId == 12)) {
                UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly valDataContext12 = new UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext12.ValueType___Expr12Get();
            }
            if ((expressionId == 13)) {
                UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly valDataContext13 = new UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly(locations, true);
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
                        && (UpdateOrderItemsForMultiPlay_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 0;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "connectionString") 
                        && (UpdateOrderItemsForMultiPlay_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 1;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "orderCaptureId") 
                        && (UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 2;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "orderItemList") 
                        && (UpdateOrderItemsForMultiPlay_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 3;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "infoTableValues") 
                        && (UpdateOrderItemsForMultiPlay_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 4;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "internet") 
                        && (UpdateOrderItemsForMultiPlay_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 5;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "estrato") 
                        && (UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 6;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "tv") 
                        && (UpdateOrderItemsForMultiPlay_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 7;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "telephony") 
                        && (UpdateOrderItemsForMultiPlay_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 8;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "orderItemList") 
                        && (UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 9;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "infoTableValues") 
                        && (UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 10;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "internet") 
                        && (UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 11;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "tv") 
                        && (UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 12;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "telephony") 
                        && (UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
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
                return new UpdateOrderItemsForMultiPlay_TypedDataContext2(locationReferences).@__Expr0GetTree();
            }
            if ((expressionId == 1)) {
                return new UpdateOrderItemsForMultiPlay_TypedDataContext2_ForReadOnly(locationReferences).@__Expr1GetTree();
            }
            if ((expressionId == 2)) {
                return new UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly(locationReferences).@__Expr2GetTree();
            }
            if ((expressionId == 3)) {
                return new UpdateOrderItemsForMultiPlay_TypedDataContext3(locationReferences).@__Expr3GetTree();
            }
            if ((expressionId == 4)) {
                return new UpdateOrderItemsForMultiPlay_TypedDataContext3(locationReferences).@__Expr4GetTree();
            }
            if ((expressionId == 5)) {
                return new UpdateOrderItemsForMultiPlay_TypedDataContext3(locationReferences).@__Expr5GetTree();
            }
            if ((expressionId == 6)) {
                return new UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly(locationReferences).@__Expr6GetTree();
            }
            if ((expressionId == 7)) {
                return new UpdateOrderItemsForMultiPlay_TypedDataContext3(locationReferences).@__Expr7GetTree();
            }
            if ((expressionId == 8)) {
                return new UpdateOrderItemsForMultiPlay_TypedDataContext3(locationReferences).@__Expr8GetTree();
            }
            if ((expressionId == 9)) {
                return new UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly(locationReferences).@__Expr9GetTree();
            }
            if ((expressionId == 10)) {
                return new UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly(locationReferences).@__Expr10GetTree();
            }
            if ((expressionId == 11)) {
                return new UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly(locationReferences).@__Expr11GetTree();
            }
            if ((expressionId == 12)) {
                return new UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly(locationReferences).@__Expr12GetTree();
            }
            if ((expressionId == 13)) {
                return new UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly(locationReferences).@__Expr13GetTree();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class UpdateOrderItemsForMultiPlay_TypedDataContext0 : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public UpdateOrderItemsForMultiPlay_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateOrderItemsForMultiPlay_TypedDataContext0(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateOrderItemsForMultiPlay_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class UpdateOrderItemsForMultiPlay_TypedDataContext0_ForReadOnly : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public UpdateOrderItemsForMultiPlay_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateOrderItemsForMultiPlay_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateOrderItemsForMultiPlay_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class UpdateOrderItemsForMultiPlay_TypedDataContext1 : UpdateOrderItemsForMultiPlay_TypedDataContext0 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public UpdateOrderItemsForMultiPlay_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateOrderItemsForMultiPlay_TypedDataContext1(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateOrderItemsForMultiPlay_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string orderCaptureId {
                get {
                    return ((string)(this.GetVariableValue((0 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((0 + locationsOffset), value);
                }
            }
            
            protected string estrato {
                get {
                    return ((string)(this.GetVariableValue((1 + locationsOffset))));
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
                if (((locationReferences[(offset + 0)].Name != "orderCaptureId") 
                            || (locationReferences[(offset + 0)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "estrato") 
                            || (locationReferences[(offset + 1)].Type != typeof(string)))) {
                    return false;
                }
                return UpdateOrderItemsForMultiPlay_TypedDataContext0.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class UpdateOrderItemsForMultiPlay_TypedDataContext1_ForReadOnly : UpdateOrderItemsForMultiPlay_TypedDataContext0_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public UpdateOrderItemsForMultiPlay_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateOrderItemsForMultiPlay_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateOrderItemsForMultiPlay_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string orderCaptureId {
                get {
                    return ((string)(this.GetVariableValue((0 + locationsOffset))));
                }
            }
            
            protected string estrato {
                get {
                    return ((string)(this.GetVariableValue((1 + locationsOffset))));
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
                if (((locationReferences[(offset + 0)].Name != "orderCaptureId") 
                            || (locationReferences[(offset + 0)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "estrato") 
                            || (locationReferences[(offset + 1)].Type != typeof(string)))) {
                    return false;
                }
                return UpdateOrderItemsForMultiPlay_TypedDataContext0_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class UpdateOrderItemsForMultiPlay_TypedDataContext2 : UpdateOrderItemsForMultiPlay_TypedDataContext1 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public UpdateOrderItemsForMultiPlay_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateOrderItemsForMultiPlay_TypedDataContext2(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateOrderItemsForMultiPlay_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr0GetTree() {
                
                #line 79 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
              connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr0Get() {
                
                #line 79 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
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
                
                #line 79 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                
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
                            && (locationReferences.Count < 3))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 3);
                }
                expectedLocationsCount = 3;
                if (((locationReferences[(offset + 2)].Name != "connectionString") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                return UpdateOrderItemsForMultiPlay_TypedDataContext1.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class UpdateOrderItemsForMultiPlay_TypedDataContext2_ForReadOnly : UpdateOrderItemsForMultiPlay_TypedDataContext1_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public UpdateOrderItemsForMultiPlay_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateOrderItemsForMultiPlay_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateOrderItemsForMultiPlay_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string connectionString {
                get {
                    return ((string)(this.GetVariableValue((2 + locationsOffset))));
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
                
                #line 180 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr1Get() {
                
                #line 180 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
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
                            && (locationReferences.Count < 3))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 3);
                }
                expectedLocationsCount = 3;
                if (((locationReferences[(offset + 2)].Name != "connectionString") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                return UpdateOrderItemsForMultiPlay_TypedDataContext1_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class UpdateOrderItemsForMultiPlay_TypedDataContext3 : UpdateOrderItemsForMultiPlay_TypedDataContext2 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public UpdateOrderItemsForMultiPlay_TypedDataContext3(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateOrderItemsForMultiPlay_TypedDataContext3(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateOrderItemsForMultiPlay_TypedDataContext3(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> orderItemList {
                get {
                    return ((System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>)(this.GetVariableValue((3 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((3 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> infoTableValues {
                get {
                    return ((System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>)(this.GetVariableValue((4 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((4 + locationsOffset), value);
                }
            }
            
            protected AmxPeruPSBActivities.Model.Tv tv {
                get {
                    return ((AmxPeruPSBActivities.Model.Tv)(this.GetVariableValue((5 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((5 + locationsOffset), value);
                }
            }
            
            protected AmxPeruPSBActivities.Model.Internet internet {
                get {
                    return ((AmxPeruPSBActivities.Model.Internet)(this.GetVariableValue((6 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((6 + locationsOffset), value);
                }
            }
            
            protected AmxPeruPSBActivities.Model.Telephony telephony {
                get {
                    return ((AmxPeruPSBActivities.Model.Telephony)(this.GetVariableValue((7 + locationsOffset))));
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
            
            internal System.Linq.Expressions.Expression @__Expr3GetTree() {
                
                #line 105 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>>> expression = () => 
                            orderItemList;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> @__Expr3Get() {
                
                #line 105 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                return 
                            orderItemList;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> ValueType___Expr3Get() {
                this.GetValueTypeValues();
                return this.@__Expr3Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr3Set(System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> value) {
                
                #line 105 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                
                            orderItemList = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr3Set(System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> value) {
                this.GetValueTypeValues();
                this.@__Expr3Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr4GetTree() {
                
                #line 119 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>>> expression = () => 
                                infoTableValues;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> @__Expr4Get() {
                
                #line 119 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                return 
                                infoTableValues;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> ValueType___Expr4Get() {
                this.GetValueTypeValues();
                return this.@__Expr4Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr4Set(System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> value) {
                
                #line 119 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                
                                infoTableValues = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr4Set(System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> value) {
                this.GetValueTypeValues();
                this.@__Expr4Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr5GetTree() {
                
                #line 124 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.Internet>> expression = () => 
                                internet;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.Internet @__Expr5Get() {
                
                #line 124 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                return 
                                internet;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.Internet ValueType___Expr5Get() {
                this.GetValueTypeValues();
                return this.@__Expr5Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr5Set(AmxPeruPSBActivities.Model.Internet value) {
                
                #line 124 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                
                                internet = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr5Set(AmxPeruPSBActivities.Model.Internet value) {
                this.GetValueTypeValues();
                this.@__Expr5Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr7GetTree() {
                
                #line 139 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.Tv>> expression = () => 
                                tv;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.Tv @__Expr7Get() {
                
                #line 139 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                return 
                                tv;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.Tv ValueType___Expr7Get() {
                this.GetValueTypeValues();
                return this.@__Expr7Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr7Set(AmxPeruPSBActivities.Model.Tv value) {
                
                #line 139 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                
                                tv = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr7Set(AmxPeruPSBActivities.Model.Tv value) {
                this.GetValueTypeValues();
                this.@__Expr7Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr8GetTree() {
                
                #line 134 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.Telephony>> expression = () => 
                                telephony;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.Telephony @__Expr8Get() {
                
                #line 134 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                return 
                                telephony;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.Telephony ValueType___Expr8Get() {
                this.GetValueTypeValues();
                return this.@__Expr8Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr8Set(AmxPeruPSBActivities.Model.Telephony value) {
                
                #line 134 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                
                                telephony = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr8Set(AmxPeruPSBActivities.Model.Telephony value) {
                this.GetValueTypeValues();
                this.@__Expr8Set(value);
                this.SetValueTypeValues();
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
                if (((locationReferences[(offset + 3)].Name != "orderItemList") 
                            || (locationReferences[(offset + 3)].Type != typeof(System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "infoTableValues") 
                            || (locationReferences[(offset + 4)].Type != typeof(System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 5)].Name != "tv") 
                            || (locationReferences[(offset + 5)].Type != typeof(AmxPeruPSBActivities.Model.Tv)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "internet") 
                            || (locationReferences[(offset + 6)].Type != typeof(AmxPeruPSBActivities.Model.Internet)))) {
                    return false;
                }
                if (((locationReferences[(offset + 7)].Name != "telephony") 
                            || (locationReferences[(offset + 7)].Type != typeof(AmxPeruPSBActivities.Model.Telephony)))) {
                    return false;
                }
                return UpdateOrderItemsForMultiPlay_TypedDataContext2.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly : UpdateOrderItemsForMultiPlay_TypedDataContext2_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateOrderItemsForMultiPlay_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> orderItemList {
                get {
                    return ((System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>)(this.GetVariableValue((3 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> infoTableValues {
                get {
                    return ((System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>)(this.GetVariableValue((4 + locationsOffset))));
                }
            }
            
            protected AmxPeruPSBActivities.Model.Tv tv {
                get {
                    return ((AmxPeruPSBActivities.Model.Tv)(this.GetVariableValue((5 + locationsOffset))));
                }
            }
            
            protected AmxPeruPSBActivities.Model.Internet internet {
                get {
                    return ((AmxPeruPSBActivities.Model.Internet)(this.GetVariableValue((6 + locationsOffset))));
                }
            }
            
            protected AmxPeruPSBActivities.Model.Telephony telephony {
                get {
                    return ((AmxPeruPSBActivities.Model.Telephony)(this.GetVariableValue((7 + locationsOffset))));
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
                
                #line 100 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                            orderCaptureId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr2Get() {
                
                #line 100 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                return 
                            orderCaptureId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr2Get() {
                this.GetValueTypeValues();
                return this.@__Expr2Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr6GetTree() {
                
                #line 114 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                estrato;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr6Get() {
                
                #line 114 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                return 
                                estrato;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr6Get() {
                this.GetValueTypeValues();
                return this.@__Expr6Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr9GetTree() {
                
                #line 129 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>>> expression = () => 
                                orderItemList;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> @__Expr9Get() {
                
                #line 129 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                return 
                                orderItemList;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> ValueType___Expr9Get() {
                this.GetValueTypeValues();
                return this.@__Expr9Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr10GetTree() {
                
                #line 148 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>>> expression = () => 
                                    infoTableValues;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> @__Expr10Get() {
                
                #line 148 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                return 
                                    infoTableValues;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> ValueType___Expr10Get() {
                this.GetValueTypeValues();
                return this.@__Expr10Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr11GetTree() {
                
                #line 153 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.Internet>> expression = () => 
                                    internet;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.Internet @__Expr11Get() {
                
                #line 153 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                return 
                                    internet;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.Internet ValueType___Expr11Get() {
                this.GetValueTypeValues();
                return this.@__Expr11Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr12GetTree() {
                
                #line 163 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.Tv>> expression = () => 
                                    tv;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.Tv @__Expr12Get() {
                
                #line 163 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                return 
                                    tv;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.Tv ValueType___Expr12Get() {
                this.GetValueTypeValues();
                return this.@__Expr12Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr13GetTree() {
                
                #line 158 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.Telephony>> expression = () => 
                                    telephony;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.Telephony @__Expr13Get() {
                
                #line 158 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATEORDERITEMSFORMULTIPLAY.XAML"
                return 
                                    telephony;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.Telephony ValueType___Expr13Get() {
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
                if (((locationReferences[(offset + 3)].Name != "orderItemList") 
                            || (locationReferences[(offset + 3)].Type != typeof(System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "infoTableValues") 
                            || (locationReferences[(offset + 4)].Type != typeof(System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 5)].Name != "tv") 
                            || (locationReferences[(offset + 5)].Type != typeof(AmxPeruPSBActivities.Model.Tv)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "internet") 
                            || (locationReferences[(offset + 6)].Type != typeof(AmxPeruPSBActivities.Model.Internet)))) {
                    return false;
                }
                if (((locationReferences[(offset + 7)].Name != "telephony") 
                            || (locationReferences[(offset + 7)].Type != typeof(AmxPeruPSBActivities.Model.Telephony)))) {
                    return false;
                }
                return UpdateOrderItemsForMultiPlay_TypedDataContext2_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
    }
}

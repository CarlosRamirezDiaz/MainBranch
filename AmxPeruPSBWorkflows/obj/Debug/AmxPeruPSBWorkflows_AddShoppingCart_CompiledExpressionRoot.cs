namespace AmxPeruPSBWorkflows {
    
    #line 31 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AddShoppingCart.xaml"
    using System;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AddShoppingCart.xaml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 32 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AddShoppingCart.xaml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AddShoppingCart.xaml"
    using System.Activities;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AddShoppingCart.xaml"
    using System.Activities.Expressions;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AddShoppingCart.xaml"
    using System.Activities.Statements;
    
    #line default
    #line hidden
    
    #line 33 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AddShoppingCart.xaml"
    using System.Data;
    
    #line default
    #line hidden
    
    #line 34 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AddShoppingCart.xaml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 35 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AddShoppingCart.xaml"
    using System.Text;
    
    #line default
    #line hidden
    
    #line 36 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AddShoppingCart.xaml"
    using Ericsson.ETELCRM.Entities.Crm;
    
    #line default
    #line hidden
    
    #line 37 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AddShoppingCart.xaml"
    using AmxPeruPSBActivities.Model;
    
    #line default
    #line hidden
    
    #line 38 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AddShoppingCart.xaml"
    using AmxPeruPSBActivities.Model.OrderItem;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AddShoppingCart.xaml"
    using System.Activities.XamlIntegration;
    
    #line default
    #line hidden
    
    
    public partial class AddShoppingCart : System.Activities.XamlIntegration.ICompiledExpressionRoot {
        
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
                this.dataContextActivities = AddShoppingCart_TypedDataContext2.GetDataContextActivitiesHelper(this.rootActivity, this.forImplementation);
            }
            if ((expressionId == 0)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AddShoppingCart_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AddShoppingCart_TypedDataContext2(locations, activityContext, true);
                }
                AddShoppingCart_TypedDataContext2 refDataContext0 = ((AddShoppingCart_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 1)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AddShoppingCart_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AddShoppingCart_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AddShoppingCart_TypedDataContext2_ForReadOnly valDataContext1 = ((AddShoppingCart_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AddShoppingCart_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AddShoppingCart_TypedDataContext2(locations, activityContext, true);
                }
                AddShoppingCart_TypedDataContext2 refDataContext2 = ((AddShoppingCart_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext2.GetLocation<Ericsson.ETELCRM.Entities.Crm.etel_ordercapture>(refDataContext2.ValueType___Expr2Get, refDataContext2.ValueType___Expr2Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 3)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AddShoppingCart_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AddShoppingCart_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AddShoppingCart_TypedDataContext2_ForReadOnly valDataContext3 = ((AddShoppingCart_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext3.ValueType___Expr3Get();
            }
            if ((expressionId == 4)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AddShoppingCart_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AddShoppingCart_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AddShoppingCart_TypedDataContext2_ForReadOnly valDataContext4 = ((AddShoppingCart_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext4.ValueType___Expr4Get();
            }
            if ((expressionId == 5)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AddShoppingCart_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AddShoppingCart_TypedDataContext2(locations, activityContext, true);
                }
                AddShoppingCart_TypedDataContext2 refDataContext5 = ((AddShoppingCart_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext5.GetLocation<System.Guid>(refDataContext5.ValueType___Expr5Get, refDataContext5.ValueType___Expr5Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 6)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AddShoppingCart_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AddShoppingCart_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AddShoppingCart_TypedDataContext2_ForReadOnly valDataContext6 = ((AddShoppingCart_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AddShoppingCart_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AddShoppingCart_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AddShoppingCart_TypedDataContext2_ForReadOnly valDataContext7 = ((AddShoppingCart_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AddShoppingCart_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AddShoppingCart_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AddShoppingCart_TypedDataContext2_ForReadOnly valDataContext8 = ((AddShoppingCart_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext8.ValueType___Expr8Get();
            }
            if ((expressionId == 9)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AddShoppingCart_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AddShoppingCart_TypedDataContext2(locations, activityContext, true);
                }
                AddShoppingCart_TypedDataContext2 refDataContext9 = ((AddShoppingCart_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext9.GetLocation<System.Guid>(refDataContext9.ValueType___Expr9Get, refDataContext9.ValueType___Expr9Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 10)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AddShoppingCart_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AddShoppingCart_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AddShoppingCart_TypedDataContext2_ForReadOnly valDataContext10 = ((AddShoppingCart_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AddShoppingCart_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AddShoppingCart_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AddShoppingCart_TypedDataContext2_ForReadOnly valDataContext11 = ((AddShoppingCart_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext11.ValueType___Expr11Get();
            }
            if ((expressionId == 12)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AddShoppingCart_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AddShoppingCart_TypedDataContext2(locations, activityContext, true);
                }
                AddShoppingCart_TypedDataContext2 refDataContext12 = ((AddShoppingCart_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext12.GetLocation<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_orderitem>>(refDataContext12.ValueType___Expr12Get, refDataContext12.ValueType___Expr12Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 13)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AddShoppingCart_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AddShoppingCart_TypedDataContext2(locations, activityContext, true);
                }
                AddShoppingCart_TypedDataContext2 refDataContext13 = ((AddShoppingCart_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext13.GetLocation<AmxPeruPSBActivities.Model.OrderDataModel>(refDataContext13.ValueType___Expr13Get, refDataContext13.ValueType___Expr13Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 14)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AddShoppingCart_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AddShoppingCart_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AddShoppingCart_TypedDataContext2_ForReadOnly valDataContext14 = ((AddShoppingCart_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext14.ValueType___Expr14Get();
            }
            if ((expressionId == 15)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AddShoppingCart_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AddShoppingCart_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AddShoppingCart_TypedDataContext2_ForReadOnly valDataContext15 = ((AddShoppingCart_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext15.ValueType___Expr15Get();
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
                AddShoppingCart_TypedDataContext2 refDataContext0 = new AddShoppingCart_TypedDataContext2(locations, true);
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set);
            }
            if ((expressionId == 1)) {
                AddShoppingCart_TypedDataContext2_ForReadOnly valDataContext1 = new AddShoppingCart_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                AddShoppingCart_TypedDataContext2 refDataContext2 = new AddShoppingCart_TypedDataContext2(locations, true);
                return refDataContext2.GetLocation<Ericsson.ETELCRM.Entities.Crm.etel_ordercapture>(refDataContext2.ValueType___Expr2Get, refDataContext2.ValueType___Expr2Set);
            }
            if ((expressionId == 3)) {
                AddShoppingCart_TypedDataContext2_ForReadOnly valDataContext3 = new AddShoppingCart_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext3.ValueType___Expr3Get();
            }
            if ((expressionId == 4)) {
                AddShoppingCart_TypedDataContext2_ForReadOnly valDataContext4 = new AddShoppingCart_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext4.ValueType___Expr4Get();
            }
            if ((expressionId == 5)) {
                AddShoppingCart_TypedDataContext2 refDataContext5 = new AddShoppingCart_TypedDataContext2(locations, true);
                return refDataContext5.GetLocation<System.Guid>(refDataContext5.ValueType___Expr5Get, refDataContext5.ValueType___Expr5Set);
            }
            if ((expressionId == 6)) {
                AddShoppingCart_TypedDataContext2_ForReadOnly valDataContext6 = new AddShoppingCart_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                AddShoppingCart_TypedDataContext2_ForReadOnly valDataContext7 = new AddShoppingCart_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                AddShoppingCart_TypedDataContext2_ForReadOnly valDataContext8 = new AddShoppingCart_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext8.ValueType___Expr8Get();
            }
            if ((expressionId == 9)) {
                AddShoppingCart_TypedDataContext2 refDataContext9 = new AddShoppingCart_TypedDataContext2(locations, true);
                return refDataContext9.GetLocation<System.Guid>(refDataContext9.ValueType___Expr9Get, refDataContext9.ValueType___Expr9Set);
            }
            if ((expressionId == 10)) {
                AddShoppingCart_TypedDataContext2_ForReadOnly valDataContext10 = new AddShoppingCart_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                AddShoppingCart_TypedDataContext2_ForReadOnly valDataContext11 = new AddShoppingCart_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext11.ValueType___Expr11Get();
            }
            if ((expressionId == 12)) {
                AddShoppingCart_TypedDataContext2 refDataContext12 = new AddShoppingCart_TypedDataContext2(locations, true);
                return refDataContext12.GetLocation<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_orderitem>>(refDataContext12.ValueType___Expr12Get, refDataContext12.ValueType___Expr12Set);
            }
            if ((expressionId == 13)) {
                AddShoppingCart_TypedDataContext2 refDataContext13 = new AddShoppingCart_TypedDataContext2(locations, true);
                return refDataContext13.GetLocation<AmxPeruPSBActivities.Model.OrderDataModel>(refDataContext13.ValueType___Expr13Get, refDataContext13.ValueType___Expr13Set);
            }
            if ((expressionId == 14)) {
                AddShoppingCart_TypedDataContext2_ForReadOnly valDataContext14 = new AddShoppingCart_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext14.ValueType___Expr14Get();
            }
            if ((expressionId == 15)) {
                AddShoppingCart_TypedDataContext2_ForReadOnly valDataContext15 = new AddShoppingCart_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext15.ValueType___Expr15Get();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool CanExecuteExpression(string expressionText, bool isReference, System.Collections.Generic.IList<System.Activities.LocationReference> locations, out int expressionId) {
            if (((isReference == true) 
                        && ((expressionText == "connectionString") 
                        && (AddShoppingCart_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 0;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "connectionString") 
                        && (AddShoppingCart_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 1;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "orderCapture") 
                        && (AddShoppingCart_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 2;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "orderItemShoppingCartModel") 
                        && (AddShoppingCart_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 3;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "activationStartDate") 
                        && (AddShoppingCart_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 4;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "createdOrderItemId") 
                        && (AddShoppingCart_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 5;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "orderCapture") 
                        && (AddShoppingCart_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 6;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "orderItemShoppingCartModel") 
                        && (AddShoppingCart_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 7;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "activationEndDate") 
                        && (AddShoppingCart_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 8;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "createdOrderItemId") 
                        && (AddShoppingCart_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 9;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "orderItemShoppingCartModel") 
                        && (AddShoppingCart_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 10;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "orderCapture.Id") 
                        && (AddShoppingCart_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 11;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "orderCaptureItems") 
                        && (AddShoppingCart_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 12;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "orderDataModel") 
                        && (AddShoppingCart_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 13;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "orderCapture") 
                        && (AddShoppingCart_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 14;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "orderCaptureItems") 
                        && (AddShoppingCart_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 15;
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
                return new AddShoppingCart_TypedDataContext2(locationReferences).@__Expr0GetTree();
            }
            if ((expressionId == 1)) {
                return new AddShoppingCart_TypedDataContext2_ForReadOnly(locationReferences).@__Expr1GetTree();
            }
            if ((expressionId == 2)) {
                return new AddShoppingCart_TypedDataContext2(locationReferences).@__Expr2GetTree();
            }
            if ((expressionId == 3)) {
                return new AddShoppingCart_TypedDataContext2_ForReadOnly(locationReferences).@__Expr3GetTree();
            }
            if ((expressionId == 4)) {
                return new AddShoppingCart_TypedDataContext2_ForReadOnly(locationReferences).@__Expr4GetTree();
            }
            if ((expressionId == 5)) {
                return new AddShoppingCart_TypedDataContext2(locationReferences).@__Expr5GetTree();
            }
            if ((expressionId == 6)) {
                return new AddShoppingCart_TypedDataContext2_ForReadOnly(locationReferences).@__Expr6GetTree();
            }
            if ((expressionId == 7)) {
                return new AddShoppingCart_TypedDataContext2_ForReadOnly(locationReferences).@__Expr7GetTree();
            }
            if ((expressionId == 8)) {
                return new AddShoppingCart_TypedDataContext2_ForReadOnly(locationReferences).@__Expr8GetTree();
            }
            if ((expressionId == 9)) {
                return new AddShoppingCart_TypedDataContext2(locationReferences).@__Expr9GetTree();
            }
            if ((expressionId == 10)) {
                return new AddShoppingCart_TypedDataContext2_ForReadOnly(locationReferences).@__Expr10GetTree();
            }
            if ((expressionId == 11)) {
                return new AddShoppingCart_TypedDataContext2_ForReadOnly(locationReferences).@__Expr11GetTree();
            }
            if ((expressionId == 12)) {
                return new AddShoppingCart_TypedDataContext2(locationReferences).@__Expr12GetTree();
            }
            if ((expressionId == 13)) {
                return new AddShoppingCart_TypedDataContext2(locationReferences).@__Expr13GetTree();
            }
            if ((expressionId == 14)) {
                return new AddShoppingCart_TypedDataContext2_ForReadOnly(locationReferences).@__Expr14GetTree();
            }
            if ((expressionId == 15)) {
                return new AddShoppingCart_TypedDataContext2_ForReadOnly(locationReferences).@__Expr15GetTree();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AddShoppingCart_TypedDataContext0 : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AddShoppingCart_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AddShoppingCart_TypedDataContext0(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AddShoppingCart_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class AddShoppingCart_TypedDataContext0_ForReadOnly : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AddShoppingCart_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AddShoppingCart_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AddShoppingCart_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class AddShoppingCart_TypedDataContext1 : AddShoppingCart_TypedDataContext0 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected System.Nullable<System.DateTime> activationEndDate;
            
            protected System.Guid createdOrderItemId;
            
            protected System.Nullable<System.DateTime> activationStartDate;
            
            public AddShoppingCart_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AddShoppingCart_TypedDataContext1(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AddShoppingCart_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected AmxPeruPSBActivities.Model.OrderItem.OrderItemAddShoppingCartModel orderItemShoppingCartModel {
                get {
                    return ((AmxPeruPSBActivities.Model.OrderItem.OrderItemAddShoppingCartModel)(this.GetVariableValue((1 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((1 + locationsOffset), value);
                }
            }
            
            protected AmxPeruPSBActivities.Model.OrderDataModel orderDataModel {
                get {
                    return ((AmxPeruPSBActivities.Model.OrderDataModel)(this.GetVariableValue((4 + locationsOffset))));
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
            
            protected override void GetValueTypeValues() {
                this.activationEndDate = ((System.Nullable<System.DateTime>)(this.GetVariableValue((0 + locationsOffset))));
                this.createdOrderItemId = ((System.Guid)(this.GetVariableValue((2 + locationsOffset))));
                this.activationStartDate = ((System.Nullable<System.DateTime>)(this.GetVariableValue((3 + locationsOffset))));
                base.GetValueTypeValues();
            }
            
            protected override void SetValueTypeValues() {
                this.SetVariableValue((0 + locationsOffset), this.activationEndDate);
                this.SetVariableValue((2 + locationsOffset), this.createdOrderItemId);
                this.SetVariableValue((3 + locationsOffset), this.activationStartDate);
                base.SetValueTypeValues();
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
                if (((locationReferences[(offset + 1)].Name != "orderItemShoppingCartModel") 
                            || (locationReferences[(offset + 1)].Type != typeof(AmxPeruPSBActivities.Model.OrderItem.OrderItemAddShoppingCartModel)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "orderDataModel") 
                            || (locationReferences[(offset + 4)].Type != typeof(AmxPeruPSBActivities.Model.OrderDataModel)))) {
                    return false;
                }
                if (((locationReferences[(offset + 0)].Name != "activationEndDate") 
                            || (locationReferences[(offset + 0)].Type != typeof(System.Nullable<System.DateTime>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 2)].Name != "createdOrderItemId") 
                            || (locationReferences[(offset + 2)].Type != typeof(System.Guid)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "activationStartDate") 
                            || (locationReferences[(offset + 3)].Type != typeof(System.Nullable<System.DateTime>)))) {
                    return false;
                }
                return AddShoppingCart_TypedDataContext0.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AddShoppingCart_TypedDataContext1_ForReadOnly : AddShoppingCart_TypedDataContext0_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected System.Nullable<System.DateTime> activationEndDate;
            
            protected System.Guid createdOrderItemId;
            
            protected System.Nullable<System.DateTime> activationStartDate;
            
            public AddShoppingCart_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AddShoppingCart_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AddShoppingCart_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected AmxPeruPSBActivities.Model.OrderItem.OrderItemAddShoppingCartModel orderItemShoppingCartModel {
                get {
                    return ((AmxPeruPSBActivities.Model.OrderItem.OrderItemAddShoppingCartModel)(this.GetVariableValue((1 + locationsOffset))));
                }
            }
            
            protected AmxPeruPSBActivities.Model.OrderDataModel orderDataModel {
                get {
                    return ((AmxPeruPSBActivities.Model.OrderDataModel)(this.GetVariableValue((4 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            protected override void GetValueTypeValues() {
                this.activationEndDate = ((System.Nullable<System.DateTime>)(this.GetVariableValue((0 + locationsOffset))));
                this.createdOrderItemId = ((System.Guid)(this.GetVariableValue((2 + locationsOffset))));
                this.activationStartDate = ((System.Nullable<System.DateTime>)(this.GetVariableValue((3 + locationsOffset))));
                base.GetValueTypeValues();
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
                if (((locationReferences[(offset + 1)].Name != "orderItemShoppingCartModel") 
                            || (locationReferences[(offset + 1)].Type != typeof(AmxPeruPSBActivities.Model.OrderItem.OrderItemAddShoppingCartModel)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "orderDataModel") 
                            || (locationReferences[(offset + 4)].Type != typeof(AmxPeruPSBActivities.Model.OrderDataModel)))) {
                    return false;
                }
                if (((locationReferences[(offset + 0)].Name != "activationEndDate") 
                            || (locationReferences[(offset + 0)].Type != typeof(System.Nullable<System.DateTime>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 2)].Name != "createdOrderItemId") 
                            || (locationReferences[(offset + 2)].Type != typeof(System.Guid)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "activationStartDate") 
                            || (locationReferences[(offset + 3)].Type != typeof(System.Nullable<System.DateTime>)))) {
                    return false;
                }
                return AddShoppingCart_TypedDataContext0_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AddShoppingCart_TypedDataContext2 : AddShoppingCart_TypedDataContext1 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AddShoppingCart_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AddShoppingCart_TypedDataContext2(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AddShoppingCart_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string connectionString {
                get {
                    return ((string)(this.GetVariableValue((5 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((5 + locationsOffset), value);
                }
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.etel_ordercapture orderCapture {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.etel_ordercapture)(this.GetVariableValue((6 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((6 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_orderitem> orderCaptureItems {
                get {
                    return ((System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_orderitem>)(this.GetVariableValue((7 + locationsOffset))));
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
            
            internal System.Linq.Expressions.Expression @__Expr0GetTree() {
                
                #line 89 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
              connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr0Get() {
                
                #line 89 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
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
                
                #line 89 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                
              connectionString = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr0Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr0Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr2GetTree() {
                
                #line 100 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                System.Linq.Expressions.Expression<System.Func<Ericsson.ETELCRM.Entities.Crm.etel_ordercapture>> expression = () => 
                      orderCapture;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Ericsson.ETELCRM.Entities.Crm.etel_ordercapture @__Expr2Get() {
                
                #line 100 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                return 
                      orderCapture;
                
                #line default
                #line hidden
            }
            
            public Ericsson.ETELCRM.Entities.Crm.etel_ordercapture ValueType___Expr2Get() {
                this.GetValueTypeValues();
                return this.@__Expr2Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr2Set(Ericsson.ETELCRM.Entities.Crm.etel_ordercapture value) {
                
                #line 100 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                
                      orderCapture = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr2Set(Ericsson.ETELCRM.Entities.Crm.etel_ordercapture value) {
                this.GetValueTypeValues();
                this.@__Expr2Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr5GetTree() {
                
                #line 127 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Guid>> expression = () => 
                      createdOrderItemId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Guid @__Expr5Get() {
                
                #line 127 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                return 
                      createdOrderItemId;
                
                #line default
                #line hidden
            }
            
            public System.Guid ValueType___Expr5Get() {
                this.GetValueTypeValues();
                return this.@__Expr5Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr5Set(System.Guid value) {
                
                #line 127 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                
                      createdOrderItemId = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr5Set(System.Guid value) {
                this.GetValueTypeValues();
                this.@__Expr5Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr9GetTree() {
                
                #line 139 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Guid>> expression = () => 
                      createdOrderItemId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Guid @__Expr9Get() {
                
                #line 139 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                return 
                      createdOrderItemId;
                
                #line default
                #line hidden
            }
            
            public System.Guid ValueType___Expr9Get() {
                this.GetValueTypeValues();
                return this.@__Expr9Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr9Set(System.Guid value) {
                
                #line 139 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                
                      createdOrderItemId = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr9Set(System.Guid value) {
                this.GetValueTypeValues();
                this.@__Expr9Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr12GetTree() {
                
                #line 156 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_orderitem>>> expression = () => 
                      orderCaptureItems;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_orderitem> @__Expr12Get() {
                
                #line 156 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                return 
                      orderCaptureItems;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_orderitem> ValueType___Expr12Get() {
                this.GetValueTypeValues();
                return this.@__Expr12Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr12Set(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_orderitem> value) {
                
                #line 156 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                
                      orderCaptureItems = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr12Set(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_orderitem> value) {
                this.GetValueTypeValues();
                this.@__Expr12Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr13GetTree() {
                
                #line 173 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.OrderDataModel>> expression = () => 
                      orderDataModel;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.OrderDataModel @__Expr13Get() {
                
                #line 173 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                return 
                      orderDataModel;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.OrderDataModel ValueType___Expr13Get() {
                this.GetValueTypeValues();
                return this.@__Expr13Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr13Set(AmxPeruPSBActivities.Model.OrderDataModel value) {
                
                #line 173 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                
                      orderDataModel = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr13Set(AmxPeruPSBActivities.Model.OrderDataModel value) {
                this.GetValueTypeValues();
                this.@__Expr13Set(value);
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
                if (((locationReferences[(offset + 5)].Name != "connectionString") 
                            || (locationReferences[(offset + 5)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "orderCapture") 
                            || (locationReferences[(offset + 6)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.etel_ordercapture)))) {
                    return false;
                }
                if (((locationReferences[(offset + 7)].Name != "orderCaptureItems") 
                            || (locationReferences[(offset + 7)].Type != typeof(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_orderitem>)))) {
                    return false;
                }
                return AddShoppingCart_TypedDataContext1.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AddShoppingCart_TypedDataContext2_ForReadOnly : AddShoppingCart_TypedDataContext1_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AddShoppingCart_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AddShoppingCart_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AddShoppingCart_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string connectionString {
                get {
                    return ((string)(this.GetVariableValue((5 + locationsOffset))));
                }
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.etel_ordercapture orderCapture {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.etel_ordercapture)(this.GetVariableValue((6 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_orderitem> orderCaptureItems {
                get {
                    return ((System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_orderitem>)(this.GetVariableValue((7 + locationsOffset))));
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
                
                #line 180 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr1Get() {
                
                #line 180 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                return 
                  connectionString;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr1Get() {
                this.GetValueTypeValues();
                return this.@__Expr1Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr3GetTree() {
                
                #line 105 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.OrderItem.OrderItemAddShoppingCartModel>> expression = () => 
                      orderItemShoppingCartModel;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.OrderItem.OrderItemAddShoppingCartModel @__Expr3Get() {
                
                #line 105 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                return 
                      orderItemShoppingCartModel;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.OrderItem.OrderItemAddShoppingCartModel ValueType___Expr3Get() {
                this.GetValueTypeValues();
                return this.@__Expr3Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr4GetTree() {
                
                #line 117 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Nullable<System.DateTime>>> expression = () => 
                      activationStartDate;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Nullable<System.DateTime> @__Expr4Get() {
                
                #line 117 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                return 
                      activationStartDate;
                
                #line default
                #line hidden
            }
            
            public System.Nullable<System.DateTime> ValueType___Expr4Get() {
                this.GetValueTypeValues();
                return this.@__Expr4Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr6GetTree() {
                
                #line 122 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                System.Linq.Expressions.Expression<System.Func<Ericsson.ETELCRM.Entities.Crm.etel_ordercapture>> expression = () => 
                      orderCapture;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Ericsson.ETELCRM.Entities.Crm.etel_ordercapture @__Expr6Get() {
                
                #line 122 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                return 
                      orderCapture;
                
                #line default
                #line hidden
            }
            
            public Ericsson.ETELCRM.Entities.Crm.etel_ordercapture ValueType___Expr6Get() {
                this.GetValueTypeValues();
                return this.@__Expr6Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr7GetTree() {
                
                #line 132 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.OrderItem.OrderItemAddShoppingCartModel>> expression = () => 
                      orderItemShoppingCartModel;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.OrderItem.OrderItemAddShoppingCartModel @__Expr7Get() {
                
                #line 132 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                return 
                      orderItemShoppingCartModel;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.OrderItem.OrderItemAddShoppingCartModel ValueType___Expr7Get() {
                this.GetValueTypeValues();
                return this.@__Expr7Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr8GetTree() {
                
                #line 112 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Nullable<System.DateTime>>> expression = () => 
                      activationEndDate;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Nullable<System.DateTime> @__Expr8Get() {
                
                #line 112 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                return 
                      activationEndDate;
                
                #line default
                #line hidden
            }
            
            public System.Nullable<System.DateTime> ValueType___Expr8Get() {
                this.GetValueTypeValues();
                return this.@__Expr8Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr10GetTree() {
                
                #line 144 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.OrderItem.OrderItemAddShoppingCartModel>> expression = () => 
                      orderItemShoppingCartModel;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.OrderItem.OrderItemAddShoppingCartModel @__Expr10Get() {
                
                #line 144 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                return 
                      orderItemShoppingCartModel;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.OrderItem.OrderItemAddShoppingCartModel ValueType___Expr10Get() {
                this.GetValueTypeValues();
                return this.@__Expr10Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr11GetTree() {
                
                #line 151 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Guid>> expression = () => 
                      orderCapture.Id;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Guid @__Expr11Get() {
                
                #line 151 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                return 
                      orderCapture.Id;
                
                #line default
                #line hidden
            }
            
            public System.Guid ValueType___Expr11Get() {
                this.GetValueTypeValues();
                return this.@__Expr11Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr14GetTree() {
                
                #line 163 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                System.Linq.Expressions.Expression<System.Func<Ericsson.ETELCRM.Entities.Crm.etel_ordercapture>> expression = () => 
                      orderCapture;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Ericsson.ETELCRM.Entities.Crm.etel_ordercapture @__Expr14Get() {
                
                #line 163 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                return 
                      orderCapture;
                
                #line default
                #line hidden
            }
            
            public Ericsson.ETELCRM.Entities.Crm.etel_ordercapture ValueType___Expr14Get() {
                this.GetValueTypeValues();
                return this.@__Expr14Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr15GetTree() {
                
                #line 168 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_orderitem>>> expression = () => 
                      orderCaptureItems;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_orderitem> @__Expr15Get() {
                
                #line 168 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\ADDSHOPPINGCART.XAML"
                return 
                      orderCaptureItems;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_orderitem> ValueType___Expr15Get() {
                this.GetValueTypeValues();
                return this.@__Expr15Get();
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
                if (((locationReferences[(offset + 5)].Name != "connectionString") 
                            || (locationReferences[(offset + 5)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "orderCapture") 
                            || (locationReferences[(offset + 6)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.etel_ordercapture)))) {
                    return false;
                }
                if (((locationReferences[(offset + 7)].Name != "orderCaptureItems") 
                            || (locationReferences[(offset + 7)].Type != typeof(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_orderitem>)))) {
                    return false;
                }
                return AddShoppingCart_TypedDataContext1_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
    }
}

namespace AmxPeruPSBWorkflows {
    
    #line 27 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\RetrieveOptionalOfferings.xaml"
    using System;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\RetrieveOptionalOfferings.xaml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 28 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\RetrieveOptionalOfferings.xaml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\RetrieveOptionalOfferings.xaml"
    using System.Activities;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\RetrieveOptionalOfferings.xaml"
    using System.Activities.Expressions;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\RetrieveOptionalOfferings.xaml"
    using System.Activities.Statements;
    
    #line default
    #line hidden
    
    #line 29 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\RetrieveOptionalOfferings.xaml"
    using System.Data;
    
    #line default
    #line hidden
    
    #line 30 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\RetrieveOptionalOfferings.xaml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 31 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\RetrieveOptionalOfferings.xaml"
    using System.Text;
    
    #line default
    #line hidden
    
    #line 32 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\RetrieveOptionalOfferings.xaml"
    using Microsoft.Xrm.Sdk;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\RetrieveOptionalOfferings.xaml"
    using System.Activities.XamlIntegration;
    
    #line default
    #line hidden
    
    
    public partial class RetrieveOptionalOfferings : System.Activities.XamlIntegration.ICompiledExpressionRoot {
        
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
                this.dataContextActivities = RetrieveOptionalOfferings_TypedDataContext2.GetDataContextActivitiesHelper(this.rootActivity, this.forImplementation);
            }
            if ((expressionId == 0)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveOptionalOfferings_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new RetrieveOptionalOfferings_TypedDataContext2(locations, activityContext, true);
                }
                RetrieveOptionalOfferings_TypedDataContext2 refDataContext0 = ((RetrieveOptionalOfferings_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 1)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveOptionalOfferings_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new RetrieveOptionalOfferings_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                RetrieveOptionalOfferings_TypedDataContext2_ForReadOnly valDataContext1 = ((RetrieveOptionalOfferings_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveOptionalOfferings_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new RetrieveOptionalOfferings_TypedDataContext3(locations, activityContext, true);
                }
                RetrieveOptionalOfferings_TypedDataContext3 refDataContext2 = ((RetrieveOptionalOfferings_TypedDataContext3)(cachedCompiledDataContext[2]));
                return refDataContext2.GetLocation<System.Collections.Generic.List<System.Guid>>(refDataContext2.ValueType___Expr2Get, refDataContext2.ValueType___Expr2Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 3)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveOptionalOfferings_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new RetrieveOptionalOfferings_TypedDataContext3(locations, activityContext, true);
                }
                RetrieveOptionalOfferings_TypedDataContext3 refDataContext3 = ((RetrieveOptionalOfferings_TypedDataContext3)(cachedCompiledDataContext[2]));
                return refDataContext3.GetLocation<System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>>(refDataContext3.ValueType___Expr3Get, refDataContext3.ValueType___Expr3Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 4)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly valDataContext4 = ((RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[3]));
                return valDataContext4.ValueType___Expr4Get();
            }
            if ((expressionId == 5)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly valDataContext5 = ((RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[3]));
                return valDataContext5.ValueType___Expr5Get();
            }
            if ((expressionId == 6)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveOptionalOfferings_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new RetrieveOptionalOfferings_TypedDataContext3(locations, activityContext, true);
                }
                RetrieveOptionalOfferings_TypedDataContext3 refDataContext6 = ((RetrieveOptionalOfferings_TypedDataContext3)(cachedCompiledDataContext[2]));
                return refDataContext6.GetLocation<System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>>(refDataContext6.ValueType___Expr6Get, refDataContext6.ValueType___Expr6Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 7)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly valDataContext7 = ((RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[3]));
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly valDataContext8 = ((RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[3]));
                return valDataContext8.ValueType___Expr8Get();
            }
            if ((expressionId == 9)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveOptionalOfferings_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new RetrieveOptionalOfferings_TypedDataContext3(locations, activityContext, true);
                }
                RetrieveOptionalOfferings_TypedDataContext3 refDataContext9 = ((RetrieveOptionalOfferings_TypedDataContext3)(cachedCompiledDataContext[2]));
                return refDataContext9.GetLocation<System.Collections.Generic.List<System.Guid>>(refDataContext9.ValueType___Expr9Get, refDataContext9.ValueType___Expr9Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 10)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly valDataContext10 = ((RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[3]));
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly valDataContext11 = ((RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[3]));
                return valDataContext11.ValueType___Expr11Get();
            }
            if ((expressionId == 12)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveOptionalOfferings_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new RetrieveOptionalOfferings_TypedDataContext3(locations, activityContext, true);
                }
                RetrieveOptionalOfferings_TypedDataContext3 refDataContext12 = ((RetrieveOptionalOfferings_TypedDataContext3)(cachedCompiledDataContext[2]));
                return refDataContext12.GetLocation<System.Collections.Generic.List<AmxPeruPSBActivities.Model.OrderCapture.ProductOfferingItem>>(refDataContext12.ValueType___Expr12Get, refDataContext12.ValueType___Expr12Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 13)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly valDataContext13 = ((RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[3]));
                return valDataContext13.ValueType___Expr13Get();
            }
            if ((expressionId == 14)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly valDataContext14 = ((RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[3]));
                return valDataContext14.ValueType___Expr14Get();
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
                RetrieveOptionalOfferings_TypedDataContext2 refDataContext0 = new RetrieveOptionalOfferings_TypedDataContext2(locations, true);
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set);
            }
            if ((expressionId == 1)) {
                RetrieveOptionalOfferings_TypedDataContext2_ForReadOnly valDataContext1 = new RetrieveOptionalOfferings_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                RetrieveOptionalOfferings_TypedDataContext3 refDataContext2 = new RetrieveOptionalOfferings_TypedDataContext3(locations, true);
                return refDataContext2.GetLocation<System.Collections.Generic.List<System.Guid>>(refDataContext2.ValueType___Expr2Get, refDataContext2.ValueType___Expr2Set);
            }
            if ((expressionId == 3)) {
                RetrieveOptionalOfferings_TypedDataContext3 refDataContext3 = new RetrieveOptionalOfferings_TypedDataContext3(locations, true);
                return refDataContext3.GetLocation<System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>>(refDataContext3.ValueType___Expr3Get, refDataContext3.ValueType___Expr3Set);
            }
            if ((expressionId == 4)) {
                RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly valDataContext4 = new RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext4.ValueType___Expr4Get();
            }
            if ((expressionId == 5)) {
                RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly valDataContext5 = new RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext5.ValueType___Expr5Get();
            }
            if ((expressionId == 6)) {
                RetrieveOptionalOfferings_TypedDataContext3 refDataContext6 = new RetrieveOptionalOfferings_TypedDataContext3(locations, true);
                return refDataContext6.GetLocation<System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>>(refDataContext6.ValueType___Expr6Get, refDataContext6.ValueType___Expr6Set);
            }
            if ((expressionId == 7)) {
                RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly valDataContext7 = new RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly valDataContext8 = new RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext8.ValueType___Expr8Get();
            }
            if ((expressionId == 9)) {
                RetrieveOptionalOfferings_TypedDataContext3 refDataContext9 = new RetrieveOptionalOfferings_TypedDataContext3(locations, true);
                return refDataContext9.GetLocation<System.Collections.Generic.List<System.Guid>>(refDataContext9.ValueType___Expr9Get, refDataContext9.ValueType___Expr9Set);
            }
            if ((expressionId == 10)) {
                RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly valDataContext10 = new RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly valDataContext11 = new RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext11.ValueType___Expr11Get();
            }
            if ((expressionId == 12)) {
                RetrieveOptionalOfferings_TypedDataContext3 refDataContext12 = new RetrieveOptionalOfferings_TypedDataContext3(locations, true);
                return refDataContext12.GetLocation<System.Collections.Generic.List<AmxPeruPSBActivities.Model.OrderCapture.ProductOfferingItem>>(refDataContext12.ValueType___Expr12Get, refDataContext12.ValueType___Expr12Set);
            }
            if ((expressionId == 13)) {
                RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly valDataContext13 = new RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext13.ValueType___Expr13Get();
            }
            if ((expressionId == 14)) {
                RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly valDataContext14 = new RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext14.ValueType___Expr14Get();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool CanExecuteExpression(string expressionText, bool isReference, System.Collections.Generic.IList<System.Activities.LocationReference> locations, out int expressionId) {
            if (((isReference == true) 
                        && ((expressionText == "connectionString") 
                        && (RetrieveOptionalOfferings_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 0;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "connectionString") 
                        && (RetrieveOptionalOfferings_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 1;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "offeringIds") 
                        && (RetrieveOptionalOfferings_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 2;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "offeringList") 
                        && (RetrieveOptionalOfferings_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 3;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "parentOfferingId") 
                        && (RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 4;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "offeringIds") 
                        && (RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 5;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "popList") 
                        && (RetrieveOptionalOfferings_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 6;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "offeringIds") 
                        && (RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 7;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "estrato") 
                        && (RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 8;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "charValues") 
                        && (RetrieveOptionalOfferings_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 9;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "offeringList") 
                        && (RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 10;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "popList") 
                        && (RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 11;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "optionalOfferingList") 
                        && (RetrieveOptionalOfferings_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 12;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "parentOfferingId") 
                        && (RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 13;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "charValues") 
                        && (RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 14;
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
                return new RetrieveOptionalOfferings_TypedDataContext2(locationReferences).@__Expr0GetTree();
            }
            if ((expressionId == 1)) {
                return new RetrieveOptionalOfferings_TypedDataContext2_ForReadOnly(locationReferences).@__Expr1GetTree();
            }
            if ((expressionId == 2)) {
                return new RetrieveOptionalOfferings_TypedDataContext3(locationReferences).@__Expr2GetTree();
            }
            if ((expressionId == 3)) {
                return new RetrieveOptionalOfferings_TypedDataContext3(locationReferences).@__Expr3GetTree();
            }
            if ((expressionId == 4)) {
                return new RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly(locationReferences).@__Expr4GetTree();
            }
            if ((expressionId == 5)) {
                return new RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly(locationReferences).@__Expr5GetTree();
            }
            if ((expressionId == 6)) {
                return new RetrieveOptionalOfferings_TypedDataContext3(locationReferences).@__Expr6GetTree();
            }
            if ((expressionId == 7)) {
                return new RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly(locationReferences).@__Expr7GetTree();
            }
            if ((expressionId == 8)) {
                return new RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly(locationReferences).@__Expr8GetTree();
            }
            if ((expressionId == 9)) {
                return new RetrieveOptionalOfferings_TypedDataContext3(locationReferences).@__Expr9GetTree();
            }
            if ((expressionId == 10)) {
                return new RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly(locationReferences).@__Expr10GetTree();
            }
            if ((expressionId == 11)) {
                return new RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly(locationReferences).@__Expr11GetTree();
            }
            if ((expressionId == 12)) {
                return new RetrieveOptionalOfferings_TypedDataContext3(locationReferences).@__Expr12GetTree();
            }
            if ((expressionId == 13)) {
                return new RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly(locationReferences).@__Expr13GetTree();
            }
            if ((expressionId == 14)) {
                return new RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly(locationReferences).@__Expr14GetTree();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class RetrieveOptionalOfferings_TypedDataContext0 : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public RetrieveOptionalOfferings_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveOptionalOfferings_TypedDataContext0(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveOptionalOfferings_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class RetrieveOptionalOfferings_TypedDataContext0_ForReadOnly : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public RetrieveOptionalOfferings_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveOptionalOfferings_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveOptionalOfferings_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class RetrieveOptionalOfferings_TypedDataContext1 : RetrieveOptionalOfferings_TypedDataContext0 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public RetrieveOptionalOfferings_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveOptionalOfferings_TypedDataContext1(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveOptionalOfferings_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string parentOfferingId {
                get {
                    return ((string)(this.GetVariableValue((0 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((0 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.List<AmxPeruPSBActivities.Model.OrderCapture.ProductOfferingItem> optionalOfferingList {
                get {
                    return ((System.Collections.Generic.List<AmxPeruPSBActivities.Model.OrderCapture.ProductOfferingItem>)(this.GetVariableValue((1 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((1 + locationsOffset), value);
                }
            }
            
            protected string estrato {
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
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 3))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 3);
                }
                expectedLocationsCount = 3;
                if (((locationReferences[(offset + 0)].Name != "parentOfferingId") 
                            || (locationReferences[(offset + 0)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "optionalOfferingList") 
                            || (locationReferences[(offset + 1)].Type != typeof(System.Collections.Generic.List<AmxPeruPSBActivities.Model.OrderCapture.ProductOfferingItem>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 2)].Name != "estrato") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                return RetrieveOptionalOfferings_TypedDataContext0.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class RetrieveOptionalOfferings_TypedDataContext1_ForReadOnly : RetrieveOptionalOfferings_TypedDataContext0_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public RetrieveOptionalOfferings_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveOptionalOfferings_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveOptionalOfferings_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string parentOfferingId {
                get {
                    return ((string)(this.GetVariableValue((0 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.List<AmxPeruPSBActivities.Model.OrderCapture.ProductOfferingItem> optionalOfferingList {
                get {
                    return ((System.Collections.Generic.List<AmxPeruPSBActivities.Model.OrderCapture.ProductOfferingItem>)(this.GetVariableValue((1 + locationsOffset))));
                }
            }
            
            protected string estrato {
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
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 3))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 3);
                }
                expectedLocationsCount = 3;
                if (((locationReferences[(offset + 0)].Name != "parentOfferingId") 
                            || (locationReferences[(offset + 0)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "optionalOfferingList") 
                            || (locationReferences[(offset + 1)].Type != typeof(System.Collections.Generic.List<AmxPeruPSBActivities.Model.OrderCapture.ProductOfferingItem>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 2)].Name != "estrato") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                return RetrieveOptionalOfferings_TypedDataContext0_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class RetrieveOptionalOfferings_TypedDataContext2 : RetrieveOptionalOfferings_TypedDataContext1 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public RetrieveOptionalOfferings_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveOptionalOfferings_TypedDataContext2(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveOptionalOfferings_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string connectionString {
                get {
                    return ((string)(this.GetVariableValue((3 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((3 + locationsOffset), value);
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
                
                #line 81 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
              connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr0Get() {
                
                #line 81 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
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
                
                #line 81 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                
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
                            && (locationReferences.Count < 4))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 4);
                }
                expectedLocationsCount = 4;
                if (((locationReferences[(offset + 3)].Name != "connectionString") 
                            || (locationReferences[(offset + 3)].Type != typeof(string)))) {
                    return false;
                }
                return RetrieveOptionalOfferings_TypedDataContext1.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class RetrieveOptionalOfferings_TypedDataContext2_ForReadOnly : RetrieveOptionalOfferings_TypedDataContext1_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public RetrieveOptionalOfferings_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveOptionalOfferings_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveOptionalOfferings_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string connectionString {
                get {
                    return ((string)(this.GetVariableValue((3 + locationsOffset))));
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
                
                #line 193 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr1Get() {
                
                #line 193 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
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
                            && (locationReferences.Count < 4))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 4);
                }
                expectedLocationsCount = 4;
                if (((locationReferences[(offset + 3)].Name != "connectionString") 
                            || (locationReferences[(offset + 3)].Type != typeof(string)))) {
                    return false;
                }
                return RetrieveOptionalOfferings_TypedDataContext1_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class RetrieveOptionalOfferings_TypedDataContext3 : RetrieveOptionalOfferings_TypedDataContext2 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public RetrieveOptionalOfferings_TypedDataContext3(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveOptionalOfferings_TypedDataContext3(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveOptionalOfferings_TypedDataContext3(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> offeringList {
                get {
                    return ((System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>)(this.GetVariableValue((4 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((4 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> popList {
                get {
                    return ((System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>)(this.GetVariableValue((5 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((5 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.List<System.Guid> offeringIds {
                get {
                    return ((System.Collections.Generic.List<System.Guid>)(this.GetVariableValue((6 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((6 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.List<System.Guid> charValues {
                get {
                    return ((System.Collections.Generic.List<System.Guid>)(this.GetVariableValue((7 + locationsOffset))));
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
            
            internal System.Linq.Expressions.Expression @__Expr2GetTree() {
                
                #line 101 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<System.Guid>>> expression = () => 
                            offeringIds;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<System.Guid> @__Expr2Get() {
                
                #line 101 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                return 
                            offeringIds;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<System.Guid> ValueType___Expr2Get() {
                this.GetValueTypeValues();
                return this.@__Expr2Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr2Set(System.Collections.Generic.List<System.Guid> value) {
                
                #line 101 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                
                            offeringIds = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr2Set(System.Collections.Generic.List<System.Guid> value) {
                this.GetValueTypeValues();
                this.@__Expr2Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr3GetTree() {
                
                #line 106 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>>> expression = () => 
                            offeringList;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> @__Expr3Get() {
                
                #line 106 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                return 
                            offeringList;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> ValueType___Expr3Get() {
                this.GetValueTypeValues();
                return this.@__Expr3Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr3Set(System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> value) {
                
                #line 106 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                
                            offeringList = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr3Set(System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> value) {
                this.GetValueTypeValues();
                this.@__Expr3Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr6GetTree() {
                
                #line 125 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>>> expression = () => 
                                popList;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> @__Expr6Get() {
                
                #line 125 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                return 
                                popList;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> ValueType___Expr6Get() {
                this.GetValueTypeValues();
                return this.@__Expr6Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr6Set(System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> value) {
                
                #line 125 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                
                                popList = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr6Set(System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> value) {
                this.GetValueTypeValues();
                this.@__Expr6Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr9GetTree() {
                
                #line 134 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<System.Guid>>> expression = () => 
                                    charValues;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<System.Guid> @__Expr9Get() {
                
                #line 134 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                return 
                                    charValues;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<System.Guid> ValueType___Expr9Get() {
                this.GetValueTypeValues();
                return this.@__Expr9Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr9Set(System.Collections.Generic.List<System.Guid> value) {
                
                #line 134 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                
                                    charValues = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr9Set(System.Collections.Generic.List<System.Guid> value) {
                this.GetValueTypeValues();
                this.@__Expr9Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr12GetTree() {
                
                #line 163 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<AmxPeruPSBActivities.Model.OrderCapture.ProductOfferingItem>>> expression = () => 
                                        optionalOfferingList;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.OrderCapture.ProductOfferingItem> @__Expr12Get() {
                
                #line 163 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                return 
                                        optionalOfferingList;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.OrderCapture.ProductOfferingItem> ValueType___Expr12Get() {
                this.GetValueTypeValues();
                return this.@__Expr12Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr12Set(System.Collections.Generic.List<AmxPeruPSBActivities.Model.OrderCapture.ProductOfferingItem> value) {
                
                #line 163 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                
                                        optionalOfferingList = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr12Set(System.Collections.Generic.List<AmxPeruPSBActivities.Model.OrderCapture.ProductOfferingItem> value) {
                this.GetValueTypeValues();
                this.@__Expr12Set(value);
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
                if (((locationReferences[(offset + 4)].Name != "offeringList") 
                            || (locationReferences[(offset + 4)].Type != typeof(System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 5)].Name != "popList") 
                            || (locationReferences[(offset + 5)].Type != typeof(System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "offeringIds") 
                            || (locationReferences[(offset + 6)].Type != typeof(System.Collections.Generic.List<System.Guid>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 7)].Name != "charValues") 
                            || (locationReferences[(offset + 7)].Type != typeof(System.Collections.Generic.List<System.Guid>)))) {
                    return false;
                }
                return RetrieveOptionalOfferings_TypedDataContext2.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly : RetrieveOptionalOfferings_TypedDataContext2_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveOptionalOfferings_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> offeringList {
                get {
                    return ((System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>)(this.GetVariableValue((4 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> popList {
                get {
                    return ((System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>)(this.GetVariableValue((5 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.List<System.Guid> offeringIds {
                get {
                    return ((System.Collections.Generic.List<System.Guid>)(this.GetVariableValue((6 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.List<System.Guid> charValues {
                get {
                    return ((System.Collections.Generic.List<System.Guid>)(this.GetVariableValue((7 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr4GetTree() {
                
                #line 111 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                            parentOfferingId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr4Get() {
                
                #line 111 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                return 
                            parentOfferingId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr4Get() {
                this.GetValueTypeValues();
                return this.@__Expr4Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr5GetTree() {
                
                #line 120 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<System.Guid>>> expression = () => 
                                offeringIds;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<System.Guid> @__Expr5Get() {
                
                #line 120 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                return 
                                offeringIds;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<System.Guid> ValueType___Expr5Get() {
                this.GetValueTypeValues();
                return this.@__Expr5Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr7GetTree() {
                
                #line 144 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<System.Guid>>> expression = () => 
                                    offeringIds;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<System.Guid> @__Expr7Get() {
                
                #line 144 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                return 
                                    offeringIds;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<System.Guid> ValueType___Expr7Get() {
                this.GetValueTypeValues();
                return this.@__Expr7Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr8GetTree() {
                
                #line 139 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                    estrato;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr8Get() {
                
                #line 139 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                return 
                                    estrato;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr8Get() {
                this.GetValueTypeValues();
                return this.@__Expr8Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr10GetTree() {
                
                #line 158 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>>> expression = () => 
                                        offeringList;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> @__Expr10Get() {
                
                #line 158 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                return 
                                        offeringList;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> ValueType___Expr10Get() {
                this.GetValueTypeValues();
                return this.@__Expr10Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr11GetTree() {
                
                #line 173 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>>> expression = () => 
                                        popList;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> @__Expr11Get() {
                
                #line 173 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                return 
                                        popList;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity> ValueType___Expr11Get() {
                this.GetValueTypeValues();
                return this.@__Expr11Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr13GetTree() {
                
                #line 168 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                        parentOfferingId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr13Get() {
                
                #line 168 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                return 
                                        parentOfferingId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr13Get() {
                this.GetValueTypeValues();
                return this.@__Expr13Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr14GetTree() {
                
                #line 153 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<System.Guid>>> expression = () => 
                                        charValues;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<System.Guid> @__Expr14Get() {
                
                #line 153 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVEOPTIONALOFFERINGS.XAML"
                return 
                                        charValues;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<System.Guid> ValueType___Expr14Get() {
                this.GetValueTypeValues();
                return this.@__Expr14Get();
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
                if (((locationReferences[(offset + 4)].Name != "offeringList") 
                            || (locationReferences[(offset + 4)].Type != typeof(System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 5)].Name != "popList") 
                            || (locationReferences[(offset + 5)].Type != typeof(System.Collections.Generic.List<Microsoft.Xrm.Sdk.Entity>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "offeringIds") 
                            || (locationReferences[(offset + 6)].Type != typeof(System.Collections.Generic.List<System.Guid>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 7)].Name != "charValues") 
                            || (locationReferences[(offset + 7)].Type != typeof(System.Collections.Generic.List<System.Guid>)))) {
                    return false;
                }
                return RetrieveOptionalOfferings_TypedDataContext2_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
    }
}

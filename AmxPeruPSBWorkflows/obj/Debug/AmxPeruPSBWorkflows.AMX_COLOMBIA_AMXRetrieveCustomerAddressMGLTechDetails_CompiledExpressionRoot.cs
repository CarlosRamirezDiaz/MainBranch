namespace AmxPeruPSBWorkflows.AMX_COLOMBIA {
    
    #line 23 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AMX COLOMBIA\AMXRetrieveCustomerAddressMGLTechDetails.xaml"
    using System;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AMX COLOMBIA\AMXRetrieveCustomerAddressMGLTechDetails.xaml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 24 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AMX COLOMBIA\AMXRetrieveCustomerAddressMGLTechDetails.xaml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AMX COLOMBIA\AMXRetrieveCustomerAddressMGLTechDetails.xaml"
    using System.Activities;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AMX COLOMBIA\AMXRetrieveCustomerAddressMGLTechDetails.xaml"
    using System.Activities.Expressions;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AMX COLOMBIA\AMXRetrieveCustomerAddressMGLTechDetails.xaml"
    using System.Activities.Statements;
    
    #line default
    #line hidden
    
    #line 25 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AMX COLOMBIA\AMXRetrieveCustomerAddressMGLTechDetails.xaml"
    using System.Data;
    
    #line default
    #line hidden
    
    #line 26 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AMX COLOMBIA\AMXRetrieveCustomerAddressMGLTechDetails.xaml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 27 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AMX COLOMBIA\AMXRetrieveCustomerAddressMGLTechDetails.xaml"
    using System.Text;
    
    #line default
    #line hidden
    
    #line 28 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AMX COLOMBIA\AMXRetrieveCustomerAddressMGLTechDetails.xaml"
    using AmxPeruPSBActivities.AMXCOLOMBIA.Model;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AMX COLOMBIA\AMXRetrieveCustomerAddressMGLTechDetails.xaml"
    using System.Activities.XamlIntegration;
    
    #line default
    #line hidden
    
    
    public partial class AMXRetrieveCustomerAddressMGLTechDetails : System.Activities.XamlIntegration.ICompiledExpressionRoot {
        
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
                this.dataContextActivities = AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2.GetDataContextActivitiesHelper(this.rootActivity, this.forImplementation);
            }
            if ((expressionId == 0)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2(locations, activityContext, true);
                }
                AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2 refDataContext0 = ((AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 1)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly valDataContext1 = ((AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2(locations, activityContext, true);
                }
                AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2 refDataContext2 = ((AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext2.GetLocation<string>(refDataContext2.ValueType___Expr2Get, refDataContext2.ValueType___Expr2Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 3)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2(locations, activityContext, true);
                }
                AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2 refDataContext3 = ((AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext3.GetLocation<string>(refDataContext3.ValueType___Expr3Get, refDataContext3.ValueType___Expr3Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 4)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2(locations, activityContext, true);
                }
                AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2 refDataContext4 = ((AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext4.GetLocation<string>(refDataContext4.ValueType___Expr4Get, refDataContext4.ValueType___Expr4Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 5)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2(locations, activityContext, true);
                }
                AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2 refDataContext5 = ((AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext5.GetLocation<string>(refDataContext5.ValueType___Expr5Get, refDataContext5.ValueType___Expr5Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 6)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly valDataContext6 = ((AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly valDataContext7 = ((AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly valDataContext8 = ((AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext8.ValueType___Expr8Get();
            }
            if ((expressionId == 9)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly valDataContext9 = ((AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext9.ValueType___Expr9Get();
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
                AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2 refDataContext0 = new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2(locations, true);
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set);
            }
            if ((expressionId == 1)) {
                AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly valDataContext1 = new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2 refDataContext2 = new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2(locations, true);
                return refDataContext2.GetLocation<string>(refDataContext2.ValueType___Expr2Get, refDataContext2.ValueType___Expr2Set);
            }
            if ((expressionId == 3)) {
                AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2 refDataContext3 = new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2(locations, true);
                return refDataContext3.GetLocation<string>(refDataContext3.ValueType___Expr3Get, refDataContext3.ValueType___Expr3Set);
            }
            if ((expressionId == 4)) {
                AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2 refDataContext4 = new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2(locations, true);
                return refDataContext4.GetLocation<string>(refDataContext4.ValueType___Expr4Get, refDataContext4.ValueType___Expr4Set);
            }
            if ((expressionId == 5)) {
                AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2 refDataContext5 = new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2(locations, true);
                return refDataContext5.GetLocation<string>(refDataContext5.ValueType___Expr5Get, refDataContext5.ValueType___Expr5Set);
            }
            if ((expressionId == 6)) {
                AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly valDataContext6 = new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly valDataContext7 = new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly valDataContext8 = new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext8.ValueType___Expr8Get();
            }
            if ((expressionId == 9)) {
                AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly valDataContext9 = new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext9.ValueType___Expr9Get();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool CanExecuteExpression(string expressionText, bool isReference, System.Collections.Generic.IList<System.Activities.LocationReference> locations, out int expressionId) {
            if (((isReference == true) 
                        && ((expressionText == "connectionString") 
                        && (AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 0;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "connectionString") 
                        && (AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 1;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "addressMGLEndpoint") 
                        && (AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 2;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "addressMGLUser") 
                        && (AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 3;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "addressMGLHeaderRequest") 
                        && (AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 4;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "addressMGLResponse") 
                        && (AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 5;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "addressMGLHeaderRequest") 
                        && (AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 6;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "addressMGLRequest") 
                        && (AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 7;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "addressMGLEndpoint") 
                        && (AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 8;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "addressMGLUser") 
                        && (AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 9;
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
                return new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2(locationReferences).@__Expr0GetTree();
            }
            if ((expressionId == 1)) {
                return new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly(locationReferences).@__Expr1GetTree();
            }
            if ((expressionId == 2)) {
                return new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2(locationReferences).@__Expr2GetTree();
            }
            if ((expressionId == 3)) {
                return new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2(locationReferences).@__Expr3GetTree();
            }
            if ((expressionId == 4)) {
                return new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2(locationReferences).@__Expr4GetTree();
            }
            if ((expressionId == 5)) {
                return new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2(locationReferences).@__Expr5GetTree();
            }
            if ((expressionId == 6)) {
                return new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly(locationReferences).@__Expr6GetTree();
            }
            if ((expressionId == 7)) {
                return new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly(locationReferences).@__Expr7GetTree();
            }
            if ((expressionId == 8)) {
                return new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly(locationReferences).@__Expr8GetTree();
            }
            if ((expressionId == 9)) {
                return new AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly(locationReferences).@__Expr9GetTree();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext0 : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext0(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext0_ForReadOnly : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext1 : AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext0 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext1(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected AmxPeruPSBActivities.AMXCOLOMBIA.Model.AddressMGLtechDetails addressMGLRequest {
                get {
                    return ((AmxPeruPSBActivities.AMXCOLOMBIA.Model.AddressMGLtechDetails)(this.GetVariableValue((0 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((0 + locationsOffset), value);
                }
            }
            
            protected string addressMGLResponse {
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
                if (((locationReferences[(offset + 0)].Name != "addressMGLRequest") 
                            || (locationReferences[(offset + 0)].Type != typeof(AmxPeruPSBActivities.AMXCOLOMBIA.Model.AddressMGLtechDetails)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "addressMGLResponse") 
                            || (locationReferences[(offset + 1)].Type != typeof(string)))) {
                    return false;
                }
                return AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext0.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext1_ForReadOnly : AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext0_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected AmxPeruPSBActivities.AMXCOLOMBIA.Model.AddressMGLtechDetails addressMGLRequest {
                get {
                    return ((AmxPeruPSBActivities.AMXCOLOMBIA.Model.AddressMGLtechDetails)(this.GetVariableValue((0 + locationsOffset))));
                }
            }
            
            protected string addressMGLResponse {
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
                if (((locationReferences[(offset + 0)].Name != "addressMGLRequest") 
                            || (locationReferences[(offset + 0)].Type != typeof(AmxPeruPSBActivities.AMXCOLOMBIA.Model.AddressMGLtechDetails)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "addressMGLResponse") 
                            || (locationReferences[(offset + 1)].Type != typeof(string)))) {
                    return false;
                }
                return AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext0_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2 : AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext1 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
            
            protected string addressMGLEndpoint {
                get {
                    return ((string)(this.GetVariableValue((3 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((3 + locationsOffset), value);
                }
            }
            
            protected string addressMGLHeaderRequest {
                get {
                    return ((string)(this.GetVariableValue((4 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((4 + locationsOffset), value);
                }
            }
            
            protected string addressMGLUser {
                get {
                    return ((string)(this.GetVariableValue((5 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((5 + locationsOffset), value);
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
                
                #line 147 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMX COLOMBIA\AMXRETRIEVECUSTOMERADDRESSMGLTECHDETAILS.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
            connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr0Get() {
                
                #line 147 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMX COLOMBIA\AMXRETRIEVECUSTOMERADDRESSMGLTECHDETAILS.XAML"
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
                
                #line 147 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMX COLOMBIA\AMXRETRIEVECUSTOMERADDRESSMGLTECHDETAILS.XAML"
                
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
                
                #line 84 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMX COLOMBIA\AMXRETRIEVECUSTOMERADDRESSMGLTECHDETAILS.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                addressMGLEndpoint;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr2Get() {
                
                #line 84 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMX COLOMBIA\AMXRETRIEVECUSTOMERADDRESSMGLTECHDETAILS.XAML"
                return 
                addressMGLEndpoint;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr2Get() {
                this.GetValueTypeValues();
                return this.@__Expr2Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr2Set(string value) {
                
                #line 84 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMX COLOMBIA\AMXRETRIEVECUSTOMERADDRESSMGLTECHDETAILS.XAML"
                
                addressMGLEndpoint = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr2Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr2Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr3GetTree() {
                
                #line 92 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMX COLOMBIA\AMXRETRIEVECUSTOMERADDRESSMGLTECHDETAILS.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                addressMGLUser;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr3Get() {
                
                #line 92 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMX COLOMBIA\AMXRETRIEVECUSTOMERADDRESSMGLTECHDETAILS.XAML"
                return 
                addressMGLUser;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr3Get() {
                this.GetValueTypeValues();
                return this.@__Expr3Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr3Set(string value) {
                
                #line 92 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMX COLOMBIA\AMXRETRIEVECUSTOMERADDRESSMGLTECHDETAILS.XAML"
                
                addressMGLUser = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr3Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr3Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr4GetTree() {
                
                #line 100 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMX COLOMBIA\AMXRETRIEVECUSTOMERADDRESSMGLTECHDETAILS.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                addressMGLHeaderRequest;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr4Get() {
                
                #line 100 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMX COLOMBIA\AMXRETRIEVECUSTOMERADDRESSMGLTECHDETAILS.XAML"
                return 
                addressMGLHeaderRequest;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr4Get() {
                this.GetValueTypeValues();
                return this.@__Expr4Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr4Set(string value) {
                
                #line 100 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMX COLOMBIA\AMXRETRIEVECUSTOMERADDRESSMGLTECHDETAILS.XAML"
                
                addressMGLHeaderRequest = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr4Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr4Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr5GetTree() {
                
                #line 113 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMX COLOMBIA\AMXRETRIEVECUSTOMERADDRESSMGLTECHDETAILS.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                addressMGLResponse;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr5Get() {
                
                #line 113 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMX COLOMBIA\AMXRETRIEVECUSTOMERADDRESSMGLTECHDETAILS.XAML"
                return 
                addressMGLResponse;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr5Get() {
                this.GetValueTypeValues();
                return this.@__Expr5Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr5Set(string value) {
                
                #line 113 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMX COLOMBIA\AMXRETRIEVECUSTOMERADDRESSMGLTECHDETAILS.XAML"
                
                addressMGLResponse = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr5Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr5Set(value);
                this.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 6))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 6);
                }
                expectedLocationsCount = 6;
                if (((locationReferences[(offset + 2)].Name != "connectionString") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "addressMGLEndpoint") 
                            || (locationReferences[(offset + 3)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "addressMGLHeaderRequest") 
                            || (locationReferences[(offset + 4)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 5)].Name != "addressMGLUser") 
                            || (locationReferences[(offset + 5)].Type != typeof(string)))) {
                    return false;
                }
                return AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext1.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly : AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext1_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string connectionString {
                get {
                    return ((string)(this.GetVariableValue((2 + locationsOffset))));
                }
            }
            
            protected string addressMGLEndpoint {
                get {
                    return ((string)(this.GetVariableValue((3 + locationsOffset))));
                }
            }
            
            protected string addressMGLHeaderRequest {
                get {
                    return ((string)(this.GetVariableValue((4 + locationsOffset))));
                }
            }
            
            protected string addressMGLUser {
                get {
                    return ((string)(this.GetVariableValue((5 + locationsOffset))));
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
                
                #line 136 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMX COLOMBIA\AMXRETRIEVECUSTOMERADDRESSMGLTECHDETAILS.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
            connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr1Get() {
                
                #line 136 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMX COLOMBIA\AMXRETRIEVECUSTOMERADDRESSMGLTECHDETAILS.XAML"
                return 
            connectionString;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr1Get() {
                this.GetValueTypeValues();
                return this.@__Expr1Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr6GetTree() {
                
                #line 118 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMX COLOMBIA\AMXRETRIEVECUSTOMERADDRESSMGLTECHDETAILS.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                addressMGLHeaderRequest;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr6Get() {
                
                #line 118 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMX COLOMBIA\AMXRETRIEVECUSTOMERADDRESSMGLTECHDETAILS.XAML"
                return 
                addressMGLHeaderRequest;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr6Get() {
                this.GetValueTypeValues();
                return this.@__Expr6Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr7GetTree() {
                
                #line 108 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMX COLOMBIA\AMXRETRIEVECUSTOMERADDRESSMGLTECHDETAILS.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.AMXCOLOMBIA.Model.AddressMGLtechDetails>> expression = () => 
                addressMGLRequest;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.AMXCOLOMBIA.Model.AddressMGLtechDetails @__Expr7Get() {
                
                #line 108 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMX COLOMBIA\AMXRETRIEVECUSTOMERADDRESSMGLTECHDETAILS.XAML"
                return 
                addressMGLRequest;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.AMXCOLOMBIA.Model.AddressMGLtechDetails ValueType___Expr7Get() {
                this.GetValueTypeValues();
                return this.@__Expr7Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr8GetTree() {
                
                #line 123 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMX COLOMBIA\AMXRETRIEVECUSTOMERADDRESSMGLTECHDETAILS.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                addressMGLEndpoint;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr8Get() {
                
                #line 123 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMX COLOMBIA\AMXRETRIEVECUSTOMERADDRESSMGLTECHDETAILS.XAML"
                return 
                addressMGLEndpoint;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr8Get() {
                this.GetValueTypeValues();
                return this.@__Expr8Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr9GetTree() {
                
                #line 128 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMX COLOMBIA\AMXRETRIEVECUSTOMERADDRESSMGLTECHDETAILS.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                addressMGLUser;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr9Get() {
                
                #line 128 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMX COLOMBIA\AMXRETRIEVECUSTOMERADDRESSMGLTECHDETAILS.XAML"
                return 
                addressMGLUser;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr9Get() {
                this.GetValueTypeValues();
                return this.@__Expr9Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 6))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 6);
                }
                expectedLocationsCount = 6;
                if (((locationReferences[(offset + 2)].Name != "connectionString") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "addressMGLEndpoint") 
                            || (locationReferences[(offset + 3)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "addressMGLHeaderRequest") 
                            || (locationReferences[(offset + 4)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 5)].Name != "addressMGLUser") 
                            || (locationReferences[(offset + 5)].Type != typeof(string)))) {
                    return false;
                }
                return AMXRetrieveCustomerAddressMGLTechDetails_TypedDataContext1_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
    }
}

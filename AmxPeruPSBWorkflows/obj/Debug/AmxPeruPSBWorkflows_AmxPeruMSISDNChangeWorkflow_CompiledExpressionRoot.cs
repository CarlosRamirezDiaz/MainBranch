namespace AmxPeruPSBWorkflows {
    
    #line 24 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruMSISDNChangeWorkflow.xaml"
    using System;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruMSISDNChangeWorkflow.xaml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 25 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruMSISDNChangeWorkflow.xaml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruMSISDNChangeWorkflow.xaml"
    using System.Activities;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruMSISDNChangeWorkflow.xaml"
    using System.Activities.Expressions;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruMSISDNChangeWorkflow.xaml"
    using System.Activities.Statements;
    
    #line default
    #line hidden
    
    #line 26 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruMSISDNChangeWorkflow.xaml"
    using System.Data;
    
    #line default
    #line hidden
    
    #line 27 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruMSISDNChangeWorkflow.xaml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 28 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruMSISDNChangeWorkflow.xaml"
    using System.Text;
    
    #line default
    #line hidden
    
    #line 29 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruMSISDNChangeWorkflow.xaml"
    using AmxPeruPSBActivities.Model;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruMSISDNChangeWorkflow.xaml"
    using System.Activities.XamlIntegration;
    
    #line default
    #line hidden
    
    
    public partial class AmxPeruMSISDNChangeWorkflow : System.Activities.XamlIntegration.ICompiledExpressionRoot {
        
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
                this.dataContextActivities = AmxPeruMSISDNChangeWorkflow_TypedDataContext2.GetDataContextActivitiesHelper(this.rootActivity, this.forImplementation);
            }
            if ((expressionId == 0)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruMSISDNChangeWorkflow_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruMSISDNChangeWorkflow_TypedDataContext2(locations, activityContext, true);
                }
                AmxPeruMSISDNChangeWorkflow_TypedDataContext2 refDataContext0 = ((AmxPeruMSISDNChangeWorkflow_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 1)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruMSISDNChangeWorkflow_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxPeruMSISDNChangeWorkflow_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruMSISDNChangeWorkflow_TypedDataContext2_ForReadOnly valDataContext1 = ((AmxPeruMSISDNChangeWorkflow_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruMSISDNChangeWorkflow_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new AmxPeruMSISDNChangeWorkflow_TypedDataContext3(locations, activityContext, true);
                }
                AmxPeruMSISDNChangeWorkflow_TypedDataContext3 refDataContext2 = ((AmxPeruMSISDNChangeWorkflow_TypedDataContext3)(cachedCompiledDataContext[2]));
                return refDataContext2.GetLocation<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>>(refDataContext2.ValueType___Expr2Get, refDataContext2.ValueType___Expr2Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 3)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruMSISDNChangeWorkflow_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new AmxPeruMSISDNChangeWorkflow_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruMSISDNChangeWorkflow_TypedDataContext3_ForReadOnly valDataContext3 = ((AmxPeruMSISDNChangeWorkflow_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[3]));
                return valDataContext3.ValueType___Expr3Get();
            }
            if ((expressionId == 4)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruMSISDNChangeWorkflow_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new AmxPeruMSISDNChangeWorkflow_TypedDataContext3(locations, activityContext, true);
                }
                AmxPeruMSISDNChangeWorkflow_TypedDataContext3 refDataContext4 = ((AmxPeruMSISDNChangeWorkflow_TypedDataContext3)(cachedCompiledDataContext[2]));
                return refDataContext4.GetLocation<AmxPeruPSBActivities.Model.AmxPeruChangeSimCardGeneralResponse>(refDataContext4.ValueType___Expr4Get, refDataContext4.ValueType___Expr4Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 5)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruMSISDNChangeWorkflow_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new AmxPeruMSISDNChangeWorkflow_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruMSISDNChangeWorkflow_TypedDataContext3_ForReadOnly valDataContext5 = ((AmxPeruMSISDNChangeWorkflow_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[3]));
                return valDataContext5.ValueType___Expr5Get();
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
                AmxPeruMSISDNChangeWorkflow_TypedDataContext2 refDataContext0 = new AmxPeruMSISDNChangeWorkflow_TypedDataContext2(locations, true);
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set);
            }
            if ((expressionId == 1)) {
                AmxPeruMSISDNChangeWorkflow_TypedDataContext2_ForReadOnly valDataContext1 = new AmxPeruMSISDNChangeWorkflow_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                AmxPeruMSISDNChangeWorkflow_TypedDataContext3 refDataContext2 = new AmxPeruMSISDNChangeWorkflow_TypedDataContext3(locations, true);
                return refDataContext2.GetLocation<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>>(refDataContext2.ValueType___Expr2Get, refDataContext2.ValueType___Expr2Set);
            }
            if ((expressionId == 3)) {
                AmxPeruMSISDNChangeWorkflow_TypedDataContext3_ForReadOnly valDataContext3 = new AmxPeruMSISDNChangeWorkflow_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext3.ValueType___Expr3Get();
            }
            if ((expressionId == 4)) {
                AmxPeruMSISDNChangeWorkflow_TypedDataContext3 refDataContext4 = new AmxPeruMSISDNChangeWorkflow_TypedDataContext3(locations, true);
                return refDataContext4.GetLocation<AmxPeruPSBActivities.Model.AmxPeruChangeSimCardGeneralResponse>(refDataContext4.ValueType___Expr4Get, refDataContext4.ValueType___Expr4Set);
            }
            if ((expressionId == 5)) {
                AmxPeruMSISDNChangeWorkflow_TypedDataContext3_ForReadOnly valDataContext5 = new AmxPeruMSISDNChangeWorkflow_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext5.ValueType___Expr5Get();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool CanExecuteExpression(string expressionText, bool isReference, System.Collections.Generic.IList<System.Activities.LocationReference> locations, out int expressionId) {
            if (((isReference == true) 
                        && ((expressionText == "connectionString") 
                        && (AmxPeruMSISDNChangeWorkflow_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 0;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "connectionString") 
                        && (AmxPeruMSISDNChangeWorkflow_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 1;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "changeReason") 
                        && (AmxPeruMSISDNChangeWorkflow_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 2;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "changeReason") 
                        && (AmxPeruMSISDNChangeWorkflow_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 3;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "resources") 
                        && (AmxPeruMSISDNChangeWorkflow_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 4;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "AmxPeruChangeSimCardGeneralRequest") 
                        && (AmxPeruMSISDNChangeWorkflow_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 5;
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
                return new AmxPeruMSISDNChangeWorkflow_TypedDataContext2(locationReferences).@__Expr0GetTree();
            }
            if ((expressionId == 1)) {
                return new AmxPeruMSISDNChangeWorkflow_TypedDataContext2_ForReadOnly(locationReferences).@__Expr1GetTree();
            }
            if ((expressionId == 2)) {
                return new AmxPeruMSISDNChangeWorkflow_TypedDataContext3(locationReferences).@__Expr2GetTree();
            }
            if ((expressionId == 3)) {
                return new AmxPeruMSISDNChangeWorkflow_TypedDataContext3_ForReadOnly(locationReferences).@__Expr3GetTree();
            }
            if ((expressionId == 4)) {
                return new AmxPeruMSISDNChangeWorkflow_TypedDataContext3(locationReferences).@__Expr4GetTree();
            }
            if ((expressionId == 5)) {
                return new AmxPeruMSISDNChangeWorkflow_TypedDataContext3_ForReadOnly(locationReferences).@__Expr5GetTree();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruMSISDNChangeWorkflow_TypedDataContext0 : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruMSISDNChangeWorkflow_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruMSISDNChangeWorkflow_TypedDataContext0(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruMSISDNChangeWorkflow_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class AmxPeruMSISDNChangeWorkflow_TypedDataContext0_ForReadOnly : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruMSISDNChangeWorkflow_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruMSISDNChangeWorkflow_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruMSISDNChangeWorkflow_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class AmxPeruMSISDNChangeWorkflow_TypedDataContext1 : AmxPeruMSISDNChangeWorkflow_TypedDataContext0 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruMSISDNChangeWorkflow_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruMSISDNChangeWorkflow_TypedDataContext1(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruMSISDNChangeWorkflow_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected AmxPeruPSBActivities.Model.AmxPeruChangeSimCardGeneralRequest AmxPeruChangeSimCardGeneralRequest {
                get {
                    return ((AmxPeruPSBActivities.Model.AmxPeruChangeSimCardGeneralRequest)(this.GetVariableValue((0 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((0 + locationsOffset), value);
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
                            && (locationReferences.Count < 1))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 1);
                }
                expectedLocationsCount = 1;
                if (((locationReferences[(offset + 0)].Name != "AmxPeruChangeSimCardGeneralRequest") 
                            || (locationReferences[(offset + 0)].Type != typeof(AmxPeruPSBActivities.Model.AmxPeruChangeSimCardGeneralRequest)))) {
                    return false;
                }
                return AmxPeruMSISDNChangeWorkflow_TypedDataContext0.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruMSISDNChangeWorkflow_TypedDataContext1_ForReadOnly : AmxPeruMSISDNChangeWorkflow_TypedDataContext0_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruMSISDNChangeWorkflow_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruMSISDNChangeWorkflow_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruMSISDNChangeWorkflow_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected AmxPeruPSBActivities.Model.AmxPeruChangeSimCardGeneralRequest AmxPeruChangeSimCardGeneralRequest {
                get {
                    return ((AmxPeruPSBActivities.Model.AmxPeruChangeSimCardGeneralRequest)(this.GetVariableValue((0 + locationsOffset))));
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
                            && (locationReferences.Count < 1))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 1);
                }
                expectedLocationsCount = 1;
                if (((locationReferences[(offset + 0)].Name != "AmxPeruChangeSimCardGeneralRequest") 
                            || (locationReferences[(offset + 0)].Type != typeof(AmxPeruPSBActivities.Model.AmxPeruChangeSimCardGeneralRequest)))) {
                    return false;
                }
                return AmxPeruMSISDNChangeWorkflow_TypedDataContext0_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruMSISDNChangeWorkflow_TypedDataContext2 : AmxPeruMSISDNChangeWorkflow_TypedDataContext1 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruMSISDNChangeWorkflow_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruMSISDNChangeWorkflow_TypedDataContext2(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruMSISDNChangeWorkflow_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string connectionString {
                get {
                    return ((string)(this.GetVariableValue((1 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((1 + locationsOffset), value);
                }
            }
            
            protected AmxPeruPSBActivities.Model.AmxPeruChangeSimCardGeneralResponse resources {
                get {
                    return ((AmxPeruPSBActivities.Model.AmxPeruChangeSimCardGeneralResponse)(this.GetVariableValue((2 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((2 + locationsOffset), value);
                }
            }
            
            protected string selectionType {
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
                
                #line 80 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUMSISDNCHANGEWORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
              connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr0Get() {
                
                #line 80 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUMSISDNCHANGEWORKFLOW.XAML"
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
                
                #line 80 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUMSISDNCHANGEWORKFLOW.XAML"
                
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
                if (((locationReferences[(offset + 1)].Name != "connectionString") 
                            || (locationReferences[(offset + 1)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 2)].Name != "resources") 
                            || (locationReferences[(offset + 2)].Type != typeof(AmxPeruPSBActivities.Model.AmxPeruChangeSimCardGeneralResponse)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "selectionType") 
                            || (locationReferences[(offset + 3)].Type != typeof(string)))) {
                    return false;
                }
                return AmxPeruMSISDNChangeWorkflow_TypedDataContext1.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruMSISDNChangeWorkflow_TypedDataContext2_ForReadOnly : AmxPeruMSISDNChangeWorkflow_TypedDataContext1_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruMSISDNChangeWorkflow_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruMSISDNChangeWorkflow_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruMSISDNChangeWorkflow_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string connectionString {
                get {
                    return ((string)(this.GetVariableValue((1 + locationsOffset))));
                }
            }
            
            protected AmxPeruPSBActivities.Model.AmxPeruChangeSimCardGeneralResponse resources {
                get {
                    return ((AmxPeruPSBActivities.Model.AmxPeruChangeSimCardGeneralResponse)(this.GetVariableValue((2 + locationsOffset))));
                }
            }
            
            protected string selectionType {
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
                
                #line 167 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUMSISDNCHANGEWORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr1Get() {
                
                #line 167 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUMSISDNCHANGEWORKFLOW.XAML"
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
                if (((locationReferences[(offset + 1)].Name != "connectionString") 
                            || (locationReferences[(offset + 1)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 2)].Name != "resources") 
                            || (locationReferences[(offset + 2)].Type != typeof(AmxPeruPSBActivities.Model.AmxPeruChangeSimCardGeneralResponse)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "selectionType") 
                            || (locationReferences[(offset + 3)].Type != typeof(string)))) {
                    return false;
                }
                return AmxPeruMSISDNChangeWorkflow_TypedDataContext1_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruMSISDNChangeWorkflow_TypedDataContext3 : AmxPeruMSISDNChangeWorkflow_TypedDataContext2 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruMSISDNChangeWorkflow_TypedDataContext3(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruMSISDNChangeWorkflow_TypedDataContext3(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruMSISDNChangeWorkflow_TypedDataContext3(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> changeReason {
                get {
                    return ((System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>)(this.GetVariableValue((4 + locationsOffset))));
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
            
            internal System.Linq.Expressions.Expression @__Expr2GetTree() {
                
                #line 100 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUMSISDNCHANGEWORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>>> expression = () => 
                                  changeReason;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> @__Expr2Get() {
                
                #line 100 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUMSISDNCHANGEWORKFLOW.XAML"
                return 
                                  changeReason;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> ValueType___Expr2Get() {
                this.GetValueTypeValues();
                return this.@__Expr2Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr2Set(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> value) {
                
                #line 100 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUMSISDNCHANGEWORKFLOW.XAML"
                
                                  changeReason = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr2Set(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> value) {
                this.GetValueTypeValues();
                this.@__Expr2Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr4GetTree() {
                
                #line 119 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUMSISDNCHANGEWORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.AmxPeruChangeSimCardGeneralResponse>> expression = () => 
                                      resources;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.AmxPeruChangeSimCardGeneralResponse @__Expr4Get() {
                
                #line 119 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUMSISDNCHANGEWORKFLOW.XAML"
                return 
                                      resources;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.AmxPeruChangeSimCardGeneralResponse ValueType___Expr4Get() {
                this.GetValueTypeValues();
                return this.@__Expr4Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr4Set(AmxPeruPSBActivities.Model.AmxPeruChangeSimCardGeneralResponse value) {
                
                #line 119 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUMSISDNCHANGEWORKFLOW.XAML"
                
                                      resources = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr4Set(AmxPeruPSBActivities.Model.AmxPeruChangeSimCardGeneralResponse value) {
                this.GetValueTypeValues();
                this.@__Expr4Set(value);
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
                if (((locationReferences[(offset + 4)].Name != "changeReason") 
                            || (locationReferences[(offset + 4)].Type != typeof(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>)))) {
                    return false;
                }
                return AmxPeruMSISDNChangeWorkflow_TypedDataContext2.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruMSISDNChangeWorkflow_TypedDataContext3_ForReadOnly : AmxPeruMSISDNChangeWorkflow_TypedDataContext2_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruMSISDNChangeWorkflow_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruMSISDNChangeWorkflow_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruMSISDNChangeWorkflow_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> changeReason {
                get {
                    return ((System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>)(this.GetVariableValue((4 + locationsOffset))));
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
                
                #line 109 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUMSISDNCHANGEWORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>>> expression = () => 
                                      changeReason;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> @__Expr3Get() {
                
                #line 109 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUMSISDNCHANGEWORKFLOW.XAML"
                return 
                                      changeReason;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> ValueType___Expr3Get() {
                this.GetValueTypeValues();
                return this.@__Expr3Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr5GetTree() {
                
                #line 114 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUMSISDNCHANGEWORKFLOW.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.AmxPeruChangeSimCardGeneralRequest>> expression = () => 
                                      AmxPeruChangeSimCardGeneralRequest;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.AmxPeruChangeSimCardGeneralRequest @__Expr5Get() {
                
                #line 114 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUMSISDNCHANGEWORKFLOW.XAML"
                return 
                                      AmxPeruChangeSimCardGeneralRequest;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.AmxPeruChangeSimCardGeneralRequest ValueType___Expr5Get() {
                this.GetValueTypeValues();
                return this.@__Expr5Get();
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
                if (((locationReferences[(offset + 4)].Name != "changeReason") 
                            || (locationReferences[(offset + 4)].Type != typeof(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>)))) {
                    return false;
                }
                return AmxPeruMSISDNChangeWorkflow_TypedDataContext2_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
    }
}

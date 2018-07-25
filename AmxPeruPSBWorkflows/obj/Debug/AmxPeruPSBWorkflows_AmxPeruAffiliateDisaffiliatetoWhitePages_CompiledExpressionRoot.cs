namespace AmxPeruPSBWorkflows {
    
    #line 24 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruAffiliateDisaffiliatetoWhitePages.xaml"
    using System;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruAffiliateDisaffiliatetoWhitePages.xaml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 25 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruAffiliateDisaffiliatetoWhitePages.xaml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruAffiliateDisaffiliatetoWhitePages.xaml"
    using System.Activities;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruAffiliateDisaffiliatetoWhitePages.xaml"
    using System.Activities.Expressions;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruAffiliateDisaffiliatetoWhitePages.xaml"
    using System.Activities.Statements;
    
    #line default
    #line hidden
    
    #line 26 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruAffiliateDisaffiliatetoWhitePages.xaml"
    using System.Data;
    
    #line default
    #line hidden
    
    #line 27 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruAffiliateDisaffiliatetoWhitePages.xaml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 28 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruAffiliateDisaffiliatetoWhitePages.xaml"
    using System.Text;
    
    #line default
    #line hidden
    
    #line 29 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruAffiliateDisaffiliatetoWhitePages.xaml"
    using AmxPeruPSBActivities.Model.AffiliateDisaffiliate;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruAffiliateDisaffiliatetoWhitePages.xaml"
    using System.Activities.XamlIntegration;
    
    #line default
    #line hidden
    
    
    public partial class AmxPeruAffiliateDisaffiliatetoWhitePages : System.Activities.XamlIntegration.ICompiledExpressionRoot {
        
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
                this.dataContextActivities = AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2.GetDataContextActivitiesHelper(this.rootActivity, this.forImplementation);
            }
            if ((expressionId == 0)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2(locations, activityContext, true);
                }
                AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2 refDataContext0 = ((AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 1)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2_ForReadOnly valDataContext1 = ((AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2_ForReadOnly valDataContext2 = ((AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext2.ValueType___Expr2Get();
            }
            if ((expressionId == 3)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2(locations, activityContext, true);
                }
                AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2 refDataContext3 = ((AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext3.GetLocation<AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AmxPeruAffiliateDisaffiliatetoWhitePagesResponse>(refDataContext3.ValueType___Expr3Get, refDataContext3.ValueType___Expr3Set, expressionId, this.rootActivity, activityContext);
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
                AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2 refDataContext0 = new AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2(locations, true);
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set);
            }
            if ((expressionId == 1)) {
                AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2_ForReadOnly valDataContext1 = new AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2_ForReadOnly valDataContext2 = new AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext2.ValueType___Expr2Get();
            }
            if ((expressionId == 3)) {
                AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2 refDataContext3 = new AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2(locations, true);
                return refDataContext3.GetLocation<AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AmxPeruAffiliateDisaffiliatetoWhitePagesResponse>(refDataContext3.ValueType___Expr3Get, refDataContext3.ValueType___Expr3Set);
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool CanExecuteExpression(string expressionText, bool isReference, System.Collections.Generic.IList<System.Activities.LocationReference> locations, out int expressionId) {
            if (((isReference == true) 
                        && ((expressionText == "connectionString") 
                        && (AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 0;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "connectionString") 
                        && (AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 1;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "Input") 
                        && (AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 2;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "Output") 
                        && (AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 3;
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
                return new AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2(locationReferences).@__Expr0GetTree();
            }
            if ((expressionId == 1)) {
                return new AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2_ForReadOnly(locationReferences).@__Expr1GetTree();
            }
            if ((expressionId == 2)) {
                return new AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2_ForReadOnly(locationReferences).@__Expr2GetTree();
            }
            if ((expressionId == 3)) {
                return new AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2(locationReferences).@__Expr3GetTree();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext0 : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext0(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext0_ForReadOnly : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext1 : AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext0 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext1(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AmxPeruAffiliateDisaffiliatetoWhitePagesResponse Output {
                get {
                    return ((AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AmxPeruAffiliateDisaffiliatetoWhitePagesResponse)(this.GetVariableValue((0 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((0 + locationsOffset), value);
                }
            }
            
            protected AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AmxPeruAffiliateDisaffiliatetoWhitePagesRequest Input {
                get {
                    return ((AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AmxPeruAffiliateDisaffiliatetoWhitePagesRequest)(this.GetVariableValue((1 + locationsOffset))));
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
                if (((locationReferences[(offset + 0)].Name != "Output") 
                            || (locationReferences[(offset + 0)].Type != typeof(AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AmxPeruAffiliateDisaffiliatetoWhitePagesResponse)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "Input") 
                            || (locationReferences[(offset + 1)].Type != typeof(AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AmxPeruAffiliateDisaffiliatetoWhitePagesRequest)))) {
                    return false;
                }
                return AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext0.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext1_ForReadOnly : AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext0_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AmxPeruAffiliateDisaffiliatetoWhitePagesResponse Output {
                get {
                    return ((AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AmxPeruAffiliateDisaffiliatetoWhitePagesResponse)(this.GetVariableValue((0 + locationsOffset))));
                }
            }
            
            protected AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AmxPeruAffiliateDisaffiliatetoWhitePagesRequest Input {
                get {
                    return ((AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AmxPeruAffiliateDisaffiliatetoWhitePagesRequest)(this.GetVariableValue((1 + locationsOffset))));
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
                if (((locationReferences[(offset + 0)].Name != "Output") 
                            || (locationReferences[(offset + 0)].Type != typeof(AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AmxPeruAffiliateDisaffiliatetoWhitePagesResponse)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "Input") 
                            || (locationReferences[(offset + 1)].Type != typeof(AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AmxPeruAffiliateDisaffiliatetoWhitePagesRequest)))) {
                    return false;
                }
                return AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext0_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2 : AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext1 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
                
                #line 77 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATETOWHITEPAGES.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
              connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr0Get() {
                
                #line 77 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATETOWHITEPAGES.XAML"
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
                
                #line 77 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATETOWHITEPAGES.XAML"
                
              connectionString = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr0Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr0Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr3GetTree() {
                
                #line 93 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATETOWHITEPAGES.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AmxPeruAffiliateDisaffiliatetoWhitePagesResponse>> expression = () => 
                      Output;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AmxPeruAffiliateDisaffiliatetoWhitePagesResponse @__Expr3Get() {
                
                #line 93 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATETOWHITEPAGES.XAML"
                return 
                      Output;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AmxPeruAffiliateDisaffiliatetoWhitePagesResponse ValueType___Expr3Get() {
                this.GetValueTypeValues();
                return this.@__Expr3Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr3Set(AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AmxPeruAffiliateDisaffiliatetoWhitePagesResponse value) {
                
                #line 93 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATETOWHITEPAGES.XAML"
                
                      Output = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr3Set(AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AmxPeruAffiliateDisaffiliatetoWhitePagesResponse value) {
                this.GetValueTypeValues();
                this.@__Expr3Set(value);
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
                return AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext1.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2_ForReadOnly : AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext1_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
                
                #line 100 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATETOWHITEPAGES.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr1Get() {
                
                #line 100 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATETOWHITEPAGES.XAML"
                return 
                  connectionString;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr1Get() {
                this.GetValueTypeValues();
                return this.@__Expr1Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr2GetTree() {
                
                #line 88 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATETOWHITEPAGES.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AmxPeruAffiliateDisaffiliatetoWhitePagesRequest>> expression = () => 
                      Input;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AmxPeruAffiliateDisaffiliatetoWhitePagesRequest @__Expr2Get() {
                
                #line 88 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUAFFILIATEDISAFFILIATETOWHITEPAGES.XAML"
                return 
                      Input;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.AffiliateDisaffiliate.AmxPeruAffiliateDisaffiliatetoWhitePagesRequest ValueType___Expr2Get() {
                this.GetValueTypeValues();
                return this.@__Expr2Get();
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
                return AmxPeruAffiliateDisaffiliatetoWhitePages_TypedDataContext1_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
    }
}

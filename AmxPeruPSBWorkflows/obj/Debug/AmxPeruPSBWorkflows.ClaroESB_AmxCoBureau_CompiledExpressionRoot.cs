namespace AmxPeruPSBWorkflows.ClaroESB {
    
    #line 46 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\ClaroESB\AmxCoBureau.xaml"
    using System;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\ClaroESB\AmxCoBureau.xaml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 47 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\ClaroESB\AmxCoBureau.xaml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\ClaroESB\AmxCoBureau.xaml"
    using System.Activities;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\ClaroESB\AmxCoBureau.xaml"
    using System.Activities.Expressions;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\ClaroESB\AmxCoBureau.xaml"
    using System.Activities.Statements;
    
    #line default
    #line hidden
    
    #line 48 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\ClaroESB\AmxCoBureau.xaml"
    using System.Data;
    
    #line default
    #line hidden
    
    #line 49 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\ClaroESB\AmxCoBureau.xaml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 50 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\ClaroESB\AmxCoBureau.xaml"
    using System.Text;
    
    #line default
    #line hidden
    
    #line 51 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\ClaroESB\AmxCoBureau.xaml"
    using AmxPeruPSBActivities.Model;
    
    #line default
    #line hidden
    
    #line 52 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\ClaroESB\AmxCoBureau.xaml"
    using Ericsson.ETELCRM.Entities.Crm;
    
    #line default
    #line hidden
    
    #line 53 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\ClaroESB\AmxCoBureau.xaml"
    using AmxPeruPSBActivities.Interfaces;
    
    #line default
    #line hidden
    
    #line 54 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\ClaroESB\AmxCoBureau.xaml"
    using AmxPeruPSBActivities.Model.EOC;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\ClaroESB\AmxCoBureau.xaml"
    using System.Activities.XamlIntegration;
    
    #line default
    #line hidden
    
    
    public partial class AmxCoBureau : System.Activities.XamlIntegration.ICompiledExpressionRoot {
        
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
                this.dataContextActivities = AmxCoBureau_TypedDataContext2.GetDataContextActivitiesHelper(this.rootActivity, this.forImplementation);
            }
            if ((expressionId == 0)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxCoBureau_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxCoBureau_TypedDataContext2(locations, activityContext, true);
                }
                AmxCoBureau_TypedDataContext2 refDataContext0 = ((AmxCoBureau_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 1)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxCoBureau_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxCoBureau_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxCoBureau_TypedDataContext2_ForReadOnly valDataContext1 = ((AmxCoBureau_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxCoBureau_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxCoBureau_TypedDataContext2(locations, activityContext, true);
                }
                AmxCoBureau_TypedDataContext2 refDataContext2 = ((AmxCoBureau_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext2.GetLocation<string>(refDataContext2.ValueType___Expr2Get, refDataContext2.ValueType___Expr2Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 3)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxCoBureau_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxCoBureau_TypedDataContext2(locations, activityContext, true);
                }
                AmxCoBureau_TypedDataContext2 refDataContext3 = ((AmxCoBureau_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext3.GetLocation<string>(refDataContext3.ValueType___Expr3Get, refDataContext3.ValueType___Expr3Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 4)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxCoBureau_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxCoBureau_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxCoBureau_TypedDataContext2_ForReadOnly valDataContext4 = ((AmxCoBureau_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext4.ValueType___Expr4Get();
            }
            if ((expressionId == 5)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxCoBureau_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxCoBureau_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxCoBureau_TypedDataContext2_ForReadOnly valDataContext5 = ((AmxCoBureau_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext5.ValueType___Expr5Get();
            }
            if ((expressionId == 6)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxCoBureau_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxCoBureau_TypedDataContext2(locations, activityContext, true);
                }
                AmxCoBureau_TypedDataContext2 refDataContext6 = ((AmxCoBureau_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext6.GetLocation<string>(refDataContext6.ValueType___Expr6Get, refDataContext6.ValueType___Expr6Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 7)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxCoBureau_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxCoBureau_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxCoBureau_TypedDataContext2_ForReadOnly valDataContext7 = ((AmxCoBureau_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxCoBureau_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxCoBureau_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxCoBureau_TypedDataContext2_ForReadOnly valDataContext8 = ((AmxCoBureau_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext8.ValueType___Expr8Get();
            }
            if ((expressionId == 9)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxCoBureau_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxCoBureau_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxCoBureau_TypedDataContext2_ForReadOnly valDataContext9 = ((AmxCoBureau_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext9.ValueType___Expr9Get();
            }
            if ((expressionId == 10)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxCoBureau_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxCoBureau_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxCoBureau_TypedDataContext2_ForReadOnly valDataContext10 = ((AmxCoBureau_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxCoBureau_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxCoBureau_TypedDataContext2(locations, activityContext, true);
                }
                AmxCoBureau_TypedDataContext2 refDataContext11 = ((AmxCoBureau_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext11.GetLocation<System.Collections.Generic.List<AmxPeruPSBActivities.Model.EOC.SRProductResponseModel>>(refDataContext11.ValueType___Expr11Get, refDataContext11.ValueType___Expr11Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 12)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxCoBureau_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxCoBureau_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxCoBureau_TypedDataContext2_ForReadOnly valDataContext12 = ((AmxCoBureau_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext12.ValueType___Expr12Get();
            }
            if ((expressionId == 13)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxCoBureau_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxCoBureau_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxCoBureau_TypedDataContext2_ForReadOnly valDataContext13 = ((AmxCoBureau_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext13.ValueType___Expr13Get();
            }
            if ((expressionId == 14)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxCoBureau_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxCoBureau_TypedDataContext2(locations, activityContext, true);
                }
                AmxCoBureau_TypedDataContext2 refDataContext14 = ((AmxCoBureau_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext14.GetLocation<string>(refDataContext14.ValueType___Expr14Get, refDataContext14.ValueType___Expr14Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 15)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxCoBureau_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxCoBureau_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxCoBureau_TypedDataContext2_ForReadOnly valDataContext15 = ((AmxCoBureau_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext15.ValueType___Expr15Get();
            }
            if ((expressionId == 16)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxCoBureau_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxCoBureau_TypedDataContext2(locations, activityContext, true);
                }
                AmxCoBureau_TypedDataContext2 refDataContext16 = ((AmxCoBureau_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext16.GetLocation<string>(refDataContext16.ValueType___Expr16Get, refDataContext16.ValueType___Expr16Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 17)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxCoBureau_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxCoBureau_TypedDataContext2(locations, activityContext, true);
                }
                AmxCoBureau_TypedDataContext2 refDataContext17 = ((AmxCoBureau_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext17.GetLocation<string>(refDataContext17.ValueType___Expr17Get, refDataContext17.ValueType___Expr17Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 18)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxCoBureau_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxCoBureau_TypedDataContext2(locations, activityContext, true);
                }
                AmxCoBureau_TypedDataContext2 refDataContext18 = ((AmxCoBureau_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext18.GetLocation<string>(refDataContext18.ValueType___Expr18Get, refDataContext18.ValueType___Expr18Set, expressionId, this.rootActivity, activityContext);
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
                AmxCoBureau_TypedDataContext2 refDataContext0 = new AmxCoBureau_TypedDataContext2(locations, true);
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set);
            }
            if ((expressionId == 1)) {
                AmxCoBureau_TypedDataContext2_ForReadOnly valDataContext1 = new AmxCoBureau_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                AmxCoBureau_TypedDataContext2 refDataContext2 = new AmxCoBureau_TypedDataContext2(locations, true);
                return refDataContext2.GetLocation<string>(refDataContext2.ValueType___Expr2Get, refDataContext2.ValueType___Expr2Set);
            }
            if ((expressionId == 3)) {
                AmxCoBureau_TypedDataContext2 refDataContext3 = new AmxCoBureau_TypedDataContext2(locations, true);
                return refDataContext3.GetLocation<string>(refDataContext3.ValueType___Expr3Get, refDataContext3.ValueType___Expr3Set);
            }
            if ((expressionId == 4)) {
                AmxCoBureau_TypedDataContext2_ForReadOnly valDataContext4 = new AmxCoBureau_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext4.ValueType___Expr4Get();
            }
            if ((expressionId == 5)) {
                AmxCoBureau_TypedDataContext2_ForReadOnly valDataContext5 = new AmxCoBureau_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext5.ValueType___Expr5Get();
            }
            if ((expressionId == 6)) {
                AmxCoBureau_TypedDataContext2 refDataContext6 = new AmxCoBureau_TypedDataContext2(locations, true);
                return refDataContext6.GetLocation<string>(refDataContext6.ValueType___Expr6Get, refDataContext6.ValueType___Expr6Set);
            }
            if ((expressionId == 7)) {
                AmxCoBureau_TypedDataContext2_ForReadOnly valDataContext7 = new AmxCoBureau_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                AmxCoBureau_TypedDataContext2_ForReadOnly valDataContext8 = new AmxCoBureau_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext8.ValueType___Expr8Get();
            }
            if ((expressionId == 9)) {
                AmxCoBureau_TypedDataContext2_ForReadOnly valDataContext9 = new AmxCoBureau_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext9.ValueType___Expr9Get();
            }
            if ((expressionId == 10)) {
                AmxCoBureau_TypedDataContext2_ForReadOnly valDataContext10 = new AmxCoBureau_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                AmxCoBureau_TypedDataContext2 refDataContext11 = new AmxCoBureau_TypedDataContext2(locations, true);
                return refDataContext11.GetLocation<System.Collections.Generic.List<AmxPeruPSBActivities.Model.EOC.SRProductResponseModel>>(refDataContext11.ValueType___Expr11Get, refDataContext11.ValueType___Expr11Set);
            }
            if ((expressionId == 12)) {
                AmxCoBureau_TypedDataContext2_ForReadOnly valDataContext12 = new AmxCoBureau_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext12.ValueType___Expr12Get();
            }
            if ((expressionId == 13)) {
                AmxCoBureau_TypedDataContext2_ForReadOnly valDataContext13 = new AmxCoBureau_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext13.ValueType___Expr13Get();
            }
            if ((expressionId == 14)) {
                AmxCoBureau_TypedDataContext2 refDataContext14 = new AmxCoBureau_TypedDataContext2(locations, true);
                return refDataContext14.GetLocation<string>(refDataContext14.ValueType___Expr14Get, refDataContext14.ValueType___Expr14Set);
            }
            if ((expressionId == 15)) {
                AmxCoBureau_TypedDataContext2_ForReadOnly valDataContext15 = new AmxCoBureau_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext15.ValueType___Expr15Get();
            }
            if ((expressionId == 16)) {
                AmxCoBureau_TypedDataContext2 refDataContext16 = new AmxCoBureau_TypedDataContext2(locations, true);
                return refDataContext16.GetLocation<string>(refDataContext16.ValueType___Expr16Get, refDataContext16.ValueType___Expr16Set);
            }
            if ((expressionId == 17)) {
                AmxCoBureau_TypedDataContext2 refDataContext17 = new AmxCoBureau_TypedDataContext2(locations, true);
                return refDataContext17.GetLocation<string>(refDataContext17.ValueType___Expr17Get, refDataContext17.ValueType___Expr17Set);
            }
            if ((expressionId == 18)) {
                AmxCoBureau_TypedDataContext2 refDataContext18 = new AmxCoBureau_TypedDataContext2(locations, true);
                return refDataContext18.GetLocation<string>(refDataContext18.ValueType___Expr18Get, refDataContext18.ValueType___Expr18Set);
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool CanExecuteExpression(string expressionText, bool isReference, System.Collections.Generic.IList<System.Activities.LocationReference> locations, out int expressionId) {
            if (((isReference == true) 
                        && ((expressionText == "connectionString") 
                        && (AmxCoBureau_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 0;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "connectionString") 
                        && (AmxCoBureau_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 1;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "bureauEndpoint") 
                        && (AmxCoBureau_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 2;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "response") 
                        && (AmxCoBureau_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 3;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "individualCustomerId") 
                        && (AmxCoBureau_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 4;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "bureauEndpoint") 
                        && (AmxCoBureau_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 5;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "CupoTotal") 
                        && (AmxCoBureau_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 6;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "response == \"Credit Profile created.\" || response == \"Credit Profile still valid." +
                            "\"") 
                        && (AmxCoBureau_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 7;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "connectionString") 
                        && (AmxCoBureau_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 8;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "srCustomerProductsRequest") 
                        && (AmxCoBureau_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 9;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "Ericsson.PSB.Workflow.Client.Core.Serializer.JsonSettings.Custom") 
                        && (AmxCoBureau_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 10;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "srCustomerProductsResponse") 
                        && (AmxCoBureau_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 11;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "uri") 
                        && (AmxCoBureau_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 12;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "individualCustomerId") 
                        && (AmxCoBureau_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 13;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "Antiguedad") 
                        && (AmxCoBureau_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 14;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "srCustomerProductsResponse") 
                        && (AmxCoBureau_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 15;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "internalBureauResponse") 
                        && (AmxCoBureau_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 16;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "CupoTotal") 
                        && (AmxCoBureau_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 17;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "CantidadLineas") 
                        && (AmxCoBureau_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 18;
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
                return new AmxCoBureau_TypedDataContext2(locationReferences).@__Expr0GetTree();
            }
            if ((expressionId == 1)) {
                return new AmxCoBureau_TypedDataContext2_ForReadOnly(locationReferences).@__Expr1GetTree();
            }
            if ((expressionId == 2)) {
                return new AmxCoBureau_TypedDataContext2(locationReferences).@__Expr2GetTree();
            }
            if ((expressionId == 3)) {
                return new AmxCoBureau_TypedDataContext2(locationReferences).@__Expr3GetTree();
            }
            if ((expressionId == 4)) {
                return new AmxCoBureau_TypedDataContext2_ForReadOnly(locationReferences).@__Expr4GetTree();
            }
            if ((expressionId == 5)) {
                return new AmxCoBureau_TypedDataContext2_ForReadOnly(locationReferences).@__Expr5GetTree();
            }
            if ((expressionId == 6)) {
                return new AmxCoBureau_TypedDataContext2(locationReferences).@__Expr6GetTree();
            }
            if ((expressionId == 7)) {
                return new AmxCoBureau_TypedDataContext2_ForReadOnly(locationReferences).@__Expr7GetTree();
            }
            if ((expressionId == 8)) {
                return new AmxCoBureau_TypedDataContext2_ForReadOnly(locationReferences).@__Expr8GetTree();
            }
            if ((expressionId == 9)) {
                return new AmxCoBureau_TypedDataContext2_ForReadOnly(locationReferences).@__Expr9GetTree();
            }
            if ((expressionId == 10)) {
                return new AmxCoBureau_TypedDataContext2_ForReadOnly(locationReferences).@__Expr10GetTree();
            }
            if ((expressionId == 11)) {
                return new AmxCoBureau_TypedDataContext2(locationReferences).@__Expr11GetTree();
            }
            if ((expressionId == 12)) {
                return new AmxCoBureau_TypedDataContext2_ForReadOnly(locationReferences).@__Expr12GetTree();
            }
            if ((expressionId == 13)) {
                return new AmxCoBureau_TypedDataContext2_ForReadOnly(locationReferences).@__Expr13GetTree();
            }
            if ((expressionId == 14)) {
                return new AmxCoBureau_TypedDataContext2(locationReferences).@__Expr14GetTree();
            }
            if ((expressionId == 15)) {
                return new AmxCoBureau_TypedDataContext2_ForReadOnly(locationReferences).@__Expr15GetTree();
            }
            if ((expressionId == 16)) {
                return new AmxCoBureau_TypedDataContext2(locationReferences).@__Expr16GetTree();
            }
            if ((expressionId == 17)) {
                return new AmxCoBureau_TypedDataContext2(locationReferences).@__Expr17GetTree();
            }
            if ((expressionId == 18)) {
                return new AmxCoBureau_TypedDataContext2(locationReferences).@__Expr18GetTree();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxCoBureau_TypedDataContext0 : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxCoBureau_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxCoBureau_TypedDataContext0(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxCoBureau_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class AmxCoBureau_TypedDataContext0_ForReadOnly : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxCoBureau_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxCoBureau_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxCoBureau_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class AmxCoBureau_TypedDataContext1 : AmxCoBureau_TypedDataContext0 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxCoBureau_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxCoBureau_TypedDataContext1(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxCoBureau_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string individualCustomerId {
                get {
                    return ((string)(this.GetVariableValue((0 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((0 + locationsOffset), value);
                }
            }
            
            protected string Antiguedad {
                get {
                    return ((string)(this.GetVariableValue((1 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((1 + locationsOffset), value);
                }
            }
            
            protected string ListaRestricciones {
                get {
                    return ((string)(this.GetVariableValue((2 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((2 + locationsOffset), value);
                }
            }
            
            protected string PorcentajePagoInicial {
                get {
                    return ((string)(this.GetVariableValue((3 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((3 + locationsOffset), value);
                }
            }
            
            protected string CargosAnticipados {
                get {
                    return ((string)(this.GetVariableValue((4 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((4 + locationsOffset), value);
                }
            }
            
            protected string CupoUtilizado {
                get {
                    return ((string)(this.GetVariableValue((5 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((5 + locationsOffset), value);
                }
            }
            
            protected string uri {
                get {
                    return ((string)(this.GetVariableValue((6 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((6 + locationsOffset), value);
                }
            }
            
            protected string internalBureauResponse {
                get {
                    return ((string)(this.GetVariableValue((7 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((7 + locationsOffset), value);
                }
            }
            
            protected AmxPeruPSBActivities.Model.EOC.SRRetrieveProductRequestModel srCustomerProductsRequest {
                get {
                    return ((AmxPeruPSBActivities.Model.EOC.SRRetrieveProductRequestModel)(this.GetVariableValue((8 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((8 + locationsOffset), value);
                }
            }
            
            protected string EvaluacionListas {
                get {
                    return ((string)(this.GetVariableValue((9 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((9 + locationsOffset), value);
                }
            }
            
            protected string OrdenesLealtadFidelizacion {
                get {
                    return ((string)(this.GetVariableValue((10 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((10 + locationsOffset), value);
                }
            }
            
            protected string CupoTotal {
                get {
                    return ((string)(this.GetVariableValue((11 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((11 + locationsOffset), value);
                }
            }
            
            protected string EvalucacionMora {
                get {
                    return ((string)(this.GetVariableValue((12 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((12 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.List<AmxPeruPSBActivities.Model.EOC.SRProductResponseModel> srCustomerProductsResponse {
                get {
                    return ((System.Collections.Generic.List<AmxPeruPSBActivities.Model.EOC.SRProductResponseModel>)(this.GetVariableValue((13 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((13 + locationsOffset), value);
                }
            }
            
            protected string response {
                get {
                    return ((string)(this.GetVariableValue((14 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((14 + locationsOffset), value);
                }
            }
            
            protected string ProductosRecurrentes {
                get {
                    return ((string)(this.GetVariableValue((15 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((15 + locationsOffset), value);
                }
            }
            
            protected string AplicaCargar1aFactura {
                get {
                    return ((string)(this.GetVariableValue((16 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((16 + locationsOffset), value);
                }
            }
            
            protected string RequiereVisitaDomiciliaria {
                get {
                    return ((string)(this.GetVariableValue((17 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((17 + locationsOffset), value);
                }
            }
            
            protected string CupoFinaciamiento {
                get {
                    return ((string)(this.GetVariableValue((18 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((18 + locationsOffset), value);
                }
            }
            
            protected string ComportamientoPago {
                get {
                    return ((string)(this.GetVariableValue((19 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((19 + locationsOffset), value);
                }
            }
            
            protected string CupoDisponible {
                get {
                    return ((string)(this.GetVariableValue((20 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((20 + locationsOffset), value);
                }
            }
            
            protected string CantidadLineas {
                get {
                    return ((string)(this.GetVariableValue((21 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((21 + locationsOffset), value);
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
                            && (locationReferences.Count < 22))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 22);
                }
                expectedLocationsCount = 22;
                if (((locationReferences[(offset + 0)].Name != "individualCustomerId") 
                            || (locationReferences[(offset + 0)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "Antiguedad") 
                            || (locationReferences[(offset + 1)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 2)].Name != "ListaRestricciones") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "PorcentajePagoInicial") 
                            || (locationReferences[(offset + 3)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "CargosAnticipados") 
                            || (locationReferences[(offset + 4)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 5)].Name != "CupoUtilizado") 
                            || (locationReferences[(offset + 5)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "uri") 
                            || (locationReferences[(offset + 6)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 7)].Name != "internalBureauResponse") 
                            || (locationReferences[(offset + 7)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 8)].Name != "srCustomerProductsRequest") 
                            || (locationReferences[(offset + 8)].Type != typeof(AmxPeruPSBActivities.Model.EOC.SRRetrieveProductRequestModel)))) {
                    return false;
                }
                if (((locationReferences[(offset + 9)].Name != "EvaluacionListas") 
                            || (locationReferences[(offset + 9)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 10)].Name != "OrdenesLealtadFidelizacion") 
                            || (locationReferences[(offset + 10)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 11)].Name != "CupoTotal") 
                            || (locationReferences[(offset + 11)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 12)].Name != "EvalucacionMora") 
                            || (locationReferences[(offset + 12)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 13)].Name != "srCustomerProductsResponse") 
                            || (locationReferences[(offset + 13)].Type != typeof(System.Collections.Generic.List<AmxPeruPSBActivities.Model.EOC.SRProductResponseModel>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 14)].Name != "response") 
                            || (locationReferences[(offset + 14)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 15)].Name != "ProductosRecurrentes") 
                            || (locationReferences[(offset + 15)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 16)].Name != "AplicaCargar1aFactura") 
                            || (locationReferences[(offset + 16)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 17)].Name != "RequiereVisitaDomiciliaria") 
                            || (locationReferences[(offset + 17)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 18)].Name != "CupoFinaciamiento") 
                            || (locationReferences[(offset + 18)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 19)].Name != "ComportamientoPago") 
                            || (locationReferences[(offset + 19)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 20)].Name != "CupoDisponible") 
                            || (locationReferences[(offset + 20)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 21)].Name != "CantidadLineas") 
                            || (locationReferences[(offset + 21)].Type != typeof(string)))) {
                    return false;
                }
                return AmxCoBureau_TypedDataContext0.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxCoBureau_TypedDataContext1_ForReadOnly : AmxCoBureau_TypedDataContext0_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxCoBureau_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxCoBureau_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxCoBureau_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string individualCustomerId {
                get {
                    return ((string)(this.GetVariableValue((0 + locationsOffset))));
                }
            }
            
            protected string Antiguedad {
                get {
                    return ((string)(this.GetVariableValue((1 + locationsOffset))));
                }
            }
            
            protected string ListaRestricciones {
                get {
                    return ((string)(this.GetVariableValue((2 + locationsOffset))));
                }
            }
            
            protected string PorcentajePagoInicial {
                get {
                    return ((string)(this.GetVariableValue((3 + locationsOffset))));
                }
            }
            
            protected string CargosAnticipados {
                get {
                    return ((string)(this.GetVariableValue((4 + locationsOffset))));
                }
            }
            
            protected string CupoUtilizado {
                get {
                    return ((string)(this.GetVariableValue((5 + locationsOffset))));
                }
            }
            
            protected string uri {
                get {
                    return ((string)(this.GetVariableValue((6 + locationsOffset))));
                }
            }
            
            protected string internalBureauResponse {
                get {
                    return ((string)(this.GetVariableValue((7 + locationsOffset))));
                }
            }
            
            protected AmxPeruPSBActivities.Model.EOC.SRRetrieveProductRequestModel srCustomerProductsRequest {
                get {
                    return ((AmxPeruPSBActivities.Model.EOC.SRRetrieveProductRequestModel)(this.GetVariableValue((8 + locationsOffset))));
                }
            }
            
            protected string EvaluacionListas {
                get {
                    return ((string)(this.GetVariableValue((9 + locationsOffset))));
                }
            }
            
            protected string OrdenesLealtadFidelizacion {
                get {
                    return ((string)(this.GetVariableValue((10 + locationsOffset))));
                }
            }
            
            protected string CupoTotal {
                get {
                    return ((string)(this.GetVariableValue((11 + locationsOffset))));
                }
            }
            
            protected string EvalucacionMora {
                get {
                    return ((string)(this.GetVariableValue((12 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.List<AmxPeruPSBActivities.Model.EOC.SRProductResponseModel> srCustomerProductsResponse {
                get {
                    return ((System.Collections.Generic.List<AmxPeruPSBActivities.Model.EOC.SRProductResponseModel>)(this.GetVariableValue((13 + locationsOffset))));
                }
            }
            
            protected string response {
                get {
                    return ((string)(this.GetVariableValue((14 + locationsOffset))));
                }
            }
            
            protected string ProductosRecurrentes {
                get {
                    return ((string)(this.GetVariableValue((15 + locationsOffset))));
                }
            }
            
            protected string AplicaCargar1aFactura {
                get {
                    return ((string)(this.GetVariableValue((16 + locationsOffset))));
                }
            }
            
            protected string RequiereVisitaDomiciliaria {
                get {
                    return ((string)(this.GetVariableValue((17 + locationsOffset))));
                }
            }
            
            protected string CupoFinaciamiento {
                get {
                    return ((string)(this.GetVariableValue((18 + locationsOffset))));
                }
            }
            
            protected string ComportamientoPago {
                get {
                    return ((string)(this.GetVariableValue((19 + locationsOffset))));
                }
            }
            
            protected string CupoDisponible {
                get {
                    return ((string)(this.GetVariableValue((20 + locationsOffset))));
                }
            }
            
            protected string CantidadLineas {
                get {
                    return ((string)(this.GetVariableValue((21 + locationsOffset))));
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
                            && (locationReferences.Count < 22))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 22);
                }
                expectedLocationsCount = 22;
                if (((locationReferences[(offset + 0)].Name != "individualCustomerId") 
                            || (locationReferences[(offset + 0)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "Antiguedad") 
                            || (locationReferences[(offset + 1)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 2)].Name != "ListaRestricciones") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "PorcentajePagoInicial") 
                            || (locationReferences[(offset + 3)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "CargosAnticipados") 
                            || (locationReferences[(offset + 4)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 5)].Name != "CupoUtilizado") 
                            || (locationReferences[(offset + 5)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "uri") 
                            || (locationReferences[(offset + 6)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 7)].Name != "internalBureauResponse") 
                            || (locationReferences[(offset + 7)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 8)].Name != "srCustomerProductsRequest") 
                            || (locationReferences[(offset + 8)].Type != typeof(AmxPeruPSBActivities.Model.EOC.SRRetrieveProductRequestModel)))) {
                    return false;
                }
                if (((locationReferences[(offset + 9)].Name != "EvaluacionListas") 
                            || (locationReferences[(offset + 9)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 10)].Name != "OrdenesLealtadFidelizacion") 
                            || (locationReferences[(offset + 10)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 11)].Name != "CupoTotal") 
                            || (locationReferences[(offset + 11)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 12)].Name != "EvalucacionMora") 
                            || (locationReferences[(offset + 12)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 13)].Name != "srCustomerProductsResponse") 
                            || (locationReferences[(offset + 13)].Type != typeof(System.Collections.Generic.List<AmxPeruPSBActivities.Model.EOC.SRProductResponseModel>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 14)].Name != "response") 
                            || (locationReferences[(offset + 14)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 15)].Name != "ProductosRecurrentes") 
                            || (locationReferences[(offset + 15)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 16)].Name != "AplicaCargar1aFactura") 
                            || (locationReferences[(offset + 16)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 17)].Name != "RequiereVisitaDomiciliaria") 
                            || (locationReferences[(offset + 17)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 18)].Name != "CupoFinaciamiento") 
                            || (locationReferences[(offset + 18)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 19)].Name != "ComportamientoPago") 
                            || (locationReferences[(offset + 19)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 20)].Name != "CupoDisponible") 
                            || (locationReferences[(offset + 20)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 21)].Name != "CantidadLineas") 
                            || (locationReferences[(offset + 21)].Type != typeof(string)))) {
                    return false;
                }
                return AmxCoBureau_TypedDataContext0_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxCoBureau_TypedDataContext2 : AmxCoBureau_TypedDataContext1 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxCoBureau_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxCoBureau_TypedDataContext2(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxCoBureau_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string connectionString {
                get {
                    return ((string)(this.GetVariableValue((22 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((22 + locationsOffset), value);
                }
            }
            
            protected string bureauEndpoint {
                get {
                    return ((string)(this.GetVariableValue((23 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((23 + locationsOffset), value);
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
                
                #line 104 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
              connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr0Get() {
                
                #line 104 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
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
                
                #line 104 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                
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
                
                #line 115 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                      bureauEndpoint;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr2Get() {
                
                #line 115 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                return 
                      bureauEndpoint;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr2Get() {
                this.GetValueTypeValues();
                return this.@__Expr2Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr2Set(string value) {
                
                #line 115 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                
                      bureauEndpoint = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr2Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr2Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr3GetTree() {
                
                #line 122 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                      response;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr3Get() {
                
                #line 122 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                return 
                      response;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr3Get() {
                this.GetValueTypeValues();
                return this.@__Expr3Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr3Set(string value) {
                
                #line 122 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                
                      response = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr3Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr3Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr6GetTree() {
                
                #line 127 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                      CupoTotal;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr6Get() {
                
                #line 127 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                return 
                      CupoTotal;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr6Get() {
                this.GetValueTypeValues();
                return this.@__Expr6Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr6Set(string value) {
                
                #line 127 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                
                      CupoTotal = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr6Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr6Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr11GetTree() {
                
                #line 170 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<AmxPeruPSBActivities.Model.EOC.SRProductResponseModel>>> expression = () => 
                              srCustomerProductsResponse;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.EOC.SRProductResponseModel> @__Expr11Get() {
                
                #line 170 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                return 
                              srCustomerProductsResponse;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.EOC.SRProductResponseModel> ValueType___Expr11Get() {
                this.GetValueTypeValues();
                return this.@__Expr11Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr11Set(System.Collections.Generic.List<AmxPeruPSBActivities.Model.EOC.SRProductResponseModel> value) {
                
                #line 170 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                
                              srCustomerProductsResponse = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr11Set(System.Collections.Generic.List<AmxPeruPSBActivities.Model.EOC.SRProductResponseModel> value) {
                this.GetValueTypeValues();
                this.@__Expr11Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr14GetTree() {
                
                #line 182 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                              Antiguedad;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr14Get() {
                
                #line 182 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                return 
                              Antiguedad;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr14Get() {
                this.GetValueTypeValues();
                return this.@__Expr14Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr14Set(string value) {
                
                #line 182 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                
                              Antiguedad = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr14Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr14Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr16GetTree() {
                
                #line 202 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                              internalBureauResponse;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr16Get() {
                
                #line 202 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                return 
                              internalBureauResponse;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr16Get() {
                this.GetValueTypeValues();
                return this.@__Expr16Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr16Set(string value) {
                
                #line 202 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                
                              internalBureauResponse = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr16Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr16Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr17GetTree() {
                
                #line 192 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                              CupoTotal;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr17Get() {
                
                #line 192 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                return 
                              CupoTotal;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr17Get() {
                this.GetValueTypeValues();
                return this.@__Expr17Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr17Set(string value) {
                
                #line 192 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                
                              CupoTotal = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr17Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr17Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr18GetTree() {
                
                #line 187 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                              CantidadLineas;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr18Get() {
                
                #line 187 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                return 
                              CantidadLineas;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr18Get() {
                this.GetValueTypeValues();
                return this.@__Expr18Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr18Set(string value) {
                
                #line 187 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                
                              CantidadLineas = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr18Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr18Set(value);
                this.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 24))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 24);
                }
                expectedLocationsCount = 24;
                if (((locationReferences[(offset + 22)].Name != "connectionString") 
                            || (locationReferences[(offset + 22)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 23)].Name != "bureauEndpoint") 
                            || (locationReferences[(offset + 23)].Type != typeof(string)))) {
                    return false;
                }
                return AmxCoBureau_TypedDataContext1.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxCoBureau_TypedDataContext2_ForReadOnly : AmxCoBureau_TypedDataContext1_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxCoBureau_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxCoBureau_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxCoBureau_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string connectionString {
                get {
                    return ((string)(this.GetVariableValue((22 + locationsOffset))));
                }
            }
            
            protected string bureauEndpoint {
                get {
                    return ((string)(this.GetVariableValue((23 + locationsOffset))));
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
                
                #line 144 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr1Get() {
                
                #line 144 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                return 
                  connectionString;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr1Get() {
                this.GetValueTypeValues();
                return this.@__Expr1Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr4GetTree() {
                
                #line 137 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                      individualCustomerId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr4Get() {
                
                #line 137 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                return 
                      individualCustomerId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr4Get() {
                this.GetValueTypeValues();
                return this.@__Expr4Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr5GetTree() {
                
                #line 132 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                      bureauEndpoint;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr5Get() {
                
                #line 132 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                return 
                      bureauEndpoint;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr5Get() {
                this.GetValueTypeValues();
                return this.@__Expr5Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr7GetTree() {
                
                #line 151 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                  response == "Credit Profile created." || response == "Credit Profile still valid.";
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr7Get() {
                
                #line 151 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                return 
                  response == "Credit Profile created." || response == "Credit Profile still valid.";
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr7Get() {
                this.GetValueTypeValues();
                return this.@__Expr7Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr8GetTree() {
                
                #line 214 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                          connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr8Get() {
                
                #line 214 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                return 
                          connectionString;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr8Get() {
                this.GetValueTypeValues();
                return this.@__Expr8Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr9GetTree() {
                
                #line 165 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.EOC.SRRetrieveProductRequestModel>> expression = () => 
                              srCustomerProductsRequest;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.EOC.SRRetrieveProductRequestModel @__Expr9Get() {
                
                #line 165 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                return 
                              srCustomerProductsRequest;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.EOC.SRRetrieveProductRequestModel ValueType___Expr9Get() {
                this.GetValueTypeValues();
                return this.@__Expr9Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr10GetTree() {
                
                #line 160 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                System.Linq.Expressions.Expression<System.Func<Ericsson.PSB.Workflow.Client.Core.Serializer.JsonSettings>> expression = () => 
                              Ericsson.PSB.Workflow.Client.Core.Serializer.JsonSettings.Custom;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Ericsson.PSB.Workflow.Client.Core.Serializer.JsonSettings @__Expr10Get() {
                
                #line 160 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                return 
                              Ericsson.PSB.Workflow.Client.Core.Serializer.JsonSettings.Custom;
                
                #line default
                #line hidden
            }
            
            public Ericsson.PSB.Workflow.Client.Core.Serializer.JsonSettings ValueType___Expr10Get() {
                this.GetValueTypeValues();
                return this.@__Expr10Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr12GetTree() {
                
                #line 175 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                              uri;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr12Get() {
                
                #line 175 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                return 
                              uri;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr12Get() {
                this.GetValueTypeValues();
                return this.@__Expr12Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr13GetTree() {
                
                #line 197 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                              individualCustomerId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr13Get() {
                
                #line 197 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                return 
                              individualCustomerId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr13Get() {
                this.GetValueTypeValues();
                return this.@__Expr13Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr15GetTree() {
                
                #line 207 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<AmxPeruPSBActivities.Model.EOC.SRProductResponseModel>>> expression = () => 
                              srCustomerProductsResponse;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.EOC.SRProductResponseModel> @__Expr15Get() {
                
                #line 207 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\CLAROESB\AMXCOBUREAU.XAML"
                return 
                              srCustomerProductsResponse;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.EOC.SRProductResponseModel> ValueType___Expr15Get() {
                this.GetValueTypeValues();
                return this.@__Expr15Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 24))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 24);
                }
                expectedLocationsCount = 24;
                if (((locationReferences[(offset + 22)].Name != "connectionString") 
                            || (locationReferences[(offset + 22)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 23)].Name != "bureauEndpoint") 
                            || (locationReferences[(offset + 23)].Type != typeof(string)))) {
                    return false;
                }
                return AmxCoBureau_TypedDataContext1_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
    }
}

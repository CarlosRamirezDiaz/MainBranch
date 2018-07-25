namespace AmxPeruPSBWorkflows {
    
    #line 26 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\GetAvailableOfferingConfiguration.xaml"
    using System;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\GetAvailableOfferingConfiguration.xaml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 27 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\GetAvailableOfferingConfiguration.xaml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\GetAvailableOfferingConfiguration.xaml"
    using System.Activities;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\GetAvailableOfferingConfiguration.xaml"
    using System.Activities.Expressions;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\GetAvailableOfferingConfiguration.xaml"
    using System.Activities.Statements;
    
    #line default
    #line hidden
    
    #line 28 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\GetAvailableOfferingConfiguration.xaml"
    using System.Data;
    
    #line default
    #line hidden
    
    #line 29 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\GetAvailableOfferingConfiguration.xaml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 30 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\GetAvailableOfferingConfiguration.xaml"
    using System.Text;
    
    #line default
    #line hidden
    
    #line 31 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\GetAvailableOfferingConfiguration.xaml"
    using Microsoft.Xrm.Sdk;
    
    #line default
    #line hidden
    
    #line 32 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\GetAvailableOfferingConfiguration.xaml"
    using Ericsson.ETELCRM.Entities.Crm.CustomEntities;
    
    #line default
    #line hidden
    
    #line 33 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\GetAvailableOfferingConfiguration.xaml"
    using AmxPeruPSBActivities.Model;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\GetAvailableOfferingConfiguration.xaml"
    using System.Activities.XamlIntegration;
    
    #line default
    #line hidden
    
    
    public partial class GetAvailableOfferingConfiguration : System.Activities.XamlIntegration.ICompiledExpressionRoot {
        
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
                this.dataContextActivities = GetAvailableOfferingConfiguration_TypedDataContext2.GetDataContextActivitiesHelper(this.rootActivity, this.forImplementation);
            }
            if ((expressionId == 0)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = GetAvailableOfferingConfiguration_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new GetAvailableOfferingConfiguration_TypedDataContext2(locations, activityContext, true);
                }
                GetAvailableOfferingConfiguration_TypedDataContext2 refDataContext0 = ((GetAvailableOfferingConfiguration_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 1)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext1 = ((GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = GetAvailableOfferingConfiguration_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new GetAvailableOfferingConfiguration_TypedDataContext2(locations, activityContext, true);
                }
                GetAvailableOfferingConfiguration_TypedDataContext2 refDataContext2 = ((GetAvailableOfferingConfiguration_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext2.GetLocation<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>>(refDataContext2.ValueType___Expr2Get, refDataContext2.ValueType___Expr2Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 3)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = GetAvailableOfferingConfiguration_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new GetAvailableOfferingConfiguration_TypedDataContext2(locations, activityContext, true);
                }
                GetAvailableOfferingConfiguration_TypedDataContext2 refDataContext3 = ((GetAvailableOfferingConfiguration_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext3.GetLocation<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>>(refDataContext3.ValueType___Expr3Get, refDataContext3.ValueType___Expr3Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 4)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = GetAvailableOfferingConfiguration_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new GetAvailableOfferingConfiguration_TypedDataContext2(locations, activityContext, true);
                }
                GetAvailableOfferingConfiguration_TypedDataContext2 refDataContext4 = ((GetAvailableOfferingConfiguration_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext4.GetLocation<Microsoft.Xrm.Sdk.EntityCollection>(refDataContext4.ValueType___Expr4Get, refDataContext4.ValueType___Expr4Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 5)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = GetAvailableOfferingConfiguration_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new GetAvailableOfferingConfiguration_TypedDataContext2(locations, activityContext, true);
                }
                GetAvailableOfferingConfiguration_TypedDataContext2 refDataContext5 = ((GetAvailableOfferingConfiguration_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext5.GetLocation<Microsoft.Xrm.Sdk.EntityCollection>(refDataContext5.ValueType___Expr5Get, refDataContext5.ValueType___Expr5Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 6)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = GetAvailableOfferingConfiguration_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new GetAvailableOfferingConfiguration_TypedDataContext2(locations, activityContext, true);
                }
                GetAvailableOfferingConfiguration_TypedDataContext2 refDataContext6 = ((GetAvailableOfferingConfiguration_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext6.GetLocation<Microsoft.Xrm.Sdk.EntityCollection>(refDataContext6.ValueType___Expr6Get, refDataContext6.ValueType___Expr6Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 7)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext7 = ((GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = GetAvailableOfferingConfiguration_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new GetAvailableOfferingConfiguration_TypedDataContext2(locations, activityContext, true);
                }
                GetAvailableOfferingConfiguration_TypedDataContext2 refDataContext8 = ((GetAvailableOfferingConfiguration_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext8.GetLocation<System.Collections.Generic.List<AmxPeruPSBActivities.Model.ProductOfferingConfigurationPriceModel>>(refDataContext8.ValueType___Expr8Get, refDataContext8.ValueType___Expr8Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 9)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext9 = ((GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext9.ValueType___Expr9Get();
            }
            if ((expressionId == 10)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext10 = ((GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext11 = ((GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext11.ValueType___Expr11Get();
            }
            if ((expressionId == 12)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext12 = ((GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext12.ValueType___Expr12Get();
            }
            if ((expressionId == 13)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext13 = ((GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext13.ValueType___Expr13Get();
            }
            if ((expressionId == 14)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext14 = ((GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext14.ValueType___Expr14Get();
            }
            if ((expressionId == 15)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = GetAvailableOfferingConfiguration_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new GetAvailableOfferingConfiguration_TypedDataContext2(locations, activityContext, true);
                }
                GetAvailableOfferingConfiguration_TypedDataContext2 refDataContext15 = ((GetAvailableOfferingConfiguration_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext15.GetLocation<System.Collections.Generic.List<AmxPeruPSBActivities.Model.ProductOfferingConfigurationPriceModel>>(refDataContext15.ValueType___Expr15Get, refDataContext15.ValueType___Expr15Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 16)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext16 = ((GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext16.ValueType___Expr16Get();
            }
            if ((expressionId == 17)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext17 = ((GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext17.ValueType___Expr17Get();
            }
            if ((expressionId == 18)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext18 = ((GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext18.ValueType___Expr18Get();
            }
            if ((expressionId == 19)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext19 = ((GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext19.ValueType___Expr19Get();
            }
            if ((expressionId == 20)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext20 = ((GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext20.ValueType___Expr20Get();
            }
            if ((expressionId == 21)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 2);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext21 = ((GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext21.ValueType___Expr21Get();
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
                GetAvailableOfferingConfiguration_TypedDataContext2 refDataContext0 = new GetAvailableOfferingConfiguration_TypedDataContext2(locations, true);
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set);
            }
            if ((expressionId == 1)) {
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext1 = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                GetAvailableOfferingConfiguration_TypedDataContext2 refDataContext2 = new GetAvailableOfferingConfiguration_TypedDataContext2(locations, true);
                return refDataContext2.GetLocation<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>>(refDataContext2.ValueType___Expr2Get, refDataContext2.ValueType___Expr2Set);
            }
            if ((expressionId == 3)) {
                GetAvailableOfferingConfiguration_TypedDataContext2 refDataContext3 = new GetAvailableOfferingConfiguration_TypedDataContext2(locations, true);
                return refDataContext3.GetLocation<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>>(refDataContext3.ValueType___Expr3Get, refDataContext3.ValueType___Expr3Set);
            }
            if ((expressionId == 4)) {
                GetAvailableOfferingConfiguration_TypedDataContext2 refDataContext4 = new GetAvailableOfferingConfiguration_TypedDataContext2(locations, true);
                return refDataContext4.GetLocation<Microsoft.Xrm.Sdk.EntityCollection>(refDataContext4.ValueType___Expr4Get, refDataContext4.ValueType___Expr4Set);
            }
            if ((expressionId == 5)) {
                GetAvailableOfferingConfiguration_TypedDataContext2 refDataContext5 = new GetAvailableOfferingConfiguration_TypedDataContext2(locations, true);
                return refDataContext5.GetLocation<Microsoft.Xrm.Sdk.EntityCollection>(refDataContext5.ValueType___Expr5Get, refDataContext5.ValueType___Expr5Set);
            }
            if ((expressionId == 6)) {
                GetAvailableOfferingConfiguration_TypedDataContext2 refDataContext6 = new GetAvailableOfferingConfiguration_TypedDataContext2(locations, true);
                return refDataContext6.GetLocation<Microsoft.Xrm.Sdk.EntityCollection>(refDataContext6.ValueType___Expr6Get, refDataContext6.ValueType___Expr6Set);
            }
            if ((expressionId == 7)) {
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext7 = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                GetAvailableOfferingConfiguration_TypedDataContext2 refDataContext8 = new GetAvailableOfferingConfiguration_TypedDataContext2(locations, true);
                return refDataContext8.GetLocation<System.Collections.Generic.List<AmxPeruPSBActivities.Model.ProductOfferingConfigurationPriceModel>>(refDataContext8.ValueType___Expr8Get, refDataContext8.ValueType___Expr8Set);
            }
            if ((expressionId == 9)) {
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext9 = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext9.ValueType___Expr9Get();
            }
            if ((expressionId == 10)) {
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext10 = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext11 = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext11.ValueType___Expr11Get();
            }
            if ((expressionId == 12)) {
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext12 = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext12.ValueType___Expr12Get();
            }
            if ((expressionId == 13)) {
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext13 = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext13.ValueType___Expr13Get();
            }
            if ((expressionId == 14)) {
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext14 = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext14.ValueType___Expr14Get();
            }
            if ((expressionId == 15)) {
                GetAvailableOfferingConfiguration_TypedDataContext2 refDataContext15 = new GetAvailableOfferingConfiguration_TypedDataContext2(locations, true);
                return refDataContext15.GetLocation<System.Collections.Generic.List<AmxPeruPSBActivities.Model.ProductOfferingConfigurationPriceModel>>(refDataContext15.ValueType___Expr15Get, refDataContext15.ValueType___Expr15Set);
            }
            if ((expressionId == 16)) {
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext16 = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext16.ValueType___Expr16Get();
            }
            if ((expressionId == 17)) {
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext17 = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext17.ValueType___Expr17Get();
            }
            if ((expressionId == 18)) {
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext18 = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext18.ValueType___Expr18Get();
            }
            if ((expressionId == 19)) {
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext19 = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext19.ValueType___Expr19Get();
            }
            if ((expressionId == 20)) {
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext20 = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext20.ValueType___Expr20Get();
            }
            if ((expressionId == 21)) {
                GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly valDataContext21 = new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext21.ValueType___Expr21Get();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool CanExecuteExpression(string expressionText, bool isReference, System.Collections.Generic.IList<System.Activities.LocationReference> locations, out int expressionId) {
            if (((isReference == true) 
                        && ((expressionText == "connectionString") 
                        && (GetAvailableOfferingConfiguration_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 0;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "connectionString") 
                        && (GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 1;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "priceTypeCodeList") 
                        && (GetAvailableOfferingConfiguration_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 2;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "pricePeriodCodeList") 
                        && (GetAvailableOfferingConfiguration_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 3;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "availabilityOfferingConfiguration") 
                        && (GetAvailableOfferingConfiguration_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 4;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "offeringPriceConfiguration") 
                        && (GetAvailableOfferingConfiguration_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 5;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "offeringPrices") 
                        && (GetAvailableOfferingConfiguration_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 6;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "availableOfferingInputModel.OfferTypeCode == \"Basic\"") 
                        && (GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 7;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "responseModel") 
                        && (GetAvailableOfferingConfiguration_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 8;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "offeringPrices") 
                        && (GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 9;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "availableOfferingInputModel") 
                        && (GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 10;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "priceTypeCodeList") 
                        && (GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 11;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "pricePeriodCodeList") 
                        && (GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 12;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "offeringPriceConfiguration") 
                        && (GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 13;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "availabilityOfferingConfiguration") 
                        && (GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 14;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "responseModel") 
                        && (GetAvailableOfferingConfiguration_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 15;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "offeringPrices") 
                        && (GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 16;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "availableOfferingInputModel") 
                        && (GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 17;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "priceTypeCodeList") 
                        && (GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 18;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "pricePeriodCodeList") 
                        && (GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 19;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "offeringPriceConfiguration") 
                        && (GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 20;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "availabilityOfferingConfiguration") 
                        && (GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 21;
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
                return new GetAvailableOfferingConfiguration_TypedDataContext2(locationReferences).@__Expr0GetTree();
            }
            if ((expressionId == 1)) {
                return new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locationReferences).@__Expr1GetTree();
            }
            if ((expressionId == 2)) {
                return new GetAvailableOfferingConfiguration_TypedDataContext2(locationReferences).@__Expr2GetTree();
            }
            if ((expressionId == 3)) {
                return new GetAvailableOfferingConfiguration_TypedDataContext2(locationReferences).@__Expr3GetTree();
            }
            if ((expressionId == 4)) {
                return new GetAvailableOfferingConfiguration_TypedDataContext2(locationReferences).@__Expr4GetTree();
            }
            if ((expressionId == 5)) {
                return new GetAvailableOfferingConfiguration_TypedDataContext2(locationReferences).@__Expr5GetTree();
            }
            if ((expressionId == 6)) {
                return new GetAvailableOfferingConfiguration_TypedDataContext2(locationReferences).@__Expr6GetTree();
            }
            if ((expressionId == 7)) {
                return new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locationReferences).@__Expr7GetTree();
            }
            if ((expressionId == 8)) {
                return new GetAvailableOfferingConfiguration_TypedDataContext2(locationReferences).@__Expr8GetTree();
            }
            if ((expressionId == 9)) {
                return new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locationReferences).@__Expr9GetTree();
            }
            if ((expressionId == 10)) {
                return new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locationReferences).@__Expr10GetTree();
            }
            if ((expressionId == 11)) {
                return new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locationReferences).@__Expr11GetTree();
            }
            if ((expressionId == 12)) {
                return new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locationReferences).@__Expr12GetTree();
            }
            if ((expressionId == 13)) {
                return new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locationReferences).@__Expr13GetTree();
            }
            if ((expressionId == 14)) {
                return new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locationReferences).@__Expr14GetTree();
            }
            if ((expressionId == 15)) {
                return new GetAvailableOfferingConfiguration_TypedDataContext2(locationReferences).@__Expr15GetTree();
            }
            if ((expressionId == 16)) {
                return new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locationReferences).@__Expr16GetTree();
            }
            if ((expressionId == 17)) {
                return new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locationReferences).@__Expr17GetTree();
            }
            if ((expressionId == 18)) {
                return new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locationReferences).@__Expr18GetTree();
            }
            if ((expressionId == 19)) {
                return new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locationReferences).@__Expr19GetTree();
            }
            if ((expressionId == 20)) {
                return new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locationReferences).@__Expr20GetTree();
            }
            if ((expressionId == 21)) {
                return new GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(locationReferences).@__Expr21GetTree();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class GetAvailableOfferingConfiguration_TypedDataContext0 : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public GetAvailableOfferingConfiguration_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public GetAvailableOfferingConfiguration_TypedDataContext0(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public GetAvailableOfferingConfiguration_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class GetAvailableOfferingConfiguration_TypedDataContext0_ForReadOnly : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public GetAvailableOfferingConfiguration_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public GetAvailableOfferingConfiguration_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public GetAvailableOfferingConfiguration_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class GetAvailableOfferingConfiguration_TypedDataContext1 : GetAvailableOfferingConfiguration_TypedDataContext0 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public GetAvailableOfferingConfiguration_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public GetAvailableOfferingConfiguration_TypedDataContext1(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public GetAvailableOfferingConfiguration_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected AmxPeruPSBActivities.Model.AvailableOfferingInputModel availableOfferingInputModel {
                get {
                    return ((AmxPeruPSBActivities.Model.AvailableOfferingInputModel)(this.GetVariableValue((0 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((0 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.List<AmxPeruPSBActivities.Model.ProductOfferingConfigurationPriceModel> responseModel {
                get {
                    return ((System.Collections.Generic.List<AmxPeruPSBActivities.Model.ProductOfferingConfigurationPriceModel>)(this.GetVariableValue((1 + locationsOffset))));
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
                if (((locationReferences[(offset + 0)].Name != "availableOfferingInputModel") 
                            || (locationReferences[(offset + 0)].Type != typeof(AmxPeruPSBActivities.Model.AvailableOfferingInputModel)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "responseModel") 
                            || (locationReferences[(offset + 1)].Type != typeof(System.Collections.Generic.List<AmxPeruPSBActivities.Model.ProductOfferingConfigurationPriceModel>)))) {
                    return false;
                }
                return GetAvailableOfferingConfiguration_TypedDataContext0.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class GetAvailableOfferingConfiguration_TypedDataContext1_ForReadOnly : GetAvailableOfferingConfiguration_TypedDataContext0_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public GetAvailableOfferingConfiguration_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public GetAvailableOfferingConfiguration_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public GetAvailableOfferingConfiguration_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected AmxPeruPSBActivities.Model.AvailableOfferingInputModel availableOfferingInputModel {
                get {
                    return ((AmxPeruPSBActivities.Model.AvailableOfferingInputModel)(this.GetVariableValue((0 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.List<AmxPeruPSBActivities.Model.ProductOfferingConfigurationPriceModel> responseModel {
                get {
                    return ((System.Collections.Generic.List<AmxPeruPSBActivities.Model.ProductOfferingConfigurationPriceModel>)(this.GetVariableValue((1 + locationsOffset))));
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
                if (((locationReferences[(offset + 0)].Name != "availableOfferingInputModel") 
                            || (locationReferences[(offset + 0)].Type != typeof(AmxPeruPSBActivities.Model.AvailableOfferingInputModel)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "responseModel") 
                            || (locationReferences[(offset + 1)].Type != typeof(System.Collections.Generic.List<AmxPeruPSBActivities.Model.ProductOfferingConfigurationPriceModel>)))) {
                    return false;
                }
                return GetAvailableOfferingConfiguration_TypedDataContext0_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class GetAvailableOfferingConfiguration_TypedDataContext2 : GetAvailableOfferingConfiguration_TypedDataContext1 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public GetAvailableOfferingConfiguration_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public GetAvailableOfferingConfiguration_TypedDataContext2(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public GetAvailableOfferingConfiguration_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
            
            protected Microsoft.Xrm.Sdk.EntityCollection availabilityOfferingConfiguration {
                get {
                    return ((Microsoft.Xrm.Sdk.EntityCollection)(this.GetVariableValue((3 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((3 + locationsOffset), value);
                }
            }
            
            protected Microsoft.Xrm.Sdk.EntityCollection offeringPriceConfiguration {
                get {
                    return ((Microsoft.Xrm.Sdk.EntityCollection)(this.GetVariableValue((4 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((4 + locationsOffset), value);
                }
            }
            
            protected Microsoft.Xrm.Sdk.EntityCollection offeringPrices {
                get {
                    return ((Microsoft.Xrm.Sdk.EntityCollection)(this.GetVariableValue((5 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((5 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> priceTypeCodeList {
                get {
                    return ((System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>)(this.GetVariableValue((6 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((6 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> pricePeriodCodeList {
                get {
                    return ((System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>)(this.GetVariableValue((7 + locationsOffset))));
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
                
                #line 86 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
              connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr0Get() {
                
                #line 86 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
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
                
                #line 86 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                
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
                
                #line 97 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>>> expression = () => 
                      priceTypeCodeList;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> @__Expr2Get() {
                
                #line 97 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                return 
                      priceTypeCodeList;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> ValueType___Expr2Get() {
                this.GetValueTypeValues();
                return this.@__Expr2Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr2Set(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> value) {
                
                #line 97 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                
                      priceTypeCodeList = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr2Set(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> value) {
                this.GetValueTypeValues();
                this.@__Expr2Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr3GetTree() {
                
                #line 104 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>>> expression = () => 
                      pricePeriodCodeList;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> @__Expr3Get() {
                
                #line 104 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                return 
                      pricePeriodCodeList;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> ValueType___Expr3Get() {
                this.GetValueTypeValues();
                return this.@__Expr3Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr3Set(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> value) {
                
                #line 104 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                
                      pricePeriodCodeList = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr3Set(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> value) {
                this.GetValueTypeValues();
                this.@__Expr3Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr4GetTree() {
                
                #line 111 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                System.Linq.Expressions.Expression<System.Func<Microsoft.Xrm.Sdk.EntityCollection>> expression = () => 
                      availabilityOfferingConfiguration;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Microsoft.Xrm.Sdk.EntityCollection @__Expr4Get() {
                
                #line 111 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                return 
                      availabilityOfferingConfiguration;
                
                #line default
                #line hidden
            }
            
            public Microsoft.Xrm.Sdk.EntityCollection ValueType___Expr4Get() {
                this.GetValueTypeValues();
                return this.@__Expr4Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr4Set(Microsoft.Xrm.Sdk.EntityCollection value) {
                
                #line 111 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                
                      availabilityOfferingConfiguration = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr4Set(Microsoft.Xrm.Sdk.EntityCollection value) {
                this.GetValueTypeValues();
                this.@__Expr4Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr5GetTree() {
                
                #line 118 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                System.Linq.Expressions.Expression<System.Func<Microsoft.Xrm.Sdk.EntityCollection>> expression = () => 
                      offeringPriceConfiguration;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Microsoft.Xrm.Sdk.EntityCollection @__Expr5Get() {
                
                #line 118 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                return 
                      offeringPriceConfiguration;
                
                #line default
                #line hidden
            }
            
            public Microsoft.Xrm.Sdk.EntityCollection ValueType___Expr5Get() {
                this.GetValueTypeValues();
                return this.@__Expr5Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr5Set(Microsoft.Xrm.Sdk.EntityCollection value) {
                
                #line 118 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                
                      offeringPriceConfiguration = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr5Set(Microsoft.Xrm.Sdk.EntityCollection value) {
                this.GetValueTypeValues();
                this.@__Expr5Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr6GetTree() {
                
                #line 125 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                System.Linq.Expressions.Expression<System.Func<Microsoft.Xrm.Sdk.EntityCollection>> expression = () => 
                      offeringPrices;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Microsoft.Xrm.Sdk.EntityCollection @__Expr6Get() {
                
                #line 125 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                return 
                      offeringPrices;
                
                #line default
                #line hidden
            }
            
            public Microsoft.Xrm.Sdk.EntityCollection ValueType___Expr6Get() {
                this.GetValueTypeValues();
                return this.@__Expr6Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr6Set(Microsoft.Xrm.Sdk.EntityCollection value) {
                
                #line 125 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                
                      offeringPrices = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr6Set(Microsoft.Xrm.Sdk.EntityCollection value) {
                this.GetValueTypeValues();
                this.@__Expr6Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr8GetTree() {
                
                #line 169 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<AmxPeruPSBActivities.Model.ProductOfferingConfigurationPriceModel>>> expression = () => 
                          responseModel;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.ProductOfferingConfigurationPriceModel> @__Expr8Get() {
                
                #line 169 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                return 
                          responseModel;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.ProductOfferingConfigurationPriceModel> ValueType___Expr8Get() {
                this.GetValueTypeValues();
                return this.@__Expr8Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr8Set(System.Collections.Generic.List<AmxPeruPSBActivities.Model.ProductOfferingConfigurationPriceModel> value) {
                
                #line 169 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                
                          responseModel = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr8Set(System.Collections.Generic.List<AmxPeruPSBActivities.Model.ProductOfferingConfigurationPriceModel> value) {
                this.GetValueTypeValues();
                this.@__Expr8Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr15GetTree() {
                
                #line 208 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<AmxPeruPSBActivities.Model.ProductOfferingConfigurationPriceModel>>> expression = () => 
                          responseModel;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.ProductOfferingConfigurationPriceModel> @__Expr15Get() {
                
                #line 208 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                return 
                          responseModel;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.ProductOfferingConfigurationPriceModel> ValueType___Expr15Get() {
                this.GetValueTypeValues();
                return this.@__Expr15Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr15Set(System.Collections.Generic.List<AmxPeruPSBActivities.Model.ProductOfferingConfigurationPriceModel> value) {
                
                #line 208 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                
                          responseModel = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr15Set(System.Collections.Generic.List<AmxPeruPSBActivities.Model.ProductOfferingConfigurationPriceModel> value) {
                this.GetValueTypeValues();
                this.@__Expr15Set(value);
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
                if (((locationReferences[(offset + 2)].Name != "connectionString") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "availabilityOfferingConfiguration") 
                            || (locationReferences[(offset + 3)].Type != typeof(Microsoft.Xrm.Sdk.EntityCollection)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "offeringPriceConfiguration") 
                            || (locationReferences[(offset + 4)].Type != typeof(Microsoft.Xrm.Sdk.EntityCollection)))) {
                    return false;
                }
                if (((locationReferences[(offset + 5)].Name != "offeringPrices") 
                            || (locationReferences[(offset + 5)].Type != typeof(Microsoft.Xrm.Sdk.EntityCollection)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "priceTypeCodeList") 
                            || (locationReferences[(offset + 6)].Type != typeof(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 7)].Name != "pricePeriodCodeList") 
                            || (locationReferences[(offset + 7)].Type != typeof(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>)))) {
                    return false;
                }
                return GetAvailableOfferingConfiguration_TypedDataContext1.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly : GetAvailableOfferingConfiguration_TypedDataContext1_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public GetAvailableOfferingConfiguration_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string connectionString {
                get {
                    return ((string)(this.GetVariableValue((2 + locationsOffset))));
                }
            }
            
            protected Microsoft.Xrm.Sdk.EntityCollection availabilityOfferingConfiguration {
                get {
                    return ((Microsoft.Xrm.Sdk.EntityCollection)(this.GetVariableValue((3 + locationsOffset))));
                }
            }
            
            protected Microsoft.Xrm.Sdk.EntityCollection offeringPriceConfiguration {
                get {
                    return ((Microsoft.Xrm.Sdk.EntityCollection)(this.GetVariableValue((4 + locationsOffset))));
                }
            }
            
            protected Microsoft.Xrm.Sdk.EntityCollection offeringPrices {
                get {
                    return ((Microsoft.Xrm.Sdk.EntityCollection)(this.GetVariableValue((5 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> priceTypeCodeList {
                get {
                    return ((System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>)(this.GetVariableValue((6 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> pricePeriodCodeList {
                get {
                    return ((System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>)(this.GetVariableValue((7 + locationsOffset))));
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
                
                #line 217 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr1Get() {
                
                #line 217 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                return 
                  connectionString;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr1Get() {
                this.GetValueTypeValues();
                return this.@__Expr1Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr7GetTree() {
                
                #line 132 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                      availableOfferingInputModel.OfferTypeCode == "Basic";
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr7Get() {
                
                #line 132 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                return 
                      availableOfferingInputModel.OfferTypeCode == "Basic";
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr7Get() {
                this.GetValueTypeValues();
                return this.@__Expr7Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr9GetTree() {
                
                #line 154 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                System.Linq.Expressions.Expression<System.Func<Microsoft.Xrm.Sdk.EntityCollection>> expression = () => 
                          offeringPrices;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Microsoft.Xrm.Sdk.EntityCollection @__Expr9Get() {
                
                #line 154 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                return 
                          offeringPrices;
                
                #line default
                #line hidden
            }
            
            public Microsoft.Xrm.Sdk.EntityCollection ValueType___Expr9Get() {
                this.GetValueTypeValues();
                return this.@__Expr9Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr10GetTree() {
                
                #line 139 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.AvailableOfferingInputModel>> expression = () => 
                          availableOfferingInputModel;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.AvailableOfferingInputModel @__Expr10Get() {
                
                #line 139 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                return 
                          availableOfferingInputModel;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.AvailableOfferingInputModel ValueType___Expr10Get() {
                this.GetValueTypeValues();
                return this.@__Expr10Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr11GetTree() {
                
                #line 164 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>>> expression = () => 
                          priceTypeCodeList;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> @__Expr11Get() {
                
                #line 164 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                return 
                          priceTypeCodeList;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> ValueType___Expr11Get() {
                this.GetValueTypeValues();
                return this.@__Expr11Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr12GetTree() {
                
                #line 159 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>>> expression = () => 
                          pricePeriodCodeList;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> @__Expr12Get() {
                
                #line 159 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                return 
                          pricePeriodCodeList;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> ValueType___Expr12Get() {
                this.GetValueTypeValues();
                return this.@__Expr12Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr13GetTree() {
                
                #line 149 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                System.Linq.Expressions.Expression<System.Func<Microsoft.Xrm.Sdk.EntityCollection>> expression = () => 
                          offeringPriceConfiguration;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Microsoft.Xrm.Sdk.EntityCollection @__Expr13Get() {
                
                #line 149 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                return 
                          offeringPriceConfiguration;
                
                #line default
                #line hidden
            }
            
            public Microsoft.Xrm.Sdk.EntityCollection ValueType___Expr13Get() {
                this.GetValueTypeValues();
                return this.@__Expr13Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr14GetTree() {
                
                #line 144 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                System.Linq.Expressions.Expression<System.Func<Microsoft.Xrm.Sdk.EntityCollection>> expression = () => 
                          availabilityOfferingConfiguration;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Microsoft.Xrm.Sdk.EntityCollection @__Expr14Get() {
                
                #line 144 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                return 
                          availabilityOfferingConfiguration;
                
                #line default
                #line hidden
            }
            
            public Microsoft.Xrm.Sdk.EntityCollection ValueType___Expr14Get() {
                this.GetValueTypeValues();
                return this.@__Expr14Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr16GetTree() {
                
                #line 193 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                System.Linq.Expressions.Expression<System.Func<Microsoft.Xrm.Sdk.EntityCollection>> expression = () => 
                          offeringPrices;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Microsoft.Xrm.Sdk.EntityCollection @__Expr16Get() {
                
                #line 193 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                return 
                          offeringPrices;
                
                #line default
                #line hidden
            }
            
            public Microsoft.Xrm.Sdk.EntityCollection ValueType___Expr16Get() {
                this.GetValueTypeValues();
                return this.@__Expr16Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr17GetTree() {
                
                #line 178 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.AvailableOfferingInputModel>> expression = () => 
                          availableOfferingInputModel;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.AvailableOfferingInputModel @__Expr17Get() {
                
                #line 178 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                return 
                          availableOfferingInputModel;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.AvailableOfferingInputModel ValueType___Expr17Get() {
                this.GetValueTypeValues();
                return this.@__Expr17Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr18GetTree() {
                
                #line 203 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>>> expression = () => 
                          priceTypeCodeList;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> @__Expr18Get() {
                
                #line 203 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                return 
                          priceTypeCodeList;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> ValueType___Expr18Get() {
                this.GetValueTypeValues();
                return this.@__Expr18Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr19GetTree() {
                
                #line 198 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>>> expression = () => 
                          pricePeriodCodeList;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> @__Expr19Get() {
                
                #line 198 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                return 
                          pricePeriodCodeList;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> ValueType___Expr19Get() {
                this.GetValueTypeValues();
                return this.@__Expr19Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr20GetTree() {
                
                #line 188 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                System.Linq.Expressions.Expression<System.Func<Microsoft.Xrm.Sdk.EntityCollection>> expression = () => 
                          offeringPriceConfiguration;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Microsoft.Xrm.Sdk.EntityCollection @__Expr20Get() {
                
                #line 188 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                return 
                          offeringPriceConfiguration;
                
                #line default
                #line hidden
            }
            
            public Microsoft.Xrm.Sdk.EntityCollection ValueType___Expr20Get() {
                this.GetValueTypeValues();
                return this.@__Expr20Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr21GetTree() {
                
                #line 183 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                System.Linq.Expressions.Expression<System.Func<Microsoft.Xrm.Sdk.EntityCollection>> expression = () => 
                          availabilityOfferingConfiguration;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Microsoft.Xrm.Sdk.EntityCollection @__Expr21Get() {
                
                #line 183 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\GETAVAILABLEOFFERINGCONFIGURATION.XAML"
                return 
                          availabilityOfferingConfiguration;
                
                #line default
                #line hidden
            }
            
            public Microsoft.Xrm.Sdk.EntityCollection ValueType___Expr21Get() {
                this.GetValueTypeValues();
                return this.@__Expr21Get();
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
                if (((locationReferences[(offset + 2)].Name != "connectionString") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "availabilityOfferingConfiguration") 
                            || (locationReferences[(offset + 3)].Type != typeof(Microsoft.Xrm.Sdk.EntityCollection)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "offeringPriceConfiguration") 
                            || (locationReferences[(offset + 4)].Type != typeof(Microsoft.Xrm.Sdk.EntityCollection)))) {
                    return false;
                }
                if (((locationReferences[(offset + 5)].Name != "offeringPrices") 
                            || (locationReferences[(offset + 5)].Type != typeof(Microsoft.Xrm.Sdk.EntityCollection)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "priceTypeCodeList") 
                            || (locationReferences[(offset + 6)].Type != typeof(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 7)].Name != "pricePeriodCodeList") 
                            || (locationReferences[(offset + 7)].Type != typeof(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>)))) {
                    return false;
                }
                return GetAvailableOfferingConfiguration_TypedDataContext1_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
    }
}

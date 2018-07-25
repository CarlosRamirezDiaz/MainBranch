namespace ExternalApiWorkflows {
    
    #line 28 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\UpdateCustomerCreditProfile.xaml"
    using System;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\UpdateCustomerCreditProfile.xaml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 29 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\UpdateCustomerCreditProfile.xaml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\UpdateCustomerCreditProfile.xaml"
    using System.Activities;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\UpdateCustomerCreditProfile.xaml"
    using System.Activities.Expressions;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\UpdateCustomerCreditProfile.xaml"
    using System.Activities.Statements;
    
    #line default
    #line hidden
    
    #line 30 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\UpdateCustomerCreditProfile.xaml"
    using System.Data;
    
    #line default
    #line hidden
    
    #line 31 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\UpdateCustomerCreditProfile.xaml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 32 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\UpdateCustomerCreditProfile.xaml"
    using System.Text;
    
    #line default
    #line hidden
    
    #line 33 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\UpdateCustomerCreditProfile.xaml"
    using Ericsson.ETELCRM.Entities.Crm;
    
    #line default
    #line hidden
    
    #line 34 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\UpdateCustomerCreditProfile.xaml"
    using ExternalApiActivities.Models;
    
    #line default
    #line hidden
    
    #line 35 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\UpdateCustomerCreditProfile.xaml"
    using ExternalApiActivities.Exceptions;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\UpdateCustomerCreditProfile.xaml"
    using System.Activities.XamlIntegration;
    
    #line default
    #line hidden
    
    
    public partial class UpdateCustomerProfile : System.Activities.XamlIntegration.ICompiledExpressionRoot {
        
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
                this.dataContextActivities = UpdateCustomerProfile_TypedDataContext2.GetDataContextActivitiesHelper(this.rootActivity, this.forImplementation);
            }
            if ((expressionId == 0)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new UpdateCustomerProfile_TypedDataContext2(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext2 refDataContext0 = ((UpdateCustomerProfile_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 1)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext1 = ((UpdateCustomerProfile_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new UpdateCustomerProfile_TypedDataContext2(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext2 refDataContext2 = ((UpdateCustomerProfile_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext2.GetLocation<System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>>>(refDataContext2.ValueType___Expr2Get, refDataContext2.ValueType___Expr2Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 3)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext3 = ((UpdateCustomerProfile_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext3.ValueType___Expr3Get();
            }
            if ((expressionId == 4)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new UpdateCustomerProfile_TypedDataContext2(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext2 refDataContext4 = ((UpdateCustomerProfile_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext4.GetLocation<Ericsson.ETELCRM.Entities.Crm.XrmDataContext>(refDataContext4.ValueType___Expr4Get, refDataContext4.ValueType___Expr4Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 5)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext5 = ((UpdateCustomerProfile_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext5.ValueType___Expr5Get();
            }
            if ((expressionId == 6)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext6 = ((UpdateCustomerProfile_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext7 = ((UpdateCustomerProfile_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new UpdateCustomerProfile_TypedDataContext2(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext2 refDataContext8 = ((UpdateCustomerProfile_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext8.GetLocation<Ericsson.ETELCRM.Entities.Crm.Contact>(refDataContext8.ValueType___Expr8Get, refDataContext8.ValueType___Expr8Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 9)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext9 = ((UpdateCustomerProfile_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext9.ValueType___Expr9Get();
            }
            if ((expressionId == 10)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext10 = ((UpdateCustomerProfile_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext11 = ((UpdateCustomerProfile_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext11.ValueType___Expr11Get();
            }
            if ((expressionId == 12)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext12 = ((UpdateCustomerProfile_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext12.ValueType___Expr12Get();
            }
            if ((expressionId == 13)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new UpdateCustomerProfile_TypedDataContext2(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext2 refDataContext13 = ((UpdateCustomerProfile_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext13.GetLocation<Ericsson.ETELCRM.Entities.Crm.Account>(refDataContext13.ValueType___Expr13Get, refDataContext13.ValueType___Expr13Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 14)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext14 = ((UpdateCustomerProfile_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext14.ValueType___Expr14Get();
            }
            if ((expressionId == 15)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext15 = ((UpdateCustomerProfile_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext15.ValueType___Expr15Get();
            }
            if ((expressionId == 16)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext16 = ((UpdateCustomerProfile_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext16.ValueType___Expr16Get();
            }
            if ((expressionId == 17)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext17 = ((UpdateCustomerProfile_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext17.ValueType___Expr17Get();
            }
            if ((expressionId == 18)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new UpdateCustomerProfile_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext3_ForReadOnly valDataContext18 = ((UpdateCustomerProfile_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext18.ValueType___Expr18Get();
            }
            if ((expressionId == 19)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new UpdateCustomerProfile_TypedDataContext3(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext3 refDataContext19 = ((UpdateCustomerProfile_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext19.GetLocation<bool>(refDataContext19.ValueType___Expr19Get, refDataContext19.ValueType___Expr19Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 20)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new UpdateCustomerProfile_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext3_ForReadOnly valDataContext20 = ((UpdateCustomerProfile_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext20.ValueType___Expr20Get();
            }
            if ((expressionId == 21)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new UpdateCustomerProfile_TypedDataContext3(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext3 refDataContext21 = ((UpdateCustomerProfile_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext21.GetLocation<string>(refDataContext21.ValueType___Expr21Get, refDataContext21.ValueType___Expr21Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 22)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new UpdateCustomerProfile_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext3_ForReadOnly valDataContext22 = ((UpdateCustomerProfile_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext22.ValueType___Expr22Get();
            }
            if ((expressionId == 23)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new UpdateCustomerProfile_TypedDataContext3(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext3 refDataContext23 = ((UpdateCustomerProfile_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext23.GetLocation<bool>(refDataContext23.ValueType___Expr23Get, refDataContext23.ValueType___Expr23Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 24)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new UpdateCustomerProfile_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext3_ForReadOnly valDataContext24 = ((UpdateCustomerProfile_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext24.ValueType___Expr24Get();
            }
            if ((expressionId == 25)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new UpdateCustomerProfile_TypedDataContext3(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext3 refDataContext25 = ((UpdateCustomerProfile_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext25.GetLocation<string>(refDataContext25.ValueType___Expr25Get, refDataContext25.ValueType___Expr25Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 26)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new UpdateCustomerProfile_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext3_ForReadOnly valDataContext26 = ((UpdateCustomerProfile_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext26.ValueType___Expr26Get();
            }
            if ((expressionId == 27)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new UpdateCustomerProfile_TypedDataContext3(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext3 refDataContext27 = ((UpdateCustomerProfile_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext27.GetLocation<bool>(refDataContext27.ValueType___Expr27Get, refDataContext27.ValueType___Expr27Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 28)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new UpdateCustomerProfile_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext3_ForReadOnly valDataContext28 = ((UpdateCustomerProfile_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext28.ValueType___Expr28Get();
            }
            if ((expressionId == 29)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new UpdateCustomerProfile_TypedDataContext3(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext3 refDataContext29 = ((UpdateCustomerProfile_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext29.GetLocation<string>(refDataContext29.ValueType___Expr29Get, refDataContext29.ValueType___Expr29Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 30)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new UpdateCustomerProfile_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext3_ForReadOnly valDataContext30 = ((UpdateCustomerProfile_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext30.ValueType___Expr30Get();
            }
            if ((expressionId == 31)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new UpdateCustomerProfile_TypedDataContext3(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext3 refDataContext31 = ((UpdateCustomerProfile_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext31.GetLocation<bool>(refDataContext31.ValueType___Expr31Get, refDataContext31.ValueType___Expr31Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 32)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new UpdateCustomerProfile_TypedDataContext3(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext3 refDataContext32 = ((UpdateCustomerProfile_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext32.GetLocation<string>(refDataContext32.ValueType___Expr32Get, refDataContext32.ValueType___Expr32Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 33)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new UpdateCustomerProfile_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext3_ForReadOnly valDataContext33 = ((UpdateCustomerProfile_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext33.ValueType___Expr33Get();
            }
            if ((expressionId == 34)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new UpdateCustomerProfile_TypedDataContext3(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext3 refDataContext34 = ((UpdateCustomerProfile_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext34.GetLocation<bool>(refDataContext34.ValueType___Expr34Get, refDataContext34.ValueType___Expr34Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 35)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new UpdateCustomerProfile_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext3_ForReadOnly valDataContext35 = ((UpdateCustomerProfile_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext35.ValueType___Expr35Get();
            }
            if ((expressionId == 36)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new UpdateCustomerProfile_TypedDataContext3(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext3 refDataContext36 = ((UpdateCustomerProfile_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext36.GetLocation<string>(refDataContext36.ValueType___Expr36Get, refDataContext36.ValueType___Expr36Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 37)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext37 = ((UpdateCustomerProfile_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext37.ValueType___Expr37Get();
            }
            if ((expressionId == 38)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext38 = ((UpdateCustomerProfile_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext38.ValueType___Expr38Get();
            }
            if ((expressionId == 39)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext4_ForReadOnly valDataContext39 = ((UpdateCustomerProfile_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext39.ValueType___Expr39Get();
            }
            if ((expressionId == 40)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext4.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new UpdateCustomerProfile_TypedDataContext4(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext4 refDataContext40 = ((UpdateCustomerProfile_TypedDataContext4)(cachedCompiledDataContext[5]));
                return refDataContext40.GetLocation<Ericsson.ETELCRM.Entities.Crm.etel_creditprofile>(refDataContext40.ValueType___Expr40Get, refDataContext40.ValueType___Expr40Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 41)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext4_ForReadOnly valDataContext41 = ((UpdateCustomerProfile_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext41.ValueType___Expr41Get();
            }
            if ((expressionId == 42)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext4_ForReadOnly valDataContext42 = ((UpdateCustomerProfile_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext42.ValueType___Expr42Get();
            }
            if ((expressionId == 43)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext4.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new UpdateCustomerProfile_TypedDataContext4(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext4 refDataContext43 = ((UpdateCustomerProfile_TypedDataContext4)(cachedCompiledDataContext[5]));
                return refDataContext43.GetLocation<bool>(refDataContext43.ValueType___Expr43Get, refDataContext43.ValueType___Expr43Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 44)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext4_ForReadOnly valDataContext44 = ((UpdateCustomerProfile_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext44.ValueType___Expr44Get();
            }
            if ((expressionId == 45)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext4.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new UpdateCustomerProfile_TypedDataContext4(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext4 refDataContext45 = ((UpdateCustomerProfile_TypedDataContext4)(cachedCompiledDataContext[5]));
                return refDataContext45.GetLocation<string>(refDataContext45.ValueType___Expr45Get, refDataContext45.ValueType___Expr45Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 46)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext4_ForReadOnly valDataContext46 = ((UpdateCustomerProfile_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext46.ValueType___Expr46Get();
            }
            if ((expressionId == 47)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext4_ForReadOnly valDataContext47 = ((UpdateCustomerProfile_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext47.ValueType___Expr47Get();
            }
            if ((expressionId == 48)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext4.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new UpdateCustomerProfile_TypedDataContext4(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext4 refDataContext48 = ((UpdateCustomerProfile_TypedDataContext4)(cachedCompiledDataContext[5]));
                return refDataContext48.GetLocation<bool>(refDataContext48.ValueType___Expr48Get, refDataContext48.ValueType___Expr48Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 49)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext4_ForReadOnly valDataContext49 = ((UpdateCustomerProfile_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext49.ValueType___Expr49Get();
            }
            if ((expressionId == 50)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext4.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new UpdateCustomerProfile_TypedDataContext4(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext4 refDataContext50 = ((UpdateCustomerProfile_TypedDataContext4)(cachedCompiledDataContext[5]));
                return refDataContext50.GetLocation<string>(refDataContext50.ValueType___Expr50Get, refDataContext50.ValueType___Expr50Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 51)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext4_ForReadOnly valDataContext51 = ((UpdateCustomerProfile_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext51.ValueType___Expr51Get();
            }
            if ((expressionId == 52)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext4.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new UpdateCustomerProfile_TypedDataContext4(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext4 refDataContext52 = ((UpdateCustomerProfile_TypedDataContext4)(cachedCompiledDataContext[5]));
                return refDataContext52.GetLocation<bool>(refDataContext52.ValueType___Expr52Get, refDataContext52.ValueType___Expr52Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 53)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext4_ForReadOnly valDataContext53 = ((UpdateCustomerProfile_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext53.ValueType___Expr53Get();
            }
            if ((expressionId == 54)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext4.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new UpdateCustomerProfile_TypedDataContext4(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext4 refDataContext54 = ((UpdateCustomerProfile_TypedDataContext4)(cachedCompiledDataContext[5]));
                return refDataContext54.GetLocation<string>(refDataContext54.ValueType___Expr54Get, refDataContext54.ValueType___Expr54Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 55)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext4.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new UpdateCustomerProfile_TypedDataContext4(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext4 refDataContext55 = ((UpdateCustomerProfile_TypedDataContext4)(cachedCompiledDataContext[5]));
                return refDataContext55.GetLocation<bool>(refDataContext55.ValueType___Expr55Get, refDataContext55.ValueType___Expr55Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 56)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext4_ForReadOnly valDataContext56 = ((UpdateCustomerProfile_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext56.ValueType___Expr56Get();
            }
            if ((expressionId == 57)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext4.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new UpdateCustomerProfile_TypedDataContext4(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext4 refDataContext57 = ((UpdateCustomerProfile_TypedDataContext4)(cachedCompiledDataContext[5]));
                return refDataContext57.GetLocation<string>(refDataContext57.ValueType___Expr57Get, refDataContext57.ValueType___Expr57Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 58)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext5_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[6] == null)) {
                    cachedCompiledDataContext[6] = new UpdateCustomerProfile_TypedDataContext5_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext5_ForReadOnly valDataContext58 = ((UpdateCustomerProfile_TypedDataContext5_ForReadOnly)(cachedCompiledDataContext[6]));
                return valDataContext58.ValueType___Expr58Get();
            }
            if ((expressionId == 59)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext5_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[6] == null)) {
                    cachedCompiledDataContext[6] = new UpdateCustomerProfile_TypedDataContext5_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext5_ForReadOnly valDataContext59 = ((UpdateCustomerProfile_TypedDataContext5_ForReadOnly)(cachedCompiledDataContext[6]));
                return valDataContext59.ValueType___Expr59Get();
            }
            if ((expressionId == 60)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext5_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[6] == null)) {
                    cachedCompiledDataContext[6] = new UpdateCustomerProfile_TypedDataContext5_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext5_ForReadOnly valDataContext60 = ((UpdateCustomerProfile_TypedDataContext5_ForReadOnly)(cachedCompiledDataContext[6]));
                return valDataContext60.ValueType___Expr60Get();
            }
            if ((expressionId == 61)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext5_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[6] == null)) {
                    cachedCompiledDataContext[6] = new UpdateCustomerProfile_TypedDataContext5_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext5_ForReadOnly valDataContext61 = ((UpdateCustomerProfile_TypedDataContext5_ForReadOnly)(cachedCompiledDataContext[6]));
                return valDataContext61.ValueType___Expr61Get();
            }
            if ((expressionId == 62)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext5_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[6] == null)) {
                    cachedCompiledDataContext[6] = new UpdateCustomerProfile_TypedDataContext5_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext5_ForReadOnly valDataContext62 = ((UpdateCustomerProfile_TypedDataContext5_ForReadOnly)(cachedCompiledDataContext[6]));
                return valDataContext62.ValueType___Expr62Get();
            }
            if ((expressionId == 63)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = UpdateCustomerProfile_TypedDataContext5_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[6] == null)) {
                    cachedCompiledDataContext[6] = new UpdateCustomerProfile_TypedDataContext5_ForReadOnly(locations, activityContext, true);
                }
                UpdateCustomerProfile_TypedDataContext5_ForReadOnly valDataContext63 = ((UpdateCustomerProfile_TypedDataContext5_ForReadOnly)(cachedCompiledDataContext[6]));
                return valDataContext63.ValueType___Expr63Get();
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
                UpdateCustomerProfile_TypedDataContext2 refDataContext0 = new UpdateCustomerProfile_TypedDataContext2(locations, true);
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set);
            }
            if ((expressionId == 1)) {
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext1 = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                UpdateCustomerProfile_TypedDataContext2 refDataContext2 = new UpdateCustomerProfile_TypedDataContext2(locations, true);
                return refDataContext2.GetLocation<System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>>>(refDataContext2.ValueType___Expr2Get, refDataContext2.ValueType___Expr2Set);
            }
            if ((expressionId == 3)) {
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext3 = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext3.ValueType___Expr3Get();
            }
            if ((expressionId == 4)) {
                UpdateCustomerProfile_TypedDataContext2 refDataContext4 = new UpdateCustomerProfile_TypedDataContext2(locations, true);
                return refDataContext4.GetLocation<Ericsson.ETELCRM.Entities.Crm.XrmDataContext>(refDataContext4.ValueType___Expr4Get, refDataContext4.ValueType___Expr4Set);
            }
            if ((expressionId == 5)) {
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext5 = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext5.ValueType___Expr5Get();
            }
            if ((expressionId == 6)) {
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext6 = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext7 = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                UpdateCustomerProfile_TypedDataContext2 refDataContext8 = new UpdateCustomerProfile_TypedDataContext2(locations, true);
                return refDataContext8.GetLocation<Ericsson.ETELCRM.Entities.Crm.Contact>(refDataContext8.ValueType___Expr8Get, refDataContext8.ValueType___Expr8Set);
            }
            if ((expressionId == 9)) {
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext9 = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext9.ValueType___Expr9Get();
            }
            if ((expressionId == 10)) {
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext10 = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext11 = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext11.ValueType___Expr11Get();
            }
            if ((expressionId == 12)) {
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext12 = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext12.ValueType___Expr12Get();
            }
            if ((expressionId == 13)) {
                UpdateCustomerProfile_TypedDataContext2 refDataContext13 = new UpdateCustomerProfile_TypedDataContext2(locations, true);
                return refDataContext13.GetLocation<Ericsson.ETELCRM.Entities.Crm.Account>(refDataContext13.ValueType___Expr13Get, refDataContext13.ValueType___Expr13Set);
            }
            if ((expressionId == 14)) {
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext14 = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext14.ValueType___Expr14Get();
            }
            if ((expressionId == 15)) {
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext15 = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext15.ValueType___Expr15Get();
            }
            if ((expressionId == 16)) {
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext16 = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext16.ValueType___Expr16Get();
            }
            if ((expressionId == 17)) {
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext17 = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext17.ValueType___Expr17Get();
            }
            if ((expressionId == 18)) {
                UpdateCustomerProfile_TypedDataContext3_ForReadOnly valDataContext18 = new UpdateCustomerProfile_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext18.ValueType___Expr18Get();
            }
            if ((expressionId == 19)) {
                UpdateCustomerProfile_TypedDataContext3 refDataContext19 = new UpdateCustomerProfile_TypedDataContext3(locations, true);
                return refDataContext19.GetLocation<bool>(refDataContext19.ValueType___Expr19Get, refDataContext19.ValueType___Expr19Set);
            }
            if ((expressionId == 20)) {
                UpdateCustomerProfile_TypedDataContext3_ForReadOnly valDataContext20 = new UpdateCustomerProfile_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext20.ValueType___Expr20Get();
            }
            if ((expressionId == 21)) {
                UpdateCustomerProfile_TypedDataContext3 refDataContext21 = new UpdateCustomerProfile_TypedDataContext3(locations, true);
                return refDataContext21.GetLocation<string>(refDataContext21.ValueType___Expr21Get, refDataContext21.ValueType___Expr21Set);
            }
            if ((expressionId == 22)) {
                UpdateCustomerProfile_TypedDataContext3_ForReadOnly valDataContext22 = new UpdateCustomerProfile_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext22.ValueType___Expr22Get();
            }
            if ((expressionId == 23)) {
                UpdateCustomerProfile_TypedDataContext3 refDataContext23 = new UpdateCustomerProfile_TypedDataContext3(locations, true);
                return refDataContext23.GetLocation<bool>(refDataContext23.ValueType___Expr23Get, refDataContext23.ValueType___Expr23Set);
            }
            if ((expressionId == 24)) {
                UpdateCustomerProfile_TypedDataContext3_ForReadOnly valDataContext24 = new UpdateCustomerProfile_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext24.ValueType___Expr24Get();
            }
            if ((expressionId == 25)) {
                UpdateCustomerProfile_TypedDataContext3 refDataContext25 = new UpdateCustomerProfile_TypedDataContext3(locations, true);
                return refDataContext25.GetLocation<string>(refDataContext25.ValueType___Expr25Get, refDataContext25.ValueType___Expr25Set);
            }
            if ((expressionId == 26)) {
                UpdateCustomerProfile_TypedDataContext3_ForReadOnly valDataContext26 = new UpdateCustomerProfile_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext26.ValueType___Expr26Get();
            }
            if ((expressionId == 27)) {
                UpdateCustomerProfile_TypedDataContext3 refDataContext27 = new UpdateCustomerProfile_TypedDataContext3(locations, true);
                return refDataContext27.GetLocation<bool>(refDataContext27.ValueType___Expr27Get, refDataContext27.ValueType___Expr27Set);
            }
            if ((expressionId == 28)) {
                UpdateCustomerProfile_TypedDataContext3_ForReadOnly valDataContext28 = new UpdateCustomerProfile_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext28.ValueType___Expr28Get();
            }
            if ((expressionId == 29)) {
                UpdateCustomerProfile_TypedDataContext3 refDataContext29 = new UpdateCustomerProfile_TypedDataContext3(locations, true);
                return refDataContext29.GetLocation<string>(refDataContext29.ValueType___Expr29Get, refDataContext29.ValueType___Expr29Set);
            }
            if ((expressionId == 30)) {
                UpdateCustomerProfile_TypedDataContext3_ForReadOnly valDataContext30 = new UpdateCustomerProfile_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext30.ValueType___Expr30Get();
            }
            if ((expressionId == 31)) {
                UpdateCustomerProfile_TypedDataContext3 refDataContext31 = new UpdateCustomerProfile_TypedDataContext3(locations, true);
                return refDataContext31.GetLocation<bool>(refDataContext31.ValueType___Expr31Get, refDataContext31.ValueType___Expr31Set);
            }
            if ((expressionId == 32)) {
                UpdateCustomerProfile_TypedDataContext3 refDataContext32 = new UpdateCustomerProfile_TypedDataContext3(locations, true);
                return refDataContext32.GetLocation<string>(refDataContext32.ValueType___Expr32Get, refDataContext32.ValueType___Expr32Set);
            }
            if ((expressionId == 33)) {
                UpdateCustomerProfile_TypedDataContext3_ForReadOnly valDataContext33 = new UpdateCustomerProfile_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext33.ValueType___Expr33Get();
            }
            if ((expressionId == 34)) {
                UpdateCustomerProfile_TypedDataContext3 refDataContext34 = new UpdateCustomerProfile_TypedDataContext3(locations, true);
                return refDataContext34.GetLocation<bool>(refDataContext34.ValueType___Expr34Get, refDataContext34.ValueType___Expr34Set);
            }
            if ((expressionId == 35)) {
                UpdateCustomerProfile_TypedDataContext3_ForReadOnly valDataContext35 = new UpdateCustomerProfile_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext35.ValueType___Expr35Get();
            }
            if ((expressionId == 36)) {
                UpdateCustomerProfile_TypedDataContext3 refDataContext36 = new UpdateCustomerProfile_TypedDataContext3(locations, true);
                return refDataContext36.GetLocation<string>(refDataContext36.ValueType___Expr36Get, refDataContext36.ValueType___Expr36Set);
            }
            if ((expressionId == 37)) {
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext37 = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext37.ValueType___Expr37Get();
            }
            if ((expressionId == 38)) {
                UpdateCustomerProfile_TypedDataContext2_ForReadOnly valDataContext38 = new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext38.ValueType___Expr38Get();
            }
            if ((expressionId == 39)) {
                UpdateCustomerProfile_TypedDataContext4_ForReadOnly valDataContext39 = new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext39.ValueType___Expr39Get();
            }
            if ((expressionId == 40)) {
                UpdateCustomerProfile_TypedDataContext4 refDataContext40 = new UpdateCustomerProfile_TypedDataContext4(locations, true);
                return refDataContext40.GetLocation<Ericsson.ETELCRM.Entities.Crm.etel_creditprofile>(refDataContext40.ValueType___Expr40Get, refDataContext40.ValueType___Expr40Set);
            }
            if ((expressionId == 41)) {
                UpdateCustomerProfile_TypedDataContext4_ForReadOnly valDataContext41 = new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext41.ValueType___Expr41Get();
            }
            if ((expressionId == 42)) {
                UpdateCustomerProfile_TypedDataContext4_ForReadOnly valDataContext42 = new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext42.ValueType___Expr42Get();
            }
            if ((expressionId == 43)) {
                UpdateCustomerProfile_TypedDataContext4 refDataContext43 = new UpdateCustomerProfile_TypedDataContext4(locations, true);
                return refDataContext43.GetLocation<bool>(refDataContext43.ValueType___Expr43Get, refDataContext43.ValueType___Expr43Set);
            }
            if ((expressionId == 44)) {
                UpdateCustomerProfile_TypedDataContext4_ForReadOnly valDataContext44 = new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext44.ValueType___Expr44Get();
            }
            if ((expressionId == 45)) {
                UpdateCustomerProfile_TypedDataContext4 refDataContext45 = new UpdateCustomerProfile_TypedDataContext4(locations, true);
                return refDataContext45.GetLocation<string>(refDataContext45.ValueType___Expr45Get, refDataContext45.ValueType___Expr45Set);
            }
            if ((expressionId == 46)) {
                UpdateCustomerProfile_TypedDataContext4_ForReadOnly valDataContext46 = new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext46.ValueType___Expr46Get();
            }
            if ((expressionId == 47)) {
                UpdateCustomerProfile_TypedDataContext4_ForReadOnly valDataContext47 = new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext47.ValueType___Expr47Get();
            }
            if ((expressionId == 48)) {
                UpdateCustomerProfile_TypedDataContext4 refDataContext48 = new UpdateCustomerProfile_TypedDataContext4(locations, true);
                return refDataContext48.GetLocation<bool>(refDataContext48.ValueType___Expr48Get, refDataContext48.ValueType___Expr48Set);
            }
            if ((expressionId == 49)) {
                UpdateCustomerProfile_TypedDataContext4_ForReadOnly valDataContext49 = new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext49.ValueType___Expr49Get();
            }
            if ((expressionId == 50)) {
                UpdateCustomerProfile_TypedDataContext4 refDataContext50 = new UpdateCustomerProfile_TypedDataContext4(locations, true);
                return refDataContext50.GetLocation<string>(refDataContext50.ValueType___Expr50Get, refDataContext50.ValueType___Expr50Set);
            }
            if ((expressionId == 51)) {
                UpdateCustomerProfile_TypedDataContext4_ForReadOnly valDataContext51 = new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext51.ValueType___Expr51Get();
            }
            if ((expressionId == 52)) {
                UpdateCustomerProfile_TypedDataContext4 refDataContext52 = new UpdateCustomerProfile_TypedDataContext4(locations, true);
                return refDataContext52.GetLocation<bool>(refDataContext52.ValueType___Expr52Get, refDataContext52.ValueType___Expr52Set);
            }
            if ((expressionId == 53)) {
                UpdateCustomerProfile_TypedDataContext4_ForReadOnly valDataContext53 = new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext53.ValueType___Expr53Get();
            }
            if ((expressionId == 54)) {
                UpdateCustomerProfile_TypedDataContext4 refDataContext54 = new UpdateCustomerProfile_TypedDataContext4(locations, true);
                return refDataContext54.GetLocation<string>(refDataContext54.ValueType___Expr54Get, refDataContext54.ValueType___Expr54Set);
            }
            if ((expressionId == 55)) {
                UpdateCustomerProfile_TypedDataContext4 refDataContext55 = new UpdateCustomerProfile_TypedDataContext4(locations, true);
                return refDataContext55.GetLocation<bool>(refDataContext55.ValueType___Expr55Get, refDataContext55.ValueType___Expr55Set);
            }
            if ((expressionId == 56)) {
                UpdateCustomerProfile_TypedDataContext4_ForReadOnly valDataContext56 = new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext56.ValueType___Expr56Get();
            }
            if ((expressionId == 57)) {
                UpdateCustomerProfile_TypedDataContext4 refDataContext57 = new UpdateCustomerProfile_TypedDataContext4(locations, true);
                return refDataContext57.GetLocation<string>(refDataContext57.ValueType___Expr57Get, refDataContext57.ValueType___Expr57Set);
            }
            if ((expressionId == 58)) {
                UpdateCustomerProfile_TypedDataContext5_ForReadOnly valDataContext58 = new UpdateCustomerProfile_TypedDataContext5_ForReadOnly(locations, true);
                return valDataContext58.ValueType___Expr58Get();
            }
            if ((expressionId == 59)) {
                UpdateCustomerProfile_TypedDataContext5_ForReadOnly valDataContext59 = new UpdateCustomerProfile_TypedDataContext5_ForReadOnly(locations, true);
                return valDataContext59.ValueType___Expr59Get();
            }
            if ((expressionId == 60)) {
                UpdateCustomerProfile_TypedDataContext5_ForReadOnly valDataContext60 = new UpdateCustomerProfile_TypedDataContext5_ForReadOnly(locations, true);
                return valDataContext60.ValueType___Expr60Get();
            }
            if ((expressionId == 61)) {
                UpdateCustomerProfile_TypedDataContext5_ForReadOnly valDataContext61 = new UpdateCustomerProfile_TypedDataContext5_ForReadOnly(locations, true);
                return valDataContext61.ValueType___Expr61Get();
            }
            if ((expressionId == 62)) {
                UpdateCustomerProfile_TypedDataContext5_ForReadOnly valDataContext62 = new UpdateCustomerProfile_TypedDataContext5_ForReadOnly(locations, true);
                return valDataContext62.ValueType___Expr62Get();
            }
            if ((expressionId == 63)) {
                UpdateCustomerProfile_TypedDataContext5_ForReadOnly valDataContext63 = new UpdateCustomerProfile_TypedDataContext5_ForReadOnly(locations, true);
                return valDataContext63.ValueType___Expr63Get();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool CanExecuteExpression(string expressionText, bool isReference, System.Collections.Generic.IList<System.Activities.LocationReference> locations, out int expressionId) {
            if (((isReference == true) 
                        && ((expressionText == "connectionString") 
                        && (UpdateCustomerProfile_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 0;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "connectionString") 
                        && (UpdateCustomerProfile_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 1;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "translations") 
                        && (UpdateCustomerProfile_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 2;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "connectionString") 
                        && (UpdateCustomerProfile_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 3;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "creditProfilecontext") 
                        && (UpdateCustomerProfile_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 4;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "customerCreditProfileRequestModel == null") 
                        && (UpdateCustomerProfile_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 5;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new Exception(translations[\"CustomerCreditProfilePSB\"].Where(t => t.Key == \"tcust" +
                            "omerCreditProfileRequestModelControlMessage\").Select(t => t.Value).FirstOrDefaul" +
                            "t().ToString())") 
                        && (UpdateCustomerProfile_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 6;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "customerCreditProfileRequestModel.CustomerId") 
                        && (UpdateCustomerProfile_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 7;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "individualCustomer") 
                        && (UpdateCustomerProfile_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 8;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "individualCustomer == null") 
                        && (UpdateCustomerProfile_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 9;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "individualCustomer.StatusCode.Value != ((int)contact_statuscode.Active)") 
                        && (UpdateCustomerProfile_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 10;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new Exception(translations[\"CustomerCreditProfilePSB\"].Where(t => t.Key == \"tCust" +
                            "omerStatusMessage\").Select(t => t.Value).FirstOrDefault().ToString())") 
                        && (UpdateCustomerProfile_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 11;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "customerCreditProfileRequestModel.CustomerId") 
                        && (UpdateCustomerProfile_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 12;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "corporateCustomer") 
                        && (UpdateCustomerProfile_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 13;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "corporateCustomer == null") 
                        && (UpdateCustomerProfile_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 14;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "corporateCustomer.StatusCode.Value != ((int)contact_statuscode.Active)") 
                        && (UpdateCustomerProfile_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 15;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new Exception(translations[\"CustomerCreditProfilePSB\"].Where(t => t.Key == \"tCust" +
                            "omerCouldNotFound\").Select(t => t.Value).FirstOrDefault().ToString())") 
                        && (UpdateCustomerProfile_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 16;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "customerCreditProfileRequestModel.CustomerCreditProfiles") 
                        && (UpdateCustomerProfile_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 17;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "String.IsNullOrWhiteSpace(customerCreditProfileModel.CreditRiskRating)") 
                        && (UpdateCustomerProfile_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 18;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "customerCreditProfileModel.IsError") 
                        && (UpdateCustomerProfile_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 19;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "translations[\"CustomerCreditProfilePSB\"].Where(t => t.Key == \"tCreditRiskRatingRe" +
                            "quiredMessage\").Select(t => t.Value).FirstOrDefault().ToString()") 
                        && (UpdateCustomerProfile_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 20;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "customerCreditProfileModel.ErrorDescription") 
                        && (UpdateCustomerProfile_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 21;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "String.IsNullOrWhiteSpace(customerCreditProfileModel.CreditScore)") 
                        && (UpdateCustomerProfile_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 22;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "customerCreditProfileModel.IsError") 
                        && (UpdateCustomerProfile_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 23;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "translations[\"CustomerCreditProfilePSB\"].Where(t => t.Key == \"tCreditScoreRequire" +
                            "dMessage\").Select(t => t.Value).FirstOrDefault().ToString()") 
                        && (UpdateCustomerProfile_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 24;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "customerCreditProfileModel.ErrorDescription") 
                        && (UpdateCustomerProfile_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 25;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "customerCreditProfileModel.StartDate == null") 
                        && (UpdateCustomerProfile_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 26;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "customerCreditProfileModel.IsError") 
                        && (UpdateCustomerProfile_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 27;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "translations[\"CustomerCreditProfilePSB\"].Where(t => t.Key == \"tStartDateWarningMe" +
                            "ssage\").Select(t => t.Value).FirstOrDefault().ToString()") 
                        && (UpdateCustomerProfile_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 28;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "customerCreditProfileModel.ErrorDescription") 
                        && (UpdateCustomerProfile_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 29;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "customerCreditProfileModel.StartDate>customerCreditProfileModel.EndDate") 
                        && (UpdateCustomerProfile_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 30;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "customerCreditProfileModel.IsError") 
                        && (UpdateCustomerProfile_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 31;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "customerCreditProfileModel.ErrorDescription") 
                        && (UpdateCustomerProfile_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 32;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "customerCreditProfileModel.EndDate == null") 
                        && (UpdateCustomerProfile_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 33;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "customerCreditProfileModel.IsError") 
                        && (UpdateCustomerProfile_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 34;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "translations[\"CustomerCreditProfilePSB\"].Where(t => t.Key == \"tEndDateWarningMess" +
                            "age\").Select(t => t.Value).FirstOrDefault().ToString()") 
                        && (UpdateCustomerProfile_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 35;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "customerCreditProfileModel.ErrorDescription") 
                        && (UpdateCustomerProfile_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 36;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "connectionString") 
                        && (UpdateCustomerProfile_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 37;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "customerCreditProfileRequestModel.CustomerCreditProfiles") 
                        && (UpdateCustomerProfile_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 38;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "f => f.etel_name == customerCreditProfileModel.CreditProfileNumber") 
                        && (UpdateCustomerProfile_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 39;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "creditProfileEntity") 
                        && (UpdateCustomerProfile_TypedDataContext4.Validate(locations, true, 0) == true)))) {
                expressionId = 40;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "creditProfileEntity == null") 
                        && (UpdateCustomerProfile_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 41;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "customerCreditProfileModel.StartDate!=null && (creditProfileEntity.etel_startdate" +
                            ".Value.ToUniversalTime().Date != DateTime.SpecifyKind(customerCreditProfileModel" +
                            ".StartDate.Value, DateTimeKind.Utc).Date)") 
                        && (UpdateCustomerProfile_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 42;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "customerCreditProfileModel.IsError") 
                        && (UpdateCustomerProfile_TypedDataContext4.Validate(locations, true, 0) == true)))) {
                expressionId = 43;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "translations[\"CustomerCreditProfilePSB\"].Where(t => t.Key == \"tStartDateUpdateMes" +
                            "sage\").Select(t => t.Value).FirstOrDefault().ToString()") 
                        && (UpdateCustomerProfile_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 44;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "customerCreditProfileModel.ErrorDescription") 
                        && (UpdateCustomerProfile_TypedDataContext4.Validate(locations, true, 0) == true)))) {
                expressionId = 45;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "individualCustomer != null") 
                        && (UpdateCustomerProfile_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 46;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "(creditProfileEntity.etel_individualid == null )|| (creditProfileEntity.etel_indi" +
                            "vidualid != null && individualCustomer.Id != creditProfileEntity.etel_individual" +
                            "id.Id)") 
                        && (UpdateCustomerProfile_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 47;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "customerCreditProfileModel.IsError") 
                        && (UpdateCustomerProfile_TypedDataContext4.Validate(locations, true, 0) == true)))) {
                expressionId = 48;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "translations[\"CustomerCreditProfilePSB\"].Where(t => t.Key == \"tCreditProfileContr" +
                            "olMessage\").Select(t => t.Value).FirstOrDefault().ToString()") 
                        && (UpdateCustomerProfile_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 49;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "customerCreditProfileModel.ErrorDescription") 
                        && (UpdateCustomerProfile_TypedDataContext4.Validate(locations, true, 0) == true)))) {
                expressionId = 50;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "(creditProfileEntity.etel_corporateid == null) || (creditProfileEntity.etel_corpo" +
                            "rateid != null && corporateCustomer.Id != creditProfileEntity.etel_corporateid.I" +
                            "d)") 
                        && (UpdateCustomerProfile_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 51;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "customerCreditProfileModel.IsError") 
                        && (UpdateCustomerProfile_TypedDataContext4.Validate(locations, true, 0) == true)))) {
                expressionId = 52;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "translations[\"CustomerCreditProfilePSB\"].Where(t => t.Key == \"tCreditProfileContr" +
                            "olMessage\").Select(t => t.Value).FirstOrDefault().ToString()") 
                        && (UpdateCustomerProfile_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 53;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "customerCreditProfileModel.ErrorDescription") 
                        && (UpdateCustomerProfile_TypedDataContext4.Validate(locations, true, 0) == true)))) {
                expressionId = 54;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "customerCreditProfileModel.IsError") 
                        && (UpdateCustomerProfile_TypedDataContext4.Validate(locations, true, 0) == true)))) {
                expressionId = 55;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "translations[\"CustomerCreditProfilePSB\"].Where(t => t.Key == \"tCreditProfileNumbe" +
                            "rInvalidMessage\").Select(t => t.Value).FirstOrDefault().ToString()") 
                        && (UpdateCustomerProfile_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 56;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "customerCreditProfileModel.ErrorDescription") 
                        && (UpdateCustomerProfile_TypedDataContext4.Validate(locations, true, 0) == true)))) {
                expressionId = 57;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new etel_bicreditprofileupdate()") 
                        && (UpdateCustomerProfile_TypedDataContext5_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 58;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "customerCreditProfileModel.IsError!=true") 
                        && (UpdateCustomerProfile_TypedDataContext5_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 59;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "(ICustomer)individualCustomer ?? corporateCustomer") 
                        && (UpdateCustomerProfile_TypedDataContext5_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 60;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "creditProfileEntity") 
                        && (UpdateCustomerProfile_TypedDataContext5_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 61;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "customerCreditProfileModel") 
                        && (UpdateCustomerProfile_TypedDataContext5_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 62;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "creditProfileUpdateBIEntity") 
                        && (UpdateCustomerProfile_TypedDataContext5_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 63;
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
                return new UpdateCustomerProfile_TypedDataContext2(locationReferences).@__Expr0GetTree();
            }
            if ((expressionId == 1)) {
                return new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locationReferences).@__Expr1GetTree();
            }
            if ((expressionId == 2)) {
                return new UpdateCustomerProfile_TypedDataContext2(locationReferences).@__Expr2GetTree();
            }
            if ((expressionId == 3)) {
                return new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locationReferences).@__Expr3GetTree();
            }
            if ((expressionId == 4)) {
                return new UpdateCustomerProfile_TypedDataContext2(locationReferences).@__Expr4GetTree();
            }
            if ((expressionId == 5)) {
                return new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locationReferences).@__Expr5GetTree();
            }
            if ((expressionId == 6)) {
                return new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locationReferences).@__Expr6GetTree();
            }
            if ((expressionId == 7)) {
                return new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locationReferences).@__Expr7GetTree();
            }
            if ((expressionId == 8)) {
                return new UpdateCustomerProfile_TypedDataContext2(locationReferences).@__Expr8GetTree();
            }
            if ((expressionId == 9)) {
                return new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locationReferences).@__Expr9GetTree();
            }
            if ((expressionId == 10)) {
                return new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locationReferences).@__Expr10GetTree();
            }
            if ((expressionId == 11)) {
                return new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locationReferences).@__Expr11GetTree();
            }
            if ((expressionId == 12)) {
                return new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locationReferences).@__Expr12GetTree();
            }
            if ((expressionId == 13)) {
                return new UpdateCustomerProfile_TypedDataContext2(locationReferences).@__Expr13GetTree();
            }
            if ((expressionId == 14)) {
                return new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locationReferences).@__Expr14GetTree();
            }
            if ((expressionId == 15)) {
                return new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locationReferences).@__Expr15GetTree();
            }
            if ((expressionId == 16)) {
                return new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locationReferences).@__Expr16GetTree();
            }
            if ((expressionId == 17)) {
                return new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locationReferences).@__Expr17GetTree();
            }
            if ((expressionId == 18)) {
                return new UpdateCustomerProfile_TypedDataContext3_ForReadOnly(locationReferences).@__Expr18GetTree();
            }
            if ((expressionId == 19)) {
                return new UpdateCustomerProfile_TypedDataContext3(locationReferences).@__Expr19GetTree();
            }
            if ((expressionId == 20)) {
                return new UpdateCustomerProfile_TypedDataContext3_ForReadOnly(locationReferences).@__Expr20GetTree();
            }
            if ((expressionId == 21)) {
                return new UpdateCustomerProfile_TypedDataContext3(locationReferences).@__Expr21GetTree();
            }
            if ((expressionId == 22)) {
                return new UpdateCustomerProfile_TypedDataContext3_ForReadOnly(locationReferences).@__Expr22GetTree();
            }
            if ((expressionId == 23)) {
                return new UpdateCustomerProfile_TypedDataContext3(locationReferences).@__Expr23GetTree();
            }
            if ((expressionId == 24)) {
                return new UpdateCustomerProfile_TypedDataContext3_ForReadOnly(locationReferences).@__Expr24GetTree();
            }
            if ((expressionId == 25)) {
                return new UpdateCustomerProfile_TypedDataContext3(locationReferences).@__Expr25GetTree();
            }
            if ((expressionId == 26)) {
                return new UpdateCustomerProfile_TypedDataContext3_ForReadOnly(locationReferences).@__Expr26GetTree();
            }
            if ((expressionId == 27)) {
                return new UpdateCustomerProfile_TypedDataContext3(locationReferences).@__Expr27GetTree();
            }
            if ((expressionId == 28)) {
                return new UpdateCustomerProfile_TypedDataContext3_ForReadOnly(locationReferences).@__Expr28GetTree();
            }
            if ((expressionId == 29)) {
                return new UpdateCustomerProfile_TypedDataContext3(locationReferences).@__Expr29GetTree();
            }
            if ((expressionId == 30)) {
                return new UpdateCustomerProfile_TypedDataContext3_ForReadOnly(locationReferences).@__Expr30GetTree();
            }
            if ((expressionId == 31)) {
                return new UpdateCustomerProfile_TypedDataContext3(locationReferences).@__Expr31GetTree();
            }
            if ((expressionId == 32)) {
                return new UpdateCustomerProfile_TypedDataContext3(locationReferences).@__Expr32GetTree();
            }
            if ((expressionId == 33)) {
                return new UpdateCustomerProfile_TypedDataContext3_ForReadOnly(locationReferences).@__Expr33GetTree();
            }
            if ((expressionId == 34)) {
                return new UpdateCustomerProfile_TypedDataContext3(locationReferences).@__Expr34GetTree();
            }
            if ((expressionId == 35)) {
                return new UpdateCustomerProfile_TypedDataContext3_ForReadOnly(locationReferences).@__Expr35GetTree();
            }
            if ((expressionId == 36)) {
                return new UpdateCustomerProfile_TypedDataContext3(locationReferences).@__Expr36GetTree();
            }
            if ((expressionId == 37)) {
                return new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locationReferences).@__Expr37GetTree();
            }
            if ((expressionId == 38)) {
                return new UpdateCustomerProfile_TypedDataContext2_ForReadOnly(locationReferences).@__Expr38GetTree();
            }
            if ((expressionId == 39)) {
                return new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locationReferences).@__Expr39GetTree();
            }
            if ((expressionId == 40)) {
                return new UpdateCustomerProfile_TypedDataContext4(locationReferences).@__Expr40GetTree();
            }
            if ((expressionId == 41)) {
                return new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locationReferences).@__Expr41GetTree();
            }
            if ((expressionId == 42)) {
                return new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locationReferences).@__Expr42GetTree();
            }
            if ((expressionId == 43)) {
                return new UpdateCustomerProfile_TypedDataContext4(locationReferences).@__Expr43GetTree();
            }
            if ((expressionId == 44)) {
                return new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locationReferences).@__Expr44GetTree();
            }
            if ((expressionId == 45)) {
                return new UpdateCustomerProfile_TypedDataContext4(locationReferences).@__Expr45GetTree();
            }
            if ((expressionId == 46)) {
                return new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locationReferences).@__Expr46GetTree();
            }
            if ((expressionId == 47)) {
                return new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locationReferences).@__Expr47GetTree();
            }
            if ((expressionId == 48)) {
                return new UpdateCustomerProfile_TypedDataContext4(locationReferences).@__Expr48GetTree();
            }
            if ((expressionId == 49)) {
                return new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locationReferences).@__Expr49GetTree();
            }
            if ((expressionId == 50)) {
                return new UpdateCustomerProfile_TypedDataContext4(locationReferences).@__Expr50GetTree();
            }
            if ((expressionId == 51)) {
                return new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locationReferences).@__Expr51GetTree();
            }
            if ((expressionId == 52)) {
                return new UpdateCustomerProfile_TypedDataContext4(locationReferences).@__Expr52GetTree();
            }
            if ((expressionId == 53)) {
                return new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locationReferences).@__Expr53GetTree();
            }
            if ((expressionId == 54)) {
                return new UpdateCustomerProfile_TypedDataContext4(locationReferences).@__Expr54GetTree();
            }
            if ((expressionId == 55)) {
                return new UpdateCustomerProfile_TypedDataContext4(locationReferences).@__Expr55GetTree();
            }
            if ((expressionId == 56)) {
                return new UpdateCustomerProfile_TypedDataContext4_ForReadOnly(locationReferences).@__Expr56GetTree();
            }
            if ((expressionId == 57)) {
                return new UpdateCustomerProfile_TypedDataContext4(locationReferences).@__Expr57GetTree();
            }
            if ((expressionId == 58)) {
                return new UpdateCustomerProfile_TypedDataContext5_ForReadOnly(locationReferences).@__Expr58GetTree();
            }
            if ((expressionId == 59)) {
                return new UpdateCustomerProfile_TypedDataContext5_ForReadOnly(locationReferences).@__Expr59GetTree();
            }
            if ((expressionId == 60)) {
                return new UpdateCustomerProfile_TypedDataContext5_ForReadOnly(locationReferences).@__Expr60GetTree();
            }
            if ((expressionId == 61)) {
                return new UpdateCustomerProfile_TypedDataContext5_ForReadOnly(locationReferences).@__Expr61GetTree();
            }
            if ((expressionId == 62)) {
                return new UpdateCustomerProfile_TypedDataContext5_ForReadOnly(locationReferences).@__Expr62GetTree();
            }
            if ((expressionId == 63)) {
                return new UpdateCustomerProfile_TypedDataContext5_ForReadOnly(locationReferences).@__Expr63GetTree();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class UpdateCustomerProfile_TypedDataContext0 : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public UpdateCustomerProfile_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateCustomerProfile_TypedDataContext0(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateCustomerProfile_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class UpdateCustomerProfile_TypedDataContext0_ForReadOnly : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public UpdateCustomerProfile_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateCustomerProfile_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateCustomerProfile_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class UpdateCustomerProfile_TypedDataContext1 : UpdateCustomerProfile_TypedDataContext0 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public UpdateCustomerProfile_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateCustomerProfile_TypedDataContext1(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateCustomerProfile_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected ExternalApiActivities.Models.CustomerCreditProfileRequestModel customerCreditProfileRequestModel {
                get {
                    return ((ExternalApiActivities.Models.CustomerCreditProfileRequestModel)(this.GetVariableValue((0 + locationsOffset))));
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
                if (((locationReferences[(offset + 0)].Name != "customerCreditProfileRequestModel") 
                            || (locationReferences[(offset + 0)].Type != typeof(ExternalApiActivities.Models.CustomerCreditProfileRequestModel)))) {
                    return false;
                }
                return UpdateCustomerProfile_TypedDataContext0.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class UpdateCustomerProfile_TypedDataContext1_ForReadOnly : UpdateCustomerProfile_TypedDataContext0_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public UpdateCustomerProfile_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateCustomerProfile_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateCustomerProfile_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected ExternalApiActivities.Models.CustomerCreditProfileRequestModel customerCreditProfileRequestModel {
                get {
                    return ((ExternalApiActivities.Models.CustomerCreditProfileRequestModel)(this.GetVariableValue((0 + locationsOffset))));
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
                if (((locationReferences[(offset + 0)].Name != "customerCreditProfileRequestModel") 
                            || (locationReferences[(offset + 0)].Type != typeof(ExternalApiActivities.Models.CustomerCreditProfileRequestModel)))) {
                    return false;
                }
                return UpdateCustomerProfile_TypedDataContext0_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class UpdateCustomerProfile_TypedDataContext2 : UpdateCustomerProfile_TypedDataContext1 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public UpdateCustomerProfile_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateCustomerProfile_TypedDataContext2(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateCustomerProfile_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
            
            protected Ericsson.ETELCRM.Entities.Crm.etel_creditprofile creditProfileEntity {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.etel_creditprofile)(this.GetVariableValue((2 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((2 + locationsOffset), value);
                }
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.XrmDataContext creditProfilecontext {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.XrmDataContext)(this.GetVariableValue((3 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((3 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>> translations {
                get {
                    return ((System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>>)(this.GetVariableValue((4 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((4 + locationsOffset), value);
                }
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.Contact individualCustomer {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.Contact)(this.GetVariableValue((5 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((5 + locationsOffset), value);
                }
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.Account corporateCustomer {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.Account)(this.GetVariableValue((6 + locationsOffset))));
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
            
            internal System.Linq.Expressions.Expression @__Expr0GetTree() {
                
                #line 87 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
              connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr0Get() {
                
                #line 87 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
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
                
                #line 87 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                
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
                
                #line 101 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>>>> expression = () => 
                            translations;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>> @__Expr2Get() {
                
                #line 101 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                            translations;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>> ValueType___Expr2Get() {
                this.GetValueTypeValues();
                return this.@__Expr2Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr2Set(System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>> value) {
                
                #line 101 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                
                            translations = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr2Set(System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>> value) {
                this.GetValueTypeValues();
                this.@__Expr2Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr4GetTree() {
                
                #line 123 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<Ericsson.ETELCRM.Entities.Crm.XrmDataContext>> expression = () => 
                          creditProfilecontext;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Ericsson.ETELCRM.Entities.Crm.XrmDataContext @__Expr4Get() {
                
                #line 123 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                          creditProfilecontext;
                
                #line default
                #line hidden
            }
            
            public Ericsson.ETELCRM.Entities.Crm.XrmDataContext ValueType___Expr4Get() {
                this.GetValueTypeValues();
                return this.@__Expr4Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr4Set(Ericsson.ETELCRM.Entities.Crm.XrmDataContext value) {
                
                #line 123 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                
                          creditProfilecontext = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr4Set(Ericsson.ETELCRM.Entities.Crm.XrmDataContext value) {
                this.GetValueTypeValues();
                this.@__Expr4Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr8GetTree() {
                
                #line 152 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<Ericsson.ETELCRM.Entities.Crm.Contact>> expression = () => 
                                individualCustomer;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Ericsson.ETELCRM.Entities.Crm.Contact @__Expr8Get() {
                
                #line 152 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                individualCustomer;
                
                #line default
                #line hidden
            }
            
            public Ericsson.ETELCRM.Entities.Crm.Contact ValueType___Expr8Get() {
                this.GetValueTypeValues();
                return this.@__Expr8Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr8Set(Ericsson.ETELCRM.Entities.Crm.Contact value) {
                
                #line 152 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                
                                individualCustomer = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr8Set(Ericsson.ETELCRM.Entities.Crm.Contact value) {
                this.GetValueTypeValues();
                this.@__Expr8Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr13GetTree() {
                
                #line 166 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<Ericsson.ETELCRM.Entities.Crm.Account>> expression = () => 
                                        corporateCustomer;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Ericsson.ETELCRM.Entities.Crm.Account @__Expr13Get() {
                
                #line 166 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                        corporateCustomer;
                
                #line default
                #line hidden
            }
            
            public Ericsson.ETELCRM.Entities.Crm.Account ValueType___Expr13Get() {
                this.GetValueTypeValues();
                return this.@__Expr13Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr13Set(Ericsson.ETELCRM.Entities.Crm.Account value) {
                
                #line 166 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                
                                        corporateCustomer = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr13Set(Ericsson.ETELCRM.Entities.Crm.Account value) {
                this.GetValueTypeValues();
                this.@__Expr13Set(value);
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
                if (((locationReferences[(offset + 1)].Name != "connectionString") 
                            || (locationReferences[(offset + 1)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 2)].Name != "creditProfileEntity") 
                            || (locationReferences[(offset + 2)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.etel_creditprofile)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "creditProfilecontext") 
                            || (locationReferences[(offset + 3)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.XrmDataContext)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "translations") 
                            || (locationReferences[(offset + 4)].Type != typeof(System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 5)].Name != "individualCustomer") 
                            || (locationReferences[(offset + 5)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.Contact)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "corporateCustomer") 
                            || (locationReferences[(offset + 6)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.Account)))) {
                    return false;
                }
                return UpdateCustomerProfile_TypedDataContext1.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class UpdateCustomerProfile_TypedDataContext2_ForReadOnly : UpdateCustomerProfile_TypedDataContext1_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public UpdateCustomerProfile_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateCustomerProfile_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateCustomerProfile_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string connectionString {
                get {
                    return ((string)(this.GetVariableValue((1 + locationsOffset))));
                }
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.etel_creditprofile creditProfileEntity {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.etel_creditprofile)(this.GetVariableValue((2 + locationsOffset))));
                }
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.XrmDataContext creditProfilecontext {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.XrmDataContext)(this.GetVariableValue((3 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>> translations {
                get {
                    return ((System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>>)(this.GetVariableValue((4 + locationsOffset))));
                }
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.Contact individualCustomer {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.Contact)(this.GetVariableValue((5 + locationsOffset))));
                }
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.Account corporateCustomer {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.Account)(this.GetVariableValue((6 + locationsOffset))));
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
                
                #line 112 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr1Get() {
                
                #line 112 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
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
                
                #line 425 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                      connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr3Get() {
                
                #line 425 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                      connectionString;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr3Get() {
                this.GetValueTypeValues();
                return this.@__Expr3Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr5GetTree() {
                
                #line 130 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                          customerCreditProfileRequestModel == null;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr5Get() {
                
                #line 130 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                          customerCreditProfileRequestModel == null;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr5Get() {
                this.GetValueTypeValues();
                return this.@__Expr5Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr6GetTree() {
                
                #line 136 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Exception>> expression = () => 
                            new Exception(translations["CustomerCreditProfilePSB"].Where(t => t.Key == "tcustomerCreditProfileRequestModelControlMessage").Select(t => t.Value).FirstOrDefault().ToString());
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Exception @__Expr6Get() {
                
                #line 136 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                            new Exception(translations["CustomerCreditProfilePSB"].Where(t => t.Key == "tcustomerCreditProfileRequestModelControlMessage").Select(t => t.Value).FirstOrDefault().ToString());
                
                #line default
                #line hidden
            }
            
            public System.Exception ValueType___Expr6Get() {
                this.GetValueTypeValues();
                return this.@__Expr6Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr7GetTree() {
                
                #line 147 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                customerCreditProfileRequestModel.CustomerId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr7Get() {
                
                #line 147 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                customerCreditProfileRequestModel.CustomerId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr7Get() {
                this.GetValueTypeValues();
                return this.@__Expr7Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr9GetTree() {
                
                #line 159 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                individualCustomer == null;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr9Get() {
                
                #line 159 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                individualCustomer == null;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr9Get() {
                this.GetValueTypeValues();
                return this.@__Expr9Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr10GetTree() {
                
                #line 216 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                    individualCustomer.StatusCode.Value != ((int)contact_statuscode.Active);
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr10Get() {
                
                #line 216 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                    individualCustomer.StatusCode.Value != ((int)contact_statuscode.Active);
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr10Get() {
                this.GetValueTypeValues();
                return this.@__Expr10Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr11GetTree() {
                
                #line 201 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Exception>> expression = () => 
                                                    new Exception(translations["CustomerCreditProfilePSB"].Where(t => t.Key == "tCustomerStatusMessage").Select(t => t.Value).FirstOrDefault().ToString());
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Exception @__Expr11Get() {
                
                #line 201 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                                    new Exception(translations["CustomerCreditProfilePSB"].Where(t => t.Key == "tCustomerStatusMessage").Select(t => t.Value).FirstOrDefault().ToString());
                
                #line default
                #line hidden
            }
            
            public System.Exception ValueType___Expr11Get() {
                this.GetValueTypeValues();
                return this.@__Expr11Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr12GetTree() {
                
                #line 171 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                        customerCreditProfileRequestModel.CustomerId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr12Get() {
                
                #line 171 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                        customerCreditProfileRequestModel.CustomerId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr12Get() {
                this.GetValueTypeValues();
                return this.@__Expr12Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr14GetTree() {
                
                #line 178 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                        corporateCustomer == null;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr14Get() {
                
                #line 178 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                        corporateCustomer == null;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr14Get() {
                this.GetValueTypeValues();
                return this.@__Expr14Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr15GetTree() {
                
                #line 194 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                            corporateCustomer.StatusCode.Value != ((int)contact_statuscode.Active);
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr15Get() {
                
                #line 194 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                            corporateCustomer.StatusCode.Value != ((int)contact_statuscode.Active);
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr15Get() {
                this.GetValueTypeValues();
                return this.@__Expr15Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr16GetTree() {
                
                #line 185 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Exception>> expression = () => 
                                                new Exception(translations["CustomerCreditProfilePSB"].Where(t => t.Key == "tCustomerCouldNotFound").Select(t => t.Value).FirstOrDefault().ToString());
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Exception @__Expr16Get() {
                
                #line 185 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                                new Exception(translations["CustomerCreditProfilePSB"].Where(t => t.Key == "tCustomerCouldNotFound").Select(t => t.Value).FirstOrDefault().ToString());
                
                #line default
                #line hidden
            }
            
            public System.Exception ValueType___Expr16Get() {
                this.GetValueTypeValues();
                return this.@__Expr16Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr17GetTree() {
                
                #line 239 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.IEnumerable<ExternalApiActivities.Models.CustomerCreditProfileModel>>> expression = () => 
                          customerCreditProfileRequestModel.CustomerCreditProfiles;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.IEnumerable<ExternalApiActivities.Models.CustomerCreditProfileModel> @__Expr17Get() {
                
                #line 239 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                          customerCreditProfileRequestModel.CustomerCreditProfiles;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.IEnumerable<ExternalApiActivities.Models.CustomerCreditProfileModel> ValueType___Expr17Get() {
                this.GetValueTypeValues();
                return this.@__Expr17Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr37GetTree() {
                
                #line 671 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                          connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr37Get() {
                
                #line 671 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                          connectionString;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr37Get() {
                this.GetValueTypeValues();
                return this.@__Expr37Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr38GetTree() {
                
                #line 436 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.IEnumerable<ExternalApiActivities.Models.CustomerCreditProfileModel>>> expression = () => 
                              customerCreditProfileRequestModel.CustomerCreditProfiles;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.IEnumerable<ExternalApiActivities.Models.CustomerCreditProfileModel> @__Expr38Get() {
                
                #line 436 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                              customerCreditProfileRequestModel.CustomerCreditProfiles;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.IEnumerable<ExternalApiActivities.Models.CustomerCreditProfileModel> ValueType___Expr38Get() {
                this.GetValueTypeValues();
                return this.@__Expr38Get();
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
                if (((locationReferences[(offset + 1)].Name != "connectionString") 
                            || (locationReferences[(offset + 1)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 2)].Name != "creditProfileEntity") 
                            || (locationReferences[(offset + 2)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.etel_creditprofile)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "creditProfilecontext") 
                            || (locationReferences[(offset + 3)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.XrmDataContext)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "translations") 
                            || (locationReferences[(offset + 4)].Type != typeof(System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 5)].Name != "individualCustomer") 
                            || (locationReferences[(offset + 5)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.Contact)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "corporateCustomer") 
                            || (locationReferences[(offset + 6)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.Account)))) {
                    return false;
                }
                return UpdateCustomerProfile_TypedDataContext1_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class UpdateCustomerProfile_TypedDataContext3 : UpdateCustomerProfile_TypedDataContext2 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public UpdateCustomerProfile_TypedDataContext3(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateCustomerProfile_TypedDataContext3(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateCustomerProfile_TypedDataContext3(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected ExternalApiActivities.Models.CustomerCreditProfileModel customerCreditProfileModel {
                get {
                    return ((ExternalApiActivities.Models.CustomerCreditProfileModel)(this.GetVariableValue((7 + locationsOffset))));
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
            
            internal System.Linq.Expressions.Expression @__Expr19GetTree() {
                
                #line 258 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                      customerCreditProfileModel.IsError;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr19Get() {
                
                #line 258 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                      customerCreditProfileModel.IsError;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr19Get() {
                this.GetValueTypeValues();
                return this.@__Expr19Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr19Set(bool value) {
                
                #line 258 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                
                                      customerCreditProfileModel.IsError = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr19Set(bool value) {
                this.GetValueTypeValues();
                this.@__Expr19Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr21GetTree() {
                
                #line 268 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                      customerCreditProfileModel.ErrorDescription;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr21Get() {
                
                #line 268 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                      customerCreditProfileModel.ErrorDescription;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr21Get() {
                this.GetValueTypeValues();
                return this.@__Expr21Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr21Set(string value) {
                
                #line 268 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                
                                      customerCreditProfileModel.ErrorDescription = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr21Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr21Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr23GetTree() {
                
                #line 291 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                      customerCreditProfileModel.IsError;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr23Get() {
                
                #line 291 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                      customerCreditProfileModel.IsError;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr23Get() {
                this.GetValueTypeValues();
                return this.@__Expr23Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr23Set(bool value) {
                
                #line 291 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                
                                      customerCreditProfileModel.IsError = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr23Set(bool value) {
                this.GetValueTypeValues();
                this.@__Expr23Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr25GetTree() {
                
                #line 301 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                      customerCreditProfileModel.ErrorDescription;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr25Get() {
                
                #line 301 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                      customerCreditProfileModel.ErrorDescription;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr25Get() {
                this.GetValueTypeValues();
                return this.@__Expr25Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr25Set(string value) {
                
                #line 301 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                
                                      customerCreditProfileModel.ErrorDescription = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr25Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr25Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr27GetTree() {
                
                #line 324 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                      customerCreditProfileModel.IsError;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr27Get() {
                
                #line 324 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                      customerCreditProfileModel.IsError;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr27Get() {
                this.GetValueTypeValues();
                return this.@__Expr27Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr27Set(bool value) {
                
                #line 324 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                
                                      customerCreditProfileModel.IsError = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr27Set(bool value) {
                this.GetValueTypeValues();
                this.@__Expr27Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr29GetTree() {
                
                #line 334 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                      customerCreditProfileModel.ErrorDescription;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr29Get() {
                
                #line 334 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                      customerCreditProfileModel.ErrorDescription;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr29Get() {
                this.GetValueTypeValues();
                return this.@__Expr29Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr29Set(string value) {
                
                #line 334 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                
                                      customerCreditProfileModel.ErrorDescription = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr29Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr29Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr31GetTree() {
                
                #line 360 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                                customerCreditProfileModel.IsError;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr31Get() {
                
                #line 360 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                                customerCreditProfileModel.IsError;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr31Get() {
                this.GetValueTypeValues();
                return this.@__Expr31Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr31Set(bool value) {
                
                #line 360 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                
                                                customerCreditProfileModel.IsError = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr31Set(bool value) {
                this.GetValueTypeValues();
                this.@__Expr31Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr32GetTree() {
                
                #line 370 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                customerCreditProfileModel.ErrorDescription;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr32Get() {
                
                #line 370 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                                customerCreditProfileModel.ErrorDescription;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr32Get() {
                this.GetValueTypeValues();
                return this.@__Expr32Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr32Set(string value) {
                
                #line 370 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                
                                                customerCreditProfileModel.ErrorDescription = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr32Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr32Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr34GetTree() {
                
                #line 397 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                      customerCreditProfileModel.IsError;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr34Get() {
                
                #line 397 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                      customerCreditProfileModel.IsError;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr34Get() {
                this.GetValueTypeValues();
                return this.@__Expr34Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr34Set(bool value) {
                
                #line 397 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                
                                      customerCreditProfileModel.IsError = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr34Set(bool value) {
                this.GetValueTypeValues();
                this.@__Expr34Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr36GetTree() {
                
                #line 407 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                      customerCreditProfileModel.ErrorDescription;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr36Get() {
                
                #line 407 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                      customerCreditProfileModel.ErrorDescription;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr36Get() {
                this.GetValueTypeValues();
                return this.@__Expr36Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr36Set(string value) {
                
                #line 407 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                
                                      customerCreditProfileModel.ErrorDescription = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr36Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr36Set(value);
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
                if (((locationReferences[(offset + 7)].Name != "customerCreditProfileModel") 
                            || (locationReferences[(offset + 7)].Type != typeof(ExternalApiActivities.Models.CustomerCreditProfileModel)))) {
                    return false;
                }
                return UpdateCustomerProfile_TypedDataContext2.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class UpdateCustomerProfile_TypedDataContext3_ForReadOnly : UpdateCustomerProfile_TypedDataContext2_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public UpdateCustomerProfile_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateCustomerProfile_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateCustomerProfile_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected ExternalApiActivities.Models.CustomerCreditProfileModel customerCreditProfileModel {
                get {
                    return ((ExternalApiActivities.Models.CustomerCreditProfileModel)(this.GetVariableValue((7 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr18GetTree() {
                
                #line 250 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                String.IsNullOrWhiteSpace(customerCreditProfileModel.CreditRiskRating);
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr18Get() {
                
                #line 250 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                String.IsNullOrWhiteSpace(customerCreditProfileModel.CreditRiskRating);
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr18Get() {
                this.GetValueTypeValues();
                return this.@__Expr18Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr20GetTree() {
                
                #line 273 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                      translations["CustomerCreditProfilePSB"].Where(t => t.Key == "tCreditRiskRatingRequiredMessage").Select(t => t.Value).FirstOrDefault().ToString();
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr20Get() {
                
                #line 273 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                      translations["CustomerCreditProfilePSB"].Where(t => t.Key == "tCreditRiskRatingRequiredMessage").Select(t => t.Value).FirstOrDefault().ToString();
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr20Get() {
                this.GetValueTypeValues();
                return this.@__Expr20Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr22GetTree() {
                
                #line 283 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                String.IsNullOrWhiteSpace(customerCreditProfileModel.CreditScore);
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr22Get() {
                
                #line 283 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                String.IsNullOrWhiteSpace(customerCreditProfileModel.CreditScore);
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr22Get() {
                this.GetValueTypeValues();
                return this.@__Expr22Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr24GetTree() {
                
                #line 306 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                      translations["CustomerCreditProfilePSB"].Where(t => t.Key == "tCreditScoreRequiredMessage").Select(t => t.Value).FirstOrDefault().ToString();
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr24Get() {
                
                #line 306 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                      translations["CustomerCreditProfilePSB"].Where(t => t.Key == "tCreditScoreRequiredMessage").Select(t => t.Value).FirstOrDefault().ToString();
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr24Get() {
                this.GetValueTypeValues();
                return this.@__Expr24Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr26GetTree() {
                
                #line 316 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                customerCreditProfileModel.StartDate == null;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr26Get() {
                
                #line 316 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                customerCreditProfileModel.StartDate == null;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr26Get() {
                this.GetValueTypeValues();
                return this.@__Expr26Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr28GetTree() {
                
                #line 339 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                      translations["CustomerCreditProfilePSB"].Where(t => t.Key == "tStartDateWarningMessage").Select(t => t.Value).FirstOrDefault().ToString();
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr28Get() {
                
                #line 339 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                      translations["CustomerCreditProfilePSB"].Where(t => t.Key == "tStartDateWarningMessage").Select(t => t.Value).FirstOrDefault().ToString();
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr28Get() {
                this.GetValueTypeValues();
                return this.@__Expr28Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr30GetTree() {
                
                #line 352 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                          customerCreditProfileModel.StartDate>customerCreditProfileModel.EndDate;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr30Get() {
                
                #line 352 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                          customerCreditProfileModel.StartDate>customerCreditProfileModel.EndDate;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr30Get() {
                this.GetValueTypeValues();
                return this.@__Expr30Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr33GetTree() {
                
                #line 389 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                customerCreditProfileModel.EndDate == null;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr33Get() {
                
                #line 389 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                customerCreditProfileModel.EndDate == null;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr33Get() {
                this.GetValueTypeValues();
                return this.@__Expr33Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr35GetTree() {
                
                #line 412 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                      translations["CustomerCreditProfilePSB"].Where(t => t.Key == "tEndDateWarningMessage").Select(t => t.Value).FirstOrDefault().ToString();
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr35Get() {
                
                #line 412 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                      translations["CustomerCreditProfilePSB"].Where(t => t.Key == "tEndDateWarningMessage").Select(t => t.Value).FirstOrDefault().ToString();
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr35Get() {
                this.GetValueTypeValues();
                return this.@__Expr35Get();
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
                if (((locationReferences[(offset + 7)].Name != "customerCreditProfileModel") 
                            || (locationReferences[(offset + 7)].Type != typeof(ExternalApiActivities.Models.CustomerCreditProfileModel)))) {
                    return false;
                }
                return UpdateCustomerProfile_TypedDataContext2_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class UpdateCustomerProfile_TypedDataContext4 : UpdateCustomerProfile_TypedDataContext2 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public UpdateCustomerProfile_TypedDataContext4(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateCustomerProfile_TypedDataContext4(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateCustomerProfile_TypedDataContext4(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected ExternalApiActivities.Models.CustomerCreditProfileModel customerCreditProfileModel {
                get {
                    return ((ExternalApiActivities.Models.CustomerCreditProfileModel)(this.GetVariableValue((7 + locationsOffset))));
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
            
            internal System.Linq.Expressions.Expression @__Expr40GetTree() {
                
                #line 452 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<Ericsson.ETELCRM.Entities.Crm.etel_creditprofile>> expression = () => 
                                    creditProfileEntity;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Ericsson.ETELCRM.Entities.Crm.etel_creditprofile @__Expr40Get() {
                
                #line 452 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                    creditProfileEntity;
                
                #line default
                #line hidden
            }
            
            public Ericsson.ETELCRM.Entities.Crm.etel_creditprofile ValueType___Expr40Get() {
                this.GetValueTypeValues();
                return this.@__Expr40Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr40Set(Ericsson.ETELCRM.Entities.Crm.etel_creditprofile value) {
                
                #line 452 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                
                                    creditProfileEntity = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr40Set(Ericsson.ETELCRM.Entities.Crm.etel_creditprofile value) {
                this.GetValueTypeValues();
                this.@__Expr40Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr43GetTree() {
                
                #line 504 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                                      customerCreditProfileModel.IsError;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr43Get() {
                
                #line 504 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                                      customerCreditProfileModel.IsError;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr43Get() {
                this.GetValueTypeValues();
                return this.@__Expr43Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr43Set(bool value) {
                
                #line 504 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                
                                                      customerCreditProfileModel.IsError = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr43Set(bool value) {
                this.GetValueTypeValues();
                this.@__Expr43Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr45GetTree() {
                
                #line 514 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                      customerCreditProfileModel.ErrorDescription;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr45Get() {
                
                #line 514 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                                      customerCreditProfileModel.ErrorDescription;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr45Get() {
                this.GetValueTypeValues();
                return this.@__Expr45Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr45Set(string value) {
                
                #line 514 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                
                                                      customerCreditProfileModel.ErrorDescription = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr45Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr45Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr48GetTree() {
                
                #line 549 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                                                customerCreditProfileModel.IsError;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr48Get() {
                
                #line 549 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                                                customerCreditProfileModel.IsError;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr48Get() {
                this.GetValueTypeValues();
                return this.@__Expr48Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr48Set(bool value) {
                
                #line 549 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                
                                                                customerCreditProfileModel.IsError = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr48Set(bool value) {
                this.GetValueTypeValues();
                this.@__Expr48Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr50GetTree() {
                
                #line 559 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                                customerCreditProfileModel.ErrorDescription;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr50Get() {
                
                #line 559 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                                                customerCreditProfileModel.ErrorDescription;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr50Get() {
                this.GetValueTypeValues();
                return this.@__Expr50Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr50Set(string value) {
                
                #line 559 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                
                                                                customerCreditProfileModel.ErrorDescription = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr50Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr50Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr52GetTree() {
                
                #line 585 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                                              customerCreditProfileModel.IsError;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr52Get() {
                
                #line 585 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                                              customerCreditProfileModel.IsError;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr52Get() {
                this.GetValueTypeValues();
                return this.@__Expr52Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr52Set(bool value) {
                
                #line 585 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                
                                                              customerCreditProfileModel.IsError = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr52Set(bool value) {
                this.GetValueTypeValues();
                this.@__Expr52Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr54GetTree() {
                
                #line 595 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                              customerCreditProfileModel.ErrorDescription;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr54Get() {
                
                #line 595 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                                              customerCreditProfileModel.ErrorDescription;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr54Get() {
                this.GetValueTypeValues();
                return this.@__Expr54Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr54Set(string value) {
                
                #line 595 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                
                                                              customerCreditProfileModel.ErrorDescription = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr54Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr54Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr55GetTree() {
                
                #line 468 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                                customerCreditProfileModel.IsError;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr55Get() {
                
                #line 468 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                                customerCreditProfileModel.IsError;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr55Get() {
                this.GetValueTypeValues();
                return this.@__Expr55Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr55Set(bool value) {
                
                #line 468 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                
                                                customerCreditProfileModel.IsError = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr55Set(bool value) {
                this.GetValueTypeValues();
                this.@__Expr55Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr57GetTree() {
                
                #line 478 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                customerCreditProfileModel.ErrorDescription;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr57Get() {
                
                #line 478 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                                customerCreditProfileModel.ErrorDescription;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr57Get() {
                this.GetValueTypeValues();
                return this.@__Expr57Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr57Set(string value) {
                
                #line 478 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                
                                                customerCreditProfileModel.ErrorDescription = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr57Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr57Set(value);
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
                if (((locationReferences[(offset + 7)].Name != "customerCreditProfileModel") 
                            || (locationReferences[(offset + 7)].Type != typeof(ExternalApiActivities.Models.CustomerCreditProfileModel)))) {
                    return false;
                }
                return UpdateCustomerProfile_TypedDataContext2.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class UpdateCustomerProfile_TypedDataContext4_ForReadOnly : UpdateCustomerProfile_TypedDataContext2_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public UpdateCustomerProfile_TypedDataContext4_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateCustomerProfile_TypedDataContext4_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateCustomerProfile_TypedDataContext4_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected ExternalApiActivities.Models.CustomerCreditProfileModel customerCreditProfileModel {
                get {
                    return ((ExternalApiActivities.Models.CustomerCreditProfileModel)(this.GetVariableValue((7 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr39GetTree() {
                
                #line 447 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Linq.Expressions.Expression<System.Func<Ericsson.ETELCRM.Entities.Crm.etel_creditprofile, bool>>>> expression = () => 
                                    f => f.etel_name == customerCreditProfileModel.CreditProfileNumber;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Linq.Expressions.Expression<System.Func<Ericsson.ETELCRM.Entities.Crm.etel_creditprofile, bool>> @__Expr39Get() {
                
                #line 447 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                    f => f.etel_name == customerCreditProfileModel.CreditProfileNumber;
                
                #line default
                #line hidden
            }
            
            public System.Linq.Expressions.Expression<System.Func<Ericsson.ETELCRM.Entities.Crm.etel_creditprofile, bool>> ValueType___Expr39Get() {
                this.GetValueTypeValues();
                return this.@__Expr39Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr41GetTree() {
                
                #line 460 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                      creditProfileEntity == null;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr41Get() {
                
                #line 460 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                      creditProfileEntity == null;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr41Get() {
                this.GetValueTypeValues();
                return this.@__Expr41Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr42GetTree() {
                
                #line 496 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                                customerCreditProfileModel.StartDate!=null && (creditProfileEntity.etel_startdate.Value.ToUniversalTime().Date != DateTime.SpecifyKind(customerCreditProfileModel.StartDate.Value, DateTimeKind.Utc).Date);
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr42Get() {
                
                #line 496 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                                customerCreditProfileModel.StartDate!=null && (creditProfileEntity.etel_startdate.Value.ToUniversalTime().Date != DateTime.SpecifyKind(customerCreditProfileModel.StartDate.Value, DateTimeKind.Utc).Date);
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr42Get() {
                this.GetValueTypeValues();
                return this.@__Expr42Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr44GetTree() {
                
                #line 519 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                      translations["CustomerCreditProfilePSB"].Where(t => t.Key == "tStartDateUpdateMessage").Select(t => t.Value).FirstOrDefault().ToString();
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr44Get() {
                
                #line 519 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                                      translations["CustomerCreditProfilePSB"].Where(t => t.Key == "tStartDateUpdateMessage").Select(t => t.Value).FirstOrDefault().ToString();
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr44Get() {
                this.GetValueTypeValues();
                return this.@__Expr44Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr46GetTree() {
                
                #line 533 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                                    individualCustomer != null;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr46Get() {
                
                #line 533 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                                    individualCustomer != null;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr46Get() {
                this.GetValueTypeValues();
                return this.@__Expr46Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr47GetTree() {
                
                #line 541 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                                          (creditProfileEntity.etel_individualid == null )|| (creditProfileEntity.etel_individualid != null && individualCustomer.Id != creditProfileEntity.etel_individualid.Id);
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr47Get() {
                
                #line 541 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                                          (creditProfileEntity.etel_individualid == null )|| (creditProfileEntity.etel_individualid != null && individualCustomer.Id != creditProfileEntity.etel_individualid.Id);
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr47Get() {
                this.GetValueTypeValues();
                return this.@__Expr47Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr49GetTree() {
                
                #line 564 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                                translations["CustomerCreditProfilePSB"].Where(t => t.Key == "tCreditProfileControlMessage").Select(t => t.Value).FirstOrDefault().ToString();
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr49Get() {
                
                #line 564 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                                                translations["CustomerCreditProfilePSB"].Where(t => t.Key == "tCreditProfileControlMessage").Select(t => t.Value).FirstOrDefault().ToString();
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr49Get() {
                this.GetValueTypeValues();
                return this.@__Expr49Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr51GetTree() {
                
                #line 577 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                                        (creditProfileEntity.etel_corporateid == null) || (creditProfileEntity.etel_corporateid != null && corporateCustomer.Id != creditProfileEntity.etel_corporateid.Id);
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr51Get() {
                
                #line 577 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                                        (creditProfileEntity.etel_corporateid == null) || (creditProfileEntity.etel_corporateid != null && corporateCustomer.Id != creditProfileEntity.etel_corporateid.Id);
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr51Get() {
                this.GetValueTypeValues();
                return this.@__Expr51Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr53GetTree() {
                
                #line 600 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                              translations["CustomerCreditProfilePSB"].Where(t => t.Key == "tCreditProfileControlMessage").Select(t => t.Value).FirstOrDefault().ToString();
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr53Get() {
                
                #line 600 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                                              translations["CustomerCreditProfilePSB"].Where(t => t.Key == "tCreditProfileControlMessage").Select(t => t.Value).FirstOrDefault().ToString();
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr53Get() {
                this.GetValueTypeValues();
                return this.@__Expr53Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr56GetTree() {
                
                #line 483 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                translations["CustomerCreditProfilePSB"].Where(t => t.Key == "tCreditProfileNumberInvalidMessage").Select(t => t.Value).FirstOrDefault().ToString();
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr56Get() {
                
                #line 483 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                                translations["CustomerCreditProfilePSB"].Where(t => t.Key == "tCreditProfileNumberInvalidMessage").Select(t => t.Value).FirstOrDefault().ToString();
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr56Get() {
                this.GetValueTypeValues();
                return this.@__Expr56Get();
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
                if (((locationReferences[(offset + 7)].Name != "customerCreditProfileModel") 
                            || (locationReferences[(offset + 7)].Type != typeof(ExternalApiActivities.Models.CustomerCreditProfileModel)))) {
                    return false;
                }
                return UpdateCustomerProfile_TypedDataContext2_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class UpdateCustomerProfile_TypedDataContext5 : UpdateCustomerProfile_TypedDataContext4 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public UpdateCustomerProfile_TypedDataContext5(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateCustomerProfile_TypedDataContext5(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateCustomerProfile_TypedDataContext5(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.etel_bicreditprofileupdate creditProfileUpdateBIEntity {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.etel_bicreditprofileupdate)(this.GetVariableValue((8 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((8 + locationsOffset), value);
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
                            && (locationReferences.Count < 9))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 9);
                }
                expectedLocationsCount = 9;
                if (((locationReferences[(offset + 8)].Name != "creditProfileUpdateBIEntity") 
                            || (locationReferences[(offset + 8)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.etel_bicreditprofileupdate)))) {
                    return false;
                }
                return UpdateCustomerProfile_TypedDataContext4.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class UpdateCustomerProfile_TypedDataContext5_ForReadOnly : UpdateCustomerProfile_TypedDataContext4_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public UpdateCustomerProfile_TypedDataContext5_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateCustomerProfile_TypedDataContext5_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public UpdateCustomerProfile_TypedDataContext5_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.etel_bicreditprofileupdate creditProfileUpdateBIEntity {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.etel_bicreditprofileupdate)(this.GetVariableValue((8 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr58GetTree() {
                
                #line 625 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<Ericsson.ETELCRM.Entities.Crm.etel_bicreditprofileupdate>> expression = () => 
                                      new etel_bicreditprofileupdate();
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Ericsson.ETELCRM.Entities.Crm.etel_bicreditprofileupdate @__Expr58Get() {
                
                #line 625 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                      new etel_bicreditprofileupdate();
                
                #line default
                #line hidden
            }
            
            public Ericsson.ETELCRM.Entities.Crm.etel_bicreditprofileupdate ValueType___Expr58Get() {
                this.GetValueTypeValues();
                return this.@__Expr58Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr59GetTree() {
                
                #line 632 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                      customerCreditProfileModel.IsError!=true;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr59Get() {
                
                #line 632 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                      customerCreditProfileModel.IsError!=true;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr59Get() {
                this.GetValueTypeValues();
                return this.@__Expr59Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr60GetTree() {
                
                #line 654 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<Ericsson.ETELCRM.Entities.Crm.ICustomer>> expression = () => 
                                              (ICustomer)individualCustomer ?? corporateCustomer;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Ericsson.ETELCRM.Entities.Crm.ICustomer @__Expr60Get() {
                
                #line 654 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                              (ICustomer)individualCustomer ?? corporateCustomer;
                
                #line default
                #line hidden
            }
            
            public Ericsson.ETELCRM.Entities.Crm.ICustomer ValueType___Expr60Get() {
                this.GetValueTypeValues();
                return this.@__Expr60Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr61GetTree() {
                
                #line 639 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<Ericsson.ETELCRM.Entities.Crm.etel_creditprofile>> expression = () => 
                                              creditProfileEntity;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Ericsson.ETELCRM.Entities.Crm.etel_creditprofile @__Expr61Get() {
                
                #line 639 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                              creditProfileEntity;
                
                #line default
                #line hidden
            }
            
            public Ericsson.ETELCRM.Entities.Crm.etel_creditprofile ValueType___Expr61Get() {
                this.GetValueTypeValues();
                return this.@__Expr61Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr62GetTree() {
                
                #line 644 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<ExternalApiActivities.Models.CustomerCreditProfileModel>> expression = () => 
                                              customerCreditProfileModel;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public ExternalApiActivities.Models.CustomerCreditProfileModel @__Expr62Get() {
                
                #line 644 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                              customerCreditProfileModel;
                
                #line default
                #line hidden
            }
            
            public ExternalApiActivities.Models.CustomerCreditProfileModel ValueType___Expr62Get() {
                this.GetValueTypeValues();
                return this.@__Expr62Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr63GetTree() {
                
                #line 649 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                System.Linq.Expressions.Expression<System.Func<Ericsson.ETELCRM.Entities.Crm.etel_bicreditprofileupdate>> expression = () => 
                                              creditProfileUpdateBIEntity;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Ericsson.ETELCRM.Entities.Crm.etel_bicreditprofileupdate @__Expr63Get() {
                
                #line 649 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\UPDATECUSTOMERCREDITPROFILE.XAML"
                return 
                                              creditProfileUpdateBIEntity;
                
                #line default
                #line hidden
            }
            
            public Ericsson.ETELCRM.Entities.Crm.etel_bicreditprofileupdate ValueType___Expr63Get() {
                this.GetValueTypeValues();
                return this.@__Expr63Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 9))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 9);
                }
                expectedLocationsCount = 9;
                if (((locationReferences[(offset + 8)].Name != "creditProfileUpdateBIEntity") 
                            || (locationReferences[(offset + 8)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.etel_bicreditprofileupdate)))) {
                    return false;
                }
                return UpdateCustomerProfile_TypedDataContext4_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
    }
}

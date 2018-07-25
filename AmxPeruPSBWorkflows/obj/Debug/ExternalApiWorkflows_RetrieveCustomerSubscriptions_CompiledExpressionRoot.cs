namespace ExternalApiWorkflows {
    
    #line 28 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\RetrieveCustomerSubscriptions.xaml"
    using System;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\RetrieveCustomerSubscriptions.xaml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 29 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\RetrieveCustomerSubscriptions.xaml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\RetrieveCustomerSubscriptions.xaml"
    using System.Activities;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\RetrieveCustomerSubscriptions.xaml"
    using System.Activities.Expressions;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\RetrieveCustomerSubscriptions.xaml"
    using System.Activities.Statements;
    
    #line default
    #line hidden
    
    #line 30 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\RetrieveCustomerSubscriptions.xaml"
    using System.Data;
    
    #line default
    #line hidden
    
    #line 31 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\RetrieveCustomerSubscriptions.xaml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 32 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\RetrieveCustomerSubscriptions.xaml"
    using System.Text;
    
    #line default
    #line hidden
    
    #line 33 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\RetrieveCustomerSubscriptions.xaml"
    using ExternalApiActivities.Models;
    
    #line default
    #line hidden
    
    #line 34 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\RetrieveCustomerSubscriptions.xaml"
    using Ericsson.ETELCRM.CrmFoundationLibrary.ServiceClient.Entities;
    
    #line default
    #line hidden
    
    #line 35 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\RetrieveCustomerSubscriptions.xaml"
    using Ericsson.ETELCRM.Entities.Crm;
    
    #line default
    #line hidden
    
    #line 36 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\RetrieveCustomerSubscriptions.xaml"
    using Ericsson.ETELCRM.Entities.Crm.CustomEntities;
    
    #line default
    #line hidden
    
    #line 37 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\RetrieveCustomerSubscriptions.xaml"
    using AmxPeruPSBActivities.Model;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\RetrieveCustomerSubscriptions.xaml"
    using System.Activities.XamlIntegration;
    
    #line default
    #line hidden
    
    
    public partial class RetrieveCustomerSubscriptions : System.Activities.XamlIntegration.ICompiledExpressionRoot {
        
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
                this.dataContextActivities = RetrieveCustomerSubscriptions_TypedDataContext2.GetDataContextActivitiesHelper(this.rootActivity, this.forImplementation);
            }
            if ((expressionId == 0)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new RetrieveCustomerSubscriptions_TypedDataContext2(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext2 refDataContext0 = ((RetrieveCustomerSubscriptions_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 1)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new RetrieveCustomerSubscriptions_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext2_ForReadOnly valDataContext1 = ((RetrieveCustomerSubscriptions_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext2 = ((RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext2.ValueType___Expr2Get();
            }
            if ((expressionId == 3)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new RetrieveCustomerSubscriptions_TypedDataContext3(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext3 refDataContext3 = ((RetrieveCustomerSubscriptions_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext3.GetLocation<System.DateTime>(refDataContext3.ValueType___Expr3Get, refDataContext3.ValueType___Expr3Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 4)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext4 = ((RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext4.ValueType___Expr4Get();
            }
            if ((expressionId == 5)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new RetrieveCustomerSubscriptions_TypedDataContext3(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext3 refDataContext5 = ((RetrieveCustomerSubscriptions_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext5.GetLocation<System.DateTime>(refDataContext5.ValueType___Expr5Get, refDataContext5.ValueType___Expr5Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 6)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext6 = ((RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new RetrieveCustomerSubscriptions_TypedDataContext3(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext3 refDataContext7 = ((RetrieveCustomerSubscriptions_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext7.GetLocation<Ericsson.ETELCRM.Entities.Crm.Contact>(refDataContext7.ValueType___Expr7Get, refDataContext7.ValueType___Expr7Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 8)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext8 = ((RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext8.ValueType___Expr8Get();
            }
            if ((expressionId == 9)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext9 = ((RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext9.ValueType___Expr9Get();
            }
            if ((expressionId == 10)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext10 = ((RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext11 = ((RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext11.ValueType___Expr11Get();
            }
            if ((expressionId == 12)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new RetrieveCustomerSubscriptions_TypedDataContext3(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext3 refDataContext12 = ((RetrieveCustomerSubscriptions_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext12.GetLocation<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_subscription>>(refDataContext12.ValueType___Expr12Get, refDataContext12.ValueType___Expr12Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 13)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new RetrieveCustomerSubscriptions_TypedDataContext3(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext3 refDataContext13 = ((RetrieveCustomerSubscriptions_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext13.GetLocation<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>>(refDataContext13.ValueType___Expr13Get, refDataContext13.ValueType___Expr13Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 14)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext14 = ((RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext14.ValueType___Expr14Get();
            }
            if ((expressionId == 15)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext15 = ((RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext15.ValueType___Expr15Get();
            }
            if ((expressionId == 16)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext16 = ((RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext16.ValueType___Expr16Get();
            }
            if ((expressionId == 17)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new RetrieveCustomerSubscriptions_TypedDataContext3(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext3 refDataContext17 = ((RetrieveCustomerSubscriptions_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext17.GetLocation<System.Collections.Generic.List<ExternalApiActivities.Models.CustomerSubscriptionsModel>>(refDataContext17.ValueType___Expr17Get, refDataContext17.ValueType___Expr17Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 18)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext18 = ((RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext18.ValueType___Expr18Get();
            }
            if ((expressionId == 19)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly valDataContext19 = ((RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext19.ValueType___Expr19Get();
            }
            if ((expressionId == 20)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext5.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new RetrieveCustomerSubscriptions_TypedDataContext5(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext5 refDataContext20 = ((RetrieveCustomerSubscriptions_TypedDataContext5)(cachedCompiledDataContext[5]));
                return refDataContext20.GetLocation<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>(refDataContext20.ValueType___Expr20Get, refDataContext20.ValueType___Expr20Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 21)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly valDataContext21 = ((RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext21.ValueType___Expr21Get();
            }
            if ((expressionId == 22)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly valDataContext22 = ((RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext22.ValueType___Expr22Get();
            }
            if ((expressionId == 23)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext23 = ((RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext23.ValueType___Expr23Get();
            }
            if ((expressionId == 24)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new RetrieveCustomerSubscriptions_TypedDataContext3(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext3 refDataContext24 = ((RetrieveCustomerSubscriptions_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext24.GetLocation<Ericsson.ETELCRM.Entities.Crm.Account>(refDataContext24.ValueType___Expr24Get, refDataContext24.ValueType___Expr24Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 25)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext25 = ((RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext25.ValueType___Expr25Get();
            }
            if ((expressionId == 26)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext26 = ((RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext26.ValueType___Expr26Get();
            }
            if ((expressionId == 27)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext27 = ((RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext27.ValueType___Expr27Get();
            }
            if ((expressionId == 28)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext28 = ((RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext28.ValueType___Expr28Get();
            }
            if ((expressionId == 29)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new RetrieveCustomerSubscriptions_TypedDataContext3(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext3 refDataContext29 = ((RetrieveCustomerSubscriptions_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext29.GetLocation<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_subscription>>(refDataContext29.ValueType___Expr29Get, refDataContext29.ValueType___Expr29Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 30)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 6);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext30 = ((RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext30.ValueType___Expr30Get();
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
                RetrieveCustomerSubscriptions_TypedDataContext2 refDataContext0 = new RetrieveCustomerSubscriptions_TypedDataContext2(locations, true);
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set);
            }
            if ((expressionId == 1)) {
                RetrieveCustomerSubscriptions_TypedDataContext2_ForReadOnly valDataContext1 = new RetrieveCustomerSubscriptions_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext2 = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext2.ValueType___Expr2Get();
            }
            if ((expressionId == 3)) {
                RetrieveCustomerSubscriptions_TypedDataContext3 refDataContext3 = new RetrieveCustomerSubscriptions_TypedDataContext3(locations, true);
                return refDataContext3.GetLocation<System.DateTime>(refDataContext3.ValueType___Expr3Get, refDataContext3.ValueType___Expr3Set);
            }
            if ((expressionId == 4)) {
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext4 = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext4.ValueType___Expr4Get();
            }
            if ((expressionId == 5)) {
                RetrieveCustomerSubscriptions_TypedDataContext3 refDataContext5 = new RetrieveCustomerSubscriptions_TypedDataContext3(locations, true);
                return refDataContext5.GetLocation<System.DateTime>(refDataContext5.ValueType___Expr5Get, refDataContext5.ValueType___Expr5Set);
            }
            if ((expressionId == 6)) {
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext6 = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                RetrieveCustomerSubscriptions_TypedDataContext3 refDataContext7 = new RetrieveCustomerSubscriptions_TypedDataContext3(locations, true);
                return refDataContext7.GetLocation<Ericsson.ETELCRM.Entities.Crm.Contact>(refDataContext7.ValueType___Expr7Get, refDataContext7.ValueType___Expr7Set);
            }
            if ((expressionId == 8)) {
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext8 = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext8.ValueType___Expr8Get();
            }
            if ((expressionId == 9)) {
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext9 = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext9.ValueType___Expr9Get();
            }
            if ((expressionId == 10)) {
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext10 = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext11 = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext11.ValueType___Expr11Get();
            }
            if ((expressionId == 12)) {
                RetrieveCustomerSubscriptions_TypedDataContext3 refDataContext12 = new RetrieveCustomerSubscriptions_TypedDataContext3(locations, true);
                return refDataContext12.GetLocation<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_subscription>>(refDataContext12.ValueType___Expr12Get, refDataContext12.ValueType___Expr12Set);
            }
            if ((expressionId == 13)) {
                RetrieveCustomerSubscriptions_TypedDataContext3 refDataContext13 = new RetrieveCustomerSubscriptions_TypedDataContext3(locations, true);
                return refDataContext13.GetLocation<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>>(refDataContext13.ValueType___Expr13Get, refDataContext13.ValueType___Expr13Set);
            }
            if ((expressionId == 14)) {
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext14 = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext14.ValueType___Expr14Get();
            }
            if ((expressionId == 15)) {
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext15 = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext15.ValueType___Expr15Get();
            }
            if ((expressionId == 16)) {
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext16 = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext16.ValueType___Expr16Get();
            }
            if ((expressionId == 17)) {
                RetrieveCustomerSubscriptions_TypedDataContext3 refDataContext17 = new RetrieveCustomerSubscriptions_TypedDataContext3(locations, true);
                return refDataContext17.GetLocation<System.Collections.Generic.List<ExternalApiActivities.Models.CustomerSubscriptionsModel>>(refDataContext17.ValueType___Expr17Get, refDataContext17.ValueType___Expr17Set);
            }
            if ((expressionId == 18)) {
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext18 = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext18.ValueType___Expr18Get();
            }
            if ((expressionId == 19)) {
                RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly valDataContext19 = new RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly(locations, true);
                return valDataContext19.ValueType___Expr19Get();
            }
            if ((expressionId == 20)) {
                RetrieveCustomerSubscriptions_TypedDataContext5 refDataContext20 = new RetrieveCustomerSubscriptions_TypedDataContext5(locations, true);
                return refDataContext20.GetLocation<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>(refDataContext20.ValueType___Expr20Get, refDataContext20.ValueType___Expr20Set);
            }
            if ((expressionId == 21)) {
                RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly valDataContext21 = new RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly(locations, true);
                return valDataContext21.ValueType___Expr21Get();
            }
            if ((expressionId == 22)) {
                RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly valDataContext22 = new RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly(locations, true);
                return valDataContext22.ValueType___Expr22Get();
            }
            if ((expressionId == 23)) {
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext23 = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext23.ValueType___Expr23Get();
            }
            if ((expressionId == 24)) {
                RetrieveCustomerSubscriptions_TypedDataContext3 refDataContext24 = new RetrieveCustomerSubscriptions_TypedDataContext3(locations, true);
                return refDataContext24.GetLocation<Ericsson.ETELCRM.Entities.Crm.Account>(refDataContext24.ValueType___Expr24Get, refDataContext24.ValueType___Expr24Set);
            }
            if ((expressionId == 25)) {
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext25 = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext25.ValueType___Expr25Get();
            }
            if ((expressionId == 26)) {
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext26 = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext26.ValueType___Expr26Get();
            }
            if ((expressionId == 27)) {
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext27 = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext27.ValueType___Expr27Get();
            }
            if ((expressionId == 28)) {
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext28 = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext28.ValueType___Expr28Get();
            }
            if ((expressionId == 29)) {
                RetrieveCustomerSubscriptions_TypedDataContext3 refDataContext29 = new RetrieveCustomerSubscriptions_TypedDataContext3(locations, true);
                return refDataContext29.GetLocation<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_subscription>>(refDataContext29.ValueType___Expr29Get, refDataContext29.ValueType___Expr29Set);
            }
            if ((expressionId == 30)) {
                RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly valDataContext30 = new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext30.ValueType___Expr30Get();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool CanExecuteExpression(string expressionText, bool isReference, System.Collections.Generic.IList<System.Activities.LocationReference> locations, out int expressionId) {
            if (((isReference == true) 
                        && ((expressionText == "connectionString") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 0;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "connectionString") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 1;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "request.endDate == null ? DateTime.MinValue : request.endDate.AddMinutes(request." +
                            "orgTimezoneOffset).AddHours(23).AddMinutes(59).AddSeconds(59);") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 2;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "request.endDate") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 3;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "request.startDate == null ? DateTime.MinValue : request.startDate.AddMinutes(requ" +
                            "est.orgTimezoneOffset);") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 4;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "request.startDate") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 5;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "request.customerId") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 6;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "individualCustomer") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 7;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "individualCustomer == null") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 8;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "request.endDate") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 9;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "individualCustomer") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 10;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "request.startDate") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 11;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "subscriptionList") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 12;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "subStatusOptionSet") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 13;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "int.Parse(request.languagecode)") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 14;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "etel_subscription.EntityLogicalName") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 15;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new List<CustomerSubscriptionsModel>()") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 16;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "subscriptionlistmodel") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 17;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "subscriptionList") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 18;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "(subStatusOptionSet == null || item.etel_subscriptionstatuscode == null) ? null :" +
                            " subStatusOptionSet.FirstOrDefault(st => st.Value == item.etel_subscriptionstatu" +
                            "scode.Value)") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 19;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "op_statuscode") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext5.Validate(locations, true, 0) == true)))) {
                expressionId = 20;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "subscriptionlistmodel") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 21;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == @"new CustomCustomerSubscriptionsModel
            {
              SubscriptionId = item.etel_subscriptionId,
              Name = item.etel_name,
              ActivationDate = item.etel_activationdate.HasValue ? item.etel_activationdate.Value.AddMinutes(request.orgTimezoneOffset).ToString(""yyyy-MM-dd"") : string.Empty,
              CreatedON = item.CreatedOn.HasValue ? item.CreatedOn.Value.AddMinutes(request.orgTimezoneOffset).ToString(""yyyy-MM-dd HH:mm"") : string.Empty,
              ExternalId = item.etel_externalid,
              MSISDNSerialNo = item.etel_msisdnserialno,
              RatePlan = item.etel_rateplanid == null ? string.Empty : item.etel_rateplanid.Name,
              SubStatus = op_statuscode == null ? string.Empty : op_statuscode.Text,
              User = item.etel_individualuserid != null ? item.etel_individualuserid.Name : (item.etel_corporateuserid != null ? item.etel_corporateuserid.Name : string.Empty)
            }") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 22;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "request.customerId") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 23;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "corporateCustomer") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 24;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "corporateCustomer == null") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 25;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "request.endDate") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 26;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "corporateCustomer") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 27;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "request.startDate") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 28;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "subscriptionList") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 29;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new Exception(\"Customer Not Found!\")") 
                        && (RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 30;
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
                return new RetrieveCustomerSubscriptions_TypedDataContext2(locationReferences).@__Expr0GetTree();
            }
            if ((expressionId == 1)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext2_ForReadOnly(locationReferences).@__Expr1GetTree();
            }
            if ((expressionId == 2)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locationReferences).@__Expr2GetTree();
            }
            if ((expressionId == 3)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext3(locationReferences).@__Expr3GetTree();
            }
            if ((expressionId == 4)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locationReferences).@__Expr4GetTree();
            }
            if ((expressionId == 5)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext3(locationReferences).@__Expr5GetTree();
            }
            if ((expressionId == 6)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locationReferences).@__Expr6GetTree();
            }
            if ((expressionId == 7)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext3(locationReferences).@__Expr7GetTree();
            }
            if ((expressionId == 8)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locationReferences).@__Expr8GetTree();
            }
            if ((expressionId == 9)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locationReferences).@__Expr9GetTree();
            }
            if ((expressionId == 10)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locationReferences).@__Expr10GetTree();
            }
            if ((expressionId == 11)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locationReferences).@__Expr11GetTree();
            }
            if ((expressionId == 12)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext3(locationReferences).@__Expr12GetTree();
            }
            if ((expressionId == 13)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext3(locationReferences).@__Expr13GetTree();
            }
            if ((expressionId == 14)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locationReferences).@__Expr14GetTree();
            }
            if ((expressionId == 15)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locationReferences).@__Expr15GetTree();
            }
            if ((expressionId == 16)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locationReferences).@__Expr16GetTree();
            }
            if ((expressionId == 17)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext3(locationReferences).@__Expr17GetTree();
            }
            if ((expressionId == 18)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locationReferences).@__Expr18GetTree();
            }
            if ((expressionId == 19)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly(locationReferences).@__Expr19GetTree();
            }
            if ((expressionId == 20)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext5(locationReferences).@__Expr20GetTree();
            }
            if ((expressionId == 21)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly(locationReferences).@__Expr21GetTree();
            }
            if ((expressionId == 22)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly(locationReferences).@__Expr22GetTree();
            }
            if ((expressionId == 23)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locationReferences).@__Expr23GetTree();
            }
            if ((expressionId == 24)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext3(locationReferences).@__Expr24GetTree();
            }
            if ((expressionId == 25)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locationReferences).@__Expr25GetTree();
            }
            if ((expressionId == 26)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locationReferences).@__Expr26GetTree();
            }
            if ((expressionId == 27)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locationReferences).@__Expr27GetTree();
            }
            if ((expressionId == 28)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locationReferences).@__Expr28GetTree();
            }
            if ((expressionId == 29)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext3(locationReferences).@__Expr29GetTree();
            }
            if ((expressionId == 30)) {
                return new RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(locationReferences).@__Expr30GetTree();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class RetrieveCustomerSubscriptions_TypedDataContext0 : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public RetrieveCustomerSubscriptions_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveCustomerSubscriptions_TypedDataContext0(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveCustomerSubscriptions_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class RetrieveCustomerSubscriptions_TypedDataContext0_ForReadOnly : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public RetrieveCustomerSubscriptions_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveCustomerSubscriptions_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveCustomerSubscriptions_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class RetrieveCustomerSubscriptions_TypedDataContext1 : RetrieveCustomerSubscriptions_TypedDataContext0 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public RetrieveCustomerSubscriptions_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveCustomerSubscriptions_TypedDataContext1(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveCustomerSubscriptions_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected System.Collections.Generic.List<ExternalApiActivities.Models.CustomerSubscriptionsModel> subscriptionlistmodel {
                get {
                    return ((System.Collections.Generic.List<ExternalApiActivities.Models.CustomerSubscriptionsModel>)(this.GetVariableValue((0 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((0 + locationsOffset), value);
                }
            }
            
            protected ExternalApiActivities.Models.CustomerSubscriptionsRequestModel request {
                get {
                    return ((ExternalApiActivities.Models.CustomerSubscriptionsRequestModel)(this.GetVariableValue((1 + locationsOffset))));
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
                if (((locationReferences[(offset + 0)].Name != "subscriptionlistmodel") 
                            || (locationReferences[(offset + 0)].Type != typeof(System.Collections.Generic.List<ExternalApiActivities.Models.CustomerSubscriptionsModel>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "request") 
                            || (locationReferences[(offset + 1)].Type != typeof(ExternalApiActivities.Models.CustomerSubscriptionsRequestModel)))) {
                    return false;
                }
                return RetrieveCustomerSubscriptions_TypedDataContext0.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class RetrieveCustomerSubscriptions_TypedDataContext1_ForReadOnly : RetrieveCustomerSubscriptions_TypedDataContext0_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public RetrieveCustomerSubscriptions_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveCustomerSubscriptions_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveCustomerSubscriptions_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected System.Collections.Generic.List<ExternalApiActivities.Models.CustomerSubscriptionsModel> subscriptionlistmodel {
                get {
                    return ((System.Collections.Generic.List<ExternalApiActivities.Models.CustomerSubscriptionsModel>)(this.GetVariableValue((0 + locationsOffset))));
                }
            }
            
            protected ExternalApiActivities.Models.CustomerSubscriptionsRequestModel request {
                get {
                    return ((ExternalApiActivities.Models.CustomerSubscriptionsRequestModel)(this.GetVariableValue((1 + locationsOffset))));
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
                if (((locationReferences[(offset + 0)].Name != "subscriptionlistmodel") 
                            || (locationReferences[(offset + 0)].Type != typeof(System.Collections.Generic.List<ExternalApiActivities.Models.CustomerSubscriptionsModel>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "request") 
                            || (locationReferences[(offset + 1)].Type != typeof(ExternalApiActivities.Models.CustomerSubscriptionsRequestModel)))) {
                    return false;
                }
                return RetrieveCustomerSubscriptions_TypedDataContext0_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class RetrieveCustomerSubscriptions_TypedDataContext2 : RetrieveCustomerSubscriptions_TypedDataContext1 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public RetrieveCustomerSubscriptions_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveCustomerSubscriptions_TypedDataContext2(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveCustomerSubscriptions_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
                
                #line 84 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
              connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr0Get() {
                
                #line 84 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
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
                
                #line 84 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                
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
                return RetrieveCustomerSubscriptions_TypedDataContext1.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class RetrieveCustomerSubscriptions_TypedDataContext2_ForReadOnly : RetrieveCustomerSubscriptions_TypedDataContext1_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public RetrieveCustomerSubscriptions_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveCustomerSubscriptions_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveCustomerSubscriptions_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
                
                #line 350 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr1Get() {
                
                #line 350 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
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
                return RetrieveCustomerSubscriptions_TypedDataContext1_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class RetrieveCustomerSubscriptions_TypedDataContext3 : RetrieveCustomerSubscriptions_TypedDataContext2 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public RetrieveCustomerSubscriptions_TypedDataContext3(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveCustomerSubscriptions_TypedDataContext3(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveCustomerSubscriptions_TypedDataContext3(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.Contact individualCustomer {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.Contact)(this.GetVariableValue((3 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((3 + locationsOffset), value);
                }
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.Account corporateCustomer {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.Account)(this.GetVariableValue((4 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((4 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> subStatusOptionSet {
                get {
                    return ((System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>)(this.GetVariableValue((5 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((5 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_subscription> subscriptionList {
                get {
                    return ((System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_subscription>)(this.GetVariableValue((6 + locationsOffset))));
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
                
                #line 104 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<System.DateTime>> expression = () => 
                            request.endDate;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.DateTime @__Expr3Get() {
                
                #line 104 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                            request.endDate;
                
                #line default
                #line hidden
            }
            
            public System.DateTime ValueType___Expr3Get() {
                this.GetValueTypeValues();
                return this.@__Expr3Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr3Set(System.DateTime value) {
                
                #line 104 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                
                            request.endDate = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr3Set(System.DateTime value) {
                this.GetValueTypeValues();
                this.@__Expr3Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr5GetTree() {
                
                #line 118 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<System.DateTime>> expression = () => 
                                request.startDate;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.DateTime @__Expr5Get() {
                
                #line 118 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                                request.startDate;
                
                #line default
                #line hidden
            }
            
            public System.DateTime ValueType___Expr5Get() {
                this.GetValueTypeValues();
                return this.@__Expr5Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr5Set(System.DateTime value) {
                
                #line 118 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                
                                request.startDate = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr5Set(System.DateTime value) {
                this.GetValueTypeValues();
                this.@__Expr5Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr7GetTree() {
                
                #line 137 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<Ericsson.ETELCRM.Entities.Crm.Contact>> expression = () => 
                                    individualCustomer;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Ericsson.ETELCRM.Entities.Crm.Contact @__Expr7Get() {
                
                #line 137 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                                    individualCustomer;
                
                #line default
                #line hidden
            }
            
            public Ericsson.ETELCRM.Entities.Crm.Contact ValueType___Expr7Get() {
                this.GetValueTypeValues();
                return this.@__Expr7Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr7Set(Ericsson.ETELCRM.Entities.Crm.Contact value) {
                
                #line 137 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                
                                    individualCustomer = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr7Set(Ericsson.ETELCRM.Entities.Crm.Contact value) {
                this.GetValueTypeValues();
                this.@__Expr7Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr12GetTree() {
                
                #line 317 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_subscription>>> expression = () => 
                                            subscriptionList;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_subscription> @__Expr12Get() {
                
                #line 317 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                                            subscriptionList;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_subscription> ValueType___Expr12Get() {
                this.GetValueTypeValues();
                return this.@__Expr12Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr12Set(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_subscription> value) {
                
                #line 317 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                
                                            subscriptionList = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr12Set(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_subscription> value) {
                this.GetValueTypeValues();
                this.@__Expr12Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr13GetTree() {
                
                #line 213 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>>> expression = () => 
                                                        subStatusOptionSet;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> @__Expr13Get() {
                
                #line 213 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                                                        subStatusOptionSet;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> ValueType___Expr13Get() {
                this.GetValueTypeValues();
                return this.@__Expr13Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr13Set(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> value) {
                
                #line 213 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                
                                                        subStatusOptionSet = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr13Set(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> value) {
                this.GetValueTypeValues();
                this.@__Expr13Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr17GetTree() {
                
                #line 222 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<ExternalApiActivities.Models.CustomerSubscriptionsModel>>> expression = () => 
                                                            subscriptionlistmodel;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<ExternalApiActivities.Models.CustomerSubscriptionsModel> @__Expr17Get() {
                
                #line 222 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                                                            subscriptionlistmodel;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<ExternalApiActivities.Models.CustomerSubscriptionsModel> ValueType___Expr17Get() {
                this.GetValueTypeValues();
                return this.@__Expr17Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr17Set(System.Collections.Generic.List<ExternalApiActivities.Models.CustomerSubscriptionsModel> value) {
                
                #line 222 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                
                                                            subscriptionlistmodel = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr17Set(System.Collections.Generic.List<ExternalApiActivities.Models.CustomerSubscriptionsModel> value) {
                this.GetValueTypeValues();
                this.@__Expr17Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr24GetTree() {
                
                #line 151 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<Ericsson.ETELCRM.Entities.Crm.Account>> expression = () => 
                                            corporateCustomer;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Ericsson.ETELCRM.Entities.Crm.Account @__Expr24Get() {
                
                #line 151 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                                            corporateCustomer;
                
                #line default
                #line hidden
            }
            
            public Ericsson.ETELCRM.Entities.Crm.Account ValueType___Expr24Get() {
                this.GetValueTypeValues();
                return this.@__Expr24Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr24Set(Ericsson.ETELCRM.Entities.Crm.Account value) {
                
                #line 151 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                
                                            corporateCustomer = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr24Set(Ericsson.ETELCRM.Entities.Crm.Account value) {
                this.GetValueTypeValues();
                this.@__Expr24Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr29GetTree() {
                
                #line 194 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_subscription>>> expression = () => 
                                                    subscriptionList;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_subscription> @__Expr29Get() {
                
                #line 194 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                                                    subscriptionList;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_subscription> ValueType___Expr29Get() {
                this.GetValueTypeValues();
                return this.@__Expr29Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr29Set(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_subscription> value) {
                
                #line 194 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                
                                                    subscriptionList = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr29Set(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_subscription> value) {
                this.GetValueTypeValues();
                this.@__Expr29Set(value);
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
                if (((locationReferences[(offset + 3)].Name != "individualCustomer") 
                            || (locationReferences[(offset + 3)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.Contact)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "corporateCustomer") 
                            || (locationReferences[(offset + 4)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.Account)))) {
                    return false;
                }
                if (((locationReferences[(offset + 5)].Name != "subStatusOptionSet") 
                            || (locationReferences[(offset + 5)].Type != typeof(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "subscriptionList") 
                            || (locationReferences[(offset + 6)].Type != typeof(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_subscription>)))) {
                    return false;
                }
                return RetrieveCustomerSubscriptions_TypedDataContext2.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly : RetrieveCustomerSubscriptions_TypedDataContext2_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.Contact individualCustomer {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.Contact)(this.GetVariableValue((3 + locationsOffset))));
                }
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.Account corporateCustomer {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.Account)(this.GetVariableValue((4 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> subStatusOptionSet {
                get {
                    return ((System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>)(this.GetVariableValue((5 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_subscription> subscriptionList {
                get {
                    return ((System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_subscription>)(this.GetVariableValue((6 + locationsOffset))));
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
                
                #line 109 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<System.DateTime>> expression = () => 
                            request.endDate == null ? DateTime.MinValue : request.endDate.AddMinutes(request.orgTimezoneOffset).AddHours(23).AddMinutes(59).AddSeconds(59);;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.DateTime @__Expr2Get() {
                
                #line 109 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                            request.endDate == null ? DateTime.MinValue : request.endDate.AddMinutes(request.orgTimezoneOffset).AddHours(23).AddMinutes(59).AddSeconds(59);;
                
                #line default
                #line hidden
            }
            
            public System.DateTime ValueType___Expr2Get() {
                this.GetValueTypeValues();
                return this.@__Expr2Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr4GetTree() {
                
                #line 123 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<System.DateTime>> expression = () => 
                                request.startDate == null ? DateTime.MinValue : request.startDate.AddMinutes(request.orgTimezoneOffset);;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.DateTime @__Expr4Get() {
                
                #line 123 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                                request.startDate == null ? DateTime.MinValue : request.startDate.AddMinutes(request.orgTimezoneOffset);;
                
                #line default
                #line hidden
            }
            
            public System.DateTime ValueType___Expr4Get() {
                this.GetValueTypeValues();
                return this.@__Expr4Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr6GetTree() {
                
                #line 132 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                    request.customerId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr6Get() {
                
                #line 132 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                                    request.customerId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr6Get() {
                this.GetValueTypeValues();
                return this.@__Expr6Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr8GetTree() {
                
                #line 144 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                    individualCustomer == null;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr8Get() {
                
                #line 144 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                                    individualCustomer == null;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr8Get() {
                this.GetValueTypeValues();
                return this.@__Expr8Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr9GetTree() {
                
                #line 307 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<System.DateTime>> expression = () => 
                                            request.endDate;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.DateTime @__Expr9Get() {
                
                #line 307 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                                            request.endDate;
                
                #line default
                #line hidden
            }
            
            public System.DateTime ValueType___Expr9Get() {
                this.GetValueTypeValues();
                return this.@__Expr9Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr10GetTree() {
                
                #line 302 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<Ericsson.ETELCRM.Entities.Crm.ICustomer>> expression = () => 
                                            individualCustomer;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Ericsson.ETELCRM.Entities.Crm.ICustomer @__Expr10Get() {
                
                #line 302 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                                            individualCustomer;
                
                #line default
                #line hidden
            }
            
            public Ericsson.ETELCRM.Entities.Crm.ICustomer ValueType___Expr10Get() {
                this.GetValueTypeValues();
                return this.@__Expr10Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr11GetTree() {
                
                #line 312 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<System.DateTime>> expression = () => 
                                            request.startDate;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.DateTime @__Expr11Get() {
                
                #line 312 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                                            request.startDate;
                
                #line default
                #line hidden
            }
            
            public System.DateTime ValueType___Expr11Get() {
                this.GetValueTypeValues();
                return this.@__Expr11Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr14GetTree() {
                
                #line 208 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
                                                        int.Parse(request.languagecode);
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr14Get() {
                
                #line 208 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                                                        int.Parse(request.languagecode);
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr14Get() {
                this.GetValueTypeValues();
                return this.@__Expr14Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr15GetTree() {
                
                #line 203 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                        etel_subscription.EntityLogicalName;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr15Get() {
                
                #line 203 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                                                        etel_subscription.EntityLogicalName;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr15Get() {
                this.GetValueTypeValues();
                return this.@__Expr15Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr16GetTree() {
                
                #line 227 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<ExternalApiActivities.Models.CustomerSubscriptionsModel>>> expression = () => 
                                                            new List<CustomerSubscriptionsModel>();
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<ExternalApiActivities.Models.CustomerSubscriptionsModel> @__Expr16Get() {
                
                #line 227 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                                                            new List<CustomerSubscriptionsModel>();
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<ExternalApiActivities.Models.CustomerSubscriptionsModel> ValueType___Expr16Get() {
                this.GetValueTypeValues();
                return this.@__Expr16Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr18GetTree() {
                
                #line 236 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.IEnumerable<Ericsson.ETELCRM.Entities.Crm.etel_subscription>>> expression = () => 
                                                                subscriptionList;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.IEnumerable<Ericsson.ETELCRM.Entities.Crm.etel_subscription> @__Expr18Get() {
                
                #line 236 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                                                                subscriptionList;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.IEnumerable<Ericsson.ETELCRM.Entities.Crm.etel_subscription> ValueType___Expr18Get() {
                this.GetValueTypeValues();
                return this.@__Expr18Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr23GetTree() {
                
                #line 156 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                            request.customerId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr23Get() {
                
                #line 156 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                                            request.customerId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr23Get() {
                this.GetValueTypeValues();
                return this.@__Expr23Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr25GetTree() {
                
                #line 163 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                            corporateCustomer == null;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr25Get() {
                
                #line 163 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                                            corporateCustomer == null;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr25Get() {
                this.GetValueTypeValues();
                return this.@__Expr25Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr26GetTree() {
                
                #line 184 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Nullable<System.DateTime>>> expression = () => 
                                                    request.endDate;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Nullable<System.DateTime> @__Expr26Get() {
                
                #line 184 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                                                    request.endDate;
                
                #line default
                #line hidden
            }
            
            public System.Nullable<System.DateTime> ValueType___Expr26Get() {
                this.GetValueTypeValues();
                return this.@__Expr26Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr27GetTree() {
                
                #line 179 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<Ericsson.ETELCRM.Entities.Crm.ICustomer>> expression = () => 
                                                    corporateCustomer;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Ericsson.ETELCRM.Entities.Crm.ICustomer @__Expr27Get() {
                
                #line 179 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                                                    corporateCustomer;
                
                #line default
                #line hidden
            }
            
            public Ericsson.ETELCRM.Entities.Crm.ICustomer ValueType___Expr27Get() {
                this.GetValueTypeValues();
                return this.@__Expr27Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr28GetTree() {
                
                #line 189 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Nullable<System.DateTime>>> expression = () => 
                                                    request.startDate;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Nullable<System.DateTime> @__Expr28Get() {
                
                #line 189 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                                                    request.startDate;
                
                #line default
                #line hidden
            }
            
            public System.Nullable<System.DateTime> ValueType___Expr28Get() {
                this.GetValueTypeValues();
                return this.@__Expr28Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr30GetTree() {
                
                #line 169 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Exception>> expression = () => 
                                                  new Exception("Customer Not Found!");
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Exception @__Expr30Get() {
                
                #line 169 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                                                  new Exception("Customer Not Found!");
                
                #line default
                #line hidden
            }
            
            public System.Exception ValueType___Expr30Get() {
                this.GetValueTypeValues();
                return this.@__Expr30Get();
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
                if (((locationReferences[(offset + 3)].Name != "individualCustomer") 
                            || (locationReferences[(offset + 3)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.Contact)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "corporateCustomer") 
                            || (locationReferences[(offset + 4)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.Account)))) {
                    return false;
                }
                if (((locationReferences[(offset + 5)].Name != "subStatusOptionSet") 
                            || (locationReferences[(offset + 5)].Type != typeof(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "subscriptionList") 
                            || (locationReferences[(offset + 6)].Type != typeof(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_subscription>)))) {
                    return false;
                }
                return RetrieveCustomerSubscriptions_TypedDataContext2_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class RetrieveCustomerSubscriptions_TypedDataContext4 : RetrieveCustomerSubscriptions_TypedDataContext3 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public RetrieveCustomerSubscriptions_TypedDataContext4(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveCustomerSubscriptions_TypedDataContext4(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveCustomerSubscriptions_TypedDataContext4(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.etel_subscription item {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.etel_subscription)(this.GetVariableValue((7 + locationsOffset))));
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
                if (((locationReferences[(offset + 7)].Name != "item") 
                            || (locationReferences[(offset + 7)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.etel_subscription)))) {
                    return false;
                }
                return RetrieveCustomerSubscriptions_TypedDataContext3.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class RetrieveCustomerSubscriptions_TypedDataContext4_ForReadOnly : RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public RetrieveCustomerSubscriptions_TypedDataContext4_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveCustomerSubscriptions_TypedDataContext4_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveCustomerSubscriptions_TypedDataContext4_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.etel_subscription item {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.etel_subscription)(this.GetVariableValue((7 + locationsOffset))));
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
                if (((locationReferences[(offset + 7)].Name != "item") 
                            || (locationReferences[(offset + 7)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.etel_subscription)))) {
                    return false;
                }
                return RetrieveCustomerSubscriptions_TypedDataContext3_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class RetrieveCustomerSubscriptions_TypedDataContext5 : RetrieveCustomerSubscriptions_TypedDataContext4 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public RetrieveCustomerSubscriptions_TypedDataContext5(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveCustomerSubscriptions_TypedDataContext5(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveCustomerSubscriptions_TypedDataContext5(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet op_statuscode {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet)(this.GetVariableValue((8 + locationsOffset))));
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
            
            internal System.Linq.Expressions.Expression @__Expr20GetTree() {
                
                #line 251 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>> expression = () => 
                                                                        op_statuscode;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet @__Expr20Get() {
                
                #line 251 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                                                                        op_statuscode;
                
                #line default
                #line hidden
            }
            
            public Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet ValueType___Expr20Get() {
                this.GetValueTypeValues();
                return this.@__Expr20Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr20Set(Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet value) {
                
                #line 251 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                
                                                                        op_statuscode = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr20Set(Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet value) {
                this.GetValueTypeValues();
                this.@__Expr20Set(value);
                this.SetValueTypeValues();
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
                if (((locationReferences[(offset + 8)].Name != "op_statuscode") 
                            || (locationReferences[(offset + 8)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet)))) {
                    return false;
                }
                return RetrieveCustomerSubscriptions_TypedDataContext4.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly : RetrieveCustomerSubscriptions_TypedDataContext4_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public RetrieveCustomerSubscriptions_TypedDataContext5_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet op_statuscode {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet)(this.GetVariableValue((8 + locationsOffset))));
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
                
                #line 256 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>> expression = () => 
                                                                        (subStatusOptionSet == null || item.etel_subscriptionstatuscode == null) ? null : subStatusOptionSet.FirstOrDefault(st => st.Value == item.etel_subscriptionstatuscode.Value);
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet @__Expr19Get() {
                
                #line 256 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                                                                        (subStatusOptionSet == null || item.etel_subscriptionstatuscode == null) ? null : subStatusOptionSet.FirstOrDefault(st => st.Value == item.etel_subscriptionstatuscode.Value);
                
                #line default
                #line hidden
            }
            
            public Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet ValueType___Expr19Get() {
                this.GetValueTypeValues();
                return this.@__Expr19Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr21GetTree() {
                
                #line 278 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.ICollection<ExternalApiActivities.Models.CustomerSubscriptionsModel>>> expression = () => 
                                                                      subscriptionlistmodel;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.ICollection<ExternalApiActivities.Models.CustomerSubscriptionsModel> @__Expr21Get() {
                
                #line 278 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                                                                      subscriptionlistmodel;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.ICollection<ExternalApiActivities.Models.CustomerSubscriptionsModel> ValueType___Expr21Get() {
                this.GetValueTypeValues();
                return this.@__Expr21Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr22GetTree() {
                
                #line 263 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                System.Linq.Expressions.Expression<System.Func<ExternalApiActivities.Models.CustomerSubscriptionsModel>> expression = () => 
                                                                        new CustomCustomerSubscriptionsModel
            {
              SubscriptionId = item.etel_subscriptionId,
              Name = item.etel_name,
              ActivationDate = item.etel_activationdate.HasValue ? item.etel_activationdate.Value.AddMinutes(request.orgTimezoneOffset).ToString("yyyy-MM-dd") : string.Empty,
              CreatedON = item.CreatedOn.HasValue ? item.CreatedOn.Value.AddMinutes(request.orgTimezoneOffset).ToString("yyyy-MM-dd HH:mm") : string.Empty,
              ExternalId = item.etel_externalid,
              MSISDNSerialNo = item.etel_msisdnserialno,
              RatePlan = item.etel_rateplanid == null ? string.Empty : item.etel_rateplanid.Name,
              SubStatus = op_statuscode == null ? string.Empty : op_statuscode.Text,
              User = item.etel_individualuserid != null ? item.etel_individualuserid.Name : (item.etel_corporateuserid != null ? item.etel_corporateuserid.Name : string.Empty)
            };
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public ExternalApiActivities.Models.CustomerSubscriptionsModel @__Expr22Get() {
                
                #line 263 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\RETRIEVECUSTOMERSUBSCRIPTIONS.XAML"
                return 
                                                                        new CustomCustomerSubscriptionsModel
            {
              SubscriptionId = item.etel_subscriptionId,
              Name = item.etel_name,
              ActivationDate = item.etel_activationdate.HasValue ? item.etel_activationdate.Value.AddMinutes(request.orgTimezoneOffset).ToString("yyyy-MM-dd") : string.Empty,
              CreatedON = item.CreatedOn.HasValue ? item.CreatedOn.Value.AddMinutes(request.orgTimezoneOffset).ToString("yyyy-MM-dd HH:mm") : string.Empty,
              ExternalId = item.etel_externalid,
              MSISDNSerialNo = item.etel_msisdnserialno,
              RatePlan = item.etel_rateplanid == null ? string.Empty : item.etel_rateplanid.Name,
              SubStatus = op_statuscode == null ? string.Empty : op_statuscode.Text,
              User = item.etel_individualuserid != null ? item.etel_individualuserid.Name : (item.etel_corporateuserid != null ? item.etel_corporateuserid.Name : string.Empty)
            };
                
                #line default
                #line hidden
            }
            
            public ExternalApiActivities.Models.CustomerSubscriptionsModel ValueType___Expr22Get() {
                this.GetValueTypeValues();
                return this.@__Expr22Get();
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
                if (((locationReferences[(offset + 8)].Name != "op_statuscode") 
                            || (locationReferences[(offset + 8)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet)))) {
                    return false;
                }
                return RetrieveCustomerSubscriptions_TypedDataContext4_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
    }
}

namespace AmxPeruPSBWorkflows {
    
    #line 45 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruNewSubscription.xaml"
    using System;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruNewSubscription.xaml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 46 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruNewSubscription.xaml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruNewSubscription.xaml"
    using System.Activities;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruNewSubscription.xaml"
    using System.Activities.Expressions;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruNewSubscription.xaml"
    using System.Activities.Statements;
    
    #line default
    #line hidden
    
    #line 47 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruNewSubscription.xaml"
    using System.Data;
    
    #line default
    #line hidden
    
    #line 48 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruNewSubscription.xaml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 49 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruNewSubscription.xaml"
    using System.Text;
    
    #line default
    #line hidden
    
    #line 50 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruNewSubscription.xaml"
    using Ericsson.ETELCRM.Entities.Crm;
    
    #line default
    #line hidden
    
    #line 51 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruNewSubscription.xaml"
    using ExternalApiActivities.Models;
    
    #line default
    #line hidden
    
    #line 52 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruNewSubscription.xaml"
    using AmxPeruPSBActivities.Model;
    
    #line default
    #line hidden
    
    #line 53 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruNewSubscription.xaml"
    using Microsoft.Xrm.Sdk;
    
    #line default
    #line hidden
    
    #line 54 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruNewSubscription.xaml"
    using AmxPeruPSBActivities.Activities.OrderItem;
    
    #line default
    #line hidden
    
    #line 55 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruNewSubscription.xaml"
    using AmxPeruPSBActivities.Model.OrderCaptureSubmit;
    
    #line default
    #line hidden
    
    #line 56 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruNewSubscription.xaml"
    using AmxPeruPSBActivities.Model.Appointment;
    
    #line default
    #line hidden
    
    #line 57 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruNewSubscription.xaml"
    using AmxPeruPSBActivities.Model.Cfss;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruNewSubscription.xaml"
    using System.Activities.XamlIntegration;
    
    #line default
    #line hidden
    
    
    public partial class AmxPeruNewSubscription : System.Activities.XamlIntegration.ICompiledExpressionRoot {
        
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
                this.dataContextActivities = AmxPeruNewSubscription_TypedDataContext2_ForReadOnly.GetDataContextActivitiesHelper(this.rootActivity, this.forImplementation);
            }
            if ((expressionId == 0)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruNewSubscription_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext2_ForReadOnly valDataContext0 = ((AmxPeruNewSubscription_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext0.ValueType___Expr0Get();
            }
            if ((expressionId == 1)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruNewSubscription_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext2_ForReadOnly valDataContext1 = ((AmxPeruNewSubscription_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruNewSubscription_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext2_ForReadOnly valDataContext2 = ((AmxPeruNewSubscription_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext2.ValueType___Expr2Get();
            }
            if ((expressionId == 3)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruNewSubscription_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext2_ForReadOnly valDataContext3 = ((AmxPeruNewSubscription_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext3.ValueType___Expr3Get();
            }
            if ((expressionId == 4)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxPeruNewSubscription_TypedDataContext2(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext2 refDataContext4 = ((AmxPeruNewSubscription_TypedDataContext2)(cachedCompiledDataContext[1]));
                return refDataContext4.GetLocation<string>(refDataContext4.ValueType___Expr4Get, refDataContext4.ValueType___Expr4Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 5)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruNewSubscription_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext2_ForReadOnly valDataContext5 = ((AmxPeruNewSubscription_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext5.ValueType___Expr5Get();
            }
            if ((expressionId == 6)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext4.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new AmxPeruNewSubscription_TypedDataContext4(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext4 refDataContext6 = ((AmxPeruNewSubscription_TypedDataContext4)(cachedCompiledDataContext[2]));
                return refDataContext6.GetLocation<AmxPeruPSBActivities.Model.OrderItemsBasketModel>(refDataContext6.ValueType___Expr6Get, refDataContext6.ValueType___Expr6Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 7)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new AmxPeruNewSubscription_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext4_ForReadOnly valDataContext7 = ((AmxPeruNewSubscription_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[3]));
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new AmxPeruNewSubscription_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext4_ForReadOnly valDataContext8 = ((AmxPeruNewSubscription_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[3]));
                return valDataContext8.ValueType___Expr8Get();
            }
            if ((expressionId == 9)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext4.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new AmxPeruNewSubscription_TypedDataContext4(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext4 refDataContext9 = ((AmxPeruNewSubscription_TypedDataContext4)(cachedCompiledDataContext[2]));
                return refDataContext9.GetLocation<AmxPeruPSBActivities.Model.ConfigurableItemsModel>(refDataContext9.ValueType___Expr9Get, refDataContext9.ValueType___Expr9Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 10)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new AmxPeruNewSubscription_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext4_ForReadOnly valDataContext10 = ((AmxPeruNewSubscription_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[3]));
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new AmxPeruNewSubscription_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext4_ForReadOnly valDataContext11 = ((AmxPeruNewSubscription_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[3]));
                return valDataContext11.ValueType___Expr11Get();
            }
            if ((expressionId == 12)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new AmxPeruNewSubscription_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext4_ForReadOnly valDataContext12 = ((AmxPeruNewSubscription_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[3]));
                return valDataContext12.ValueType___Expr12Get();
            }
            if ((expressionId == 13)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext4.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new AmxPeruNewSubscription_TypedDataContext4(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext4 refDataContext13 = ((AmxPeruNewSubscription_TypedDataContext4)(cachedCompiledDataContext[2]));
                return refDataContext13.GetLocation<AmxPeruPSBActivities.Model.ConfigurableItemsModel>(refDataContext13.ValueType___Expr13Get, refDataContext13.ValueType___Expr13Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 14)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new AmxPeruNewSubscription_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext4_ForReadOnly valDataContext14 = ((AmxPeruNewSubscription_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[3]));
                return valDataContext14.ValueType___Expr14Get();
            }
            if ((expressionId == 15)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext4.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new AmxPeruNewSubscription_TypedDataContext4(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext4 refDataContext15 = ((AmxPeruNewSubscription_TypedDataContext4)(cachedCompiledDataContext[2]));
                return refDataContext15.GetLocation<System.Collections.Generic.List<AmxPeruPSBActivities.Model.Cfss.CfssCharacteristicList>>(refDataContext15.ValueType___Expr15Get, refDataContext15.ValueType___Expr15Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 16)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new AmxPeruNewSubscription_TypedDataContext3(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3 refDataContext16 = ((AmxPeruNewSubscription_TypedDataContext3)(cachedCompiledDataContext[4]));
                return refDataContext16.GetLocation<Ericsson.ETELCRM.Entities.Crm.Account>(refDataContext16.ValueType___Expr16Get, refDataContext16.ValueType___Expr16Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 17)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new AmxPeruNewSubscription_TypedDataContext3(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3 refDataContext17 = ((AmxPeruNewSubscription_TypedDataContext3)(cachedCompiledDataContext[4]));
                return refDataContext17.GetLocation<string>(refDataContext17.ValueType___Expr17Get, refDataContext17.ValueType___Expr17Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 18)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext18 = ((AmxPeruNewSubscription_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[5]));
                return valDataContext18.ValueType___Expr18Get();
            }
            if ((expressionId == 19)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext19 = ((AmxPeruNewSubscription_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[5]));
                return valDataContext19.ValueType___Expr19Get();
            }
            if ((expressionId == 20)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new AmxPeruNewSubscription_TypedDataContext3(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3 refDataContext20 = ((AmxPeruNewSubscription_TypedDataContext3)(cachedCompiledDataContext[4]));
                return refDataContext20.GetLocation<Ericsson.ETELCRM.Entities.Crm.Contact>(refDataContext20.ValueType___Expr20Get, refDataContext20.ValueType___Expr20Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 21)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext21 = ((AmxPeruNewSubscription_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[5]));
                return valDataContext21.ValueType___Expr21Get();
            }
            if ((expressionId == 22)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext22 = ((AmxPeruNewSubscription_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[5]));
                return valDataContext22.ValueType___Expr22Get();
            }
            if ((expressionId == 23)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new AmxPeruNewSubscription_TypedDataContext3(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3 refDataContext23 = ((AmxPeruNewSubscription_TypedDataContext3)(cachedCompiledDataContext[4]));
                return refDataContext23.GetLocation<string>(refDataContext23.ValueType___Expr23Get, refDataContext23.ValueType___Expr23Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 24)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new AmxPeruNewSubscription_TypedDataContext3(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3 refDataContext24 = ((AmxPeruNewSubscription_TypedDataContext3)(cachedCompiledDataContext[4]));
                return refDataContext24.GetLocation<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_billingaccount>>(refDataContext24.ValueType___Expr24Get, refDataContext24.ValueType___Expr24Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 25)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new AmxPeruNewSubscription_TypedDataContext3(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3 refDataContext25 = ((AmxPeruNewSubscription_TypedDataContext3)(cachedCompiledDataContext[4]));
                return refDataContext25.GetLocation<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.TwoOption>>(refDataContext25.ValueType___Expr25Get, refDataContext25.ValueType___Expr25Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 26)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext26 = ((AmxPeruNewSubscription_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[5]));
                return valDataContext26.ValueType___Expr26Get();
            }
            if ((expressionId == 27)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new AmxPeruNewSubscription_TypedDataContext3(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3 refDataContext27 = ((AmxPeruNewSubscription_TypedDataContext3)(cachedCompiledDataContext[4]));
                return refDataContext27.GetLocation<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.TwoOption>>(refDataContext27.ValueType___Expr27Get, refDataContext27.ValueType___Expr27Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 28)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext28 = ((AmxPeruNewSubscription_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[5]));
                return valDataContext28.ValueType___Expr28Get();
            }
            if ((expressionId == 29)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new AmxPeruNewSubscription_TypedDataContext3(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3 refDataContext29 = ((AmxPeruNewSubscription_TypedDataContext3)(cachedCompiledDataContext[4]));
                return refDataContext29.GetLocation<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>>(refDataContext29.ValueType___Expr29Get, refDataContext29.ValueType___Expr29Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 30)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext30 = ((AmxPeruNewSubscription_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[5]));
                return valDataContext30.ValueType___Expr30Get();
            }
            if ((expressionId == 31)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext31 = ((AmxPeruNewSubscription_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[5]));
                return valDataContext31.ValueType___Expr31Get();
            }
            if ((expressionId == 32)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext6_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[6] == null)) {
                    cachedCompiledDataContext[6] = new AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext6_ForReadOnly valDataContext32 = ((AmxPeruNewSubscription_TypedDataContext6_ForReadOnly)(cachedCompiledDataContext[6]));
                return valDataContext32.ValueType___Expr32Get();
            }
            if ((expressionId == 33)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext6.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[7] == null)) {
                    cachedCompiledDataContext[7] = new AmxPeruNewSubscription_TypedDataContext6(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext6 refDataContext33 = ((AmxPeruNewSubscription_TypedDataContext6)(cachedCompiledDataContext[7]));
                return refDataContext33.GetLocation<AmxPeruPSBActivities.Model.BillingAccount>(refDataContext33.ValueType___Expr33Get, refDataContext33.ValueType___Expr33Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 34)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext6_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[6] == null)) {
                    cachedCompiledDataContext[6] = new AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext6_ForReadOnly valDataContext34 = ((AmxPeruNewSubscription_TypedDataContext6_ForReadOnly)(cachedCompiledDataContext[6]));
                return valDataContext34.ValueType___Expr34Get();
            }
            if ((expressionId == 35)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext6.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[7] == null)) {
                    cachedCompiledDataContext[7] = new AmxPeruNewSubscription_TypedDataContext6(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext6 refDataContext35 = ((AmxPeruNewSubscription_TypedDataContext6)(cachedCompiledDataContext[7]));
                return refDataContext35.GetLocation<string>(refDataContext35.ValueType___Expr35Get, refDataContext35.ValueType___Expr35Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 36)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext6_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[6] == null)) {
                    cachedCompiledDataContext[6] = new AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext6_ForReadOnly valDataContext36 = ((AmxPeruNewSubscription_TypedDataContext6_ForReadOnly)(cachedCompiledDataContext[6]));
                return valDataContext36.ValueType___Expr36Get();
            }
            if ((expressionId == 37)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext6.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[7] == null)) {
                    cachedCompiledDataContext[7] = new AmxPeruNewSubscription_TypedDataContext6(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext6 refDataContext37 = ((AmxPeruNewSubscription_TypedDataContext6)(cachedCompiledDataContext[7]));
                return refDataContext37.GetLocation<string>(refDataContext37.ValueType___Expr37Get, refDataContext37.ValueType___Expr37Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 38)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext6_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[6] == null)) {
                    cachedCompiledDataContext[6] = new AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext6_ForReadOnly valDataContext38 = ((AmxPeruNewSubscription_TypedDataContext6_ForReadOnly)(cachedCompiledDataContext[6]));
                return valDataContext38.ValueType___Expr38Get();
            }
            if ((expressionId == 39)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext6.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[7] == null)) {
                    cachedCompiledDataContext[7] = new AmxPeruNewSubscription_TypedDataContext6(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext6 refDataContext39 = ((AmxPeruNewSubscription_TypedDataContext6)(cachedCompiledDataContext[7]));
                return refDataContext39.GetLocation<string>(refDataContext39.ValueType___Expr39Get, refDataContext39.ValueType___Expr39Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 40)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext6_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[6] == null)) {
                    cachedCompiledDataContext[6] = new AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext6_ForReadOnly valDataContext40 = ((AmxPeruNewSubscription_TypedDataContext6_ForReadOnly)(cachedCompiledDataContext[6]));
                return valDataContext40.ValueType___Expr40Get();
            }
            if ((expressionId == 41)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext6.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[7] == null)) {
                    cachedCompiledDataContext[7] = new AmxPeruNewSubscription_TypedDataContext6(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext6 refDataContext41 = ((AmxPeruNewSubscription_TypedDataContext6)(cachedCompiledDataContext[7]));
                return refDataContext41.GetLocation<string>(refDataContext41.ValueType___Expr41Get, refDataContext41.ValueType___Expr41Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 42)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext6_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[6] == null)) {
                    cachedCompiledDataContext[6] = new AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext6_ForReadOnly valDataContext42 = ((AmxPeruNewSubscription_TypedDataContext6_ForReadOnly)(cachedCompiledDataContext[6]));
                return valDataContext42.ValueType___Expr42Get();
            }
            if ((expressionId == 43)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext6.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[7] == null)) {
                    cachedCompiledDataContext[7] = new AmxPeruNewSubscription_TypedDataContext6(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext6 refDataContext43 = ((AmxPeruNewSubscription_TypedDataContext6)(cachedCompiledDataContext[7]));
                return refDataContext43.GetLocation<string>(refDataContext43.ValueType___Expr43Get, refDataContext43.ValueType___Expr43Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 44)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext6_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[6] == null)) {
                    cachedCompiledDataContext[6] = new AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext6_ForReadOnly valDataContext44 = ((AmxPeruNewSubscription_TypedDataContext6_ForReadOnly)(cachedCompiledDataContext[6]));
                return valDataContext44.ValueType___Expr44Get();
            }
            if ((expressionId == 45)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext6.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[7] == null)) {
                    cachedCompiledDataContext[7] = new AmxPeruNewSubscription_TypedDataContext6(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext6 refDataContext45 = ((AmxPeruNewSubscription_TypedDataContext6)(cachedCompiledDataContext[7]));
                return refDataContext45.GetLocation<string>(refDataContext45.ValueType___Expr45Get, refDataContext45.ValueType___Expr45Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 46)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext6.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[7] == null)) {
                    cachedCompiledDataContext[7] = new AmxPeruNewSubscription_TypedDataContext6(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext6 refDataContext46 = ((AmxPeruNewSubscription_TypedDataContext6)(cachedCompiledDataContext[7]));
                return refDataContext46.GetLocation<string>(refDataContext46.ValueType___Expr46Get, refDataContext46.ValueType___Expr46Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 47)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext6_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[6] == null)) {
                    cachedCompiledDataContext[6] = new AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext6_ForReadOnly valDataContext47 = ((AmxPeruNewSubscription_TypedDataContext6_ForReadOnly)(cachedCompiledDataContext[6]));
                return valDataContext47.ValueType___Expr47Get();
            }
            if ((expressionId == 48)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext6_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[6] == null)) {
                    cachedCompiledDataContext[6] = new AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext6_ForReadOnly valDataContext48 = ((AmxPeruNewSubscription_TypedDataContext6_ForReadOnly)(cachedCompiledDataContext[6]));
                return valDataContext48.ValueType___Expr48Get();
            }
            if ((expressionId == 49)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext49 = ((AmxPeruNewSubscription_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[5]));
                return valDataContext49.ValueType___Expr49Get();
            }
            if ((expressionId == 50)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new AmxPeruNewSubscription_TypedDataContext3(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3 refDataContext50 = ((AmxPeruNewSubscription_TypedDataContext3)(cachedCompiledDataContext[4]));
                return refDataContext50.GetLocation<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>>(refDataContext50.ValueType___Expr50Get, refDataContext50.ValueType___Expr50Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 51)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext51 = ((AmxPeruNewSubscription_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[5]));
                return valDataContext51.ValueType___Expr51Get();
            }
            if ((expressionId == 52)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext52 = ((AmxPeruNewSubscription_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[5]));
                return valDataContext52.ValueType___Expr52Get();
            }
            if ((expressionId == 53)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new AmxPeruNewSubscription_TypedDataContext3(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3 refDataContext53 = ((AmxPeruNewSubscription_TypedDataContext3)(cachedCompiledDataContext[4]));
                return refDataContext53.GetLocation<AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest>(refDataContext53.ValueType___Expr53Get, refDataContext53.ValueType___Expr53Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 54)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext54 = ((AmxPeruNewSubscription_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[5]));
                return valDataContext54.ValueType___Expr54Get();
            }
            if ((expressionId == 55)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext55 = ((AmxPeruNewSubscription_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[5]));
                return valDataContext55.ValueType___Expr55Get();
            }
            if ((expressionId == 56)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext56 = ((AmxPeruNewSubscription_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[5]));
                return valDataContext56.ValueType___Expr56Get();
            }
            if ((expressionId == 57)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new AmxPeruNewSubscription_TypedDataContext3(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3 refDataContext57 = ((AmxPeruNewSubscription_TypedDataContext3)(cachedCompiledDataContext[4]));
                return refDataContext57.GetLocation<string>(refDataContext57.ValueType___Expr57Get, refDataContext57.ValueType___Expr57Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 58)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new AmxPeruNewSubscription_TypedDataContext3(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3 refDataContext58 = ((AmxPeruNewSubscription_TypedDataContext3)(cachedCompiledDataContext[4]));
                return refDataContext58.GetLocation<string>(refDataContext58.ValueType___Expr58Get, refDataContext58.ValueType___Expr58Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 59)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext59 = ((AmxPeruNewSubscription_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[5]));
                return valDataContext59.ValueType___Expr59Get();
            }
            if ((expressionId == 60)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext60 = ((AmxPeruNewSubscription_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[5]));
                return valDataContext60.ValueType___Expr60Get();
            }
            if ((expressionId == 61)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new AmxPeruNewSubscription_TypedDataContext3(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3 refDataContext61 = ((AmxPeruNewSubscription_TypedDataContext3)(cachedCompiledDataContext[4]));
                return refDataContext61.GetLocation<AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse>(refDataContext61.ValueType___Expr61Get, refDataContext61.ValueType___Expr61Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 62)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext62 = ((AmxPeruNewSubscription_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[5]));
                return valDataContext62.ValueType___Expr62Get();
            }
            if ((expressionId == 63)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext63 = ((AmxPeruNewSubscription_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[5]));
                return valDataContext63.ValueType___Expr63Get();
            }
            if ((expressionId == 64)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext64 = ((AmxPeruNewSubscription_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[5]));
                return valDataContext64.ValueType___Expr64Get();
            }
            if ((expressionId == 65)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new AmxPeruNewSubscription_TypedDataContext3(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3 refDataContext65 = ((AmxPeruNewSubscription_TypedDataContext3)(cachedCompiledDataContext[4]));
                return refDataContext65.GetLocation<AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse>(refDataContext65.ValueType___Expr65Get, refDataContext65.ValueType___Expr65Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 66)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext66 = ((AmxPeruNewSubscription_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[5]));
                return valDataContext66.ValueType___Expr66Get();
            }
            if ((expressionId == 67)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext67 = ((AmxPeruNewSubscription_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[5]));
                return valDataContext67.ValueType___Expr67Get();
            }
            if ((expressionId == 68)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruNewSubscription_TypedDataContext7_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 9);
                if ((cachedCompiledDataContext[8] == null)) {
                    cachedCompiledDataContext[8] = new AmxPeruNewSubscription_TypedDataContext7_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruNewSubscription_TypedDataContext7_ForReadOnly valDataContext68 = ((AmxPeruNewSubscription_TypedDataContext7_ForReadOnly)(cachedCompiledDataContext[8]));
                return valDataContext68.ValueType___Expr68Get();
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
                AmxPeruNewSubscription_TypedDataContext2_ForReadOnly valDataContext0 = new AmxPeruNewSubscription_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext0.ValueType___Expr0Get();
            }
            if ((expressionId == 1)) {
                AmxPeruNewSubscription_TypedDataContext2_ForReadOnly valDataContext1 = new AmxPeruNewSubscription_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                AmxPeruNewSubscription_TypedDataContext2_ForReadOnly valDataContext2 = new AmxPeruNewSubscription_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext2.ValueType___Expr2Get();
            }
            if ((expressionId == 3)) {
                AmxPeruNewSubscription_TypedDataContext2_ForReadOnly valDataContext3 = new AmxPeruNewSubscription_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext3.ValueType___Expr3Get();
            }
            if ((expressionId == 4)) {
                AmxPeruNewSubscription_TypedDataContext2 refDataContext4 = new AmxPeruNewSubscription_TypedDataContext2(locations, true);
                return refDataContext4.GetLocation<string>(refDataContext4.ValueType___Expr4Get, refDataContext4.ValueType___Expr4Set);
            }
            if ((expressionId == 5)) {
                AmxPeruNewSubscription_TypedDataContext2_ForReadOnly valDataContext5 = new AmxPeruNewSubscription_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext5.ValueType___Expr5Get();
            }
            if ((expressionId == 6)) {
                AmxPeruNewSubscription_TypedDataContext4 refDataContext6 = new AmxPeruNewSubscription_TypedDataContext4(locations, true);
                return refDataContext6.GetLocation<AmxPeruPSBActivities.Model.OrderItemsBasketModel>(refDataContext6.ValueType___Expr6Get, refDataContext6.ValueType___Expr6Set);
            }
            if ((expressionId == 7)) {
                AmxPeruNewSubscription_TypedDataContext4_ForReadOnly valDataContext7 = new AmxPeruNewSubscription_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext7.ValueType___Expr7Get();
            }
            if ((expressionId == 8)) {
                AmxPeruNewSubscription_TypedDataContext4_ForReadOnly valDataContext8 = new AmxPeruNewSubscription_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext8.ValueType___Expr8Get();
            }
            if ((expressionId == 9)) {
                AmxPeruNewSubscription_TypedDataContext4 refDataContext9 = new AmxPeruNewSubscription_TypedDataContext4(locations, true);
                return refDataContext9.GetLocation<AmxPeruPSBActivities.Model.ConfigurableItemsModel>(refDataContext9.ValueType___Expr9Get, refDataContext9.ValueType___Expr9Set);
            }
            if ((expressionId == 10)) {
                AmxPeruNewSubscription_TypedDataContext4_ForReadOnly valDataContext10 = new AmxPeruNewSubscription_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                AmxPeruNewSubscription_TypedDataContext4_ForReadOnly valDataContext11 = new AmxPeruNewSubscription_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext11.ValueType___Expr11Get();
            }
            if ((expressionId == 12)) {
                AmxPeruNewSubscription_TypedDataContext4_ForReadOnly valDataContext12 = new AmxPeruNewSubscription_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext12.ValueType___Expr12Get();
            }
            if ((expressionId == 13)) {
                AmxPeruNewSubscription_TypedDataContext4 refDataContext13 = new AmxPeruNewSubscription_TypedDataContext4(locations, true);
                return refDataContext13.GetLocation<AmxPeruPSBActivities.Model.ConfigurableItemsModel>(refDataContext13.ValueType___Expr13Get, refDataContext13.ValueType___Expr13Set);
            }
            if ((expressionId == 14)) {
                AmxPeruNewSubscription_TypedDataContext4_ForReadOnly valDataContext14 = new AmxPeruNewSubscription_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext14.ValueType___Expr14Get();
            }
            if ((expressionId == 15)) {
                AmxPeruNewSubscription_TypedDataContext4 refDataContext15 = new AmxPeruNewSubscription_TypedDataContext4(locations, true);
                return refDataContext15.GetLocation<System.Collections.Generic.List<AmxPeruPSBActivities.Model.Cfss.CfssCharacteristicList>>(refDataContext15.ValueType___Expr15Get, refDataContext15.ValueType___Expr15Set);
            }
            if ((expressionId == 16)) {
                AmxPeruNewSubscription_TypedDataContext3 refDataContext16 = new AmxPeruNewSubscription_TypedDataContext3(locations, true);
                return refDataContext16.GetLocation<Ericsson.ETELCRM.Entities.Crm.Account>(refDataContext16.ValueType___Expr16Get, refDataContext16.ValueType___Expr16Set);
            }
            if ((expressionId == 17)) {
                AmxPeruNewSubscription_TypedDataContext3 refDataContext17 = new AmxPeruNewSubscription_TypedDataContext3(locations, true);
                return refDataContext17.GetLocation<string>(refDataContext17.ValueType___Expr17Get, refDataContext17.ValueType___Expr17Set);
            }
            if ((expressionId == 18)) {
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext18 = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext18.ValueType___Expr18Get();
            }
            if ((expressionId == 19)) {
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext19 = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext19.ValueType___Expr19Get();
            }
            if ((expressionId == 20)) {
                AmxPeruNewSubscription_TypedDataContext3 refDataContext20 = new AmxPeruNewSubscription_TypedDataContext3(locations, true);
                return refDataContext20.GetLocation<Ericsson.ETELCRM.Entities.Crm.Contact>(refDataContext20.ValueType___Expr20Get, refDataContext20.ValueType___Expr20Set);
            }
            if ((expressionId == 21)) {
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext21 = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext21.ValueType___Expr21Get();
            }
            if ((expressionId == 22)) {
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext22 = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext22.ValueType___Expr22Get();
            }
            if ((expressionId == 23)) {
                AmxPeruNewSubscription_TypedDataContext3 refDataContext23 = new AmxPeruNewSubscription_TypedDataContext3(locations, true);
                return refDataContext23.GetLocation<string>(refDataContext23.ValueType___Expr23Get, refDataContext23.ValueType___Expr23Set);
            }
            if ((expressionId == 24)) {
                AmxPeruNewSubscription_TypedDataContext3 refDataContext24 = new AmxPeruNewSubscription_TypedDataContext3(locations, true);
                return refDataContext24.GetLocation<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_billingaccount>>(refDataContext24.ValueType___Expr24Get, refDataContext24.ValueType___Expr24Set);
            }
            if ((expressionId == 25)) {
                AmxPeruNewSubscription_TypedDataContext3 refDataContext25 = new AmxPeruNewSubscription_TypedDataContext3(locations, true);
                return refDataContext25.GetLocation<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.TwoOption>>(refDataContext25.ValueType___Expr25Get, refDataContext25.ValueType___Expr25Set);
            }
            if ((expressionId == 26)) {
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext26 = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext26.ValueType___Expr26Get();
            }
            if ((expressionId == 27)) {
                AmxPeruNewSubscription_TypedDataContext3 refDataContext27 = new AmxPeruNewSubscription_TypedDataContext3(locations, true);
                return refDataContext27.GetLocation<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.TwoOption>>(refDataContext27.ValueType___Expr27Get, refDataContext27.ValueType___Expr27Set);
            }
            if ((expressionId == 28)) {
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext28 = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext28.ValueType___Expr28Get();
            }
            if ((expressionId == 29)) {
                AmxPeruNewSubscription_TypedDataContext3 refDataContext29 = new AmxPeruNewSubscription_TypedDataContext3(locations, true);
                return refDataContext29.GetLocation<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>>(refDataContext29.ValueType___Expr29Get, refDataContext29.ValueType___Expr29Set);
            }
            if ((expressionId == 30)) {
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext30 = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext30.ValueType___Expr30Get();
            }
            if ((expressionId == 31)) {
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext31 = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext31.ValueType___Expr31Get();
            }
            if ((expressionId == 32)) {
                AmxPeruNewSubscription_TypedDataContext6_ForReadOnly valDataContext32 = new AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(locations, true);
                return valDataContext32.ValueType___Expr32Get();
            }
            if ((expressionId == 33)) {
                AmxPeruNewSubscription_TypedDataContext6 refDataContext33 = new AmxPeruNewSubscription_TypedDataContext6(locations, true);
                return refDataContext33.GetLocation<AmxPeruPSBActivities.Model.BillingAccount>(refDataContext33.ValueType___Expr33Get, refDataContext33.ValueType___Expr33Set);
            }
            if ((expressionId == 34)) {
                AmxPeruNewSubscription_TypedDataContext6_ForReadOnly valDataContext34 = new AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(locations, true);
                return valDataContext34.ValueType___Expr34Get();
            }
            if ((expressionId == 35)) {
                AmxPeruNewSubscription_TypedDataContext6 refDataContext35 = new AmxPeruNewSubscription_TypedDataContext6(locations, true);
                return refDataContext35.GetLocation<string>(refDataContext35.ValueType___Expr35Get, refDataContext35.ValueType___Expr35Set);
            }
            if ((expressionId == 36)) {
                AmxPeruNewSubscription_TypedDataContext6_ForReadOnly valDataContext36 = new AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(locations, true);
                return valDataContext36.ValueType___Expr36Get();
            }
            if ((expressionId == 37)) {
                AmxPeruNewSubscription_TypedDataContext6 refDataContext37 = new AmxPeruNewSubscription_TypedDataContext6(locations, true);
                return refDataContext37.GetLocation<string>(refDataContext37.ValueType___Expr37Get, refDataContext37.ValueType___Expr37Set);
            }
            if ((expressionId == 38)) {
                AmxPeruNewSubscription_TypedDataContext6_ForReadOnly valDataContext38 = new AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(locations, true);
                return valDataContext38.ValueType___Expr38Get();
            }
            if ((expressionId == 39)) {
                AmxPeruNewSubscription_TypedDataContext6 refDataContext39 = new AmxPeruNewSubscription_TypedDataContext6(locations, true);
                return refDataContext39.GetLocation<string>(refDataContext39.ValueType___Expr39Get, refDataContext39.ValueType___Expr39Set);
            }
            if ((expressionId == 40)) {
                AmxPeruNewSubscription_TypedDataContext6_ForReadOnly valDataContext40 = new AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(locations, true);
                return valDataContext40.ValueType___Expr40Get();
            }
            if ((expressionId == 41)) {
                AmxPeruNewSubscription_TypedDataContext6 refDataContext41 = new AmxPeruNewSubscription_TypedDataContext6(locations, true);
                return refDataContext41.GetLocation<string>(refDataContext41.ValueType___Expr41Get, refDataContext41.ValueType___Expr41Set);
            }
            if ((expressionId == 42)) {
                AmxPeruNewSubscription_TypedDataContext6_ForReadOnly valDataContext42 = new AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(locations, true);
                return valDataContext42.ValueType___Expr42Get();
            }
            if ((expressionId == 43)) {
                AmxPeruNewSubscription_TypedDataContext6 refDataContext43 = new AmxPeruNewSubscription_TypedDataContext6(locations, true);
                return refDataContext43.GetLocation<string>(refDataContext43.ValueType___Expr43Get, refDataContext43.ValueType___Expr43Set);
            }
            if ((expressionId == 44)) {
                AmxPeruNewSubscription_TypedDataContext6_ForReadOnly valDataContext44 = new AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(locations, true);
                return valDataContext44.ValueType___Expr44Get();
            }
            if ((expressionId == 45)) {
                AmxPeruNewSubscription_TypedDataContext6 refDataContext45 = new AmxPeruNewSubscription_TypedDataContext6(locations, true);
                return refDataContext45.GetLocation<string>(refDataContext45.ValueType___Expr45Get, refDataContext45.ValueType___Expr45Set);
            }
            if ((expressionId == 46)) {
                AmxPeruNewSubscription_TypedDataContext6 refDataContext46 = new AmxPeruNewSubscription_TypedDataContext6(locations, true);
                return refDataContext46.GetLocation<string>(refDataContext46.ValueType___Expr46Get, refDataContext46.ValueType___Expr46Set);
            }
            if ((expressionId == 47)) {
                AmxPeruNewSubscription_TypedDataContext6_ForReadOnly valDataContext47 = new AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(locations, true);
                return valDataContext47.ValueType___Expr47Get();
            }
            if ((expressionId == 48)) {
                AmxPeruNewSubscription_TypedDataContext6_ForReadOnly valDataContext48 = new AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(locations, true);
                return valDataContext48.ValueType___Expr48Get();
            }
            if ((expressionId == 49)) {
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext49 = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext49.ValueType___Expr49Get();
            }
            if ((expressionId == 50)) {
                AmxPeruNewSubscription_TypedDataContext3 refDataContext50 = new AmxPeruNewSubscription_TypedDataContext3(locations, true);
                return refDataContext50.GetLocation<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>>(refDataContext50.ValueType___Expr50Get, refDataContext50.ValueType___Expr50Set);
            }
            if ((expressionId == 51)) {
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext51 = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext51.ValueType___Expr51Get();
            }
            if ((expressionId == 52)) {
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext52 = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext52.ValueType___Expr52Get();
            }
            if ((expressionId == 53)) {
                AmxPeruNewSubscription_TypedDataContext3 refDataContext53 = new AmxPeruNewSubscription_TypedDataContext3(locations, true);
                return refDataContext53.GetLocation<AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest>(refDataContext53.ValueType___Expr53Get, refDataContext53.ValueType___Expr53Set);
            }
            if ((expressionId == 54)) {
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext54 = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext54.ValueType___Expr54Get();
            }
            if ((expressionId == 55)) {
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext55 = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext55.ValueType___Expr55Get();
            }
            if ((expressionId == 56)) {
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext56 = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext56.ValueType___Expr56Get();
            }
            if ((expressionId == 57)) {
                AmxPeruNewSubscription_TypedDataContext3 refDataContext57 = new AmxPeruNewSubscription_TypedDataContext3(locations, true);
                return refDataContext57.GetLocation<string>(refDataContext57.ValueType___Expr57Get, refDataContext57.ValueType___Expr57Set);
            }
            if ((expressionId == 58)) {
                AmxPeruNewSubscription_TypedDataContext3 refDataContext58 = new AmxPeruNewSubscription_TypedDataContext3(locations, true);
                return refDataContext58.GetLocation<string>(refDataContext58.ValueType___Expr58Get, refDataContext58.ValueType___Expr58Set);
            }
            if ((expressionId == 59)) {
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext59 = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext59.ValueType___Expr59Get();
            }
            if ((expressionId == 60)) {
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext60 = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext60.ValueType___Expr60Get();
            }
            if ((expressionId == 61)) {
                AmxPeruNewSubscription_TypedDataContext3 refDataContext61 = new AmxPeruNewSubscription_TypedDataContext3(locations, true);
                return refDataContext61.GetLocation<AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse>(refDataContext61.ValueType___Expr61Get, refDataContext61.ValueType___Expr61Set);
            }
            if ((expressionId == 62)) {
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext62 = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext62.ValueType___Expr62Get();
            }
            if ((expressionId == 63)) {
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext63 = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext63.ValueType___Expr63Get();
            }
            if ((expressionId == 64)) {
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext64 = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext64.ValueType___Expr64Get();
            }
            if ((expressionId == 65)) {
                AmxPeruNewSubscription_TypedDataContext3 refDataContext65 = new AmxPeruNewSubscription_TypedDataContext3(locations, true);
                return refDataContext65.GetLocation<AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse>(refDataContext65.ValueType___Expr65Get, refDataContext65.ValueType___Expr65Set);
            }
            if ((expressionId == 66)) {
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext66 = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext66.ValueType___Expr66Get();
            }
            if ((expressionId == 67)) {
                AmxPeruNewSubscription_TypedDataContext3_ForReadOnly valDataContext67 = new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext67.ValueType___Expr67Get();
            }
            if ((expressionId == 68)) {
                AmxPeruNewSubscription_TypedDataContext7_ForReadOnly valDataContext68 = new AmxPeruNewSubscription_TypedDataContext7_ForReadOnly(locations, true);
                return valDataContext68.ValueType___Expr68Get();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool CanExecuteExpression(string expressionText, bool isReference, System.Collections.Generic.IList<System.Activities.LocationReference> locations, out int expressionId) {
            if (((isReference == false) 
                        && ((expressionText == "new List<AmxPeruPSBActivities.Model.CustomerAddressModel>()") 
                        && (AmxPeruNewSubscription_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 0;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new List<BillingAccount>()") 
                        && (AmxPeruNewSubscription_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 1;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new ConfigurableItemsModel()") 
                        && (AmxPeruNewSubscription_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 2;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new ConfigurableItemsModel()") 
                        && (AmxPeruNewSubscription_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 3;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "connectionString") 
                        && (AmxPeruNewSubscription_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 4;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "connectionString") 
                        && (AmxPeruNewSubscription_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 5;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "orderBasket") 
                        && (AmxPeruNewSubscription_TypedDataContext4.Validate(locations, true, 0) == true)))) {
                expressionId = 6;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "orderCaptureId") 
                        && (AmxPeruNewSubscription_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 7;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "orderBasket") 
                        && (AmxPeruNewSubscription_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 8;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "configurableOrderBasket") 
                        && (AmxPeruNewSubscription_TypedDataContext4.Validate(locations, true, 0) == true)))) {
                expressionId = 9;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "configurableOrderBasket.hasConfigurableItems") 
                        && (AmxPeruNewSubscription_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 10;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "order") 
                        && (AmxPeruNewSubscription_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 11;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "configurableOrderBasket") 
                        && (AmxPeruNewSubscription_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 12;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "orderItemBasket") 
                        && (AmxPeruNewSubscription_TypedDataContext4.Validate(locations, true, 0) == true)))) {
                expressionId = 13;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "productExternalId") 
                        && (AmxPeruNewSubscription_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 14;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "cfssCharacteristicList") 
                        && (AmxPeruNewSubscription_TypedDataContext4.Validate(locations, true, 0) == true)))) {
                expressionId = 15;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "corporateCustomer") 
                        && (AmxPeruNewSubscription_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 16;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "customerType") 
                        && (AmxPeruNewSubscription_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 17;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "corporateCustomerId") 
                        && (AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 18;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "individualCustomerId") 
                        && (AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 19;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "individualCustomer") 
                        && (AmxPeruNewSubscription_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 20;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "customerType.Equals(Account.EntityLogicalName) ? corporateCustomerId : individual" +
                            "CustomerId") 
                        && (AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 21;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "customerType.Equals(Account.EntityLogicalName) ? Account.EntityTypeCode : Convert" +
                            ".ToInt32(Ericsson.ETELCRM.Entities.Crm.Contact.EntityTypeCode)") 
                        && (AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 22;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "languageId") 
                        && (AmxPeruNewSubscription_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 23;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "billingAccountList") 
                        && (AmxPeruNewSubscription_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 24;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "isPrimaryOptionSet") 
                        && (AmxPeruNewSubscription_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 25;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "int.Parse(languageId)") 
                        && (AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 26;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "callItemizationOptionSet") 
                        && (AmxPeruNewSubscription_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 27;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "int.Parse(languageId)") 
                        && (AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 28;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "billMediumOptionSet") 
                        && (AmxPeruNewSubscription_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 29;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "int.Parse(languageId)") 
                        && (AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 30;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "billingAccountList") 
                        && (AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 31;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new BillingAccount()") 
                        && (AmxPeruNewSubscription_TypedDataContext6_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 32;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "billingAccount") 
                        && (AmxPeruNewSubscription_TypedDataContext6.Validate(locations, true, 0) == true)))) {
                expressionId = 33;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "item.etel_name") 
                        && (AmxPeruNewSubscription_TypedDataContext6_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 34;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "billingAccount.billingAccount") 
                        && (AmxPeruNewSubscription_TypedDataContext6.Validate(locations, true, 0) == true)))) {
                expressionId = 35;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "item.etel_billtoaddressid == null ? string.Empty : item.etel_billtoaddressid.Name" +
                            "") 
                        && (AmxPeruNewSubscription_TypedDataContext6_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 36;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "billingAccount.billingAddress") 
                        && (AmxPeruNewSubscription_TypedDataContext6.Validate(locations, true, 0) == true)))) {
                expressionId = 37;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "item.etel_mailtoaddressid == null ? string.Empty : item.etel_mailtoaddressid.Name" +
                            "") 
                        && (AmxPeruNewSubscription_TypedDataContext6_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 38;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "billingAccount.mailingAddress") 
                        && (AmxPeruNewSubscription_TypedDataContext6.Validate(locations, true, 0) == true)))) {
                expressionId = 39;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "(billMediumOptionSet == null || item.etel_billmediumcode == null) ? \n            " +
                            "    string.Empty : \n                billMediumOptionSet.FirstOrDefault(x => x.Va" +
                            "lue == item.etel_billmediumcode.Value).Text") 
                        && (AmxPeruNewSubscription_TypedDataContext6_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 40;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "billingAccount.billMedium") 
                        && (AmxPeruNewSubscription_TypedDataContext6.Validate(locations, true, 0) == true)))) {
                expressionId = 41;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "(callItemizationOptionSet == null || item.etel_allowcallitemizationoninvoice == n" +
                            "ull) \n                ? null \n                : callItemizationOptionSet.FirstOr" +
                            "Default(x => x.Value == item.etel_allowcallitemizationoninvoice).Text") 
                        && (AmxPeruNewSubscription_TypedDataContext6_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 42;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "billingAccount.callItemization") 
                        && (AmxPeruNewSubscription_TypedDataContext6.Validate(locations, true, 0) == true)))) {
                expressionId = 43;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "item.etel_numberofcopies == null ? string.Empty : item.etel_numberofcopies.Value." +
                            "ToString()") 
                        && (AmxPeruNewSubscription_TypedDataContext6_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 44;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "billingAccount.numberOfCopies") 
                        && (AmxPeruNewSubscription_TypedDataContext6.Validate(locations, true, 0) == true)))) {
                expressionId = 45;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "billingAccount.language") 
                        && (AmxPeruNewSubscription_TypedDataContext6.Validate(locations, true, 0) == true)))) {
                expressionId = 46;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "billingAccountListModel") 
                        && (AmxPeruNewSubscription_TypedDataContext6_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 47;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "billingAccount") 
                        && (AmxPeruNewSubscription_TypedDataContext6_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 48;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "appointmentRequired") 
                        && (AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 49;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "resourceTypeCodes") 
                        && (AmxPeruNewSubscription_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 50;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "etel_productresourcespecification.EntityLogicalName") 
                        && (AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 51;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "corporateCustomer") 
                        && (AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 52;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "submitRequest") 
                        && (AmxPeruNewSubscription_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 53;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new Guid(orderCaptureId)") 
                        && (AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 54;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "individualCustomer") 
                        && (AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 55;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "resourceTypeCodes") 
                        && (AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 56;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "orderSubmitEndpoint") 
                        && (AmxPeruNewSubscription_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 57;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "eocTimoutInMiliseconds") 
                        && (AmxPeruNewSubscription_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 58;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "submitRequest") 
                        && (AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 59;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "Ericsson.PSB.Workflow.Client.Core.Serializer.JsonSettings.Custom") 
                        && (AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 60;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "omResponse") 
                        && (AmxPeruNewSubscription_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 61;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "eocTimoutInMiliseconds") 
                        && (AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 62;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "orderSubmitEndpoint") 
                        && (AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 63;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "omResponse") 
                        && (AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 64;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "submitOrderResponse") 
                        && (AmxPeruNewSubscription_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 65;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new Guid(orderCaptureId)") 
                        && (AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 66;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "submitOrderResponse.id") 
                        && (AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 67;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new Exception(exception.Message)") 
                        && (AmxPeruNewSubscription_TypedDataContext7_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 68;
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
                return new AmxPeruNewSubscription_TypedDataContext2_ForReadOnly(locationReferences).@__Expr0GetTree();
            }
            if ((expressionId == 1)) {
                return new AmxPeruNewSubscription_TypedDataContext2_ForReadOnly(locationReferences).@__Expr1GetTree();
            }
            if ((expressionId == 2)) {
                return new AmxPeruNewSubscription_TypedDataContext2_ForReadOnly(locationReferences).@__Expr2GetTree();
            }
            if ((expressionId == 3)) {
                return new AmxPeruNewSubscription_TypedDataContext2_ForReadOnly(locationReferences).@__Expr3GetTree();
            }
            if ((expressionId == 4)) {
                return new AmxPeruNewSubscription_TypedDataContext2(locationReferences).@__Expr4GetTree();
            }
            if ((expressionId == 5)) {
                return new AmxPeruNewSubscription_TypedDataContext2_ForReadOnly(locationReferences).@__Expr5GetTree();
            }
            if ((expressionId == 6)) {
                return new AmxPeruNewSubscription_TypedDataContext4(locationReferences).@__Expr6GetTree();
            }
            if ((expressionId == 7)) {
                return new AmxPeruNewSubscription_TypedDataContext4_ForReadOnly(locationReferences).@__Expr7GetTree();
            }
            if ((expressionId == 8)) {
                return new AmxPeruNewSubscription_TypedDataContext4_ForReadOnly(locationReferences).@__Expr8GetTree();
            }
            if ((expressionId == 9)) {
                return new AmxPeruNewSubscription_TypedDataContext4(locationReferences).@__Expr9GetTree();
            }
            if ((expressionId == 10)) {
                return new AmxPeruNewSubscription_TypedDataContext4_ForReadOnly(locationReferences).@__Expr10GetTree();
            }
            if ((expressionId == 11)) {
                return new AmxPeruNewSubscription_TypedDataContext4_ForReadOnly(locationReferences).@__Expr11GetTree();
            }
            if ((expressionId == 12)) {
                return new AmxPeruNewSubscription_TypedDataContext4_ForReadOnly(locationReferences).@__Expr12GetTree();
            }
            if ((expressionId == 13)) {
                return new AmxPeruNewSubscription_TypedDataContext4(locationReferences).@__Expr13GetTree();
            }
            if ((expressionId == 14)) {
                return new AmxPeruNewSubscription_TypedDataContext4_ForReadOnly(locationReferences).@__Expr14GetTree();
            }
            if ((expressionId == 15)) {
                return new AmxPeruNewSubscription_TypedDataContext4(locationReferences).@__Expr15GetTree();
            }
            if ((expressionId == 16)) {
                return new AmxPeruNewSubscription_TypedDataContext3(locationReferences).@__Expr16GetTree();
            }
            if ((expressionId == 17)) {
                return new AmxPeruNewSubscription_TypedDataContext3(locationReferences).@__Expr17GetTree();
            }
            if ((expressionId == 18)) {
                return new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locationReferences).@__Expr18GetTree();
            }
            if ((expressionId == 19)) {
                return new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locationReferences).@__Expr19GetTree();
            }
            if ((expressionId == 20)) {
                return new AmxPeruNewSubscription_TypedDataContext3(locationReferences).@__Expr20GetTree();
            }
            if ((expressionId == 21)) {
                return new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locationReferences).@__Expr21GetTree();
            }
            if ((expressionId == 22)) {
                return new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locationReferences).@__Expr22GetTree();
            }
            if ((expressionId == 23)) {
                return new AmxPeruNewSubscription_TypedDataContext3(locationReferences).@__Expr23GetTree();
            }
            if ((expressionId == 24)) {
                return new AmxPeruNewSubscription_TypedDataContext3(locationReferences).@__Expr24GetTree();
            }
            if ((expressionId == 25)) {
                return new AmxPeruNewSubscription_TypedDataContext3(locationReferences).@__Expr25GetTree();
            }
            if ((expressionId == 26)) {
                return new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locationReferences).@__Expr26GetTree();
            }
            if ((expressionId == 27)) {
                return new AmxPeruNewSubscription_TypedDataContext3(locationReferences).@__Expr27GetTree();
            }
            if ((expressionId == 28)) {
                return new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locationReferences).@__Expr28GetTree();
            }
            if ((expressionId == 29)) {
                return new AmxPeruNewSubscription_TypedDataContext3(locationReferences).@__Expr29GetTree();
            }
            if ((expressionId == 30)) {
                return new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locationReferences).@__Expr30GetTree();
            }
            if ((expressionId == 31)) {
                return new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locationReferences).@__Expr31GetTree();
            }
            if ((expressionId == 32)) {
                return new AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(locationReferences).@__Expr32GetTree();
            }
            if ((expressionId == 33)) {
                return new AmxPeruNewSubscription_TypedDataContext6(locationReferences).@__Expr33GetTree();
            }
            if ((expressionId == 34)) {
                return new AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(locationReferences).@__Expr34GetTree();
            }
            if ((expressionId == 35)) {
                return new AmxPeruNewSubscription_TypedDataContext6(locationReferences).@__Expr35GetTree();
            }
            if ((expressionId == 36)) {
                return new AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(locationReferences).@__Expr36GetTree();
            }
            if ((expressionId == 37)) {
                return new AmxPeruNewSubscription_TypedDataContext6(locationReferences).@__Expr37GetTree();
            }
            if ((expressionId == 38)) {
                return new AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(locationReferences).@__Expr38GetTree();
            }
            if ((expressionId == 39)) {
                return new AmxPeruNewSubscription_TypedDataContext6(locationReferences).@__Expr39GetTree();
            }
            if ((expressionId == 40)) {
                return new AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(locationReferences).@__Expr40GetTree();
            }
            if ((expressionId == 41)) {
                return new AmxPeruNewSubscription_TypedDataContext6(locationReferences).@__Expr41GetTree();
            }
            if ((expressionId == 42)) {
                return new AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(locationReferences).@__Expr42GetTree();
            }
            if ((expressionId == 43)) {
                return new AmxPeruNewSubscription_TypedDataContext6(locationReferences).@__Expr43GetTree();
            }
            if ((expressionId == 44)) {
                return new AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(locationReferences).@__Expr44GetTree();
            }
            if ((expressionId == 45)) {
                return new AmxPeruNewSubscription_TypedDataContext6(locationReferences).@__Expr45GetTree();
            }
            if ((expressionId == 46)) {
                return new AmxPeruNewSubscription_TypedDataContext6(locationReferences).@__Expr46GetTree();
            }
            if ((expressionId == 47)) {
                return new AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(locationReferences).@__Expr47GetTree();
            }
            if ((expressionId == 48)) {
                return new AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(locationReferences).@__Expr48GetTree();
            }
            if ((expressionId == 49)) {
                return new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locationReferences).@__Expr49GetTree();
            }
            if ((expressionId == 50)) {
                return new AmxPeruNewSubscription_TypedDataContext3(locationReferences).@__Expr50GetTree();
            }
            if ((expressionId == 51)) {
                return new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locationReferences).@__Expr51GetTree();
            }
            if ((expressionId == 52)) {
                return new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locationReferences).@__Expr52GetTree();
            }
            if ((expressionId == 53)) {
                return new AmxPeruNewSubscription_TypedDataContext3(locationReferences).@__Expr53GetTree();
            }
            if ((expressionId == 54)) {
                return new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locationReferences).@__Expr54GetTree();
            }
            if ((expressionId == 55)) {
                return new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locationReferences).@__Expr55GetTree();
            }
            if ((expressionId == 56)) {
                return new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locationReferences).@__Expr56GetTree();
            }
            if ((expressionId == 57)) {
                return new AmxPeruNewSubscription_TypedDataContext3(locationReferences).@__Expr57GetTree();
            }
            if ((expressionId == 58)) {
                return new AmxPeruNewSubscription_TypedDataContext3(locationReferences).@__Expr58GetTree();
            }
            if ((expressionId == 59)) {
                return new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locationReferences).@__Expr59GetTree();
            }
            if ((expressionId == 60)) {
                return new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locationReferences).@__Expr60GetTree();
            }
            if ((expressionId == 61)) {
                return new AmxPeruNewSubscription_TypedDataContext3(locationReferences).@__Expr61GetTree();
            }
            if ((expressionId == 62)) {
                return new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locationReferences).@__Expr62GetTree();
            }
            if ((expressionId == 63)) {
                return new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locationReferences).@__Expr63GetTree();
            }
            if ((expressionId == 64)) {
                return new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locationReferences).@__Expr64GetTree();
            }
            if ((expressionId == 65)) {
                return new AmxPeruNewSubscription_TypedDataContext3(locationReferences).@__Expr65GetTree();
            }
            if ((expressionId == 66)) {
                return new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locationReferences).@__Expr66GetTree();
            }
            if ((expressionId == 67)) {
                return new AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(locationReferences).@__Expr67GetTree();
            }
            if ((expressionId == 68)) {
                return new AmxPeruNewSubscription_TypedDataContext7_ForReadOnly(locationReferences).@__Expr68GetTree();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruNewSubscription_TypedDataContext0 : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruNewSubscription_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext0(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class AmxPeruNewSubscription_TypedDataContext0_ForReadOnly : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruNewSubscription_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class AmxPeruNewSubscription_TypedDataContext1 : AmxPeruNewSubscription_TypedDataContext0 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruNewSubscription_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext1(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
            
            protected AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse submitOrderResponse {
                get {
                    return ((AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse)(this.GetVariableValue((1 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((1 + locationsOffset), value);
                }
            }
            
            protected string languageId {
                get {
                    return ((string)(this.GetVariableValue((2 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((2 + locationsOffset), value);
                }
            }
            
            protected string orderCaptureId {
                get {
                    return ((string)(this.GetVariableValue((3 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((3 + locationsOffset), value);
                }
            }
            
            protected AmxPeruPSBActivities.Model.OrderItemsBasketModel orderBasket {
                get {
                    return ((AmxPeruPSBActivities.Model.OrderItemsBasketModel)(this.GetVariableValue((4 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((4 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.List<AmxPeruPSBActivities.Model.Appointment.AppEventModel> calendarEvents {
                get {
                    return ((System.Collections.Generic.List<AmxPeruPSBActivities.Model.Appointment.AppEventModel>)(this.GetVariableValue((5 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((5 + locationsOffset), value);
                }
            }
            
            protected AmxPeruPSBActivities.Model.Appointment.GetCapacityResponseModel getCapacityResponse {
                get {
                    return ((AmxPeruPSBActivities.Model.Appointment.GetCapacityResponseModel)(this.GetVariableValue((6 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((6 + locationsOffset), value);
                }
            }
            
            protected string corporateCustomerId {
                get {
                    return ((string)(this.GetVariableValue((7 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((7 + locationsOffset), value);
                }
            }
            
            protected AmxPeruPSBActivities.Model.ConfigurableItemsModel configurableOrderBasket {
                get {
                    return ((AmxPeruPSBActivities.Model.ConfigurableItemsModel)(this.GetVariableValue((8 + locationsOffset))));
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
                if (((locationReferences[(offset + 0)].Name != "individualCustomerId") 
                            || (locationReferences[(offset + 0)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "submitOrderResponse") 
                            || (locationReferences[(offset + 1)].Type != typeof(AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse)))) {
                    return false;
                }
                if (((locationReferences[(offset + 2)].Name != "languageId") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "orderCaptureId") 
                            || (locationReferences[(offset + 3)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "orderBasket") 
                            || (locationReferences[(offset + 4)].Type != typeof(AmxPeruPSBActivities.Model.OrderItemsBasketModel)))) {
                    return false;
                }
                if (((locationReferences[(offset + 5)].Name != "calendarEvents") 
                            || (locationReferences[(offset + 5)].Type != typeof(System.Collections.Generic.List<AmxPeruPSBActivities.Model.Appointment.AppEventModel>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "getCapacityResponse") 
                            || (locationReferences[(offset + 6)].Type != typeof(AmxPeruPSBActivities.Model.Appointment.GetCapacityResponseModel)))) {
                    return false;
                }
                if (((locationReferences[(offset + 7)].Name != "corporateCustomerId") 
                            || (locationReferences[(offset + 7)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 8)].Name != "configurableOrderBasket") 
                            || (locationReferences[(offset + 8)].Type != typeof(AmxPeruPSBActivities.Model.ConfigurableItemsModel)))) {
                    return false;
                }
                return AmxPeruNewSubscription_TypedDataContext0.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruNewSubscription_TypedDataContext1_ForReadOnly : AmxPeruNewSubscription_TypedDataContext0_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruNewSubscription_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string individualCustomerId {
                get {
                    return ((string)(this.GetVariableValue((0 + locationsOffset))));
                }
            }
            
            protected AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse submitOrderResponse {
                get {
                    return ((AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse)(this.GetVariableValue((1 + locationsOffset))));
                }
            }
            
            protected string languageId {
                get {
                    return ((string)(this.GetVariableValue((2 + locationsOffset))));
                }
            }
            
            protected string orderCaptureId {
                get {
                    return ((string)(this.GetVariableValue((3 + locationsOffset))));
                }
            }
            
            protected AmxPeruPSBActivities.Model.OrderItemsBasketModel orderBasket {
                get {
                    return ((AmxPeruPSBActivities.Model.OrderItemsBasketModel)(this.GetVariableValue((4 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.List<AmxPeruPSBActivities.Model.Appointment.AppEventModel> calendarEvents {
                get {
                    return ((System.Collections.Generic.List<AmxPeruPSBActivities.Model.Appointment.AppEventModel>)(this.GetVariableValue((5 + locationsOffset))));
                }
            }
            
            protected AmxPeruPSBActivities.Model.Appointment.GetCapacityResponseModel getCapacityResponse {
                get {
                    return ((AmxPeruPSBActivities.Model.Appointment.GetCapacityResponseModel)(this.GetVariableValue((6 + locationsOffset))));
                }
            }
            
            protected string corporateCustomerId {
                get {
                    return ((string)(this.GetVariableValue((7 + locationsOffset))));
                }
            }
            
            protected AmxPeruPSBActivities.Model.ConfigurableItemsModel configurableOrderBasket {
                get {
                    return ((AmxPeruPSBActivities.Model.ConfigurableItemsModel)(this.GetVariableValue((8 + locationsOffset))));
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
                if (((locationReferences[(offset + 0)].Name != "individualCustomerId") 
                            || (locationReferences[(offset + 0)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "submitOrderResponse") 
                            || (locationReferences[(offset + 1)].Type != typeof(AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse)))) {
                    return false;
                }
                if (((locationReferences[(offset + 2)].Name != "languageId") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "orderCaptureId") 
                            || (locationReferences[(offset + 3)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "orderBasket") 
                            || (locationReferences[(offset + 4)].Type != typeof(AmxPeruPSBActivities.Model.OrderItemsBasketModel)))) {
                    return false;
                }
                if (((locationReferences[(offset + 5)].Name != "calendarEvents") 
                            || (locationReferences[(offset + 5)].Type != typeof(System.Collections.Generic.List<AmxPeruPSBActivities.Model.Appointment.AppEventModel>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "getCapacityResponse") 
                            || (locationReferences[(offset + 6)].Type != typeof(AmxPeruPSBActivities.Model.Appointment.GetCapacityResponseModel)))) {
                    return false;
                }
                if (((locationReferences[(offset + 7)].Name != "corporateCustomerId") 
                            || (locationReferences[(offset + 7)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 8)].Name != "configurableOrderBasket") 
                            || (locationReferences[(offset + 8)].Type != typeof(AmxPeruPSBActivities.Model.ConfigurableItemsModel)))) {
                    return false;
                }
                return AmxPeruNewSubscription_TypedDataContext0_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruNewSubscription_TypedDataContext2 : AmxPeruNewSubscription_TypedDataContext1 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected bool appointmentRequired;
            
            public AmxPeruNewSubscription_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext2(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string connectionString {
                get {
                    return ((string)(this.GetVariableValue((9 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((9 + locationsOffset), value);
                }
            }
            
            protected string location {
                get {
                    return ((string)(this.GetVariableValue((10 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((10 + locationsOffset), value);
                }
            }
            
            protected string province {
                get {
                    return ((string)(this.GetVariableValue((11 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((11 + locationsOffset), value);
                }
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.ICustomer customer {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.ICustomer)(this.GetVariableValue((12 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((12 + locationsOffset), value);
                }
            }
            
            protected AmxPeruPSBActivities.Model.CustomerAddressModel addressModel {
                get {
                    return ((AmxPeruPSBActivities.Model.CustomerAddressModel)(this.GetVariableValue((13 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((13 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.List<AmxPeruPSBActivities.Model.CustomerAddressModel> customerAddressListModel {
                get {
                    return ((System.Collections.Generic.List<AmxPeruPSBActivities.Model.CustomerAddressModel>)(this.GetVariableValue((14 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((14 + locationsOffset), value);
                }
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.etel_customeraddress[] customerAddressList {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.etel_customeraddress[])(this.GetVariableValue((15 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((15 + locationsOffset), value);
                }
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.Contact individualCustomer {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.Contact)(this.GetVariableValue((16 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((16 + locationsOffset), value);
                }
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.Account corporateCustomer {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.Account)(this.GetVariableValue((17 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((17 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_billingaccount> billingAccountList {
                get {
                    return ((System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_billingaccount>)(this.GetVariableValue((18 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((18 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.List<AmxPeruPSBActivities.Model.BillingAccount> billingAccountListModel {
                get {
                    return ((System.Collections.Generic.List<AmxPeruPSBActivities.Model.BillingAccount>)(this.GetVariableValue((19 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((19 + locationsOffset), value);
                }
            }
            
            protected AmxPeruPSBActivities.Model.BillingAccount billingAccount {
                get {
                    return ((AmxPeruPSBActivities.Model.BillingAccount)(this.GetVariableValue((20 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((20 + locationsOffset), value);
                }
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.etel_ordercapture orderCapture {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.etel_ordercapture)(this.GetVariableValue((21 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((21 + locationsOffset), value);
                }
            }
            
            protected AmxPeruPSBActivities.Model.AmxPeruOfferingPriceModel order {
                get {
                    return ((AmxPeruPSBActivities.Model.AmxPeruOfferingPriceModel)(this.GetVariableValue((22 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((22 + locationsOffset), value);
                }
            }
            
            protected AmxPeruPSBActivities.Model.BillingAccount selectedBillingAccount {
                get {
                    return ((AmxPeruPSBActivities.Model.BillingAccount)(this.GetVariableValue((23 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((23 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> billMediumOptionSet {
                get {
                    return ((System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>)(this.GetVariableValue((24 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((24 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.TwoOption> callItemizationOptionSet {
                get {
                    return ((System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.TwoOption>)(this.GetVariableValue((25 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((25 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.TwoOption> isPrimaryOptionSet {
                get {
                    return ((System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.TwoOption>)(this.GetVariableValue((26 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((26 + locationsOffset), value);
                }
            }
            
            protected string orderSubmitEndpoint {
                get {
                    return ((string)(this.GetVariableValue((27 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((27 + locationsOffset), value);
                }
            }
            
            protected string eocTimoutInMiliseconds {
                get {
                    return ((string)(this.GetVariableValue((28 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((28 + locationsOffset), value);
                }
            }
            
            protected AmxPeruPSBActivities.Model.ConfigurableItemsModel orderItemBasket {
                get {
                    return ((AmxPeruPSBActivities.Model.ConfigurableItemsModel)(this.GetVariableValue((29 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((29 + locationsOffset), value);
                }
            }
            
            protected AmxPeruPSBActivities.Model.ConfigurableItemsModel configurableItems {
                get {
                    return ((AmxPeruPSBActivities.Model.ConfigurableItemsModel)(this.GetVariableValue((30 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((30 + locationsOffset), value);
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
                
                #line 145 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
              connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr4Get() {
                
                #line 145 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
              connectionString;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr4Get() {
                this.GetValueTypeValues();
                return this.@__Expr4Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr4Set(string value) {
                
                #line 145 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                
              connectionString = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr4Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr4Set(value);
                this.SetValueTypeValues();
            }
            
            protected override void GetValueTypeValues() {
                this.appointmentRequired = ((bool)(this.GetVariableValue((31 + locationsOffset))));
                base.GetValueTypeValues();
            }
            
            protected override void SetValueTypeValues() {
                this.SetVariableValue((31 + locationsOffset), this.appointmentRequired);
                base.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 32))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 32);
                }
                expectedLocationsCount = 32;
                if (((locationReferences[(offset + 9)].Name != "connectionString") 
                            || (locationReferences[(offset + 9)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 10)].Name != "location") 
                            || (locationReferences[(offset + 10)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 11)].Name != "province") 
                            || (locationReferences[(offset + 11)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 12)].Name != "customer") 
                            || (locationReferences[(offset + 12)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.ICustomer)))) {
                    return false;
                }
                if (((locationReferences[(offset + 13)].Name != "addressModel") 
                            || (locationReferences[(offset + 13)].Type != typeof(AmxPeruPSBActivities.Model.CustomerAddressModel)))) {
                    return false;
                }
                if (((locationReferences[(offset + 14)].Name != "customerAddressListModel") 
                            || (locationReferences[(offset + 14)].Type != typeof(System.Collections.Generic.List<AmxPeruPSBActivities.Model.CustomerAddressModel>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 15)].Name != "customerAddressList") 
                            || (locationReferences[(offset + 15)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.etel_customeraddress[])))) {
                    return false;
                }
                if (((locationReferences[(offset + 16)].Name != "individualCustomer") 
                            || (locationReferences[(offset + 16)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.Contact)))) {
                    return false;
                }
                if (((locationReferences[(offset + 17)].Name != "corporateCustomer") 
                            || (locationReferences[(offset + 17)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.Account)))) {
                    return false;
                }
                if (((locationReferences[(offset + 18)].Name != "billingAccountList") 
                            || (locationReferences[(offset + 18)].Type != typeof(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_billingaccount>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 19)].Name != "billingAccountListModel") 
                            || (locationReferences[(offset + 19)].Type != typeof(System.Collections.Generic.List<AmxPeruPSBActivities.Model.BillingAccount>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 20)].Name != "billingAccount") 
                            || (locationReferences[(offset + 20)].Type != typeof(AmxPeruPSBActivities.Model.BillingAccount)))) {
                    return false;
                }
                if (((locationReferences[(offset + 21)].Name != "orderCapture") 
                            || (locationReferences[(offset + 21)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.etel_ordercapture)))) {
                    return false;
                }
                if (((locationReferences[(offset + 22)].Name != "order") 
                            || (locationReferences[(offset + 22)].Type != typeof(AmxPeruPSBActivities.Model.AmxPeruOfferingPriceModel)))) {
                    return false;
                }
                if (((locationReferences[(offset + 23)].Name != "selectedBillingAccount") 
                            || (locationReferences[(offset + 23)].Type != typeof(AmxPeruPSBActivities.Model.BillingAccount)))) {
                    return false;
                }
                if (((locationReferences[(offset + 24)].Name != "billMediumOptionSet") 
                            || (locationReferences[(offset + 24)].Type != typeof(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 25)].Name != "callItemizationOptionSet") 
                            || (locationReferences[(offset + 25)].Type != typeof(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.TwoOption>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 26)].Name != "isPrimaryOptionSet") 
                            || (locationReferences[(offset + 26)].Type != typeof(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.TwoOption>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 27)].Name != "orderSubmitEndpoint") 
                            || (locationReferences[(offset + 27)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 28)].Name != "eocTimoutInMiliseconds") 
                            || (locationReferences[(offset + 28)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 29)].Name != "orderItemBasket") 
                            || (locationReferences[(offset + 29)].Type != typeof(AmxPeruPSBActivities.Model.ConfigurableItemsModel)))) {
                    return false;
                }
                if (((locationReferences[(offset + 30)].Name != "configurableItems") 
                            || (locationReferences[(offset + 30)].Type != typeof(AmxPeruPSBActivities.Model.ConfigurableItemsModel)))) {
                    return false;
                }
                if (((locationReferences[(offset + 31)].Name != "appointmentRequired") 
                            || (locationReferences[(offset + 31)].Type != typeof(bool)))) {
                    return false;
                }
                return AmxPeruNewSubscription_TypedDataContext1.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruNewSubscription_TypedDataContext2_ForReadOnly : AmxPeruNewSubscription_TypedDataContext1_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected bool appointmentRequired;
            
            public AmxPeruNewSubscription_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string connectionString {
                get {
                    return ((string)(this.GetVariableValue((9 + locationsOffset))));
                }
            }
            
            protected string location {
                get {
                    return ((string)(this.GetVariableValue((10 + locationsOffset))));
                }
            }
            
            protected string province {
                get {
                    return ((string)(this.GetVariableValue((11 + locationsOffset))));
                }
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.ICustomer customer {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.ICustomer)(this.GetVariableValue((12 + locationsOffset))));
                }
            }
            
            protected AmxPeruPSBActivities.Model.CustomerAddressModel addressModel {
                get {
                    return ((AmxPeruPSBActivities.Model.CustomerAddressModel)(this.GetVariableValue((13 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.List<AmxPeruPSBActivities.Model.CustomerAddressModel> customerAddressListModel {
                get {
                    return ((System.Collections.Generic.List<AmxPeruPSBActivities.Model.CustomerAddressModel>)(this.GetVariableValue((14 + locationsOffset))));
                }
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.etel_customeraddress[] customerAddressList {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.etel_customeraddress[])(this.GetVariableValue((15 + locationsOffset))));
                }
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.Contact individualCustomer {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.Contact)(this.GetVariableValue((16 + locationsOffset))));
                }
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.Account corporateCustomer {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.Account)(this.GetVariableValue((17 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_billingaccount> billingAccountList {
                get {
                    return ((System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_billingaccount>)(this.GetVariableValue((18 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.List<AmxPeruPSBActivities.Model.BillingAccount> billingAccountListModel {
                get {
                    return ((System.Collections.Generic.List<AmxPeruPSBActivities.Model.BillingAccount>)(this.GetVariableValue((19 + locationsOffset))));
                }
            }
            
            protected AmxPeruPSBActivities.Model.BillingAccount billingAccount {
                get {
                    return ((AmxPeruPSBActivities.Model.BillingAccount)(this.GetVariableValue((20 + locationsOffset))));
                }
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.etel_ordercapture orderCapture {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.etel_ordercapture)(this.GetVariableValue((21 + locationsOffset))));
                }
            }
            
            protected AmxPeruPSBActivities.Model.AmxPeruOfferingPriceModel order {
                get {
                    return ((AmxPeruPSBActivities.Model.AmxPeruOfferingPriceModel)(this.GetVariableValue((22 + locationsOffset))));
                }
            }
            
            protected AmxPeruPSBActivities.Model.BillingAccount selectedBillingAccount {
                get {
                    return ((AmxPeruPSBActivities.Model.BillingAccount)(this.GetVariableValue((23 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> billMediumOptionSet {
                get {
                    return ((System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>)(this.GetVariableValue((24 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.TwoOption> callItemizationOptionSet {
                get {
                    return ((System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.TwoOption>)(this.GetVariableValue((25 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.TwoOption> isPrimaryOptionSet {
                get {
                    return ((System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.TwoOption>)(this.GetVariableValue((26 + locationsOffset))));
                }
            }
            
            protected string orderSubmitEndpoint {
                get {
                    return ((string)(this.GetVariableValue((27 + locationsOffset))));
                }
            }
            
            protected string eocTimoutInMiliseconds {
                get {
                    return ((string)(this.GetVariableValue((28 + locationsOffset))));
                }
            }
            
            protected AmxPeruPSBActivities.Model.ConfigurableItemsModel orderItemBasket {
                get {
                    return ((AmxPeruPSBActivities.Model.ConfigurableItemsModel)(this.GetVariableValue((29 + locationsOffset))));
                }
            }
            
            protected AmxPeruPSBActivities.Model.ConfigurableItemsModel configurableItems {
                get {
                    return ((AmxPeruPSBActivities.Model.ConfigurableItemsModel)(this.GetVariableValue((30 + locationsOffset))));
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
                
                #line 107 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<AmxPeruPSBActivities.Model.CustomerAddressModel>>> expression = () => 
          new List<AmxPeruPSBActivities.Model.CustomerAddressModel>();
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.CustomerAddressModel> @__Expr0Get() {
                
                #line 107 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
          new List<AmxPeruPSBActivities.Model.CustomerAddressModel>();
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.CustomerAddressModel> ValueType___Expr0Get() {
                this.GetValueTypeValues();
                return this.@__Expr0Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr1GetTree() {
                
                #line 116 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<AmxPeruPSBActivities.Model.BillingAccount>>> expression = () => 
          new List<BillingAccount>();
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.BillingAccount> @__Expr1Get() {
                
                #line 116 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
          new List<BillingAccount>();
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.BillingAccount> ValueType___Expr1Get() {
                this.GetValueTypeValues();
                return this.@__Expr1Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr2GetTree() {
                
                #line 130 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.ConfigurableItemsModel>> expression = () => 
          new ConfigurableItemsModel();
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.ConfigurableItemsModel @__Expr2Get() {
                
                #line 130 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
          new ConfigurableItemsModel();
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.ConfigurableItemsModel ValueType___Expr2Get() {
                this.GetValueTypeValues();
                return this.@__Expr2Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr3GetTree() {
                
                #line 135 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.ConfigurableItemsModel>> expression = () => 
          new ConfigurableItemsModel();
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.ConfigurableItemsModel @__Expr3Get() {
                
                #line 135 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
          new ConfigurableItemsModel();
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.ConfigurableItemsModel ValueType___Expr3Get() {
                this.GetValueTypeValues();
                return this.@__Expr3Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr5GetTree() {
                
                #line 1078 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr5Get() {
                
                #line 1078 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                  connectionString;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr5Get() {
                this.GetValueTypeValues();
                return this.@__Expr5Get();
            }
            
            protected override void GetValueTypeValues() {
                this.appointmentRequired = ((bool)(this.GetVariableValue((31 + locationsOffset))));
                base.GetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 32))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 32);
                }
                expectedLocationsCount = 32;
                if (((locationReferences[(offset + 9)].Name != "connectionString") 
                            || (locationReferences[(offset + 9)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 10)].Name != "location") 
                            || (locationReferences[(offset + 10)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 11)].Name != "province") 
                            || (locationReferences[(offset + 11)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 12)].Name != "customer") 
                            || (locationReferences[(offset + 12)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.ICustomer)))) {
                    return false;
                }
                if (((locationReferences[(offset + 13)].Name != "addressModel") 
                            || (locationReferences[(offset + 13)].Type != typeof(AmxPeruPSBActivities.Model.CustomerAddressModel)))) {
                    return false;
                }
                if (((locationReferences[(offset + 14)].Name != "customerAddressListModel") 
                            || (locationReferences[(offset + 14)].Type != typeof(System.Collections.Generic.List<AmxPeruPSBActivities.Model.CustomerAddressModel>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 15)].Name != "customerAddressList") 
                            || (locationReferences[(offset + 15)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.etel_customeraddress[])))) {
                    return false;
                }
                if (((locationReferences[(offset + 16)].Name != "individualCustomer") 
                            || (locationReferences[(offset + 16)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.Contact)))) {
                    return false;
                }
                if (((locationReferences[(offset + 17)].Name != "corporateCustomer") 
                            || (locationReferences[(offset + 17)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.Account)))) {
                    return false;
                }
                if (((locationReferences[(offset + 18)].Name != "billingAccountList") 
                            || (locationReferences[(offset + 18)].Type != typeof(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_billingaccount>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 19)].Name != "billingAccountListModel") 
                            || (locationReferences[(offset + 19)].Type != typeof(System.Collections.Generic.List<AmxPeruPSBActivities.Model.BillingAccount>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 20)].Name != "billingAccount") 
                            || (locationReferences[(offset + 20)].Type != typeof(AmxPeruPSBActivities.Model.BillingAccount)))) {
                    return false;
                }
                if (((locationReferences[(offset + 21)].Name != "orderCapture") 
                            || (locationReferences[(offset + 21)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.etel_ordercapture)))) {
                    return false;
                }
                if (((locationReferences[(offset + 22)].Name != "order") 
                            || (locationReferences[(offset + 22)].Type != typeof(AmxPeruPSBActivities.Model.AmxPeruOfferingPriceModel)))) {
                    return false;
                }
                if (((locationReferences[(offset + 23)].Name != "selectedBillingAccount") 
                            || (locationReferences[(offset + 23)].Type != typeof(AmxPeruPSBActivities.Model.BillingAccount)))) {
                    return false;
                }
                if (((locationReferences[(offset + 24)].Name != "billMediumOptionSet") 
                            || (locationReferences[(offset + 24)].Type != typeof(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 25)].Name != "callItemizationOptionSet") 
                            || (locationReferences[(offset + 25)].Type != typeof(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.TwoOption>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 26)].Name != "isPrimaryOptionSet") 
                            || (locationReferences[(offset + 26)].Type != typeof(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.TwoOption>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 27)].Name != "orderSubmitEndpoint") 
                            || (locationReferences[(offset + 27)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 28)].Name != "eocTimoutInMiliseconds") 
                            || (locationReferences[(offset + 28)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 29)].Name != "orderItemBasket") 
                            || (locationReferences[(offset + 29)].Type != typeof(AmxPeruPSBActivities.Model.ConfigurableItemsModel)))) {
                    return false;
                }
                if (((locationReferences[(offset + 30)].Name != "configurableItems") 
                            || (locationReferences[(offset + 30)].Type != typeof(AmxPeruPSBActivities.Model.ConfigurableItemsModel)))) {
                    return false;
                }
                if (((locationReferences[(offset + 31)].Name != "appointmentRequired") 
                            || (locationReferences[(offset + 31)].Type != typeof(bool)))) {
                    return false;
                }
                return AmxPeruNewSubscription_TypedDataContext1_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruNewSubscription_TypedDataContext3 : AmxPeruNewSubscription_TypedDataContext2 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected bool newStage;
            
            public AmxPeruNewSubscription_TypedDataContext3(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext3(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext3(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string customerType {
                get {
                    return ((string)(this.GetVariableValue((32 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((32 + locationsOffset), value);
                }
            }
            
            protected AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse omResponse {
                get {
                    return ((AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse)(this.GetVariableValue((34 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((34 + locationsOffset), value);
                }
            }
            
            protected AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest submitRequest {
                get {
                    return ((AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest)(this.GetVariableValue((35 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((35 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> resourceTypeCodes {
                get {
                    return ((System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>)(this.GetVariableValue((36 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((36 + locationsOffset), value);
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr16GetTree() {
                
                #line 284 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<Ericsson.ETELCRM.Entities.Crm.Account>> expression = () => 
                                          corporateCustomer;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Ericsson.ETELCRM.Entities.Crm.Account @__Expr16Get() {
                
                #line 284 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                          corporateCustomer;
                
                #line default
                #line hidden
            }
            
            public Ericsson.ETELCRM.Entities.Crm.Account ValueType___Expr16Get() {
                this.GetValueTypeValues();
                return this.@__Expr16Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr16Set(Ericsson.ETELCRM.Entities.Crm.Account value) {
                
                #line 284 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                
                                          corporateCustomer = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr16Set(Ericsson.ETELCRM.Entities.Crm.Account value) {
                this.GetValueTypeValues();
                this.@__Expr16Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr17GetTree() {
                
                #line 294 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                          customerType;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr17Get() {
                
                #line 294 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                          customerType;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr17Get() {
                this.GetValueTypeValues();
                return this.@__Expr17Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr17Set(string value) {
                
                #line 294 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                
                                          customerType = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr17Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr17Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr20GetTree() {
                
                #line 299 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<Ericsson.ETELCRM.Entities.Crm.Contact>> expression = () => 
                                          individualCustomer;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Ericsson.ETELCRM.Entities.Crm.Contact @__Expr20Get() {
                
                #line 299 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                          individualCustomer;
                
                #line default
                #line hidden
            }
            
            public Ericsson.ETELCRM.Entities.Crm.Contact ValueType___Expr20Get() {
                this.GetValueTypeValues();
                return this.@__Expr20Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr20Set(Ericsson.ETELCRM.Entities.Crm.Contact value) {
                
                #line 299 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                
                                          individualCustomer = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr20Set(Ericsson.ETELCRM.Entities.Crm.Contact value) {
                this.GetValueTypeValues();
                this.@__Expr20Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr23GetTree() {
                
                #line 328 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                              languageId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr23Get() {
                
                #line 328 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                              languageId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr23Get() {
                this.GetValueTypeValues();
                return this.@__Expr23Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr23Set(string value) {
                
                #line 328 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                
                                              languageId = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr23Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr23Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr24GetTree() {
                
                #line 313 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_billingaccount>>> expression = () => 
                                              billingAccountList;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_billingaccount> @__Expr24Get() {
                
                #line 313 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                              billingAccountList;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_billingaccount> ValueType___Expr24Get() {
                this.GetValueTypeValues();
                return this.@__Expr24Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr24Set(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_billingaccount> value) {
                
                #line 313 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                
                                              billingAccountList = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr24Set(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.etel_billingaccount> value) {
                this.GetValueTypeValues();
                this.@__Expr24Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr25GetTree() {
                
                #line 342 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.TwoOption>>> expression = () => 
                                                  isPrimaryOptionSet;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.TwoOption> @__Expr25Get() {
                
                #line 342 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                  isPrimaryOptionSet;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.TwoOption> ValueType___Expr25Get() {
                this.GetValueTypeValues();
                return this.@__Expr25Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr25Set(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.TwoOption> value) {
                
                #line 342 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                
                                                  isPrimaryOptionSet = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr25Set(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.TwoOption> value) {
                this.GetValueTypeValues();
                this.@__Expr25Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr27GetTree() {
                
                #line 356 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.TwoOption>>> expression = () => 
                                                      callItemizationOptionSet;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.TwoOption> @__Expr27Get() {
                
                #line 356 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                      callItemizationOptionSet;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.TwoOption> ValueType___Expr27Get() {
                this.GetValueTypeValues();
                return this.@__Expr27Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr27Set(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.TwoOption> value) {
                
                #line 356 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                
                                                      callItemizationOptionSet = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr27Set(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.TwoOption> value) {
                this.GetValueTypeValues();
                this.@__Expr27Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr29GetTree() {
                
                #line 370 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>>> expression = () => 
                                                          billMediumOptionSet;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> @__Expr29Get() {
                
                #line 370 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                          billMediumOptionSet;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> ValueType___Expr29Get() {
                this.GetValueTypeValues();
                return this.@__Expr29Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr29Set(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> value) {
                
                #line 370 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                
                                                          billMediumOptionSet = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr29Set(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> value) {
                this.GetValueTypeValues();
                this.@__Expr29Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr50GetTree() {
                
                #line 641 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>>> expression = () => 
                                                              resourceTypeCodes;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> @__Expr50Get() {
                
                #line 641 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                              resourceTypeCodes;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> ValueType___Expr50Get() {
                this.GetValueTypeValues();
                return this.@__Expr50Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr50Set(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> value) {
                
                #line 641 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                
                                                              resourceTypeCodes = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr50Set(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> value) {
                this.GetValueTypeValues();
                this.@__Expr50Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr53GetTree() {
                
                #line 670 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest>> expression = () => 
                                                                  submitRequest;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest @__Expr53Get() {
                
                #line 670 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                  submitRequest;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest ValueType___Expr53Get() {
                this.GetValueTypeValues();
                return this.@__Expr53Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr53Set(AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest value) {
                
                #line 670 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                
                                                                  submitRequest = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr53Set(AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest value) {
                this.GetValueTypeValues();
                this.@__Expr53Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr57GetTree() {
                
                #line 682 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                                            orderSubmitEndpoint;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr57Get() {
                
                #line 682 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                            orderSubmitEndpoint;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr57Get() {
                this.GetValueTypeValues();
                return this.@__Expr57Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr57Set(string value) {
                
                #line 682 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                
                                                                            orderSubmitEndpoint = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr57Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr57Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr58GetTree() {
                
                #line 689 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                                            eocTimoutInMiliseconds;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr58Get() {
                
                #line 689 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                            eocTimoutInMiliseconds;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr58Get() {
                this.GetValueTypeValues();
                return this.@__Expr58Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr58Set(string value) {
                
                #line 689 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                
                                                                            eocTimoutInMiliseconds = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr58Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr58Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr61GetTree() {
                
                #line 706 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse>> expression = () => 
                                                                            omResponse;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse @__Expr61Get() {
                
                #line 706 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                            omResponse;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse ValueType___Expr61Get() {
                this.GetValueTypeValues();
                return this.@__Expr61Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr61Set(AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse value) {
                
                #line 706 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                
                                                                            omResponse = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr61Set(AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse value) {
                this.GetValueTypeValues();
                this.@__Expr61Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr65GetTree() {
                
                #line 723 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse>> expression = () => 
                                                                            submitOrderResponse;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse @__Expr65Get() {
                
                #line 723 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                            submitOrderResponse;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse ValueType___Expr65Get() {
                this.GetValueTypeValues();
                return this.@__Expr65Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr65Set(AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse value) {
                
                #line 723 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                
                                                                            submitOrderResponse = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr65Set(AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse value) {
                this.GetValueTypeValues();
                this.@__Expr65Set(value);
                this.SetValueTypeValues();
            }
            
            protected override void GetValueTypeValues() {
                this.newStage = ((bool)(this.GetVariableValue((33 + locationsOffset))));
                base.GetValueTypeValues();
            }
            
            protected override void SetValueTypeValues() {
                this.SetVariableValue((33 + locationsOffset), this.newStage);
                base.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 37))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 37);
                }
                expectedLocationsCount = 37;
                if (((locationReferences[(offset + 32)].Name != "customerType") 
                            || (locationReferences[(offset + 32)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 34)].Name != "omResponse") 
                            || (locationReferences[(offset + 34)].Type != typeof(AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse)))) {
                    return false;
                }
                if (((locationReferences[(offset + 35)].Name != "submitRequest") 
                            || (locationReferences[(offset + 35)].Type != typeof(AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest)))) {
                    return false;
                }
                if (((locationReferences[(offset + 36)].Name != "resourceTypeCodes") 
                            || (locationReferences[(offset + 36)].Type != typeof(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 33)].Name != "newStage") 
                            || (locationReferences[(offset + 33)].Type != typeof(bool)))) {
                    return false;
                }
                return AmxPeruNewSubscription_TypedDataContext2.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruNewSubscription_TypedDataContext3_ForReadOnly : AmxPeruNewSubscription_TypedDataContext2_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected bool newStage;
            
            public AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string customerType {
                get {
                    return ((string)(this.GetVariableValue((32 + locationsOffset))));
                }
            }
            
            protected AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse omResponse {
                get {
                    return ((AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse)(this.GetVariableValue((34 + locationsOffset))));
                }
            }
            
            protected AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest submitRequest {
                get {
                    return ((AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest)(this.GetVariableValue((35 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> resourceTypeCodes {
                get {
                    return ((System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>)(this.GetVariableValue((36 + locationsOffset))));
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
                
                #line 289 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                          corporateCustomerId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr18Get() {
                
                #line 289 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                          corporateCustomerId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr18Get() {
                this.GetValueTypeValues();
                return this.@__Expr18Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr19GetTree() {
                
                #line 304 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                          individualCustomerId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr19Get() {
                
                #line 304 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                          individualCustomerId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr19Get() {
                this.GetValueTypeValues();
                return this.@__Expr19Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr21GetTree() {
                
                #line 318 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                              customerType.Equals(Account.EntityLogicalName) ? corporateCustomerId : individualCustomerId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr21Get() {
                
                #line 318 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                              customerType.Equals(Account.EntityLogicalName) ? corporateCustomerId : individualCustomerId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr21Get() {
                this.GetValueTypeValues();
                return this.@__Expr21Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr22GetTree() {
                
                #line 323 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<long>> expression = () => 
                                              customerType.Equals(Account.EntityLogicalName) ? Account.EntityTypeCode : Convert.ToInt32(Ericsson.ETELCRM.Entities.Crm.Contact.EntityTypeCode);
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public long @__Expr22Get() {
                
                #line 323 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                              customerType.Equals(Account.EntityLogicalName) ? Account.EntityTypeCode : Convert.ToInt32(Ericsson.ETELCRM.Entities.Crm.Contact.EntityTypeCode);
                
                #line default
                #line hidden
            }
            
            public long ValueType___Expr22Get() {
                this.GetValueTypeValues();
                return this.@__Expr22Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr26GetTree() {
                
                #line 337 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
                                                  int.Parse(languageId);
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr26Get() {
                
                #line 337 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                  int.Parse(languageId);
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr26Get() {
                this.GetValueTypeValues();
                return this.@__Expr26Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr28GetTree() {
                
                #line 351 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
                                                      int.Parse(languageId);
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr28Get() {
                
                #line 351 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                      int.Parse(languageId);
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr28Get() {
                this.GetValueTypeValues();
                return this.@__Expr28Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr30GetTree() {
                
                #line 365 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<int>> expression = () => 
                                                          int.Parse(languageId);
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public int @__Expr30Get() {
                
                #line 365 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                          int.Parse(languageId);
                
                #line default
                #line hidden
            }
            
            public int ValueType___Expr30Get() {
                this.GetValueTypeValues();
                return this.@__Expr30Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr31GetTree() {
                
                #line 379 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.IEnumerable<Ericsson.ETELCRM.Entities.Crm.etel_billingaccount>>> expression = () => 
                                                              billingAccountList;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.IEnumerable<Ericsson.ETELCRM.Entities.Crm.etel_billingaccount> @__Expr31Get() {
                
                #line 379 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                              billingAccountList;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.IEnumerable<Ericsson.ETELCRM.Entities.Crm.etel_billingaccount> ValueType___Expr31Get() {
                this.GetValueTypeValues();
                return this.@__Expr31Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr49GetTree() {
                
                #line 529 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                    appointmentRequired;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr49Get() {
                
                #line 529 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                    appointmentRequired;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr49Get() {
                this.GetValueTypeValues();
                return this.@__Expr49Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr51GetTree() {
                
                #line 636 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                              etel_productresourcespecification.EntityLogicalName;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr51Get() {
                
                #line 636 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                              etel_productresourcespecification.EntityLogicalName;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr51Get() {
                this.GetValueTypeValues();
                return this.@__Expr51Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr52GetTree() {
                
                #line 650 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<Ericsson.ETELCRM.Entities.Crm.Account>> expression = () => 
                                                                  corporateCustomer;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Ericsson.ETELCRM.Entities.Crm.Account @__Expr52Get() {
                
                #line 650 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                  corporateCustomer;
                
                #line default
                #line hidden
            }
            
            public Ericsson.ETELCRM.Entities.Crm.Account ValueType___Expr52Get() {
                this.GetValueTypeValues();
                return this.@__Expr52Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr54GetTree() {
                
                #line 660 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Guid>> expression = () => 
                                                                  new Guid(orderCaptureId);
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Guid @__Expr54Get() {
                
                #line 660 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                  new Guid(orderCaptureId);
                
                #line default
                #line hidden
            }
            
            public System.Guid ValueType___Expr54Get() {
                this.GetValueTypeValues();
                return this.@__Expr54Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr55GetTree() {
                
                #line 655 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<Ericsson.ETELCRM.Entities.Crm.Contact>> expression = () => 
                                                                  individualCustomer;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Ericsson.ETELCRM.Entities.Crm.Contact @__Expr55Get() {
                
                #line 655 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                  individualCustomer;
                
                #line default
                #line hidden
            }
            
            public Ericsson.ETELCRM.Entities.Crm.Contact ValueType___Expr55Get() {
                this.GetValueTypeValues();
                return this.@__Expr55Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr56GetTree() {
                
                #line 665 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>>> expression = () => 
                                                                  resourceTypeCodes;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> @__Expr56Get() {
                
                #line 665 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                  resourceTypeCodes;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet> ValueType___Expr56Get() {
                this.GetValueTypeValues();
                return this.@__Expr56Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr59GetTree() {
                
                #line 701 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest>> expression = () => 
                                                                            submitRequest;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest @__Expr59Get() {
                
                #line 701 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                            submitRequest;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest ValueType___Expr59Get() {
                this.GetValueTypeValues();
                return this.@__Expr59Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr60GetTree() {
                
                #line 696 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<Ericsson.PSB.Workflow.Client.Core.Serializer.JsonSettings>> expression = () => 
                                                                            Ericsson.PSB.Workflow.Client.Core.Serializer.JsonSettings.Custom;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public Ericsson.PSB.Workflow.Client.Core.Serializer.JsonSettings @__Expr60Get() {
                
                #line 696 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                            Ericsson.PSB.Workflow.Client.Core.Serializer.JsonSettings.Custom;
                
                #line default
                #line hidden
            }
            
            public Ericsson.PSB.Workflow.Client.Core.Serializer.JsonSettings ValueType___Expr60Get() {
                this.GetValueTypeValues();
                return this.@__Expr60Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr62GetTree() {
                
                #line 711 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                                            eocTimoutInMiliseconds;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr62Get() {
                
                #line 711 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                            eocTimoutInMiliseconds;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr62Get() {
                this.GetValueTypeValues();
                return this.@__Expr62Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr63GetTree() {
                
                #line 716 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                                            orderSubmitEndpoint;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr63Get() {
                
                #line 716 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                            orderSubmitEndpoint;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr63Get() {
                this.GetValueTypeValues();
                return this.@__Expr63Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr64GetTree() {
                
                #line 728 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse>> expression = () => 
                                                                            omResponse;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse @__Expr64Get() {
                
                #line 728 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                            omResponse;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse ValueType___Expr64Get() {
                this.GetValueTypeValues();
                return this.@__Expr64Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr66GetTree() {
                
                #line 740 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Guid>> expression = () => 
                                                                            new Guid(orderCaptureId);
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Guid @__Expr66Get() {
                
                #line 740 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                            new Guid(orderCaptureId);
                
                #line default
                #line hidden
            }
            
            public System.Guid ValueType___Expr66Get() {
                this.GetValueTypeValues();
                return this.@__Expr66Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr67GetTree() {
                
                #line 735 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                                            submitOrderResponse.id;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr67Get() {
                
                #line 735 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                            submitOrderResponse.id;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr67Get() {
                this.GetValueTypeValues();
                return this.@__Expr67Get();
            }
            
            protected override void GetValueTypeValues() {
                this.newStage = ((bool)(this.GetVariableValue((33 + locationsOffset))));
                base.GetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 37))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 37);
                }
                expectedLocationsCount = 37;
                if (((locationReferences[(offset + 32)].Name != "customerType") 
                            || (locationReferences[(offset + 32)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 34)].Name != "omResponse") 
                            || (locationReferences[(offset + 34)].Type != typeof(AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderResponse)))) {
                    return false;
                }
                if (((locationReferences[(offset + 35)].Name != "submitRequest") 
                            || (locationReferences[(offset + 35)].Type != typeof(AmxPeruPSBActivities.Model.OrderCaptureSubmit.SubmitOrderRequest)))) {
                    return false;
                }
                if (((locationReferences[(offset + 36)].Name != "resourceTypeCodes") 
                            || (locationReferences[(offset + 36)].Type != typeof(System.Collections.Generic.List<Ericsson.ETELCRM.Entities.Crm.CustomEntities.OptionSet>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 33)].Name != "newStage") 
                            || (locationReferences[(offset + 33)].Type != typeof(bool)))) {
                    return false;
                }
                return AmxPeruNewSubscription_TypedDataContext2_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruNewSubscription_TypedDataContext4 : AmxPeruNewSubscription_TypedDataContext3 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruNewSubscription_TypedDataContext4(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext4(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext4(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected System.Collections.Generic.List<AmxPeruPSBActivities.Model.Cfss.CfssCharacteristicList> cfssCharacteristicList {
                get {
                    return ((System.Collections.Generic.List<AmxPeruPSBActivities.Model.Cfss.CfssCharacteristicList>)(this.GetVariableValue((37 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((37 + locationsOffset), value);
                }
            }
            
            protected string productExternalId {
                get {
                    return ((string)(this.GetVariableValue((38 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((38 + locationsOffset), value);
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr6GetTree() {
                
                #line 188 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.OrderItemsBasketModel>> expression = () => 
                                      orderBasket;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.OrderItemsBasketModel @__Expr6Get() {
                
                #line 188 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                      orderBasket;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.OrderItemsBasketModel ValueType___Expr6Get() {
                this.GetValueTypeValues();
                return this.@__Expr6Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr6Set(AmxPeruPSBActivities.Model.OrderItemsBasketModel value) {
                
                #line 188 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                
                                      orderBasket = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr6Set(AmxPeruPSBActivities.Model.OrderItemsBasketModel value) {
                this.GetValueTypeValues();
                this.@__Expr6Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr9GetTree() {
                
                #line 197 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.ConfigurableItemsModel>> expression = () => 
                                          configurableOrderBasket;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.ConfigurableItemsModel @__Expr9Get() {
                
                #line 197 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                          configurableOrderBasket;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.ConfigurableItemsModel ValueType___Expr9Get() {
                this.GetValueTypeValues();
                return this.@__Expr9Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr9Set(AmxPeruPSBActivities.Model.ConfigurableItemsModel value) {
                
                #line 197 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                
                                          configurableOrderBasket = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr9Set(AmxPeruPSBActivities.Model.ConfigurableItemsModel value) {
                this.GetValueTypeValues();
                this.@__Expr9Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr13GetTree() {
                
                #line 216 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.ConfigurableItemsModel>> expression = () => 
                                                  orderItemBasket;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.ConfigurableItemsModel @__Expr13Get() {
                
                #line 216 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                  orderItemBasket;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.ConfigurableItemsModel ValueType___Expr13Get() {
                this.GetValueTypeValues();
                return this.@__Expr13Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr13Set(AmxPeruPSBActivities.Model.ConfigurableItemsModel value) {
                
                #line 216 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                
                                                  orderItemBasket = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr13Set(AmxPeruPSBActivities.Model.ConfigurableItemsModel value) {
                this.GetValueTypeValues();
                this.@__Expr13Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr15GetTree() {
                
                #line 230 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<AmxPeruPSBActivities.Model.Cfss.CfssCharacteristicList>>> expression = () => 
                                                      cfssCharacteristicList;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.Cfss.CfssCharacteristicList> @__Expr15Get() {
                
                #line 230 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                      cfssCharacteristicList;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.Cfss.CfssCharacteristicList> ValueType___Expr15Get() {
                this.GetValueTypeValues();
                return this.@__Expr15Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr15Set(System.Collections.Generic.List<AmxPeruPSBActivities.Model.Cfss.CfssCharacteristicList> value) {
                
                #line 230 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                
                                                      cfssCharacteristicList = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr15Set(System.Collections.Generic.List<AmxPeruPSBActivities.Model.Cfss.CfssCharacteristicList> value) {
                this.GetValueTypeValues();
                this.@__Expr15Set(value);
                this.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 39))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 39);
                }
                expectedLocationsCount = 39;
                if (((locationReferences[(offset + 37)].Name != "cfssCharacteristicList") 
                            || (locationReferences[(offset + 37)].Type != typeof(System.Collections.Generic.List<AmxPeruPSBActivities.Model.Cfss.CfssCharacteristicList>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 38)].Name != "productExternalId") 
                            || (locationReferences[(offset + 38)].Type != typeof(string)))) {
                    return false;
                }
                return AmxPeruNewSubscription_TypedDataContext3.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruNewSubscription_TypedDataContext4_ForReadOnly : AmxPeruNewSubscription_TypedDataContext3_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruNewSubscription_TypedDataContext4_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext4_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext4_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected System.Collections.Generic.List<AmxPeruPSBActivities.Model.Cfss.CfssCharacteristicList> cfssCharacteristicList {
                get {
                    return ((System.Collections.Generic.List<AmxPeruPSBActivities.Model.Cfss.CfssCharacteristicList>)(this.GetVariableValue((37 + locationsOffset))));
                }
            }
            
            protected string productExternalId {
                get {
                    return ((string)(this.GetVariableValue((38 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr7GetTree() {
                
                #line 183 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                      orderCaptureId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr7Get() {
                
                #line 183 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                      orderCaptureId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr7Get() {
                this.GetValueTypeValues();
                return this.@__Expr7Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr8GetTree() {
                
                #line 202 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.OrderItemsBasketModel>> expression = () => 
                                          orderBasket;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.OrderItemsBasketModel @__Expr8Get() {
                
                #line 202 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                          orderBasket;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.OrderItemsBasketModel ValueType___Expr8Get() {
                this.GetValueTypeValues();
                return this.@__Expr8Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr10GetTree() {
                
                #line 209 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                          configurableOrderBasket.hasConfigurableItems;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr10Get() {
                
                #line 209 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                          configurableOrderBasket.hasConfigurableItems;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr10Get() {
                this.GetValueTypeValues();
                return this.@__Expr10Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr11GetTree() {
                
                #line 247 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.AmxPeruOfferingPriceModel>> expression = () => 
                                                              order;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.AmxPeruOfferingPriceModel @__Expr11Get() {
                
                #line 247 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                              order;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.AmxPeruOfferingPriceModel ValueType___Expr11Get() {
                this.GetValueTypeValues();
                return this.@__Expr11Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr12GetTree() {
                
                #line 221 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.ConfigurableItemsModel>> expression = () => 
                                                  configurableOrderBasket;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.ConfigurableItemsModel @__Expr12Get() {
                
                #line 221 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                  configurableOrderBasket;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.ConfigurableItemsModel ValueType___Expr12Get() {
                this.GetValueTypeValues();
                return this.@__Expr12Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr14GetTree() {
                
                #line 235 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                      productExternalId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr14Get() {
                
                #line 235 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                      productExternalId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr14Get() {
                this.GetValueTypeValues();
                return this.@__Expr14Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 39))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 39);
                }
                expectedLocationsCount = 39;
                if (((locationReferences[(offset + 37)].Name != "cfssCharacteristicList") 
                            || (locationReferences[(offset + 37)].Type != typeof(System.Collections.Generic.List<AmxPeruPSBActivities.Model.Cfss.CfssCharacteristicList>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 38)].Name != "productExternalId") 
                            || (locationReferences[(offset + 38)].Type != typeof(string)))) {
                    return false;
                }
                return AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruNewSubscription_TypedDataContext5 : AmxPeruNewSubscription_TypedDataContext3 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruNewSubscription_TypedDataContext5(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext5(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext5(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.etel_billingaccount item {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.etel_billingaccount)(this.GetVariableValue((37 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((37 + locationsOffset), value);
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
                            && (locationReferences.Count < 38))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 38);
                }
                expectedLocationsCount = 38;
                if (((locationReferences[(offset + 37)].Name != "item") 
                            || (locationReferences[(offset + 37)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.etel_billingaccount)))) {
                    return false;
                }
                return AmxPeruNewSubscription_TypedDataContext3.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruNewSubscription_TypedDataContext5_ForReadOnly : AmxPeruNewSubscription_TypedDataContext3_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruNewSubscription_TypedDataContext5_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext5_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext5_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected Ericsson.ETELCRM.Entities.Crm.etel_billingaccount item {
                get {
                    return ((Ericsson.ETELCRM.Entities.Crm.etel_billingaccount)(this.GetVariableValue((37 + locationsOffset))));
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
                            && (locationReferences.Count < 38))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 38);
                }
                expectedLocationsCount = 38;
                if (((locationReferences[(offset + 37)].Name != "item") 
                            || (locationReferences[(offset + 37)].Type != typeof(Ericsson.ETELCRM.Entities.Crm.etel_billingaccount)))) {
                    return false;
                }
                return AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruNewSubscription_TypedDataContext6 : AmxPeruNewSubscription_TypedDataContext5 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruNewSubscription_TypedDataContext6(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext6(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext6(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected AmxPeruPSBActivities.Model.BillingAccount billingAccountMode {
                get {
                    return ((AmxPeruPSBActivities.Model.BillingAccount)(this.GetVariableValue((38 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((38 + locationsOffset), value);
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr33GetTree() {
                
                #line 393 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.BillingAccount>> expression = () => 
                                                                    billingAccount;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.BillingAccount @__Expr33Get() {
                
                #line 393 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                    billingAccount;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.BillingAccount ValueType___Expr33Get() {
                this.GetValueTypeValues();
                return this.@__Expr33Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr33Set(AmxPeruPSBActivities.Model.BillingAccount value) {
                
                #line 393 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                
                                                                    billingAccount = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr33Set(AmxPeruPSBActivities.Model.BillingAccount value) {
                this.GetValueTypeValues();
                this.@__Expr33Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr35GetTree() {
                
                #line 405 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                                    billingAccount.billingAccount;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr35Get() {
                
                #line 405 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                    billingAccount.billingAccount;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr35Get() {
                this.GetValueTypeValues();
                return this.@__Expr35Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr35Set(string value) {
                
                #line 405 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                
                                                                    billingAccount.billingAccount = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr35Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr35Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr37GetTree() {
                
                #line 417 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                                    billingAccount.billingAddress;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr37Get() {
                
                #line 417 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                    billingAccount.billingAddress;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr37Get() {
                this.GetValueTypeValues();
                return this.@__Expr37Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr37Set(string value) {
                
                #line 417 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                
                                                                    billingAccount.billingAddress = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr37Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr37Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr39GetTree() {
                
                #line 429 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                                    billingAccount.mailingAddress;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr39Get() {
                
                #line 429 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                    billingAccount.mailingAddress;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr39Get() {
                this.GetValueTypeValues();
                return this.@__Expr39Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr39Set(string value) {
                
                #line 429 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                
                                                                    billingAccount.mailingAddress = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr39Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr39Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr41GetTree() {
                
                #line 441 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                                    billingAccount.billMedium;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr41Get() {
                
                #line 441 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                    billingAccount.billMedium;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr41Get() {
                this.GetValueTypeValues();
                return this.@__Expr41Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr41Set(string value) {
                
                #line 441 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                
                                                                    billingAccount.billMedium = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr41Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr41Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr43GetTree() {
                
                #line 455 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                                    billingAccount.callItemization;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr43Get() {
                
                #line 455 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                    billingAccount.callItemization;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr43Get() {
                this.GetValueTypeValues();
                return this.@__Expr43Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr43Set(string value) {
                
                #line 455 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                
                                                                    billingAccount.callItemization = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr43Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr43Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr45GetTree() {
                
                #line 469 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                                    billingAccount.numberOfCopies;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr45Get() {
                
                #line 469 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                    billingAccount.numberOfCopies;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr45Get() {
                this.GetValueTypeValues();
                return this.@__Expr45Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr45Set(string value) {
                
                #line 469 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                
                                                                    billingAccount.numberOfCopies = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr45Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr45Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr46GetTree() {
                
                #line 481 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                                    billingAccount.language;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr46Get() {
                
                #line 481 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                    billingAccount.language;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr46Get() {
                this.GetValueTypeValues();
                return this.@__Expr46Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr46Set(string value) {
                
                #line 481 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                
                                                                    billingAccount.language = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr46Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr46Set(value);
                this.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 39))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 39);
                }
                expectedLocationsCount = 39;
                if (((locationReferences[(offset + 38)].Name != "billingAccountMode") 
                            || (locationReferences[(offset + 38)].Type != typeof(AmxPeruPSBActivities.Model.BillingAccount)))) {
                    return false;
                }
                return AmxPeruNewSubscription_TypedDataContext5.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruNewSubscription_TypedDataContext6_ForReadOnly : AmxPeruNewSubscription_TypedDataContext5_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext6_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected AmxPeruPSBActivities.Model.BillingAccount billingAccountMode {
                get {
                    return ((AmxPeruPSBActivities.Model.BillingAccount)(this.GetVariableValue((38 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr32GetTree() {
                
                #line 398 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.BillingAccount>> expression = () => 
                                                                    new BillingAccount();
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.BillingAccount @__Expr32Get() {
                
                #line 398 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                    new BillingAccount();
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.BillingAccount ValueType___Expr32Get() {
                this.GetValueTypeValues();
                return this.@__Expr32Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr34GetTree() {
                
                #line 410 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                                    item.etel_name;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr34Get() {
                
                #line 410 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                    item.etel_name;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr34Get() {
                this.GetValueTypeValues();
                return this.@__Expr34Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr36GetTree() {
                
                #line 422 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                                    item.etel_billtoaddressid == null ? string.Empty : item.etel_billtoaddressid.Name;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr36Get() {
                
                #line 422 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                    item.etel_billtoaddressid == null ? string.Empty : item.etel_billtoaddressid.Name;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr36Get() {
                this.GetValueTypeValues();
                return this.@__Expr36Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr38GetTree() {
                
                #line 434 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                                    item.etel_mailtoaddressid == null ? string.Empty : item.etel_mailtoaddressid.Name;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr38Get() {
                
                #line 434 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                    item.etel_mailtoaddressid == null ? string.Empty : item.etel_mailtoaddressid.Name;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr38Get() {
                this.GetValueTypeValues();
                return this.@__Expr38Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr40GetTree() {
                
                #line 446 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                                    (billMediumOptionSet == null || item.etel_billmediumcode == null) ? 
                string.Empty : 
                billMediumOptionSet.FirstOrDefault(x => x.Value == item.etel_billmediumcode.Value).Text;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr40Get() {
                
                #line 446 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                    (billMediumOptionSet == null || item.etel_billmediumcode == null) ? 
                string.Empty : 
                billMediumOptionSet.FirstOrDefault(x => x.Value == item.etel_billmediumcode.Value).Text;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr40Get() {
                this.GetValueTypeValues();
                return this.@__Expr40Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr42GetTree() {
                
                #line 460 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                                    (callItemizationOptionSet == null || item.etel_allowcallitemizationoninvoice == null) 
                ? null 
                : callItemizationOptionSet.FirstOrDefault(x => x.Value == item.etel_allowcallitemizationoninvoice).Text;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr42Get() {
                
                #line 460 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                    (callItemizationOptionSet == null || item.etel_allowcallitemizationoninvoice == null) 
                ? null 
                : callItemizationOptionSet.FirstOrDefault(x => x.Value == item.etel_allowcallitemizationoninvoice).Text;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr42Get() {
                this.GetValueTypeValues();
                return this.@__Expr42Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr44GetTree() {
                
                #line 474 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                                                    item.etel_numberofcopies == null ? string.Empty : item.etel_numberofcopies.Value.ToString();
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr44Get() {
                
                #line 474 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                    item.etel_numberofcopies == null ? string.Empty : item.etel_numberofcopies.Value.ToString();
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr44Get() {
                this.GetValueTypeValues();
                return this.@__Expr44Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr47GetTree() {
                
                #line 495 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.ICollection<AmxPeruPSBActivities.Model.BillingAccount>>> expression = () => 
                                                                  billingAccountListModel;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.ICollection<AmxPeruPSBActivities.Model.BillingAccount> @__Expr47Get() {
                
                #line 495 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                  billingAccountListModel;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.ICollection<AmxPeruPSBActivities.Model.BillingAccount> ValueType___Expr47Get() {
                this.GetValueTypeValues();
                return this.@__Expr47Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr48GetTree() {
                
                #line 491 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.BillingAccount>> expression = () => 
                                                                    billingAccount;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.BillingAccount @__Expr48Get() {
                
                #line 491 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                    billingAccount;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.BillingAccount ValueType___Expr48Get() {
                this.GetValueTypeValues();
                return this.@__Expr48Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 39))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 39);
                }
                expectedLocationsCount = 39;
                if (((locationReferences[(offset + 38)].Name != "billingAccountMode") 
                            || (locationReferences[(offset + 38)].Type != typeof(AmxPeruPSBActivities.Model.BillingAccount)))) {
                    return false;
                }
                return AmxPeruNewSubscription_TypedDataContext5_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruNewSubscription_TypedDataContext7 : AmxPeruNewSubscription_TypedDataContext3 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruNewSubscription_TypedDataContext7(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext7(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext7(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected System.Exception exception {
                get {
                    return ((System.Exception)(this.GetVariableValue((37 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((37 + locationsOffset), value);
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
                            && (locationReferences.Count < 38))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 38);
                }
                expectedLocationsCount = 38;
                if (((locationReferences[(offset + 37)].Name != "exception") 
                            || (locationReferences[(offset + 37)].Type != typeof(System.Exception)))) {
                    return false;
                }
                return AmxPeruNewSubscription_TypedDataContext3.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruNewSubscription_TypedDataContext7_ForReadOnly : AmxPeruNewSubscription_TypedDataContext3_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruNewSubscription_TypedDataContext7_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext7_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext7_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected System.Exception exception {
                get {
                    return ((System.Exception)(this.GetVariableValue((37 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr68GetTree() {
                
                #line 754 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Exception>> expression = () => 
                                                                            new Exception(exception.Message);
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Exception @__Expr68Get() {
                
                #line 754 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUNEWSUBSCRIPTION.XAML"
                return 
                                                                            new Exception(exception.Message);
                
                #line default
                #line hidden
            }
            
            public System.Exception ValueType___Expr68Get() {
                this.GetValueTypeValues();
                return this.@__Expr68Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 38))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 38);
                }
                expectedLocationsCount = 38;
                if (((locationReferences[(offset + 37)].Name != "exception") 
                            || (locationReferences[(offset + 37)].Type != typeof(System.Exception)))) {
                    return false;
                }
                return AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruNewSubscription_TypedDataContext8 : AmxPeruNewSubscription_TypedDataContext3 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruNewSubscription_TypedDataContext8(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext8(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext8(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected AmxPeruPSBActivities.Model.Appointment.GetCapacityRequestModel getCapacityRequest {
                get {
                    return ((AmxPeruPSBActivities.Model.Appointment.GetCapacityRequestModel)(this.GetVariableValue((37 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((37 + locationsOffset), value);
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
                            && (locationReferences.Count < 38))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 38);
                }
                expectedLocationsCount = 38;
                if (((locationReferences[(offset + 37)].Name != "getCapacityRequest") 
                            || (locationReferences[(offset + 37)].Type != typeof(AmxPeruPSBActivities.Model.Appointment.GetCapacityRequestModel)))) {
                    return false;
                }
                return AmxPeruNewSubscription_TypedDataContext3.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruNewSubscription_TypedDataContext8_ForReadOnly : AmxPeruNewSubscription_TypedDataContext3_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruNewSubscription_TypedDataContext8_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext8_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruNewSubscription_TypedDataContext8_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected AmxPeruPSBActivities.Model.Appointment.GetCapacityRequestModel getCapacityRequest {
                get {
                    return ((AmxPeruPSBActivities.Model.Appointment.GetCapacityRequestModel)(this.GetVariableValue((37 + locationsOffset))));
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
                            && (locationReferences.Count < 38))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 38);
                }
                expectedLocationsCount = 38;
                if (((locationReferences[(offset + 37)].Name != "getCapacityRequest") 
                            || (locationReferences[(offset + 37)].Type != typeof(AmxPeruPSBActivities.Model.Appointment.GetCapacityRequestModel)))) {
                    return false;
                }
                return AmxPeruNewSubscription_TypedDataContext3_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
    }
}

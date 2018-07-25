namespace AmxPeruPSBWorkflows {
    
    #line 28 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruLinePortabilityQuery.xaml"
    using System;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruLinePortabilityQuery.xaml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 29 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruLinePortabilityQuery.xaml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruLinePortabilityQuery.xaml"
    using System.Activities;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruLinePortabilityQuery.xaml"
    using System.Activities.Expressions;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruLinePortabilityQuery.xaml"
    using System.Activities.Statements;
    
    #line default
    #line hidden
    
    #line 30 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruLinePortabilityQuery.xaml"
    using System.Data;
    
    #line default
    #line hidden
    
    #line 31 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruLinePortabilityQuery.xaml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 32 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruLinePortabilityQuery.xaml"
    using System.Text;
    
    #line default
    #line hidden
    
    #line 33 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruLinePortabilityQuery.xaml"
    using AmxPeruPSBActivities.Model.DirectoryNumberRead;
    
    #line default
    #line hidden
    
    #line 34 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruLinePortabilityQuery.xaml"
    using AmxPeruPSBActivities.Activities.LinePortability;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruLinePortabilityQuery.xaml"
    using System.Activities.XamlIntegration;
    
    #line default
    #line hidden
    
    
    public partial class AmxPeruLinePortabilityQuery : System.Activities.XamlIntegration.ICompiledExpressionRoot {
        
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
                this.dataContextActivities = AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.GetDataContextActivitiesHelper(this.rootActivity, this.forImplementation);
            }
            if ((expressionId == 0)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext0 = ((AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext0.ValueType___Expr0Get();
            }
            if ((expressionId == 1)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext1 = ((AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext2 = ((AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext2.ValueType___Expr2Get();
            }
            if ((expressionId == 3)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext3 = ((AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext3.ValueType___Expr3Get();
            }
            if ((expressionId == 4)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxPeruLinePortabilityQuery_TypedDataContext2(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext2 refDataContext4 = ((AmxPeruLinePortabilityQuery_TypedDataContext2)(cachedCompiledDataContext[1]));
                return refDataContext4.GetLocation<string>(refDataContext4.ValueType___Expr4Get, refDataContext4.ValueType___Expr4Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 5)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext5 = ((AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext5.ValueType___Expr5Get();
            }
            if ((expressionId == 6)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext6 = ((AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxPeruLinePortabilityQuery_TypedDataContext2(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext2 refDataContext7 = ((AmxPeruLinePortabilityQuery_TypedDataContext2)(cachedCompiledDataContext[1]));
                return refDataContext7.GetLocation<System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel>>(refDataContext7.ValueType___Expr7Get, refDataContext7.ValueType___Expr7Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 8)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxPeruLinePortabilityQuery_TypedDataContext2(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext2 refDataContext8 = ((AmxPeruLinePortabilityQuery_TypedDataContext2)(cachedCompiledDataContext[1]));
                return refDataContext8.GetLocation<string>(refDataContext8.ValueType___Expr8Get, refDataContext8.ValueType___Expr8Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 9)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext9 = ((AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext9.ValueType___Expr9Get();
            }
            if ((expressionId == 10)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly valDataContext10 = ((AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly valDataContext11 = ((AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext11.ValueType___Expr11Get();
            }
            if ((expressionId == 12)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new AmxPeruLinePortabilityQuery_TypedDataContext3(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext3 refDataContext12 = ((AmxPeruLinePortabilityQuery_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext12.GetLocation<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel>(refDataContext12.ValueType___Expr12Get, refDataContext12.ValueType___Expr12Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 13)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly valDataContext13 = ((AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext13.ValueType___Expr13Get();
            }
            if ((expressionId == 14)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly valDataContext14 = ((AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext14.ValueType___Expr14Get();
            }
            if ((expressionId == 15)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new AmxPeruLinePortabilityQuery_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext4_ForReadOnly valDataContext15 = ((AmxPeruLinePortabilityQuery_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext15.ValueType___Expr15Get();
            }
            if ((expressionId == 16)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext4_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[4] == null)) {
                    cachedCompiledDataContext[4] = new AmxPeruLinePortabilityQuery_TypedDataContext4_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext4_ForReadOnly valDataContext16 = ((AmxPeruLinePortabilityQuery_TypedDataContext4_ForReadOnly)(cachedCompiledDataContext[4]));
                return valDataContext16.ValueType___Expr16Get();
            }
            if ((expressionId == 17)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext17 = ((AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext17.ValueType___Expr17Get();
            }
            if ((expressionId == 18)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly valDataContext18 = ((AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly)(cachedCompiledDataContext[5]));
                return valDataContext18.ValueType___Expr18Get();
            }
            if ((expressionId == 19)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly valDataContext19 = ((AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly)(cachedCompiledDataContext[5]));
                return valDataContext19.ValueType___Expr19Get();
            }
            if ((expressionId == 20)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly valDataContext20 = ((AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly)(cachedCompiledDataContext[5]));
                return valDataContext20.ValueType___Expr20Get();
            }
            if ((expressionId == 21)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly valDataContext21 = ((AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly)(cachedCompiledDataContext[5]));
                return valDataContext21.ValueType___Expr21Get();
            }
            if ((expressionId == 22)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[5] == null)) {
                    cachedCompiledDataContext[5] = new AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly valDataContext22 = ((AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly)(cachedCompiledDataContext[5]));
                return valDataContext22.ValueType___Expr22Get();
            }
            if ((expressionId == 23)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext23 = ((AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext23.ValueType___Expr23Get();
            }
            if ((expressionId == 24)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext24 = ((AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext24.ValueType___Expr24Get();
            }
            if ((expressionId == 25)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext25 = ((AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext25.ValueType___Expr25Get();
            }
            if ((expressionId == 26)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext26 = ((AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext26.ValueType___Expr26Get();
            }
            if ((expressionId == 27)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxPeruLinePortabilityQuery_TypedDataContext2(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext2 refDataContext27 = ((AmxPeruLinePortabilityQuery_TypedDataContext2)(cachedCompiledDataContext[1]));
                return refDataContext27.GetLocation<System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel>>(refDataContext27.ValueType___Expr27Get, refDataContext27.ValueType___Expr27Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 28)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext28 = ((AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext28.ValueType___Expr28Get();
            }
            if ((expressionId == 29)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext29 = ((AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[0]));
                return valDataContext29.ValueType___Expr29Get();
            }
            if ((expressionId == 30)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext6_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[6] == null)) {
                    cachedCompiledDataContext[6] = new AmxPeruLinePortabilityQuery_TypedDataContext6_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext6_ForReadOnly valDataContext30 = ((AmxPeruLinePortabilityQuery_TypedDataContext6_ForReadOnly)(cachedCompiledDataContext[6]));
                return valDataContext30.ValueType___Expr30Get();
            }
            if ((expressionId == 31)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruLinePortabilityQuery_TypedDataContext6_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 7);
                if ((cachedCompiledDataContext[6] == null)) {
                    cachedCompiledDataContext[6] = new AmxPeruLinePortabilityQuery_TypedDataContext6_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruLinePortabilityQuery_TypedDataContext6_ForReadOnly valDataContext31 = ((AmxPeruLinePortabilityQuery_TypedDataContext6_ForReadOnly)(cachedCompiledDataContext[6]));
                return valDataContext31.ValueType___Expr31Get();
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
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext0 = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext0.ValueType___Expr0Get();
            }
            if ((expressionId == 1)) {
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext1 = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext2 = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext2.ValueType___Expr2Get();
            }
            if ((expressionId == 3)) {
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext3 = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext3.ValueType___Expr3Get();
            }
            if ((expressionId == 4)) {
                AmxPeruLinePortabilityQuery_TypedDataContext2 refDataContext4 = new AmxPeruLinePortabilityQuery_TypedDataContext2(locations, true);
                return refDataContext4.GetLocation<string>(refDataContext4.ValueType___Expr4Get, refDataContext4.ValueType___Expr4Set);
            }
            if ((expressionId == 5)) {
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext5 = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext5.ValueType___Expr5Get();
            }
            if ((expressionId == 6)) {
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext6 = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                AmxPeruLinePortabilityQuery_TypedDataContext2 refDataContext7 = new AmxPeruLinePortabilityQuery_TypedDataContext2(locations, true);
                return refDataContext7.GetLocation<System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel>>(refDataContext7.ValueType___Expr7Get, refDataContext7.ValueType___Expr7Set);
            }
            if ((expressionId == 8)) {
                AmxPeruLinePortabilityQuery_TypedDataContext2 refDataContext8 = new AmxPeruLinePortabilityQuery_TypedDataContext2(locations, true);
                return refDataContext8.GetLocation<string>(refDataContext8.ValueType___Expr8Get, refDataContext8.ValueType___Expr8Set);
            }
            if ((expressionId == 9)) {
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext9 = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext9.ValueType___Expr9Get();
            }
            if ((expressionId == 10)) {
                AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly valDataContext10 = new AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly valDataContext11 = new AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext11.ValueType___Expr11Get();
            }
            if ((expressionId == 12)) {
                AmxPeruLinePortabilityQuery_TypedDataContext3 refDataContext12 = new AmxPeruLinePortabilityQuery_TypedDataContext3(locations, true);
                return refDataContext12.GetLocation<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel>(refDataContext12.ValueType___Expr12Get, refDataContext12.ValueType___Expr12Set);
            }
            if ((expressionId == 13)) {
                AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly valDataContext13 = new AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext13.ValueType___Expr13Get();
            }
            if ((expressionId == 14)) {
                AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly valDataContext14 = new AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext14.ValueType___Expr14Get();
            }
            if ((expressionId == 15)) {
                AmxPeruLinePortabilityQuery_TypedDataContext4_ForReadOnly valDataContext15 = new AmxPeruLinePortabilityQuery_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext15.ValueType___Expr15Get();
            }
            if ((expressionId == 16)) {
                AmxPeruLinePortabilityQuery_TypedDataContext4_ForReadOnly valDataContext16 = new AmxPeruLinePortabilityQuery_TypedDataContext4_ForReadOnly(locations, true);
                return valDataContext16.ValueType___Expr16Get();
            }
            if ((expressionId == 17)) {
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext17 = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext17.ValueType___Expr17Get();
            }
            if ((expressionId == 18)) {
                AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly valDataContext18 = new AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly(locations, true);
                return valDataContext18.ValueType___Expr18Get();
            }
            if ((expressionId == 19)) {
                AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly valDataContext19 = new AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly(locations, true);
                return valDataContext19.ValueType___Expr19Get();
            }
            if ((expressionId == 20)) {
                AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly valDataContext20 = new AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly(locations, true);
                return valDataContext20.ValueType___Expr20Get();
            }
            if ((expressionId == 21)) {
                AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly valDataContext21 = new AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly(locations, true);
                return valDataContext21.ValueType___Expr21Get();
            }
            if ((expressionId == 22)) {
                AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly valDataContext22 = new AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly(locations, true);
                return valDataContext22.ValueType___Expr22Get();
            }
            if ((expressionId == 23)) {
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext23 = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext23.ValueType___Expr23Get();
            }
            if ((expressionId == 24)) {
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext24 = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext24.ValueType___Expr24Get();
            }
            if ((expressionId == 25)) {
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext25 = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext25.ValueType___Expr25Get();
            }
            if ((expressionId == 26)) {
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext26 = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext26.ValueType___Expr26Get();
            }
            if ((expressionId == 27)) {
                AmxPeruLinePortabilityQuery_TypedDataContext2 refDataContext27 = new AmxPeruLinePortabilityQuery_TypedDataContext2(locations, true);
                return refDataContext27.GetLocation<System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel>>(refDataContext27.ValueType___Expr27Get, refDataContext27.ValueType___Expr27Set);
            }
            if ((expressionId == 28)) {
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext28 = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext28.ValueType___Expr28Get();
            }
            if ((expressionId == 29)) {
                AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly valDataContext29 = new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext29.ValueType___Expr29Get();
            }
            if ((expressionId == 30)) {
                AmxPeruLinePortabilityQuery_TypedDataContext6_ForReadOnly valDataContext30 = new AmxPeruLinePortabilityQuery_TypedDataContext6_ForReadOnly(locations, true);
                return valDataContext30.ValueType___Expr30Get();
            }
            if ((expressionId == 31)) {
                AmxPeruLinePortabilityQuery_TypedDataContext6_ForReadOnly valDataContext31 = new AmxPeruLinePortabilityQuery_TypedDataContext6_ForReadOnly(locations, true);
                return valDataContext31.ValueType___Expr31Get();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool CanExecuteExpression(string expressionText, bool isReference, System.Collections.Generic.IList<System.Activities.LocationReference> locations, out int expressionId) {
            if (((isReference == false) 
                        && ((expressionText == "new List<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberRea" +
                            "dResponseModel>()") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 0;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new GenericDirectoryNumberReadResponseModel()") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 1;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new List<GenericDirectoryNumberReadResponseModel>()") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 2;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new List<ClaroDirectoryNumberConfigResponseModel>()") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 3;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "connectionString") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 4;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "connectionString") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 5;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new List<ClaroDirectoryNumberConfigResponseModel>()") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 6;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "response") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 7;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "endPoint") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 8;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "lineNumberList") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 9;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "item") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 10;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "endPoint") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 11;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "responseModel") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 12;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "bscsResponseCollection") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 13;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "responseModel") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 14;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "bscsResponseCollection") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 15;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new GenericDirectoryNumberReadResponseModel()\n            {\ndirnum = item,\ndnStat" +
                            "us = \"NotClaro\"\n            }") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext4_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 16;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "bscsResponseCollection") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 17;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "item.dnStatus.Equals(\"NotClaro\")") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 18;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "claroLineNumbers") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 19;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "item") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 20;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "response") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 21;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new ClaroDirectoryNumberConfigResponseModel()\n            {\n            PhoneNumb" +
                            "er = item.dirnum,\n            Status = item.dnStatus,\n            Provider = \"No" +
                            "tClaro\"\n            }") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 22;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "claroLineNumbers.Select(i => i.dirnum).ToList()") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 23;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "currentPlan") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 24;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "currentCarrier") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 25;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "claroEndPoint") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 26;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "claroServiceResponseCollection") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 27;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "serviceType") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 28;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "claroServiceResponseCollection") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 29;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "response") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext6_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 30;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "item") 
                        && (AmxPeruLinePortabilityQuery_TypedDataContext6_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 31;
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
                return new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locationReferences).@__Expr0GetTree();
            }
            if ((expressionId == 1)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locationReferences).@__Expr1GetTree();
            }
            if ((expressionId == 2)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locationReferences).@__Expr2GetTree();
            }
            if ((expressionId == 3)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locationReferences).@__Expr3GetTree();
            }
            if ((expressionId == 4)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext2(locationReferences).@__Expr4GetTree();
            }
            if ((expressionId == 5)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locationReferences).@__Expr5GetTree();
            }
            if ((expressionId == 6)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locationReferences).@__Expr6GetTree();
            }
            if ((expressionId == 7)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext2(locationReferences).@__Expr7GetTree();
            }
            if ((expressionId == 8)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext2(locationReferences).@__Expr8GetTree();
            }
            if ((expressionId == 9)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locationReferences).@__Expr9GetTree();
            }
            if ((expressionId == 10)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly(locationReferences).@__Expr10GetTree();
            }
            if ((expressionId == 11)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly(locationReferences).@__Expr11GetTree();
            }
            if ((expressionId == 12)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext3(locationReferences).@__Expr12GetTree();
            }
            if ((expressionId == 13)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly(locationReferences).@__Expr13GetTree();
            }
            if ((expressionId == 14)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly(locationReferences).@__Expr14GetTree();
            }
            if ((expressionId == 15)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext4_ForReadOnly(locationReferences).@__Expr15GetTree();
            }
            if ((expressionId == 16)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext4_ForReadOnly(locationReferences).@__Expr16GetTree();
            }
            if ((expressionId == 17)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locationReferences).@__Expr17GetTree();
            }
            if ((expressionId == 18)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly(locationReferences).@__Expr18GetTree();
            }
            if ((expressionId == 19)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly(locationReferences).@__Expr19GetTree();
            }
            if ((expressionId == 20)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly(locationReferences).@__Expr20GetTree();
            }
            if ((expressionId == 21)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly(locationReferences).@__Expr21GetTree();
            }
            if ((expressionId == 22)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly(locationReferences).@__Expr22GetTree();
            }
            if ((expressionId == 23)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locationReferences).@__Expr23GetTree();
            }
            if ((expressionId == 24)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locationReferences).@__Expr24GetTree();
            }
            if ((expressionId == 25)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locationReferences).@__Expr25GetTree();
            }
            if ((expressionId == 26)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locationReferences).@__Expr26GetTree();
            }
            if ((expressionId == 27)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext2(locationReferences).@__Expr27GetTree();
            }
            if ((expressionId == 28)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locationReferences).@__Expr28GetTree();
            }
            if ((expressionId == 29)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(locationReferences).@__Expr29GetTree();
            }
            if ((expressionId == 30)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext6_ForReadOnly(locationReferences).@__Expr30GetTree();
            }
            if ((expressionId == 31)) {
                return new AmxPeruLinePortabilityQuery_TypedDataContext6_ForReadOnly(locationReferences).@__Expr31GetTree();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruLinePortabilityQuery_TypedDataContext0 : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruLinePortabilityQuery_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext0(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class AmxPeruLinePortabilityQuery_TypedDataContext0_ForReadOnly : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruLinePortabilityQuery_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class AmxPeruLinePortabilityQuery_TypedDataContext1 : AmxPeruLinePortabilityQuery_TypedDataContext0 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruLinePortabilityQuery_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext1(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected System.Collections.Generic.List<string> lineNumberList {
                get {
                    return ((System.Collections.Generic.List<string>)(this.GetVariableValue((0 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((0 + locationsOffset), value);
                }
            }
            
            protected string currentCarrier {
                get {
                    return ((string)(this.GetVariableValue((1 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((1 + locationsOffset), value);
                }
            }
            
            protected string serviceType {
                get {
                    return ((string)(this.GetVariableValue((2 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((2 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel> response {
                get {
                    return ((System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel>)(this.GetVariableValue((3 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((3 + locationsOffset), value);
                }
            }
            
            protected string currentPlan {
                get {
                    return ((string)(this.GetVariableValue((4 + locationsOffset))));
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
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 5))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 5);
                }
                expectedLocationsCount = 5;
                if (((locationReferences[(offset + 0)].Name != "lineNumberList") 
                            || (locationReferences[(offset + 0)].Type != typeof(System.Collections.Generic.List<string>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "currentCarrier") 
                            || (locationReferences[(offset + 1)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 2)].Name != "serviceType") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "response") 
                            || (locationReferences[(offset + 3)].Type != typeof(System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "currentPlan") 
                            || (locationReferences[(offset + 4)].Type != typeof(string)))) {
                    return false;
                }
                return AmxPeruLinePortabilityQuery_TypedDataContext0.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruLinePortabilityQuery_TypedDataContext1_ForReadOnly : AmxPeruLinePortabilityQuery_TypedDataContext0_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruLinePortabilityQuery_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected System.Collections.Generic.List<string> lineNumberList {
                get {
                    return ((System.Collections.Generic.List<string>)(this.GetVariableValue((0 + locationsOffset))));
                }
            }
            
            protected string currentCarrier {
                get {
                    return ((string)(this.GetVariableValue((1 + locationsOffset))));
                }
            }
            
            protected string serviceType {
                get {
                    return ((string)(this.GetVariableValue((2 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel> response {
                get {
                    return ((System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel>)(this.GetVariableValue((3 + locationsOffset))));
                }
            }
            
            protected string currentPlan {
                get {
                    return ((string)(this.GetVariableValue((4 + locationsOffset))));
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
                            && (locationReferences.Count < 5))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 5);
                }
                expectedLocationsCount = 5;
                if (((locationReferences[(offset + 0)].Name != "lineNumberList") 
                            || (locationReferences[(offset + 0)].Type != typeof(System.Collections.Generic.List<string>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "currentCarrier") 
                            || (locationReferences[(offset + 1)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 2)].Name != "serviceType") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "response") 
                            || (locationReferences[(offset + 3)].Type != typeof(System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "currentPlan") 
                            || (locationReferences[(offset + 4)].Type != typeof(string)))) {
                    return false;
                }
                return AmxPeruLinePortabilityQuery_TypedDataContext0_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruLinePortabilityQuery_TypedDataContext2 : AmxPeruLinePortabilityQuery_TypedDataContext1 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruLinePortabilityQuery_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext2(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
            
            protected string endPoint {
                get {
                    return ((string)(this.GetVariableValue((6 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((6 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel> bscsResponseCollection {
                get {
                    return ((System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel>)(this.GetVariableValue((7 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((7 + locationsOffset), value);
                }
            }
            
            protected AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel responseModel {
                get {
                    return ((AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel)(this.GetVariableValue((8 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((8 + locationsOffset), value);
                }
            }
            
            protected string claroEndPoint {
                get {
                    return ((string)(this.GetVariableValue((9 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((9 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel> claroLineNumbers {
                get {
                    return ((System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel>)(this.GetVariableValue((10 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((10 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel> claroServiceResponseCollection {
                get {
                    return ((System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel>)(this.GetVariableValue((11 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((11 + locationsOffset), value);
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
                
                #line 105 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
              connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr4Get() {
                
                #line 105 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
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
                
                #line 105 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                
              connectionString = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr4Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr4Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr7GetTree() {
                
                #line 116 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel>>> expression = () => 
                      response;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel> @__Expr7Get() {
                
                #line 116 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
                      response;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel> ValueType___Expr7Get() {
                this.GetValueTypeValues();
                return this.@__Expr7Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr7Set(System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel> value) {
                
                #line 116 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                
                      response = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr7Set(System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel> value) {
                this.GetValueTypeValues();
                this.@__Expr7Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr8GetTree() {
                
                #line 131 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                            endPoint;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr8Get() {
                
                #line 131 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
                            endPoint;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr8Get() {
                this.GetValueTypeValues();
                return this.@__Expr8Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr8Set(string value) {
                
                #line 131 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                
                            endPoint = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr8Set(string value) {
                this.GetValueTypeValues();
                this.@__Expr8Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr27GetTree() {
                
                #line 297 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel>>> expression = () => 
                            claroServiceResponseCollection;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel> @__Expr27Get() {
                
                #line 297 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
                            claroServiceResponseCollection;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel> ValueType___Expr27Get() {
                this.GetValueTypeValues();
                return this.@__Expr27Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr27Set(System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel> value) {
                
                #line 297 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                
                            claroServiceResponseCollection = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr27Set(System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel> value) {
                this.GetValueTypeValues();
                this.@__Expr27Set(value);
                this.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 12))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 12);
                }
                expectedLocationsCount = 12;
                if (((locationReferences[(offset + 5)].Name != "connectionString") 
                            || (locationReferences[(offset + 5)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "endPoint") 
                            || (locationReferences[(offset + 6)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 7)].Name != "bscsResponseCollection") 
                            || (locationReferences[(offset + 7)].Type != typeof(System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 8)].Name != "responseModel") 
                            || (locationReferences[(offset + 8)].Type != typeof(AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel)))) {
                    return false;
                }
                if (((locationReferences[(offset + 9)].Name != "claroEndPoint") 
                            || (locationReferences[(offset + 9)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 10)].Name != "claroLineNumbers") 
                            || (locationReferences[(offset + 10)].Type != typeof(System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 11)].Name != "claroServiceResponseCollection") 
                            || (locationReferences[(offset + 11)].Type != typeof(System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel>)))) {
                    return false;
                }
                return AmxPeruLinePortabilityQuery_TypedDataContext1.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly : AmxPeruLinePortabilityQuery_TypedDataContext1_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string connectionString {
                get {
                    return ((string)(this.GetVariableValue((5 + locationsOffset))));
                }
            }
            
            protected string endPoint {
                get {
                    return ((string)(this.GetVariableValue((6 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel> bscsResponseCollection {
                get {
                    return ((System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel>)(this.GetVariableValue((7 + locationsOffset))));
                }
            }
            
            protected AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel responseModel {
                get {
                    return ((AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel)(this.GetVariableValue((8 + locationsOffset))));
                }
            }
            
            protected string claroEndPoint {
                get {
                    return ((string)(this.GetVariableValue((9 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel> claroLineNumbers {
                get {
                    return ((System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel>)(this.GetVariableValue((10 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel> claroServiceResponseCollection {
                get {
                    return ((System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel>)(this.GetVariableValue((11 + locationsOffset))));
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
                
                #line 80 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel>>> expression = () => 
          new List<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel>();
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel> @__Expr0Get() {
                
                #line 80 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
          new List<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel>();
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel> ValueType___Expr0Get() {
                this.GetValueTypeValues();
                return this.@__Expr0Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr1GetTree() {
                
                #line 85 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel>> expression = () => 
          new GenericDirectoryNumberReadResponseModel();
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel @__Expr1Get() {
                
                #line 85 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
          new GenericDirectoryNumberReadResponseModel();
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel ValueType___Expr1Get() {
                this.GetValueTypeValues();
                return this.@__Expr1Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr2GetTree() {
                
                #line 91 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel>>> expression = () => 
          new List<GenericDirectoryNumberReadResponseModel>();
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel> @__Expr2Get() {
                
                #line 91 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
          new List<GenericDirectoryNumberReadResponseModel>();
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel> ValueType___Expr2Get() {
                this.GetValueTypeValues();
                return this.@__Expr2Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr3GetTree() {
                
                #line 96 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel>>> expression = () => 
          new List<ClaroDirectoryNumberConfigResponseModel>();
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel> @__Expr3Get() {
                
                #line 96 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
          new List<ClaroDirectoryNumberConfigResponseModel>();
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel> ValueType___Expr3Get() {
                this.GetValueTypeValues();
                return this.@__Expr3Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr5GetTree() {
                
                #line 335 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr5Get() {
                
                #line 335 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
                  connectionString;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr5Get() {
                this.GetValueTypeValues();
                return this.@__Expr5Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr6GetTree() {
                
                #line 121 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel>>> expression = () => 
                      new List<ClaroDirectoryNumberConfigResponseModel>();
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel> @__Expr6Get() {
                
                #line 121 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
                      new List<ClaroDirectoryNumberConfigResponseModel>();
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel> ValueType___Expr6Get() {
                this.GetValueTypeValues();
                return this.@__Expr6Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr9GetTree() {
                
                #line 140 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.IEnumerable<string>>> expression = () => 
                                lineNumberList;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.IEnumerable<string> @__Expr9Get() {
                
                #line 140 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
                                lineNumberList;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.IEnumerable<string> ValueType___Expr9Get() {
                this.GetValueTypeValues();
                return this.@__Expr9Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr17GetTree() {
                
                #line 217 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.IEnumerable<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel>>> expression = () => 
                      bscsResponseCollection;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.IEnumerable<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel> @__Expr17Get() {
                
                #line 217 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
                      bscsResponseCollection;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.IEnumerable<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel> ValueType___Expr17Get() {
                this.GetValueTypeValues();
                return this.@__Expr17Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr23GetTree() {
                
                #line 292 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.List<string>>> expression = () => 
                            claroLineNumbers.Select(i => i.dirnum).ToList();
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.List<string> @__Expr23Get() {
                
                #line 292 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
                            claroLineNumbers.Select(i => i.dirnum).ToList();
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.List<string> ValueType___Expr23Get() {
                this.GetValueTypeValues();
                return this.@__Expr23Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr24GetTree() {
                
                #line 282 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                            currentPlan;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr24Get() {
                
                #line 282 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
                            currentPlan;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr24Get() {
                this.GetValueTypeValues();
                return this.@__Expr24Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr25GetTree() {
                
                #line 277 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                            currentCarrier;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr25Get() {
                
                #line 277 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
                            currentCarrier;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr25Get() {
                this.GetValueTypeValues();
                return this.@__Expr25Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr26GetTree() {
                
                #line 287 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                            claroEndPoint;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr26Get() {
                
                #line 287 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
                            claroEndPoint;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr26Get() {
                this.GetValueTypeValues();
                return this.@__Expr26Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr28GetTree() {
                
                #line 302 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                            serviceType;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr28Get() {
                
                #line 302 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
                            serviceType;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr28Get() {
                this.GetValueTypeValues();
                return this.@__Expr28Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr29GetTree() {
                
                #line 313 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.IEnumerable<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel>>> expression = () => 
                      claroServiceResponseCollection;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.IEnumerable<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel> @__Expr29Get() {
                
                #line 313 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
                      claroServiceResponseCollection;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.IEnumerable<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel> ValueType___Expr29Get() {
                this.GetValueTypeValues();
                return this.@__Expr29Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 12))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 12);
                }
                expectedLocationsCount = 12;
                if (((locationReferences[(offset + 5)].Name != "connectionString") 
                            || (locationReferences[(offset + 5)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "endPoint") 
                            || (locationReferences[(offset + 6)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 7)].Name != "bscsResponseCollection") 
                            || (locationReferences[(offset + 7)].Type != typeof(System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 8)].Name != "responseModel") 
                            || (locationReferences[(offset + 8)].Type != typeof(AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel)))) {
                    return false;
                }
                if (((locationReferences[(offset + 9)].Name != "claroEndPoint") 
                            || (locationReferences[(offset + 9)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 10)].Name != "claroLineNumbers") 
                            || (locationReferences[(offset + 10)].Type != typeof(System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 11)].Name != "claroServiceResponseCollection") 
                            || (locationReferences[(offset + 11)].Type != typeof(System.Collections.Generic.List<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel>)))) {
                    return false;
                }
                return AmxPeruLinePortabilityQuery_TypedDataContext1_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruLinePortabilityQuery_TypedDataContext3 : AmxPeruLinePortabilityQuery_TypedDataContext2 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruLinePortabilityQuery_TypedDataContext3(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext3(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext3(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string item {
                get {
                    return ((string)(this.GetVariableValue((12 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((12 + locationsOffset), value);
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr12GetTree() {
                
                #line 164 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel>> expression = () => 
                                            responseModel;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel @__Expr12Get() {
                
                #line 164 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
                                            responseModel;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel ValueType___Expr12Get() {
                this.GetValueTypeValues();
                return this.@__Expr12Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr12Set(AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel value) {
                
                #line 164 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                
                                            responseModel = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr12Set(AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel value) {
                this.GetValueTypeValues();
                this.@__Expr12Set(value);
                this.SetValueTypeValues();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 13))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 13);
                }
                expectedLocationsCount = 13;
                if (((locationReferences[(offset + 12)].Name != "item") 
                            || (locationReferences[(offset + 12)].Type != typeof(string)))) {
                    return false;
                }
                return AmxPeruLinePortabilityQuery_TypedDataContext2.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly : AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string item {
                get {
                    return ((string)(this.GetVariableValue((12 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr10GetTree() {
                
                #line 159 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                            item;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr10Get() {
                
                #line 159 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
                                            item;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr10Get() {
                this.GetValueTypeValues();
                return this.@__Expr10Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr11GetTree() {
                
                #line 154 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                            endPoint;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr11Get() {
                
                #line 154 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
                                            endPoint;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr11Get() {
                this.GetValueTypeValues();
                return this.@__Expr11Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr13GetTree() {
                
                #line 175 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.ICollection<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel>>> expression = () => 
                                          bscsResponseCollection;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.ICollection<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel> @__Expr13Get() {
                
                #line 175 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
                                          bscsResponseCollection;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.ICollection<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel> ValueType___Expr13Get() {
                this.GetValueTypeValues();
                return this.@__Expr13Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr14GetTree() {
                
                #line 171 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel>> expression = () => 
                                            responseModel;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel @__Expr14Get() {
                
                #line 171 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
                                            responseModel;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel ValueType___Expr14Get() {
                this.GetValueTypeValues();
                return this.@__Expr14Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 13))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 13);
                }
                expectedLocationsCount = 13;
                if (((locationReferences[(offset + 12)].Name != "item") 
                            || (locationReferences[(offset + 12)].Type != typeof(string)))) {
                    return false;
                }
                return AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruLinePortabilityQuery_TypedDataContext4 : AmxPeruLinePortabilityQuery_TypedDataContext3 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruLinePortabilityQuery_TypedDataContext4(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext4(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext4(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected System.Exception exception {
                get {
                    return ((System.Exception)(this.GetVariableValue((13 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((13 + locationsOffset), value);
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
                            && (locationReferences.Count < 14))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 14);
                }
                expectedLocationsCount = 14;
                if (((locationReferences[(offset + 13)].Name != "exception") 
                            || (locationReferences[(offset + 13)].Type != typeof(System.Exception)))) {
                    return false;
                }
                return AmxPeruLinePortabilityQuery_TypedDataContext3.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruLinePortabilityQuery_TypedDataContext4_ForReadOnly : AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruLinePortabilityQuery_TypedDataContext4_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext4_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext4_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected System.Exception exception {
                get {
                    return ((System.Exception)(this.GetVariableValue((13 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr15GetTree() {
                
                #line 197 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.ICollection<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel>>> expression = () => 
                                            bscsResponseCollection;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.ICollection<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel> @__Expr15Get() {
                
                #line 197 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
                                            bscsResponseCollection;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.ICollection<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel> ValueType___Expr15Get() {
                this.GetValueTypeValues();
                return this.@__Expr15Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr16GetTree() {
                
                #line 189 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel>> expression = () => 
                                              new GenericDirectoryNumberReadResponseModel()
            {
dirnum = item,
dnStatus = "NotClaro"
            };
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel @__Expr16Get() {
                
                #line 189 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
                                              new GenericDirectoryNumberReadResponseModel()
            {
dirnum = item,
dnStatus = "NotClaro"
            };
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel ValueType___Expr16Get() {
                this.GetValueTypeValues();
                return this.@__Expr16Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 14))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 14);
                }
                expectedLocationsCount = 14;
                if (((locationReferences[(offset + 13)].Name != "exception") 
                            || (locationReferences[(offset + 13)].Type != typeof(System.Exception)))) {
                    return false;
                }
                return AmxPeruLinePortabilityQuery_TypedDataContext3_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruLinePortabilityQuery_TypedDataContext5 : AmxPeruLinePortabilityQuery_TypedDataContext2 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruLinePortabilityQuery_TypedDataContext5(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext5(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext5(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel item {
                get {
                    return ((AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel)(this.GetVariableValue((12 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((12 + locationsOffset), value);
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
                            && (locationReferences.Count < 13))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 13);
                }
                expectedLocationsCount = 13;
                if (((locationReferences[(offset + 12)].Name != "item") 
                            || (locationReferences[(offset + 12)].Type != typeof(AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel)))) {
                    return false;
                }
                return AmxPeruLinePortabilityQuery_TypedDataContext2.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly : AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext5_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel item {
                get {
                    return ((AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel)(this.GetVariableValue((12 + locationsOffset))));
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
                
                #line 228 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                            item.dnStatus.Equals("NotClaro");
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr18Get() {
                
                #line 228 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
                            item.dnStatus.Equals("NotClaro");
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr18Get() {
                this.GetValueTypeValues();
                return this.@__Expr18Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr19GetTree() {
                
                #line 258 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.ICollection<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel>>> expression = () => 
                                  claroLineNumbers;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.ICollection<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel> @__Expr19Get() {
                
                #line 258 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
                                  claroLineNumbers;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.ICollection<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel> ValueType___Expr19Get() {
                this.GetValueTypeValues();
                return this.@__Expr19Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr20GetTree() {
                
                #line 254 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel>> expression = () => 
                                    item;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel @__Expr20Get() {
                
                #line 254 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
                                    item;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel ValueType___Expr20Get() {
                this.GetValueTypeValues();
                return this.@__Expr20Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr21GetTree() {
                
                #line 244 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.ICollection<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel>>> expression = () => 
                                  response;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.ICollection<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel> @__Expr21Get() {
                
                #line 244 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
                                  response;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.ICollection<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel> ValueType___Expr21Get() {
                this.GetValueTypeValues();
                return this.@__Expr21Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr22GetTree() {
                
                #line 235 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel>> expression = () => 
                                    new ClaroDirectoryNumberConfigResponseModel()
            {
            PhoneNumber = item.dirnum,
            Status = item.dnStatus,
            Provider = "NotClaro"
            };
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel @__Expr22Get() {
                
                #line 235 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
                                    new ClaroDirectoryNumberConfigResponseModel()
            {
            PhoneNumber = item.dirnum,
            Status = item.dnStatus,
            Provider = "NotClaro"
            };
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel ValueType___Expr22Get() {
                this.GetValueTypeValues();
                return this.@__Expr22Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 13))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 13);
                }
                expectedLocationsCount = 13;
                if (((locationReferences[(offset + 12)].Name != "item") 
                            || (locationReferences[(offset + 12)].Type != typeof(AmxPeruPSBActivities.Model.DirectoryNumberRead.GenericDirectoryNumberReadResponseModel)))) {
                    return false;
                }
                return AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruLinePortabilityQuery_TypedDataContext6 : AmxPeruLinePortabilityQuery_TypedDataContext2 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruLinePortabilityQuery_TypedDataContext6(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext6(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext6(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel item {
                get {
                    return ((AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel)(this.GetVariableValue((12 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((12 + locationsOffset), value);
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
                            && (locationReferences.Count < 13))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 13);
                }
                expectedLocationsCount = 13;
                if (((locationReferences[(offset + 12)].Name != "item") 
                            || (locationReferences[(offset + 12)].Type != typeof(AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel)))) {
                    return false;
                }
                return AmxPeruLinePortabilityQuery_TypedDataContext2.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruLinePortabilityQuery_TypedDataContext6_ForReadOnly : AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruLinePortabilityQuery_TypedDataContext6_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext6_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruLinePortabilityQuery_TypedDataContext6_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel item {
                get {
                    return ((AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel)(this.GetVariableValue((12 + locationsOffset))));
                }
            }
            
            internal new static System.Activities.XamlIntegration.CompiledDataContext[] GetCompiledDataContextCacheHelper(object dataContextActivities, System.Activities.ActivityContext activityContext, System.Activities.Activity compiledRoot, bool forImplementation, int compiledDataContextCount) {
                return System.Activities.XamlIntegration.CompiledDataContext.GetCompiledDataContextCache(dataContextActivities, activityContext, compiledRoot, forImplementation, compiledDataContextCount);
            }
            
            public new virtual void SetLocationsOffset(int locationsOffsetValue) {
                locationsOffset = locationsOffsetValue;
                base.SetLocationsOffset(locationsOffset);
            }
            
            internal System.Linq.Expressions.Expression @__Expr30GetTree() {
                
                #line 327 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.ICollection<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel>>> expression = () => 
                        response;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.ICollection<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel> @__Expr30Get() {
                
                #line 327 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
                        response;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.ICollection<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel> ValueType___Expr30Get() {
                this.GetValueTypeValues();
                return this.@__Expr30Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr31GetTree() {
                
                #line 323 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel>> expression = () => 
                          item;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel @__Expr31Get() {
                
                #line 323 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERULINEPORTABILITYQUERY.XAML"
                return 
                          item;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel ValueType___Expr31Get() {
                this.GetValueTypeValues();
                return this.@__Expr31Get();
            }
            
            public new static bool Validate(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences, bool validateLocationCount, int offset) {
                if (((validateLocationCount == true) 
                            && (locationReferences.Count < 13))) {
                    return false;
                }
                if ((validateLocationCount == true)) {
                    offset = (locationReferences.Count - 13);
                }
                expectedLocationsCount = 13;
                if (((locationReferences[(offset + 12)].Name != "item") 
                            || (locationReferences[(offset + 12)].Type != typeof(AmxPeruPSBActivities.Model.DirectoryNumberRead.ClaroDirectoryNumberConfigResponseModel)))) {
                    return false;
                }
                return AmxPeruLinePortabilityQuery_TypedDataContext2_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
    }
}

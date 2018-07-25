namespace AmxPeruPSBWorkflows {
    
    #line 26 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruValidationBeforeChangeResource.xaml"
    using System;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruValidationBeforeChangeResource.xaml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 27 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruValidationBeforeChangeResource.xaml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruValidationBeforeChangeResource.xaml"
    using System.Activities;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruValidationBeforeChangeResource.xaml"
    using System.Activities.Expressions;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruValidationBeforeChangeResource.xaml"
    using System.Activities.Statements;
    
    #line default
    #line hidden
    
    #line 28 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruValidationBeforeChangeResource.xaml"
    using System.Data;
    
    #line default
    #line hidden
    
    #line 29 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruValidationBeforeChangeResource.xaml"
    using System.Linq;
    
    #line default
    #line hidden
    
    #line 30 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruValidationBeforeChangeResource.xaml"
    using System.Text;
    
    #line default
    #line hidden
    
    #line 31 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruValidationBeforeChangeResource.xaml"
    using AmxPeruPSBActivities.Model.CheckDebtAccount;
    
    #line default
    #line hidden
    
    #line 32 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruValidationBeforeChangeResource.xaml"
    using AmxPeruPSBActivities.Model.ChangeResource;
    
    #line default
    #line hidden
    
    #line 1 "D:\CarlosRamirez\Desktop\MainBranch\AmxPeruPSBWorkflows\AmxPeruValidationBeforeChangeResource.xaml"
    using System.Activities.XamlIntegration;
    
    #line default
    #line hidden
    
    
    public partial class AmxPeruValidationBeforeChangeResource : System.Activities.XamlIntegration.ICompiledExpressionRoot {
        
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
                this.dataContextActivities = AmxPeruValidationBeforeChangeResource_TypedDataContext2.GetDataContextActivitiesHelper(this.rootActivity, this.forImplementation);
            }
            if ((expressionId == 0)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruValidationBeforeChangeResource_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruValidationBeforeChangeResource_TypedDataContext2(locations, activityContext, true);
                }
                AmxPeruValidationBeforeChangeResource_TypedDataContext2 refDataContext0 = ((AmxPeruValidationBeforeChangeResource_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 1)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly valDataContext1 = ((AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly valDataContext2 = ((AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext2.ValueType___Expr2Get();
            }
            if ((expressionId == 3)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruValidationBeforeChangeResource_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruValidationBeforeChangeResource_TypedDataContext2(locations, activityContext, true);
                }
                AmxPeruValidationBeforeChangeResource_TypedDataContext2 refDataContext3 = ((AmxPeruValidationBeforeChangeResource_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext3.GetLocation<AmxPeruPSBActivities.Model.CheckDebtAccount.CheckDebtAccountResponse>(refDataContext3.ValueType___Expr3Get, refDataContext3.ValueType___Expr3Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 4)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruValidationBeforeChangeResource_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruValidationBeforeChangeResource_TypedDataContext2(locations, activityContext, true);
                }
                AmxPeruValidationBeforeChangeResource_TypedDataContext2 refDataContext4 = ((AmxPeruValidationBeforeChangeResource_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext4.GetLocation<bool>(refDataContext4.ValueType___Expr4Get, refDataContext4.ValueType___Expr4Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 5)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly valDataContext5 = ((AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext5.ValueType___Expr5Get();
            }
            if ((expressionId == 6)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruValidationBeforeChangeResource_TypedDataContext3_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[2] == null)) {
                    cachedCompiledDataContext[2] = new AmxPeruValidationBeforeChangeResource_TypedDataContext3_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruValidationBeforeChangeResource_TypedDataContext3_ForReadOnly valDataContext6 = ((AmxPeruValidationBeforeChangeResource_TypedDataContext3_ForReadOnly)(cachedCompiledDataContext[2]));
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruValidationBeforeChangeResource_TypedDataContext3.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[3] == null)) {
                    cachedCompiledDataContext[3] = new AmxPeruValidationBeforeChangeResource_TypedDataContext3(locations, activityContext, true);
                }
                AmxPeruValidationBeforeChangeResource_TypedDataContext3 refDataContext7 = ((AmxPeruValidationBeforeChangeResource_TypedDataContext3)(cachedCompiledDataContext[3]));
                return refDataContext7.GetLocation<bool>(refDataContext7.ValueType___Expr7Get, refDataContext7.ValueType___Expr7Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 8)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly valDataContext8 = ((AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext8.ValueType___Expr8Get();
            }
            if ((expressionId == 9)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly valDataContext9 = ((AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext9.ValueType___Expr9Get();
            }
            if ((expressionId == 10)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly valDataContext10 = ((AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruValidationBeforeChangeResource_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruValidationBeforeChangeResource_TypedDataContext2(locations, activityContext, true);
                }
                AmxPeruValidationBeforeChangeResource_TypedDataContext2 refDataContext11 = ((AmxPeruValidationBeforeChangeResource_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext11.GetLocation<bool>(refDataContext11.ValueType___Expr11Get, refDataContext11.ValueType___Expr11Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 12)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly valDataContext12 = ((AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext12.ValueType___Expr12Get();
            }
            if ((expressionId == 13)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly valDataContext13 = ((AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext13.ValueType___Expr13Get();
            }
            if ((expressionId == 14)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruValidationBeforeChangeResource_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruValidationBeforeChangeResource_TypedDataContext2(locations, activityContext, true);
                }
                AmxPeruValidationBeforeChangeResource_TypedDataContext2 refDataContext14 = ((AmxPeruValidationBeforeChangeResource_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext14.GetLocation<AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse>(refDataContext14.ValueType___Expr14Get, refDataContext14.ValueType___Expr14Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 15)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly valDataContext15 = ((AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext15.ValueType___Expr15Get();
            }
            if ((expressionId == 16)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruValidationBeforeChangeResource_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruValidationBeforeChangeResource_TypedDataContext2(locations, activityContext, true);
                }
                AmxPeruValidationBeforeChangeResource_TypedDataContext2 refDataContext16 = ((AmxPeruValidationBeforeChangeResource_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext16.GetLocation<AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse>(refDataContext16.ValueType___Expr16Get, refDataContext16.ValueType___Expr16Set, expressionId, this.rootActivity, activityContext);
            }
            if ((expressionId == 17)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[1] == null)) {
                    cachedCompiledDataContext[1] = new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locations, activityContext, true);
                }
                AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly valDataContext17 = ((AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly)(cachedCompiledDataContext[1]));
                return valDataContext17.ValueType___Expr17Get();
            }
            if ((expressionId == 18)) {
                System.Activities.XamlIntegration.CompiledDataContext[] cachedCompiledDataContext = AmxPeruValidationBeforeChangeResource_TypedDataContext2.GetCompiledDataContextCacheHelper(this.dataContextActivities, activityContext, this.rootActivity, this.forImplementation, 4);
                if ((cachedCompiledDataContext[0] == null)) {
                    cachedCompiledDataContext[0] = new AmxPeruValidationBeforeChangeResource_TypedDataContext2(locations, activityContext, true);
                }
                AmxPeruValidationBeforeChangeResource_TypedDataContext2 refDataContext18 = ((AmxPeruValidationBeforeChangeResource_TypedDataContext2)(cachedCompiledDataContext[0]));
                return refDataContext18.GetLocation<AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse>(refDataContext18.ValueType___Expr18Get, refDataContext18.ValueType___Expr18Set, expressionId, this.rootActivity, activityContext);
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
                AmxPeruValidationBeforeChangeResource_TypedDataContext2 refDataContext0 = new AmxPeruValidationBeforeChangeResource_TypedDataContext2(locations, true);
                return refDataContext0.GetLocation<string>(refDataContext0.ValueType___Expr0Get, refDataContext0.ValueType___Expr0Set);
            }
            if ((expressionId == 1)) {
                AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly valDataContext1 = new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext1.ValueType___Expr1Get();
            }
            if ((expressionId == 2)) {
                AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly valDataContext2 = new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext2.ValueType___Expr2Get();
            }
            if ((expressionId == 3)) {
                AmxPeruValidationBeforeChangeResource_TypedDataContext2 refDataContext3 = new AmxPeruValidationBeforeChangeResource_TypedDataContext2(locations, true);
                return refDataContext3.GetLocation<AmxPeruPSBActivities.Model.CheckDebtAccount.CheckDebtAccountResponse>(refDataContext3.ValueType___Expr3Get, refDataContext3.ValueType___Expr3Set);
            }
            if ((expressionId == 4)) {
                AmxPeruValidationBeforeChangeResource_TypedDataContext2 refDataContext4 = new AmxPeruValidationBeforeChangeResource_TypedDataContext2(locations, true);
                return refDataContext4.GetLocation<bool>(refDataContext4.ValueType___Expr4Get, refDataContext4.ValueType___Expr4Set);
            }
            if ((expressionId == 5)) {
                AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly valDataContext5 = new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext5.ValueType___Expr5Get();
            }
            if ((expressionId == 6)) {
                AmxPeruValidationBeforeChangeResource_TypedDataContext3_ForReadOnly valDataContext6 = new AmxPeruValidationBeforeChangeResource_TypedDataContext3_ForReadOnly(locations, true);
                return valDataContext6.ValueType___Expr6Get();
            }
            if ((expressionId == 7)) {
                AmxPeruValidationBeforeChangeResource_TypedDataContext3 refDataContext7 = new AmxPeruValidationBeforeChangeResource_TypedDataContext3(locations, true);
                return refDataContext7.GetLocation<bool>(refDataContext7.ValueType___Expr7Get, refDataContext7.ValueType___Expr7Set);
            }
            if ((expressionId == 8)) {
                AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly valDataContext8 = new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext8.ValueType___Expr8Get();
            }
            if ((expressionId == 9)) {
                AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly valDataContext9 = new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext9.ValueType___Expr9Get();
            }
            if ((expressionId == 10)) {
                AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly valDataContext10 = new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext10.ValueType___Expr10Get();
            }
            if ((expressionId == 11)) {
                AmxPeruValidationBeforeChangeResource_TypedDataContext2 refDataContext11 = new AmxPeruValidationBeforeChangeResource_TypedDataContext2(locations, true);
                return refDataContext11.GetLocation<bool>(refDataContext11.ValueType___Expr11Get, refDataContext11.ValueType___Expr11Set);
            }
            if ((expressionId == 12)) {
                AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly valDataContext12 = new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext12.ValueType___Expr12Get();
            }
            if ((expressionId == 13)) {
                AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly valDataContext13 = new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext13.ValueType___Expr13Get();
            }
            if ((expressionId == 14)) {
                AmxPeruValidationBeforeChangeResource_TypedDataContext2 refDataContext14 = new AmxPeruValidationBeforeChangeResource_TypedDataContext2(locations, true);
                return refDataContext14.GetLocation<AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse>(refDataContext14.ValueType___Expr14Get, refDataContext14.ValueType___Expr14Set);
            }
            if ((expressionId == 15)) {
                AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly valDataContext15 = new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext15.ValueType___Expr15Get();
            }
            if ((expressionId == 16)) {
                AmxPeruValidationBeforeChangeResource_TypedDataContext2 refDataContext16 = new AmxPeruValidationBeforeChangeResource_TypedDataContext2(locations, true);
                return refDataContext16.GetLocation<AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse>(refDataContext16.ValueType___Expr16Get, refDataContext16.ValueType___Expr16Set);
            }
            if ((expressionId == 17)) {
                AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly valDataContext17 = new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locations, true);
                return valDataContext17.ValueType___Expr17Get();
            }
            if ((expressionId == 18)) {
                AmxPeruValidationBeforeChangeResource_TypedDataContext2 refDataContext18 = new AmxPeruValidationBeforeChangeResource_TypedDataContext2(locations, true);
                return refDataContext18.GetLocation<AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse>(refDataContext18.ValueType___Expr18Get, refDataContext18.ValueType___Expr18Set);
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool CanExecuteExpression(string expressionText, bool isReference, System.Collections.Generic.IList<System.Activities.LocationReference> locations, out int expressionId) {
            if (((isReference == true) 
                        && ((expressionText == "connectionString") 
                        && (AmxPeruValidationBeforeChangeResource_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 0;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "connectionString") 
                        && (AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 1;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new CheckDebtAccountRequest() { DocumentId = \"Passport\", DocumentNumber = \"123456" +
                            "7\" }") 
                        && (AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 2;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "debtStatusResponseModel") 
                        && (AmxPeruValidationBeforeChangeResource_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 3;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "accountDebtStatusFlag") 
                        && (AmxPeruValidationBeforeChangeResource_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 4;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "debtStatusResponseModel.CABECERA_CONSULTA") 
                        && (AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 5;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "debtItem.DEUDA_MOVIL > 0") 
                        && (AmxPeruValidationBeforeChangeResource_TypedDataContext3_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 6;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "accountDebtStatusFlag") 
                        && (AmxPeruValidationBeforeChangeResource_TypedDataContext3.Validate(locations, true, 0) == true)))) {
                expressionId = 7;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "accountDebtStatusFlag == true") 
                        && (AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 8;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "connectionString") 
                        && (AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 9;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "requestModel.SubscriptionId") 
                        && (AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 10;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "openShoppingCartStatus") 
                        && (AmxPeruValidationBeforeChangeResource_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 11;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "openShoppingCartStatus == true") 
                        && (AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 12;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new ChangeResourceResponse() { Status = \"0\" }") 
                        && (AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 13;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "responseModel") 
                        && (AmxPeruValidationBeforeChangeResource_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 14;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new ChangeResourceResponse() { Status = \"1\", Error = \"OpenShoppingCart\" }") 
                        && (AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 15;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "responseModel") 
                        && (AmxPeruValidationBeforeChangeResource_TypedDataContext2.Validate(locations, true, 0) == true)))) {
                expressionId = 16;
                return true;
            }
            if (((isReference == false) 
                        && ((expressionText == "new ChangeResourceResponse() { Status=\"1\", Error = \"OpenDebtExists\" }") 
                        && (AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly.Validate(locations, true, 0) == true)))) {
                expressionId = 17;
                return true;
            }
            if (((isReference == true) 
                        && ((expressionText == "responseModel") 
                        && (AmxPeruValidationBeforeChangeResource_TypedDataContext2.Validate(locations, true, 0) == true)))) {
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
                return new AmxPeruValidationBeforeChangeResource_TypedDataContext2(locationReferences).@__Expr0GetTree();
            }
            if ((expressionId == 1)) {
                return new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locationReferences).@__Expr1GetTree();
            }
            if ((expressionId == 2)) {
                return new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locationReferences).@__Expr2GetTree();
            }
            if ((expressionId == 3)) {
                return new AmxPeruValidationBeforeChangeResource_TypedDataContext2(locationReferences).@__Expr3GetTree();
            }
            if ((expressionId == 4)) {
                return new AmxPeruValidationBeforeChangeResource_TypedDataContext2(locationReferences).@__Expr4GetTree();
            }
            if ((expressionId == 5)) {
                return new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locationReferences).@__Expr5GetTree();
            }
            if ((expressionId == 6)) {
                return new AmxPeruValidationBeforeChangeResource_TypedDataContext3_ForReadOnly(locationReferences).@__Expr6GetTree();
            }
            if ((expressionId == 7)) {
                return new AmxPeruValidationBeforeChangeResource_TypedDataContext3(locationReferences).@__Expr7GetTree();
            }
            if ((expressionId == 8)) {
                return new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locationReferences).@__Expr8GetTree();
            }
            if ((expressionId == 9)) {
                return new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locationReferences).@__Expr9GetTree();
            }
            if ((expressionId == 10)) {
                return new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locationReferences).@__Expr10GetTree();
            }
            if ((expressionId == 11)) {
                return new AmxPeruValidationBeforeChangeResource_TypedDataContext2(locationReferences).@__Expr11GetTree();
            }
            if ((expressionId == 12)) {
                return new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locationReferences).@__Expr12GetTree();
            }
            if ((expressionId == 13)) {
                return new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locationReferences).@__Expr13GetTree();
            }
            if ((expressionId == 14)) {
                return new AmxPeruValidationBeforeChangeResource_TypedDataContext2(locationReferences).@__Expr14GetTree();
            }
            if ((expressionId == 15)) {
                return new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locationReferences).@__Expr15GetTree();
            }
            if ((expressionId == 16)) {
                return new AmxPeruValidationBeforeChangeResource_TypedDataContext2(locationReferences).@__Expr16GetTree();
            }
            if ((expressionId == 17)) {
                return new AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(locationReferences).@__Expr17GetTree();
            }
            if ((expressionId == 18)) {
                return new AmxPeruValidationBeforeChangeResource_TypedDataContext2(locationReferences).@__Expr18GetTree();
            }
            return null;
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruValidationBeforeChangeResource_TypedDataContext0 : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruValidationBeforeChangeResource_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruValidationBeforeChangeResource_TypedDataContext0(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruValidationBeforeChangeResource_TypedDataContext0(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class AmxPeruValidationBeforeChangeResource_TypedDataContext0_ForReadOnly : System.Activities.XamlIntegration.CompiledDataContext {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruValidationBeforeChangeResource_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruValidationBeforeChangeResource_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruValidationBeforeChangeResource_TypedDataContext0_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
        private class AmxPeruValidationBeforeChangeResource_TypedDataContext1 : AmxPeruValidationBeforeChangeResource_TypedDataContext0 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruValidationBeforeChangeResource_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruValidationBeforeChangeResource_TypedDataContext1(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruValidationBeforeChangeResource_TypedDataContext1(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceRequest requestModel {
                get {
                    return ((AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceRequest)(this.GetVariableValue((0 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((0 + locationsOffset), value);
                }
            }
            
            protected AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse responseModel {
                get {
                    return ((AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse)(this.GetVariableValue((1 + locationsOffset))));
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
                if (((locationReferences[(offset + 0)].Name != "requestModel") 
                            || (locationReferences[(offset + 0)].Type != typeof(AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceRequest)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "responseModel") 
                            || (locationReferences[(offset + 1)].Type != typeof(AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse)))) {
                    return false;
                }
                return AmxPeruValidationBeforeChangeResource_TypedDataContext0.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruValidationBeforeChangeResource_TypedDataContext1_ForReadOnly : AmxPeruValidationBeforeChangeResource_TypedDataContext0_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruValidationBeforeChangeResource_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruValidationBeforeChangeResource_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruValidationBeforeChangeResource_TypedDataContext1_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceRequest requestModel {
                get {
                    return ((AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceRequest)(this.GetVariableValue((0 + locationsOffset))));
                }
            }
            
            protected AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse responseModel {
                get {
                    return ((AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse)(this.GetVariableValue((1 + locationsOffset))));
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
                if (((locationReferences[(offset + 0)].Name != "requestModel") 
                            || (locationReferences[(offset + 0)].Type != typeof(AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceRequest)))) {
                    return false;
                }
                if (((locationReferences[(offset + 1)].Name != "responseModel") 
                            || (locationReferences[(offset + 1)].Type != typeof(AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse)))) {
                    return false;
                }
                return AmxPeruValidationBeforeChangeResource_TypedDataContext0_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruValidationBeforeChangeResource_TypedDataContext2 : AmxPeruValidationBeforeChangeResource_TypedDataContext1 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected bool accountDebtStatusFlag;
            
            protected bool openShoppingCartStatus;
            
            public AmxPeruValidationBeforeChangeResource_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruValidationBeforeChangeResource_TypedDataContext2(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruValidationBeforeChangeResource_TypedDataContext2(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
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
            
            protected AmxPeruPSBActivities.Model.CheckDebtAccount.CheckDebtAccountResponse debtStatusResponseModel {
                get {
                    return ((AmxPeruPSBActivities.Model.CheckDebtAccount.CheckDebtAccountResponse)(this.GetVariableValue((5 + locationsOffset))));
                }
                set {
                    this.SetVariableValue((5 + locationsOffset), value);
                }
            }
            
            protected System.Collections.Generic.List<string> errorsList {
                get {
                    return ((System.Collections.Generic.List<string>)(this.GetVariableValue((6 + locationsOffset))));
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
                
                #line 84 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
              connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr0Get() {
                
                #line 84 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
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
                
                #line 84 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                
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
                
                #line 100 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.CheckDebtAccount.CheckDebtAccountResponse>> expression = () => 
                      debtStatusResponseModel;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.CheckDebtAccount.CheckDebtAccountResponse @__Expr3Get() {
                
                #line 100 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                return 
                      debtStatusResponseModel;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.CheckDebtAccount.CheckDebtAccountResponse ValueType___Expr3Get() {
                this.GetValueTypeValues();
                return this.@__Expr3Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr3Set(AmxPeruPSBActivities.Model.CheckDebtAccount.CheckDebtAccountResponse value) {
                
                #line 100 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                
                      debtStatusResponseModel = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr3Set(AmxPeruPSBActivities.Model.CheckDebtAccount.CheckDebtAccountResponse value) {
                this.GetValueTypeValues();
                this.@__Expr3Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr4GetTree() {
                
                #line 116 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                      accountDebtStatusFlag;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr4Get() {
                
                #line 116 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                return 
                      accountDebtStatusFlag;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr4Get() {
                this.GetValueTypeValues();
                return this.@__Expr4Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr4Set(bool value) {
                
                #line 116 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                
                      accountDebtStatusFlag = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr4Set(bool value) {
                this.GetValueTypeValues();
                this.@__Expr4Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr11GetTree() {
                
                #line 184 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                      openShoppingCartStatus;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr11Get() {
                
                #line 184 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                return 
                                      openShoppingCartStatus;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr11Get() {
                this.GetValueTypeValues();
                return this.@__Expr11Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr11Set(bool value) {
                
                #line 184 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                
                                      openShoppingCartStatus = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr11Set(bool value) {
                this.GetValueTypeValues();
                this.@__Expr11Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr14GetTree() {
                
                #line 226 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse>> expression = () => 
                                          responseModel;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse @__Expr14Get() {
                
                #line 226 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                return 
                                          responseModel;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse ValueType___Expr14Get() {
                this.GetValueTypeValues();
                return this.@__Expr14Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr14Set(AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse value) {
                
                #line 226 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                
                                          responseModel = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr14Set(AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse value) {
                this.GetValueTypeValues();
                this.@__Expr14Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr16GetTree() {
                
                #line 210 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse>> expression = () => 
                                          responseModel;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse @__Expr16Get() {
                
                #line 210 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                return 
                                          responseModel;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse ValueType___Expr16Get() {
                this.GetValueTypeValues();
                return this.@__Expr16Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr16Set(AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse value) {
                
                #line 210 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                
                                          responseModel = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr16Set(AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse value) {
                this.GetValueTypeValues();
                this.@__Expr16Set(value);
                this.SetValueTypeValues();
            }
            
            internal System.Linq.Expressions.Expression @__Expr18GetTree() {
                
                #line 166 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse>> expression = () => 
                                  responseModel;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse @__Expr18Get() {
                
                #line 166 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                return 
                                  responseModel;
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse ValueType___Expr18Get() {
                this.GetValueTypeValues();
                return this.@__Expr18Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr18Set(AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse value) {
                
                #line 166 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                
                                  responseModel = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr18Set(AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse value) {
                this.GetValueTypeValues();
                this.@__Expr18Set(value);
                this.SetValueTypeValues();
            }
            
            protected override void GetValueTypeValues() {
                this.accountDebtStatusFlag = ((bool)(this.GetVariableValue((3 + locationsOffset))));
                this.openShoppingCartStatus = ((bool)(this.GetVariableValue((4 + locationsOffset))));
                base.GetValueTypeValues();
            }
            
            protected override void SetValueTypeValues() {
                this.SetVariableValue((3 + locationsOffset), this.accountDebtStatusFlag);
                this.SetVariableValue((4 + locationsOffset), this.openShoppingCartStatus);
                base.SetValueTypeValues();
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
                if (((locationReferences[(offset + 2)].Name != "connectionString") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 5)].Name != "debtStatusResponseModel") 
                            || (locationReferences[(offset + 5)].Type != typeof(AmxPeruPSBActivities.Model.CheckDebtAccount.CheckDebtAccountResponse)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "errorsList") 
                            || (locationReferences[(offset + 6)].Type != typeof(System.Collections.Generic.List<string>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "accountDebtStatusFlag") 
                            || (locationReferences[(offset + 3)].Type != typeof(bool)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "openShoppingCartStatus") 
                            || (locationReferences[(offset + 4)].Type != typeof(bool)))) {
                    return false;
                }
                return AmxPeruValidationBeforeChangeResource_TypedDataContext1.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly : AmxPeruValidationBeforeChangeResource_TypedDataContext1_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            protected bool accountDebtStatusFlag;
            
            protected bool openShoppingCartStatus;
            
            public AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected string connectionString {
                get {
                    return ((string)(this.GetVariableValue((2 + locationsOffset))));
                }
            }
            
            protected AmxPeruPSBActivities.Model.CheckDebtAccount.CheckDebtAccountResponse debtStatusResponseModel {
                get {
                    return ((AmxPeruPSBActivities.Model.CheckDebtAccount.CheckDebtAccountResponse)(this.GetVariableValue((5 + locationsOffset))));
                }
            }
            
            protected System.Collections.Generic.List<string> errorsList {
                get {
                    return ((System.Collections.Generic.List<string>)(this.GetVariableValue((6 + locationsOffset))));
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
                
                #line 107 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                  connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr1Get() {
                
                #line 107 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
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
                
                #line 95 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.CheckDebtAccount.CheckDebtAccountRequest>> expression = () => 
                      new CheckDebtAccountRequest() { DocumentId = "Passport", DocumentNumber = "1234567" };
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.CheckDebtAccount.CheckDebtAccountRequest @__Expr2Get() {
                
                #line 95 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                return 
                      new CheckDebtAccountRequest() { DocumentId = "Passport", DocumentNumber = "1234567" };
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.CheckDebtAccount.CheckDebtAccountRequest ValueType___Expr2Get() {
                this.GetValueTypeValues();
                return this.@__Expr2Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr5GetTree() {
                
                #line 128 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                System.Linq.Expressions.Expression<System.Func<System.Collections.Generic.IEnumerable<AmxPeruPSBActivities.Model.CheckDebtAccount.HeadQuestionType>>> expression = () => 
                          debtStatusResponseModel.CABECERA_CONSULTA;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public System.Collections.Generic.IEnumerable<AmxPeruPSBActivities.Model.CheckDebtAccount.HeadQuestionType> @__Expr5Get() {
                
                #line 128 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                return 
                          debtStatusResponseModel.CABECERA_CONSULTA;
                
                #line default
                #line hidden
            }
            
            public System.Collections.Generic.IEnumerable<AmxPeruPSBActivities.Model.CheckDebtAccount.HeadQuestionType> ValueType___Expr5Get() {
                this.GetValueTypeValues();
                return this.@__Expr5Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr8GetTree() {
                
                #line 159 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                          accountDebtStatusFlag == true;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr8Get() {
                
                #line 159 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                return 
                          accountDebtStatusFlag == true;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr8Get() {
                this.GetValueTypeValues();
                return this.@__Expr8Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr9GetTree() {
                
                #line 196 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                  connectionString;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr9Get() {
                
                #line 196 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                return 
                                  connectionString;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr9Get() {
                this.GetValueTypeValues();
                return this.@__Expr9Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr10GetTree() {
                
                #line 189 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                System.Linq.Expressions.Expression<System.Func<string>> expression = () => 
                                      requestModel.SubscriptionId;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public string @__Expr10Get() {
                
                #line 189 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                return 
                                      requestModel.SubscriptionId;
                
                #line default
                #line hidden
            }
            
            public string ValueType___Expr10Get() {
                this.GetValueTypeValues();
                return this.@__Expr10Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr12GetTree() {
                
                #line 203 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                  openShoppingCartStatus == true;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr12Get() {
                
                #line 203 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                return 
                                  openShoppingCartStatus == true;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr12Get() {
                this.GetValueTypeValues();
                return this.@__Expr12Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr13GetTree() {
                
                #line 231 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse>> expression = () => 
                                          new ChangeResourceResponse() { Status = "0" };
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse @__Expr13Get() {
                
                #line 231 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                return 
                                          new ChangeResourceResponse() { Status = "0" };
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse ValueType___Expr13Get() {
                this.GetValueTypeValues();
                return this.@__Expr13Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr15GetTree() {
                
                #line 215 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse>> expression = () => 
                                          new ChangeResourceResponse() { Status = "1", Error = "OpenShoppingCart" };
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse @__Expr15Get() {
                
                #line 215 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                return 
                                          new ChangeResourceResponse() { Status = "1", Error = "OpenShoppingCart" };
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse ValueType___Expr15Get() {
                this.GetValueTypeValues();
                return this.@__Expr15Get();
            }
            
            internal System.Linq.Expressions.Expression @__Expr17GetTree() {
                
                #line 171 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                System.Linq.Expressions.Expression<System.Func<AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse>> expression = () => 
                                  new ChangeResourceResponse() { Status="1", Error = "OpenDebtExists" };
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse @__Expr17Get() {
                
                #line 171 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                return 
                                  new ChangeResourceResponse() { Status="1", Error = "OpenDebtExists" };
                
                #line default
                #line hidden
            }
            
            public AmxPeruPSBActivities.Model.ChangeResource.ChangeResourceResponse ValueType___Expr17Get() {
                this.GetValueTypeValues();
                return this.@__Expr17Get();
            }
            
            protected override void GetValueTypeValues() {
                this.accountDebtStatusFlag = ((bool)(this.GetVariableValue((3 + locationsOffset))));
                this.openShoppingCartStatus = ((bool)(this.GetVariableValue((4 + locationsOffset))));
                base.GetValueTypeValues();
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
                if (((locationReferences[(offset + 2)].Name != "connectionString") 
                            || (locationReferences[(offset + 2)].Type != typeof(string)))) {
                    return false;
                }
                if (((locationReferences[(offset + 5)].Name != "debtStatusResponseModel") 
                            || (locationReferences[(offset + 5)].Type != typeof(AmxPeruPSBActivities.Model.CheckDebtAccount.CheckDebtAccountResponse)))) {
                    return false;
                }
                if (((locationReferences[(offset + 6)].Name != "errorsList") 
                            || (locationReferences[(offset + 6)].Type != typeof(System.Collections.Generic.List<string>)))) {
                    return false;
                }
                if (((locationReferences[(offset + 3)].Name != "accountDebtStatusFlag") 
                            || (locationReferences[(offset + 3)].Type != typeof(bool)))) {
                    return false;
                }
                if (((locationReferences[(offset + 4)].Name != "openShoppingCartStatus") 
                            || (locationReferences[(offset + 4)].Type != typeof(bool)))) {
                    return false;
                }
                return AmxPeruValidationBeforeChangeResource_TypedDataContext1_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruValidationBeforeChangeResource_TypedDataContext3 : AmxPeruValidationBeforeChangeResource_TypedDataContext2 {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruValidationBeforeChangeResource_TypedDataContext3(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruValidationBeforeChangeResource_TypedDataContext3(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruValidationBeforeChangeResource_TypedDataContext3(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected AmxPeruPSBActivities.Model.CheckDebtAccount.HeadQuestionType debtItem {
                get {
                    return ((AmxPeruPSBActivities.Model.CheckDebtAccount.HeadQuestionType)(this.GetVariableValue((7 + locationsOffset))));
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
            
            internal System.Linq.Expressions.Expression @__Expr7GetTree() {
                
                #line 145 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                                  accountDebtStatusFlag;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr7Get() {
                
                #line 145 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                return 
                                  accountDebtStatusFlag;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr7Get() {
                this.GetValueTypeValues();
                return this.@__Expr7Get();
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public void @__Expr7Set(bool value) {
                
                #line 145 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                
                                  accountDebtStatusFlag = value;
                
                #line default
                #line hidden
            }
            
            public void ValueType___Expr7Set(bool value) {
                this.GetValueTypeValues();
                this.@__Expr7Set(value);
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
                if (((locationReferences[(offset + 7)].Name != "debtItem") 
                            || (locationReferences[(offset + 7)].Type != typeof(AmxPeruPSBActivities.Model.CheckDebtAccount.HeadQuestionType)))) {
                    return false;
                }
                return AmxPeruValidationBeforeChangeResource_TypedDataContext2.Validate(locationReferences, false, offset);
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Activities", "4.0.0.0")]
        [System.ComponentModel.BrowsableAttribute(false)]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        private class AmxPeruValidationBeforeChangeResource_TypedDataContext3_ForReadOnly : AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly {
            
            private int locationsOffset;
            
            private static int expectedLocationsCount;
            
            public AmxPeruValidationBeforeChangeResource_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locations, System.Activities.ActivityContext activityContext, bool computelocationsOffset) : 
                    base(locations, activityContext, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruValidationBeforeChangeResource_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.Location> locations, bool computelocationsOffset) : 
                    base(locations, false) {
                if ((computelocationsOffset == true)) {
                    this.SetLocationsOffset((locations.Count - expectedLocationsCount));
                }
            }
            
            public AmxPeruValidationBeforeChangeResource_TypedDataContext3_ForReadOnly(System.Collections.Generic.IList<System.Activities.LocationReference> locationReferences) : 
                    base(locationReferences) {
            }
            
            protected AmxPeruPSBActivities.Model.CheckDebtAccount.HeadQuestionType debtItem {
                get {
                    return ((AmxPeruPSBActivities.Model.CheckDebtAccount.HeadQuestionType)(this.GetVariableValue((7 + locationsOffset))));
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
                
                #line 138 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                System.Linq.Expressions.Expression<System.Func<bool>> expression = () => 
                              debtItem.DEUDA_MOVIL > 0;
                
                #line default
                #line hidden
                return base.RewriteExpressionTree(expression);
            }
            
            [System.Diagnostics.DebuggerHiddenAttribute()]
            public bool @__Expr6Get() {
                
                #line 138 "D:\CARLOSRAMIREZ\DESKTOP\MAINBRANCH\AMXPERUPSBWORKFLOWS\AMXPERUVALIDATIONBEFORECHANGERESOURCE.XAML"
                return 
                              debtItem.DEUDA_MOVIL > 0;
                
                #line default
                #line hidden
            }
            
            public bool ValueType___Expr6Get() {
                this.GetValueTypeValues();
                return this.@__Expr6Get();
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
                if (((locationReferences[(offset + 7)].Name != "debtItem") 
                            || (locationReferences[(offset + 7)].Type != typeof(AmxPeruPSBActivities.Model.CheckDebtAccount.HeadQuestionType)))) {
                    return false;
                }
                return AmxPeruValidationBeforeChangeResource_TypedDataContext2_ForReadOnly.Validate(locationReferences, false, offset);
            }
        }
    }
}

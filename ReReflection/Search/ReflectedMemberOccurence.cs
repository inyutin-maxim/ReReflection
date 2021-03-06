﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.ActionManagement;
using JetBrains.Annotations;
using JetBrains.ProjectModel;

#if R9
using JetBrains.ReSharper.Features.Navigation.Features.OccurencesActions;
using JetBrains.UI.ActionsRevised;
#else
using JetBrains.ReSharper.Feature.Services.Navigation.Search;
using JetBrains.ReSharper.Feature.Services.Occurences.OccurenceKindProviders;
using JetBrains.ReSharper.Features.Common.Occurences;
#endif

using JetBrains.ReSharper.Feature.Services.Occurences;
using JetBrains.ReSharper.Feature.Services.Resources;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Resolve;
using JetBrains.ReSharper.Psi.Tree;

namespace ReSharper.Reflection.Search
{
    public class ReflectedMemberOccurence : ReferenceOccurence
    {
        public ReflectedMemberOccurence(IReference reference, IDeclaredElement target, OccurenceType occurenceType, IProjectFile projectFile = null) 
#if R9
            : base(reference, target, occurenceType)
#else
            : base(reference, target, occurenceType, projectFile)
#endif
        {
            Kinds.Clear();
            Kinds.Add(ReflectedMemberOccurenceKindProvider.ReflectionOccurenceKind);
        }
    }

#if R9
    [Action("OccurenceBrowser.Filter.ShowReflection", "Show Reflection Usages", Icon = typeof(ServicesNavigationThemedIcons.UsageBase), Id = 2253)]
#else
    [ActionHandler(new string[] { "OccurenceBrowser.Filter.ShowReflection" })]
#endif
    public class ShowReflectionAccessAction : ShowOccurenceKindBaseAction
    {
        public override OccurenceKind OccurenceKind
        {
            get
            {
                return ReflectedMemberOccurenceKindProvider.ReflectionOccurenceKind;
            }
        }
    }
}

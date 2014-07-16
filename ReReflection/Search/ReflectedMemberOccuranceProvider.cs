﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.ReSharper.Feature.Services.Navigation.Search;
using JetBrains.ReSharper.Feature.Services.Occurences;
using JetBrains.ReSharper.Psi.Search;

namespace ReSharper.Reflection.Search
{
    [OccurenceProvider(Priority = 1)]
    public class ReflectedMemberOccuranceProvider : IOccurenceProvider
    {
        public IOccurence MakeOccurence(FindResult findResult)
        {
            var findResultReference = findResult as FindResultReference;
            if (findResultReference != null && findResultReference.Reference is ReflectedMemberReference)
            {
                var reflectedMemberReference = (ReflectedMemberReference)findResultReference.Reference;
                return new ReflectedMemberOccurence(reflectedMemberReference, reflectedMemberReference.CurrentResolveResult.DeclaredElement, OccurenceType.Occurence);
            }
            return null;
        }
    }
}

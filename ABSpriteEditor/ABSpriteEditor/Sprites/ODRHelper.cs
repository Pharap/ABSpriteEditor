using System;
using System.Collections.Generic;
using System.Linq;

//
//  Copyright (C) 2022 Pharap (@Pharap)
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

namespace ABSpriteEditor.Sprites
{
    public static class ODRHelper
    {
        public static bool ViolatesODR(SpriteFile spriteFile)
        {
            return EnumerateODRViolations(spriteFile).Any();
        }

        public static IEnumerable<string> EnumerateODRViolations(SpriteFile spriteFile)
        {
            return EnumerateODRViolations((ISpriteGroup)spriteFile, new List<Identifier>());
        }

        internal static IEnumerable<string> EnumerateODRViolationsForTree(SpriteFile spriteFile, Identifier treeTitle)
        {
            return ODRHelper.EnumerateODRViolations((ISpriteGroup)spriteFile, new List<Identifier>() { treeTitle });
        }

        internal static IEnumerable<string> EnumerateODRViolations(ISpriteGroup spriteGroup, List<Identifier> outerNamespaces)
        {
            // If the group doesn't represent the global namespace
            if (spriteGroup.Namespace != null)
                // Push the group's namespace onto the stack
                outerNamespaces.Add(spriteGroup.Namespace);

            // A string representing the fully qualified namespace that contains the sprites.
            var namespacePrefix = new Lazy<string>(() => string.Join("::", outerNamespaces));

            // Create a hashset to track names in the scope
            var scope = new HashSet<Identifier>();

            foreach (var sprite in spriteGroup.Sprites)
            {
                // Add the sprite's name to the current scope
                if (!scope.Add(sprite.Name))
                {
                    // If the name wasn't added, a definition already exists...

                    // Construct the offending sprite's full name
                    var fullName = string.Format("{0}::{1}", namespacePrefix.Value, sprite.Name);

                    // Yield the full name back to the caller
                    yield return fullName;
                }
            }

            foreach (var subgroup in spriteGroup.Subgroups)
            {
                // Add the sprite group's name to the current scope
                if (!scope.Add(subgroup.Namespace))
                {
                    // If the name wasn't added, a definition already exists...

                    // Construct the offending sprite group's full name
                    var fullName = string.Format("{0}::{1}", namespacePrefix.Value, subgroup.Namespace);

                    // Yield the full name back to the caller
                    yield return fullName;
                }

                // Recurse into the current subgroup
                foreach (var violation in EnumerateODRViolations(subgroup, outerNamespaces))
                    // Yield all violations produced by the subgroup
                    yield return violation;
            }

            // If the group doesn't represent the global namespace
            if (spriteGroup.Namespace != null)
                // Remove the group's namespace from the stack
                outerNamespaces.RemoveAt(outerNamespaces.Count - 1);
        }

        public static IEnumerable<Identifier> EnumerateCurrentLevelODRViolations(ISpriteGroup spriteGroup)
        {
            // Create a hashset to track names in the current scope
            var scope = new HashSet<Identifier>();

            foreach (var sprite in spriteGroup.Sprites)
                // Add the sprite's name to the current scope
                if (!scope.Add(sprite.Name))
                    // If the name wasn't added, it already had been, so the ODR has been violated
                    // Yield the sprite's name back to the caller
                    yield return sprite.Name;

            foreach (var subgroup in spriteGroup.Subgroups)
                // Add the sprite group's name to the current scope
                if (!scope.Add(subgroup.Namespace))
                    // If the name wasn't added, it already had been, so the ODR has been violated
                    // Yield the group's name back to the caller
                    yield return subgroup.Namespace;
        }
    }
}

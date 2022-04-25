using System.Windows.Forms;
using ABSpriteEditor.Properties;
using ABSpriteEditor.Sprites;

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

namespace ABSpriteEditor
{
    public static class WarningsHelper
    {
        private static DialogResult ShowWarningBox(string message)
        {
            return MessageBox.Show(message, Strings.Warning, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        }

        private static DialogResult ShowWarningBox(string message, MessageBoxButtons buttons)
        {
            return MessageBox.Show(message, Strings.Warning, buttons, MessageBoxIcon.Warning);
        }

        public static DialogResult ShowMemoryUsageWarning(int spriteBytes, int arduboyBytes)
        {
            var warning = string.Format(WarningStrings.SpriteExceedsArduboyMemoryLimit, spriteBytes, arduboyBytes);
            return ShowWarningBox(warning);
        }

        public static DialogResult ShowInvalidSpriteNameChangedWarning(Identifier name)
        {
            var warning = string.Format(WarningStrings.InvalidSpriteNameChanged, name);
            return ShowWarningBox(warning);
        }

        public static DialogResult ShowInvalidNamespaceNameChangedWarning(Identifier name)
        {
            var warning = string.Format(WarningStrings.InvalidNamespaceNameChanged, name);
            return ShowWarningBox(warning);
        }

        public static DialogResult ShowClosingUnsavedSpriteWarning(string spriteName)
        {
            var warning = string.Format(WarningStrings.ClosingUnsavedSprite, spriteName);
            return ShowWarningBox(warning, MessageBoxButtons.YesNoCancel);
        }

        public static DialogResult ShowSpriteFileViolatesTheODRWarning()
        {
            return ShowWarningBox(WarningStrings.SpriteFileViolatesTheODR);
        }

        public static DialogResult ShowFileDropOverwritesFramesWarning()
        {
            return ShowWarningBox(WarningStrings.FileDropOverwritesFrames);
        }
    }
}

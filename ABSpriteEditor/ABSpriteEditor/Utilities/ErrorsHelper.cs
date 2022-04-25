using System.Windows.Forms;
using ABSpriteEditor.Properties;

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
    public static class ErrorsHelper
    {
        private static DialogResult ShowErrorBox(string message)
        {
            return MessageBox.Show(message, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static DialogResult ShowErrorBox(string message, MessageBoxButtons buttons)
        {
            return MessageBox.Show(message, Strings.Error, buttons, MessageBoxIcon.Error);
        }

        public static DialogResult ShowInvalidSpriteNameError()
        {
            return ShowErrorBox(ErrorStrings.InvalidSpriteName);
        }

        public static DialogResult ShowInvalidNamespaceNameError()
        {
            return ShowErrorBox(ErrorStrings.InvalidNamespaceName);
        }

        public static DialogResult ShowNoFilesToSaveError()
        {
            return ShowErrorBox(ErrorStrings.NoFilesToSave);
        }

        public static DialogResult ShowNoFilesToExportError()
        {
            return ShowErrorBox(ErrorStrings.NoFilesToExport);
        }

        public static DialogResult ShowUnexpectedExceptionLoggedError(string logFilePath)
        {
            var message = string.Format(ErrorStrings.UnexpectedExceptionLogged, logFilePath);
            return ShowErrorBox(message);
        }

        public static DialogResult ShowSpriteFileDropInvalidDimensionsError(string filePath, int imageWidth, int imageHeight, int spriteWidth, int spriteHeight)
        {
            var message = string.Format(ErrorStrings.SpriteFileDropInvalidDimensions, filePath, imageWidth, imageHeight, spriteWidth, spriteHeight);
            return ShowErrorBox(message, MessageBoxButtons.OKCancel);
        }

        public static DialogResult ShowFileContainedErrorsError(string loadFilePath, string logFilePath)
        {
            var message = string.Format(ErrorStrings.FileContainedErrors, loadFilePath, logFilePath);
            return ShowErrorBox(message, MessageBoxButtons.OKCancel);
        }
    }
}

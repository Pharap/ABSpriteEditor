using System.Collections.Generic;
using System.IO;
using System.Text;

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

namespace ABSpriteEditor.Utilities
{
    public class FileHelper
    {
        private static HashSet<char> invalidFileNameChars;
        private static HashSet<char> invalidPathChars;

        static FileHelper()
        {
            invalidFileNameChars = new HashSet<char>(Path.GetInvalidFileNameChars());
            invalidPathChars = new HashSet<char>(Path.GetInvalidPathChars());
        }

        public static bool IsInvalidFileNameChar(char character)
        {
            return invalidFileNameChars.Contains(character);
        }

        public static bool IsInvalidPathChar(char character)
        {
            return invalidPathChars.Contains(character);
        }

        public static string ValidateFileName(string value)
        {
            var builder = new StringBuilder();
            var invalid = false;

            foreach (var character in value)
            {
                if (IsInvalidFileNameChar(character))
                {
                    invalid = true;
                }
                else
                {
                    builder.Append(character);
                }
            }

            return (invalid ? builder.ToString() : value);
        }

        public static string ValidatePath(string value)
        {
            var builder = new StringBuilder();
            var invalid = false;

            foreach (var character in value)
            {
                if (IsInvalidPathChar(character))
                {
                    invalid = true;
                }
                else
                {
                    builder.Append(character);
                }
            }

            return (invalid ? builder.ToString() : value);
        }
    }
}

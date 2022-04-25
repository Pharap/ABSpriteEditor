using System;
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

namespace ABSpriteEditor.Sprites
{
    // TODO: Comment this class
    public class Identifier : IEquatable<Identifier>
    {
        private readonly string identifier;

        private Identifier(string identifier)
        {
            this.identifier = identifier;
        }

        public override string ToString()
        {
            return this.identifier;
        }

        public override int GetHashCode()
        {
            return this.identifier.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Identifier);
        }

        public bool Equals(Identifier other)
        {
            return ((other != null) && this.identifier.Equals(other.identifier));
        }

        public static Identifier Create(string name)
        {
            return new Identifier(ConvertToIdentifier(name));
        }

        public static Identifier CreateOrDefault(string name, Identifier defaultValue)
        {
            return (CanCreateIdentifierFrom(name) ? Create(name) : defaultValue);
        }

        public static bool IsValidIdentifier(string name)
        {
            // If the name's length is zero
            if (name.Length == 0)
                // It is not a valid identifier, return false
                return false;

            // If the name does not start with a letter
            if (!IsLetter(name[0]))
                // It is not a valid identifier, return false
                return false;

            // For each character after the first
            for (int index = 1; index < name.Length; ++index)
                // If the character is not a valid identifier character
                if (!IsIdentifierCharacter(name[index]))
                    // Then name is not a valid identifier, so return false
                    return false;

            // If name passed all the earlier checks, return true
            return true;
        }

        public static bool CanCreateIdentifierFrom(string name)
        {
            return CanConvertToIdentifier(name);
        }

        private static bool CanConvertToIdentifier(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            foreach (char character in name)
                if (IsLetter(character))
                    return true;

            return false;
        }

        private static string ConvertToIdentifier(string name)
        {
            var builder = new StringBuilder(name.Length);

            bool letterFound = false;

            foreach (char character in name)
            {
                if (!letterFound)
                {
                    if (IsLetter(character))
                    {
                        letterFound = true;
                        builder.Append(character);
                    }
                }
                else
                {
                    if (IsIdentifierCharacter(character))
                        builder.Append(character);
                }
            }

            if (!letterFound)
                throw new ArgumentException("Could convert tabTitle to Identifier");

            return builder.ToString();
        }

        private static bool IsLetter(char c)
        {
            return (IsLower(c) || IsUpper(c));
        }

        private static bool IsLower(char c)
        {
            return ((c >= 'a') && (c <= 'z'));
        }

        private static bool IsUpper(char c)
        {
            return ((c >= 'A') && (c <= 'Z'));
        }

        private static bool IsDigit(char c)
        {
            return ((c >= '0') && (c <= '9'));
        }

        private static bool IsLetterOrDigit(char c)
        {
            return (IsLetter(c) || IsDigit(c));
        }

        private static bool IsIdentifierCharacter(char c)
        {
            return (IsLetter(c) || IsDigit(c) || (c == '_'));
        }
    }
}

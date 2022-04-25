using System;
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

namespace ABSpriteEditor.Sprites.IO
{
    public class IndentWriter : TextWriter
    {
        private readonly TextWriter writer;
        private string indentString = "\t";
        private char lastCharacterWritten = '\0';
        private int indentLevel = 0;

        public IndentWriter(TextWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");

            this.writer = writer;
        }

        public IndentWriter(TextWriter writer, string indentString) :
            this(writer)
        {
            if (indentString == null)
                throw new ArgumentNullException("indentString");

            this.indentString = indentString;
        }

        public int IndentLevel
        {
            get { return this.indentLevel; }
        }

        public string IndentString
        {
            get { return this.indentString; }
        }

        public char LastCharacterWritten
        {
            get { return this.lastCharacterWritten; }
        }

        public override Encoding Encoding
        {
            get { return this.writer.Encoding; }
        }

        public override IFormatProvider FormatProvider
        {
            get { return this.writer.FormatProvider; }
        }

        public override string NewLine
        {
            get { return this.writer.NewLine; }
            set { this.writer.NewLine = value; }
        }

        public void IncreaseIndent()
        {
            if (this.indentLevel == int.MaxValue)
                throw new InvalidOperationException("Cannot increase IndentLevel beyond int.MaxValue");

            ++this.indentLevel;
        }

        public void DecreaseIndent()
        {
            if (this.indentLevel == 0)
                throw new InvalidOperationException("Cannot decrease an IndentLevel of 0");

            --this.indentLevel;
        }

        protected void WriteIndent()
        {
            for (int count = 0; count < this.indentLevel; ++count)
                this.writer.Write(this.IndentString);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                this.writer.Dispose();

            base.Dispose(disposing);
        }

        public override void Close()
        {
            this.writer.Close();
            base.Close();
        }

        public override void Flush()
        {
            this.writer.Flush();
            base.Flush();
        }

        public override string ToString()
        {
            return this.writer.ToString();
        }

        public override int GetHashCode()
        {
            return this.writer.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is IndentWriter))
                return false;

            var other = (obj as IndentWriter);

            return (this == other);
        }

        public override object InitializeLifetimeService()
        {
            return this.writer.InitializeLifetimeService();
        }

        #region WriteFrame

        public override void Write(char value)
        {
            // If the previous character was a new line
            // and the character to be written isn't
            if ((this.lastCharacterWritten == '\n') && (value != '\n'))
                // WriteFrame the indent before writing the character
                this.WriteIndent();

            base.Write(value);
            this.writer.Write(value);

            // Keep a copy of the character that was just written
            this.lastCharacterWritten = value;
        }

        public override void Write(string value)
        {
            base.Write(value);
        }

        public override void Write(char[] buffer)
        {
            base.Write(buffer);
        }

        public override void Write(char[] buffer, int index, int count)
        {
            base.Write(buffer, index, count);
        }

        public override void Write(bool value)
        {
            base.Write(value);
        }

        public override void Write(int value)
        {
            base.Write(value);
        }

        public override void Write(long value)
        {
            base.Write(value);
        }

        public override void Write(uint value)
        {
            base.Write(value);
        }

        public override void Write(ulong value)
        {
            base.Write(value);
        }

        public override void Write(float value)
        {
            base.Write(value);
        }

        public override void Write(double value)
        {
            base.Write(value);
        }

        public override void Write(decimal value)
        {
            base.Write(value);
        }

        public override void Write(object value)
        {
            base.Write(value);
        }

        public override void Write(string format, object arg0)
        {
            base.Write(format, arg0);
        }

        public override void Write(string format, object arg0, object arg1)
        {
            base.Write(format, arg0, arg1);
        }

        public override void Write(string format, object arg0, object arg1, object arg2)
        {
            base.Write(format, arg0, arg1, arg2);
        }

        public override void Write(string format, params object[] arg)
        {
            base.Write(format, arg);
        }

        #endregion

        #region WriteLine

        public override void WriteLine()
        {
            base.WriteLine();
        }

        public override void WriteLine(char value)
        {
            base.WriteLine(value);
        }

        public override void WriteLine(string value)
        {
            base.WriteLine(value);
        }

        public override void WriteLine(char[] buffer)
        {
            base.WriteLine(buffer);
        }

        public override void WriteLine(char[] buffer, int index, int count)
        {
            base.WriteLine(buffer, index, count);
        }

        public override void WriteLine(bool value)
        {
            base.WriteLine(value);
        }

        public override void WriteLine(int value)
        {
            base.WriteLine(value);
        }

        public override void WriteLine(long value)
        {
            base.WriteLine(value);
        }

        public override void WriteLine(uint value)
        {
            base.WriteLine(value);
        }

        public override void WriteLine(ulong value)
        {
            base.WriteLine(value);
        }

        public override void WriteLine(float value)
        {
            base.WriteLine(value);
        }

        public override void WriteLine(double value)
        {
            base.WriteLine(value);
        }

        public override void WriteLine(decimal value)
        {
            base.WriteLine(value);
        }

        public override void WriteLine(object value)
        {
            base.WriteLine(value);
        }

        public override void WriteLine(string format, object arg0)
        {
            base.WriteLine(format, arg0);
        }

        public override void WriteLine(string format, object arg0, object arg1)
        {
            base.WriteLine(format, arg0, arg1);
        }

        public override void WriteLine(string format, object arg0, object arg1, object arg2)
        {
            base.WriteLine(format, arg0, arg1, arg2);
        }

        public override void WriteLine(string format, params object[] arg)
        {
            base.WriteLine(format, arg);
        }

        #endregion
    }
}

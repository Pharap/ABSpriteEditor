using System;
using System.IO;

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
    public static class ErrorLogHelper
    {
        public static string CreateErrorLog(Exception exception)
        {
            // Cache the current time,
            // both in localised and UTC+00:00 format
            var now = DateTime.Now;
            var utcNow = DateTime.UtcNow;

            // Create a filename
            var fileName = string.Format("Error-{0:yyyy-MM-dd-HH-mm-ss-ffff}", now);

            // Create the file path
            var filePath = Path.Combine(Environment.CurrentDirectory, Path.ChangeExtension(fileName, "log"));

            // Create the file writer
            using (var writer = new StreamWriter(filePath))
            {
                // Log the date on which the error occurred
                writer.WriteLine("UTC Date: {0:yyyy'/'MM'/'dd}", utcNow);

                // Log the time (at UTC+00:00) at which the error occurred
                writer.WriteLine("UTC Time: {0:HH':'mm':'ss.ffff}", utcNow);

                // Log the local date on which the error occurred
                writer.WriteLine("Local Date: {0:yyyy'/'MM'/'dd}", now);

                // Log the local time at which the error occurred
                writer.WriteLine("Local Time: {0:HH':'mm':'ss.ffff}", now);

                // Log the local time zone
                writer.WriteLine("Time Zone: UTC{0:zzz}", now);

                // Add a blank line for clarity
                writer.WriteLine();

                // Loop from the current exception to its deepest inner exception
                for (var current = exception; current != null; current = exception.InnerException)
                    // Log the exception info
                    LogException(writer, current);
            }

            // Return the path that the error was written to
            return filePath;
        }

        private static void LogException(TextWriter writer, Exception exception)
        {
            // Log the exception type
            writer.WriteLine("Type: {0}", exception.GetType());

            // Log the exception source
            writer.WriteLine("Source: {0}", exception.Source);

            // Log the exeption message
            writer.Write("Message: ");
            writer.WriteLine(exception.Message);

            // Log the stack trace with special formatting
            writer.WriteLine("Stack:");
            LogStackTrace(writer, exception.StackTrace);
        }

        // The stack track is to be bulled apart and written with custom formatting
        private static void LogStackTrace(TextWriter writer, string stackTrace)
        {
            // Open the stack trace with a text reader
            using (var reader = new StringReader(stackTrace))
                // While the reader still has input to process
                while (reader.Peek() != -1)
                {
                    // Read a line of the stack trace
                    var line = reader.ReadLine();

                    // Try to find the function part of the line
                    var functionPosition = line.IndexOf("at ");

                    // Try to find the file part of the line
                    var filePosition = line.IndexOf(" in ");

                    // If the function wasn't specified in this line
                    // (Note: This shouldn't happen with a proper stack trace)
                    if (functionPosition == -1)
                    {
                        // Write the line verbatim
                        writer.WriteLine(line);

                        // Move onto the next line
                        continue;
                    }

                    // Extract the function text
                    var functionText =
                        // If the file position wasn't found
                        (filePosition == -1) ?
                        // Take everything from the function position onwards
                        line.Substring(functionPosition) :
                        // Otherwise, take everything up to the start of the file text
                        line.Substring(functionPosition, filePosition - functionPosition);

                    // Indent
                    writer.Write('\t');

                    // Write the function text
                    writer.WriteLine(functionText);

                    // If the file was specified in this line
                    if (filePosition != -1)
                    {
                        // Indent
                        writer.Write('\t');

                        // Extract the file text
                        var fileText = line.Substring(filePosition + 1);

                        // Write the file text
                        writer.WriteLine(fileText);
                    }
                }
        }
    }
}

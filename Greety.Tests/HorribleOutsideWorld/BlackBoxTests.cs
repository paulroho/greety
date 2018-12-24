using System;
using System.Diagnostics;
using System.IO;
using FluentAssertions;
using Xunit;

namespace Greety.Tests.HorribleOutsideWorld
{
    public class BlackBoxTests
    {
        [Fact]
        public void GreetsHelloWorldOnALine()
        {
            var process = PrepareGreetyProcess();

            // Act
            process.Start();

            process.StandardInput.WriteLine("Paul");
            var output = process.StandardOutput.ReadToEnd();
            output.Should().Be("What's your name? \r\nHello World, Paul!\r\n");
        }

        private Process PrepareGreetyProcess()
        {
            var path = @"..\..\..\..\Greety\bin\Debug\netcoreapp2.1\greety.dll";
            var fileInfo = new FileInfo(path);
            var commandLine = $@"""{Environment.GetEnvironmentVariable("ProgramFiles")}\dotnet\dotnet.exe"" ""{fileInfo.FullName}""";
            var process = new Process
            {
                StartInfo = new ProcessStartInfo(commandLine)
                {
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                }
            };
            return process;
        }
    }
}

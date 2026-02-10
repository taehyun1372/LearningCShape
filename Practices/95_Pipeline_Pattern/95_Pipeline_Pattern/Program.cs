using System;
using System.Collections.Generic;

namespace _95_Pipeline_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var pipeline = new Pipeline<string>()
                .AddStep(new ToUpperStep())
                .AddStep(new AppendTextStep(" - appened text"));

            string input = "Hello World";
            string result = pipeline.Exectue(input);

            Console.WriteLine(result);

            Console.WriteLine("Goodbye World");
            Console.ReadLine();
        }
    }

    public class Pipeline<T>
    {
        private readonly List<IPipelineStep<T>> _steps = new List<IPipelineStep<T>>();

        public Pipeline<T> AddStep(IPipelineStep<T> step)
        {
            _steps.Add(step);
            return this;
        }

        public T Exectue(T input)
        {
            T result = input;
            foreach (var step in _steps) result = step.Process(result);
            return result;
        }

    }


    public interface IPipelineStep<T>
    {
        public T Process(T input);
    }

    public class ToUpperStep : IPipelineStep<string>
    {
        public string Process(string input)
        {
            return input.ToUpper();
        }
    }

    public class AppendTextStep : IPipelineStep<string>
    {
        private readonly string _textToAppend;
        public AppendTextStep(string textToAppend)
        {
            _textToAppend = textToAppend;
        }

        public string Process(string input)
        {
            return input + _textToAppend;
        }
    }
}

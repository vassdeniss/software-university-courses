using System;

namespace BE01.PipesInPool {
    class Program {
        static void Main(string[] args) {
            int poolCapacity = int.Parse(Console.ReadLine());
            int flowRatePipeOne = int.Parse(Console.ReadLine());
            int flowRatePipeTwo = int.Parse(Console.ReadLine());
            double workerAFK = double.Parse(Console.ReadLine());

            double flowedWaterPipeOne = flowRatePipeOne * workerAFK;
            double flowedWaterPipeTwo = flowRatePipeTwo * workerAFK;
            double flowedWater = flowedWaterPipeOne + flowedWaterPipeTwo;

            if (flowedWater <= poolCapacity) {
                double poolPercent = (flowedWater / poolCapacity) * 100;
                double pipeOnePercent = (flowedWaterPipeOne / flowedWater) * 100;
                double pipeTwoPercent = (flowedWaterPipeTwo / flowedWater) * 100;
                Console.WriteLine($"The pool is {poolPercent:f2}% full. " +
                    $"Pipe 1: {pipeOnePercent:f2}%. " +
                    $"Pipe 2: {pipeTwoPercent:f2}%.");
            } else {
                Console.WriteLine($"For {workerAFK:f2} hours " +
                    $"the pool overflows with {flowedWater - poolCapacity:f2} liters.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace E10.SoftUniCoursePlanning
{
    class Program
    {
        static bool IsInList(List<string> list, string lesson)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == lesson)
                {
                    return true;
                }
            }
            return false;
        }

        static bool IsExercise(List<string> list, string lesson)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == lesson)
                {
                    try
                    {
                        if (list[i + 1] == $"{lesson}-Exercise")
                        {
                            return true;
                        }
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        static void Swap(List<string> list, string l1, string l2)
        {
            bool lessonOneExercise = IsExercise(list, l1);
            bool lessonTwoExercise = IsExercise(list, l2);

            string lessonOneTest = $"{l1}-Exercise";
            string lessonTwoTest = $"{l2}-Exercise";

            int lessonOneIndex = 0;
            int lessonTwoIndex = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == l1)
                    lessonOneIndex = i;

                if (list[i] == l2)
                    lessonTwoIndex = i;
            }

            list[lessonOneIndex] = l2;
            list[lessonTwoIndex] = l1;
            if (lessonOneExercise && lessonTwoExercise)
            {
                list[lessonOneIndex + 1] = lessonTwoTest;
                list[lessonTwoIndex + 1] = lessonOneTest;
            }
            else if (lessonTwoExercise)
            {
                list.Remove($"{l2}-Exercise");
                try
                {
                    list.Insert(lessonOneIndex + 1, $"{l2}-Exercise");
                }
                catch (Exception)
                {
                    list.Add($"{l2}-Exercise");
                }
            }
            else if (lessonOneExercise)
            {
                list.Remove($"{l1}-Exercise");
                try
                {
                    list.Insert(lessonTwoIndex + 1, $"{l1}-Exercise");
                }
                catch (Exception)
                {
                    list.Add($"{l1}-Exercise");
                }
            }
        }

        static void Exercise(List<string> list, string lesson)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == lesson)
                    list.Insert(i + 1, $"{lesson}-Exercise");
            }
        }

        static void Main(string[] args)
        {
            List<string> lessonList = Console.ReadLine()
                .Split(", ").ToList();
            string[] cmd = Console.ReadLine().Split(new char[] { ':', ' '});

            while (cmd[0] != "course")
            {
                if (cmd[0] == "Add")
                {
                    if (!IsInList(lessonList, cmd[1]))
                        lessonList.Add(cmd[1]);
                }
                else if (cmd[0] == "Insert")
                {
                    if (!IsInList(lessonList, cmd[1]))
                        lessonList.Insert(int.Parse(cmd[2]), cmd[1]);
                }
                else if (cmd[0] == "Remove")
                {
                    if (IsInList(lessonList, cmd[1]))
                    {
                        if (IsExercise(lessonList, cmd[1]))
                            lessonList.Remove($"{cmd[1]}-Exercise");
                        lessonList.Remove(cmd[1]);
                    }
                }
                else if (cmd[0] == "Swap")
                {
                    if (IsInList(lessonList, cmd[1]) && IsInList(lessonList, cmd[2]))
                        Swap(lessonList, cmd[1], cmd[2]);
                }
                else if (cmd[0] == "Exercise")
                {
                    if (IsInList(lessonList, cmd[1]) && !IsExercise(lessonList, cmd[1]))
                    {
                        Exercise(lessonList, cmd[1]);
                    }
                    else if (!IsInList(lessonList, cmd[1]) && !IsExercise(lessonList, cmd[1]))
                    {
                        lessonList.Add(cmd[1]);
                        lessonList.Add($"{cmd[1]}-Exercise");
                    }

                }

                cmd = Console.ReadLine().Split(new char[] { ':', ' ' });
            }

            int numerator = 1;
            foreach (string s in lessonList)
            {
                Console.WriteLine($"{numerator}.{s}");
                numerator++;
            }
        }
    }
}

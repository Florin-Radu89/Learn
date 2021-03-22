using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnCsharp
{
    interface Guru99Interface
    {
        void SetTutorial(int pID, string pName);
        String GetTutorial();
    }

    class Guru99Tutorial : Guru99Interface
    {
        private const int V = 5;
        protected int TutorialID;
        protected string TutorialName;

        public void SetTutorial(int pID, string pName)
        {
            TutorialID = pID;
            TutorialName = pName;
        }

        public String GetTutorial()
        {
            return TutorialName;
        }

        static void Main(string[] args)
        {
            const int pConst = 5;
            //readonly int y = V; // valid only in instance constructor or static class constructor

            Guru99Tutorial pTutor = new Guru99Tutorial();

            pTutor.SetTutorial(1 + pConst, ".Net by Guru99");

            Console.WriteLine(pTutor.GetTutorial());

            Console.ReadKey();
        }
    }

}

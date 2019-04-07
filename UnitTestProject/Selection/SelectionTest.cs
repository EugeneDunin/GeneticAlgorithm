using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneticAlgorithmProj.Selection;
using GeneticAlgorithm.FuncImpls.Base;

namespace UnitTestProject.Selection
{
    [TestClass]
    public class SelectionTest
    {
        private ISelection selection;
        private FitnessFuncGoal goal;
        private int populationSize, tournamentSize;

        [TestInitialize]
        public void Init()
        {
            goal = FitnessFuncGoal.Min;
            populationSize = 20;
            tournamentSize = 2;
            selection = new TournamentSelection();
        }

        [TestMethod]
        public void TournamentSelectionTest()
        {
            
        }
    }
}

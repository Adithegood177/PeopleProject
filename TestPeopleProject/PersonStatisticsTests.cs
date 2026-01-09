using NUnit.Framework;
using PeopleProject;
using System;
using System.Collections.Generic;

namespace TestPeopleProject
{
    [TestFixture]
    public class PersonStatisticsTests
    {
        private PersonStatistics _stats;
        private List<Person> _testData;

        [SetUp]
        public void Setup()
        {
            _testData = new List<Person>
            {
                new Person(1, "Anna", 20, true, 80),
                new Person(2, "Béla", 30, false, 30), 
                new Person(3, "Cecil", 25, true, 50),
                new Person(4, "Dóra", 25, true, 90)  
            };
            _stats = new PersonStatistics(_testData);
        }

        [Test]
        public void TestGetAverageAge()
        {
            Assert.That(_stats.GetAverageAge(), Is.EqualTo(25.0));
        }

        [Test]
        public void TestGetNumberOfStudents()
        {
            Assert.That(_stats.GetNumberOfStudents(), Is.EqualTo(3));
        }

        [Test]
        public void TestGetPersonWithHighestScore()
        {
            var result = _stats.GetPersonWithHighestScore();
            Assert.That(result.Name, Is.EqualTo("Dóra"));
        }

        [Test]
        public void TestGetAverageScoreOfStudents()
        {
            
            Assert.That(_stats.GetAverageScoreOfStudents(), Is.EqualTo(73.33).Within(0.01));
        }

        [Test]
        public void TestGetOldestStudent()
        {
            
            Assert.That(_stats.GetOldestStudent().Age, Is.EqualTo(25));
        }

        [Test]
        public void TestIsAnyoneFailing_True()
        {
            Assert.That(_stats.IsAnyoneFailing(), Is.True);
        }

        [Test]
        public void TestEmptyList_ReturnsDefaults()
        {
            _stats.People = new List<Person>(); 
            Assert.Multiple(() =>
            {
                Assert.That(_stats.GetAverageAge(), Is.EqualTo(0));
                Assert.That(_stats.GetNumberOfStudents(), Is.EqualTo(0));
                Assert.That(_stats.GetPersonWithHighestScore(), Is.Null);
                Assert.That(_stats.GetAverageScoreOfStudents(), Is.EqualTo(0));
                Assert.That(_stats.GetOldestStudent(), Is.Null);
                Assert.That(_stats.IsAnyoneFailing(), Is.False);
            });
        }

        [Test]
        public void TestConstructor_ThrowsExceptionOnNull()
        {
            Assert.Throws<ArgumentNullException>(() => new PersonStatistics(null));
        }

        [Test]
        public void GetAverageScoreOfStudents_NincsenekTanulok_Nullatadvissza()
        {
            var people = new List<Person>
            {
                new Person(1, "Józsi", 30, false, 80),
                new Person(2, "Pista", 40, false, 90)
            };

            var stats = new PersonStatistics(people);

            Assert.That(stats.GetAverageScoreOfStudents(), Is.EqualTo(0));
        }

        [Test]
        public void GetOldestStudent_NincsenekTanulok_NulltAdVissza()
        {
            var people = new List<Person>
            {
                new Person(1, "Józsi", 30, false, 85),
                new Person(2, "Pista", 40, false, 95)
            };

            var stats = new PersonStatistics(people);

            Assert.That(stats.GetOldestStudent(), Is.Null);
        }

        [Test]
        public void IsAnyoneFailing_FalsetAdVisszaHaSenkinekNincs40Alatt()
        {
            var people = new List<Person>
            {
                new Person(1, "Anna", 20, true, 40),
                new Person(2, "Béla", 22, false, 60)
            };

            var stats = new PersonStatistics(people);

            Assert.That(stats.IsAnyoneFailing(), Is.EqualTo(false));
        }

        [Test]
        public void GetNumberOfStudents_MindegyikHamos_NullatAdVissza()
        {
            var people = new List<Person>
            {
                new Person(1, "Anna", 20, false, 50),
                new Person(2, "Béla", 25, false, 60)
            };

            var stats = new PersonStatistics(people);
            Assert.That(stats.GetNumberOfStudents(), Is.EqualTo(0));
        }

        [Test]
        public void GetAverageScoreOfStudents_TortAtlag_DoubletAdVissza()
        {
            var people = new List<Person>
            {
                new Person(1, "Anna", 20, true, 70),
                new Person(2, "Béla", 21, true, 71)
            };

            var stats = new PersonStatistics(people);

            Assert.That(stats.GetAverageScoreOfStudents(), Is.EqualTo(70.5));
        }
    }
}
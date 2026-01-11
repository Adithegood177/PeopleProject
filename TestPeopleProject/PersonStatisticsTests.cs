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
        public void TestGetAverageAge_MasikLista()
        {
            var people = new List<Person>
            {
                new Person(1, "Test1", 18, true, 50),
                new Person(2, "Test2", 22, false, 60),
                new Person(3, "Test3", 26, true, 70)
            };
            var stats = new PersonStatistics(people);
            Assert.That(stats.GetAverageAge(), Is.EqualTo(22.0));
        }

        [Test]
        public void TestGetNumberOfStudents()
        {
            Assert.That(_stats.GetNumberOfStudents(), Is.EqualTo(3));
        }

        [Test]
        public void TestGetNumberOfStudents_MasikLista()
        {
            var people = new List<Person>
            {
                new Person(1, "Test1", 20, true, 50),
                new Person(2, "Test2", 25, false, 60),
                new Person(3, "Test3", 30, true, 70),
                new Person(4, "Test4", 35, false, 80),
                new Person(5, "Test5", 40, true, 90)
            };
            var stats = new PersonStatistics(people);
            Assert.That(stats.GetNumberOfStudents(), Is.EqualTo(3));
        }

        [Test]
        public void TestGetPersonWithHighestScore()
        {
            var result = _stats.GetPersonWithHighestScore();
            Assert.That(result.Name, Is.EqualTo("Dóra"));
        }

        [Test]
        public void TestGetPersonWithHighestScore_MasikLista()
        {
            var people = new List<Person>
            {
                new Person(1, "Test1", 20, true, 65),
                new Person(2, "Test2", 25, false, 95),
                new Person(3, "Test3", 30, true, 75)
            };
            var stats = new PersonStatistics(people);
            var result = stats.GetPersonWithHighestScore();
            Assert.That(result.Name, Is.EqualTo("Test2"));
            Assert.That(result.Score, Is.EqualTo(95));
        }

        [Test]
        public void TestGetAverageScoreOfStudents()
        {
            
            Assert.That(_stats.GetAverageScoreOfStudents(), Is.EqualTo(73.33).Within(0.01));
        }

        [Test]
        public void TestGetAverageScoreOfStudents_MasikLista()
        {
            var people = new List<Person>
            {
                new Person(1, "Test1", 20, true, 60),
                new Person(2, "Test2", 25, false, 100),
                new Person(3, "Test3", 30, true, 80)
            };
            var stats = new PersonStatistics(people);
            Assert.That(stats.GetAverageScoreOfStudents(), Is.EqualTo(70.0));
        }

        [Test]
        public void TestGetOldestStudent()
        {
            
            Assert.That(_stats.GetOldestStudent().Age, Is.EqualTo(25));
        }

        [Test]
        public void TestGetOldestStudent_MasikLista()
        {
            var people = new List<Person>
            {
                new Person(1, "Test1", 19, true, 60),
                new Person(2, "Test2", 35, false, 70),
                new Person(3, "Test3", 28, true, 80)
            };
            var stats = new PersonStatistics(people);
            Assert.That(stats.GetOldestStudent().Age, Is.EqualTo(28));
            Assert.That(stats.GetOldestStudent().Name, Is.EqualTo("Test3"));
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
        public void GetAverageScoreOfStudents_NincsenekTanulok_MasikLista()
        {
            var people = new List<Person>
            {
                new Person(1, "Test1", 50, false, 45),
                new Person(2, "Test2", 60, false, 55),
                new Person(3, "Test3", 70, false, 65)
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
        public void GetOldestStudent_NincsenekTanulok_MasikLista()
        {
            var people = new List<Person>
            {
                new Person(1, "Test1", 25, false, 70),
                new Person(2, "Test2", 45, false, 80)
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
        public void IsAnyoneFailing_MasikListaFalse()
        {
            var people = new List<Person>
            {
                new Person(1, "Test1", 20, true, 50),
                new Person(2, "Test2", 22, false, 60),
                new Person(3, "Test3", 24, true, 45)
            };

            var stats = new PersonStatistics(people);

            Assert.That(stats.IsAnyoneFailing(), Is.EqualTo(false));
        }

        [Test]
        public void IsAnyoneFailing_MasikListaTrue()
        {
            var people = new List<Person>
            {
                new Person(1, "Test1", 20, true, 35),
                new Person(2, "Test2", 22, false, 60)
            };

            var stats = new PersonStatistics(people);

            Assert.That(stats.IsAnyoneFailing(), Is.EqualTo(true));
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
        public void GetNumberOfStudents_KulonbozoSzamok()
        {
            var people = new List<Person>
            {
                new Person(1, "Test1", 20, true, 50),
                new Person(2, "Test2", 25, true, 60),
                new Person(3, "Test3", 30, false, 70),
                new Person(4, "Test4", 35, true, 80)
            };

            var stats = new PersonStatistics(people);
            Assert.That(stats.GetNumberOfStudents(), Is.EqualTo(3));
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

        [Test]
        public void GetAverageScoreOfStudents_MasikTortAtlag()
        {
            var people = new List<Person>
            {
                new Person(1, "Test1", 20, true, 85),
                new Person(2, "Test2", 21, false, 100),
                new Person(3, "Test3", 22, true, 90)
            };

            var stats = new PersonStatistics(people);

            Assert.That(stats.GetAverageScoreOfStudents(), Is.EqualTo(87.5));
        }
    }
}
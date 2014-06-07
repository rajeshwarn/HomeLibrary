﻿ using System;
using System.Collections.Generic;
using System.Data.Entity;
using KesselRun.HomeLibrary.Model;
using KesselRun.HomeLibrary.Model.Enums;
 using Repository.Pattern.Infrastructure;

namespace KesselRun.HomeLibrary.EF.Db
{
    //public class HomeLibraryInitializer : CreateDatabaseIfNotExists<HomeLibraryContext>
    //public class HomeLibraryInitializer : DropCreateDatabaseIfModelChanges<HomeLibraryContext>
    public class HomeLibraryInitializer : DropCreateDatabaseAlways<HomeLibraryContext>
    {
        protected override void Seed(HomeLibraryContext context)
        {
            context.Configuration.LazyLoadingEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            var johnKennedyToole = new Person
            {
                FirstName = "John",
                LastName = "Kennedy-Toole",
                Email = "john@dunces.com",
                IsAuthor = true,
                ObjectState = ObjectState.Added,
                Sobriquet = "Troubled Genius"
            };

            var hunterSTompson = new Person
            {
                FirstName = "Hunter",
                LastName = "S. Tompson",
                Email = string.Empty,
                IsAuthor = true,
                ObjectState = ObjectState.Added,
                Sobriquet = "Gonzo journo"
            };

            var terryHalpin =
                new Person
                {
                    FirstName = "Terry",
                    LastName = "Halpin",
                    Email = "terry@halpin.com",
                    IsAuthor = true,
                    ObjectState = ObjectState.Added,
                    Sobriquet = "ORM Guy"
                };

            var tonyMorgan =
                new Person
                {
                    FirstName = "Tony",
                    LastName = "Morgan",
                    Email = "tony@halpin.com",
                    IsAuthor = true,
                    ObjectState = ObjectState.Added,
                    Sobriquet = null
                };

            var alanTuring = new Person
            {
                FirstName = "Alan",
                LastName = "Turing",
                Email = "alan@turing.com",
                IsAuthor = false,
                ObjectState = ObjectState.Added,
                Sobriquet = "Father of Awesome"
            };

            var edgarCodd = new Person
            {
                FirstName = "Edgar",
                LastName = "Codd",
                Email = "edgar@codd.com",
                IsAuthor = true,
                ObjectState = ObjectState.Added,
                Sobriquet = "Father of Awesome"
            };

            var markBowden = new Person
            {
                FirstName = "Mark",
                LastName = "Bowden",
                IsAuthor = true,
                ObjectState = ObjectState.Added,
                Email = string.Empty,
            };

            var fredJones = new Person
            {
                FirstName = "Fred",
                LastName = "Jones",
                Email = "fred@jone.com",
                IsAuthor = false,
                ObjectState = ObjectState.Added,
                Sobriquet = "Freddy-boy"
            };

            var rayFeist = new Person
            {
                FirstName = "Raymond E",
                LastName = "Feist",
                Email = "ray@feist.com",
                IsAuthor = true,
                ObjectState = ObjectState.Added,
                Sobriquet = "Magic Man"
            };

            var johnLacey = new Person
            {
                FirstName = "John",
                LastName = "Lacey",
                Email = "jon@lacey.com",
                IsAuthor = false,
                ObjectState = ObjectState.Added,
                Sobriquet = "Lace"
            };

            var renoRaines = new Person
            {
                FirstName = "Reno",
                LastName = "Raines",
                Email = "reno@raines.com",
                IsAuthor = false,
                ObjectState = ObjectState.Added,
                Sobriquet = "Badlands Prowler"
            };

            var bobbySixkiller = new Person
            {
                FirstName = "Bobby",
                LastName = "Sixkiller",
                Email = "bob@sixkiller.com",
                IsAuthor = false,
                ObjectState = ObjectState.Added
            };

            var richardBarker = new Person
            {
                FirstName = "Richard",
                LastName = "Barker",
                Email = "dick@barker.com",
                IsAuthor = false,
                ObjectState = ObjectState.Added
            };

            var tomWolfe = new Person
            {
                FirstName = "Tom",
                LastName = "Wolfe",
                Email = "tom@wolfe.com",
                IsAuthor = false,
                Sobriquet = "Tommy Lad",
                ObjectState = ObjectState.Added,
            };


            var richardRhodes = new Person
            {
                FirstName = "Richard",
                LastName = "Rhodes",
                Email = "richard@tab.com",
                IsAuthor = true,
                ObjectState = ObjectState.Added
            };

            context.People.AddRange(new List<Person>
            {
                johnKennedyToole,
                hunterSTompson,
                terryHalpin,
                tonyMorgan,
                alanTuring,
                edgarCodd,
                markBowden,
                fredJones,
                rayFeist,
                johnLacey,
                renoRaines,
                bobbySixkiller, 
                richardBarker,
                tomWolfe,
                richardRhodes
            });
            //context.SaveChanges();

            var penguin = new Publisher { Name = "Penguin", ObjectState = ObjectState.Added};
            var morganKaufmann = new Publisher { Name = "Morgan Kaufmann", ObjectState = ObjectState.Added };
            var simonAndSchuster = new Publisher { Name = "Simon and Schuster", ObjectState = ObjectState.Added};
            var harperCollins = new Publisher { Name = "Harper Collins", ObjectState = ObjectState.Added };
            var picador = new Publisher { Name = "Picador", ObjectState = ObjectState.Added };

            context.Publishers.AddRange(new List<Publisher> {penguin, morganKaufmann, simonAndSchuster, harperCollins, picador});
            //context.SaveChanges();

            var aConfederacyOfDunces = new Book
            {
                Edition = Edition.First,
                Publisher = penguin,
                Title = "A Confederacy ofDunces",
                TypeOfBook = BookType.Novel,
                ObjectState = ObjectState.Added,
                Authors = new List<Person> {johnKennedyToole}
            };

            var hellsAngels = new Book
            {
                Edition = Edition.First,
                Publisher = penguin,
                Title = "Hells Angels",
                TypeOfBook = BookType.Novel,
                ObjectState = ObjectState.Added,
                Authors = new List<Person> {hunterSTompson}
            };

            var informationModelingAndRelationalDatabases = new Book
            {
                Edition = Edition.Second,
                Publisher = morganKaufmann,
                Title = "Information Modeling and Relational Databases",
                TypeOfBook = BookType.TextBook,
                ObjectState = ObjectState.Added,
                Authors = new List<Person> {terryHalpin, tonyMorgan}
            };

            var killingPablo = new Book
            {
                Edition = Edition.Second,
                Publisher = penguin,
                Title = "Killing Pablo: The Hunt for the World's Greatest Outlaw",
                TypeOfBook = BookType.Novel,
                ObjectState = ObjectState.Added,
                Authors = new List<Person> {markBowden}
            };

            var theMakingOfTheAtomBomb = new Book
            {
                Edition = Edition.Second,
                Publisher = penguin,
                Title = "The Making of the Atom Bomb",
                TypeOfBook = BookType.Novel,
                ObjectState = ObjectState.Added,
                Authors = new List<Person> {richardRhodes}
            };

            var theMagician = new Book
            {
                Edition = Edition.Second,
                Publisher = harperCollins,
                Title = "The Magician",
                TypeOfBook = BookType.Novel,
                ObjectState = ObjectState.Added,
                Authors = new List<Person> {rayFeist}
            };

            var theElectricKoolAidAcidTest = new Book
            {
                Edition = Edition.Second,
                Publisher = picador,
                Title = "The Electric Kool-Aid Acid Test",
                TypeOfBook = BookType.Novel,
                ObjectState = ObjectState.Added,
                Authors = new List<Person> {tomWolfe}
            };

            context.Books.AddRange(new List<Book>
            {
                aConfederacyOfDunces,
                hellsAngels,
                informationModelingAndRelationalDatabases,
                killingPablo,
                theMakingOfTheAtomBomb,
                theMagician,
                theElectricKoolAidAcidTest
            });

            var lendingToTerry = new Lending
            {
                Book = aConfederacyOfDunces,
                DateLent = DateTime.Now,
                ObjectState = ObjectState.Added,
            };

            var lendingToAlan = new Lending
            {
                Book = hellsAngels,
                DateLent = DateTime.Now.Subtract(TimeSpan.FromDays(90)),
                ObjectState = ObjectState.Added,
            };

            var lendingToFred = new Lending
            {
                Book = informationModelingAndRelationalDatabases,
                DateLent = DateTime.Now.Subtract(TimeSpan.FromDays(120)),
                ObjectState = ObjectState.Added,
            };

            var lendingToLace = new Lending
            {
                Book = theMagician,
                DateLent = DateTime.Now.Subtract(TimeSpan.FromDays(4)),
                ObjectState = ObjectState.Added,
            };

            var lendingToReno = new Lending
            {
                Book = killingPablo,
                DateLent = DateTime.Now.Subtract(TimeSpan.FromDays(44)),
                ObjectState = ObjectState.Added,
            };
            
            var lendingToBob = new Lending
            {
                Book = theMakingOfTheAtomBomb,
                DateLent = DateTime.Now.Subtract(TimeSpan.FromDays(1)),
                ObjectState = ObjectState.Added,
            };

            var lendingToDick = new Lending
            {
                Book = theElectricKoolAidAcidTest,
                DateLent = DateTime.Now.Subtract(TimeSpan.FromDays(45)),
                ObjectState = ObjectState.Added,
            };

            context.Lendings.AddRange(new List<Lending>
            {
                lendingToTerry,
                lendingToAlan,
                lendingToFred,
                lendingToLace,
                lendingToReno,
                lendingToBob, lendingToDick
            });

            terryHalpin.Lendings = new List<Lending> {lendingToTerry};
            alanTuring.Lendings = new List<Lending> {lendingToAlan};
            fredJones.Lendings = new List<Lending> {lendingToFred};
            johnLacey.Lendings = new List<Lending> {lendingToLace};
            renoRaines.Lendings = new List<Lending> {lendingToReno};
            bobbySixkiller.Lendings = new List<Lending> {lendingToBob};
            richardBarker.Lendings = new List<Lending> {lendingToDick};

            //context.SaveChanges();

            base.Seed(context);
        }
    }
}

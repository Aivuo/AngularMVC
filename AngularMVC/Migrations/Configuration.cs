namespace AngularMVC.Migrations
{
    using AngularMVC.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Drawing;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AngularMVC.Models.PeopleListDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AngularMVC.Models.PeopleListDb context)
        {
            PeopleListDb db = new PeopleListDb();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //ImageConverter _imageConverter = new ImageConverter();

            //var image = (byte[])_imageConverter.ConvertTo(Image.FromFile("C:\\Users\\Lexicon\\Desktop\\GitHub\\AngularCode\\AngularMVC\\AngularMVC\\AngularMVC\\Content\\Images\\Img (3).png")
            //                                    , typeof(byte[]));
            //var image2 = (byte[])_imageConverter.ConvertTo(Image.FromFile("C:\\Users\\Lexicon\\Desktop\\GitHub\\AngularCode\\AngularMVC\\AngularMVC\\AngularMVC\\Content\\Images\\Img (4).png")
            //                        , typeof(byte[]));
            //var image3 = (byte[])_imageConverter.ConvertTo(Image.FromFile("C:\\Users\\Lexicon\\Desktop\\GitHub\\AngularCode\\AngularMVC\\AngularMVC\\AngularMVC\\Content\\Images\\Img (5).png")
            //                        , typeof(byte[]));
            //var image4 = (byte[])_imageConverter.ConvertTo(Image.FromFile("C:\\Users\\Lexicon\\Desktop\\GitHub\\AngularCode\\AngularMVC\\AngularMVC\\AngularMVC\\Content\\Images\\Img (6).png")
            //                        , typeof(byte[]));
            //var image5 = (byte[])_imageConverter.ConvertTo(Image.FromFile("C:\\Users\\Lexicon\\Desktop\\GitHub\\AngularCode\\AngularMVC\\AngularMVC\\AngularMVC\\Content\\Images\\Img (7).png")
            //                        , typeof(byte[]));
            //var image6 = (byte[])_imageConverter.ConvertTo(Image.FromFile("C:\\Users\\Lexicon\\Desktop\\GitHub\\AngularCode\\AngularMVC\\AngularMVC\\AngularMVC\\Content\\Images\\Img (8).png")
            //                        , typeof(byte[]));
            //var image7 = (byte[])_imageConverter.ConvertTo(Image.FromFile("C:\\Users\\Lexicon\\Desktop\\GitHub\\AngularCode\\AngularMVC\\AngularMVC\\AngularMVC\\Content\\Images\\Img (9).png")
            //                        , typeof(byte[]));
            //var image8 = (byte[])_imageConverter.ConvertTo(Image.FromFile("C:\\Users\\Lexicon\\Desktop\\GitHub\\AngularCode\\AngularMVC\\AngularMVC\\AngularMVC\\Content\\Images\\Img (10).png")
            //                        , typeof(byte[]));
            //var image9 = (byte[])_imageConverter.ConvertTo(Image.FromFile("C:\\Users\\Lexicon\\Desktop\\GitHub\\AngularCode\\AngularMVC\\AngularMVC\\AngularMVC\\Content\\Images\\Img (11).png")
            //                        , typeof(byte[]));
            //var image10 = (byte[])_imageConverter.ConvertTo(Image.FromFile("C:\\Users\\Lexicon\\Desktop\\GitHub\\AngularCode\\AngularMVC\\AngularMVC\\AngularMVC\\Content\\Images\\Img (12).png")
            //                        , typeof(byte[]));
            //var image11 = (byte[])_imageConverter.ConvertTo(Image.FromFile("C:\\Users\\Lexicon\\Desktop\\GitHub\\AngularCode\\AngularMVC\\AngularMVC\\AngularMVC\\Content\\Images\\Img (13).png")
            //                        , typeof(byte[]));
            //var image12 = (byte[])_imageConverter.ConvertTo(Image.FromFile("C:\\Users\\Lexicon\\Desktop\\GitHub\\AngularCode\\AngularMVC\\AngularMVC\\AngularMVC\\Content\\Images\\Img (14).png")
            //                        , typeof(byte[]));
            //var image13 = (byte[])_imageConverter.ConvertTo(Image.FromFile("C:\\Users\\Lexicon\\Desktop\\GitHub\\AngularCode\\AngularMVC\\AngularMVC\\AngularMVC\\Content\\Images\\Img (15).png")
            //                        , typeof(byte[]));
            //var image14 = (byte[])_imageConverter.ConvertTo(Image.FromFile("C:\\Users\\Lexicon\\Desktop\\GitHub\\AngularCode\\AngularMVC\\AngularMVC\\AngularMVC\\Content\\Images\\Img (16).png")
            //                        , typeof(byte[]));

            //context.Countries.AddOrUpdate(
            //    new Country
            //    {
            //        CountryName = "Sweden"
            //    },
            //    new Country
            //    {
            //        CountryName = "Denmark"
            //    },
            //    new Country
            //    {
            //        CountryName = "Norway"
            //    });
            //context.SaveChanges();

            //context.Images.AddOrUpdate(
            //    new MyImage
            //    {
            //        ImageName = "Img3",
            //        Image = image
            //    },
            //    new MyImage
            //    {
            //        ImageName = "Img4",
            //        Image = image2
            //    },
            //    new MyImage
            //    {
            //        ImageName = "Img5",
            //        Image = image3
            //    },
            //    new MyImage
            //    {
            //        ImageName = "Img6",
            //        Image = image4
            //    },
            //    new MyImage
            //    {
            //        ImageName = "Img7",
            //        Image = image5
            //    },
            //    new MyImage
            //    {
            //        ImageName = "Img8",
            //        Image = image6
            //    },
            //    new MyImage
            //    {
            //        ImageName = "Img9",
            //        Image = image7
            //    },
            //    new MyImage
            //    {
            //        ImageName = "Img10",
            //        Image = image8
            //    },
            //    new MyImage
            //    {
            //        ImageName = "Img11",
            //        Image = image9
            //    },
            //    new MyImage
            //    {
            //        ImageName = "Img12",
            //        Image = image10
            //    },
            //    new MyImage
            //    {
            //        ImageName = "Img13",
            //        Image = image11
            //    },
            //    new MyImage
            //    {
            //        ImageName = "Img14",
            //        Image = image12
            //    },
            //    new MyImage
            //    {
            //        ImageName = "Img15",
            //        Image = image13
            //    },
            //    new MyImage
            //    {
            //        ImageName = "Img16",
            //        Image = image14
            //    });
            //context.SaveChanges();

            context.People.AddOrUpdate(
                new Person
                {
                    FirstName = "Happy",
                    LastName = "Hogan",
                    Email = "Hogan@Hogan.com",
                    Country = db.Countries.First(x => x.CountryName == "Denmark"),
                    CountryId = db.Countries.First(x => x.CountryName == "Denmark").CountryId,
                    ProfilePicture = db.Images.First(x => x.ImageName == "Img3"),
                    ProfilePictureId = db.Images.First(x => x.ImageName == "Img3").ImageId
                },
                new Person
                {
                    FirstName = "Olaf",
                    LastName = "Snowman",
                    Email = "KillMe@Faster.com",
                    Country = db.Countries.First(x => x.CountryName == "Norway"),
                    CountryId = db.Countries.First(x => x.CountryName == "Norway").CountryId,
                    ProfilePicture = db.Images.First(x => x.ImageName == "Img4"),
                    ProfilePictureId = db.Images.First(x => x.ImageName == "Img4").ImageId
                }
                );
            context.SaveChanges();
        }
    }
}
